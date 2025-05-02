
namespace TicariZeka
{
    partial class fm_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_main));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lbTitleChildForm = new System.Windows.Forms.Label();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMinimize = new FontAwesome.Sharp.IconPictureBox();
            this.btnMaximize = new FontAwesome.Sharp.IconPictureBox();
            this.btnExit = new FontAwesome.Sharp.IconPictureBox();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.btnGrafikler = new FontAwesome.Sharp.IconButton();
            this.btnTicari = new FontAwesome.Sharp.IconButton();
            this.btnSatim = new FontAwesome.Sharp.IconButton();
            this.btnAlim = new FontAwesome.Sharp.IconButton();
            this.btnMusteri = new FontAwesome.Sharp.IconButton();
            this.btnUrun = new FontAwesome.Sharp.IconButton();
            this.btnTedarik = new FontAwesome.Sharp.IconButton();
            this.btnSermaye = new FontAwesome.Sharp.IconButton();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelMenu.Controls.Add(this.btnGrafikler);
            this.panelMenu.Controls.Add(this.btnTicari);
            this.panelMenu.Controls.Add(this.btnSatim);
            this.panelMenu.Controls.Add(this.btnAlim);
            this.panelMenu.Controls.Add(this.btnMusteri);
            this.panelMenu.Controls.Add(this.btnUrun);
            this.panelMenu.Controls.Add(this.btnTedarik);
            this.panelMenu.Controls.Add(this.btnSermaye);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 631);
            this.panelMenu.TabIndex = 0;
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.btnHome);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 140);
            this.panelLogo.TabIndex = 0;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panelTitleBar.Controls.Add(this.btnMinimize);
            this.panelTitleBar.Controls.Add(this.btnMaximize);
            this.panelTitleBar.Controls.Add(this.btnExit);
            this.panelTitleBar.Controls.Add(this.lbTitleChildForm);
            this.panelTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(964, 75);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // lbTitleChildForm
            // 
            this.lbTitleChildForm.AutoSize = true;
            this.lbTitleChildForm.ForeColor = System.Drawing.Color.Gainsboro;
            this.lbTitleChildForm.Location = new System.Drawing.Point(44, 30);
            this.lbTitleChildForm.Name = "lbTitleChildForm";
            this.lbTitleChildForm.Size = new System.Drawing.Size(56, 13);
            this.lbTitleChildForm.TabIndex = 1;
            this.lbTitleChildForm.Text = "Ana Sayfa";
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(220, 75);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(964, 9);
            this.panelShadow.TabIndex = 2;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelDesktop.Controls.Add(this.pictureBox1);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(220, 84);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(964, 547);
            this.panelDesktop.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::TicariZeka.Properties.Resources.ikonn;
            this.pictureBox1.Location = new System.Drawing.Point(382, 173);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.btnMinimize.ForeColor = System.Drawing.Color.MediumPurple;
            this.btnMinimize.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btnMinimize.IconColor = System.Drawing.Color.MediumPurple;
            this.btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimize.IconSize = 16;
            this.btnMinimize.Location = new System.Drawing.Point(892, 4);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(16, 16);
            this.btnMinimize.TabIndex = 4;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            this.btnMinimize.MouseEnter += new System.EventHandler(this.btnMinimize_MouseEnter);
            this.btnMinimize.MouseLeave += new System.EventHandler(this.btnMinimize_MouseLeave);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.btnMaximize.ForeColor = System.Drawing.Color.MediumPurple;
            this.btnMaximize.IconChar = FontAwesome.Sharp.IconChar.ExternalLinkAlt;
            this.btnMaximize.IconColor = System.Drawing.Color.MediumPurple;
            this.btnMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMaximize.IconSize = 16;
            this.btnMaximize.Location = new System.Drawing.Point(914, 4);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(16, 16);
            this.btnMaximize.TabIndex = 3;
            this.btnMaximize.TabStop = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            this.btnMaximize.MouseEnter += new System.EventHandler(this.btnMaximize_MouseEnter);
            this.btnMaximize.MouseLeave += new System.EventHandler(this.btnMaximize_MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.btnExit.ForeColor = System.Drawing.Color.MediumPurple;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnExit.IconColor = System.Drawing.Color.MediumPurple;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 16;
            this.btnExit.Location = new System.Drawing.Point(936, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(16, 16);
            this.btnExit.TabIndex = 2;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.iconCurrentChildForm.ForeColor = System.Drawing.Color.MediumPurple;
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.MediumPurple;
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(6, 21);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(32, 32);
            this.iconCurrentChildForm.TabIndex = 0;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // btnGrafikler
            // 
            this.btnGrafikler.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGrafikler.FlatAppearance.BorderSize = 0;
            this.btnGrafikler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrafikler.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnGrafikler.IconChar = FontAwesome.Sharp.IconChar.ChartArea;
            this.btnGrafikler.IconColor = System.Drawing.Color.Gainsboro;
            this.btnGrafikler.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGrafikler.IconSize = 32;
            this.btnGrafikler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrafikler.Location = new System.Drawing.Point(0, 560);
            this.btnGrafikler.Name = "btnGrafikler";
            this.btnGrafikler.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnGrafikler.Size = new System.Drawing.Size(220, 60);
            this.btnGrafikler.TabIndex = 8;
            this.btnGrafikler.Text = "Grafikler";
            this.btnGrafikler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGrafikler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGrafikler.UseVisualStyleBackColor = true;
            this.btnGrafikler.Click += new System.EventHandler(this.btnGrafikler_Click);
            // 
            // btnTicari
            // 
            this.btnTicari.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTicari.FlatAppearance.BorderSize = 0;
            this.btnTicari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTicari.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTicari.IconChar = FontAwesome.Sharp.IconChar.ChartPie;
            this.btnTicari.IconColor = System.Drawing.Color.Gainsboro;
            this.btnTicari.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTicari.IconSize = 32;
            this.btnTicari.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTicari.Location = new System.Drawing.Point(0, 500);
            this.btnTicari.Name = "btnTicari";
            this.btnTicari.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnTicari.Size = new System.Drawing.Size(220, 60);
            this.btnTicari.TabIndex = 7;
            this.btnTicari.Text = "Ticari Raporlar";
            this.btnTicari.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTicari.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTicari.UseVisualStyleBackColor = true;
            this.btnTicari.Click += new System.EventHandler(this.btnTicari_Click);
            // 
            // btnSatim
            // 
            this.btnSatim.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSatim.FlatAppearance.BorderSize = 0;
            this.btnSatim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatim.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSatim.IconChar = FontAwesome.Sharp.IconChar.LiraSign;
            this.btnSatim.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSatim.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSatim.IconSize = 32;
            this.btnSatim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSatim.Location = new System.Drawing.Point(0, 440);
            this.btnSatim.Name = "btnSatim";
            this.btnSatim.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnSatim.Size = new System.Drawing.Size(220, 60);
            this.btnSatim.TabIndex = 6;
            this.btnSatim.Text = "Satım İşlemleri";
            this.btnSatim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSatim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSatim.UseVisualStyleBackColor = true;
            this.btnSatim.Click += new System.EventHandler(this.btnSatim_Click);
            // 
            // btnAlim
            // 
            this.btnAlim.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAlim.FlatAppearance.BorderSize = 0;
            this.btnAlim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlim.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAlim.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.btnAlim.IconColor = System.Drawing.Color.Gainsboro;
            this.btnAlim.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAlim.IconSize = 32;
            this.btnAlim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlim.Location = new System.Drawing.Point(0, 380);
            this.btnAlim.Name = "btnAlim";
            this.btnAlim.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnAlim.Size = new System.Drawing.Size(220, 60);
            this.btnAlim.TabIndex = 5;
            this.btnAlim.Text = "Alım İşlemleri";
            this.btnAlim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlim.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlim.UseVisualStyleBackColor = true;
            this.btnAlim.Click += new System.EventHandler(this.btnAlim_Click);
            // 
            // btnMusteri
            // 
            this.btnMusteri.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMusteri.FlatAppearance.BorderSize = 0;
            this.btnMusteri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusteri.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnMusteri.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.btnMusteri.IconColor = System.Drawing.Color.Gainsboro;
            this.btnMusteri.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMusteri.IconSize = 32;
            this.btnMusteri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMusteri.Location = new System.Drawing.Point(0, 320);
            this.btnMusteri.Name = "btnMusteri";
            this.btnMusteri.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnMusteri.Size = new System.Drawing.Size(220, 60);
            this.btnMusteri.TabIndex = 4;
            this.btnMusteri.Text = "Müşteri Tanımları";
            this.btnMusteri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMusteri.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMusteri.UseVisualStyleBackColor = true;
            this.btnMusteri.Click += new System.EventHandler(this.btnMusteri_Click);
            // 
            // btnUrun
            // 
            this.btnUrun.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUrun.FlatAppearance.BorderSize = 0;
            this.btnUrun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrun.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnUrun.IconChar = FontAwesome.Sharp.IconChar.Box;
            this.btnUrun.IconColor = System.Drawing.Color.Gainsboro;
            this.btnUrun.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUrun.IconSize = 32;
            this.btnUrun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUrun.Location = new System.Drawing.Point(0, 260);
            this.btnUrun.Name = "btnUrun";
            this.btnUrun.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnUrun.Size = new System.Drawing.Size(220, 60);
            this.btnUrun.TabIndex = 3;
            this.btnUrun.Text = "Ürün Tanımları";
            this.btnUrun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUrun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUrun.UseVisualStyleBackColor = true;
            this.btnUrun.Click += new System.EventHandler(this.btnUrun_Click);
            // 
            // btnTedarik
            // 
            this.btnTedarik.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTedarik.FlatAppearance.BorderSize = 0;
            this.btnTedarik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTedarik.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTedarik.IconChar = FontAwesome.Sharp.IconChar.TruckLoading;
            this.btnTedarik.IconColor = System.Drawing.Color.Gainsboro;
            this.btnTedarik.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTedarik.IconSize = 32;
            this.btnTedarik.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTedarik.Location = new System.Drawing.Point(0, 200);
            this.btnTedarik.Name = "btnTedarik";
            this.btnTedarik.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnTedarik.Size = new System.Drawing.Size(220, 60);
            this.btnTedarik.TabIndex = 2;
            this.btnTedarik.Text = "Tedarikçi Tanımları";
            this.btnTedarik.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTedarik.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTedarik.UseVisualStyleBackColor = true;
            this.btnTedarik.Click += new System.EventHandler(this.btnTedarik_Click);
            // 
            // btnSermaye
            // 
            this.btnSermaye.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSermaye.FlatAppearance.BorderSize = 0;
            this.btnSermaye.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSermaye.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSermaye.IconChar = FontAwesome.Sharp.IconChar.Wallet;
            this.btnSermaye.IconColor = System.Drawing.Color.Gainsboro;
            this.btnSermaye.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSermaye.IconSize = 32;
            this.btnSermaye.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSermaye.Location = new System.Drawing.Point(0, 140);
            this.btnSermaye.Name = "btnSermaye";
            this.btnSermaye.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnSermaye.Size = new System.Drawing.Size(220, 60);
            this.btnSermaye.TabIndex = 1;
            this.btnSermaye.Text = "Sermaye Tanımları";
            this.btnSermaye.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSermaye.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSermaye.UseVisualStyleBackColor = true;
            this.btnSermaye.Click += new System.EventHandler(this.btnSermaye_Click);
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHome.Image = global::TicariZeka.Properties.Resources.ikonn;
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(220, 140);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // fm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 631);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fm_main";
            this.Text = "Ticari Zeka";
            this.Load += new System.EventHandler(this.fm_main_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelDesktop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private FontAwesome.Sharp.IconButton btnSermaye;
        private FontAwesome.Sharp.IconButton btnTedarik;
        private FontAwesome.Sharp.IconButton btnTicari;
        private FontAwesome.Sharp.IconButton btnSatim;
        private FontAwesome.Sharp.IconButton btnAlim;
        private FontAwesome.Sharp.IconButton btnMusteri;
        private FontAwesome.Sharp.IconButton btnUrun;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Label lbTitleChildForm;
        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconPictureBox btnMinimize;
        private FontAwesome.Sharp.IconPictureBox btnMaximize;
        private FontAwesome.Sharp.IconPictureBox btnExit;
        private FontAwesome.Sharp.IconButton btnGrafikler;
    }
}