﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QUANLYSANXUATEntities : DbContext
    {
        public QUANLYSANXUATEntities()
            : base("name=QUANLYSANXUATEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<All_Process_Repair> All_Process_Repair { get; set; }
        public virtual DbSet<All_Processes> All_Processes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Information_NG> Information_NG { get; set; }
        public virtual DbSet<Line> Lines { get; set; }
        public virtual DbSet<Lines_processes> Lines_processes { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<PCB> PCBs { get; set; }
        public virtual DbSet<Sheet_productions> Sheet_productions { get; set; }
        public virtual DbSet<Show_Result> Show_Result { get; set; }
        public virtual DbSet<Timing> Timings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Users_processes> Users_processes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Line_status> Line_status { get; set; }
    }
}
