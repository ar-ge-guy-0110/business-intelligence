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
    public partial class main_musteriler : Form
    {
        SqlConnection baglan = new SqlConnection(baglanticlass.baglanticumlesi);
        int id;
        public main_musteriler()
        {
            InitializeComponent();
        }

        private void listele()
        {
            SqlCommand listeleq = new SqlCommand("SELECT * FROM customer", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "customer");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "customer";
        }

        private void main_musteriler_Load(object sender, EventArgs e)
        {
            listele();

            id = -1;

            if ((main)Application.OpenForms["main"] != null)
            {
                main mainwin = (main)Application.OpenForms["main"];
                mainwin.formOpen_main_musteriler = true;
            }

        }

        private void main_musteriler_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((main)Application.OpenForms["main"] != null)
            {
                main mainwin = (main)Application.OpenForms["main"];
                mainwin.formOpen_main_musteriler = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ekle
            if (maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && maskedTextBox4.Text != "" && maskedTextBox5.Text != "")
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO customer(customercode, customername, address, taxno, telno)" +
                        "VALUES(@ccode, @cname, @caddress, @ctaxno, @ctelno)", baglan);
                    ekle.Parameters.AddWithValue("@ccode", SqlDbType.NVarChar).Value = maskedTextBox1.Text;
                    ekle.Parameters.AddWithValue("@cname", SqlDbType.NVarChar).Value = maskedTextBox2.Text;
                    ekle.Parameters.AddWithValue("@caddress", SqlDbType.NVarChar).Value = maskedTextBox3.Text;
                    ekle.Parameters.AddWithValue("@ctaxno", SqlDbType.NVarChar).Value = maskedTextBox4.Text;
                    ekle.Parameters.AddWithValue("@ctelno", SqlDbType.VarChar).Value = maskedTextBox5.Text;

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
            //sil
            if (id != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM customer WHERE id=@id", baglan);
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
                MessageBox.Show("Lütfen tablodaki silmek istediğiniz veriye çift tıklayıp seçili hale getiriniz.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //güncelle
            if (maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && maskedTextBox4.Text != "" && maskedTextBox5.Text != "" && id != -1)
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("UPDATE customer SET customercode = @ccode, customername = @cname, address = @caddress, taxno = @ctaxno, telno = @ctelno WHERE id = @id", baglan);
                    guncelle.Parameters.AddWithValue("@ccode", SqlDbType.NVarChar).Value = maskedTextBox1.Text;
                    guncelle.Parameters.AddWithValue("@cname", SqlDbType.NVarChar).Value = maskedTextBox2.Text;
                    guncelle.Parameters.AddWithValue("@caddress", SqlDbType.NVarChar).Value = maskedTextBox3.Text;
                    guncelle.Parameters.AddWithValue("@ctaxno", SqlDbType.NVarChar).Value = maskedTextBox4.Text;
                    guncelle.Parameters.AddWithValue("@ctelno", SqlDbType.VarChar).Value = maskedTextBox5.Text;
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
            //ara
            string cmd_start = "SELECT";
            string cmd_middle = " *";
            string cmd_end = " FROM customer WHERE";
            int cmdend_length = cmd_end.Length;

            if (maskedTextBox1.Text != null && maskedTextBox1.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " customercode LIKE '%'+@ccode+'%'";
            }

            if (maskedTextBox2.Text != null && maskedTextBox2.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " customername LIKE '%'+@cname+'%'";
            }

            if (maskedTextBox3.Text != null && maskedTextBox3.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " address LIKE '%'+@caddress+'%'";
            }

            if (maskedTextBox4.Text != null && maskedTextBox4.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " taxno LIKE '%'+@ctaxno+'%'";
            }

            if (maskedTextBox5.Text != null && maskedTextBox5.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " telno LIKE '%'+@ctelno+'%'";
            }

            SqlCommand bul = new SqlCommand(cmd_start + cmd_middle + cmd_end, baglan);

            if (maskedTextBox1.Text != null && maskedTextBox1.Text != "")
                bul.Parameters.AddWithValue("@ccode", SqlDbType.Int).Value = maskedTextBox1.Text;
            if (maskedTextBox2.Text != null && maskedTextBox2.Text != "")
                bul.Parameters.AddWithValue("@cname", SqlDbType.NVarChar).Value = maskedTextBox2.Text;
            if (maskedTextBox3.Text != null && maskedTextBox3.Text != "")
                bul.Parameters.AddWithValue("@caddress", SqlDbType.NVarChar).Value = maskedTextBox3.Text;
            if (maskedTextBox4.Text != null && maskedTextBox4.Text != "")
                bul.Parameters.AddWithValue("@ctaxno", SqlDbType.NVarChar).Value = maskedTextBox4.Text;
            if (maskedTextBox5.Text != null && maskedTextBox5.Text != "")
                bul.Parameters.AddWithValue("@ctelno", SqlDbType.NVarChar).Value = maskedTextBox5.Text;

            MessageBox.Show(cmd_start + cmd_middle + cmd_end);

            if (maskedTextBox1.Text != "" || maskedTextBox2.Text != "" || maskedTextBox3.Text != "" || maskedTextBox4.Text != "" || maskedTextBox5.Text != "")
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(bul);
                da.Fill(ds, "customer");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "customer";
            }
            else
            {
                listele();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //hepsini listele
            listele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //temizle
            id = -1;
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";
            maskedTextBox5.Text = "";
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //tiklagetir
            try
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                maskedTextBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                maskedTextBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                maskedTextBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                id = -1;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
