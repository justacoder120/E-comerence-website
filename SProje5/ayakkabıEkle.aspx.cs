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
    public partial class ayakkabıEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            string ayakkabiAdi = txtAyakkabiAdi.Text;
            string fiyat = txtFiyat.Text;
            string kategori = drpKategori.SelectedItem.Value;
            string marka = drpMarka.SelectedItem.Value;
            string renk = drpRenk.SelectedItem.Value;
            string ResimAdi = null;
            if (Resim.HasFile && ayakkabiAdi != "")
            {
                Bitmap EskiResim = new Bitmap(Resim.PostedFile.InputStream);
                int SabitBoyut = 600;
                Bitmap YeniKucukResim = YenidenBoyutlandir(EskiResim, SabitBoyut);
                ResimAdi = string.Join("", ayakkabiAdi.Split(' ')) + ".jpg";
                YeniKucukResim.Save(Server.MapPath("Resimler/" + ResimAdi), ImageFormat.Jpeg);
            }
            String BaglantiYolu = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/Veritabani1.accdb";
            OleDbConnection Baglanti = new OleDbConnection(BaglantiYolu);
            Baglanti.Open();
            string Sorgu = "INSERT INTO Ürünler (Ad, Fiyat, AltKategori, Marka, Cinsiyet, Renk, Resim) VALUES(@Ad, @Fiyat, @AltKategori, @Marka, @Cinsiyet, @Renk, @Resim)";
            OleDbCommand Komut = new OleDbCommand(Sorgu, Baglanti);
            Komut.Parameters.AddWithValue("@Ad", ayakkabiAdi);
            Komut.Parameters.AddWithValue("@Fiyat", fiyat);
            Komut.Parameters.AddWithValue("@AltKategori", kategori);
            Komut.Parameters.AddWithValue("@Marka", marka);
            Komut.Parameters.AddWithValue("@Cinsiyet", fiyat);
            Komut.Parameters.AddWithValue("@Renk", renk);
            Komut.ExecuteNonQuery();
            Baglanti.Close();
        }
        public Bitmap YenidenBoyutlandir(Bitmap EskiResim, int SabitBoyut)
        {
            using (Bitmap OriginalResim = EskiResim)
            {
                double ResimYukseklik = OriginalResim.Height;
                double ResimUzunluk = OriginalResim.Width;
                double oran = 0;
                if (ResimUzunluk > ResimYukseklik && ResimUzunluk > SabitBoyut)
                {
                    oran = ResimUzunluk / ResimYukseklik;
                    ResimUzunluk = SabitBoyut;
                    ResimYukseklik = SabitBoyut / oran;
                }
                else if (ResimYukseklik > ResimUzunluk && ResimYukseklik > SabitBoyut)

                {
                    oran = ResimYukseklik / ResimUzunluk;
                    ResimYukseklik = SabitBoyut;
                    ResimUzunluk = SabitBoyut / oran;
                }
                else if (ResimYukseklik == ResimUzunluk && ResimYukseklik > SabitBoyut)

                {
                    ResimYukseklik = SabitBoyut;
                    ResimUzunluk = SabitBoyut;
                }
                Size YeniBoyut = new Size(Convert.ToInt32(ResimUzunluk), Convert.ToInt32(ResimYukseklik));
                Bitmap YeniBitmapResim = new Bitmap(OriginalResim, YeniBoyut);
                OriginalResim.Dispose();
                return YeniBitmapResim;
            }
        }
    }
}