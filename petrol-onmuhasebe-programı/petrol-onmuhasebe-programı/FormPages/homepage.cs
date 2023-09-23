using petrol_onmuhasebe_programı.FormPages.DepoForm;
using petrol_onmuhasebe_programı.FormPages.Kredikart;
using petrol_onmuhasebe_programı.FormPages.kullanıcıTanımlama;
using petrol_onmuhasebe_programı.FormPages.PersonelForm;
using petrol_onmuhasebe_programı.FormPages.VeresiyeMüşteri;
using petrol_onmuhasebe_programı.Model;
using petrol_onmuhasebe_programı.Model.Depo_İslemleri;
using petrol_onmuhasebe_programı.Vardıya_Bılgılerı;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace petrol_onmuhasebe_programı
{
    public partial class Homepage : Form
    {
        public int User_role_ıd { get; set; }
        public string Username { get; set; }
        private Vardıya_raporu_gır vardıya_Raporu;
        private DepoAyarları depoAyarları;
        private PersonelAyarları personelAyarları;
        private Musteri_Islemlerı veresiyeMusteri;
        private KullanıcıYetkiTanımlama yetkiTanımlama;
        private kredikart kredikart;
        public Homepage()
        {
            InitializeComponent();
        }
        private void Homepage_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            //user_role_ıd 'ye göre homepage üzerinde engeller kuracağız
            if (User_role_ıd != 1)
            {
                btn_kullanıcı_tanımlama.Visible = false;
            }            
            if (!string.IsNullOrEmpty(Username))
            {
                label1.Text ="Hoş Geldin " + Username.ToString();
            }
            else
            {
                label1.Text = "Hoş Geldin " + "Default";
            }
        }

        private void BunifuPictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool boyut=true;
        private void BunifuPictureBox3_Click(object sender, EventArgs e)
        {
            if (boyut == false)
            {
                this.WindowState = FormWindowState.Maximized;
                boyut = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                boyut = false;
            }
        }

        private void BunifuPictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #region Geçişler
        private void Btn_vardiya_raporu_Click_1(object sender, EventArgs e)
        {
            if (vardıya_Raporu == null || vardıya_Raporu.IsDisposed)
            {
                vardıya_Raporu = new Vardıya_raporu_gır();
                vardıya_Raporu.user_role_ıd = User_role_ıd;
                vardıya_Raporu.Show();
            }
            else
            {
                vardıya_Raporu.BringToFront();
            }
        }

        private void Btn_depo_ayar_Click(object sender, EventArgs e)
        {
            if (depoAyarları == null || depoAyarları.IsDisposed)
            {
                depoAyarları = new DepoAyarları();
                depoAyarları.user_rol_ıd = User_role_ıd;
                depoAyarları.Show();
            }
            else
            {
                depoAyarları.BringToFront();
            }
        }

        private void Btn_personel_ayar_Click(object sender, EventArgs e)
        {
            if (personelAyarları == null || personelAyarları.IsDisposed)
            {
                personelAyarları = new PersonelAyarları();
                personelAyarları.user_rol_ıd = User_role_ıd;
                personelAyarları.Show();
            }
            else
            {
                personelAyarları.BringToFront();
            }
        }

        private void Btn_musterı_ayar_Click(object sender, EventArgs e)
        {
            if (veresiyeMusteri == null || veresiyeMusteri.IsDisposed)
            {
                veresiyeMusteri = new Musteri_Islemlerı();
                veresiyeMusteri.user_rol_ıd = User_role_ıd;
                veresiyeMusteri.Show();
            }
            else
            {
                veresiyeMusteri.BringToFront();
            }

        }

        private void Btn_kullanıcı_tanımlama_Click(object sender, EventArgs e)
        {
            if (yetkiTanımlama == null || yetkiTanımlama.IsDisposed)
            {
                yetkiTanımlama = new KullanıcıYetkiTanımlama();
                yetkiTanımlama.Show();
            }
            else
            {
                yetkiTanımlama.BringToFront();
            }
        }
        private void Txt_KartTanımlama_Click(object sender, EventArgs e)
        {
            if (kredikart == null || kredikart.IsDisposed)
            {
                kredikart = new kredikart();
                kredikart.user_rol_ıd = User_role_ıd;
                kredikart.Show();
            }
            else
            {
                kredikart.BringToFront();
            }
        }
        #endregion
    }
}