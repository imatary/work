namespace Umc.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Olympic_change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Olympics", "CreateBy", c => c.String());
            AddColumn("dbo.Olympics", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Olympics", "CreateDate");
            DropColumn("dbo.Olympics", "CreateBy");
        }
    }
}
