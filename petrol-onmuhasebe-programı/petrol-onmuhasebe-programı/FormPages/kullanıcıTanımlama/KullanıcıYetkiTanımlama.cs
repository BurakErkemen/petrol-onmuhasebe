using petrol_onmuhasebe_programı.Model;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Context = petrol_onmuhasebe_programı.Model.Context;

namespace petrol_onmuhasebe_programı.FormPages.kullanıcıTanımlama
{
    public partial class KullanıcıYetkiTanımlama : Form
    {
        public KullanıcıYetkiTanımlama()
        {
            InitializeComponent();
        }

        private void KullanıcıYetkiTanımlama_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            Combobox();
            GridYükle();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void GridYükle()
        {
            try
            {
                using (Context db = new Context())
                {
                    // Kullanıcıları ve rollerini birleştirerek çek
                    var query = from user in db.Users
                                join role in db.User_roles on user.user_role_ıd equals role.user_role_ıd
                                select new
                                {
                                    KullanıcıAdı = user.kullanıcıadı,
                                    Şifre = user.sifre, // Şifre sütununu sorguya ekleyin
                                    Rol = role.role_name,
                                };

                    // DataGridView'e verileri yüklemeden önce sütunları otomatik oluşturmasına izin verin
                    data1.AutoGenerateColumns = true;
                    data1.DataSource = query.ToList();

                    Txt_Şifre.Clear();
                    Txt_KullanıcıAdı.Clear();
                    comboBox1.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Combobox()
        {
            try
            {
                using (Context db = new Context())
                {
                    var roles = db.User_roles.Select(r => r.role_name).ToList();
                    comboBox1.Items.Clear();
                    comboBox1.Items.AddRange(roles.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private DataGridViewRow row;
        private void Data1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                if (e.RowIndex >= 0)
                {
                    row= data1.SelectedRows[0];
                    // DataGridView'daki sütunların indekslerini kullanarak verilere erişin
                    Txt_KullanıcıAdı.Text = row.Cells["KullanıcıAdı"].Value.ToString();
                    Txt_Şifre.Text = row.Cells["Şifre"].Value.ToString();
                    string selectedDepo = row.Cells["Rol"].Value.ToString();
                    comboBox1.SelectedIndex = comboBox1.Items.IndexOf(selectedDepo);
                }
                else
                {
                    if (data1.SelectedRows.Count == 0)
                    {
                        Txt_Şifre.Clear();
                        Txt_KullanıcıAdı.Clear();
                        comboBox1.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Btn_Ekle_Click(object sender, EventArgs e)
        {
            using (var context = new Context())
            {
                var selectedRoleName = comboBox1.SelectedItem?.ToString(); // Seçilen rol adını al

                if (!string.IsNullOrEmpty(selectedRoleName))
                {
                    // Seçilen rol adına göre ilgili rolü veritabanından al
                    var selectedRole = context.User_roles.SingleOrDefault(r => r.role_name == selectedRoleName);

                    if (selectedRole != null)
                    {
                        var Ekle = new user()
                        {
                            kullanıcıadı = Txt_KullanıcıAdı.Text,
                            sifre = Txt_Şifre.Text,
                            user_role_ıd = selectedRole.user_role_ıd, 
                            user_Role = selectedRole 
                        };

                        context.Users.Add(Ekle);
                        context.SaveChanges();

                        MessageBox.Show("Kullanıcı başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GridYükle();
                    }
                    else
                    {
                        MessageBox.Show("Seçilen rol veritabanında bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir rol seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #region Upper
        private void Txt_KullanıcıAdı_TextChanged(object sender, EventArgs e)
        {
            Txt_KullanıcıAdı.Text = Txt_KullanıcıAdı.Text.ToUpper();
            Txt_KullanıcıAdı.SelectionStart = Txt_KullanıcıAdı.Text.Length;
        }

        private void Txt_Şifre_TextChanged(object sender, EventArgs e)
        {
            Txt_Şifre.Text = Txt_Şifre.Text.ToUpper();
            Txt_Şifre.SelectionStart = Txt_Şifre.Text.Length;
        }
        #endregion

        private void Btn_Sil_Click(object sender, EventArgs e)
        {
            if (data1.SelectedRows.Count > 0)
            {
                try
                {
                    using (Context db = new Context())
                    {
                        // Seçilen satırın kullanıcı adını al
                        string kullaniciAdi = data1.SelectedRows[0].Cells["KullanıcıAdı"].Value.ToString();

                        // Kullanıcıyı veritabanından bul
                        var kullanici = db.Users.FirstOrDefault(u => u.kullanıcıadı == kullaniciAdi);

                        if (kullanici != null)
                        {
                            // Kullanıcıyı sil ve değişiklikleri kaydet
                            db.Users.Remove(kullanici);
                            db.SaveChanges();

                            // Gridi yeniden yükle
                            GridYükle();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_Guncelle_Click(object sender, EventArgs e)
        {
            if (data1.SelectedRows.Count > 0)
            {
                try
                {
                    using (Context db = new Context())
                    {
                        // Seçilen satırın kullanıcı adını al
                        string kullaniciAdi = data1.SelectedRows[0].Cells["kullanıcıadı"].Value.ToString();

                        // Kullanıcıyı veritabanından bul
                        var kullanici = db.Users.FirstOrDefault(u => u.kullanıcıadı == kullaniciAdi);

                        if (kullanici != null)
                        {
                            var selectedRoleName = comboBox1.SelectedItem?.ToString();

                            // Seçilen rol adına göre ilgili rolü veritabanından al
                            var selectedRole = db.User_roles.SingleOrDefault(r => r.role_name == selectedRoleName);

                            if (selectedRole != null)
                            {
                                // Kullanıcının özelliklerini güncelle
                                kullanici.kullanıcıadı = Txt_KullanıcıAdı.Text;
                                kullanici.sifre = Txt_Şifre.Text;
                                kullanici.user_role_ıd = selectedRole.user_role_ıd;
                                kullanici.user_Role = selectedRole;

                                // Değişiklikleri kaydet
                                db.SaveChanges();

                                // Gridi yeniden yükle
                                GridYükle();
                            }
                            else
                            {
                                MessageBox.Show("Seçilen rol bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
