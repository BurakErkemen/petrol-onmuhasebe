using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace petrol_onmuhasebe_programı.Vardıya_Bılgılerı
{
    public partial class Veresiye_formu : Form
    {
        public Veresiye_formu()
        {
            InitializeComponent();
        }
        string musteriAdi;
        string plaka;
        string yakitTuru;
        string litre;
        string tutar;
        private void Veresiye_formu_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            #region Combobox
            combo_Musteri.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_Plaka.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_YakıtTuru.DropDownStyle = ComboBoxStyle.DropDownList;

            combo_YakıtTuru.Items.Add("Motorin");
            combo_YakıtTuru.Items.Add("Optimum");
            combo_YakıtTuru.Items.Add("Otogaz");
            combo_YakıtTuru.Items.Add("Benzin");

            combo_Musteri.Items.Add("musteri1");
            combo_Musteri.Items.Add("musteri");
            combo_Plaka.Items.Add("plaka1");
            combo_Plaka.Items.Add("plaka2");
            #endregion

            #region GridviewColumnName
            DataGridViewTextBoxColumn musteriAdiColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Müşteri Adı"
            };
            DataGridView1.Columns.Add(musteriAdiColumn);

            DataGridViewTextBoxColumn plakaColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Plaka"
            };
            DataGridView1.Columns.Add(plakaColumn);

            DataGridViewTextBoxColumn yakitTuruColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Yakıt Türü"
            };
            DataGridView1.Columns.Add(yakitTuruColumn);

            DataGridViewTextBoxColumn litreColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Litre"
            };
            DataGridView1.Columns.Add(litreColumn);

            DataGridViewTextBoxColumn tutarColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Tutar"
            };
            DataGridView1.Columns.Add(tutarColumn);

            DataGridViewTextBoxColumn fisColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Fiş No"
            };
            DataGridView1.Columns.Add(fisColumn);
            #endregion


        }

        private void Btn_iptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_ekle_Click(object sender, EventArgs e)
        {
            // Müşteri verilerini gridview üzerine gönderme
            /*try
            {
                if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || Txt_litre == null || comboBox3.SelectedItem == null || Txt_tutar == null)
                {
                    MessageBox.Show("Lütfen Gerekli Tüm Alanları Doldurunuz", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Musteri_Adı = comboBox1.SelectedItem.ToString();
                    Plaka = comboBox2.SelectedItem.ToString();
                    Yakıt_Turu = comboBox3.SelectedItem.ToString();
                    Litre = Txt_litre.Text;
                    Tutar = Txt_tutar.Text;
                    DataGridView1.Rows.Add(Musteri_Adı, Plaka, Yakıt_Turu,Litre,Tutar);

                    DataGridViewRow row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = Musteri_Adı }); // 1. sütun
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = Plaka }); // 2. sütun
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = Yakıt_Turu }); // 3. sütun
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = Litre }); // 3. sütun
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = Tutar}); // 3. sütun

                    // DataGridView'e satırı ekle
                    DataGridView1.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            
            try
            {
                if (combo_Musteri.SelectedItem == null || combo_Plaka.SelectedItem == null || Txt_litre.Text == "" || combo_YakıtTuru.SelectedItem == null || Txt_tutar.Text == "")
                {
                    MessageBox.Show("Lütfen Gerekli Tüm Alanları Doldurunuz", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                     musteriAdi = combo_Musteri.SelectedItem.ToString();
                     plaka = combo_Plaka.SelectedItem.ToString();
                     yakitTuru = combo_YakıtTuru.SelectedItem.ToString();
                     litre = Txt_litre.Text;
                     tutar = Txt_tutar.Text;

                    DataGridView1.Rows.Add(musteriAdi, plaka, yakitTuru,litre, tutar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #region Temizlik
            combo_Musteri.SelectedIndex = -1;
            combo_Plaka.SelectedIndex = -1;
            combo_YakıtTuru.SelectedIndex = -1;
            Txt_litre.Clear();
            Txt_tutar.Clear();
            #endregion
        }

        private void Btn_gonder_Click(object sender, EventArgs e)
        {
            //Datagridview içindeki columns ve rowlar vardiya_raporu form sayfasındaki veresiye_tablo'suna post edilecek
        }
    }
}
