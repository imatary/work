using System;
using System.ComponentModel.DataAnnotations;

namespace NichiconSystem
{
    public class Nichicon
    {
        public Nichicon()
        {
            DateCheck = DateTime.Now.ToShortDateString();
            TimeCheck = DateTime.Now.ToShortTimeString();
        }

        [Key]
        public string ProductionID { get; set; }
        public int LineID { get; set; }
        public string BoxID { get; set; }
        public string ModelID { get; set; }
        public string DateCheck { get; set; }
        public string TimeCheck { get; set; }
        public string OperatorCode { get; set; }
        public string ModelCustomer { get; set; }
        public bool? JudgeResult { get; set; }
        public string ModelName { get; set; }
        public string CustomerName { get; set; }
    }
}
