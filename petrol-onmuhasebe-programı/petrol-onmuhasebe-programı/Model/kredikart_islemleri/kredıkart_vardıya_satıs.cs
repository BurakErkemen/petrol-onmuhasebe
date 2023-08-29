using petrol_onmuhasebe_programı.Model.Giris_İslemleri;
using petrol_onmuhasebe_programı.Model.vardıya_ıslemlerı;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrol_onmuhasebe_programı.Model.kredikart_islemleri
{
    public class Kredıkart_vardıya_satıs
    {
        [Key]
        public int Kk_satıs_ıd { get; set; }
        public int Kk_gunluk_toplam_tutar { get; set; }


        //vardiya_formu ile ilişki
        [ForeignKey("Vardiya")]
        public int VardıyaId { get; set; }
        public virtual Vardıya_formu Vardiya { get; set; }
    }
}