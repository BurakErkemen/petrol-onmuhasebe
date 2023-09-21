using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrol_onmuhasebe_programı.Model.vardıya_ıslemlerı
{
    public class ekHarcama
    {
        [Key]
        public int HarcamaId { get; set; }
        public string HarcamaAdı { get; set; }
        public int HarcamaTutarı { get; set; }
        public int VardiyaID { get; set; }
        public virtual Vardıya_formu Vardıya { get; set; }
    }

}
