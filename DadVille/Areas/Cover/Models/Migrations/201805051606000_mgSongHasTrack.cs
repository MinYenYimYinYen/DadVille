namespace DadVille.Areas.Cover.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgSongHasTrack : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Track",
                c => new
                    {
                        TrackID = c.Int(nullable: false),
                        SongID = c.Int(nullable: false),
                        PathMP3 = c.String(),
                        PathWAV = c.String(),
                        AYouTube = c.String(),
                        PlayBackSource = c.Int(),
                    })
                .PrimaryKey(t => t.TrackID)
                .ForeignKey("dbo.Song", t => t.TrackID)
                .Index(t => t.TrackID);
            
            AddColumn("dbo.Song", "TrackID", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Track", "TrackID", "dbo.Song");
            DropIndex("dbo.Track", new[] { "TrackID" });
            DropColumn("dbo.Song", "TrackID");
            DropTable("dbo.Track");
        }
    }
}
