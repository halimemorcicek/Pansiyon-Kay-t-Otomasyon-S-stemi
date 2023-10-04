﻿using System;
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
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }
         SqlConnection baglanti = new SqlConnection(@"Data Source = LAPTOP-KP295N8R; Initial Catalog = MorçiçekPansiyon; Integrated Security = True");
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
           try
           {
                baglanti.Open();
                string sql = "select * from AdminGiris where Kullanici = @Kullaniciadi AND Sifre = @Sifresi";
                SqlParameter prm1 = new SqlParameter("Kullaniciadi", TxtKullaniciAdi.Text.Trim());
                SqlParameter prm2 = new SqlParameter("Sifresi", TxtSifre.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);

                da.Fill(dt);

                if(dt.Rows.Count > 0 )
                {
                    FrmAnaForm fr = new FrmAnaForm();
                    fr.Show();
                    this.Hide();
                }
           }
           catch(Exception)
           {
                MessageBox.Show("Hatalı Giriş");
                


           }
        }

        private void TxtSifre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
