using System;
using System.ComponentModel;

namespace UMC.OQC.Barcode
{
    [Serializable]
    public class NICHICON
    {
        /// <summary>
        /// ProductionID
        /// </summary>
        [DisplayName("ProductionID")]
        public string ProductionID { get; set; }

        /// <summary>
        /// LineID
        /// </summary>
        [DisplayName("LineID")]
        public int LineID { get; set; }

        /// <summary>
        /// BoxID
        /// </summary>
        [DisplayName("BoxID")]
        public string BoxID { get; set; }

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
        /// DateCheck
        /// </summary>
        [DisplayName("DateCheck")]
        public DateTime DateCheck { get; set; }

        /// <summary>
        /// TimeCheck
        /// </summary>
        [DisplayName("TimeCheck")]
        public string TimeCheck { get; set; }

        /// <summary>
        /// OperatorCode
        /// </summary>
        [DisplayName("OperatorCode")]
        public string OperatorCode { get; set; }

        /// <summary>
        /// JudgeResult
        /// </summary>
        [DisplayName("JudgeResult")]
        public string JudgeResult { get; set; }

        /// <summary>
        /// OperatorName
        /// </summary>
        [DisplayName("OperatorName")]
        public string OperatorName { get; set; }
    }
}
