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

                if (KartListesi.Columns.Contains("Kart_ıd"))
                {
                    KartListesi.Columns["KrediKartVardiyaSatislar"].Visible = false;

                    foreach (DataGridViewRow row in KartListesi.Rows)
                    {
                        if (row.Cells["Kart_ıd"].Value == null)
                        {
                            row.Cells["Kart_ıd"].Value = "";
                        }
                    }
                }
                KartListesi.Columns["Kart_ad"].HeaderText = "Kart Adı";
                KartListesi.Columns["Kart_ıd"].HeaderText = "Kart No";
            }

            Btn_Güncelle.Visible = false;
            Btn_Sil.Visible = false;
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
            try
            {
                using (var context = new Context())
                {
                    var kart = new Kredıkart_turu_ekleme
                    {
                        Kart_ad = Txt_BankaAd.Text
                    };

                    context.KrediKartTurleris.Add(kart);
                    context.SaveChanges();
                    GridYükle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Güncelle_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Context())
                {
                    int selectedPersonelId = Convert.ToInt32(selectedRow.Cells["Kart_ıd"].Value);
                    var Update = context.KrediKartTurleris.FirstOrDefault(p => p.Kart_ıd == selectedPersonelId);

                    if (Update != null)
                    {
                        Update.Kart_ad = Txt_BankaAd.Text;

                        context.SaveChanges();

                        GridYükle();

                        MessageBox.Show("Kart bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kart bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataGridViewRow selectedRow;
        private void Btn_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Silmek İstediğinizden Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (var context = new Context())
                    {
                        // Seçilen satırın PersonelId'sini alın
                        int KartID = Convert.ToInt32(selectedRow.Cells["Kart_ıd"].Value);

                        // Veritabanından seçilen personeli bulun
                        var kart = context.KrediKartTurleris.FirstOrDefault(p => p.Kart_ıd == KartID);

                        if (kart != null)
                        {
                            // İkinci bir onay iletişim kutusu açın
                            if (MessageBox.Show("Tekrar Silmek İstediğinizden Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                // Kullanıcı "Evet" seçeneğini seçtiğinde, personeli veritabanından silin
                                context.KrediKartTurleris.Remove(kart);
                                context.SaveChanges();

                                GridYükle();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void KartListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Eğer tıklanan hücrenin satır endeksi -1 ise (başlık satırı tıklandıysa) işlem yapma
                if (e.RowIndex == -1)
                {
                    return;
                }

                if (e.RowIndex >= 0)
                {
                    selectedRow = KartListesi.SelectedRows[0];
                    Txt_BankaAd.Text = selectedRow.Cells["Kart_ad"].Value.ToString();
                    Btn_Güncelle.Visible = true;
                    Btn_Sil.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString(), "Bildiri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
