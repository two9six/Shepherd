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
    
    public partial class CommitteeMember
    {
        public int Id { get; set; }
        public int CommitteeId { get; set; }
        public int MemberId { get; set; }
        public bool IsCommitteeHead { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    
        public virtual Committee Committee { get; set; }
        public virtual Member Member { get; set; }
    }
}