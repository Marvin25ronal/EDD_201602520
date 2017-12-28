using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteEDD
{
    public partial class Login : System.Web.UI.Page
    {
        localhost.WebService1 web = new localhost.WebService1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (web.VerifiCarUsuario(TextBox1.Text, TextBox2.Text) == true)
            {
                Label3.Text = "Usuario Correcto";
                Session["Usuario"] = TextBox1.Text;
                if (TextBox1.Text == "Marvin25")
                {
                    Response.Redirect("Administrador.aspx");
                }
                else
                {

                }

            }
            else
            {
                Label3.Text = "Usuario Incorrecto";
            }
        }
    }
}