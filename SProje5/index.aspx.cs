using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

namespace SProje5
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String BaglantiYolu = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Veritabani1.accdb";
            OleDbConnection Baglanti = new OleDbConnection(BaglantiYolu);
            Baglanti.Open();

            string Sorgu = "SELECT *, Kategori.Kategori AS KKategori, Marka.Marka AS MMarka FROM ((Ayakkabı INNER JOIN Kategori ON Ayakkabı.Kategori=Kategori.KategoriID) INNER JOIN Marka ON Ayakkabı.Marka=Marka.MarkaID)";

            OleDbDataAdapter Adapter1 = new OleDbDataAdapter(Sorgu, Baglanti);
            DataSet DataSet1 = new DataSet();
            Adapter1.Fill(DataSet1, "Tablo1");

            onerilenUrunler.DataSource = DataSet1.Tables["Tablo1"];
            onerilenUrunler.DataBind();
            Baglanti.Close();
        }
    }
}