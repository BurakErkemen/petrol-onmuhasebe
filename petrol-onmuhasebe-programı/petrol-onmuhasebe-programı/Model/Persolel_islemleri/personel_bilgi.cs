using petrol_onmuhasebe_programı.Model.vardıya_ıslemlerı;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrol_onmuhasebe_programı.Model.Persolel_Bilgi
{
    public class personel_bilgi
    {
        [Key]
        public int PersonelId { get; set; }
        public string PersonelAd { get; set; }
        public string PersonelSoyad { get; set; }
        public string Personel_TcNo { get; set; }
        public string PersonelMaas{ get; set; }
        public DateTime BaslamaTarıhı { get; set; }
        public DateTime BıtısTarıhı{ get; set; }
        public virtual ICollection<Vardıya_formu> VardıyaFormlar { get; set; }

    }
}
