namespace OverTime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreateByEmployess : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employesses", "CreateBy", c => c.String(nullable: false, maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employesses", "CreateBy");
        }
    }
}
