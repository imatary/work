//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stock.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Issue
    {
        public Issue()
        {
            this.IssueDetails = new HashSet<IssueDetail>();
        }
    
        public string IssueID { get; set; }
        public System.DateTime IssueDate { get; set; }
        public string Status { get; set; }
        public bool Active { get; set; }
        public string Note { get; set; }
        public Nullable<long> Price { get; set; }
        public Nullable<long> Total { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string DepartmentID { get; set; }
        public string EmployeeRequest { get; set; }
        public string EmployeeCode { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual ICollection<IssueDetail> IssueDetails { get; set; }
    }
}
