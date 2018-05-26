namespace DadVille.Areas.Cover.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgSongHasGenre : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenreID);
            
            CreateTable(
                "dbo.SongGenre",
                c => new
                    {
                        SongID = c.Int(nullable: false),
                        GenreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SongID, t.GenreID })
                .ForeignKey("dbo.Song", t => t.SongID, cascadeDelete: true)
                .ForeignKey("dbo.Genre", t => t.GenreID, cascadeDelete: true)
                .Index(t => t.SongID)
                .Index(t => t.GenreID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SongGenre", "GenreID", "dbo.Genre");
            DropForeignKey("dbo.SongGenre", "SongID", "dbo.Song");
            DropIndex("dbo.SongGenre", new[] { "GenreID" });
            DropIndex("dbo.SongGenre", new[] { "SongID" });
            DropTable("dbo.SongGenre");
            DropTable("dbo.Genre");
        }
    }
}
