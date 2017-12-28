using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteEDD
{
    public partial class Configuracion : System.Web.UI.Page
    {
        localhost.WebService1 w = new localhost.WebService1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (w.CargarConfiguracion()!="")
            {
                string[] h = w.CargarConfiguracion().Split(',');
                for (int i = 0; i < h.Length; i++)
                {
                    Label1.Text += h[i] + "<p><p>";
                }
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            w.GuardarConfiguracion(TextBox1.Text, TextBox2.Text, int.Parse(TextBox3.Text), int.Parse(TextBox4.Text), int.Parse(TextBox5.Text), int.Parse(TextBox6.Text), int.Parse(TextBox7.Text), int.Parse(TextBox8.Text), int.Parse(TextBox9.Text),TextBox10.Text);
            Response.Redirect(Request.RawUrl);
        }
    }
}