using System;

namespace BarcodeShipping.Data
{
    public class Murata
    {
        public string ProductionID { get; set; }
        public int LineID { get; set; }
        public string BoxID { get; set; }
        public string ModelID { get; set; }
        public DateTime? DateCheck { get; set; }
        public TimeSpan? TimeCheck { get; set; }
        public string OperatorCode { get; set; }
        public string ModelCustomer { get; set; }
        public bool? JudgeResult { get; set; }
        public string ModelName { get; set; }
        public string CustomerName { get; set; }
    }
}
