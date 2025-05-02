using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace TicariZeka
{
    public partial class main_tedarikciler_kategoriler : Form
    {
        SqlConnection baglan = new SqlConnection(baglanticlass.baglanticumlesi);
        int id;
        public main_tedarikciler_kategoriler()
        {
            InitializeComponent();
        }

        private void main_tedarikciler_kategoriler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void listele()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT TOP 200 * FROM kategori_tedarikci";
            SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(maskedTextBox1.Text != "")
            {
                try
                {
                    //kategori ekle
                    SqlCommand ekle = new SqlCommand("INSERT INTO kategori_tedarikci(kategori_adi) VALUES(@ka)", baglan);
                    ekle.Parameters.AddWithValue("@ka", SqlDbType.NVarChar).Value = maskedTextBox1.Text;

                    baglan.Open();
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    listele();
                }
                catch
                {
                    MessageBox.Show("Şu an işlem gerçekleşemiyor, lütfen tekrar deneyiniz.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bilgileri eksiksiz girdiğinize emin olunuz.");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //kategori sil
            if(id != -1)
            {
                DialogResult eminmisin = MessageBox.Show("Kategori silinirse bu kategoriyle ile ilgili bütün veriler silinir! Devam Edilsin mi?", "UYARI!", MessageBoxButtons.YesNo);
                if (eminmisin == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand sil = new SqlCommand("DELETE FROM kategori_tedarikci WHERE id=@id", baglan);
                        sil.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                        baglan.Open();
                        sil.ExecuteNonQuery();
                        baglan.Close();

                        listele();
                        id = -1;
                    }
                    catch
                    {
                        MessageBox.Show("Şu an işlem gerçekleşemiyor, lütfen tekrar deneyiniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Silme işlemi başarıyla iptal edildi.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen tablodaki silmek istediğiniz veriye çift tıklayıp seçili hale getiriniz.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //kategori güncelle
            if(maskedTextBox1.Text != "" && id != -1)
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("UPDATE kategori_tedarikci SET kategori_adi = @kadi WHERE id = @id", baglan);
                    guncelle.Parameters.AddWithValue("@kadi", SqlDbType.NVarChar).Value = maskedTextBox1.Text;
                    guncelle.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

                    baglan.Open();
                    guncelle.ExecuteNonQuery();
                    baglan.Close();
                    listele();
                }
                catch
                {
                    MessageBox.Show("Şu an işlem gerçekleşemiyor, lütfen tekrar deneyiniz.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen tablodaki güncellenecek veriyi seçiniz ve bilgileri eksiksiz girdiğinize emin olunuz.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //kategori ara
            if(maskedTextBox1.Text != "")
            {
                DataTable dt = new DataTable();
                string sql = "SELECT TOP 200 * FROM kategori_tedarikci WHERE kategori_adi LIKE '%" + maskedTextBox1.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                listele();
            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //tiklagetir
            try
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                id = -1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}
