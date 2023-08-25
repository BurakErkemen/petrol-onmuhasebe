using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace petrol_onmuhasebe_programı.Vardıya_Bılgılerı
{
    public partial class vardıya_raporu_gır : Form
    {
        public vardıya_raporu_gır()
        {
            InitializeComponent();
        }
        public int user_role_ıd;
        
        private void vardıya_raporu_gır_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            #region combobox
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox3.Items.Add('1');
            comboBox3.Items.Add('2');
            comboBox3.Items.Add('3');
            #endregion

            #region tab_index
            txt_otogaz_litre.TabIndex = 0;
            txt_otogaz_tutar.TabIndex = 1;
            txt_motorin_litre.TabIndex = 2;
            txt_motorin_tutar.TabIndex = 3;
            txt_optimum_litre.TabIndex = 4;
            txt_optimum_tutar.TabIndex = 5;
            txt_benzin_litre.TabIndex = 6;
            txt_benzin_tutar.TabIndex = 7;
            #endregion

        }
    }
}
