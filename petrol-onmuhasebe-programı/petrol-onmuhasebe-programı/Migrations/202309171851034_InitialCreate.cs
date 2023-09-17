namespace petrol_onmuhasebe_programı.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.giris_tarihleri",
                c => new
                    {
                        giris_ıd = c.Int(nullable: false, identity: true),
                        giris_tarih = c.DateTime(nullable: false),
                        ıd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.giris_ıd)
                .ForeignKey("dbo.users", t => t.ıd, cascadeDelete: true)
                .Index(t => t.ıd);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        ıd = c.Int(nullable: false, identity: true),
                        kullanıcıadı = c.String(),
                        sifre = c.String(),
                        user_role_ıd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ıd)
                .ForeignKey("dbo.user_role", t => t.user_role_ıd, cascadeDelete: true)
                .Index(t => t.user_role_ıd);
            
            CreateTable(
                "dbo.user_role",
                c => new
                    {
                        user_role_ıd = c.Int(nullable: false, identity: true),
                        role_name = c.String(),
                    })
                .PrimaryKey(t => t.user_role_ıd);
            
            CreateTable(
                "dbo.Kredıkart_turu_ekleme",
                c => new
                    {
                        Kart_ıd = c.Int(nullable: false, identity: true),
                        Kart_ad = c.String(),
                    })
                .PrimaryKey(t => t.Kart_ıd);
            
            CreateTable(
                "dbo.Kredıkart_vardıya_satıs",
                c => new
                    {
                        Kk_satıs_ıd = c.Int(nullable: false, identity: true),
                        Kk_gunluk_toplam_tutar = c.Int(nullable: false),
                        VardıyaId = c.Int(nullable: false),
                        Kredıkart_turu_ekleme_Kart_ıd = c.Int(),
                    })
                .PrimaryKey(t => t.Kk_satıs_ıd)
                .ForeignKey("dbo.Vardıya_formu", t => t.VardıyaId, cascadeDelete: true)
                .ForeignKey("dbo.Kredıkart_turu_ekleme", t => t.Kredıkart_turu_ekleme_Kart_ıd)
                .Index(t => t.VardıyaId)
                .Index(t => t.Kredıkart_turu_ekleme_Kart_ıd);
            
            CreateTable(
                "dbo.Vardıya_formu",
                c => new
                    {
                        VardıyaId = c.Int(nullable: false, identity: true),
                        Vardıya_sıra_no = c.Int(nullable: false),
                        Vardıya_tarıhı = c.DateTime(nullable: false),
                        Otogaz_lirte = c.Int(nullable: false),
                        Otogaz_tutar = c.Int(nullable: false),
                        Motorin_litre = c.Int(nullable: false),
                        Motorin_tutar = c.Int(nullable: false),
                        Optimum_litre = c.Int(nullable: false),
                        Optimum_tutar = c.Int(nullable: false),
                        Benzin_litre = c.Int(nullable: false),
                        Benzin_tutar = c.Int(nullable: false),
                        personel_bilgi_PersonelId = c.Int(),
                        Personel1_PersonelId = c.Int(),
                        Personel2_PersonelId = c.Int(),
                    })
                .PrimaryKey(t => t.VardıyaId)
                .ForeignKey("dbo.personel_bilgi", t => t.personel_bilgi_PersonelId)
                .ForeignKey("dbo.personel_bilgi", t => t.Personel1_PersonelId)
                .ForeignKey("dbo.personel_bilgi", t => t.Personel2_PersonelId)
                .Index(t => t.personel_bilgi_PersonelId)
                .Index(t => t.Personel1_PersonelId)
                .Index(t => t.Personel2_PersonelId);
            
            CreateTable(
                "dbo.personel_bilgi",
                c => new
                    {
                        PersonelId = c.Int(nullable: false, identity: true),
                        PersonelAd = c.String(),
                        PersonelSoyad = c.String(),
                        Personel_TcNo = c.String(),
                        PersonelMaas = c.String(),
                        BaslamaTarıhı = c.DateTime(nullable: false),
                        BıtısTarıhı = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PersonelId);
            
            CreateTable(
                "dbo.Musterı_bılgı",
                c => new
                    {
                        MusterıID = c.Int(nullable: false, identity: true),
                        MusterıAd = c.String(),
                        MusterıSoyad = c.String(),
                        MusteriBorc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MusterıID);
            
            CreateTable(
                "dbo.Musterı_odeme",
                c => new
                    {
                        OdemeId = c.Int(nullable: false, identity: true),
                        MusterıId = c.Int(nullable: false),
                        Tutar = c.Int(nullable: false),
                        OdemeTarıhı = c.DateTime(nullable: false),
                        OdemeTuru = c.String(),
                    })
                .PrimaryKey(t => t.OdemeId)
                .ForeignKey("dbo.Musterı_bılgı", t => t.MusterıId, cascadeDelete: true)
                .Index(t => t.MusterıId);
            
            CreateTable(
                "dbo.Plaka_kayıt",
                c => new
                    {
                        PlakaId = c.Int(nullable: false, identity: true),
                        PlakaNo = c.String(),
                        MusterıID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlakaId)
                .ForeignKey("dbo.Musterı_bılgı", t => t.MusterıID, cascadeDelete: true)
                .Index(t => t.MusterıID);
            
            CreateTable(
                "dbo.Tank_bilgi",
                c => new
                    {
                        TankId = c.Int(nullable: false, identity: true),
                        Tank_ad = c.String(),
                        Tank_hacim = c.Int(nullable: false),
                        Tank_yakıt_turu = c.String(),
                    })
                .PrimaryKey(t => t.TankId);
            
            CreateTable(
                "dbo.Tank_dolum",
                c => new
                    {
                        DolumId = c.Int(nullable: false, identity: true),
                        Dolum_Litre = c.Int(nullable: false),
                        Dolum_Tarıhı = c.DateTime(nullable: false),
                        FaturaNo = c.String(),
                        TankID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DolumId)
                .ForeignKey("dbo.Tank_bilgi", t => t.TankID, cascadeDelete: true)
                .Index(t => t.TankID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tank_dolum", "TankID", "dbo.Tank_bilgi");
            DropForeignKey("dbo.Plaka_kayıt", "MusterıID", "dbo.Musterı_bılgı");
            DropForeignKey("dbo.Musterı_odeme", "MusterıId", "dbo.Musterı_bılgı");
            DropForeignKey("dbo.Kredıkart_vardıya_satıs", "Kredıkart_turu_ekleme_Kart_ıd", "dbo.Kredıkart_turu_ekleme");
            DropForeignKey("dbo.Vardıya_formu", "Personel2_PersonelId", "dbo.personel_bilgi");
            DropForeignKey("dbo.Vardıya_formu", "Personel1_PersonelId", "dbo.personel_bilgi");
            DropForeignKey("dbo.Vardıya_formu", "personel_bilgi_PersonelId", "dbo.personel_bilgi");
            DropForeignKey("dbo.Kredıkart_vardıya_satıs", "VardıyaId", "dbo.Vardıya_formu");
            DropForeignKey("dbo.users", "user_role_ıd", "dbo.user_role");
            DropForeignKey("dbo.giris_tarihleri", "ıd", "dbo.users");
            DropIndex("dbo.Tank_dolum", new[] { "TankID" });
            DropIndex("dbo.Plaka_kayıt", new[] { "MusterıID" });
            DropIndex("dbo.Musterı_odeme", new[] { "MusterıId" });
            DropIndex("dbo.Vardıya_formu", new[] { "Personel2_PersonelId" });
            DropIndex("dbo.Vardıya_formu", new[] { "Personel1_PersonelId" });
            DropIndex("dbo.Vardıya_formu", new[] { "personel_bilgi_PersonelId" });
            DropIndex("dbo.Kredıkart_vardıya_satıs", new[] { "Kredıkart_turu_ekleme_Kart_ıd" });
            DropIndex("dbo.Kredıkart_vardıya_satıs", new[] { "VardıyaId" });
            DropIndex("dbo.users", new[] { "user_role_ıd" });
            DropIndex("dbo.giris_tarihleri", new[] { "ıd" });
            DropTable("dbo.Tank_dolum");
            DropTable("dbo.Tank_bilgi");
            DropTable("dbo.Plaka_kayıt");
            DropTable("dbo.Musterı_odeme");
            DropTable("dbo.Musterı_bılgı");
            DropTable("dbo.personel_bilgi");
            DropTable("dbo.Vardıya_formu");
            DropTable("dbo.Kredıkart_vardıya_satıs");
            DropTable("dbo.Kredıkart_turu_ekleme");
            DropTable("dbo.user_role");
            DropTable("dbo.users");
            DropTable("dbo.giris_tarihleri");
        }
    }
}
