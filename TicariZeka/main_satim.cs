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
    public partial class main_satim : Form
    {
        SqlConnection baglan = new SqlConnection(baglanticlass.baglanticumlesi);

        //musteri
        int musteriid;

        //satim
        int satimid;

        //comboboxlar
        string urungetirsql = "";
        int kategoriid;
        int markaid;
        int urunid;
        string birimi;
        float birimfiyat;

        //satimsepet
        int sepetrowid;

        //sermaye
        int sermayeid;
        float sermayemiktar;

        //satissonlandir
        float odememiktari; //kazanc
        int ticariislemid;

        public main_satim()
        {
            InitializeComponent();
        }

        private void main_satim_Load(object sender, EventArgs e)
        {
            if ((main)Application.OpenForms["main"] != null)
            {
                main mainwin = (main)Application.OpenForms["main"];
                mainwin.formOpen_main_satim = true;
            }

            musterilistele();

            musteriid = -1;
            kategoriid = -1;
            markaid = -1;
            urunid = -1;
            sermayeid = -1;

            //kategorileri getir
            baglan.Open();
            SqlCommand komut1 = new SqlCommand("SELECT * FROM kategori_urun", baglan);
            SqlDataReader oku1 = komut1.ExecuteReader();
            while (oku1.Read())
            {
                comboBox1.Items.Add(oku1["kategori_adi"]);
            }
            baglan.Close();

            //markaları getir
            baglan.Open();
            SqlCommand komut2 = new SqlCommand("SELECT * FROM tedarikci", baglan);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                comboBox2.Items.Add(oku2["tedarikci_unvan"]);
            }
            baglan.Close();

            //sermayeler gelsin
            baglan.Open();
            SqlCommand komut3 = new SqlCommand("SELECT * FROM sermaye", baglan);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                comboBox4.Items.Add(oku3["sermaye_adi"]);
            }
            baglan.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.Text = "";

            if (comboBox1.SelectedIndex != -1)
            {
                //kategori id al
                DataTable dt7 = new DataTable();
                string sql7 = "SELECT id FROM kategori_urun WHERE kategori_adi = N'" + comboBox1.SelectedItem.ToString() + "'";
                SqlDataAdapter da7 = new SqlDataAdapter(sql7, baglan);
                da7.Fill(dt7);

                kategoriid = Convert.ToInt32(dt7.Rows[0][0]);

                urungetirsql = "SELECT * FROM urun WHERE kategori_id = " + kategoriid;

                baglan.Open();
                SqlCommand komut3 = new SqlCommand(urungetirsql, baglan);
                SqlDataReader oku3 = komut3.ExecuteReader();
                while (oku3.Read())
                {
                    comboBox3.Items.Add(oku3["urunadi"]);
                }
                baglan.Close();
            }
            else if(comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                DataTable dt7 = new DataTable();
                string sql7 = "SELECT id FROM kategori_urun WHERE kategori_adi = N'" + comboBox1.SelectedItem.ToString() + "'";
                SqlDataAdapter da7 = new SqlDataAdapter(sql7, baglan);
                da7.Fill(dt7);

                kategoriid = Convert.ToInt32(dt7.Rows[0][0]);

                DataTable dt78 = new DataTable();
                string sql78 = "SELECT id FROM tedarikci WHERE tedarikci_unvan = N'" + comboBox2.SelectedItem.ToString() + "'";
                SqlDataAdapter da78 = new SqlDataAdapter(sql78, baglan);
                da78.Fill(dt78);

                markaid = Convert.ToInt32(dt78.Rows[0][0]);

                urungetirsql = "SELECT * FROM urun WHERE kategori_id = " + kategoriid + " AND tedarikci_marka_id = " + markaid;

                baglan.Open();
                SqlCommand komut3 = new SqlCommand(urungetirsql, baglan);
                SqlDataReader oku3 = komut3.ExecuteReader();
                while (oku3.Read())
                {
                    comboBox3.Items.Add(oku3["urunadi"]);
                }
                baglan.Close();
            }
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            if (comboBox2.SelectedIndex != -1)
            {
                //marka id al
                DataTable dt7 = new DataTable();
                string sql7 = "SELECT id FROM tedarikci WHERE tedarikci_unvan = N'" + comboBox2.SelectedItem.ToString() + "'";
                SqlDataAdapter da7 = new SqlDataAdapter(sql7, baglan);
                da7.Fill(dt7);

                markaid = Convert.ToInt32(dt7.Rows[0][0]);

                urungetirsql = "SELECT * FROM urun WHERE tedarikci_marka_id = " + markaid;

                baglan.Open();
                SqlCommand komut3 = new SqlCommand(urungetirsql, baglan);
                SqlDataReader oku3 = komut3.ExecuteReader();
                while (oku3.Read())
                {
                    comboBox3.Items.Add(oku3["urunadi"]);
                }
                baglan.Close();
            }
            else if (comboBox2.SelectedIndex != -1 && comboBox1.SelectedIndex != -1)
            {
                DataTable dt7 = new DataTable();
                string sql7 = "SELECT id FROM kategori_urun WHERE kategori_adi = N'" + comboBox1.SelectedItem.ToString() + "'";
                SqlDataAdapter da7 = new SqlDataAdapter(sql7, baglan);
                da7.Fill(dt7);

                kategoriid = Convert.ToInt32(dt7.Rows[0][0]);

                DataTable dt78 = new DataTable();
                string sql78 = "SELECT id FROM tedarikci WHERE tedarikci_unvan = N'" + comboBox2.SelectedItem.ToString() + "'";
                SqlDataAdapter da78 = new SqlDataAdapter(sql78, baglan);
                da78.Fill(dt78);

                markaid = Convert.ToInt32(dt78.Rows[0][0]);

                urungetirsql = "SELECT * FROM urun WHERE kategori_id = " + kategoriid + " AND tedarikci_marka_id = " + markaid;

                baglan.Open();
                SqlCommand komut3 = new SqlCommand(urungetirsql, baglan);
                SqlDataReader oku3 = komut3.ExecuteReader();
                while (oku3.Read())
                {
                    comboBox3.Items.Add(oku3["urunadi"]);
                }
                baglan.Close();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox3.SelectedIndex != -1)
            {
                DataTable dt78 = new DataTable();
                string sql78 = "SELECT * FROM urun WHERE urunadi = N'" + comboBox3.SelectedItem.ToString() + "'";
                SqlDataAdapter da78 = new SqlDataAdapter(sql78, baglan);
                da78.Fill(dt78);

                urunid = Convert.ToInt32(dt78.Rows[0][0]);
                birimi = dt78.Rows[0][5].ToString();
                birimfiyat = (float)Convert.ToDouble(dt78.Rows[0][7]);
            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox4.SelectedIndex != -1)
            {
                DataTable dt7 = new DataTable();
                string sql7 = "SELECT * FROM sermaye WHERE sermaye_adi = N'" + comboBox4.SelectedItem.ToString() + "'";
                SqlDataAdapter da7 = new SqlDataAdapter(sql7, baglan);
                da7.Fill(dt7);

                sermayeid = Convert.ToInt32(dt7.Rows[0][0]);

                sermayelabel.Text = "Sermaye Miktarı: " + dt7.Rows[0][2].ToString();
                sermayemiktar = (float)Convert.ToDouble(dt7.Rows[0][2]);
            }

        }



        private void main_satim_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((main)Application.OpenForms["main"] != null)
            {
                main mainwin = (main)Application.OpenForms["main"];
                mainwin.formOpen_main_satim = false;
            }

        }

        //listeler
        private void musterilistele()
        {
            SqlCommand listeleq = new SqlCommand("SELECT * FROM customer", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "customer");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "customer";
        }

        private void satimemirlistele()
        {
            SqlCommand listeleq = new SqlCommand("SELECT * FROM satim_emri WHERE customer_id = " + musteriid, baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "satim_emri");
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "satim_emri";
        }

        private void listele2()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT TOP 200 satim_emri_sepet.id AS id, satim_emri_sepet.satim_emri_id AS emir_id, satim_emri_sepet.urun_id AS urun_id, urun.urunadi AS urun_adi, satim_emri_sepet.satim_miktar AS satim_miktar, satim_emri_sepet.birimi AS birimi, satim_emri_sepet.birim_fiyat AS birim_fiyat, satim_emri_sepet.toplam_tutar AS toplam_kazanc FROM satim_emri_sepet JOIN urun ON urun.id = satim_emri_sepet.urun_id WHERE satim_emri_sepet.satim_emri_id = " + satimid.ToString();
            SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
            da.Fill(dt);
            dataGridView3.DataSource = dt;
        }
        //

        //tiklagetirler
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //musteri

            try
            {
                musteriid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                maskedTextBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                maskedTextBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                maskedTextBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                maskedTextBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                satimemirlistele();
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                musteriid = -1;
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            //satim emir
            try
            {
                satimid = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                listele2();
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                satimid = -1;
            }
        }

        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {
            //sepetrow
            try
            {
                sepetrowid = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                sepetrowid = -1;
            }
        }
        //


        //
        //
        //MUŞTERI SEÇ
        //
        //

        private void button4_Click(object sender, EventArgs e)
        {
            //müşteri ara
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
                musterilistele();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //müşteri hepsini listele
            musterilistele();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //musteri temizle
            musteriid = -1;
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";
            maskedTextBox5.Text = "";
        }



        //
        //MÜŞTERİ SEÇILDI = musteriid
        //SATIŞ EMRI OLUŞTUR
        //SATIŞ EMRI SEÇ
        //

        private void button1_Click(object sender, EventArgs e)
        {
            //satim emri aç
            if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true && musteriid != -1)
            {
                //try
                //{
                    SqlCommand ekle = new SqlCommand("INSERT INTO satim_emri(customer_id, tarih, bitistarih)" +
                        "VALUES(@cid, @dt, @dtt)", baglan);
                    ekle.Parameters.AddWithValue("@cid", SqlDbType.Int).Value = musteriid;
                    ekle.Parameters.AddWithValue("@dt", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                    ekle.Parameters.AddWithValue("@dtt", SqlDbType.Date).Value = dateTimePicker2.Value.Date;

                    baglan.Open();
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    satimemirlistele();
                //}
                //catch
                //{
                  //  MessageBox.Show("Şu an işlem gerçekleşemiyor, lütfen tekrar deneyiniz.");
                //}
            }
            else
            {
                MessageBox.Show("Lütfen bütün bilgileri giriniz.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //satim emri ara
            if (dateTimePicker1.Value.Date == dateTimePicker2.Value.Date)
            {
                satimemirlistele();
            }
            else if (dateTimePicker1.Value.Date != dateTimePicker2.Value.Date)
            {
                SqlCommand listeleq = new SqlCommand("SELECT * FROM satim_emri WHERE satim_emri.tarih BETWEEN @tarih AND @bitistarih", baglan);
                listeleq.Parameters.AddWithValue("@tarih", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                listeleq.Parameters.AddWithValue("@bitistarih", SqlDbType.Date).Value = dateTimePicker2.Value.Date;

                DataSet ds23 = new DataSet();
                SqlDataAdapter da23 = new SqlDataAdapter(listeleq);
                da23.Fill(ds23, "satim_emri");
                dataGridView2.DataSource = ds23;
                dataGridView2.DataMember = "satim_emri";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //satim emri listele
            if (satimid != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM satim_emri WHERE id=@id", baglan);
                    sil.Parameters.AddWithValue("@id", SqlDbType.Int).Value = satimid;
                    baglan.Open();
                    sil.ExecuteNonQuery();
                    baglan.Close();
                    satimemirlistele();
                    satimid = -1;
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

        //SATIS EMRI SEPETI
        //MÜŞTERİ SEÇILDI = musteriid
        //SATIŞ EMRI SEÇILDI = satimid
        //URUN SEÇ
        //SEPETE KOY

        private void button9_Click(object sender, EventArgs e)
        {
            //sepete urun ekle
            if (satimid != -1 && maskedTextBox6.Text != "" && urunid != -1)
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO satim_emri_sepet(satim_emri_id, urun_id, satim_miktar, birimi, birim_fiyat, toplam_tutar)" +
                        "VALUES(@alimid, @uid, @almiktar, @birimi, @birimfiyat, @sumtutar)", baglan);
                    ekle.Parameters.AddWithValue("@alimid", SqlDbType.Int).Value = satimid;
                    ekle.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = urunid;
                    ekle.Parameters.AddWithValue("@almiktar", SqlDbType.Int).Value = Convert.ToInt32(maskedTextBox6.Text);
                    ekle.Parameters.AddWithValue("@birimi", SqlDbType.NVarChar).Value = birimi;
                    ekle.Parameters.AddWithValue("@birimfiyat", SqlDbType.Float).Value = birimfiyat;
                    ekle.Parameters.AddWithValue("@sumtutar", SqlDbType.Float).Value = (float)(Convert.ToInt32(maskedTextBox6.Text) * birimfiyat);

                    baglan.Open();
                    ekle.ExecuteNonQuery();
                    baglan.Close();
                    listele2();

                    urunid = -1;
                }
                catch
                {
                    MessageBox.Show("Şu an işlem gerçekleşemiyor, lütfen tekrar deneyiniz.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen ürünü seçtiğinizden ve ürün miktarını girdiğinizden emin olunuz.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //sepetten urun kaldır
            if (sepetrowid != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM satim_emri_sepet WHERE id=@id", baglan);
                    sil.Parameters.AddWithValue("@id", SqlDbType.Int).Value = sepetrowid;
                    baglan.Open();
                    sil.ExecuteNonQuery();
                    baglan.Close();
                    listele2();
                    sepetrowid = -1;
                }
                catch
                {
                    MessageBox.Show("Şu an işlem gerçekleşemiyor, lütfen tekrar deneyiniz.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen tablodaki silmek istediğiniz satın alma detayına çift tıklatıp seçili hale getiriniz.");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //comboboxlari ve yaziyi temizle
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.Items.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            maskedTextBox6.Text = "";

        }





        //SATISI SONUCLANDIR
        //MÜŞTERİ SEÇILDI = musteriid
        //SATIŞ EMRI SEÇILDI = satimid
        //URUNLER KONULDU HESAPLANACAK = EGER URUN MIKTARI STOKTA YETERSIZSE SATILAMAZ.
        //SIPARISI SONUCLANDIR

        private void button10_Click(object sender, EventArgs e)
        {
            //toplamtutarı getir.
            if (satimid != -1)
            {
                DataTable dt = new DataTable();
                string sql = "SELECT SUM(satim_emri_sepet.toplam_tutar) FROM satim_emri_sepet WHERE satim_emri_sepet.satim_emri_id = " + satimid.ToString();
                SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                da.Fill(dt);

                odenecektoplam.Text = dt.Rows[0][0].ToString();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (satimid != -1 && sermayeid != -1)
            {
                DataTable dt = new DataTable();
                string sql = "SELECT SUM(satim_emri_sepet.toplam_tutar) FROM satim_emri_sepet WHERE satim_emri_sepet.satim_emri_id = " + satimid.ToString();
                SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                da.Fill(dt);

                odememiktari = (float)Convert.ToDouble(dt.Rows[0][0]);

                float yenisermaye = sermayemiktar + odememiktari;
                
                //stok kontrolü-------------------------------------------------------------------------
                bool stokdenetimigectimi = false;

                DataTable urunstoklaridenetim_dt = new DataTable();
                string stokdenetimsql = "";




                ////////////
                DataTable satimdenetimurunstoklari_dt = new DataTable();
                string stokdenetimsql2 = "SELECT * FROM satim_emri_sepet WHERE satim_emri_id = " + satimid;
                SqlDataAdapter stokdenetimda2 = new SqlDataAdapter(stokdenetimsql2, baglan);
                stokdenetimda2.Fill(satimdenetimurunstoklari_dt);

                foreach (DataRow roww in satimdenetimurunstoklari_dt.Rows)
                {
                    int urunnidd = Convert.ToInt32(roww["urun_id"]);

                    stokdenetimsql2 = "SELECT * FROM stok_urun WHERE urun_id = " + urunnidd;
                    SqlDataAdapter stokdaaaa = new SqlDataAdapter(stokdenetimsql2, baglan);
                    stokdaaaa.Fill(urunstoklaridenetim_dt);

                    int stoktamiktarr = Convert.ToInt32(urunstoklaridenetim_dt.Rows[0][2]);
                    urunstoklaridenetim_dt.Clear();

                    int satilanmiktar = Convert.ToInt32(roww["satim_miktar"]);

                    if(stoktamiktarr >= satilanmiktar)
                    {
                        stokdenetimigectimi = true;
                    }
                    else
                    {
                        stokdenetimigectimi = false;
                        break;
                    }
                }

                //-------------------------------------------------------------------------

                if (stokdenetimigectimi)
                {
                    //sermayeyi güncelle
                    try
                    {
                        int idbull;
                        //sermayeyi güncelle
                        SqlCommand guncelle = new SqlCommand("UPDATE sermaye SET sermaye_miktar = @smk WHERE id = @id", baglan); ;
                        guncelle.Parameters.AddWithValue("@smk", SqlDbType.Float).Value = yenisermaye;
                        guncelle.Parameters.AddWithValue("@id", SqlDbType.Int).Value = sermayeid;

                        baglan.Open();
                        guncelle.ExecuteNonQuery();
                        baglan.Close();

                        idbull = sermayeid;

                        //sermaye değişikliğini kaydet
                        SqlCommand sermayetakip_ekle = new SqlCommand("INSERT INTO sermaye_takip(sermaye_id, tarih, yeni_sermaye, eski_sermaye) VALUES(@id, @trh, @ynsr, @ensr)", baglan);

                        sermayetakip_ekle.Parameters.AddWithValue("@id", SqlDbType.Int).Value = idbull;
                        sermayetakip_ekle.Parameters.AddWithValue("@trh", SqlDbType.Date).Value = DateTime.Now.Date;
                        sermayetakip_ekle.Parameters.AddWithValue("@ynsr", SqlDbType.Float).Value = yenisermaye;
                        sermayetakip_ekle.Parameters.AddWithValue("@ensr", SqlDbType.Float).Value = sermayemiktar;

                        baglan.Open();
                        sermayetakip_ekle.ExecuteNonQuery();
                        baglan.Close();

                        //ticari işlemler kaydını gir
                        SqlCommand ticariislemtakip_ekle = new SqlCommand("INSERT INTO ticari_islemler(sermaye_id, islem_turu, islem_yapilan_miktar, islem_tarihi) VALUES(@sid, @istur, @ismiktar, @istarih) SELECT SCOPE_IDENTITY()", baglan);
                        ticariislemtakip_ekle.Parameters.AddWithValue("@sid", SqlDbType.Int).Value = idbull;
                        ticariislemtakip_ekle.Parameters.AddWithValue("@istur", SqlDbType.VarChar).Value = "SATIM";
                        ticariislemtakip_ekle.Parameters.AddWithValue("@ismiktar", SqlDbType.Float).Value = odememiktari;
                        ticariislemtakip_ekle.Parameters.AddWithValue("@istarih", SqlDbType.Date).Value = DateTime.Now.Date;
                        baglan.Open();
                        ticariislemid = Convert.ToInt32(ticariislemtakip_ekle.ExecuteScalar());
                        baglan.Close();

                    }
                    catch
                    {
                        MessageBox.Show("Şu an işlem gerçekleşemiyor, lütfen tekrar deneyiniz.");
                    }

                    //stoğu güncelle
                    try
                    {
                        //siparişteki her bir ürün için stoğu güncelle
                        DataTable urunstoklari_dt = new DataTable();
                        string stoksql = "";

                        DataTable urunbilgi_dt = new DataTable();
                        string urunbilgisql = "";




                        ////////////
                        DataTable alimurunstoklari_dt = new DataTable();
                        string stoksql2 = "SELECT * FROM satim_emri_sepet WHERE satim_emri_id = " + satimid;
                        SqlDataAdapter stokda2 = new SqlDataAdapter(stoksql2, baglan);
                        stokda2.Fill(alimurunstoklari_dt);

                        foreach (DataRow row in alimurunstoklari_dt.Rows)
                        {
                            int urunnidd = Convert.ToInt32(row["urun_id"]);

                            stoksql = "SELECT * FROM stok_urun WHERE urun_id = " + urunnidd;
                            SqlDataAdapter stokda = new SqlDataAdapter(stoksql, baglan);
                            stokda.Fill(urunstoklari_dt);

                            int stoktamiktarr = Convert.ToInt32(urunstoklari_dt.Rows[0][2]);
                            urunstoklari_dt.Clear();

                            int alinanmiktar = Convert.ToInt32(row["satim_miktar"]);

                            int yenimiktar = stoktamiktarr - alinanmiktar;

                            //urun birimfiyatı lazım!!
                            urunbilgisql = "SELECT satis_fiyati FROM urun WHERE id = " + urunnidd;
                            SqlDataAdapter stokda333 = new SqlDataAdapter(urunbilgisql, baglan);
                            stokda333.Fill(urunbilgi_dt);
                            int birimfiat = Convert.ToInt32(urunbilgi_dt.Rows[0][0]);
                            urunbilgi_dt.Clear();

                            SqlCommand stokguncel = new SqlCommand("UPDATE stok_urun SET miktar = @mr WHERE urun_id = @id", baglan);
                            stokguncel.Parameters.AddWithValue("@mr", SqlDbType.Int).Value = yenimiktar;
                            stokguncel.Parameters.AddWithValue("@id", SqlDbType.Int).Value = urunnidd;
                            baglan.Open();
                            stokguncel.ExecuteNonQuery();
                            baglan.Close();

                            //urun satim takibi
                            SqlCommand takipurun = new SqlCommand("INSERT INTO takip_urunsatis(urun_id, ticari_islem_id, tarih, miktar, toplam_kazanc) VALUES(@uid, @tcid, @tarih, @amo, @topsum)", baglan);
                            takipurun.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = urunnidd;
                            takipurun.Parameters.AddWithValue("@tcid", SqlDbType.Int).Value = ticariislemid;
                            takipurun.Parameters.AddWithValue("@tarih", SqlDbType.Date).Value = DateTime.Now.Date;
                            takipurun.Parameters.AddWithValue("@amo", SqlDbType.Int).Value = alinanmiktar;
                            takipurun.Parameters.AddWithValue("@topsum", SqlDbType.Float).Value = alinanmiktar * birimfiat;

                            baglan.Open();
                            takipurun.ExecuteNonQuery();
                            baglan.Close();
                        }

                        MessageBox.Show("İşlem Başarıyla Gerçekleşti!");
                    }
                    catch
                    {
                        MessageBox.Show("Şu an işlem gerçekleşemiyor, lütfen tekrar deneyiniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Stok yetersiz!");
                }


            }
            else
            {
                MessageBox.Show("Lütfen işlem yapılacak sermayeyi ve satın alma emrini seçiniz.");
            }
        }
    }
}
