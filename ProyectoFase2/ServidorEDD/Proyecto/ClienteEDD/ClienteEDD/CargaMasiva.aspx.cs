using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClienteEDD
{
    public partial class CargaMasiva : System.Web.UI.Page
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
            }
            if (RadioButtonList1.SelectedIndex == 1)
            {
                MultiView1.ActiveViewIndex = 2;
            }
            if (RadioButtonList1.SelectedIndex == 2)
            {
                MultiView1.ActiveViewIndex = 3;
            }
            if (RadioButtonList1.SelectedIndex == 3)
            {
                MultiView1.ActiveViewIndex = 4;
            }
            if (RadioButtonList1.SelectedIndex == 4)
            {
                MultiView1.ActiveViewIndex = 5;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                String fileExtension =
                  System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                bool fileOk = false;
                String[] allowedExtensions =
                   {".csv"};
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOk = true;
                    }
                }
                if (fileOk == true)
                {
                    
                    int contador = 0;
                    string line;
                    System.IO.StreamReader file = new System.IO.StreamReader(FileUpload1.PostedFile.FileName);
                    Label1.Text = FileUpload1.PostedFile.FileName;
                    while ((line = file.ReadLine()) != null)
                    {

                        string[] arreglo = line.Split(',');
                        if (contador != 0)
                        {
                            web.InsertarUsuario(arreglo[0], arreglo[1], arreglo[2]);
                        }
                        if (arreglo[0] == "Nickname")
                        {
                            contador++;
                        }
                      

                    }
                    Response.Redirect("CargaMasiva.aspx");

                }
                else
                {
                    Label1.Text = "Formato de archivo incorrecto";
                }




            }catch(Exception ex)
            {
                Label1.Text = "Error en el archivo de entrada";
            }
            }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                String fileExtension =
                  System.IO.Path.GetExtension(FileUpload3.FileName).ToLower();
                bool fileOk = false;
                String[] allowedExtensions =
                   {".csv"};
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOk = true;
                    }
                }
                if (fileOk == true)
                {

                    int contador = 0;
                    string line;
                    System.IO.StreamReader file = new System.IO.StreamReader(FileUpload3.PostedFile.FileName);
                    
                    while ((line = file.ReadLine()) != null)
                    {

                        string[] arreglo = line.Split(',');
                        if (contador != 0)
                        {
                            web.InsertarLista(arreglo[0], arreglo[1], int.Parse(arreglo[2]), int.Parse(arreglo[3]), int.Parse(arreglo[4]), int.Parse(arreglo[5]));
                        }
                        if (arreglo[0] == "Usuario Base")
                        {
                            contador++;
                        }
                       

                    }
                    Response.Redirect("CargaMasiva.aspx");

                }
                else
                {
                    Label2.Text = "Formato de archivo incorrecto";
                }
            }
            catch (Exception ex)
            {
                Label2.Text = "Error en el archivo de entrada "+ex.Message;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                String fileExtension =
                  System.IO.Path.GetExtension(FileUpload4.FileName).ToLower();
                bool fileOk = false;
                String[] allowedExtensions =
                   {".csv"};
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOk = true;
                    }
                }
                if (fileOk == true)
                {

                    int contador = 0;
                    string line;
                    System.IO.StreamReader file = new System.IO.StreamReader(FileUpload4.PostedFile.FileName);

                    while ((line = file.ReadLine()) != null)
                    {

                        string[] arreglo = line.Split(',');
                        if (contador != 0)
                        {
                            web.MeterMatriz(arreglo[0], arreglo[1], int.Parse(arreglo[2]), arreglo[3], int.Parse(arreglo[4]));
                        }
                        if (arreglo[0] == "jugador")
                        {
                            contador++;
                        }
                    }
                    Response.Redirect("CargaMasiva.aspx");
                }
                else
                {
                    Label3.Text = "Formato de archivo incorrecto";
                }
            }
            catch (Exception ex)
            {
                Label3.Text = "Error en el archivo de entrada " + ex.Message;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                String fileExtension =
                  System.IO.Path.GetExtension(FileUpload5.FileName).ToLower();
                bool fileOk = false;
                String[] allowedExtensions =
                   {".csv"};
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOk = true;
                    }
                }
                if (fileOk == true)
                {

                    int contador = 0;
                    string line;
                    System.IO.StreamReader file = new System.IO.StreamReader(FileUpload5.PostedFile.FileName);

                    while ((line = file.ReadLine()) != null)
                    {

                        string[] arreglo = line.Split(',');
                        if (contador != 0)
                        {
                            web.GuardarConfiguracion(arreglo[0], arreglo[1], int.Parse(arreglo[2]), int.Parse(arreglo[3]), int.Parse(arreglo[4]), int.Parse(arreglo[5]), int.Parse(arreglo[6]), int.Parse(arreglo[7]), int.Parse(arreglo[8]), arreglo[9]);
                            
                        }
                        if (arreglo[0] == "\"Nickname1")
                        {
                            contador++;
                        }
                    }
                    Response.Redirect("CargaMasiva.aspx");
                }
                else
                {
                    Label4.Text = "Formato de archivo incorrecto";
                }
            }
            catch (Exception ex)
            {
                Label4.Text = "Error en el archivo de entrada " + ex.Message;
            }
        }

        protected void Cargar_Click(object sender, EventArgs e)
        {
            try
            {
                String fileExtension =
                  System.IO.Path.GetExtension(FileUpload6.FileName).ToLower();
                bool fileOk = false;
                String[] allowedExtensions =
                   {".csv"};
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOk = true;
                    }
                }
                if (fileOk == true)
                {

                    int contador = 0;
                    string line;
                    System.IO.StreamReader file = new System.IO.StreamReader(FileUpload6.PostedFile.FileName);

                    while ((line = file.ReadLine()) != null)
                    {

                        string[] arreglo = line.Split(',');
                        if (contador != 0)
                        {
                            web.MeterContacto(arreglo[0],arreglo[1],arreglo[2],arreglo[3],0);

                        }
                        if (arreglo[1] == "Nickname")
                        {
                            contador++;
                        }
                    }
                    Response.Redirect("CargaMasiva.aspx");
                }
                else
                {
                    Label5.Text = "Formato de archivo incorrecto";
                }
            }
            catch (Exception ex)
            {
                Label5.Text = "Error en el archivo de entrada " + ex.Message;
            }
        }
    }
}