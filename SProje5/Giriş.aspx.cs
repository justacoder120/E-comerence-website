using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SProje5
{
    public partial class Giriş : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            string Eposta = txtEposta.Text;
            string parola = txtParola.Text;

            string BaglantiYolu = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Veritabani1.accdb";
            OleDbConnection Baglanti = new OleDbConnection(BaglantiYolu);
            Baglanti.Open();
            string sorgu = "SELECT * FROM Kullanıcı";
            OleDbCommand Komut = new OleDbCommand(sorgu, Baglanti);
            OleDbDataReader Okuyucu = Komut.ExecuteReader();
            while (Okuyucu.Read())
            {
                string veritabaniEposta = Okuyucu["EPosta"].ToString();
                string veritabaniParola = Okuyucu["Parola"].ToString();
                if (Eposta == veritabaniEposta && parola == veritabaniParola)
                {
                    HttpCookie cerez = new HttpCookie("Cerez");
                    cerez.Values["UserID"] = Okuyucu["KullaniciID"].ToString();
                    cerez.Values["Yonetici"] = Okuyucu["Yonetici"].ToString();
                    if (chbOturumAcikTut.Checked)
                    {
                        cerez.Expires = DateTime.Now.AddDays(1);
                    }
                    Response.Cookies.Add(cerez);
                    Response.Redirect("index.aspx");
                }

            }

        }
    }
}