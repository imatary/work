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
    
    public partial class PCB
    {
        public string Id_PCB { get; set; }
        public string Name_PCB { get; set; }
        public System.DateTime Date_time_check { get; set; }
        public string Status_PCB { get; set; }
        public string Id_process { get; set; }
    
        public virtual All_Processes All_Processes { get; set; }
    }
}
