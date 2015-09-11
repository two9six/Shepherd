using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Infrastructure;
using Shepherd.Entities;
using Shepherd.Entities.Contracts;
using Spackle;

namespace Shepherd.Data.Tests
{
	[TestClass]
	public class UnitOfWorkTests
	{
		[TestMethod]
		public void Context_DefaultValue_IsNotNull()
		{
			//Arrange

			//Act
			var unitOfWork = new UnitOfWork();

			//Assert

			Assert.IsNotNull(unitOfWork.Context);
		}

		[TestMethod]
		public void Context_DefaultValue_IsTypeShepherdEntities()
		{
			//Arrange

			//Act
			var unitOfWork = new UnitOfWork();

			//Assert
			Assert.IsInstanceOfType(unitOfWork.Context, typeof(ShepherdContext));
		}

		[TestMethod]
		public void Repositories_DefaultValue_IsNotNull()
		{
			//Arrange

			//Act
			var unitOfWork = new UnitOfWork();

			//Assert
			Assert.IsNotNull(unitOfWork.DesignationRepository);
			Assert.IsNotNull(unitOfWork.GatheringTypeRepository);
			Assert.IsNotNull(unitOfWork.MemberRepository);
			Assert.IsNotNull(unitOfWork.MemberStatusRepository);
			Assert.IsNotNull(unitOfWork.MemberTypeRepository);
			Assert.IsNotNull(unitOfWork.PersonRepository);	
		}

		[TestMethod]
		public void Save_ContextSaveChanges_IsInvoked()
		{
			//Arrange
			var generator = new RandomObjectGenerator();
			var expectedResult = generator.Generate<int>();

			var mockEntities = new Mock<IShepherdContext>(MockBehavior.Strict);
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