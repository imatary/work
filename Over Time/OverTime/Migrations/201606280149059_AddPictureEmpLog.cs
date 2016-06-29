namespace OverTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPictureEmpLog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeesLogs", "CreateBy", c => c.String(nullable: false, maxLength: 256));
            AddColumn("dbo.EmployeesLogs", "StaffPicture", c => c.Binary(storeType: "image"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeesLogs", "StaffPicture");
            DropColumn("dbo.EmployeesLogs", "CreateBy");
        }
    }
}
