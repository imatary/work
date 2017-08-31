using System;
using System.ComponentModel.DataAnnotations;

namespace UMC.Entities
{
    public class tbl_test_log
    {
        [Key, Required]
        public string ProductionID { get; set; }
        public int LineID { get; set; }
        public string MacAddress { get; set; }
        public string BoxID { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCheck { get; set; }
        public TimeSpan TimeCheck { get; set; }
        public string OperatorCode { get; set; }
        public int Target { get; set; }
        public int Actual { get; set; }
        public bool FullBox { get; set; }
        public bool QA_Check { get; set; }
        public string CheckBy { get; set; }
        public string ModelID { get; set; }

    }
}
