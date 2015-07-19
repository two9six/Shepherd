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

        public MemberStatus Status { get; set; }

        public MemberType Type { get; set; }

        public ChurchDesignation Designation { get; set; }

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

            this.FirstName = member.Person.FirstName;
            this.LastName = member.Person.LastName;
            this.MiddleName = member.Person.MiddleName;
            this.DateCreated = member.DateCreated;
            this.DateBaptized = member.DateBaptized;
            this.Status = MemberStatus.Active;
            this.Type = MemberType.Member;
            this.Designation = ChurchDesignation.Member;

        }
    }
}
