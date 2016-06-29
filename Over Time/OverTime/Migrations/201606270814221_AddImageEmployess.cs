namespace OverTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageEmployess : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employesses", "StaffPicture", c => c.Binary(storeType: "image"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employesses", "StaffPicture");
        }
    }
}
