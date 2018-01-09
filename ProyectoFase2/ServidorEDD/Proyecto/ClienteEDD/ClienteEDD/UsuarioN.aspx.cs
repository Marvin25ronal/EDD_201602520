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
        static int lo = 5;
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
            Label3.Text = web.usuario1();
            Label4.Text = web.usuario2();
            TextBox4.Text = web.getConsola();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
             string nueo = "";
              if (web.puedeColocarseI(TextBox2.Text,int.Parse(TextBox3.Text)) == true)
            {
                web.MeterMatriz(Session["Usuario"].ToString(), TextBox2.Text, int.Parse(TextBox3.Text), DropDownList1.SelectedItem.Text + (++lo), 1);
                nueo = "El jugador " + Session["Usuario"].ToString() + " coloco una nueva nave: " + DropDownList1.SelectedItem.Text + lo + "\n en las posiciones : \n X: " + TextBox2.Text + " \n Y: " + TextBox3.Text + " \n";

            }
            else
            {
                nueo = "El jugador no pudo colocar la nave porque se exedio del tamano del tablero \n";
            }
            web.setcosola(web.getConsola() + nueo);
            Response.Redirect("UsuarioN.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (web.ExisteUnoEnesaPos(DropDownList2.SelectedItem.Text, TextBox5.Text, int.Parse(TextBox6.Text) )== true){
                web.Mover(DropDownList2.SelectedItem.Text,TextBox5.Text,int.Parse(TextBox6.Text), TextBox7.Text, int.Parse(TextBox8.Text));
                string nueo = "";
                nueo = "Se movio una unidad: " + DropDownList2.SelectedItem.Text + " \n";
                web.setcosola(web.getConsola() + nueo);
                Response.Redirect("UsuarioN.aspx");
            }
        }
    }
}