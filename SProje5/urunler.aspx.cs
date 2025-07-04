using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SProje5
{
    public partial class urunler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String BaglantiYolu = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Veritabani1.accdb";
            OleDbConnection Baglanti = new OleDbConnection(BaglantiYolu);
            Baglanti.Open();

            string Sorgu = "SELECT * FROM Ayakkabı";

            List<string> myList = new List<string>();

            string kategori = Request.QueryString["LinkKategori"];
            string renk = Request.QueryString["LinkRenk"];
            string marka = Request.QueryString["LinkMarka"];
            string siralama = Request.QueryString["LinkSiralama"];

            if (!string.IsNullOrEmpty(kategori))
            {

                myList.Add("Kategori=" + Convert.ToInt32(kategori));
            }

            if (!string.IsNullOrEmpty(renk))
            {

                myList.Add("Renk=" + Convert.ToInt32(renk));

            }

            if (!string.IsNullOrEmpty(marka))
            {

                myList.Add("Renk=" + Convert.ToInt32(marka));
            }

            if (myList.Count != 0)
            {
                string sonuc = string.Join(" AND ", myList);
                Sorgu += " WHERE ";
                Sorgu += sonuc;
            }


            if (!string.IsNullOrEmpty(siralama))
            {
                string siralamaMetni = "";
                int siralamaTipi = Convert.ToInt16(siralama);

                if (siralamaTipi == 1)
                {
                    siralamaMetni = " ORDER BY Fiyat ASC";
                }
                else if (siralamaTipi == 2)
                {
                    siralamaMetni = " ORDER BY Fiyat DESC";
                }

                Sorgu += siralamaMetni;
            }




            OleDbDataAdapter Adapter1 = new OleDbDataAdapter(Sorgu, Baglanti);
            DataSet DataSet1 = new DataSet();

            Adapter1.Fill(DataSet1, "Tablo1");

            AyakkabıKartı.DataSource = DataSet1.Tables["Tablo1"];
            AyakkabıKartı.DataBind();

            if (!IsPostBack)
            {
                string sorgu = "SELECT * FROM Marka";
                OleDbCommand Komut = new OleDbCommand(sorgu, Baglanti);
                OleDbDataReader Okuyucu = Komut.ExecuteReader();

                ListItem Eleman = new ListItem();
                Eleman.Text = "Tümü";
                Eleman.Value = "0";
                drpMarka.Items.Add(Eleman);
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

                Eleman = new ListItem();
                Eleman.Text = "Tümü";
                Eleman.Value = "0";
                drpKategori.Items.Add(Eleman);
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

                Eleman = new ListItem();
                Eleman.Text = "Tümü";
                Eleman.Value = "0";
                drpRenk.Items.Add(Eleman);
                while (Okuyucu.Read())
                {
                    Eleman = new ListItem();
                    Eleman.Text = Okuyucu["Renk"].ToString();
                    Eleman.Value = Okuyucu["RenkID"].ToString();
                    drpRenk.Items.Add(Eleman);
                }
            }


            Baglanti.Close();
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string kategori = Request.QueryString["LinkKategori"];
                string renk = Request.QueryString["LinkRenk"];
                string marka = Request.QueryString["LinkMarka"];
                string siralama = Request.QueryString["LinkSiralama"];

                if (!string.IsNullOrEmpty(kategori))
                {
                    drpKategori.SelectedValue = kategori;
                }

                if (!string.IsNullOrEmpty(renk))
                {
                    drpRenk.SelectedValue = renk;
                }

                if (!string.IsNullOrEmpty(marka))
                {
                    drpMarka.SelectedValue = marka;
                }
                if (!string.IsNullOrEmpty(siralama))
                {
                    drpSiralama.SelectedValue = siralama;
                }
            }
        }

        protected void btnUygula_Click(object sender, EventArgs e)
        {
            string selectedKategori = drpKategori.SelectedValue;
            string selectedMarka = drpMarka.SelectedValue;
            string selectedRenk = drpRenk.SelectedValue;
            string selectedSiralama = drpSiralama.SelectedValue;

            string redirectUrl = "urunler.aspx?";
            List<string> myList = new List<string>();


            if (!selectedKategori.Equals("0"))
            {
                myList.Add("LinkKategori=" + selectedKategori);
            }

            if (!selectedMarka.Equals("0"))
            {
                myList.Add("LinkMarka=" + selectedMarka);

            }

            if (!selectedRenk.Equals("0"))
            {
                myList.Add("LinkRenk=" + selectedRenk);
            }
            if (!selectedSiralama.Equals("0"))
            {
                myList.Add("LinkSiralama=" + selectedSiralama);
            }
            string sonuc = string.Join("&", myList);
            Response.Redirect(redirectUrl + sonuc);
        }

        protected void AyakkabıKartı_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                
                Panel adminbutonlari = (Panel)e.Item.FindControl("adminButonlari");
                

                if (Request.Cookies["Cerez"] != null && Request.Cookies["Cerez"]["Yonetici"].Equals("True"))
                {
                    adminbutonlari.Visible = true;
                }
                else
                {
                    adminbutonlari.Visible = false;
                }
            }
        }

        protected void AyakkabıKartı_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item != null)
            {
                

                string BaglantiYolu = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Veritabani1.accdb";
                OleDbConnection Baglanti = new OleDbConnection(BaglantiYolu);
                Baglanti.Open();
                string ayakkabıId = e.CommandArgument.ToString();
                String Sorgu = "DELETE * FROM Ayakkabı WHERE AyakkabıID = @AyakkabıId";
                OleDbCommand Komut = new OleDbCommand(Sorgu, Baglanti);
                Komut.Parameters.AddWithValue("@AyakkabıId", ayakkabıId);
                Komut.ExecuteNonQuery();
                Baglanti.Close();
                Response.Redirect(Request.RawUrl);
                
            }
        }
    }
}