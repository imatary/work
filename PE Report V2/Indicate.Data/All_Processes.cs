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
    
    public partial class All_Processes
    {
        public All_Processes()
        {
            this.All_Process_Repair = new HashSet<All_Process_Repair>();
            this.Lines_processes = new HashSet<Lines_processes>();
            this.PCBs = new HashSet<PCB>();
            this.Users_processes = new HashSet<Users_processes>();
        }
    
        public string Id_process { get; set; }
        public string Name_process { get; set; }
        public string Parent_Id { get; set; }
    
        public virtual ICollection<All_Process_Repair> All_Process_Repair { get; set; }
        public virtual ICollection<Lines_processes> Lines_processes { get; set; }
        public virtual ICollection<PCB> PCBs { get; set; }
        public virtual ICollection<Users_processes> Users_processes { get; set; }
    }
}
