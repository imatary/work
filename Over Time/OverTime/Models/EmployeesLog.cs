using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OverTime.Models
{
    public class EmployeesLog
    {
        public EmployeesLog()
        {
            Id = Guid.NewGuid();
        }

        [Key, Column(Order = 0)]
        public Guid Id { get; set; }

        [Key, Column(Order = 1), StringLength(30)]
        public string StaffCode { get; set; }

        [Required, StringLength(200)]
        public string FullName { get; set; }

        public DateTime DateCheck { get; set; }

        public DateTime TimeCheck { get; set; }

        [Required, StringLength(30)]
        public string DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }

        public string Note { get; set; }

        [Display(Name = "Leader Approved")]
        public bool LeaderApproved { get; set; }

        [Display(Name = "Manage Department Shift")]
        public bool ManageDepartmentShiftApproved { get; set; }

        [Display(Name = "Manager Approved")]
        public bool ManagerApproved { get; set; }

        [Display(Name = "GA Approved")]
        public bool GaComplete { get; set; }

        public bool IsDelete { get; set; }

        [Required, StringLength(256), Display(Name = "Leader")]
        public string CreateBy { get; set; }

        [Column(TypeName = "image")]
        public byte[] StaffPicture { get; set; }

    }
}