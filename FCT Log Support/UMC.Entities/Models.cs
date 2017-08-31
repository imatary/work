using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace UMC.Entities
{
    public class Models
    {
        [Key]
        public string ModelID { get; set; }
        public string ModelName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public int Quantity { get; set; }
        public string SerialNo { get; set; }
        public string CustomerName { get; set; }
        public bool CheckWidthModelCus { get; set; }
        public string CodeMurata { get; set; }

    }
}
