using Shepherd.Core.Enums;
using Shepherd.Data.Contracts.Infrastructure;
using Shepherd.Data.Infrastructure;
using Shepherd.Domain.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shepherd.Domain.Models
{
    public class MembersDetail : IMembersDetail
    {
        public int Id { get; set; }

        public string ChurchId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string PlaceOfBirth { get; set; }

        public string Gender { get; set; }

        public string Citizenship { get; set; }

        public Address Address { get; set; }

        public DateTime? DateBaptized { get; set; }

        public Baptizer Baptizer { get; set; }

        public string MaritalStatus { get; set; }

        public string SpouseName { get; set; }

        public ContactInformation ContactInformation { get; set; }

        public MemberStatuses Status { get; set; }

        public DesignationTypes Type { get; set; }

        public Designations Designation { get; set; }

        public int CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? DateModified { get; set; }

        private readonly IUnitOfWork unitOfWork;


        public MembersDetail()
            : this(UnitOfWork.Instance)
        { 
        }

        public MembersDetail(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

        public void Load()
        {
            var member = unitOfWork.MemberRepository.GetById(this.Id);

            this.ChurchId = member.ChurchId;
            this.FirstName = member.Person.FirstName;
            this.LastName = member.Person.LastName;
            this.MiddleName = member.Person.MiddleName;
            this.BirthDate = member.Person.BirthDate;
            this.PlaceOfBirth = member.Person.PlaceOfBirth;
            this.Gender = member.Person.Gender;
            this.Citizenship = member.Person.Citizenship;
            this.Address = new Address() { 
                AddressLine1 = member.Person.AddressLine1,
                AddressLine2 = member.Person.AddressLine2,
                City = member.Person.City,
                Country = member.Person.Country,
                StateProvince = member.Person.StateProvince
            };
            this.DateBaptized = member.DateBaptized;

            this.Baptizer = new Baptizer() { 
                Id = member.BaptizedById
            };

            this.MaritalStatus = member.MaritalStatus;
            this.SpouseName = member.SpouseName;
            this.ContactInformation = new ContactInformation()
            {
                Email = member.Email,
                LandLine = member.LandLine,
                MobileNumber = member.MobileNumber
            };
            
            this.Status = MemberStatuses.Active;
            this.Type = DesignationTypes.Member;
            this.Designation = Designations.Member;

            this.CreatedBy = member.CreatedBy;
            this.DateCreated = member.DateCreated;
            this.ModifiedBy = member.ModifiedBy;
            this.DateModified = member.DateModified;


        }
    }
}
