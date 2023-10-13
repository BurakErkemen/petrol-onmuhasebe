using petrol_onmuhasebe_programı.Model;
using petrol_onmuhasebe_programı.Model.kredikart_islemleri;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using Context = petrol_onmuhasebe_programı.Model.Context;

namespace petrol_onmuhasebe_programı.Vardıya_Bılgılerı
{
    public partial class Kredikart_Formu : Form
    {
        public Kredikart_Formu()
        {
            InitializeComponent();
        }
        public int VardiyaID;
        private void Kredikart_Formu_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadKrediKartTurleri();
            Grid();
            DataGridView1.AutoGenerateColumns = true;
        }
        private void Grid()
        {
            using (var context = new Context())
            {
                context.Configuration.LazyLoadingEnabled = false;
                var bugunEklenenVeriler = context.KrediKartVardiyaSatislars
                .Where(k => k.VardıyaId == VardiyaID)
                .Select(k => new
                {
                    KartAd = k.Kart.Kart_ad, // Kart adını ilgili sütündan alın
                    k.VardıyaId,
                    k.Kk_gunluk_toplam_tutar
                })
                .ToList();

                DataGridView1.DataSource = bugunEklenenVeriler;

                DataGridView1.Columns["VardıyaId"].HeaderText = "Vardiya Numarası";
                DataGridView1.Columns["Kk_gunluk_toplam_tutar"].HeaderText = "Toplam Satış";

            }
        }

        private void LoadKrediKartTurleri()
        {
            using (var context = new Model.Context())
            {
                // Kredi kartı türlerini veritabanından çek
                var krediKartTurleri = context.KrediKartTurleris.ToList();

                // ComboBox'a eklemek için kredi kartı türlerini döngüyle gezin
                foreach (var kartTuru in krediKartTurleri)
                {
                    comboBox1.Items.Add(kartTuru.Kart_ad);
                }
            }
        }

        private void Btn_İptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_gonder_Click(object sender, EventArgs e)
        {
            //Datagridview2 içindeki columns ve rowlar vardiya_raporu form sayfasındaki veresiye_tablo'suna post edilecek

        }

        private void Btn_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem == null || Txt_kk4.Text == "")
                {
                    MessageBox.Show("Lütfen Gerekli Tüm Alanları Doldurunuz", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Seçilen kredi kartı türünü alın
                    string kartTuru = comboBox1.Text.ToString();

                    // Günlük toplam tutarı alın
                    int gunlukToplamTutar = int.Parse(Txt_kk4.Text);


                    // Veriyi kredikart_vardıya_satıs tablosuna eklemek için ilgili veritabanı işlemlerini yapın
                    using (var context = new Model.Context())
                    {
                        // Seçilen kredi kartının bilgilerini veritabanından alın
                        var kartBilgisi = context.KrediKartTurleris.FirstOrDefault(k => k.Kart_ad == kartTuru);

                        if (kartBilgisi != null)
                        {
                            // Yeni kredikart_vardıya_satıs kaydını oluşturun

                            var yeniKrediKartSatis = new Kredıkart_vardıya_satıs
                            {
                                Kk_gunluk_toplam_tutar = gunlukToplamTutar,
                                Kart = kartBilgisi,
                                VardıyaId = VardiyaID, // VardiyaID != null ? VardiyaID :
                                Kart_ıd = kartBilgisi.Kart_ıd // kartBilgisi != null ? kartBilgisi.Kart_ıd :
                            };
                            context.KrediKartVardiyaSatislars.Add(yeniKrediKartSatis);
                            context.SaveChanges();

                        }
                    }
                    Grid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (ex.InnerException != null)
                {
                    MessageBox.Show("İç Hata: " + ex.InnerException.Message, "İç Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            comboBox1.SelectedIndex = -1;
            Txt_kk4.Clear();
        }

        private int secilenSatirID; // Seçilen satırın ID'sini saklamak için bir değişken

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Geçerli bir satır seçildiğinden emin olun
            {
                DataGridViewRow secilenSatir = DataGridView1.Rows[e.RowIndex];

                // Seçilen satırın verilerini ComboBox ve TextBox'lara atayın
                comboBox1.SelectedItem = secilenSatir.Cells["Kart_ad"].Value; // Kredi kartı adını ayarlayın, "KrediKartAdiColumn" sütununun adını doğru olarak değiştirin
                Txt_kk4.Text = secilenSatir.Cells["Kk_gunluk_toplam_tutar"].Value.ToString(); // Toplam tutarı ayarlayın, "ToplamTutarColumn" sütununun adını doğru olarak değiştirin

                // Seçilen satırın ID'sini saklayın
                secilenSatirID = (int)secilenSatir.Cells["Kk_satıs_ıd"].Value; // Kredi kartı ID'sini ayarlayın, "KrediKartIDColumn" sütununun adını doğru olarak değiştirin
            }
        }

        private void Btn_Güncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (secilenSatirID > 0)
                {
                    string yeniKartAdi = comboBox1.SelectedItem.ToString();
                    int yeniToplamTutar; // int kullanıyoruz

                    if (int.TryParse(Txt_kk4.Text, out yeniToplamTutar)) // int'e dönüşüm yapılıyor
                    {
                        using (var context = new Model.Context())
                        {
                            // Seçilen kredi kartı türünü alın
                            string kartTuru = comboBox1.Text.ToString();

                            // Veriyi güncelleme
                            var güncellenecekKrediKartSatis = context.KrediKartVardiyaSatislars.FirstOrDefault(k => k.Kk_satıs_ıd == secilenSatirID);

                            if (güncellenecekKrediKartSatis != null)
                            {
                                // Kart bilgisi veritabanından alınıyor
                                var kartBilgisi = context.KrediKartTurleris.FirstOrDefault(k => k.Kart_ad == yeniKartAdi);

                                if (kartBilgisi != null)
                                {
                                    güncellenecekKrediKartSatis.Kk_gunluk_toplam_tutar = yeniToplamTutar; // int olarak güncelliyoruz
                                    güncellenecekKrediKartSatis.Kart = kartBilgisi;

                                    context.SaveChanges();

                                    MessageBox.Show("Veri güncellendi.");

                                    Grid();
                                }
                                else
                                {
                                    MessageBox.Show("Seçilen kart bilgisi bulunamadı.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kayıt bulunamadı.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen geçerli bir toplam tutar girin.");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir satır seçin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (secilenSatirID > 0)
            {
                using (var context = new Model.Context())
                {
                    var silinecekKrediKartSatis = context.KrediKartVardiyaSatislars.FirstOrDefault(k => k.Kk_satıs_ıd == secilenSatirID);

                    if (silinecekKrediKartSatis != null)
                    {
                        context.KrediKartVardiyaSatislars.Remove(silinecekKrediKartSatis);
                        context.SaveChanges();

                        MessageBox.Show("Veri silindi.");

                        Grid();
                    }
                    else
                    {
                        MessageBox.Show("Kayıt bulunamadı.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.");
            }
        }
    }
}
