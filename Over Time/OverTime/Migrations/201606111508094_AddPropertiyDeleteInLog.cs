namespace OverTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiyDeleteInLog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeesLogs", "IsDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeesLogs", "IsDelete");
        }
    }
}
