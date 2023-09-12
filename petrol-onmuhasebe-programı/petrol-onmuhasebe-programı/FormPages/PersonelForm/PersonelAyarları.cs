using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace petrol_onmuhasebe_programı.FormPages.PersonelForm
{
    public partial class PersonelAyarları : Form
    {
        public PersonelAyarları()
        {
            InitializeComponent();
        }
        private void PersonelAyarları_Load(object sender, EventArgs e)
        {
            #region LoadAyarları
            Btn_Güncelle.Visible= false;
            Btn_Sil.Visible = false;
            #endregion
        }
        private void Btn_İptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PersonelListesi_SelectionChanged(object sender, EventArgs e)
        {
            if (PersonelListesi.SelectedRows.Count == 0)
            {
                Btn_Güncelle.Visible = false;
                Btn_Sil.Visible = false;
            }
            else
            {
                Btn_Güncelle.Visible = true;
                Btn_Sil.Visible = true;
            }
        }
    }
}
