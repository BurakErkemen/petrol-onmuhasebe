using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace petrol_onmuhasebe_programı.FormPages.VeresiyeMüşteri
{
    public partial class MüsteriEkle : Form
    {
        public MüsteriEkle()
        {
            InitializeComponent();
        }
        public string SeçilenMüşteri;
        private void MüsteriEkle_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            #region
            combo_MusteriAdı.DropDownStyle= ComboBoxStyle.DropDownList;
            combo_MusteriSoyad.DropDownStyle= ComboBoxStyle.DropDownList;
            #endregion
        }

        private void Btn_İptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
