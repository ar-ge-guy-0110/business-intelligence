using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace TicariZeka
{
    public partial class main_grafikler : Form
    {
        SqlConnection baglan = new SqlConnection(baglanticlass.baglanticumlesi);
        int sermayeid;
        int urunid;
        public main_grafikler()
        {
            InitializeComponent();
        }

        private void main_grafikler_Load(object sender, EventArgs e)
        {
            sermayeid = -1;
            urunid = -1;

            //sermayeler gelsin
            baglan.Open();
            SqlCommand sql_sermaye = new SqlCommand("SELECT * FROM sermaye", baglan);
            SqlDataReader sql_sermaye_oku = sql_sermaye.ExecuteReader();
            while (sql_sermaye_oku.Read())
            {
                cmbSermayeler.Items.Add(sql_sermaye_oku["sermaye_adi"]);
            }
            baglan.Close();
            //--

            //satilan urunler gelsin
            baglan.Open();
            SqlCommand sql_satisurun = new SqlCommand("SELECT urun.urunadi AS urun_adi, takip_urunsatis.ticari_islem_id AS ticari_islem_no, takip_urunsatis.tarih AS islem_tarihi, takip_urunsatis.miktar AS urun_satis_miktari, takip_urunsatis.toplam_kazanc FROM takip_urunsatis JOIN urun ON urun.id = takip_urunsatis.id", baglan);
            SqlDataReader sq_satisurun_oku = sql_satisurun.ExecuteReader();
            while (sq_satisurun_oku.Read())
            {
                cmbUrun.Items.Add(sq_satisurun_oku["urun_adi"]);
            }
            baglan.Close();
            //--





        }

        private void cmbSermayeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbSermayeler.SelectedIndex != -1)
            {
                DataTable dt7 = new DataTable();
                string sql7 = "SELECT * FROM sermaye WHERE sermaye_adi = N'" + cmbSermayeler.SelectedItem.ToString() + "'";
                SqlDataAdapter da7 = new SqlDataAdapter(sql7, baglan);
                da7.Fill(dt7);

                sermayeid = Convert.ToInt32(dt7.Rows[0][0]);


                chart1.Series.Clear();
                chart1.Titles.Clear();

                chart1.Series.Add("Sermayeler");
                chart1.Series["Sermayeler"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT sermaye.sermaye_adi, sermaye_takip.tarih AS islem_tarihi, sermaye_takip.eski_sermaye, sermaye_takip.yeni_sermaye FROM sermaye_takip JOIN sermaye ON sermaye.id = sermaye_takip.sermaye_id WHERE sermaye.Id = " + sermayeid, baglan);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    chart1.Series["Sermayeler"].Points.AddXY(oku[1].ToString(), oku[3]);
                }
                baglan.Close();
                chart1.Titles.Add(cmbSermayeler.SelectedItem.ToString());
            }
        }

        private void cmbUrun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUrun.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                string sql = "SELECT * FROM urun WHERE urunadi = N'" + cmbUrun.SelectedItem.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, baglan);
                da.Fill(dt);
                urunid = Convert.ToInt32(dt.Rows[0][0]);

                chart2.Series.Clear();
                chart2.Titles.Clear();

                chart2.Series.Add(dt.Rows[0][4].ToString());
                chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chart2.Titles.Add(dt.Rows[0][4].ToString());
                baglan.Open();
                SqlCommand komut = new SqlCommand("SELECT urun.urunadi AS urun_adi, takip_urunsatis.ticari_islem_id AS ticari_islem_no, takip_urunsatis.tarih AS islem_tarihi, takip_urunsatis.miktar AS urun_satis_miktari, takip_urunsatis.toplam_kazanc FROM takip_urunsatis JOIN urun ON urun.id = takip_urunsatis.id WHERE urun.id = " + urunid, baglan);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    chart2.Series[0].Points.AddXY(oku[2].ToString(), oku[3]);
                }
                baglan.Close();

            }
        }
    }
}
