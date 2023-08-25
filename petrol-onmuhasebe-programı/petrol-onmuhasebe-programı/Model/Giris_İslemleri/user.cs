using petrol_onmuhasebe_programı.Model.Giris_İslemleri;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrol_onmuhasebe_programı.Model
{
    public class user
    {
        [Key]
        public int ıd { get; set; }
        public string kullanıcıadı { get; set; }
        public string sifre { get; set; }
        
        //Her kullanıcının bir rolü olabilir
        public int user_role_ıd { get; set; }
        public user_role user_Role { get; set; }

        //Kullanıcı birden fazla giriş yapabilir.
        public ICollection<giris_tarihleri> Giris_Tarihi { get; set; }
    }
}
