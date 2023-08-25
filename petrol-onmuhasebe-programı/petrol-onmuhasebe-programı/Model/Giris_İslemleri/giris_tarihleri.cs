using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrol_onmuhasebe_programı.Model.Giris_İslemleri
{
    public class giris_tarihleri
    {
        [Key]
        public int giris_ıd { get; set; }
        public DateTime giris_tarih { get; set; }
        public int ıd { get; set; }
        public user user { get; set; }
    }
}
