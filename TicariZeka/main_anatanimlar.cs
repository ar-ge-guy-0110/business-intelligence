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
    public partial class main_anatanimlar : Form
    {
        //SqlConnection baglan = new SqlConnection(ConfigurationManager.ConnectionStrings["TicariZeka.Properties.Settings.ticarizekaConnectionString"].ConnectionString);
        SqlConnection baglan = new SqlConnection(baglanticlass.baglanticumlesi);

        int id;
        int anasermayeid;
        float sermayee;

        public main_anatanimlar()
        {
            InitializeComponent();
        }

        private void main_anatanimlar_Load(object sender, EventArgs e)
        {


            label1.Text = DateTime.Now.ToLongDateString();

            if ((main)Application.OpenForms["main"] != null)
            {
                main mainwin = (main)Application.OpenForms["main"];
                mainwin.formOpen_main_anatanimlar = true;
            }



            id = -1;

            listele();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Tarih: " + DateTime.Now.ToLongDateString();
        }

        private void main_anatanimlar_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((main)Application.OpenForms["main"] != null)
            {
                main mainwin = (main)Application.OpenForms["main"];
                mainwin.formOpen_main_anatanimlar = false;
            }

        }

        private void listele()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT TOP 200 * FROM sermaye";
            SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //sermaye ekle
            if (maskedTextBox1.Text != "" && textBox1.Text != "")
            {
                try
                {
                    int idbull;

                    SqlCommand ekle = new SqlCommand("INSERT INTO sermaye(sermaye_adi, sermaye_miktar) VALUES(@sadi, @smik) SELECT SCOPE_IDENTITY()", baglan);
                    ekle.Parameters.AddWithValue("@sadi", SqlDbType.NVarChar).Value = maskedTextBox1.Text;
                    ekle.Parameters.AddWithValue("@smik", SqlDbType.Float).Value = Convert.ToDouble(textBox1.Text);


                    baglan.Open();
                    idbull = Convert.ToInt32(ekle.ExecuteScalar());
                    baglan.Close();

                    SqlCommand sermayetakip_ekle = new SqlCommand("INSERT INTO sermaye_takip(sermaye_id, tarih, yeni_sermaye, eski_sermaye) VALUES(@id, @trh, @ynsr, @ensr)", baglan);

                    sermayetakip_ekle.Parameters.AddWithValue("@id", SqlDbType.Int).Value = idbull;
                    sermayetakip_ekle.Parameters.AddWithValue("@trh", SqlDbType.Date).Value = DateTime.Now.Date;
                    sermayetakip_ekle.Parameters.AddWithValue("@ynsr", SqlDbType.Float).Value = Convert.ToDouble(textBox1.Text);
                    sermayetakip_ekle.Parameters.AddWithValue("@ensr", SqlDbType.Float).Value = 0;

                    baglan.Open();
                    sermayetakip_ekle.ExecuteNonQuery();
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
            DataTable dt = new DataTable();
            string sql = "SELECT TOP 1 * FROM sermaye";
            SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
            da.Fill(dt);

            anasermayeid = Convert.ToInt32(dt.Rows[0][0]);

            //sermaye sil
            if (id == anasermayeid)
            {
                MessageBox.Show("Ana Sermaye silinemez");
            }
            else
            {
                DialogResult eminmisin = MessageBox.Show("Sermaye silinirse bu sermaye ile ilgili bütün veriler silinir! Devam Edilsin mi?", "UYARI!", MessageBoxButtons.YesNo);
                if (eminmisin == DialogResult.Yes)
                {
                    if (id != -1)
                    {
                        try
                        {
                            //sermaye ile bağıntılı herşeyi sil------------------------

                            //sermaye kayıtlarını sil
                            SqlCommand silsermayekayitlar = new SqlCommand("DELETE FROM sermaye_takip WHERE sermaye_id = @id", baglan);
                            silsermayekayitlar.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                            baglan.Open();
                            silsermayekayitlar.ExecuteNonQuery();
                            baglan.Close();


                            //sermaye sil
                            SqlCommand sil = new SqlCommand("DELETE FROM sermaye WHERE id=@id", baglan);
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
                

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //sermaye güncelle
            if(maskedTextBox1.Text != "" && textBox1.Text != "" && id != -1)
            {
                try
                {
                    int idbull;
                    //sermayeyi güncelle
                    SqlCommand guncelle = new SqlCommand("UPDATE sermaye SET sermaye_adi = @sadi, sermaye_miktar = @smk WHERE id = @id", baglan);
                    guncelle.Parameters.AddWithValue("@sadi", SqlDbType.NVarChar).Value = maskedTextBox1.Text;
                    guncelle.Parameters.AddWithValue("@smk", SqlDbType.Float).Value = textBox1.Text;
                    guncelle.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;

                    baglan.Open();
                    guncelle.ExecuteNonQuery();
                    baglan.Close();

                    idbull = id;

                    //sermaye değişikliğini kaydet
                    SqlCommand sermayetakip_ekle = new SqlCommand("INSERT INTO sermaye_takip(sermaye_id, tarih, yeni_sermaye, eski_sermaye) VALUES(@id, @trh, @ynsr, @ensr)", baglan);

                    sermayetakip_ekle.Parameters.AddWithValue("@id", SqlDbType.Int).Value = idbull;
                    sermayetakip_ekle.Parameters.AddWithValue("@trh", SqlDbType.Date).Value = DateTime.Now.Date;
                    sermayetakip_ekle.Parameters.AddWithValue("@ynsr", SqlDbType.Float).Value = Convert.ToDouble(textBox1.Text);
                    sermayetakip_ekle.Parameters.AddWithValue("@ensr", SqlDbType.Float).Value = sermayee;

                    baglan.Open();
                    sermayetakip_ekle.ExecuteNonQuery();
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
            //sermaye ara
            string sql = "";

            string cmd_start = "SELECT TOP 200";
            string cmd_middle = " *";
            string cmd_end = " FROM sermaye WHERE";
            int cmdend_length = cmd_end.Length;

            if (maskedTextBox1.Text != null && maskedTextBox1.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " sermaye_adi LIKE '%" + maskedTextBox1.Text + "%'";
            }

            if (textBox1.Text != null && textBox1.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " sermaye_miktar < '" + textBox1.Text + "'";
            }


            sql = cmd_start + cmd_middle + cmd_end;

            if (maskedTextBox1.Text != "" || textBox1.Text != "")
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                listele();
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 44 && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 44)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //tiklagetir
            try
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                sermayee = (float)Convert.ToDouble(dataGridView1.CurrentRow.Cells[2].Value);
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

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
