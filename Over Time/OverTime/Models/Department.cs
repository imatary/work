using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OverTime.Models
{
    public class Department
    {
        public Department()
        {
            UserDepartmentses = new HashSet<UserDepartments>();
        }
        
        [Key, StringLength(30)]
        [Display(Name = "ID")]
        public string DepartmentID { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }

        [StringLength(500), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required, StringLength(30)]
        public string ParentID { get; set; }

        public int? Sort { get; set; }

        public virtual ICollection<UserDepartments> UserDepartmentses { get; set; }

    }
}