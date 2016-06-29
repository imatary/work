using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.GA.Data
{
    public class GAStaff
    {
        [StringLength(10)]
        public string StaffCode { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [Key]
        [StringLength(50)]
        public string DeptCode { get; set; }

        public int OrderHistory { get; set; }

        [StringLength(255)]
        public string DeptName { get; set; }

        [StringLength(50)]
        public string ImageName { get; set; }

        public byte[] StaffPicture { get; set; }
    }
}