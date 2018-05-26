namespace DadVille.Areas.Cover.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        ArtistID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ArtistID);
            
            CreateTable(
                "dbo.Song",
                c => new
                    {
                        SongID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AristID = c.Int(),
                    })
                .PrimaryKey(t => t.SongID)
                .ForeignKey("dbo.Artist", t => t.AristID)
                .Index(t => t.AristID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Song", "AristID", "dbo.Artist");
            DropIndex("dbo.Song", new[] { "AristID" });
            DropTable("dbo.Song");
            DropTable("dbo.Artist");
        }
    }
}
