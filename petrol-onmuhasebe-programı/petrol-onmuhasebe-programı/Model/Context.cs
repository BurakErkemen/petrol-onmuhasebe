using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using petrol_onmuhasebe_programı.Model.Depo_İslemleri;
using petrol_onmuhasebe_programı.Model.Giris_İslemleri;
using petrol_onmuhasebe_programı.Model.kredikart_islemleri;
using petrol_onmuhasebe_programı.Model.Musteri_Bilgi;
using petrol_onmuhasebe_programı.Model.Persolel_Bilgi;
using petrol_onmuhasebe_programı.Model.vardıya_ıslemlerı;

namespace petrol_onmuhasebe_programı.Model
{
    class Context:DbContext
    {
        //giriş işlemleri
        public DbSet<giris_tarihleri> Giris_tarihleris { get; set; }
        public DbSet<user> Users { get; set; }
        public DbSet<user_role> User_roles { get; set; }
        
        //kredikart işlemleri
        public DbSet<Kredıkart_vardıya_satıs> KrediKartVardiyaSatislars { get; set; }
        public DbSet<Kredıkart_turu_ekleme> KrediKartTurleris { get; set; }

        //depo işlemleri
        public DbSet<Tank_bilgi> Tank_Bilgis { get; set; }
        public DbSet<Tank_dolum> Tank_Dolums { get; set; }

        //müşteri işlemleri
        public DbSet<Musterı_bılgı> Musterı_Bılgıs { get; set; }
        public DbSet<Musterı_odeme> Musterı_Odemes { get; set; }
        public DbSet<Plaka_kayıt> Plaka_Kayıts { get; set; }

        //personel islemleri
        public DbSet<personel_bilgi> Personel_Bilgis { get; set; }

        //vardiya_islemleri
        public DbSet<Vardıya_formu> Vardıya_Formus { get; set; }

    }
}
