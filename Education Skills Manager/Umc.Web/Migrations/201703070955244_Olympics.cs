namespace Umc.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Olympics : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Olympics",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StaffCode = c.String(),
                        FullName = c.String(),
                        StaffPicture = c.Binary(),
                        Content = c.String(),
                        TestDate = c.DateTime(nullable: false),
                        Certificate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Olympics");
        }
    }
}
