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
                        kullanıcı_ıd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.giris_ıd);
            
            CreateTable(
                "dbo.logins",
                c => new
                    {
                        ıd = c.Int(nullable: false, identity: true),
                        kullanıcıadı = c.String(),
                        sifre = c.String(),
                        user_rol_ıd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ıd);
            
            CreateTable(
                "dbo.user_role",
                c => new
                    {
                        user_role_ıd = c.Int(nullable: false, identity: true),
                        role_name = c.String(),
                    })
                .PrimaryKey(t => t.user_role_ıd);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.user_role");
            DropTable("dbo.logins");
            DropTable("dbo.giris_tarihleri");
        }
    }
}
