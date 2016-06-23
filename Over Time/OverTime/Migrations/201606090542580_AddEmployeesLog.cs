namespace OverTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeesLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeesLogs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StaffCode = c.String(nullable: false, maxLength: 30),
                        FullName = c.String(nullable: false, maxLength: 200),
                        DateCheck = c.DateTime(nullable: false),
                        DepartmentID = c.String(nullable: false, maxLength: 30),
                        Note = c.String(),
                        LeaderApproved = c.Boolean(nullable: false),
                        ManagerApproved = c.Boolean(nullable: false),
                        GaComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.StaffCode })
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeesLogs", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.EmployeesLogs", new[] { "DepartmentID" });
            DropTable("dbo.EmployeesLogs");
        }
    }
}
