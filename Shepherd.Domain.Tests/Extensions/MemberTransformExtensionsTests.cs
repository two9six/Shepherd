using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shepherd.Domain.Extensions;
using Shepherd.Domain.Models;
using Shepherd.Domain.Tests.Helpers;
using Spackle;

namespace Shepherd.Domain.Tests.Extensions
{
	[TestClass]
	public class MemberTransformExtensionsTests
	{
		[TestMethod]
		public void LoadFromEntity_WhenUsingValidData_TransformSuccessfully()
		{
			// Arrange
			var random = new RandomObjectGenerator();
			var domainMember = new Member();
			var entityMember = MemberHelpers.CreateEntityMember();

			// Act
			domainMember.LoadFromEntity(entityMember);

			// Assert
			Assert.AreEqual(entityMember.ChurchId, domainMember.ChurchId);
			Assert.AreEqual(entityMember.Person.FirstName, domainMember.FirstName);
			Assert.AreEqual(entityMember.Person.LastName, domainMember.LastName);
			Assert.AreEqual(entityMember.Person.MiddleName, domainMember.MiddleName);
			Assert.AreEqual(entityMember.Person.BirthDate, domainMember.BirthDate);
			Assert.AreEqual(entityMember.Person.PlaceOfBirth, domainMember.PlaceOfBirth);
			Assert.AreEqual(entityMember.Person.Gender, domainMember.Gender);
			Assert.AreEqual(entityMember.Person.Citizenship, domainMember.Citizenship);
			Assert.AreEqual(entityMember.Person.AddressLine1, domainMember.Address.AddressLine1);
			Assert.AreEqual(entityMember.Person.AddressLine2, domainMember.Address.AddressLine2);
			Assert.AreEqual(entityMember.Person.City, domainMember.Address.City);
			Assert.AreEqual(entityMember.Person.StateProvince, domainMember.Address.StateProvince);
			Assert.AreEqual(entityMember.Person.Country, domainMember.Address.Country);
			Assert.AreEqual(entityMember.BaptizerId, domainMember.Baptizer.Id);
			Assert.AreEqual(entityMember.MaritalStatus, domainMember.MaritalStatus);
			Assert.AreEqual(entityMember.SpouseName, domainMember.SpouseName);
			Assert.AreEqual(entityMember.LandLine, domainMember.ContactInformation.LandLine);
			Assert.AreEqual(entityMember.MobileNumber, domainMember.ContactInformation.MobileNumber);
			Assert.AreEqual(entityMember.Email, domainMember.ContactInformation.Email);
			Assert.AreEqual(entityMember.MemberStatusId, (byte)domainMember.MemberStatus);
			Assert.AreEqual(entityMember.DesignationId, (byte)domainMember.Designation);
			Assert.AreEqual(entityMember.CreatedBy, domainMember.CreatedBy);
			Assert.AreEqual(entityMember.DateCreated, domainMember.DateCreated);
			Assert.AreEqual(entityMember.ModifiedBy, domainMember.ModifiedBy);
			Assert.AreEqual(entityMember.DateModified, domainMember.DateModified);
		}

		[TestMethod]
		public void ToEntity_WhenUsingValidData_TransformSuccessfully()
		{
			// Arrange
			var random = new RandomObjectGenerator();
			var domainMember = MemberHelpers.CreateDomainMember();
			var entityMember = new Entities.Member();

			// Act
			entityMember = domainMember.ToEntity();

			// Assert
			Assert.AreEqual(domainMember.ChurchId, entityMember.ChurchId);
			Assert.AreEqual(domainMember.FirstName, entityMember.Person.FirstName);
			Assert.AreEqual(domainMember.LastName, entityMember.Person.LastName);
			Assert.AreEqual(domainMember.MiddleName, entityMember.Person.MiddleName);
			Assert.AreEqual(domainMember.BirthDate, entityMember.Person.BirthDate);
			Assert.AreEqual(domainMember.PlaceOfBirth, entityMember.Person.PlaceOfBirth);
			Assert.AreEqual(domainMember.Gender, entityMember.Person.Gender);
			Assert.AreEqual(domainMember.Citizenship, entityMember.Person.Citizenship);
			Assert.AreEqual(domainMember.Address.AddressLine1, entityMember.Person.AddressLine1);
			Assert.AreEqual(domainMember.Address.AddressLine2, entityMember.Person.AddressLine2);
			Assert.AreEqual(domainMember.Address.City, entityMember.Person.City);
			Assert.AreEqual(domainMember.Address.StateProvince, entityMember.Person.StateProvince);
			Assert.AreEqual(domainMember.Address.Country, entityMember.Person.Country);
			Assert.AreEqual(domainMember.Baptizer.Id, entityMember.BaptizerId);
			Assert.AreEqual(domainMember.MaritalStatus, entityMember.MaritalStatus);
			Assert.AreEqual(domainMember.SpouseName, entityMember.SpouseName);
			Assert.AreEqual(domainMember.ContactInformation.LandLine, entityMember.LandLine);
			Assert.AreEqual(domainMember.ContactInformation.MobileNumber, entityMember.MobileNumber);
			Assert.AreEqual(domainMember.ContactInformation.Email, entityMember.Email);
			Assert.AreEqual((byte)domainMember.MemberStatus, entityMember.MemberStatusId);
			Assert.AreEqual((byte)domainMember.Designation, entityMember.DesignationId);
			Assert.AreEqual(domainMember.CreatedBy, entityMember.CreatedBy);
			Assert.AreEqual(domainMember.DateCreated, entityMember.DateCreated);
			Assert.AreEqual(domainMember.ModifiedBy, entityMember.ModifiedBy);
			Assert.AreEqual(domainMember.DateModified, entityMember.DateModified);
		}
	}
}
