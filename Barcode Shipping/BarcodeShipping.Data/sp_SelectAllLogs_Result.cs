//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BarcodeShipping.Data
{
    using System;
    
    public partial class sp_SelectAllLogs_Result
    {
        public string ProductionID { get; set; }
        public int LineID { get; set; }
        public string MacAddress { get; set; }
        public string BoxID { get; set; }
        public string ModelID { get; set; }
        public string WorkingOder { get; set; }
        public Nullable<System.DateTime> DateCheck { get; set; }
        public Nullable<System.TimeSpan> TimeCheck { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string OperatorCode { get; set; }
        public Nullable<bool> QACheck { get; set; }
    }
}