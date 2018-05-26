namespace DadVille.Areas.Cover.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgSongHasTags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TagID);
            
            CreateTable(
                "dbo.SongTag",
                c => new
                    {
                        SongID = c.Int(nullable: false),
                        TagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SongID, t.TagID })
                .ForeignKey("dbo.Song", t => t.SongID, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagID, cascadeDelete: true)
                .Index(t => t.SongID)
                .Index(t => t.TagID);
            
            AddColumn("dbo.Song", "ReleaseYear", c => c.Int());
            AddColumn("dbo.Song", "PerformanceTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SongTag", "TagID", "dbo.Tags");
            DropForeignKey("dbo.SongTag", "SongID", "dbo.Song");
            DropIndex("dbo.SongTag", new[] { "TagID" });
            DropIndex("dbo.SongTag", new[] { "SongID" });
            DropColumn("dbo.Song", "PerformanceTime");
            DropColumn("dbo.Song", "ReleaseYear");
            DropTable("dbo.SongTag");
            DropTable("dbo.Tags");
        }
    }
}
