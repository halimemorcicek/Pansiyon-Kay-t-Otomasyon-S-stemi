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
using System.Data.Sql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Morçiçek_Pnsiyon
{
    public partial class FrmSifreGuncelle : Form
    {
        public FrmSifreGuncelle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LAPTOP-KP295N8R;Initial Catalog=MorçiçekPansiyon;Integrated Security=True");

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update AdminGiris set Kullanici='" + TxtKullaniciAdi.Text + "',Sifre= '" +TxtSifre.Text+" '" , baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            
        }
    }
}
