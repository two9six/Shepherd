//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shepherd.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Person
    {
        public Person()
        {
            this.Members = new HashSet<Member>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Gender { get; set; }
        public string Citizenship { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string NameExtension { get; set; }
    
        public virtual ICollection<Member> Members { get; set; }
    }
}
