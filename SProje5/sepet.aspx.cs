using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SProje5
{
    public partial class sepet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int kullaniciId = Convert.ToInt32(Request.Cookies["Cerez"]["UserID"]);
            String BaglantiYolu = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Veritabani1.accdb";
            OleDbConnection Baglanti = new OleDbConnection(BaglantiYolu);
            Baglanti.Open();
            string Sorgu = "SELECT Ayakkabı.AyakkabıID, Ayakkabı.AyakkabıAdı, Ayakkabı.Fiyat, Ayakkabı.Resim, Kategori.Kategori AS KKategori, Marka.Marka AS MMarka FROM (((Sepet INNER JOIN Ayakkabı ON Sepet.AyakkabıID = Ayakkabı.AyakkabıID) INNER JOIN Kategori ON Ayakkabı.Kategori= Kategori.KategoriID) INNER JOIN Marka ON Ayakkabı.Marka = Marka.MarkaID) WHERE Sepet.kullanıcıID = @kullanıcıId";
            OleDbDataAdapter Adapter1 = new OleDbDataAdapter(Sorgu, Baglanti);
            Adapter1.SelectCommand.Parameters.AddWithValue("@kullanıcıId", kullaniciId);
            DataSet DataSet1 = new DataSet();

            Adapter1.Fill(DataSet1, "Tablo1");

            AyakkabıKartı.DataSource = DataSet1.Tables["Tablo1"];
            AyakkabıKartı.DataBind();

            Baglanti.Close();
        }
    }
}