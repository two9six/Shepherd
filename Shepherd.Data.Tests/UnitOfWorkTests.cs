using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shepherd.Data.Contracts;
using Spackle;

namespace Shepherd.Data.Tests
{
	[TestClass]
	public class UnitOfWorkTests
	{
		[TestMethod]
		public void Context_Passes_WhenIsNotNull()
		{
			//Arrange

			//Act
			var unitOfWork = new UnitOfWork();

			//Assert

			Assert.IsNotNull(unitOfWork.Context);
		}

		[TestMethod]
		public void Context_Passes_WhenTypeIsShepherdEntities()
		{
			//Arrange

			//Act
			var unitOfWork = new UnitOfWork();

			//Assert
			Assert.AreEqual(typeof(ShepherdEntities), unitOfWork.Context.GetType());
		}

		[TestMethod]
		public void Repositories_Passes_WhenNotNull()
		{
			//Arrange

			//Act
			var unitOfWork = new UnitOfWork();

			//Assert
			Assert.IsNotNull(unitOfWork.LookupRepository);
			Assert.IsNotNull(unitOfWork.LookupTypeRepository);
			Assert.IsNotNull(unitOfWork.PersonRepository);
			Assert.IsNotNull(unitOfWork.MemberRepository);
		}

		[TestMethod]
		public void Save_Passes_WhenInvoked()
		{
			//Arrange
			var generator = new RandomObjectGenerator();
			var expectedResult = generator.Generate<int>();

			var mockEntities = new Mock<IShepherdEntities>(MockBehavior.Strict);
			mockEntities
				.Setup(_ => _.SaveChanges())
				.Returns(expectedResult);

			var unitOfWork = new UnitOfWork();
			unitOfWork.Context = mockEntities.Object;

			//Act
			var actualResult = unitOfWork.Save();

			//Assert
			mockEntities.VerifyAll();
			Assert.AreEqual(expectedResult, actualResult);
		}
	}
}