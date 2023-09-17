using petrol_onmuhasebe_programı.FormPages.Vardıya_Bılgılerı;
using petrol_onmuhasebe_programı.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace petrol_onmuhasebe_programı.Vardıya_Bılgılerı
{
    public partial class Vardıya_raporu_gır : Form
    {
        public Vardıya_raporu_gır()
        {
            InitializeComponent();
        }
        public int user_role_ıd;
        
        private void Vardıya_raporu_gır_Load(object sender, EventArgs e)
        {
            lbl_ToplamTutar.Visible = false;
            Lbl_ToplamLitre.Visible = false;
            veresiye_tablosu.Visible = false;
            this.WindowState = FormWindowState.Maximized;

            #region combobox
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox3.Items.Add('1');
            comboBox3.Items.Add('2');
            comboBox3.Items.Add('3');
            #endregion

            #region tab_index
            txt_otogaz_litre.TabIndex = 0;
            txt_otogaz_tutar.TabIndex = 1;
            txt_motorin_litre.TabIndex = 2;
            txt_motorin_tutar.TabIndex = 3;
            txt_optimum_litre.TabIndex = 4;
            txt_optimum_tutar.TabIndex = 5;
            txt_benzin_litre.TabIndex = 6;
            txt_benzin_tutar.TabIndex = 7;
            #endregion

        }
        Veresiye_formu Veresiye_Formu;
        Kredikart_Formu Kredikart_formu;
        EkHarcama ekHarcama;
        private void Btn_kredikart_gir_Click(object sender, EventArgs e)
        {
            if (Kredikart_formu == null || Kredikart_formu.IsDisposed)
            {
                Kredikart_formu = new Kredikart_Formu();
                Kredikart_formu.Show();
            }
            else
            {
                Kredikart_formu.BringToFront();
            }
        }
       
        private void Btn_veresiye_ekle_Click(object sender, EventArgs e)
        {
            if (Veresiye_Formu== null || Veresiye_Formu.IsDisposed)
            {
                Veresiye_Formu = new Veresiye_formu();
                Veresiye_Formu.Show();
            }
            else
            {
                Veresiye_Formu.BringToFront();
            }
        }

        private void Btn_EkHarcama_Click(object sender, EventArgs e)
        {
            if (ekHarcama == null || ekHarcama.IsDisposed)
            {
                ekHarcama = new EkHarcama();
                ekHarcama.Show();
            }
            else
            {
                Veresiye_Formu.BringToFront();
            }
        }

        #region Txtbox_tutarlar
        private int sayı1, sayı2, sayı3, sayı4;

        private void Txt_benzin_tutar_TextChanged(object sender, EventArgs e)
        {
            sayı4 = int.Parse(txt_motorin_tutar.Text);
            lbl_ToplamTutar.Text = (sayı1 + sayı2 + sayı3 + sayı4).ToString();
        }

        private void Txt_optimum_tutar_TextChanged(object sender, EventArgs e)
        {
            sayı3 = int.Parse(txt_motorin_tutar.Text);
            lbl_ToplamTutar.Text = (sayı1 + sayı2 + sayı3).ToString();
        }

        private void Txt_motorin_tutar_TextChanged(object sender, EventArgs e)
        {
            sayı2 = int.Parse(txt_motorin_tutar.Text);
            lbl_ToplamTutar.Text = (sayı1 + sayı2).ToString();
        }

        private void Txt_otogaz_tutar_TextChanged(object sender, EventArgs e)
        {
            sayı1 = int.Parse(txt_otogaz_tutar.Text);
            lbl_ToplamTutar.Text = sayı1.ToString();
            lbl_ToplamTutar.Visible = true;
        }
        #endregion

        #region Txtbox_Litreler
        private int lt1, lt2, lt3, lt4;
        private void Txt_otogaz_litre_TextChanged(object sender, EventArgs e)
        {
            lt1 = int.Parse(txt_otogaz_litre.Text);
            Lbl_ToplamLitre.Text = lt1.ToString();
            Lbl_ToplamLitre.Visible=true;
        }
        private void Txt_motorin_litre_TextChanged(object sender, EventArgs e)
        {
            lt2 = int.Parse(txt_motorin_litre.Text);
            Lbl_ToplamLitre.Text = (lt1 + lt2).ToString();
        }

        private void Txt_optimum_litre_TextChanged(object sender, EventArgs e)
        {
            lt3 = int.Parse(txt_optimum_litre.Text);
            Lbl_ToplamLitre.Text = (lt1 + lt2 + lt3).ToString();
        }

        private void Txt_benzin_litre_TextChanged(object sender, EventArgs e)
        {
            lt4 = int.Parse(txt_benzin_litre.Text);
            Lbl_ToplamLitre.Text = (lt1 + lt2 + lt3 + lt4).ToString();
        }
        #endregion

        private void GridYükle()
        {

        }
        private void Btn_Onayla_Click(object sender, EventArgs e)
        {
            try
            {
                using(var context = new Context())
                {

                    GridYükle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString(), "Bildiri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
