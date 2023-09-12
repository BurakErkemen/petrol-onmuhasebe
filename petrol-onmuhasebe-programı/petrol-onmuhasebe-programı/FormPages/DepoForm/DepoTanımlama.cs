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

namespace petrol_onmuhasebe_programı.FormPages.DepoForm
{
    public partial class DepoTanımlama : Form
    {
        public DepoTanımlama()
        {
            InitializeComponent();
        }
        private void GridYükle()
        {
            using (var context = new Context())
            {
               
                var TankBilgisi = context.Tank_Bilgis.ToList();
                BindingList<Tank_bilgi> tank_s = new BindingList<Tank_bilgi>(TankBilgisi);
                DepoListesi.DataSource = tank_s;
                TankBilgisi = context.Tank_Bilgis.Include("TankDolumlar").ToList();

                if (DepoListesi.Columns.Contains("TankDolumlar"))
                {
                    DepoListesi.Columns["TankDolumlar"].Visible = false;
                    DepoListesi.Columns["TankId"].Visible = false;

                    foreach (DataGridViewRow row in DepoListesi.Rows)
                    {
                        if (row.Cells["TankDolumlar"].Value == null)
                        {
                            row.Cells["TankDolumlar"].Value = ""; // Null değeri bir boş string ile değiştir
                        }
                    }
                }

                DepoListesi.Columns["Tank_ad"].HeaderText = "Tank Adı";
                DepoListesi.Columns["Tank_hacim"].HeaderText = "Tank Hacmi";
                DepoListesi.Columns["Tank_yakıt_turu"].HeaderText = "Tank Yakıt Türü";

                txt_tankLitre.Clear();
                Txt_tankad.Clear();
                Combo_YakıtTuru.SelectedIndex = -1;
            }
        }
        private void DepoTanımlama_Load(object sender, EventArgs e)
        {
            Btn_güncelle.Visible = false;
            Btn_Sil.Visible = false;

            GridYükle();
            #region Combobox
            Combo_YakıtTuru.DropDownStyle = ComboBoxStyle.DropDownList;
            Combo_YakıtTuru.Items.Add("MOTORİN");
            Combo_YakıtTuru.Items.Add("OPTİMUM");
            Combo_YakıtTuru.Items.Add("BENZİN");
            Combo_YakıtTuru.Items.Add("OTOGAZ");
            #endregion
        }
        
        private void Btn_İptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_onayla_Click(object sender, EventArgs e)
        {
            try
            {
                using (Context context = new Context())
                {
                    Tank_bilgi tank_Bilgi = new Tank_bilgi
                    {
                        Tank_ad = Txt_tankad.Text,
                        Tank_hacim = Convert.ToInt32(txt_tankLitre.Text),
                        Tank_yakıt_turu = Combo_YakıtTuru.Text.ToString()
                    };

                    context.Tank_Bilgis.Add(tank_Bilgi); //Yeni Kayıt Ekleme
                    context.SaveChanges(); //Değişikleri Veritabanına kayıt etme
                    GridYükle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Bildirim");
            }
        }

        private void Btn_güncelle_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Context()) // DbContext nesnesini oluşturun veya enjekte edin
                {
                    var TankUpdate = context.Tank_Bilgis.FirstOrDefault(s => s.TankId == 1); // Güncellenecek öğrenciyi seçin

                    if (TankUpdate != null)
                    {
                        TankUpdate.Tank_ad = Txt_tankad.Text;
                        TankUpdate.Tank_hacim = Convert.ToInt32(txt_tankLitre.Text);
                        TankUpdate.Tank_yakıt_turu = Combo_YakıtTuru.Text;
                        context.SaveChanges(); // Değişiklikleri veritabanına kaydedin
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private void DepoListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {

                    Btn_güncelle.Visible = true;
                    Btn_Sil.Visible = true;

                    // İlk seçilen satırı alın
                    DataGridViewRow selectedRow = DepoListesi.SelectedRows[0];

                    // Seçilen satırdaki değerleri TextBox ve ComboBox'lara atayın
                    Txt_tankad.Text = selectedRow.Cells["Tank_ad"].Value.ToString();
                    txt_tankLitre.Text = selectedRow.Cells["Tank_hacim"].Value.ToString();

                    // ComboBox'ta seçili öğeyi ayarlama
                    string selectedYakitTuru = selectedRow.Cells["Tank_yakıt_turu"].Value.ToString();
                    Combo_YakıtTuru.SelectedIndex = Combo_YakıtTuru.Items.IndexOf(selectedYakitTuru);

                }
                else
                {
                    if (DepoListesi.SelectedRows.Count == 0)
                    {
                        Btn_güncelle.Visible = false;
                        Btn_Sil.Visible = false;

                        // Seçilen satır yoksa, kontrolleri temizleyin
                        Txt_tankad.Clear();
                        txt_tankLitre.Clear();
                        Combo_YakıtTuru.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Bildiri");
            }
        }

        private void Btn_Sil_Click(object sender, EventArgs e)
        {
            if (DepoListesi.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DepoListesi.SelectedRows[0];
                int tankId = Convert.ToInt32(selectedRow.Cells["TankId"].Value);

                DialogResult result = MessageBox.Show("Seçili satırı silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (var context = new Context())
                    {
                        var tankToDelete = context.Tank_Bilgis.FirstOrDefault(t => t.TankId == tankId);
                        if (tankToDelete != null)
                        {
                            context.Tank_Bilgis.Remove(tankToDelete);
                            context.SaveChanges(); // Veritabanından kaydı sil
                        }
                    }

                    // DataGridView'den seçilen satırı görsel olarak sil
                    DepoListesi.Rows.RemoveAt(selectedRow.Index);
                }
            }
        }
    }
}
