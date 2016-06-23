using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OverTime.Models
{
    public class UserDepartments
    {
        [Key, Column(Order = 0)]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Key, Column(Order = 1)]
        public string DepartmentId { get; set; }

        public virtual Department Department { get; set; }

    }
}