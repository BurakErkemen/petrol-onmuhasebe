using petrol_onmuhasebe_programı.Model.Musteri_Bilgi;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrol_onmuhasebe_programı.Model.vardıya_ıslemlerı
{
    public class veresiye_raporu
    {
        [Key]
        public int Versiyeid { get; set; }
        public int Tutar { get; set; }
        public int Litre { get; set; }
        public string YakıtTürü { get; set; }
        public int FisNo {  get; set; }
        // Her veresiye raporu bir Plaka_kayıt'a bağlı olacak
        public int PlakaId { get; set; }
        public virtual Plaka_kayıt PlakaKayit { get; set; }
        public Musterı_bılgı MusteriBilgi { get; internal set; }
    }

}
