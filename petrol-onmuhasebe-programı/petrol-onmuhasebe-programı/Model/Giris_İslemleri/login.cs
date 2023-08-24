using petrol_onmuhasebe_programı.Model.Giris_İslemleri;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrol_onmuhasebe_programı.Model
{
    public class login
    {
        [Key]
        public int ıd { get; set; }
        public string kullanıcıadı { get; set; }
        public string sifre { get; set; }
        public user_role user_role { get; set; }
        public ICollection<giris_tarihleri> Giris_Tarihi { get; set; }
    }
}
