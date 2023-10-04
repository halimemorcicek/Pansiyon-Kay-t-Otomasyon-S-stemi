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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-KP295N8R;Initial Catalog=MorçiçekPansiyon;Integrated Security=True");

        private void veriler()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Mutfak", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem Ekle = new ListViewItem();
                Ekle.Text = oku["Gidalar"].ToString();
                Ekle.SubItems.Add(oku["İcecekler"].ToString());
                Ekle.SubItems.Add(oku["Cerezler"].ToString());
                listView1.Items.Add(Ekle);
                ;           }
            baglanti.Close();
        }
        private void veriler2()
        {

            listView2.Items.Clear();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select * from Faturalar", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                ListViewItem Ekle = new ListViewItem();
                Ekle.Text = oku2["Elektrik"].ToString();
                Ekle.SubItems.Add(oku2["Su"].ToString());
                Ekle.SubItems.Add(oku2["İnternet"].ToString());
                listView2.Items.Add(Ekle);
                
            }
            baglanti.Close();
        }
        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            veriler();
            veriler2();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Mutfak (Gidalar,İcecekler,Cerezler) values ('" + TxtGidalar.Text + "','" + Txtİcecekler.Text + "','" + TxtCerezler.Text + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            veriler();
        }

        private void BtnKaydet2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into Faturalar (Elektrik,Su,İnternet) values ('" + TxtElektrik.Text + "','" + TxtSu.Text + "','" + Txtİnternet.Text + "')", baglanti);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            veriler2();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click_1(object sender, EventArgs e)
        {

        }
    }
}
