using petrol_onmuhasebe_programı.FormPages.DepoForm;
using petrol_onmuhasebe_programı.Model;
using petrol_onmuhasebe_programı.Model.Depo_İslemleri;
using petrol_onmuhasebe_programı.Model.Musteri_Bilgi;
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
    public partial class VeresiyeMusteri : Form
    {
        public VeresiyeMusteri()
        {
            InitializeComponent();
        }
        private void VeresiyeMusteri_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            GridYükle();
        }


        private void GridYükle()
        {
            using (var context = new Context())
            {

                var musterı_Bılgıs = context.Musterı_Bılgıs.ToList();
                BindingList<Musterı_bılgı> musterı_s = new BindingList<Musterı_bılgı>(musterı_Bılgıs);
                MüsteriTablosu.DataSource = musterı_s;
                musterı_Bılgıs = context.Musterı_Bılgıs.Include("Plaka_Kayıts").ToList();
                musterı_Bılgıs = context.Musterı_Bılgıs.Include("Musterı_Odemes").ToList();

                if (MüsteriTablosu.Columns.Contains("TankDolumlar") || MüsteriTablosu.Columns.Contains("Musterı_Odemes"))
                {
                    MüsteriTablosu.Columns["MusterıID"].Visible = false;

                    foreach (DataGridViewRow row in MüsteriTablosu.Rows)
                    {
                        if (row.Cells["Musterı_Odemes"].Value == null || row.Cells["Plaka_Kayıts"].Value == null)
                        {
                            row.Cells["Musterı_Odemes"].Value = ""; // Null değeri bir boş string ile değiştir
                            row.Cells["Plaka_Kayıts"].Value = ""; // Null değeri bir boş string ile değiştir
                        }
                    }
                }
                /*
                MüsteriTablosu.Columns["Tank_ad"].HeaderText = "Tank Adı";
                MüsteriTablosu.Columns["Tank_hacim"].HeaderText = "Tank Hacmi";
                MüsteriTablosu.Columns["Tank_yakıt_turu"].HeaderText = "Tank Yakıt Türü";
                */
                Txt_Ad.Clear();
                Txt_Soyad.Clear();
            }
        }
        private void Btn_İptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        MüsteriEkle müsteriEkle;
        private void Btn_MüsteriEkle_Click(object sender, EventArgs e)
        {
            if (müsteriEkle == null || müsteriEkle.IsDisposed)
            {
                müsteriEkle = new MüsteriEkle();
                müsteriEkle.Show();
            }
            else
            {
                müsteriEkle.BringToFront();
            }
        }

        private void Btn_MüsteriGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (MüsteriTablosu.SelectedRows == null)
                {
                    MessageBox.Show("Lütfen Bir Müşteri Seçiniz!", "Bildirim", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string seçilenRow = MüsteriTablosu.SelectedRows.ToString();

                    if (müsteriEkle == null || müsteriEkle.IsDisposed)
                    {
                        müsteriEkle.SeçilenMüşteri = seçilenRow;
                        müsteriEkle = new MüsteriEkle();
                        müsteriEkle.Show();
                    }
                    else
                    {
                        müsteriEkle.SeçilenMüşteri = seçilenRow;
                        müsteriEkle.BringToFront();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void Btn_MusteriOlustur_Click(object sender, EventArgs e)
        {
           
        }
    }
}
