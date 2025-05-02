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
    public partial class main_iszekasi : Form
    {
        SqlConnection baglan = new SqlConnection(baglanticlass.baglanticumlesi);
        public main_iszekasi()
        {
            InitializeComponent();
        }

        private void main_iszekasi_Load(object sender, EventArgs e)
        {
            if ((main)Application.OpenForms["main"] != null)
            {
                main mainwin = (main)Application.OpenForms["main"];
                mainwin.formOpen_main_iszekasi = true;
            }


            listele1();
            listele2();
            listele3();
        }

        private void main_iszekasi_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((main)Application.OpenForms["main"] != null)
            {
                main mainwin = (main)Application.OpenForms["main"];
                mainwin.formOpen_main_iszekasi = false;
            }

        }

        private void listele1()
        {
            SqlCommand listeleq = new SqlCommand("SELECT sermaye.sermaye_adi, sermaye_takip.tarih AS islem_tarihi, sermaye_takip.eski_sermaye, sermaye_takip.yeni_sermaye FROM sermaye_takip JOIN sermaye ON sermaye.id = sermaye_takip.sermaye_id", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "sermaye_takip");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "sermaye_takip";
        }

        private void listele2()
        {
            SqlCommand listeleq = new SqlCommand("SELECT sermaye.sermaye_adi, ticari_islemler.islem_turu, ticari_islemler.islem_yapilan_miktar AS islem_yapilan_para_miktari, ticari_islemler.islem_tarihi FROM ticari_islemler JOIN sermaye ON sermaye.id = ticari_islemler.sermaye_id", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "ticari_islemler");
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "ticari_islemler";
        }

        private void listele3()
        {
            SqlCommand listeleq = new SqlCommand("SELECT urun.urunadi AS urun_adi, takip_urunsatis.ticari_islem_id AS ticari_islem_no, takip_urunsatis.tarih AS islem_tarihi, takip_urunsatis.miktar AS urun_satis_miktari, takip_urunsatis.toplam_kazanc FROM takip_urunsatis JOIN urun ON urun.id = takip_urunsatis.id", baglan);
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter(listeleq);
            da.Fill(ds, "takip_urunsatis");
            dataGridView3.DataSource = ds;
            dataGridView3.DataMember = "takip_urunsatis";
        }
    }
}
