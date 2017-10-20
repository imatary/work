using System;
using System.ComponentModel;

namespace UMC.OQC.Models
{
    [Serializable]
    public class Models
    {
        /// <summary>
        /// ModelID
        /// </summary>
        [DisplayName("ModelID")]
        public string ModelID { get; set; }

        /// <summary>
        /// ModelName
        /// </summary>
        [DisplayName("ModelName")]
        public string ModelName { get; set; }

        /// <summary>
        /// CreatedBy
        /// </summary>
        [DisplayName("CreatedBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// DateCreated
        /// </summary>
        [DisplayName("DateCreated")]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// SerialNo
        /// </summary>
        [DisplayName("SerialNo")]
        public string SerialNo { get; set; }

        /// <summary>
        /// CustomerName
        /// </summary>
        [DisplayName("CustomerName")]
        public string CustomerName { get; set; }

        /// <summary>
        /// CheckWidthModelCus
        /// </summary>
        [DisplayName("CheckWidthModelCus")]
        public bool? CheckWidthModelCus { get; set; }

        /// <summary>
        /// CodeMurata
        /// </summary>
        [DisplayName("CodeMurata")]
        public string CodeMurata { get; set; }

        /// <summary>
        /// FujiHP
        /// </summary>
        [DisplayName("FujiHP")]
        public bool? FujiHP { get; set; }

        /// <summary>
        /// QuantityHP
        /// </summary>
        [DisplayName("QuantityHP")]
        public int? QuantityHP { get; set; }
    }
}
