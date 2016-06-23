using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Models
{
    public partial class TB_USER_DEPT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nDepartmentIdn { get; set; }

        [Required, StringLength(64)]
        public string sName { get; set; }

        [Required, StringLength(255)]
        public string sDepartment { get; set; }

        public Int16 nDepth { get; set; }

        public int nParentIdn { get; set; }

    }

    //public partial class TB_EVENT_DATA
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    //    public int nEventIdn { get; set; }

    //    [Required]
    //    [StringLength(64)]
    //    public string sName { get; set; }

    //    [Required]
    //    [StringLength(255)]
    //    public string sDescription { get; set; }
    //}
}