namespace petrol_onmuhasebe_programı.FormPages.Kredikart
{
    partial class kredikart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kredikart));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.KartListesi = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.Btn_Sil = new Bunifu.Framework.UI.BunifuThinButton2();
            this.Btn_Güncelle = new Bunifu.Framework.UI.BunifuThinButton2();
            this.Btn_Onayla = new Bunifu.Framework.UI.BunifuThinButton2();
            this.Btn_İptal = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_BankaAd = new Bunifu.UI.WinForms.BunifuTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KartListesi)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.KartListesi, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Sil, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Güncelle, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.Btn_Onayla, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.Btn_İptal, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.Txt_BankaAd, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(623, 378);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // KartListesi
            // 
            this.KartListesi.AllowCustomTheming = false;
            this.KartListesi.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.KartListesi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.KartListesi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.KartListesi.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.KartListesi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.KartListesi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.KartListesi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.KartListesi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.KartListesi.ColumnHeadersHeight = 40;
            this.tableLayoutPanel1.SetColumnSpan(this.KartListesi, 4);
            this.KartListesi.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.KartListesi.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.KartListesi.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.KartListesi.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.KartListesi.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.KartListesi.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.KartListesi.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.KartListesi.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.KartListesi.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.KartListesi.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.KartListesi.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.KartListesi.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.KartListesi.CurrentTheme.Name = null;
            this.KartListesi.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.KartListesi.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.KartListesi.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.KartListesi.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.KartListesi.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.KartListesi.DefaultCellStyle = dataGridViewCellStyle3;
            this.KartListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KartListesi.EnableHeadersVisualStyles = false;
            this.KartListesi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.KartListesi.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.KartListesi.HeaderBgColor = System.Drawing.Color.Empty;
            this.KartListesi.HeaderForeColor = System.Drawing.Color.White;
            this.KartListesi.Location = new System.Drawing.Point(3, 3);
            this.KartListesi.Name = "KartListesi";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.KartListesi.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.KartListesi.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.KartListesi, 4);
            this.KartListesi.RowTemplate.Height = 40;
            this.KartListesi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.KartListesi.Size = new System.Drawing.Size(617, 210);
            this.KartListesi.TabIndex = 69;
            this.KartListesi.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            this.KartListesi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.KartListesi_CellClick);
            // 
            // Btn_Sil
            // 
            this.Btn_Sil.ActiveBorderThickness = 1;
            this.Btn_Sil.ActiveCornerRadius = 20;
            this.Btn_Sil.ActiveFillColor = System.Drawing.Color.Green;
            this.Btn_Sil.ActiveForecolor = System.Drawing.Color.Transparent;
            this.Btn_Sil.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.Btn_Sil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Sil.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_Sil.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Sil.BackgroundImage")));
            this.Btn_Sil.ButtonText = "Sil";
            this.Btn_Sil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Sil.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Sil.ForeColor = System.Drawing.Color.SeaGreen;
            this.Btn_Sil.IdleBorderThickness = 1;
            this.Btn_Sil.IdleCornerRadius = 20;
            this.Btn_Sil.IdleFillColor = System.Drawing.Color.Transparent;
            this.Btn_Sil.IdleForecolor = System.Drawing.Color.Black;
            this.Btn_Sil.IdleLineColor = System.Drawing.Color.Black;
            this.Btn_Sil.Location = new System.Drawing.Point(470, 333);
            this.Btn_Sil.Margin = new System.Windows.Forms.Padding(5);
            this.Btn_Sil.Name = "Btn_Sil";
            this.Btn_Sil.Size = new System.Drawing.Size(148, 35);
            this.Btn_Sil.TabIndex = 84;
            this.Btn_Sil.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Sil.Click += new System.EventHandler(this.Btn_Sil_Click);
            // 
            // Btn_Güncelle
            // 
            this.Btn_Güncelle.ActiveBorderThickness = 1;
            this.Btn_Güncelle.ActiveCornerRadius = 20;
            this.Btn_Güncelle.ActiveFillColor = System.Drawing.Color.Green;
            this.Btn_Güncelle.ActiveForecolor = System.Drawing.Color.Transparent;
            this.Btn_Güncelle.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.Btn_Güncelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Güncelle.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_Güncelle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Güncelle.BackgroundImage")));
            this.Btn_Güncelle.ButtonText = "Güncelle";
            this.Btn_Güncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Güncelle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Güncelle.ForeColor = System.Drawing.Color.SeaGreen;
            this.Btn_Güncelle.IdleBorderThickness = 1;
            this.Btn_Güncelle.IdleCornerRadius = 20;
            this.Btn_Güncelle.IdleFillColor = System.Drawing.Color.Transparent;
            this.Btn_Güncelle.IdleForecolor = System.Drawing.Color.Black;
            this.Btn_Güncelle.IdleLineColor = System.Drawing.Color.Black;
            this.Btn_Güncelle.Location = new System.Drawing.Point(315, 333);
            this.Btn_Güncelle.Margin = new System.Windows.Forms.Padding(5);
            this.Btn_Güncelle.Name = "Btn_Güncelle";
            this.Btn_Güncelle.Size = new System.Drawing.Size(145, 35);
            this.Btn_Güncelle.TabIndex = 83;
            this.Btn_Güncelle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Güncelle.Click += new System.EventHandler(this.Btn_Güncelle_Click);
            // 
            // Btn_Onayla
            // 
            this.Btn_Onayla.ActiveBorderThickness = 1;
            this.Btn_Onayla.ActiveCornerRadius = 20;
            this.Btn_Onayla.ActiveFillColor = System.Drawing.Color.Green;
            this.Btn_Onayla.ActiveForecolor = System.Drawing.Color.Transparent;
            this.Btn_Onayla.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.Btn_Onayla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Onayla.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_Onayla.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Onayla.BackgroundImage")));
            this.Btn_Onayla.ButtonText = "Onayla";
            this.Btn_Onayla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Onayla.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Onayla.ForeColor = System.Drawing.Color.SeaGreen;
            this.Btn_Onayla.IdleBorderThickness = 1;
            this.Btn_Onayla.IdleCornerRadius = 20;
            this.Btn_Onayla.IdleFillColor = System.Drawing.Color.Transparent;
            this.Btn_Onayla.IdleForecolor = System.Drawing.Color.Black;
            this.Btn_Onayla.IdleLineColor = System.Drawing.Color.Black;
            this.Btn_Onayla.Location = new System.Drawing.Point(160, 333);
            this.Btn_Onayla.Margin = new System.Windows.Forms.Padding(5);
            this.Btn_Onayla.Name = "Btn_Onayla";
            this.Btn_Onayla.Size = new System.Drawing.Size(145, 35);
            this.Btn_Onayla.TabIndex = 82;
            this.Btn_Onayla.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Onayla.Click += new System.EventHandler(this.Btn_Onayla_Click);
            // 
            // Btn_İptal
            // 
            this.Btn_İptal.ActiveBorderThickness = 1;
            this.Btn_İptal.ActiveCornerRadius = 20;
            this.Btn_İptal.ActiveFillColor = System.Drawing.Color.Red;
            this.Btn_İptal.ActiveForecolor = System.Drawing.Color.Transparent;
            this.Btn_İptal.ActiveLineColor = System.Drawing.Color.Red;
            this.Btn_İptal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_İptal.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_İptal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_İptal.BackgroundImage")));
            this.Btn_İptal.ButtonText = "İptal";
            this.Btn_İptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_İptal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_İptal.ForeColor = System.Drawing.Color.SeaGreen;
            this.Btn_İptal.IdleBorderThickness = 1;
            this.Btn_İptal.IdleCornerRadius = 20;
            this.Btn_İptal.IdleFillColor = System.Drawing.Color.Transparent;
            this.Btn_İptal.IdleForecolor = System.Drawing.Color.Black;
            this.Btn_İptal.IdleLineColor = System.Drawing.Color.Black;
            this.Btn_İptal.Location = new System.Drawing.Point(5, 333);
            this.Btn_İptal.Margin = new System.Windows.Forms.Padding(5);
            this.Btn_İptal.Name = "Btn_İptal";
            this.Btn_İptal.Size = new System.Drawing.Size(145, 35);
            this.Btn_İptal.TabIndex = 79;
            this.Btn_İptal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_İptal.Click += new System.EventHandler(this.Btn_İptal_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(158, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 54);
            this.label1.TabIndex = 68;
            this.label1.Text = "Banka Adı:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Txt_BankaAd
            // 
            this.Txt_BankaAd.AcceptsReturn = false;
            this.Txt_BankaAd.AcceptsTab = false;
            this.Txt_BankaAd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_BankaAd.AnimationSpeed = 200;
            this.Txt_BankaAd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.Txt_BankaAd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.Txt_BankaAd.BackColor = System.Drawing.Color.Transparent;
            this.Txt_BankaAd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Txt_BankaAd.BackgroundImage")));
            this.Txt_BankaAd.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.Txt_BankaAd.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Txt_BankaAd.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.Txt_BankaAd.BorderColorIdle = System.Drawing.Color.Silver;
            this.Txt_BankaAd.BorderRadius = 15;
            this.Txt_BankaAd.BorderThickness = 1;
            this.Txt_BankaAd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.Txt_BankaAd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Txt_BankaAd.DefaultFont = new System.Drawing.Font("Palatino Linotype", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Txt_BankaAd.DefaultText = "";
            this.Txt_BankaAd.FillColor = System.Drawing.Color.White;
            this.Txt_BankaAd.HideSelection = true;
            this.Txt_BankaAd.IconLeft = null;
            this.Txt_BankaAd.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.Txt_BankaAd.IconPadding = 10;
            this.Txt_BankaAd.IconRight = null;
            this.Txt_BankaAd.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.Txt_BankaAd.Lines = new string[0];
            this.Txt_BankaAd.Location = new System.Drawing.Point(313, 223);
            this.Txt_BankaAd.MaxLength = 32767;
            this.Txt_BankaAd.MinimumSize = new System.Drawing.Size(1, 1);
            this.Txt_BankaAd.Modified = false;
            this.Txt_BankaAd.Multiline = false;
            this.Txt_BankaAd.Name = "Txt_BankaAd";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.Txt_BankaAd.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.Txt_BankaAd.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.Txt_BankaAd.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.Txt_BankaAd.OnIdleState = stateProperties4;
            this.Txt_BankaAd.Padding = new System.Windows.Forms.Padding(3);
            this.Txt_BankaAd.PasswordChar = '\0';
            this.Txt_BankaAd.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.Txt_BankaAd.PlaceholderText = "Banka Adı";
            this.Txt_BankaAd.ReadOnly = false;
            this.Txt_BankaAd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Txt_BankaAd.SelectedText = "";
            this.Txt_BankaAd.SelectionLength = 0;
            this.Txt_BankaAd.SelectionStart = 0;
            this.Txt_BankaAd.ShortcutsEnabled = true;
            this.Txt_BankaAd.Size = new System.Drawing.Size(149, 39);
            this.Txt_BankaAd.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.Txt_BankaAd.TabIndex = 78;
            this.Txt_BankaAd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Txt_BankaAd.TextMarginBottom = 0;
            this.Txt_BankaAd.TextMarginLeft = 3;
            this.Txt_BankaAd.TextMarginTop = 0;
            this.Txt_BankaAd.TextPlaceholder = "Banka Adı";
            this.Txt_BankaAd.UseSystemPasswordChar = false;
            this.Txt_BankaAd.WordWrap = true;
            this.Txt_BankaAd.TextChanged += new System.EventHandler(this.Txt_BankaAd_TextChanged);
            // 
            // kredikart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 378);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "kredikart";
            this.Text = "kredikart";
            this.Load += new System.EventHandler(this.Kredikart_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KartListesi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private Bunifu.UI.WinForms.BunifuDataGridView KartListesi;
        private Bunifu.UI.WinForms.BunifuTextBox Txt_BankaAd;
        private Bunifu.Framework.UI.BunifuThinButton2 Btn_İptal;
        private Bunifu.Framework.UI.BunifuThinButton2 Btn_Onayla;
        private Bunifu.Framework.UI.BunifuThinButton2 Btn_Güncelle;
        private Bunifu.Framework.UI.BunifuThinButton2 Btn_Sil;
    }
}