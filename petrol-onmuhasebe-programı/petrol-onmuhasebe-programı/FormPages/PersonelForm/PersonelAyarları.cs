using petrol_onmuhasebe_programı.Model;
using petrol_onmuhasebe_programı.Model.Depo_İslemleri;
using petrol_onmuhasebe_programı.Model.Musteri_Bilgi;
using petrol_onmuhasebe_programı.Model.Persolel_Bilgi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
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
            CenterToScreen();
            #region LoadAyarları
            Btn_Güncelle.Visible = false;
            Btn_Sil.Visible = false;
            #endregion
            GridYükle();
            Personel_AyrılısTarıhı.Text = DateTime.Now.ToString();
            Personel_BaslangıcTarıhı.Text = DateTime.Now.ToString();
        }
        private void GridYükle()
        {
            using (var context = new Context())
            {

                var Personel = context.Personel_Bilgis.ToList();
                BindingList<personel_bilgi> tank_s = new BindingList<personel_bilgi>(Personel);
                PersonelListesi.DataSource = tank_s;

                if (PersonelListesi.Columns.Contains("PersonelId"))
                {
                    PersonelListesi.Columns["PersonelId"].Visible = false;
                    PersonelListesi.Columns["VardıyaFormlar"].Visible = false;

                    foreach (DataGridViewRow row in PersonelListesi.Rows)
                    {
                        if (row.Cells["PersonelId"].Value == null || row.Cells["VardıyaFormlar"].Value == null)
                        {
                            row.Cells["PersonelId"].Value = ""; 
                            row.Cells["VardıyaFormlar"].Value = ""; 
                        }
                    }
                }

                PersonelListesi.Columns["PersonelAd"].HeaderText = "Personel Adı";
                PersonelListesi.Columns["PersonelSoyad"].HeaderText = "Personel Soyadı";
                PersonelListesi.Columns["Personel_TcNo"].HeaderText = "Personel Tc No";
                PersonelListesi.Columns["PersonelMaas"].HeaderText = "Personel Maaş";
                PersonelListesi.Columns["BaslamaTarıhı"].HeaderText = "İşe Başlama Tarihi";
                PersonelListesi.Columns["BıtısTarıhı"].HeaderText = "Ayrılış Tarihi";

                Txt_PersonelAd.Clear();
                Txt_PersonelMaas.Clear();
                Txt_PersonelKimlik.Clear();
                Txt_PersonelSoyAd.Clear();
                Personel_BaslangıcTarıhı.Text = DateTime.Now.ToString();
                Personel_AyrılısTarıhı.Text = DateTime.Now.ToString();
            }
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

        private DataGridViewRow selectedRow;
        private void PersonelListesi_CellClick(object sender, DataGridViewCellEventArgs e)
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
                    // İlk seçilen satırı alın
                    selectedRow = PersonelListesi.SelectedRows[0];

                    // Seçilen satırdaki değerleri TextBox ve ComboBox'lara atayın
                    Txt_PersonelAd.Text = selectedRow.Cells["PersonelAd"].Value.ToString();
                    Txt_PersonelSoyAd.Text = selectedRow.Cells["PersonelSoyad"].Value.ToString();
                    Txt_PersonelKimlik.Text = selectedRow.Cells["Personel_TcNo"].Value.ToString();
                    Txt_PersonelMaas.Text = selectedRow.Cells["PersonelMaas"].Value.ToString();
                    if (selectedRow.Cells["BaslamaTarıhı"].Value != null)
                    {
                        Personel_BaslangıcTarıhı.Value = (DateTime)selectedRow.Cells["BaslamaTarıhı"].Value;
                    }
                    else
                    {
                        Personel_BaslangıcTarıhı.Value = DateTime.Now;
                    }

                    if (selectedRow.Cells["BıtısTarıhı"].Value != null)
                    {
                        Personel_AyrılısTarıhı.Value = (DateTime)selectedRow.Cells["BıtısTarıhı"].Value;
                    }
                    else
                    {
                        Personel_AyrılısTarıhı.Value = DateTime.Now;
                    }
                    Btn_Güncelle.Visible = true;
                    Btn_Sil.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString(), "Bildiri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Onayla_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Context())
                {
                    var yeniPersonel = new personel_bilgi
                    {
                        PersonelAd = Txt_PersonelAd.Text,
                        PersonelSoyad = Txt_PersonelSoyAd.Text,
                        Personel_TcNo = Txt_PersonelKimlik.Text,
                        PersonelMaas = Txt_PersonelMaas.Text,
                        BaslamaTarıhı = Personel_BaslangıcTarıhı.Value,
                        BıtısTarıhı = Personel_AyrılısTarıhı.Value
                    };

                    // Yeni personeli veritabanına ekleyin
                    context.Personel_Bilgis.Add(yeniPersonel);
                    context.SaveChanges();

                    GridYükle();

                    MessageBox.Show("Personel başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString(), "Bildiri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Güncelle_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Context())
                {
                    int selectedPersonelId = Convert.ToInt32(selectedRow.Cells["PersonelId"].Value);

                    var guncellenecekPersonel = context.Personel_Bilgis.FirstOrDefault(p => p.PersonelId == selectedPersonelId);

                    if (guncellenecekPersonel != null)
                    {
                        guncellenecekPersonel.PersonelAd = Txt_PersonelAd.Text;
                        guncellenecekPersonel.PersonelSoyad = Txt_PersonelSoyAd.Text;
                        guncellenecekPersonel.PersonelMaas = Txt_PersonelMaas.Text;
                        guncellenecekPersonel.Personel_TcNo = Txt_PersonelKimlik.Text;
                        guncellenecekPersonel.BaslamaTarıhı = Personel_BaslangıcTarıhı.Value;
                        guncellenecekPersonel.BıtısTarıhı = Personel_AyrılısTarıhı.Value;

                        context.SaveChanges();

                        // DataGridView'i güncelleyin
                        GridYükle();

                        // Güncellemeyi onayladığınıza dair bir mesaj gösterin
                        MessageBox.Show("Personel bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Personel bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Silmek İstediğinizden Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (var context = new Context())
                    {
                        // Seçilen satırın PersonelId'sini alın
                        int selectedPersonelId = Convert.ToInt32(selectedRow.Cells["PersonelId"].Value);

                        // Veritabanından seçilen personeli bulun
                        var personel = context.Personel_Bilgis.FirstOrDefault(p => p.PersonelId == selectedPersonelId);

                        if (personel != null)
                        {
                            // İkinci bir onay iletişim kutusu açın
                            if (MessageBox.Show("Tekrar Silmek İstediğinizden Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                // Kullanıcı "Evet" seçeneğini seçtiğinde, personeli veritabanından silin
                                context.Personel_Bilgis.Remove(personel);
                                context.SaveChanges();

                                GridYükle();
                            }
                        }
                    }
                }
                else
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
