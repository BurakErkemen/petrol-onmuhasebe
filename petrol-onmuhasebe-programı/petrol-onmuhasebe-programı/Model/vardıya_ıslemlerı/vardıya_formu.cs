﻿using petrol_onmuhasebe_programı.Model.kredikart_islemleri;
using petrol_onmuhasebe_programı.Model.Persolel_Bilgi;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrol_onmuhasebe_programı.Model.vardıya_ıslemlerı
{
    public class Vardıya_formu
    {
        [Key]
        public int VardıyaId { get; set; }
        // İlişkili sınıflar için navigation property
        public virtual personel_bilgi Personel1 { get; set; }
        public virtual personel_bilgi Personel2 { get; set; }

        // Normal Kayıtlar
        public int Vardıya_sıra_no { get; set; }
        public DateTime Vardıya_tarıhı { get; set; }
        public int Otogaz_lirte { get; set; }
        public int Otogaz_tutar { get; set; }
        public int Motorin_litre { get; set; }
        public int Motorin_tutar { get; set; }
        public int Optimum_litre { get; set; }
        public int Optimum_tutar { get; set; }
        public int Benzin_litre { get; set; }
        public int Benzin_tutar { get; set; }

        //kredikart_vardıya_satıslar ilişkisi 
        public virtual ICollection<Kredıkart_vardıya_satıs> KrediKartSatisları { get; set; }
        //Ek Harcamalar
        public virtual ICollection<ekHarcama> EkHarcamalar { get; set; }
        // Her vardiya raporu birden çok veresiye raporu içerebilir
        public virtual ICollection<veresiye_raporu> VeresiyeRaporlar { get; set; }

        [NotMapped] // Veritabanına bu özelliği yansıtmamak için [NotMapped] kullanın
        public DateTime VardiyaTarihi => Vardıya_tarıhı;
    }


}
