//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Indicate.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Timing
    {
        public int Id_time_test { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }
        public Nullable<int> SetPlan { get; set; }
        public Nullable<int> Id_sheet_production { get; set; }
        public Nullable<int> Products_current_hour { get; set; }
    
        public virtual Sheet_productions Sheet_productions { get; set; }
    }
}
