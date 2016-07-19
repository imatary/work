using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OQC.Web.Models
{
    public class ModelPCB
    {
        public string ModelID { get; set; }

        [Required]
        [Display(Name = "Tên Model")]
        [StringLength(250), MinLength(5), MaxLength(250)]

        public string ModelName { get; set; }

        [Display(Name = "Tạo bởi")]
        [StringLength(15), MinLength(2), MaxLength(15)]
        public string CreatedBy { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime DateCreated { get; set; }

        [RegularExpression("([0-9][0-9]*)")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Ký tự")]
        public string SerialNo { get; set; }

        [Required()]
        [Display(Name = "Khách hàng")]
        public string CustomerName { get; set; }
    }

    public class ModelPCBAdd
    {
        [Required]
        [Display(Name = "Tên Model")]
        [Remote("CheckModelNameExits", "ModelsPcb", ErrorMessage = "Model đã tồn tại!")]
        [StringLength(250), MinLength(5), MaxLength(250)]
        public string ModelName { get; set; }

        [RegularExpression("([0-9][0-9]*)")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Ký tự")]
        public string SerialNo { get; set; }

        [Required()]
        [Display(Name = "Khách hàng")]
        public string CustomerName { get; set; }
    }

    public class ModelPCBEdit
    {
        [Required]
        [HiddenInput]
        public string ModelID { get; set; }

        [Required]
        [Display(Name = "Tên Model")]
        [StringLength(250), MinLength(5), MaxLength(250)]
        public string ModelName { get; set; }

        [RegularExpression("([0-9][0-9]*)")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Ký tự")]
        [RegularExpression("([0-9][0-9][A-Z][a-z]*)")]
        public string SerialNo { get; set; }

        [Required()]
        [Display(Name = "Khách hàng")]
        public string CustomerName { get; set; }
    }

    //public partial class Model
    //{
    //    public Model()
    //    {
    //        this.PackingPOes = new HashSet<PackingPO>();
    //        this.Shippings = new HashSet<Shipping>();
    //        this.tbl_test_log = new HashSet<tbl_test_log>();
    //    }

    //    public string ModelID { get; set; }
    //    public string ModelName { get; set; }
    //    public string CreatedBy { get; set; }
    //    public System.DateTime DateCreated { get; set; }
    //    public int Quantity { get; set; }
    //    public string SerialNo { get; set; }
    //    public string CustomerName { get; set; }

    //    public virtual ICollection<PackingPO> PackingPOes { get; set; }
    //    public virtual ICollection<Shipping> Shippings { get; set; }
    //    public virtual ICollection<tbl_test_log> tbl_test_log { get; set; }
    //}
}