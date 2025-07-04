using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SProje5
{
    public partial class ayakkabıGuncelle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ayakkabiId = Request.QueryString["LinkAyakkabıID"];

            string BaglantiYolu = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Veritabani1.accdb";
            OleDbConnection Baglanti = new OleDbConnection(BaglantiYolu);
            Baglanti.Open();
            string sorgu = null;
            OleDbCommand Komut = null;
            OleDbDataReader Okuyucu = null;
            if (!IsPostBack)
            {
                sorgu = "SELECT * FROM Marka";
                Komut = new OleDbCommand(sorgu, Baglanti);
                Okuyucu = Komut.ExecuteReader();

                ListItem Eleman = null;
                while (Okuyucu.Read())
                {
                    Eleman = new ListItem();
                    Eleman.Text = Okuyucu["Marka"].ToString();
                    Eleman.Value = Okuyucu["MarkaID"].ToString();
                    drpMarka.Items.Add(Eleman);
                }

                sorgu = "SELECT * FROM Kategori";
                Komut = new OleDbCommand(sorgu, Baglanti);
                Okuyucu = Komut.ExecuteReader();

                while (Okuyucu.Read())
                {
                    Eleman = new ListItem();
                    Eleman.Text = Okuyucu["Kategori"].ToString();
                    Eleman.Value = Okuyucu["KategoriID"].ToString();
                    drpKategori.Items.Add(Eleman);
                }

                sorgu = "SELECT * FROM Renk";
                Komut = new OleDbCommand(sorgu, Baglanti);
                Okuyucu = Komut.ExecuteReader();

                while (Okuyucu.Read())
                {
                    Eleman = new ListItem();
                    Eleman.Text = Okuyucu["Renk"].ToString();
                    Eleman.Value = Okuyucu["RenkID"].ToString();
                    drpRenk.Items.Add(Eleman);
                }
            }
            sorgu = "SELECT * FROM Ayakkabı WHERE AyakkabıID = @AyakkabıId";
            Komut = new OleDbCommand(sorgu, Baglanti);
            Komut.Parameters.AddWithValue("@AyakkabıId", Convert.ToInt16(ayakkabiId));
            Okuyucu = Komut.ExecuteReader();
            while (Okuyucu.Read())
            {
                txtAyakkabiAdi.Text = Okuyucu["AyakkabıAdı"].ToString();
                txtFiyat.Text = Okuyucu["Fiyat"].ToString();
                drpKategori.SelectedValue = Okuyucu["Kategori"].ToString();
                drpMarka.SelectedValue = Okuyucu["Marka"].ToString();
                drpRenk.SelectedValue = Okuyucu["Renk"].ToString();
                Resim.ImageUrl = "Resimler/" + Okuyucu["Resim"].ToString();
            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            string ayakkabiAdi = txtAyakkabiAdi.Text;
            string ayakkabiId = Request.QueryString["LinkAyakkabıID"];
            string fiyat = txtFiyat.Text;
            string kategori = drpKategori.SelectedItem.Value;
            string marka = drpMarka.SelectedItem.Value;
            string renk = drpRenk.SelectedItem.Value;

            String BaglantiYolu = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Veritabani1.accdb";
            OleDbConnection Baglanti = new OleDbConnection(BaglantiYolu);
            Baglanti.Open();
            string Sorgu = "UPDATE Ayakkabı SET AyakkabıAdı = @ayakkabıAdı, Renk = @renk, Kategori = @kategori, Marka = @marka, Fiyat = @fiyat";
            OleDbCommand Komut = new OleDbCommand(Sorgu, Baglanti);
            //Komut.Parameters.AddWithValue("@fiyat", ayakkabiId);
            Komut.Parameters.AddWithValue("@ayakkabıAdı", ayakkabiAdi);
            Komut.Parameters.AddWithValue("@renk", renk);
            Komut.Parameters.AddWithValue("@kategori", kategori);
            Komut.Parameters.AddWithValue("@marka", marka);
            Komut.Parameters.AddWithValue("@fiyat", fiyat);
            Komut.ExecuteNonQuery();
            Baglanti.Close();
        }
    }
}