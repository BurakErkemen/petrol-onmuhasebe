using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrol_onmuhasebe_programı.Model.Depo_İslemleri
{
    public class Tank_bilgi
    {
        [Key] 
        public int TankId { get; set; }
        public string Tank_ad { get; set; }
        public int Tank_hacim { get; set; }
        public string Tank_yakıt_turu { get; set; }

        //tank_dolum tablosu ilişkisi 
        public virtual ICollection<Tank_dolum> TankDolumlar { get; set; }
        public override string ToString()
        {
            return this.Tank_ad; // Tank_ad özelliğini döndürerek sütunun verisini Tank_ad'a göre göster
        }

    }
}
