namespace Lib.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.String(nullable: false, maxLength: 30),
                        Name = c.String(nullable: false, maxLength: 150),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Employesses",
                c => new
                    {
                        StaffCode = c.String(nullable: false, maxLength: 30),
                        FullName = c.String(nullable: false, maxLength: 200),
                        DateCheck = c.DateTime(nullable: false),
                        DepartmentID = c.String(nullable: false, maxLength: 30),
                        Note = c.String(),
                        LeaderApproved = c.Boolean(nullable: false),
                        ManagerApproved = c.Boolean(nullable: false),
                        GaComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StaffCode)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employesses", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.Employesses", new[] { "DepartmentID" });
            DropTable("dbo.Employesses");
            DropTable("dbo.Departments");
        }
    }
}
