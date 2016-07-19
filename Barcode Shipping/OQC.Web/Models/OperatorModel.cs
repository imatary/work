using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OQC.Web.Models
{
    public partial class mst_operator
    {
        [Required]
        [MaxLength(5)]
        [MinLength(1)]
        [RegularExpression("([0-9][0-9]*)")]
        [StringLength(5)]
        [Display(Name ="Code")]
        public string OperatorID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name ="Tên")]
        //[RegularExpression("([A-Z][a-z]*)")]
        public string OperatorName { get; set; }
    }

    public class OperatorAddModel
    {
        [Remote("CheckOperatorExits", "Operator", ErrorMessage = "Operator đã tồn tại!")]
        [Required]
        [MaxLength(5)]
        [MinLength(1)]
        [RegularExpression("([0-9][0-9]*)")]
        [StringLength(5)]
        [Display(Name = "Code")]
        public string OperatorID { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Tên")]
        //[RegularExpression("([A-Z][a-z]*)")]
        public string OperatorName { get; set; }
    }
}