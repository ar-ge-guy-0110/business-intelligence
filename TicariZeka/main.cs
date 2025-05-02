using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicariZeka
{
    public partial class main : Form
    {
        //form şalterleri
        public bool formOpen_main_anatanimlar { get; set; }
        public bool formOpen_main_tedarikciler { get; set; }
        public bool formOpen_main_urunler { get; set; }
        public bool formOpen_main_alim { get; set; }
        public bool formOpen_main_musteriler { get; set; }
        public bool formOpen_main_satim { get; set; }
        public bool formOpen_main_iszekasi { get; set; }
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            formOpen_main_anatanimlar = false;
            formOpen_main_tedarikciler = false;
            formOpen_main_urunler = false;
            formOpen_main_alim = false;
            formOpen_main_musteriler = false;
            formOpen_main_satim = false;
            formOpen_main_iszekasi = false;
        }

        private void anatanimmodulbutton_Click(object sender, EventArgs e)
        {
            if(formOpen_main_anatanimlar == false)
            {
                Form main_anatanimlar = new main_anatanimlar();
                main_anatanimlar.Show();
            }
        }

        private void tedarikcimodulbutton_Click(object sender, EventArgs e)
        {
            if (formOpen_main_tedarikciler == false)
            {
                Form main_tedarikciler = new main_tedarikciler();
                main_tedarikciler.Show();
            }
        }

        private void urunmodulbutton_Click(object sender, EventArgs e)
        {
            if (formOpen_main_urunler == false)
            {
                Form main_urunler = new main_urunler();
                main_urunler.Show();
            }
        }

        private void alimislembutton_Click(object sender, EventArgs e)
        {
            if (formOpen_main_alim == false)
            {
                Form main_alim = new main_alim();
                main_alim.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (formOpen_main_musteriler == false)
            {
                Form main_musteriler = new main_musteriler();
                main_musteriler.Show();
            }
        }

        private void satimislembutton_Click(object sender, EventArgs e)
        {
            if (formOpen_main_satim == false)
            {
                Form main_satim = new main_satim();
                main_satim.Show();
            }
        }

        private void iszekasibutton_Click(object sender, EventArgs e)
        {
            if (formOpen_main_iszekasi == false)
            {
                Form main_iszekasi = new main_iszekasi();
                main_iszekasi.Show();
            }
        }
    }
}
