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
    
    public partial class Baptizer
    {
        public Baptizer()
        {
            this.Members = new HashSet<Member>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual ICollection<Member> Members { get; set; }
    }
}