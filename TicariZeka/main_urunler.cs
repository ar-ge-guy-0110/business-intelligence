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
    public partial class main_urunler : Form
    {
        SqlConnection baglan = new SqlConnection(baglanticlass.baglanticumlesi);
        int id;
        int katid;
        int marid;

        public string urunadi { get; set; }
        public int idd { get; set; }

        public bool stockupdated = false;
        public main_urunler()
        {
            InitializeComponent();
        }

        private void ürünKategorileriToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form main_urunler_kategoriler = new main_urunler_kategoriler();
            main_urunler_kategoriler.ShowDialog();


        }

        private void main_urunler_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((main)Application.OpenForms["main"] != null)
            {
                main mainwin = (main)Application.OpenForms["main"];
                mainwin.formOpen_main_urunler = false;
            }

        }

        private void main_urunler_Load(object sender, EventArgs e)
        {
            if ((main)Application.OpenForms["main"] != null)
            {
                main mainwin = (main)Application.OpenForms["main"];
                mainwin.formOpen_main_urunler = true;
            }


            id = -1;
            katid = -1;
            marid = -1;

            listele();

            //kategoriler gelsin
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM kategori_urun", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["kategori_adi"]);
            }
            baglan.Close();

            //markalar gelsin
            baglan.Open();
            SqlCommand komut2 = new SqlCommand("SELECT * FROM tedarikci", baglan);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                comboBox2.Items.Add(oku2["tedarikci_unvan"]);
            }
            baglan.Close();

        }

        private void listele()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT TOP 200 urun.id AS urun_id, stok_urun.id AS stok_id, urun.urunkodu, urun.urunadi, kategori_urun.kategori_adi AS urun_grubu, tedarikci.tedarikci_unvan AS tedarikci_marka, urun.alis_fiyati, urun.satis_fiyati,stok_urun.miktar AS stok_miktarı, stok_urun.birimi FROM urun JOIN stok_urun ON stok_urun.urun_id = urun.id JOIN kategori_urun ON kategori_urun.id = urun.kategori_id JOIN tedarikci ON tedarikci.id = urun.tedarikci_marka_id";
            SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex != -1)
            {
                //marka id al
                //marka id bul
                DataTable dt7 = new DataTable();
                string sql7 = "SELECT id FROM tedarikci WHERE tedarikci_unvan = N'" + comboBox2.SelectedItem.ToString() + "'";
                SqlDataAdapter da7 = new SqlDataAdapter(sql7, baglan);
                da7.Fill(dt7);

                marid = Convert.ToInt32(dt7.Rows[0][0]);
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != -1)
            {
                //kategori id al
                //kategori id bul
                DataTable dt4 = new DataTable();
                string sql4 = "SELECT id FROM kategori_urun WHERE kategori_adi = N'" + comboBox1.SelectedItem.ToString() + "'";
                SqlDataAdapter da4 = new SqlDataAdapter(sql4, baglan);
                da4.Fill(dt4);

                katid = Convert.ToInt32(dt4.Rows[0][0]);
            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //tiklagetir
            try
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                maskedTextBox3.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                urunadi = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                idd = id;
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                id = -1;
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            //EKLE
            if(comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && textBox1.Text != "" && textBox2.Text != "")
            {
                try
                {
                    int idbull;
                    //eklemeye devam ticari
                    SqlCommand ekle = new SqlCommand("INSERT INTO urun(kategori_id, tedarikci_marka_id, urunkodu, urunadi, urunbirimi, alis_fiyati, satis_fiyati) VALUES(@kid, @tid, @ukod, @uad, @ubirim, @ualis, @usatis) SELECT SCOPE_IDENTITY()", baglan);
                    ekle.Parameters.AddWithValue("@kid", SqlDbType.Int).Value = katid;
                    ekle.Parameters.AddWithValue("@tid", SqlDbType.Int).Value = marid;
                    ekle.Parameters.AddWithValue("@ukod", SqlDbType.NVarChar).Value = maskedTextBox1.Text;
                    ekle.Parameters.AddWithValue("@uad", SqlDbType.NVarChar).Value = maskedTextBox2.Text;
                    ekle.Parameters.AddWithValue("@ubirim", SqlDbType.NVarChar).Value = maskedTextBox3.Text;
                    ekle.Parameters.AddWithValue("@ualis", SqlDbType.Float).Value = Convert.ToDouble(textBox1.Text);
                    ekle.Parameters.AddWithValue("@usatis", SqlDbType.Float).Value = Convert.ToDouble(textBox2.Text);
                    baglan.Open();
                    idbull = Convert.ToInt32(ekle.ExecuteScalar());
                    baglan.Close();

                    //ürünün stok tanımını yap.
                    SqlCommand stokekle = new SqlCommand("INSERT INTO stok_urun(urun_id, miktar, birimi) VALUES(@uid, @mik, @br)", baglan);
                    stokekle.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = idbull;
                    stokekle.Parameters.AddWithValue("@mik", SqlDbType.Int).Value = 0;
                    stokekle.Parameters.AddWithValue("@br", SqlDbType.NVarChar).Value = maskedTextBox3.Text;
                    baglan.Open();
                    stokekle.ExecuteNonQuery();
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
            if (id != -1)
            {
                DialogResult eminmisin = MessageBox.Show("Ürün silinirse bu ürün ile ilgili bütün veriler silinir! Devam Edilsin mi?", "UYARI!", MessageBoxButtons.YesNo);
                if (eminmisin == DialogResult.Yes)
                {
                    try
                    {
                        //baglı olan stogu sil
                        SqlCommand stogusil = new SqlCommand("DELETE FROM stok_urun WHERE urun_id = @id", baglan);
                        stogusil.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;


                        //ürünü sil
                        SqlCommand sil = new SqlCommand("DELETE FROM urun WHERE id=@id", baglan);
                        sil.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                        baglan.Open();
                        stogusil.ExecuteNonQuery();
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
            if ( id != -1 && comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && maskedTextBox1.Text != "" && maskedTextBox2.Text != "" && maskedTextBox3.Text != "" && textBox1.Text != "" && textBox2.Text != "")
            {
                try
                {
                    int idbull;
                    idbull = id;
                    
                    SqlCommand guncelle = new SqlCommand("UPDATE urun SET kategori_id = @kid, tedarikci_marka_id = @tid, urunkodu = @ukod, urunadi = @uad, urunbirimi = @ubirim, alis_fiyati = @ualis, satis_fiyati = @usatis WHERE id = @id", baglan);
                    guncelle.Parameters.AddWithValue("@kid", SqlDbType.Int).Value = katid;
                    guncelle.Parameters.AddWithValue("@tid", SqlDbType.Int).Value = marid;
                    guncelle.Parameters.AddWithValue("@ukod", SqlDbType.NVarChar).Value = maskedTextBox1.Text;
                    guncelle.Parameters.AddWithValue("@uad", SqlDbType.NVarChar).Value = maskedTextBox2.Text;
                    guncelle.Parameters.AddWithValue("@ubirim", SqlDbType.NVarChar).Value = maskedTextBox3.Text;
                    guncelle.Parameters.AddWithValue("@ualis", SqlDbType.Float).Value = Convert.ToDouble(textBox1.Text);
                    guncelle.Parameters.AddWithValue("@usatis", SqlDbType.Float).Value = Convert.ToDouble(textBox2.Text);
                    guncelle.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
                    baglan.Open();
                    guncelle.ExecuteNonQuery();
                    baglan.Close();

                    //ürünün stok tanımını da guncelle.
                    SqlCommand stokguncel = new SqlCommand("UPDATE stok_urun SET birimi = @br WHERE urun_id = @id", baglan);
                    stokguncel.Parameters.AddWithValue("@id", SqlDbType.Int).Value = idbull;
                    stokguncel.Parameters.AddWithValue("@br", SqlDbType.NVarChar).Value = maskedTextBox3.Text;
                    baglan.Open();
                    stokguncel.ExecuteNonQuery();
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

        private void button4_Click(object sender, EventArgs e)
        {
            //ARA
            string sql2 = "";

            string cmd_start = "SELECT TOP 200";
            string cmd_middle = " urun.id AS urun_id, stok_urun.id AS stok_id, urun.urunkodu, urun.urunadi, kategori_urun.kategori_adi AS urun_grubu, tedarikci.tedarikci_unvan AS tedarikci_marka, urun.alis_fiyati, urun.satis_fiyati,stok_urun.miktar AS stok_miktarı, stok_urun.birimi";
            string cmd_end = " FROM urun JOIN stok_urun ON stok_urun.urun_id = urun.id JOIN kategori_urun ON kategori_urun.id = urun.kategori_id JOIN tedarikci ON tedarikci.id = urun.tedarikci_marka_id WHERE";
            int cmdend_length = cmd_end.Length;

            if (comboBox1.SelectedIndex != -1)
            {

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " urun.kategori_id LIKE '%" + katid + "%'";
            }

            if (comboBox2.SelectedIndex != -1)
            {

                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " urun.tedarikci_marka_id LIKE '%" + marid + "%'";
            }

            if (maskedTextBox1.Text != null && maskedTextBox1.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " urun.urunkodu LIKE N'%" + maskedTextBox1.Text + "%'";
            }

            if (maskedTextBox2.Text != null && maskedTextBox2.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " urun.urunadi LIKE N'%" + maskedTextBox2.Text + "%'";
            }

            if (maskedTextBox3.Text != null && maskedTextBox3.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " urun.urunbirimi LIKE N'%" + maskedTextBox3.Text + "%'";
            }

            if (textBox1.Text != null && textBox1.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " urun.alis_fiyati < " + Convert.ToDouble(textBox1.Text).ToString();
            }

            if (textBox2.Text != null && textBox2.Text != "")
            {
                if (cmd_end.Length > cmdend_length)
                {
                    cmd_end += " AND";
                }
                cmd_end += " urun.satis_fiyati < " + Convert.ToDouble(textBox2.Text).ToString();
            }


            sql2 = cmd_start + cmd_middle + cmd_end;

            if (comboBox1.SelectedIndex != -1 || comboBox2.SelectedIndex != -1 || maskedTextBox1.Text != "" || maskedTextBox2.Text != "" || maskedTextBox3.Text != "" || textBox1.Text != "" || textBox2.Text != "")
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
            //HEPSİNİ LİSTELE
            listele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //TEMİZLE
            id = -1;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox1.Text = "";
            comboBox2.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(id != -1)
            {
                Form main_urunler_stokdegistir = new main_urunler_stokdegistir();
                main_urunler_stokdegistir.ShowDialog();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
