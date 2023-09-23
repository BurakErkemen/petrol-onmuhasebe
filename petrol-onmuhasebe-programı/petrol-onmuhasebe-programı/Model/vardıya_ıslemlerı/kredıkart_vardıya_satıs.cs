using petrol_onmuhasebe_programı.Model.vardıya_ıslemlerı;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace petrol_onmuhasebe_programı.Model.kredikart_islemleri
{
    public class Kredıkart_vardıya_satıs
    {
        [Key]
        public int Kk_satıs_ıd { get; set; }
        public int Kk_gunluk_toplam_tutar { get; set; }
        public int Kart_ıd { get; set; }
        public virtual Kredıkart_turu_ekleme Kart {  get; set; }
        public int VardıyaId { get; set; }
        public virtual Vardıya_formu Vardiya { get; set; }

        [NotMapped] // Veritabanına bu özelliği yansıtmamak için [NotMapped] kullanın
        public string KartAd { get { return Kart?.Kart_ad; } }
    }

}