using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrol_onmuhasebe_programı.Model.Depo_İslemleri
{
    public class Tank_dolum
    {
        [Key]
        public int DolumId { get; set; }
        public int Dolum_Litre { get; set; }
        public DateTime Dolum_Tarıhı { get; set; }
        public string FaturaNo { get; set; }
        //tank_bilgi tablosu ilişkisi
        public int TankID { get; set; }
        public virtual Tank_bilgi Tank { get; set; }

    }
}
