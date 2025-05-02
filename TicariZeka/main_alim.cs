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
    public partial class main_alim : Form
    {
        SqlConnection baglan = new SqlConnection(baglanticlass.baglanticumlesi);
        int marid;
        int alimid;
        
        int secilenmarid;

        //sepet
        int urunid;
        int alim_miktar;
        string birimi;
        float birim_fiyat;
        float toplam_tutar;
        int sepetrowid;

        //bakiye
        float sermayemiktar;
        int sermayeid;
        float odememiktari;

        public main_alim()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //alma emri aç
            if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true && comboBox1.SelectedIndex != -1)
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO alim_emri(tedarikci_id, tarih, bitistarih)" +
                        "VALUES(@tid, @dt, @dtt)", baglan);
                    ekle.Parameters.AddWithValue("@tid", SqlDbType.Int).Value = marid;
                    ekle.Parameters.AddWithValue("@dt", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                    ekle.Parameters.AddWithValue("@dtt", SqlDbType.Date).Value = dateTimePicker2.Value.Date;

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
                MessageBox.Show("Lütfen bütün bilgileri giriniz.");
            }
        }

        private void listele()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT TOP 200 alim_emri.id AS alim_id, tedarikci.id AS tedarikci_id, tedarikci.tedarikci_unvan AS tedarikci, alim_emri.tarih AS tarih, alim_emri.bitistarih AS bitis_tarihi FROM alim_emri JOIN tedarikci ON tedarikci.id = alim_emri.tedarikci_id";
            SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void listele2()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT TOP 200 alim_emri_sepet.id AS id, alim_emri_sepet.alim_emri_id AS emir_id, alim_emri_sepet.urun_id AS urun_id, urun.urunadi AS urun_adi, alim_emri_sepet.alim_miktar AS alım_miktar, alim_emri_sepet.birimi AS birimi, alim_emri_sepet.birim_fiyat AS birim_fiyat, alim_emri_sepet.toplam_tutar AS toplam_tutar FROM alim_emri_sepet JOIN urun ON urun.id = alim_emri_sepet.urun_id WHERE alim_emri_sepet.alim_emri_id = " + alimid.ToString();
            SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }


        private void main_alim_Load(object sender, EventArgs e)
        {
            listele();
            if ((main)Application.OpenForms["main"] != null)
            {
                main mainwin = (main)Application.OpenForms["main"];
                mainwin.formOpen_main_alim = true;
            }


            marid = -1;
            alimid = -1;
            urunid = -1;
            sepetrowid = -1;
            sermayeid = -1;
            //markalar gelsin
            baglan.Open();
            SqlCommand komut2 = new SqlCommand("SELECT * FROM tedarikci", baglan);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                comboBox1.Items.Add(oku2["tedarikci_unvan"]);
            }
            baglan.Close();

            //sermayeler gelsin
            baglan.Open();
            SqlCommand komut3 = new SqlCommand("SELECT * FROM sermaye", baglan);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                comboBox3.Items.Add(oku3["sermaye_adi"]);
            }
            baglan.Close();

        }

        private void main_alim_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((main)Application.OpenForms["main"] != null)
            {
                main mainwin = (main)Application.OpenForms["main"];
                mainwin.formOpen_main_alim = false;
            }

        }


        //ALIM EMRINI SEÇ
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //tiklagetir
            try
            {
                comboBox2.Items.Clear();
                comboBox2.Text = "";

                alimid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                secilenmarid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());

                //sepet urunlerini doldur.
                baglan.Open();
                SqlCommand komut3 = new SqlCommand("SELECT * FROM urun WHERE tedarikci_marka_id = @tid", baglan);
                komut3.Parameters.AddWithValue("@tid", SqlDbType.Int).Value = secilenmarid;
                SqlDataReader oku3 = komut3.ExecuteReader();
                while (oku3.Read())
                {
                    comboBox2.Items.Add(oku3["urunadi"]);
                }
                baglan.Close();

                //sepet gridvievini goster
                listele2();
            }
            catch
            {
                MessageBox.Show("Lütfen doğru kolonu seçiniz.");
                alimid = -1;
            }

        }


        //EMRIN SEPETINDEN SEÇ
        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                sepetrowid = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
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
        //  ALIM EMRI AÇ
        //
        //
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //marka id al
            if(comboBox1.SelectedIndex != -1)
            {
                //marka id al
                //marka id bul
                DataTable dt7 = new DataTable();
                string sql7 = "SELECT id FROM tedarikci WHERE tedarikci_unvan = N'" + comboBox1.SelectedItem.ToString() + "'";
                SqlDataAdapter da7 = new SqlDataAdapter(sql7, baglan);
                da7.Fill(dt7);

                marid = Convert.ToInt32(dt7.Rows[0][0]);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            //emir ara
            if (dateTimePicker1.Value.Date == dateTimePicker2.Value.Date && comboBox1.SelectedIndex == -1)
            {
                listele();
            }
            else if(dateTimePicker1.Value.Date == dateTimePicker2.Value.Date && comboBox1.SelectedIndex != -1)
            {

                DataTable dt2 = new DataTable();
                string sql2 = "SELECT TOP 200 alim_emri.id AS alim_id, tedarikci.id AS tedarikci_id, tedarikci.tedarikci_unvan AS tedarikci, alim_emri.tarih AS tarih, alim_emri.bitistarih AS bitis_tarihi FROM alim_emri JOIN tedarikci ON tedarikci.id = alim_emri.tedarikci_id WHERE tedarikci.id = " + marid.ToString();
                SqlDataAdapter da2 = new SqlDataAdapter(sql2, baglan);
                da2.Fill(dt2);
                dataGridView1.DataSource = dt2;





            }
            else if(dateTimePicker1.Value.Date != dateTimePicker2.Value.Date && comboBox1.SelectedIndex == -1)
            {
                SqlCommand listeleq = new SqlCommand("SELECT TOP 200 alim_emri.id AS alim_id, tedarikci.id AS tedarikci_id, tedarikci.tedarikci_unvan AS tedarikci, alim_emri.tarih AS tarih, alim_emri.bitistarih AS bitis_tarihi FROM alim_emri JOIN tedarikci ON tedarikci.id = alim_emri.tedarikci_id WHERE alim_emri.tarih BETWEEN @tarih AND @bitistarih", baglan);
                listeleq.Parameters.AddWithValue("@tarih", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                listeleq.Parameters.AddWithValue("@bitistarih", SqlDbType.Date).Value = dateTimePicker2.Value.Date;

                DataSet ds23 = new DataSet();
                SqlDataAdapter da23 = new SqlDataAdapter(listeleq);
                da23.Fill(ds23, "alim_emri");
                dataGridView1.DataSource = ds23;
                dataGridView1.DataMember = "alim_emri";
            }
            else if(dateTimePicker1.Value.Date != dateTimePicker2.Value.Date && comboBox1.SelectedIndex != -1)
            {
                SqlCommand listeleq = new SqlCommand("SELECT TOP 200 alim_emri.id AS alim_id, tedarikci.id AS tedarikci_id, tedarikci.tedarikci_unvan AS tedarikci, alim_emri.tarih AS tarih, alim_emri.bitistarih AS bitis_tarihi FROM alim_emri JOIN tedarikci ON tedarikci.id = alim_emri.tedarikci_id WHERE tedarikci_id=@tid AND alim_emri.tarih BETWEEN @tarih AND @bitistarih", baglan);
                listeleq.Parameters.AddWithValue("@tid", SqlDbType.Int).Value = marid;
                listeleq.Parameters.AddWithValue("@tarih", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                listeleq.Parameters.AddWithValue("@bitistarih", SqlDbType.Date).Value = dateTimePicker2.Value.Date;

                DataSet ds24 = new DataSet();
                SqlDataAdapter da24 = new SqlDataAdapter(listeleq);
                da24.Fill(ds24, "alim_emri");
                dataGridView1.DataSource = ds24;
                dataGridView1.DataMember = "alim_emri";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (alimid != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM alim_emri WHERE id=@id", baglan);
                    sil.Parameters.AddWithValue("@id", SqlDbType.Int).Value = alimid;
                    baglan.Open();
                    sil.ExecuteNonQuery();
                    baglan.Close();
                    listele();
                    alimid = -1;
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



        //
        //
        // DINAMIK OLARAK ALIM EMRINE GORE EMRIN SEPETINI GETIR
        //
        //

        private void button4_Click(object sender, EventArgs e)
        {
            //sepete alim ekle
            if (alimid != -1 && maskedTextBox1.Text != "" && urunid != -1)
            {
                try
                {
                    SqlCommand ekle = new SqlCommand("INSERT INTO alim_emri_sepet(alim_emri_id, urun_id, alim_miktar, birimi, birim_fiyat, toplam_tutar)" +
                        "VALUES(@alimid, @uid, @almiktar, @birimi, @birimfiyat, @sumtutar)", baglan);
                    ekle.Parameters.AddWithValue("@alimid", SqlDbType.Int).Value = alimid;
                    ekle.Parameters.AddWithValue("@uid", SqlDbType.Int).Value = urunid;
                    ekle.Parameters.AddWithValue("@almiktar", SqlDbType.Int).Value = Convert.ToInt32(maskedTextBox1.Text);
                    ekle.Parameters.AddWithValue("@birimi", SqlDbType.NVarChar).Value = birimi;
                    ekle.Parameters.AddWithValue("@birimfiyat", SqlDbType.Float).Value = birim_fiyat;
                    ekle.Parameters.AddWithValue("@sumtutar", SqlDbType.Float).Value = (float)(Convert.ToInt32(maskedTextBox1.Text) * birim_fiyat);

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

        private void button5_Click(object sender, EventArgs e)
        {
            //sepetten alim sil
            if (sepetrowid != -1)
            {
                try
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM alim_emri_sepet WHERE id=@id", baglan);
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //urun bilgilerini al
            if (comboBox2.SelectedIndex != -1 && alimid != -1)
            {

                DataTable dt7 = new DataTable();
                string sql7 = "SELECT * FROM urun WHERE urunadi = N'" + comboBox2.SelectedItem.ToString() + "'";
                SqlDataAdapter da7 = new SqlDataAdapter(sql7, baglan);
                da7.Fill(dt7);

                urunid = Convert.ToInt32(dt7.Rows[0][0]);
                birimi = dt7.Rows[0][5].ToString();
                birim_fiyat = (float)Convert.ToDouble(dt7.Rows[0][6]);
            }

        }



        //
        //
        // ALIM EMRINI SONLANDIRMAK ICIN SEPETINI INCELE TOPLAM TUTARI OGREN VE SECILEN BAKIYEYLE KARŞILAŞTIR. BAKIYE YETERLIYSE ISLEM GERCEKLEŞTIR YETERLI
        // DEGILSE SERMAYE YETERSIZ DE
        //

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt7 = new DataTable();
            string sql7 = "SELECT * FROM sermaye WHERE sermaye_adi = N'" + comboBox3.SelectedItem.ToString() + "'";
            SqlDataAdapter da7 = new SqlDataAdapter(sql7, baglan);
            da7.Fill(dt7);

            sermayeid = Convert.ToInt32(dt7.Rows[0][0]);

            sermayelabel.Text = "Sermaye Miktarı: " + dt7.Rows[0][2].ToString();
            sermayemiktar = (float)Convert.ToDouble(dt7.Rows[0][2]);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //toplamtutarı getir.
            if(alimid != -1)
            {
                DataTable dt = new DataTable();
                string sql = "SELECT SUM(alim_emri_sepet.toplam_tutar) FROM alim_emri_sepet WHERE alim_emri_sepet.alim_emri_id = " + alimid.ToString();
                SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                da.Fill(dt);

                odenecektoplam.Text = dt.Rows[0][0].ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //SATIN AL
            if (alimid != -1 && sermayeid != -1)
            {
                DataTable dt = new DataTable();
                string sql = "SELECT SUM(alim_emri_sepet.toplam_tutar) FROM alim_emri_sepet WHERE alim_emri_sepet.alim_emri_id = " + alimid.ToString();
                SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                da.Fill(dt);

                odememiktari = (float)Convert.ToDouble(dt.Rows[0][0]);

                if(odememiktari > sermayemiktar)
                {
                    MessageBox.Show("Sermaye yetersiz.");
                }
                else if(odememiktari < sermayemiktar)
                {
                    float yenisermaye = sermayemiktar - odememiktari;

                    //sermayeyi güncelle
                    try
                    {
                        int idbull;
                        //sermayeyi güncelle
                        SqlCommand guncelle = new SqlCommand("UPDATE sermaye SET sermaye_miktar = @smk WHERE id = @id", baglan);;
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
                        SqlCommand ticariislemtakip_ekle = new SqlCommand("INSERT INTO ticari_islemler(sermaye_id, islem_turu, islem_yapilan_miktar, islem_tarihi) VALUES(@sid, @istur, @ismiktar, @istarih)", baglan);
                        ticariislemtakip_ekle.Parameters.AddWithValue("@sid", SqlDbType.Int).Value = idbull;
                        ticariislemtakip_ekle.Parameters.AddWithValue("@istur", SqlDbType.VarChar).Value = "ALIM";
                        ticariislemtakip_ekle.Parameters.AddWithValue("@ismiktar", SqlDbType.Float).Value = odememiktari;
                        ticariislemtakip_ekle.Parameters.AddWithValue("@istarih", SqlDbType.Date).Value = DateTime.Now.Date;
                        baglan.Open();
                        ticariislemtakip_ekle.ExecuteNonQuery();
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




                        ////////////
                        DataTable alimurunstoklari_dt = new DataTable();
                        string stoksql2 = "SELECT * FROM alim_emri_sepet WHERE alim_emri_id = " + alimid;
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

                            int alinanmiktar = Convert.ToInt32(row["alim_miktar"]);

                            int yenimiktar = stoktamiktarr + alinanmiktar;

                            SqlCommand stokguncel = new SqlCommand("UPDATE stok_urun SET miktar = @mr WHERE urun_id = @id", baglan);
                            stokguncel.Parameters.AddWithValue("@mr", SqlDbType.Int).Value = yenimiktar;
                            stokguncel.Parameters.AddWithValue("@id", SqlDbType.Int).Value = urunnidd;
                            baglan.Open();
                            stokguncel.ExecuteNonQuery();
                            baglan.Close();
                        }

                        MessageBox.Show("İşlem Başarıyla Gerçekleşti!");
                    }
                    catch
                    {
                        MessageBox.Show("Şu an işlem gerçekleşemiyor, lütfen tekrar deneyiniz.");
                    }

                }
            }
            else
            {
                MessageBox.Show("Lütfen işlem yapılacak sermayeyi ve satın alma emrini seçiniz.");
            }
        }
    }
}
