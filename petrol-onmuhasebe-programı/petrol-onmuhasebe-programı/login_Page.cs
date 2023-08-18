using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace petrol_onmuhasebe_programı
{
    public partial class login_Page : Form
    {
        public login_Page()
        {
            InitializeComponent();
        }
        private string ConnectionString = "Data Source=DESKTOP-1TTOTC5\\SQLEXPRESS;Initial Catalog=onmuhasebe;Integrated Security=True;MultipleActiveResultSets=True";
        private void button1_Click(object sender, EventArgs e)
        {
            string kullanıcıAdı = textBox1.Text;
            string sifre= textBox2.Text;
            string sorgu = "SELECT * FROM login_information WHERE kullanıcıadı = @kullanıcıadı AND sifre = @sifre";

            try
            {
               using(SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sorgu, connection))
                    {
                        command.Parameters.AddWithValue("@kullanıcıadı", kullanıcıAdı);
                        command.Parameters.AddWithValue("@sifre", sifre);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                if (reader.Read())
                                {
                                    int userId = Convert.ToInt32(reader["ıd"]); // Burada "user_id" kolonunun adını kullanıcı veritabanınıza göre ayarlayın
                                    string username = Convert.ToString(reader["kullanıcıadı"]);
                                    homepage homepage = new homepage();
                                    homepage.user_ıd = userId;
                                    homepage.username = username;
                                    homepage.Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı Adı veya Şifre Hatası!","HATALI",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Bilgiri", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
