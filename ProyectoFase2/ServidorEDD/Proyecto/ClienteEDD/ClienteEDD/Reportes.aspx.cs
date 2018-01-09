using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ClienteEDD
{
    public partial class Reportes : System.Web.UI.Page
    {
        localhost.WebService1 web = new localhost.WebService1();
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = int.Parse(Request["N"]);

        }

        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {
            if (MultiView1.ActiveViewIndex == 0)
            {
                
                web.GenerarArbolito();
               
                Image1.ImageUrl = "data:image/jpeg;base64," + web.ConvertirArbol("Arbol");
                Label3.Text = web.DatosArbol();

            }
            if (MultiView1.ActiveViewIndex == 1)
            {

                web.GenerarEspejo();

                Image2.ImageUrl = "data:image/jpeg;base64," + web.ConvertirEspejo("Espejo");
                Label2.Text = web.DatosArbol();

            }
            if (MultiView1.ActiveViewIndex == 2)
            {
                web.GenerarDestruidas();
                Image5.ImageUrl = "data:image/jpeg;base64," + web.HacerDestruL0("DestruL0");
                Image6.ImageUrl = "data:image/jpeg;base64," + web.HacerDestruL1("DestruL1");
                Image3.ImageUrl = "data:image/jpeg;base64," + web.HacerDestruL2("DestruL2");
                Image4.ImageUrl = "data:image/jpeg;base64," + web.HacerDestruL4("DestruL3");

            }
            if (MultiView1.ActiveViewIndex == 3)
            {
                web.GenerarSobrevivientes();
                Image7.ImageUrl = "data:image/jpeg;base64," + web.HacerDestruL0("Vivos0");
                Image8.ImageUrl = "data:image/jpeg;base64," + web.HacerDestruL1("Vivos1");
                Image9.ImageUrl = "data:image/jpeg;base64," + web.HacerDestruL2("Vivos2");
                Image10.ImageUrl = "data:image/jpeg;base64," + web.HacerDestruL4("Vivos3");

            }
            if (MultiView1.ActiveViewIndex == 4)
            {
                Label6.Text = web.CargarUsuarios();

            }
            if (MultiView1.ActiveViewIndex == 6)
            {
                web.InsertarHash();
                web.GenerarTablaHash();
                Image12.ImageUrl = "data:image/jpeg;base64," + web.HacerHash("Hash");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Image11.Visible = true;
            if (web.Existe(TextBox1.Text) == true)
            {
                web.GenerarContac(TextBox1.Text);
                Image11.ImageUrl = "data:image/jpeg;base64," + web.ConvertirContactos("Contactos");
                MultiView1.ActiveViewIndex = 5;
            }
            else
            {
                Label8.Text = "El usuario no existe";
            }
           
        }
    }
}