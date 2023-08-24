using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using petrol_onmuhasebe_programı.Model;
namespace petrol_onmuhasebe_programı
{
    public partial class login_Page : Form
    {
        public login_Page()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Context context = new Context();
            context.Database.Create();
        }
    }
}
