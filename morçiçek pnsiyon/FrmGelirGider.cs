using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Morçiçek_Pnsiyon
{
    public partial class FrmGelirGider : Form
    {
        public FrmGelirGider()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-KP295N8R;Initial Catalog=MorçiçekPansiyon;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            int personel1;
            personel1 = Convert.ToInt16(TxtPersonel.Text);
            LblPersonelMaas.Text = (personel1 * 1500).ToString();

            int sonuc;
            sonuc = Convert.ToInt16(LblKasaToplam.Text) - (Convert.ToInt16(LblPersonelMaas.Text) + Convert.ToInt16(LblAlinanÜrünler1.Text) + Convert.ToInt16(LblAlinanÜrünler2.Text) + Convert.ToInt16(LblAlinanÜrünler3.Text) + Convert.ToInt16(LblFaturalar1.Text) + Convert.ToInt16(LblFaturalar2.Text) + Convert.ToInt16(LblFaturalar3.Text));
            LblSonuc.Text = sonuc.ToString();
        }

        private void FrmGelirGider_Load(object sender, EventArgs e)
        {
            //Kasadaki Toplam Tutar
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select sum(Ucret) as toplam from MusteriEkle", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                LblKasaToplam.Text = oku["toplam"].ToString();
            }
            baglanti.Close();

            

            //Gıda Giderleri
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select sum(Gidalar) as toplam1 from Mutfak", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                LblAlinanÜrünler1.Text = oku2["toplam1"].ToString();
            }
            baglanti.Close();

            //İçecekler
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select sum(İcecekler) as toplam2 from Mutfak", baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                LblAlinanÜrünler2.Text = oku3["toplam2"].ToString();
            }
            baglanti.Close();

            //Çerezler
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select sum(Cerezler) as toplam3 from Mutfak", baglanti);
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                LblAlinanÜrünler3.Text = oku4["toplam3"].ToString();
            }
            baglanti.Close();

            //ELEKTRİK
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select sum(Elektrik) as toplam4 from Faturalar", baglanti);
            SqlDataReader oku5 = komut5.ExecuteReader();
            while (oku5.Read())
            {
                LblFaturalar1.Text = oku5["toplam4"].ToString();
            }
            baglanti.Close();

            //SU

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select sum(Su) as toplam5 from Faturalar", baglanti);
            SqlDataReader oku6 = komut6.ExecuteReader();
            while (oku6.Read())
            {
                LblFaturalar2.Text = oku6["toplam5"].ToString();
            }
            baglanti.Close();

            //İNTERNET
            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("Select sum(İnternet) as toplam6 from Faturalar", baglanti);
            SqlDataReader oku7 = komut7.ExecuteReader();
            while (oku7.Read())
            {
                LblFaturalar3.Text = oku7["toplam6"].ToString();
            }
            baglanti.Close();


            






        }
    }
}
