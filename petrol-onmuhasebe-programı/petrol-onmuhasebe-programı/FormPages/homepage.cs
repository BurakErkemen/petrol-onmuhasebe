using petrol_onmuhasebe_programı.FormPages.DepoForm;
using petrol_onmuhasebe_programı.FormPages.Kredikart;
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
        public Homepage()
        {
            InitializeComponent();
        }
        private void Homepage_Load(object sender, EventArgs e)
        {

            //user_role_ıd 'ye göre homepage üzerinde görünmesini istemediğimiz bazı durumları saklayacağız
            if (User_role_ıd > 2)
            {
                Btn_depo_ayar.Visible = false;
                btn_personel_ayar.Visible=false;
                btn_kullanıcı_tanımlama.Visible=false;
            }
            else if (User_role_ıd == 2)
            {
                btn_kullanıcı_tanımlama.Enabled = false;
            }

            this.WindowState = FormWindowState.Maximized;
            
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

        private void Btn_vardiya_raporu_Click_1(object sender, EventArgs e)
        {
            if (vardıya_Raporu == null || vardıya_Raporu.IsDisposed)
            {
                vardıya_Raporu = new Vardıya_raporu_gır();
                vardıya_Raporu.Show();
                vardıya_Raporu.user_role_ıd = User_role_ıd;
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
                veresiyeMusteri.Show();
            }
            else
            {
                veresiyeMusteri.BringToFront();
            }

        }

        private void Btn_kullanıcı_tanımlama_Click(object sender, EventArgs e)
        {
            if (veresiyeMusteri == null || veresiyeMusteri.IsDisposed)
            {
                veresiyeMusteri = new Musteri_Islemlerı();
                veresiyeMusteri.Show();
            }
            else
            {
                veresiyeMusteri.BringToFront();
            }
        }
        private kredikart kredikart;
        private void Txt_KartTanımlama_Click(object sender, EventArgs e)
        {
            if (kredikart == null || kredikart.IsDisposed)
            {
                kredikart = new kredikart();
                kredikart.Show();
            }
            else
            {
                kredikart.BringToFront();
            }
        }
    }
}