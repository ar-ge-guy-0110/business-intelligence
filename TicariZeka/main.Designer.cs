namespace TicariZeka
{
    partial class main
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.anatanimmodulbutton = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tedarikcimodulbutton = new System.Windows.Forms.Button();
            this.urunmodulbutton = new System.Windows.Forms.Button();
            this.alimislembutton = new System.Windows.Forms.Button();
            this.satimislembutton = new System.Windows.Forms.Button();
            this.iszekasibutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // anatanimmodulbutton
            // 
            this.anatanimmodulbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.anatanimmodulbutton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.anatanimmodulbutton.ImageIndex = 0;
            this.anatanimmodulbutton.ImageList = this.ımageList1;
            this.anatanimmodulbutton.Location = new System.Drawing.Point(12, 45);
            this.anatanimmodulbutton.Name = "anatanimmodulbutton";
            this.anatanimmodulbutton.Size = new System.Drawing.Size(150, 150);
            this.anatanimmodulbutton.TabIndex = 0;
            this.anatanimmodulbutton.Text = "Capital Definitions";
            this.anatanimmodulbutton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.anatanimmodulbutton.UseVisualStyleBackColor = true;
            this.anatanimmodulbutton.Click += new System.EventHandler(this.anatanimmodulbutton_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "investment.png");
            this.ımageList1.Images.SetKeyName(1, "manufacture.png");
            this.ımageList1.Images.SetKeyName(2, "box.png");
            this.ımageList1.Images.SetKeyName(3, "purchase-order.png");
            this.ımageList1.Images.SetKeyName(4, "satisfaction.png");
            this.ımageList1.Images.SetKeyName(5, "order.png");
            this.ımageList1.Images.SetKeyName(6, "sales (1).png");
            // 
            // tedarikcimodulbutton
            // 
            this.tedarikcimodulbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.tedarikcimodulbutton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tedarikcimodulbutton.ImageIndex = 1;
            this.tedarikcimodulbutton.ImageList = this.ımageList1;
            this.tedarikcimodulbutton.Location = new System.Drawing.Point(240, 45);
            this.tedarikcimodulbutton.Name = "tedarikcimodulbutton";
            this.tedarikcimodulbutton.Size = new System.Drawing.Size(150, 150);
            this.tedarikcimodulbutton.TabIndex = 1;
            this.tedarikcimodulbutton.Text = "Supplier Definitions";
            this.tedarikcimodulbutton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tedarikcimodulbutton.UseVisualStyleBackColor = true;
            this.tedarikcimodulbutton.Click += new System.EventHandler(this.tedarikcimodulbutton_Click);
            // 
            // urunmodulbutton
            // 
            this.urunmodulbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.urunmodulbutton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.urunmodulbutton.ImageIndex = 2;
            this.urunmodulbutton.ImageList = this.ımageList1;
            this.urunmodulbutton.Location = new System.Drawing.Point(468, 45);
            this.urunmodulbutton.Name = "urunmodulbutton";
            this.urunmodulbutton.Size = new System.Drawing.Size(150, 150);
            this.urunmodulbutton.TabIndex = 2;
            this.urunmodulbutton.Text = "Product Definitions";
            this.urunmodulbutton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.urunmodulbutton.UseVisualStyleBackColor = true;
            this.urunmodulbutton.Click += new System.EventHandler(this.urunmodulbutton_Click);
            // 
            // alimislembutton
            // 
            this.alimislembutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.alimislembutton.ImageIndex = 3;
            this.alimislembutton.ImageList = this.ımageList1;
            this.alimislembutton.Location = new System.Drawing.Point(12, 286);
            this.alimislembutton.Name = "alimislembutton";
            this.alimislembutton.Size = new System.Drawing.Size(150, 150);
            this.alimislembutton.TabIndex = 3;
            this.alimislembutton.Text = "Purchases";
            this.alimislembutton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.alimislembutton.UseVisualStyleBackColor = true;
            this.alimislembutton.Click += new System.EventHandler(this.alimislembutton_Click);
            // 
            // satimislembutton
            // 
            this.satimislembutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.satimislembutton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.satimislembutton.ImageKey = "order.png";
            this.satimislembutton.ImageList = this.ımageList1;
            this.satimislembutton.Location = new System.Drawing.Point(240, 286);
            this.satimislembutton.Name = "satimislembutton";
            this.satimislembutton.Size = new System.Drawing.Size(150, 150);
            this.satimislembutton.TabIndex = 4;
            this.satimislembutton.Text = "Sales Transactions";
            this.satimislembutton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.satimislembutton.UseVisualStyleBackColor = true;
            this.satimislembutton.Click += new System.EventHandler(this.satimislembutton_Click);
            // 
            // iszekasibutton
            // 
            this.iszekasibutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.iszekasibutton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.iszekasibutton.ImageIndex = 6;
            this.iszekasibutton.ImageList = this.ımageList1;
            this.iszekasibutton.Location = new System.Drawing.Point(468, 286);
            this.iszekasibutton.Name = "iszekasibutton";
            this.iszekasibutton.Size = new System.Drawing.Size(150, 150);
            this.iszekasibutton.TabIndex = 5;
            this.iszekasibutton.Text = "Commercial Reports";
            this.iszekasibutton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iszekasibutton.UseVisualStyleBackColor = true;
            this.iszekasibutton.Click += new System.EventHandler(this.iszekasibutton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.ImageIndex = 4;
            this.button1.ImageList = this.ımageList1;
            this.button1.Location = new System.Drawing.Point(696, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 150);
            this.button1.TabIndex = 6;
            this.button1.Text = "Consumer Definitions";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(858, 492);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.iszekasibutton);
            this.Controls.Add(this.satimislembutton);
            this.Controls.Add(this.alimislembutton);
            this.Controls.Add(this.urunmodulbutton);
            this.Controls.Add(this.tedarikcimodulbutton);
            this.Controls.Add(this.anatanimmodulbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.Text = "Commercial Intelligence - Business Intelligence Program";
            this.Load += new System.EventHandler(this.main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button anatanimmodulbutton;
        private System.Windows.Forms.Button tedarikcimodulbutton;
        private System.Windows.Forms.Button urunmodulbutton;
        private System.Windows.Forms.Button alimislembutton;
        private System.Windows.Forms.Button satimislembutton;
        private System.Windows.Forms.Button iszekasibutton;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Button button1;
    }
}

