using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrol_onmuhasebe_programı.Model.Depo_İslemleri
{
    public class tank_bilgi
    {
        [Key] 
        public int tank_ıd { get; set; }
        public string tank_ad { get; set; }
        public int tank_hacim { get; set; }
        public int tank_yakıt_turu { get; set; }
    }
}
