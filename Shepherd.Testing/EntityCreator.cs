using Spackle;
using System;
using System.Linq;
using System.Reflection;

namespace Shepherd.Testing
{
	public static class EntityCreator
	{
		public static T Create<T>()
			where T : new()
		{
			var generator = new RandomObjectGenerator();

			var entity = new T();

			foreach (var property in
				typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
					.Where(_ => _.CanWrite))
			{
				property.SetValue(entity,
					typeof(RandomObjectGenerator)
						.GetMethod("Generate", Type.EmptyTypes)
						.MakeGenericMethod(new[] { property.PropertyType })
						.Invoke(generator, null));
			}

			return entity;
		}

		public static T Create<T>(Action<T> modifier)
			where T : new()
		{
			var entity = EntityCreator.Create<T>();
			modifier(entity);
			return entity;
		}
	}
}