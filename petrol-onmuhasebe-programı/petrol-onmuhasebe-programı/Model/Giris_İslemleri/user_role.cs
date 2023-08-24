using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrol_onmuhasebe_programı.Model
{
    public class user_role
    {
        [Key]
        public int user_role_ıd { get; set; }
        public string role_name { get; set; }
        public ICollection<login> logins { get; set; }
    }
}
