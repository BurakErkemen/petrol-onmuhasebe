using petrol_onmuhasebe_programı.Model;
using petrol_onmuhasebe_programı.Model.kredikart_islemleri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace petrol_onmuhasebe_programı.FormPages.Kredikart
{
    public partial class kredikart : Form
    {
        public kredikart()
        {
            InitializeComponent();
        }

        private void Kredikart_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            GridYükle();
        }
        private void GridYükle()
        {
            using(var context = new Context())
            {
                var kart = context.KrediKartTurleris.ToList();
                BindingList<Kredıkart_turu_ekleme> kredıkarts = new BindingList<Kredıkart_turu_ekleme>(kart);
                KartListesi.DataSource = kredıkarts;

                if (KartListesi.Columns.Contains("PersonelId"))
                {
                    KartListesi.Columns["Kart_ıd"].Visible = false;

                    foreach (DataGridViewRow row in KartListesi.Rows)
                    {
                        if (row.Cells["Kart_ıd"].Value == null)
                        {
                            row.Cells["Kart_ıd"].Value = "";
                        }
                    }
                }
            }
            Txt_BankaAd.Clear();
        }
        private void Txt_BankaAd_TextChanged(object sender, EventArgs e)
        {
            Txt_BankaAd.Text = Txt_BankaAd.Text.ToUpper();
            Txt_BankaAd.SelectionStart = Txt_BankaAd.Text.Length;
        }

        private void Btn_İptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Onayla_Click(object sender, EventArgs e)
        {
            using(var context = new Context())
            {
                var kart = new Kredıkart_turu_ekleme
                {
                    Kart_ad=Txt_BankaAd.Text
                };
                context.SaveChanges();
                GridYükle();
            }
        }

        private void Btn_Güncelle_Click(object sender, EventArgs e)
        {
            using (var context = new Context())
            {

            }
        }

        private void Btn_Sil_Click(object sender, EventArgs e)
        {
            using (var context = new Context())
            {

            }
        }
    }
}
