using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SProje5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string BaglantiYolu = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Veritabani1.accdb";
            OleDbConnection Baglanti = new OleDbConnection(BaglantiYolu);
            Baglanti.Open();
            string ayakkabiId = Request.QueryString["AyakkabıID"];
            string sorgu = "SELECT * FROM (((Ayakkabı INNER JOIN Renk ON Ayakkabı.Renk=Renk.RenkID) INNER JOIN Marka ON Ayakkabı.Marka=Marka.MarkaID) INNER JOIN Kategori ON Ayakkabı.Kategori=Kategori.KategoriID) WHERE AyakkabıID = @AyakkabıId";
            OleDbCommand Komut = new OleDbCommand(sorgu, Baglanti);
            Komut.Parameters.AddWithValue("@AyakkabıId", Convert.ToInt16(ayakkabiId));
            OleDbDataReader Okuyucu = Komut.ExecuteReader();
            while (Okuyucu.Read())
            {
                txtAdet.Text = "1";
                lblAyakkabiAdi.Text = Okuyucu["AyakkabıAdı"].ToString();
                lblAyakkabiFiyat.Text = "$" + Okuyucu["Fiyat"].ToString();
                lblAyakkabiKategory.Text = "👟" +  Okuyucu["Kategori.Kategori"].ToString();
                lblAyakkabiMarkasi.Text = Okuyucu["Marka.Marka"].ToString();
                lblAyakkabiRenk.Text = "🎨" + Okuyucu["Renk.Renk"].ToString() ;
                lblAyakkabiDeger.Text = "🌟" + Okuyucu["değerlendirme"].ToString();
                AyakkabiResmi.ImageUrl = "Resimler/" + Okuyucu["Resim"].ToString();
            }
        }

        protected void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            string ayakkabiId = Request.QueryString["AyakkabıID"];
            string kullaniciId = Request.Cookies["Cerez"]["UserID"];
            String BaglantiYolu = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Veritabani1.accdb";
            OleDbConnection Baglanti = new OleDbConnection(BaglantiYolu);
            Baglanti.Open();
            string Sorgu = "INSERT INTO Sepet (AyakkabıID, KullanıcıID) VALUES(@ayakkabıId, @kullaniciId)";
            OleDbCommand Komut = new OleDbCommand(Sorgu, Baglanti);
            Komut.Parameters.AddWithValue("@ayakkabıId", ayakkabiId);
            Komut.Parameters.AddWithValue("@kullaniciId", kullaniciId);
            Komut.ExecuteNonQuery();
            Baglanti.Close();
        }
    }
}