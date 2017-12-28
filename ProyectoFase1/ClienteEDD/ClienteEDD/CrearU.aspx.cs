<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteEDD
{
    public partial class CrearU : System.Web.UI.Page
    {
        localhost.WebService1 w = new localhost.WebService1();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "Bienvenido " + Session["Usuario"].ToString();
            MultiView1.ActiveViewIndex = int.Parse(Request["M"]);
            Label3.Text = w.CargarUsuarios();
            Label5.Text = w.CargarUsuarios();
            Panel1.Visible = false;
      
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (w.Existe(TextBox4.Text) == false)
            {
                Label4.Text = "El usuario no existe";
            }
            else
            {
                Panel1.Visible = true;

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (w.ModificarUsuario(TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text)==true)
            {
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Label4.Text = "No se pudo modificar";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (w.InsertarUsuario(TextBox1.Text,TextBox2.Text,TextBox3.Text) == true)
            {
                Label1.Text = "Se creo";
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Label1.Text = "No se puede crear";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (w.EliminarUsuario(TextBox8.Text) == true)
            {
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Label5.Text = "No se pudo eliminar";    
            }
        }
    }
    
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteEDD
{
    public partial class CrearU : System.Web.UI.Page
    {
        localhost.WebService1 w = new localhost.WebService1();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "Bienvenido " + Session["Usuario"].ToString();
            MultiView1.ActiveViewIndex = int.Parse(Request["M"]);
            Label3.Text = w.CargarUsuarios();
            Label5.Text = w.CargarUsuarios();
            Panel1.Visible = false;
      
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (w.Existe(TextBox4.Text) == false)
            {
                Label4.Text = "El usuario no existe";
            }
            else
            {
                Panel1.Visible = true;

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (w.ModificarUsuario(TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text)==true)
            {
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Label4.Text = "No se pudo modificar";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (w.InsertarUsuario(TextBox1.Text,TextBox2.Text,TextBox3.Text) == true)
            {
                Label1.Text = "Se creo";
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Label1.Text = "No se puede crear";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (w.EliminarUsuario(TextBox8.Text) == true)
            {
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                Label5.Text = "No se pudo eliminar";    
            }
        }
    }
    
>>>>>>> dd5dfac4819ebdd8ebdbef72dbeef126d5d02568
}