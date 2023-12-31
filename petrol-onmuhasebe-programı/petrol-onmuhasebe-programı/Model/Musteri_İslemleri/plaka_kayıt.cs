﻿using petrol_onmuhasebe_programı.Model.vardıya_ıslemlerı;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace petrol_onmuhasebe_programı.Model.Musteri_Bilgi
{
    public class Plaka_kayıt
    {
        [Key]
        public int PlakaId { get; set; }
        public string PlakaNo { get; set; }

        public int MusterıID { get; set; }
        public virtual Musterı_bılgı Musterı_Bılgı { get; set; }
        public override string ToString()
        {
            return this.PlakaNo; 
        }
        public virtual ICollection<veresiye_raporu> VeresiyeRaporlar { get; set; }
    }

}
