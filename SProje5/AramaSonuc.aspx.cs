using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SProje5
{
    public partial class AramaSonuc : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            string Metin = Request.QueryString["LinkMetin"];
            String BaglantiYolu = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Veritabani1.accdb";
            OleDbConnection Baglanti = new OleDbConnection(BaglantiYolu);
            Baglanti.Open();
            string Sorgu = "SELECT *, Kategori.Kategori AS KKategori, Marka.Marka AS MMarka FROM (((Ayakkabı INNER JOIN Renk ON Ayakkabı.Renk=Renk.RenkID) INNER JOIN Marka ON Ayakkabı.Marka=Marka.MarkaID) INNER JOIN Kategori ON Ayakkabı.Kategori=Kategori.KategoriID)";
            if (!string.IsNullOrEmpty(Metin))
            {
                Sorgu += $" WHERE AyakkabıAdı LIKE '%{Metin}%' OR Marka.Marka LIKE '%{Metin}%' OR Renk.Renk LIKE '%{Metin}%' OR Kategori.Kategori LIKE '%{Metin}%'";
            }
            OleDbDataAdapter Adapter1 = new OleDbDataAdapter(Sorgu, Baglanti);
            DataSet DataSet1 = new DataSet();
            Adapter1.Fill(DataSet1, "Tablo1");
            AyakkabıKartı.DataSource = DataSet1.Tables["Tablo1"];
            AyakkabıKartı.DataBind();
            Baglanti.Close();
        }
    }
}