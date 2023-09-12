using petrol_onmuhasebe_programı.Model;
using petrol_onmuhasebe_programı.Model.Depo_İslemleri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace petrol_onmuhasebe_programı.FormPages.DepoForm
{
    public partial class DepoAyarları : Form
    {
        public DepoAyarları()
        {
            InitializeComponent();
        }

        private void DepoAyarları_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            GridYükle();
            DoldurComboBox();
            #region Combobox
            combo_depo.DropDownStyle = ComboBoxStyle.DropDownList;
            #endregion

        }
        private void GridYükle()
        {
            using (var context = new Context())
            {

                var TankBilgisi = context.Tank_Dolums.ToList();
                BindingList<Tank_dolum> tank_s = new BindingList<Tank_dolum>(TankBilgisi);
                Fatura_Tablosu.DataSource = tank_s;
                var tankDolumlar = context.Tank_Dolums.Include("Tank").ToList();

                if (Fatura_Tablosu.Columns.Contains("DolumId"))
                {
                    Fatura_Tablosu.Columns["DolumId"].Visible = false;
                    Fatura_Tablosu.Columns["TankId"].Visible = false;

                    foreach (DataGridViewRow row in Fatura_Tablosu.Rows)
                    {
                        if (row.Cells["DolumId"].Value == null)
                        {
                            row.Cells["DolumId"].Value = ""; // Null değeri bir boş string ile değiştir
                        }
                    }
                }

                Fatura_Tablosu.Columns["Dolum_Litre"].HeaderText = "Dolum Litresi";
                Fatura_Tablosu.Columns["Dolum_Tarıhı"].HeaderText = "Dolum Tarihi";
                Fatura_Tablosu.Columns["FaturaNo"].HeaderText = "Fatura No";
                // İlgili sütunun adını ve görüntülemek istediğiniz sütunu belirtin
                string displayColumnName = "Tank";
                string targetColumnName = "Tank Adı";

                // Sütunun varlığını kontrol edin
                if (Fatura_Tablosu.Columns.Contains(displayColumnName))
                {
                    // Sütunun görünen başlığını değiştirin
                    Fatura_Tablosu.Columns[displayColumnName].HeaderText = targetColumnName;
                }

                Txt_litre.Clear();
                Txt_YakıtTürü.Clear();
                Txt_FaturaNo.Clear();
                combo_depo.SelectedIndex = -1;
            }
        }
        DepoTanımlama depoTanımlama;
        private void Btn_DepoTanımla_Click(object sender, EventArgs e)
        {
            if (depoTanımlama == null || depoTanımlama.IsDisposed)
            {
                depoTanımlama = new DepoTanımlama();
                depoTanımlama.Show();
            }
            else
            {
                depoTanımlama.BringToFront();
            }
        }

        private void Btn_İptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DoldurComboBox()
        {
            using (Context context = new Context()) // DbContext nesnesini kullanarak veritabanına bağlanın
            {
                var tankAdlari = context.Tank_Bilgis.Select(t => t.Tank_ad).ToList(); // "Tank_ad" sütununu çekin
                combo_depo.DataSource = tankAdlari; // ComboBox'a verileri ata

            }
        }
        private int DepoAd;
        private void Btn_onayla_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedValue = combo_depo.Text.ToString();
                using (var context = new Context())
                {
                    if (combo_depo.SelectedItem != null)
                    {
                        var row = context.Tank_Bilgis.FirstOrDefault(i => i.Tank_ad == selectedValue);
                        if (row != null)
                        {
                            Txt_YakıtTürü.Text = row.Tank_yakıt_turu;
                            DepoAd = row.TankId; // DepoAd'ı bir int olarak tanımlayın
                        }
                    }
                }
                using (var context = new Context())
                {
                    DateTime selectedDate = dateTimePicker1.Value;
                    var tankDolum = new Tank_dolum
                    {
                        FaturaNo = Txt_FaturaNo.Text,
                        Dolum_Litre = Convert.ToInt32(Txt_litre.Text),
                        Dolum_Tarıhı = selectedDate,
                        TankID = DepoAd // Burada DepoAd değişkenini kullanın
                    };

                    context.Tank_Dolums.Add(tankDolum);
                    context.SaveChanges();
                }
                GridYükle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata");
            }
        }
        private void Btn_Guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedValue = combo_depo.Text.ToString();
                DateTime selectedDate = dateTimePicker1.Value;
                int selectedDolumId = Convert.ToInt32(Fatura_Tablosu.SelectedRows[0].Cells["DolumId"].Value); // Seçilen satırın DolumId'sini al
                using (var context = new Context())
                {
                    if (combo_depo.SelectedItem != null)
                    {
                        var row = context.Tank_Bilgis.FirstOrDefault(i => i.Tank_ad == selectedValue);
                        if (row != null)
                        {
                            Txt_YakıtTürü.Text = row.Tank_yakıt_turu;
                            DepoAd = row.TankId; // DepoAd'ı bir int olarak tanımlayın
                        }
                    }
                }
                using (var context = new Context())
                {
                    var TankUpdate = context.Tank_Dolums.FirstOrDefault(s => s.DolumId == selectedDolumId);

                    if (TankUpdate != null)
                    {
                        TankUpdate.FaturaNo = Txt_FaturaNo.Text;
                        TankUpdate.Dolum_Litre = Convert.ToInt32(Txt_litre.Text);
                        TankUpdate.Dolum_Tarıhı = selectedDate;
                        TankUpdate.TankID = DepoAd;
                        context.SaveChanges();
                    }
                    GridYükle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void Combo_depo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (combo_depo.SelectedItem != null) // ComboBox'ta seçilmiş bir öğe var mı?
                {
                    string selectedValue = combo_depo.SelectedItem.ToString();

                    // Veritabanından ilgili satırı çekin
                    using (var context = new Context()) // DbContext sınıfınızın adını kullanmalısınız
                    {
                        var row = context.Tank_Bilgis.FirstOrDefault(item => item.Tank_ad == selectedValue);

                        if (row != null)
                        {
                            // TextBox'a değeri yazdırın
                            Txt_YakıtTürü.Text = row.Tank_yakıt_turu; // AnotherColumn, TextBox'a yazdırmak istediğiniz sütunun adı olmalı
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("HatA: " + ex.Message);
            }
        }
        private DataGridViewRow selectedRow;
        private void Fatura_Tablosu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                   
                    // İlk seçilen satırı alın
                     selectedRow = Fatura_Tablosu.SelectedRows[0];

                    // Seçilen satırdaki değerleri TextBox ve ComboBox'lara atayın
                    Txt_FaturaNo.Text = selectedRow.Cells["FaturaNo"].Value.ToString();
                    Txt_litre.Text = selectedRow.Cells["Dolum_Litre"].Value.ToString();
                   

                    // ComboBox'ta seçili öğeyi ayarlama
                    string selectedDepo = selectedRow.Cells["Tank"].Value.ToString();
                    combo_depo.SelectedIndex = combo_depo.Items.IndexOf(selectedDepo);
                }
                else
                {
                    if (Fatura_Tablosu.SelectedRows.Count == 0)
                    {

                        // Seçilen satır yoksa, kontrolleri temizleyin
                        Txt_litre.Clear();
                        Txt_FaturaNo.Clear();
                        combo_depo.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Bildiri");
            }
        }
    }
}
