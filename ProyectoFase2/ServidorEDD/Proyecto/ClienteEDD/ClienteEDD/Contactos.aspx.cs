using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteEDD
{
    public partial class Contactos : System.Web.UI.Page
    {
        localhost.WebService1 w = new localhost.WebService1();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label1.Text = w.CargarContactos(Session["Usuario"].ToString());
            Panel1.Visible = false;
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 0)
            {
                MultiView1.ActiveViewIndex = 1;
            }
            if (RadioButtonList1.SelectedIndex == 1)
            {
                Label2.Text = w.CargarContactos(Session["Usuario"].ToString());
                MultiView1.ActiveViewIndex = 2;
            }
            if (RadioButtonList1.SelectedIndex == 2)
            {
                Label5.Text = w.CargarContactos(Session["Usuario"].ToString());
                MultiView1.ActiveViewIndex = 3;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
                w.MeterContacto(Session["Usuario"].ToString(), TextBox1.Text, TextBox2.Text, TextBox3.Text, 0);
            Response.Redirect("Contactos.aspx");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (w.EliminarContacto(Session["Usuario"].ToString(), TextBox4.Text) == true)
            {
                Response.Redirect("Contactos.aspx");
            }
            else
            {
                Label3.Text = "No se pudo eliminar";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            w.EliminarContacto(Session["Usuario"].ToString(), TextBox8.Text);
            w.MeterContacto(Session["Usuario"].ToString(), TextBox5.Text, TextBox6.Text, TextBox7.Text, 0);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (w.ExisteContacto(Session["Usuario"].ToString(), TextBox8.Text) == true)
            {
                Panel1.Visible = true;
            }
        }
    }
}