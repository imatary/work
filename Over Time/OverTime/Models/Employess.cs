using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OverTime.Models
{
    public class Employess
    {
        public Employess()
        {
            Id = Guid.NewGuid();
        }

        [Key, Column(Order = 0)]
        public Guid Id { get; set; }

        [Key, Column(Order = 1), StringLength(30)]
        public string StaffCode { get; set; }

        [Required, StringLength(200)]
        public string FullName { get; set; }

        [Column(TypeName = "image")]
        public byte[] StaffPicture { get; set; }

        public DateTime DateCheck { get; set; }

        [Required, StringLength(30)]
        public string DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }

        [Required, StringLength(256), Display(Name = "Leader")]
        public string CreateBy { get; set; }

        public string Note { get; set; }

        public bool LeaderApproved { get; set; }

        public bool ManagerApproved { get; set; }

        public bool GaComplete { get; set; }
    }
}