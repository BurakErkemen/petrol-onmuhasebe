﻿using petrol_onmuhasebe_programı.Vardıya_Bılgılerı;
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
        public int user_ıd { get; set; }
        public string username { get; set; }
        private vardıya_raporu_gır vardıya_Raporu;
        public homepage()
        {
            InitializeComponent();
        }
        //private string ConnectionString = "Data Source=DESKTOP-1TTOTC5\\SQLEXPRESS;Initial Catalog=onmuhasebe;Integrated Security=True;MultipleActiveResultSets=True";
        private void homepage_Load(object sender, EventArgs e)
        {
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

        private void btn_vardiya_raporu_Click(object sender, EventArgs e)
        {
            
            if (vardıya_Raporu == null || vardıya_Raporu.IsDisposed)
            {
                vardıya_Raporu = new vardıya_raporu_gır();
                vardıya_Raporu.Show();
            }
            else
            {
                vardıya_Raporu.BringToFront();
            }
        }
    }
}