using System;

namespace Stock.GUI.Models
{
    public class EmployeeView
    {
        public string EmployeeID { get; set; }
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string Alias { get; set; }
        public bool? Sex { get; set; }
        public string Address { get; set; }
        public string HomeTell { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public string Note { get; set; }
        public bool? IsActive { get; set; } 
    }
}