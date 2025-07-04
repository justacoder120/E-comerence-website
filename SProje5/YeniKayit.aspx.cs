using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SProje5
{
    public partial class YeniKayit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnKayit_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text;
            string Soyad = txtSoyad.Text;
            string Eposta = txtEposta.Text;
            string parola = txtParola.Text;


            String BaglantiYolu = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Veritabani1.accdb";
            OleDbConnection Baglanti = new OleDbConnection(BaglantiYolu);
            Baglanti.Open();
            string Sorgu = "INSERT INTO Kullanıcı (Ad, Soyad, EPosta, Parola) VALUES(@AdSoyad, @Soyad, @Eposta, @Parola)";
            OleDbCommand Komut = new OleDbCommand(Sorgu, Baglanti);
            Komut.Parameters.AddWithValue("@Ad", ad);
            Komut.Parameters.AddWithValue("@Soyad", Soyad);
            Komut.Parameters.AddWithValue("@Soyad", Eposta);
            Komut.Parameters.AddWithValue("@Parola", parola);
            Komut.ExecuteNonQuery();
            Baglanti.Close();
        }
    }
}