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

        }
    }
}