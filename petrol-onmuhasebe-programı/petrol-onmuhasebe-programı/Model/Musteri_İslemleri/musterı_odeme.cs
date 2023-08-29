using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrol_onmuhasebe_programı.Model.Musteri_Bilgi
{
    public class Musterı_odeme
    {
        [Key]
        public int OdemeId { get; set; }

        public int MusterıId { get; set; }
        public virtual Musterı_bılgı Musterı_Bılgı { get; set; }

        public int Tutar { get; set; }
        public DateTime OdemeTarıhı { get; set; }
        public bool OdemeTuru { get; set; }
    }
}
