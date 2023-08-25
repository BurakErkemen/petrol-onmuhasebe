using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using petrol_onmuhasebe_programı.Model.Depo_İslemleri;
using petrol_onmuhasebe_programı.Model.Giris_İslemleri;
namespace petrol_onmuhasebe_programı.Model
{
    class Context:DbContext
    {
        public DbSet<giris_tarihleri> giris_tarihleris { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<user_role> user_roles { get; set; }
        public DbSet<tank_bilgi> tank_Bilgis { get; set; }
    }
}
