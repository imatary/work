namespace UMCWorkManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Code", c => c.String());
            AddColumn("dbo.AspNetUsers", "Dept", c => c.String());
            AddColumn("dbo.AspNetUsers", "Position", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Position");
            DropColumn("dbo.AspNetUsers", "Dept");
            DropColumn("dbo.AspNetUsers", "Code");
        }
    }
}
