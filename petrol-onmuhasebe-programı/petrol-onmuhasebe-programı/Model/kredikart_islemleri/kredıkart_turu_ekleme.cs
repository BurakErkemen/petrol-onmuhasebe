using petrol_onmuhasebe_programı.Model.Giris_İslemleri;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrol_onmuhasebe_programı.Model.kredikart_islemleri
{
    public class Kredıkart_turu_ekleme
    {
        [Key]
        public int Kart_ıd { get; set; }
        public string Kart_ad { get; set; }

        //kredikart_vardiya_sayıs ilişkisi
        public virtual ICollection<Kredıkart_vardıya_satıs> KrediKartVardiyaSatislar { get; set; }
    }
}
