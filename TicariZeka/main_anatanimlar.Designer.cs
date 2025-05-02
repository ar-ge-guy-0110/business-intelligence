namespace TicariZeka
{
    partial class main_anatanimlar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_anatanimlar));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ticarizekaDataSetSermayeler = new TicariZeka.ticarizekaDataSetSermayeler();
            this.sermayeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sermayeTableAdapter = new TicariZeka.ticarizekaDataSetSermayelerTableAdapters.sermayeTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ticarizekaDataSetSermayelerNew = new TicariZeka.ticarizekaDataSetSermayelerNew();
            this.sermayeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sermayeTableAdapter1 = new TicariZeka.ticarizekaDataSetSermayelerNewTableAdapters.sermayeTableAdapter();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticarizekaDataSetSermayeler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sermayeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticarizekaDataSetSermayelerNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sermayeBindingSource1)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tarih:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(300, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Gray;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dataGridView1.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.Size = new System.Drawing.Size(648, 508);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(126, 57);
            this.maskedTextBox1.Mask = "AAAAAAAAAAAA";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.PromptChar = ' ';
            this.maskedTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.maskedTextBox1.Size = new System.Drawing.Size(160, 20);
            this.maskedTextBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(28, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sermaye Adı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(7, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sermaye Miktarı:";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Location = new System.Drawing.Point(126, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ekle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ticarizekaDataSetSermayeler
            // 
            this.ticarizekaDataSetSermayeler.DataSetName = "ticarizekaDataSetSermayeler";
            this.ticarizekaDataSetSermayeler.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sermayeBindingSource
            // 
            this.sermayeBindingSource.DataMember = "sermaye";
            this.sermayeBindingSource.DataSource = this.ticarizekaDataSetSermayeler;
            // 
            // sermayeTableAdapter
            // 
            this.sermayeTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Gainsboro;
            this.button2.Location = new System.Drawing.Point(126, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Sil";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Gainsboro;
            this.button3.Location = new System.Drawing.Point(126, 168);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Güncelle";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Gainsboro;
            this.button4.Location = new System.Drawing.Point(126, 197);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(160, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Ara";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ticarizekaDataSetSermayelerNew
            // 
            this.ticarizekaDataSetSermayelerNew.DataSetName = "ticarizekaDataSetSermayelerNew";
            this.ticarizekaDataSetSermayelerNew.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sermayeBindingSource1
            // 
            this.sermayeBindingSource1.DataMember = "sermaye";
            this.sermayeBindingSource1.DataSource = this.ticarizekaDataSetSermayelerNew;
            // 
            // sermayeTableAdapter1
            // 
            this.sermayeTableAdapter1.ClearBeforeFill = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(126, 83);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.Gainsboro;
            this.button5.Location = new System.Drawing.Point(126, 226);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(160, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "Hepsini Listele";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Controls.Add(this.button5);
            this.panelMenu.Controls.Add(this.label2);
            this.panelMenu.Controls.Add(this.textBox1);
            this.panelMenu.Controls.Add(this.label3);
            this.panelMenu.Controls.Add(this.button4);
            this.panelMenu.Controls.Add(this.maskedTextBox1);
            this.panelMenu.Controls.Add(this.button3);
            this.panelMenu.Controls.Add(this.button1);
            this.panelMenu.Controls.Add(this.button2);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(300, 508);
            this.panelMenu.TabIndex = 12;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // main_anatanimlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(948, 508);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelMenu);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main_anatanimlar";
            this.Text = "Ana Tanımlar - Ticari Zeka";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.main_anatanimlar_FormClosed);
            this.Load += new System.EventHandler(this.main_anatanimlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticarizekaDataSetSermayeler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sermayeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticarizekaDataSetSermayelerNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sermayeBindingSource1)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private ticarizekaDataSetSermayeler ticarizekaDataSetSermayeler;
        private System.Windows.Forms.BindingSource sermayeBindingSource;
        private ticarizekaDataSetSermayelerTableAdapters.sermayeTableAdapter sermayeTableAdapter;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer timer1;
        private ticarizekaDataSetSermayelerNew ticarizekaDataSetSermayelerNew;
        private System.Windows.Forms.BindingSource sermayeBindingSource1;
        private ticarizekaDataSetSermayelerNewTableAdapters.sermayeTableAdapter sermayeTableAdapter1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panelMenu;
    }
}