namespace DadVille.Areas.Crypto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        BankID = c.String(nullable: false, maxLength: 8),
                        CurrencyID = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.AccountID)
                .ForeignKey("dbo.Bank", t => t.BankID, cascadeDelete: true)
                .ForeignKey("dbo.Currency", t => t.CurrencyID)
                .Index(t => t.BankID)
                .Index(t => t.CurrencyID);
            
            CreateTable(
                "dbo.Bank",
                c => new
                    {
                        BankID = c.String(nullable: false, maxLength: 8),
                        Name = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.BankID);
            
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        CurrencyID = c.String(nullable: false, maxLength: 8),
                        Name = c.String(maxLength: 32),
                    })
                .PrimaryKey(t => t.CurrencyID);
            
            CreateTable(
                "dbo.PricePoint",
                c => new
                    {
                        PricePointID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceOfID = c.String(nullable: false, maxLength: 8),
                        PricedByID = c.String(nullable: false, maxLength: 8),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PricePointID)
                .ForeignKey("dbo.Currency", t => t.PricedByID)
                .ForeignKey("dbo.Currency", t => t.PriceOfID, cascadeDelete: true)
                .Index(t => t.PriceOfID)
                .Index(t => t.PricedByID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Account", "CurrencyID", "dbo.Currency");
            DropForeignKey("dbo.PricePoint", "PriceOfID", "dbo.Currency");
            DropForeignKey("dbo.PricePoint", "PricedByID", "dbo.Currency");
            DropForeignKey("dbo.Account", "BankID", "dbo.Bank");
            DropIndex("dbo.PricePoint", new[] { "PricedByID" });
            DropIndex("dbo.PricePoint", new[] { "PriceOfID" });
            DropIndex("dbo.Account", new[] { "CurrencyID" });
            DropIndex("dbo.Account", new[] { "BankID" });
            DropTable("dbo.PricePoint");
            DropTable("dbo.Currency");
            DropTable("dbo.Bank");
            DropTable("dbo.Account");
        }
    }
}
