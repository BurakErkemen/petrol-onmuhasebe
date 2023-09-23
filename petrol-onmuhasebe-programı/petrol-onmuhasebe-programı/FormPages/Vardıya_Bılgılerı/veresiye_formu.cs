using petrol_onmuhasebe_programı.Model;
using petrol_onmuhasebe_programı.Model.Musteri_Bilgi;
using petrol_onmuhasebe_programı.Model.vardıya_ıslemlerı;
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
        public int VardiyaID = 1;
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
            using (var context = new Context())
            {
                // Müşteri bilgilerini Musterı_Bılgıs tablosundan çekin
                var musteriBilgileri = context.Musterı_Bılgıs.ToList();

                // ComboBox'a müşteri adlarını ekleyin
                foreach (var musteri in musteriBilgileri)
                {
                    combo_Musteri.Items.Add(musteri.MusterıAd);
                }

                // Plaka kayıtlarını Plaka_Kayıts tablosundan çekin
                var plakaKayitlari = context.Plaka_Kayıts.ToList();

                // ComboBox'a plaka numaralarını ekleyin
                foreach (var plaka in plakaKayitlari)
                {
                    combo_Plaka.Items.Add(plaka.PlakaNo);
                }
            }

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

        private List<veresiye_raporu> veresiyeRaporları = new List<veresiye_raporu>(); // Verileri tutmak için bir liste oluşturun

        private void Btn_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (combo_Musteri.SelectedItem == null || combo_Plaka.SelectedItem == null || Txt_litre.Text == "" || combo_YakıtTuru.SelectedItem == null || Txt_tutar.Text == "" || Txt_FisNo.Text == "")
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
                    int fisNo = int.Parse(Txt_FisNo.Text);

                    // Verileri DataGridView'da göster
                    DataGridView1.Rows.Add(musteriAdi, plaka, yakitTuru, litre, tutar, fisNo);

                    // Verileri liste içinde saklayın
                    veresiye_raporu rapor = new veresiye_raporu
                    {
                        Tutar = int.Parse(Txt_tutar.Text),
                        Litre = int.Parse(Txt_litre.Text),
                        YakıtTürü = combo_YakıtTuru.Text,
                        FisNo = fisNo, 
                        PlakaKayit = GetPlakaKayit(plaka), 
                        MusteriBilgi = GetMusteriBilgi(musteriAdi), 
                        VardıyaId = VardiyaID,
                    };

                    // Veriyi veritabanına eklemek için EF kullanımı
                    using (var context = new Context()) // Context sınıfınıza uygun bir şekilde tanımlamanız gerekiyor
                    {
                        context.veresiye_Raporus.Add(rapor);
                        context.SaveChanges(); // Değişiklikleri kaydet
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private Plaka_kayıt GetPlakaKayit(string plakaNo)
        {
            using (var context = new Context())
            {
                return context.Plaka_Kayıts.FirstOrDefault(p => p.PlakaNo == plakaNo);
            }
        }

        private Musterı_bılgı GetMusteriBilgi(string musteriAdi)
        {
            using (var context = new Context())
            {
                return context.Musterı_Bılgıs.FirstOrDefault(m => m.MusterıAd == musteriAdi);
            }
        }





        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var context = new Context())
            {
                // Plaka_kayıt nesnesini alın (örneğin, PlakaId = 1 olan)
                Plaka_kayıt plakaKayit = context.Plaka_Kayıts.FirstOrDefault(p => p.PlakaId == 1);

                if (plakaKayit != null)
                {
                    // Yeni bir veresiye raporu oluşturun ve Plaka_kayıt'ı atayın
                    var yeniVeresiyeRaporu = new veresiye_raporu
                    {
                        Tutar = int.Parse(Txt_tutar.Text),
                        Litre = int.Parse(Txt_litre.Text),
                        YakıtTürü = combo_YakıtTuru.Text.ToString(),
                        FisNo = int.Parse(Txt_FisNo.Text), // Örnek fiş numarası
                        PlakaKayit = plakaKayit // Plaka_kayıt'ı atayın
                    };

                    // Yeni veresiye raporu veritabanına ekleyin
                    context.veresiye_Raporus.Add(yeniVeresiyeRaporu);
                    context.SaveChanges();
                }
            }

        }

        private void Btn_Sil_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = DataGridView1.SelectedRows[0];

                    // Silinecek veresiye raporunun ID'sini alın
                    int raporId = Convert.ToInt32(selectedRow.Cells["Versiyeid"].Value);

                    // Veriyi DataGridView'dan sil
                    DataGridView1.Rows.Remove(selectedRow);

                    // Veritabanından da silmek için EF kullanımı
                    using (var context = new Context()) // Context sınıfınıza uygun bir şekilde tanımlamanız gerekiyor
                    {
                        var rapor = context.veresiye_Raporus.FirstOrDefault(r => r.Versiyeid == raporId);

                        if (rapor != null)
                        {
                            context.veresiye_Raporus.Remove(rapor);
                            context.SaveChanges(); // Değişiklikleri kaydet
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Silmek için bir satır seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
