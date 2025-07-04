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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Cerez"] != null)
            {
               
                HyperLink1.Visible = false;
                HyperLink2.Visible = false;
                HyperLink3.Visible = true;
                btncikis.Visible = true;

            }
            else
            {
                HyperLink1.Visible = true;
                HyperLink2.Visible = true;
                HyperLink3.Visible = false;
                btncikis.Visible = false;

            }
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            string aramaMetni = txtArama.Text;
            Response.Redirect("aramaSonuc.aspx?LinkMetin=" + aramaMetni);
        }

        protected void btnOturumuKapat_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["Cerez"] != null)
            {
                Response.Cookies["Cerez"].Expires = DateTime.Now.AddDays(-1);
                Response.Redirect("index.aspx");
            }
        }
    }
}