namespace OverTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShiftManageEmployeesLog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeesLogs", "ManageDepartmentShiftApproved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeesLogs", "ManageDepartmentShiftApproved");
        }
    }
}
