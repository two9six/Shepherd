using Shepherd.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shepherd.Domain.Models
{
    public class AddMember
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

        public MemberStatuses MemberStatus { get; set; }

        public Designations Designation { get; set; }

        public int CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
