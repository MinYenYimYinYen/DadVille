namespace DadVille.Areas.Cover.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgSongHasRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        SongID = c.Int(nullable: false),
                        BandMemberID = c.Int(nullable: false),
                        BandMember_BandMemberID = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => t.RoleID)
                .ForeignKey("dbo.BandMember", t => t.BandMember_BandMemberID)
                .ForeignKey("dbo.Song", t => t.SongID, cascadeDelete: true)
                .Index(t => t.SongID)
                .Index(t => t.BandMember_BandMemberID);
            
            CreateTable(
                "dbo.BandMember",
                c => new
                    {
                        BandMemberID = c.String(nullable: false, maxLength: 4),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BandMemberID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Role", "SongID", "dbo.Song");
            DropForeignKey("dbo.Role", "BandMember_BandMemberID", "dbo.BandMember");
            DropIndex("dbo.Role", new[] { "BandMember_BandMemberID" });
            DropIndex("dbo.Role", new[] { "SongID" });
            DropTable("dbo.BandMember");
            DropTable("dbo.Role");
        }
    }
}
