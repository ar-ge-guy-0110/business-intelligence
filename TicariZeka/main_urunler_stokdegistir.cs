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
using System.Configuration;

namespace TicariZeka
{
    public partial class main_urunler_stokdegistir : Form
    {
        SqlConnection baglan = new SqlConnection(baglanticlass.baglanticumlesi);
        main_urunler mainwin = (main_urunler)Application.OpenForms["main_urunler"];



        string urunadi;
        int id;
        public main_urunler_stokdegistir()
        {
            InitializeComponent();
        }

        private void main_urunler_stokdegistir_Load(object sender, EventArgs e)
        {

            urunadi = mainwin.urunadi;
            this.Text = urunadi + ": Stok - Ticari Zeka";
            id = mainwin.idd;
            //MessageBox.Show(id.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(maskedTextBox1.Text != "")
            {
                SqlCommand stokguncel = new SqlCommand("UPDATE stok_urun SET miktar = @mr WHERE urun_id = @id", baglan);
                stokguncel.Parameters.AddWithValue("@mr", SqlDbType.Int).Value = Convert.ToInt32(maskedTextBox1.Text);
                stokguncel.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                baglan.Open();
                stokguncel.ExecuteNonQuery();
                baglan.Close();

                mainwin.stockupdated = true;
            }
            else
            {
                MessageBox.Show("Lütfen stok miktarını giriniz.");
            }

        }

        private void main_urunler_stokdegistir_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
