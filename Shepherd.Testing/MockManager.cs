using Moq;
using Moq.Language.Flow;
using Spackle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Shepherd.Testing
{
	public sealed class MockManager
	{
		private readonly List<Mock> Mocks;

		public MockManager()
		{
			this.Mocks = new List<Mock>();
		}

		public Mock<T> GetMock<T>(MockBehavior mockBehavior = MockBehavior.Strict)
			where T : class
		{
			var mock = new Mock<T>(mockBehavior);
			this.Mocks.Add(mock);

			return mock;
		}

		public Mock<T> GetMockAndSetupProperties<T>(MockBehavior mockBehavior = MockBehavior.Strict)
			where T : class
		{
			var generator = new RandomObjectGenerator();
			var mock = this.GetMock<T>(mockBehavior);
			var properties = typeof(T).GetProperties();
			foreach (var prop in properties)
			{
				var lambdaParameter = Expression.Parameter(typeof(T));
				var lambdaBody = Expression.Property(lambdaParameter, prop);
				var value = typeof(RandomObjectGenerator)
							.GetMethods()
							.Single(m => m.Name.Equals("Generate") && !m.GetParameters().Any())
							.MakeGenericMethod(new[] { prop.PropertyType })
							.Invoke(generator, null);

				var func = Expression.Lambda(lambdaBody, lambdaParameter);
				var setup = typeof(Mock<T>)
					.GetMethods()
					.Single(m => m.Name.Equals("Setup") && m.IsGenericMethod)
					.MakeGenericMethod(new[] { prop.PropertyType })
					.Invoke(mock, new[] { func });

				typeof(MockManager)
					.GetMethod("SetupProperty")
					.MakeGenericMethod(new[] { typeof(T), prop.PropertyType })
					.Invoke(null, new[] { setup, value });
			}

			return mock;
		}

		public static void SetupProperty<T, TResult>(object setup, object value)
			where T : class
		{
			((ISetup<T, TResult>)setup).Returns((TResult)value);
		}

		public void Test(Action testAction)
		{
			if (testAction == null)
			{
				throw new ArgumentNullException("testAction");
			}

			testAction();
			this.VerifyAllMocks();
		}

		private void VerifyAllMocks()
		{
			foreach (var mock in this.Mocks)
			{
				mock.VerifyAll();
			}
		}
	}
}