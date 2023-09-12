using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace petrol_onmuhasebe_programı.Vardıya_Bılgılerı
{
    public partial class Kredikart_Formu : Form
    {
        public Kredikart_Formu()
        {
            InitializeComponent();
        }

        private void Kredikart_Formu_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            #region GridviewColumnName
            DataGridViewTextBoxColumn kk1 = new DataGridViewTextBoxColumn
            {
                HeaderText = label1.Text
            };
            DataGridView1.Columns.Add(kk1);

            DataGridViewTextBoxColumn kk2 = new DataGridViewTextBoxColumn
            {
                HeaderText = label2.Text
            };
            DataGridView1.Columns.Add(kk2);

            DataGridViewTextBoxColumn kk3 = new DataGridViewTextBoxColumn
            {
                HeaderText = label3.Text
            };
            DataGridView1.Columns.Add(kk3);

            DataGridViewTextBoxColumn kk4 = new DataGridViewTextBoxColumn
            {
                HeaderText = label4.Text
            };
            DataGridView1.Columns.Add(kk4);
            #endregion
        }

        private void Btn_İptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_gonder_Click(object sender, EventArgs e)
        {
            //Datagridview2 içindeki columns ve rowlar vardiya_raporu form sayfasındaki veresiye_tablo'suna post edilecek

        }
    }
}
