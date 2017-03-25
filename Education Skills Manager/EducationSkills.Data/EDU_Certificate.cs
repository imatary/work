using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationSkills.Data
{
    public partial class EDU_Certificates
    {
        [Key]
        public int ValueMember { get; set; }
        public string DisplayMember { get; set; }
    }
}
