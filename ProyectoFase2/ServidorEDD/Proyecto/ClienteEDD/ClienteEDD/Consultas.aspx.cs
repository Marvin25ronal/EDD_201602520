using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteEDD
{
    public partial class Consultas : System.Web.UI.Page
    {
        localhost.WebService1 web = new localhost.WebService1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedIndex == 0)
            {
                MultiView1.ActiveViewIndex = 1;
                TextBox1.Text = "Top de ganadores: \n";
                TextBox1.Text+=web.Ganados();
            }
            if (RadioButtonList1.SelectedIndex == 1)
            {
                MultiView1.ActiveViewIndex = 2;
                TextBox2.Text = "Porcentaje de victorias: \n";
                TextBox2.Text += web.Prom();
            }
            if (RadioButtonList1.SelectedIndex == 2)
            {
                MultiView1.ActiveViewIndex = 3;
                TextBox3.Text = " \n";
                TextBox3.Text = web.TopMasContactos();
            }
            if (RadioButtonList1.SelectedIndex == 3)
            {
                MultiView1.ActiveViewIndex = 4;
                TextBox4.Text = " \n";
                TextBox4.Text = web.TopMasDestruidos();
            }
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}