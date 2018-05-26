namespace DadVille.Areas.Cover.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Song", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.BandMember", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tags", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tags", "Active");
            DropColumn("dbo.BandMember", "Active");
            DropColumn("dbo.Song", "Active");
        }
    }
}
