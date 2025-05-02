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
    public partial class main_tedarikciler : Form
    {
        SqlConnection baglan = new SqlConnection(baglanticlass.baglanticumlesi);
        int id;
        public main_tedarikciler()
        {
            InitializeComponent();
        }

        private void main_tedarikciler_Load(object sender, EventArgs e)
        {
            if ((main)Application.OpenForms["main"] != null)
            {
                main mainwin = (main)Application.OpenForms["main"];
                mainwin.formOpen_main_tedarikciler = true;
            }


            id = -1;

            listele();

            //kategoriler gelsin
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM kategori_tedarikci", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["kategori_adi"]);
            }
            baglan.Close();
        }

        private void main_tedarikciler_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((main)Application.OpenForms["main"] != null)
            {
                main mainwin = (main)Application.OpenForms["main"];
                mainwin.formOpen_main_tedarikciler = false;
            }
        }

        private void listele()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT TOP 200 * FROM tedarikci";
            SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void tedarikciKategorileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form main_tedarikciler_kategoriler = new main_tedarikciler_kategoriler();
            main_tedarikciler_kategoriler.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //EKLE
            if(comboBox1.SelectedIndex != -1 && maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && maskedTextBox4.Text != "" && maskedTextBox5.Text != "")
            {
                try
                {
                    //kategori id bul
                    DataTable dt = new DataTable();
                    string sql = "SELECT id FROM kategori_tedarikci WHERE kategori_adi = N'" + comboBox1.SelectedItem.ToString() + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                    da.Fill(dt);


                    //eklemeye devam ticari
                    SqlCommand ekle = new SqlCommand("INSERT INTO tedarikci(kategori_id, tedarikci_kodu, tedarikci_unvan, tedarikci_adres, tedarikci_vergino, tedarikci_telno) VALUES(@kid, @tkod, @tu, @ta, @tv, @tt)", baglan);
                    ekle.Parameters.AddWithValue("@kid", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[0][0]);
                    ekle.Parameters.AddWithValue("@tkod", SqlDbType.NVarChar).Value = maskedTextBox1.Text;
                    ekle.Parameters.AddWithValue("@tu", SqlDbType.NVarChar).Value = maskedTextBox2.Text;
                    ekle.Parameters.AddWithValue("@ta", SqlDbType.NVarChar).Value = maskedTextBox3.Text;
                    ekle.Parameters.AddWithValue("@tv", SqlDbType.VarChar).Value = maskedTextBox4.Text;
                    ekle.Parameters.AddWithValue("@tt", SqlDbType.VarChar).Value = maskedTextBox5.Text;
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
            //SİL
            if(id != -1)
            {
                DialogResult eminmisin = MessageBox.Show("Tedarikci silinirse bu tedarikci ile ilgili bütün veriler silinir! Devam Edilsin mi?", "UYARI!", MessageBoxButtons.YesNo);
                if (eminmisin == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand sil = new SqlCommand("DELETE FROM tedarikci WHERE id=@id", baglan);
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
            //GÜNCELLE
            if (id != -1 && comboBox1.SelectedIndex != -1 && maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && maskedTextBox4.Text != "" && maskedTextBox5.Text != "")
            {
                try
                {
                    //kategori id bul
                    DataTable dt = new DataTable();
                    string sql = "SELECT id FROM kategori_tedarikci WHERE kategori_adi = N'" + comboBox1.SelectedItem.ToString() + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                    da.Fill(dt);

                    //güncelle ticari güncelle!
                    SqlCommand guncelle = new SqlCommand("UPDATE tedarikci SET kategori_id = @kid, tedarikci_kodu = @tkod, tedarikci_unvan = @tu, tedarikci_adres = @ta, tedarikci_vergino = @tv, tedarikci_telno = @tt WHERE id = @id", baglan);
                    guncelle.Parameters.AddWithValue("@kid", SqlDbType.Int).Value = Convert.ToInt32(dt.Rows[0][0]);
                    guncelle.Parameters.AddWithValue("@tkod", SqlDbType.NVarChar).Value = maskedTextBox1.Text;
                    guncelle.Parameters.AddWithValue("@tu", SqlDbType.NVarChar).Value = maskedTextBox2.Text;
                    guncelle.Parameters.AddWithValue("@ta", SqlDbType.NVarChar).Value = maskedTextBox3.Text;
                    guncelle.Parameters.AddWithValue("@tv", SqlDbType.VarChar).Value = maskedTextBox4.Text;
                    guncelle.Parameters.AddWithValue("@tt", SqlDbType.VarChar).Value = maskedTextBox5.Text;
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


            //ARA
            string sql2 = "";

            string cmd_start = "SELECT TOP 200";
            string cmd_middle = " *";
            string cmd_end = " FROM tedarikci WHERE";
            int cmdend_length = cmd_end.Length;

            if (comboBox1.SelectedIndex != -1)
            {
                //kategori id bul
                DataTable dt = new DataTable();
                string sql = "SELECT id FROM kategori_tedarikci WHERE kategori_adi = N'" + comboBox1.SelectedItem.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                da.Fill(dt);

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " kategori_id LIKE '%" + Convert.ToInt32(dt.Rows[0][0]).ToString() + "%'";
            }

            if (maskedTextBox1.Text != null && maskedTextBox1.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " tedarikci_kodu LIKE N'%" + maskedTextBox1.Text + "%'";
            }

            if (maskedTextBox2.Text != null && maskedTextBox2.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " tedarikci_unvan LIKE N'%" + maskedTextBox2.Text + "%'";
            }

            if (maskedTextBox3.Text != null && maskedTextBox3.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " tedarikci_adres LIKE N'%" + maskedTextBox3.Text + "%'";
            }

            if (maskedTextBox4.Text != null && maskedTextBox4.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " tedarikci_vergino LIKE N'%" + maskedTextBox4.Text + "%'";
            }

            if (maskedTextBox5.Text != null && maskedTextBox5.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " tedarikci_telno LIKE N'%" + maskedTextBox5.Text + "%'";
            }


            sql2 = cmd_start + cmd_middle + cmd_end;

            if( comboBox1.SelectedIndex != -1 || maskedTextBox1.Text != "" || maskedTextBox2.Text != "" || maskedTextBox3.Text != "" || maskedTextBox4.Text != "" || maskedTextBox5.Text != "")
            {
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(sql2, baglan);
                da2.Fill(dt2);
                dataGridView1.DataSource = dt2;
            }
            else
            {
                listele();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //LISTELE
            listele();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //TIKLAGETIR
            try
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                maskedTextBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                maskedTextBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                maskedTextBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                id = -1;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //TEMİZLE
            id = -1;
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";
            maskedTextBox5.Text = "";

        }
    }
}
