using petrol_onmuhasebe_programı.Model;
using petrol_onmuhasebe_programı.Model.Depo_İslemleri;
using petrol_onmuhasebe_programı.Model.Musteri_Bilgi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace petrol_onmuhasebe_programı.FormPages.VeresiyeMüşteri
{
    public partial class Musteri_Islemlerı : Form
    {
        public Musteri_Islemlerı()
        {
            InitializeComponent();
        }

        private void Musteri_Islemlerı_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            GridYükle();
        }
        private void GridYükle()
        {
            // DataGridView hücrelerin metinlerini ortalamak için varsayılan hücre stilini ayarlayın
            MüsteriTablosu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            using (var context = new Context())
            {
                var MusteriBilgisi = context.Musterı_Bılgıs.Include(m => m.Plaka_Kayıts).ToList();
                BindingList<Musterı_bılgı> musterı_s = new BindingList<Musterı_bılgı>(MusteriBilgisi);
                MüsteriTablosu.DataSource = musterı_s;

                if (MüsteriTablosu.Columns.Contains("MusterıID"))
                {
                    MüsteriTablosu.Columns["MusterıID"].Visible = false;
                    MüsteriTablosu.Columns["Musterı_Odemes"].Visible = false;
                }
                MüsteriTablosu.Columns["MusterıAd"].HeaderText = "Müşteri Adı";
                MüsteriTablosu.Columns["MusterıSoyad"].HeaderText = "Müşteri Soyadı";
                MüsteriTablosu.Columns["MusteriBorc"].HeaderText = "Müşterinin Borcu";
                MüsteriTablosu.Columns["Plaka_Kayıts"].HeaderText = "Plaka";
            }

            // İşlem sonunda kontrolleri temizleyin
            Txt_PlakaGir.Clear();
            Txt_MusteriSoyadı.Clear();
            Txt_MusteriAra.Clear();
            Txt_MusteriAdı.Clear();
            Txt_MusteriBorcu.Clear();
        }

        private void Btn_BorcGuncelleme_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçili müşteriyi bulmak için MusterıID'yi alın
                int selectedMusteriID = Convert.ToInt32(MüsteriTablosu.CurrentRow.Cells["MusterıID"].Value);

                using (var context = new Context())
                {
                    // Musterı_bılgı tablosundan seçilen müşteriyi bulun
                    var musteri = context.Musterı_Bılgıs.FirstOrDefault(m => m.MusterıID == selectedMusteriID);

                    if (musteri != null)
                    {
                        // Borcu güncelleyin
                        musteri.MusteriBorc = Convert.ToInt32(Txt_MusteriBorcu.Text);
                        musteri.MusterıAd = Txt_MusteriAdı.Text;
                        musteri.MusterıSoyad = Txt_MusteriSoyadı.Text;

                        // Değişiklikleri veritabanına kaydedin
                        context.SaveChanges();

                        // Grid'i güncelleyin
                        GridYükle();

                        MessageBox.Show("Müşteri bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Müşteri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region TxtBox_Upper
        private void Txt_MusteriAra_TextChanged(object sender, EventArgs e)
        {
            Txt_MusteriAra.Text = Txt_MusteriAra.Text.ToUpper();
            Txt_MusteriAra.SelectionStart = Txt_MusteriAra.Text.Length;
        }

        private void Txt_MusteriAdı_TextChanged(object sender, EventArgs e)
        {
            Txt_MusteriAdı.Text = Txt_MusteriAdı.Text.ToUpper();
            Txt_MusteriAdı.SelectionStart = Txt_MusteriAdı.Text.Length;
        }

        private void Txt_MusteriSoyadı_TextChanged(object sender, EventArgs e)
        {
            Txt_MusteriSoyadı.Text = Txt_MusteriSoyadı.Text.ToUpper();
            Txt_MusteriSoyadı.SelectionStart = Txt_MusteriSoyadı.Text.Length;
        }

        private void Txt_MusteriBorcu_TextChanged(object sender, EventArgs e)
        {
            Txt_MusteriBorcu.Text = Txt_MusteriBorcu.Text.ToUpper();
            Txt_MusteriBorcu.SelectionStart = Txt_MusteriBorcu.Text.Length;
        }

        private void Txt_PlakaGir_TextChanged(object sender, EventArgs e)
        {
            Txt_PlakaGir.Text = Txt_PlakaGir.Text.ToUpper();
            Txt_PlakaGir.SelectionStart = Txt_PlakaGir.Text.Length;
        }

        #endregion

        private void Btn_MusteriEkle_Click(object sender, EventArgs e)
        {
            try
            {
                using (var MusteriBilgi = new Context())
                {
                    if (string.IsNullOrEmpty(Txt_MusteriAdı.Text) || string.IsNullOrEmpty(Txt_MusteriSoyadı.Text))
                    {
                        MessageBox.Show("Müşteri Adı ve Soyadı boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Eğer gerekli alanlar boşsa işlemi sonlandır
                    }

                    var MusteriEkle = new Musterı_bılgı
                    {
                        MusterıAd = Txt_MusteriAdı.Text,
                        MusterıSoyad = Txt_MusteriSoyadı.Text,
                    };

                    if (!string.IsNullOrEmpty(Txt_MusteriBorcu.Text))
                    {
                        if (int.TryParse(Txt_MusteriBorcu.Text, out int borc))
                        {
                            MusteriEkle.MusteriBorc = borc;
                        }
                        else
                        {
                            MessageBox.Show("Borç alanına geçerli bir sayı girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // Eğer geçerli bir sayı girilmediyse işlemi sonlandır
                        }
                    }

                    MusteriBilgi.Musterı_Bılgıs.Add(MusteriEkle);
                    MusteriBilgi.SaveChanges();
                    MessageBox.Show("Müşteri başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Ekledikten sonra formunuzu sıfırlamak istiyorsanız, metin kutularını temizleyebilirsiniz.
                    Txt_MusteriAdı.Clear();
                    Txt_MusteriSoyadı.Clear();
                    Txt_MusteriBorcu.Clear();
                    GridYükle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataGridViewRow selectedRow;
        private void MüsteriTablosu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    // İlk seçilen satırı alın
                    selectedRow = MüsteriTablosu.SelectedRows[0];

                    // Seçilen satırdaki değerleri TextBox ve ComboBox'lara atayın
                    Txt_MusteriAdı.Text = selectedRow.Cells["MusterıAd"].Value.ToString();
                    Txt_MusteriSoyadı.Text = selectedRow.Cells["MusterıSoyad"].Value.ToString();
                    Txt_MusteriBorcu.Text = selectedRow.Cells["MusteriBorc"].Value.ToString();

                    // Plaka_Kayıts sütunundaki değeri kontrol edin
                    var plakalar = selectedRow.Cells["Plaka_Kayıts"].Value as HashSet<Plaka_kayıt>;
                    if (plakalar != null && plakalar.Any())
                    {
                        Txt_PlakaGir.Text = string.Join(", ", plakalar.Select(p => p.PlakaNo));
                    }
                    else
                    {
                        Txt_PlakaGir.Text = ""; // Koleksiyon boşsa boş bir string olarak ayarlayın
                    }

                }
                else
                {
                    if (MüsteriTablosu.SelectedRows.Count == 0)
                    {
                        // Seçilen satır yoksa, kontrolleri temizleyin
                        Txt_MusteriSoyadı.Clear();
                        Txt_MusteriAdı.Clear();
                        Txt_MusteriBorcu.Clear();
                        Txt_PlakaGir.Clear();
                        Txt_MusteriAra.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Bildiri");
            }
        }

        private void Btn_PlakaTanımlama_Click(object sender, EventArgs e)
        {
            int musteriId = Convert.ToInt32(selectedRow.Cells["MusterıID"].Value);
            Plaka_kayıt yeniPlaka = new Plaka_kayıt
            {
                PlakaNo = Txt_PlakaGir.Text,
                MusterıID = musteriId
            };
            using (var context = new Context())
            {
                // Plaka kaydını veritabanına ekleyin
                context.Plaka_Kayıts.Add(yeniPlaka);
                context.SaveChanges(); // Değişiklikleri kaydedin
            }
            GridYükle();
        }
    }
}
