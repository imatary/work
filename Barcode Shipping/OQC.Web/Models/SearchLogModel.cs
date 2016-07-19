using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OQC.Web.Models
{
    public class SearchLogModel
    {
        public string ProductionID { get; set; }
        public int LineID { get; set; }
        public string MacAddress { get; set; }
        public string BoxID { get; set; }
        public string ModelID { get; set; }
        public bool QA_Check { get; set; }
        public string CheckBy { get; set; }
        public string OperatorCode { get; set; }
        public int OperationID { get; set; }
        public bool JudgeResult { get; set; }
        public DateTime OperationDate { get; set; }
        public string OperatorName { get; set; }
    }
}