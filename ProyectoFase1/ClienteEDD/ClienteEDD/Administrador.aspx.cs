using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteEDD
{
    public partial class Administrador1 : System.Web.UI.Page
    {
        localhost.WebService1 web = new localhost.WebService1();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Bienvenido " + Session["Usuario"].ToString();
            web.CambiarEstado(Session["Usuario"].ToString());
        }
    }
}