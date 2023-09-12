using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace petrol_onmuhasebe_programı.FormPages.Vardıya_Bılgılerı
{
    public partial class EkHarcama : Form
    {
        public EkHarcama()
        {
            InitializeComponent();
        }
        private void EkHarcama_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
        private void Btn_İptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
