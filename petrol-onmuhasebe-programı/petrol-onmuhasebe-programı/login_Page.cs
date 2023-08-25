﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using petrol_onmuhasebe_programı.Model;
namespace petrol_onmuhasebe_programı
{
    public partial class login_Page : Form
    {
        public login_Page()
        {
            InitializeComponent();
        }

        private void login_Page_Load(object sender, EventArgs e)
        {
            this.Opacity = 90;
        }
        private void button_1_Click(object sender, EventArgs e)
        {
            using (Context db = new Context())
            {
                string kullanıcı_adı = textBox1.Text;
                string sifre = textBox2.Text;

                var user = db.users.FirstOrDefault(a => a.kullanıcıadı == kullanıcı_adı && a.sifre == sifre);

                if (user != null)
                {
                    // Kullanıcı girişi başarılı
                    homepage homepage = new homepage();
                    homepage.user_role_ıd = user.user_role_ıd;
                    homepage.username = user.kullanıcıadı;
                    MessageBox.Show("Giriş başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    homepage.Show();
                    this.Hide();
                }
                else
                {
                    // Kullanıcı girişi başarısız
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bunifuLabel1_MouseMove(object sender, MouseEventArgs e)
        {
            bunifuLabel2.Visible = true;
        }

        #region TXT
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Usurname")
                textBox1.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "Usurname";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Password")
                textBox1.Text = "";
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "Password";
        }
        #endregion
        private void bunifuPictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void login_Page_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }
        private void login_Page_MouseMove(object sender, MouseEventArgs e)
        {
            bunifuLabel2.Visible = false;

            if (move == true)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x,MousePosition.Y - mouse_y);
            }
        }


        private void login_Page_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;

        }
    }
} 
