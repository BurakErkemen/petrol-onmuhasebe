using petrol_onmuhasebe_programı.Model;
using petrol_onmuhasebe_programı.Model.vardıya_ıslemlerı;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace petrol_onmuhasebe_programı.FormPages.Vardıya_Bılgılerı
{
    public partial class EkHarcama : Form
    {
        public EkHarcama()
        {
            InitializeComponent();
        }
        private void EkHarcama_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            GridYükle();
        }
        private void GridYükle()
        {
            try
            {
                using (var context = new Context())
                {
                    // Veritabanından ekHarcama kayıtlarını alın
                    var harcamalar = context.ekHarcamas.ToList();

                    // DataGridView'i doldurmak için bir BindingList oluşturun
                    BindingList<ekHarcama> harcamaListesi = new BindingList<ekHarcama>(harcamalar);

                    // DataGridView'e BindingList'i bağlayın
                    Fatura_Tablosu.DataSource = harcamaListesi;

                    // İlgili sütunların başlıklarını belirtin (Varsayılan başlıklar kullanılır)
                    Fatura_Tablosu.Columns["HarcamaId"].HeaderText = "Harcama ID";
                    Fatura_Tablosu.Columns["HarcamaAdı"].HeaderText = "Harcama Adı";
                    Fatura_Tablosu.Columns["HarcamaTutarı"].HeaderText = "Harcama Tutarı";

                    // Vardiya ve VardiyaID sütunlarını gizle
                    Fatura_Tablosu.Columns["Vardıya"].Visible = false;
                    Fatura_Tablosu.Columns["VardiyaID"].Visible = false;

                    // DataGridView'i güncelle
                    Fatura_Tablosu.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString(), "Bildiri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Btn_İptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Vardıya_formu vardıya_Formu = new Vardıya_formu();
        private void Btn_Onayla_Click(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                // Yeni ekHarcama kaydını oluştur
                var yeniHarcama = new ekHarcama
                {
                    HarcamaAdı = txt_harcamaAd.Text,
                    HarcamaTutarı = int.Parse(txt_HarcamaMiktar.Text)
                };

                // ekHarcama kaydını veritabanına ekleyin
                context.ekHarcamas.Add(yeniHarcama);
                context.SaveChanges(); // Değişiklikleri kaydet

                // Yeni eklenen ekHarcama kaydının ID'sini alabilirsiniz
                int yeniHarcamaId = yeniHarcama.HarcamaId;

                // Vardiya_formu tablosundaki ilgili vardiya kaydını alın
                Vardıya_formu vardiya = context.Vardıya_Formus.FirstOrDefault(v => v.VardıyaId == vardıya_Formu.VardıyaId);

                if (vardiya != null)
                {
                    // Vardiya'nın ilgili alanını güncelleyin
                    vardiya.VardıyaId = yeniHarcamaId;

                    // Değişikliği kaydedin
                    context.SaveChanges();
                }
                GridYükle();
            }
        }

        private void Btn_Guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (Fatura_Tablosu.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = Fatura_Tablosu.SelectedRows[0];
                    int harcamaId = Convert.ToInt32(selectedRow.Cells["HarcamaId"].Value);

                    using (var context = new Context())
                    {
                        // Veritabanında güncelleme yapmak için ilgili ekHarcama kaydını bulun
                        var harcama = context.ekHarcamas.FirstOrDefault(h => h.HarcamaId == harcamaId);

                        if (harcama != null)
                        {
                            // TextBox'lardan güncel verileri alın
                            harcama.HarcamaAdı = txt_harcamaAd.Text;
                            harcama.HarcamaTutarı = int.Parse(txt_HarcamaMiktar.Text);

                            // Değişikliği kaydedin
                            context.SaveChanges();

                            // DataGridView'i yeniden yükle
                            GridYükle();
                        }
                    }

                    // TextBox'ları temizle
                    txt_harcamaAd.Clear();
                    txt_HarcamaMiktar.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString(), "Bildiri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Btn_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                if (Fatura_Tablosu.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show("Silmek İstediğinizden Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DataGridViewRow selectedRow = Fatura_Tablosu.SelectedRows[0];
                        int harcamaId = Convert.ToInt32(selectedRow.Cells["HarcamaId"].Value);

                        using (var context = new Context())
                        {
                            // Veritabanında silme işlemi yapmak için ilgili ekHarcama kaydını bulun
                            var harcama = context.ekHarcamas.FirstOrDefault(h => h.HarcamaId == harcamaId);

                            if (harcama != null)
                            {
                                // ekHarcama kaydını veritabanından silin
                                context.ekHarcamas.Remove(harcama);
                                context.SaveChanges();

                                // DataGridView'i yeniden yükle
                                GridYükle();
                            }
                        }

                        // TextBox'ları temizle
                        txt_harcamaAd.Clear();
                        txt_HarcamaMiktar.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString(), "Bildiri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Fatura_Tablosu_CellClick(object sender, DataGridViewCellEventArgs e)
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
                    // Seçilen satırı alın
                    DataGridViewRow selectedRow = Fatura_Tablosu.Rows[e.RowIndex];

                    // Seçilen hücrelerden verileri TextBox'lara yazın
                    txt_harcamaAd.Text = selectedRow.Cells["HarcamaAdı"].Value.ToString();
                    txt_HarcamaMiktar.Text = selectedRow.Cells["HarcamaTutarı"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString(), "Bildiri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
