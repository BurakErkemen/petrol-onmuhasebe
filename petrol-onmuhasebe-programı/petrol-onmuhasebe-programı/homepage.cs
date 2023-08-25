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
    public partial class homepage : Form
    {
        public int user_role_ıd { get; set; }
        public string username { get; set; }
        private vardıya_raporu_gır vardıya_Raporu;
        public homepage()
        {
            InitializeComponent();
        }
        private void homepage_Load(object sender, EventArgs e)
        {

            //user_role_ıd 'ye göre homepage üzerinde görünmesini istemediğimiz bazı durumları saklayacağız
            if (user_role_ıd > 2)
            {
                btn_depo_ayar.Visible = false;
                btn_personel_ayar.Visible=false;
                btn_kullanıcı_tanımlama.Visible=false;
            }
            else if (user_role_ıd == 2)
            {
                btn_kullanıcı_tanımlama.Enabled = false;
            }

            this.WindowState = FormWindowState.Maximized;
            
            if (!string.IsNullOrEmpty(username))
            {
                label1.Text ="Hoş Geldin " + username.ToString();
            }
            else
            {
                label1.Text = "Hoş Geldin " + "Default";
            }
        }

        private void bunifuPictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool boyut=true;
        private void bunifuPictureBox3_Click(object sender, EventArgs e)
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

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_vardiya_raporu_Click_1(object sender, EventArgs e)
        {
            if (vardıya_Raporu == null || vardıya_Raporu.IsDisposed)
            {
                vardıya_Raporu = new vardıya_raporu_gır();
                vardıya_Raporu.Show();
                vardıya_Raporu.user_role_ıd = user_role_ıd;
            }
            else
            {
                vardıya_Raporu.BringToFront();
            }
        }
    }
}