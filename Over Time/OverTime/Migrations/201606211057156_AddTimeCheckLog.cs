namespace OverTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeCheckLog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeesLogs", "TimeCheck", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeesLogs", "TimeCheck");
        }
    }
}
