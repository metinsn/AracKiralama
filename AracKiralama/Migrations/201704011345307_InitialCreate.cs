namespace AracKiralama.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aracs",
                c => new
                    {
                        AracID = c.Int(nullable: false, identity: true),
                        PlakaNo = c.String(),
                        Yas = c.Int(nullable: false),
                        Tip = c.Int(nullable: false),
                        GunlukUcret = c.Double(nullable: false),
                        Kiralandimi = c.Boolean(nullable: false),
                        Silindimi = c.Boolean(nullable: false),
                        AracMarkaID = c.Int(nullable: false),
                        AracModelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AracID)
                .ForeignKey("dbo.AracMarkas", t => t.AracMarkaID, cascadeDelete: true)
                .ForeignKey("dbo.AracModels", t => t.AracModelID, cascadeDelete: true)
                .Index(t => t.AracMarkaID)
                .Index(t => t.AracModelID);
            
            CreateTable(
                "dbo.AracMarkas",
                c => new
                    {
                        AracMarkaID = c.Int(nullable: false, identity: true),
                        Isim = c.String(),
                    })
                .PrimaryKey(t => t.AracMarkaID);
            
            CreateTable(
                "dbo.AracModels",
                c => new
                    {
                        AracModelID = c.Int(nullable: false, identity: true),
                        Isim = c.String(),
                        MarkaID = c.Int(nullable: false),
                        Marka_AracMarkaID = c.Int(),
                    })
                .PrimaryKey(t => t.AracModelID)
                .ForeignKey("dbo.AracMarkas", t => t.Marka_AracMarkaID)
                .Index(t => t.Marka_AracMarkaID);
            
            CreateTable(
                "dbo.Kiras",
                c => new
                    {
                        KiraID = c.Int(nullable: false, identity: true),
                        AlisTarihi = c.DateTime(nullable: false),
                        KiralamaSuresi = c.Int(nullable: false),
                        ToplamUcret = c.Double(nullable: false),
                        AracID = c.Int(nullable: false),
                        MusteriID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KiraID)
                .ForeignKey("dbo.Aracs", t => t.AracID, cascadeDelete: true)
                .ForeignKey("dbo.Musteris", t => t.MusteriID, cascadeDelete: true)
                .Index(t => t.AracID)
                .Index(t => t.MusteriID);
            
            CreateTable(
                "dbo.Musteris",
                c => new
                    {
                        MusteriID = c.Int(nullable: false, identity: true),
                        Isim = c.String(),
                        Soyisim = c.String(),
                        Telefon = c.String(),
                    })
                .PrimaryKey(t => t.MusteriID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kiras", "MusteriID", "dbo.Musteris");
            DropForeignKey("dbo.Kiras", "AracID", "dbo.Aracs");
            DropForeignKey("dbo.Aracs", "AracModelID", "dbo.AracModels");
            DropForeignKey("dbo.AracModels", "Marka_AracMarkaID", "dbo.AracMarkas");
            DropForeignKey("dbo.Aracs", "AracMarkaID", "dbo.AracMarkas");
            DropIndex("dbo.Kiras", new[] { "MusteriID" });
            DropIndex("dbo.Kiras", new[] { "AracID" });
            DropIndex("dbo.AracModels", new[] { "Marka_AracMarkaID" });
            DropIndex("dbo.Aracs", new[] { "AracModelID" });
            DropIndex("dbo.Aracs", new[] { "AracMarkaID" });
            DropTable("dbo.Musteris");
            DropTable("dbo.Kiras");
            DropTable("dbo.AracModels");
            DropTable("dbo.AracMarkas");
            DropTable("dbo.Aracs");
        }
    }
}
