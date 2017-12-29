using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteEDD
{
    public partial class UsuarioNormalaspx : System.Web.UI.Page
    {
        localhost.WebService1 web = new localhost.WebService1();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Bienvenido " + Session["Usuario"].ToString();
            web.CambiarEstado(Session["Usuario"].ToString());
            web.GenerarTablero();
            Image1.ImageUrl = "data:image/jpeg;base64,"+ web.HacerTableroL0("TableroL0");
            Image2.ImageUrl = "data:image/jpeg;base64," + web.HacerTableroL1("TableroL1");
            Image3.ImageUrl = "data:image/jpeg;base64," + web.HacerTableroL2("TableroL2");
            Image4.ImageUrl = "data:image/jpeg;base64," + web.HacerTableroL0("TableroL3");

        }
    }
}