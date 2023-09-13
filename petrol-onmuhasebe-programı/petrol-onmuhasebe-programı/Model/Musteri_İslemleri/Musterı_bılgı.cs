using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrol_onmuhasebe_programı.Model.Musteri_Bilgi
{
    public class Musterı_bılgı
    {
        [Key]
        public int MusterıID { get; set; }
        public string MusterıAd { get; set; }
        public string MusterıSoyad { get; set; }
        public int MusteriBorc { get; set; }

        // Plaka kayıtları için ilişki
        public virtual ICollection<Plaka_kayıt> Plaka_Kayıts { get; set; }

        // Müşteri ödemeleri için ilişki
        public virtual ICollection<Musterı_odeme> Musterı_Odemes { get; set; }
    }


}
