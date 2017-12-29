using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;

namespace ServidorEDD
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        static Arbol1 arbolito;
        static Matriz eliminados;
        static Matriz vivos;
        static Matriz tablero;
        static Espejo Espejo;
        static int contadorArbolNormal=0;
        static int id = 0;
        static int contadorEspejo = 0;
        static int ContadorTablero = 0;
        static int L0=0, L1=0, L2=0, L3 = 0;
        static WebService1()
        {
            arbolito = new Arbol1();
            eliminados = new Matriz();
            vivos = new Matriz();
            tablero = new Matriz();
            Espejo = new Espejo();
        }
      
        [WebMethod]
        public bool VerifiCarUsuario(string nickname,string Contrasena)
        {
            NodoArbol aux;
            aux = arbolito.Buscar(nickname);
            if (aux == null)
            {
                return false;
            }
            else if(aux.Contrasena==Contrasena)
            {
                return true;

            }

            return false;
        }
        [WebMethod]
        public void CambiarEstado(string nickname)
        {
            arbolito.CambiarEstado(nickname);
            Espejo.CambiarEstado(nickname);
        }
        [WebMethod]
        public bool InsertarUsuario(string nickname,string contrasena,string correo)
        {
            if (arbolito.Buscar(nickname) == null)
            {
                arbolito.insertarNodo(nickname, contrasena, correo, 0);
                Espejo.insertarNodo(nickname, contrasena, correo, 0);
                return true;
            }
            else
            {
                return false;
            }
        }
        [WebMethod]
        public string CargarUsuarios()
        {
            return arbolito.Pre();
        }
        [WebMethod]
       public string RetornarCorreo(string nombre)
        {
            NodoArbol aux = arbolito.Buscar(nombre);
            return aux.Correo;
        }
        [WebMethod]
       public string RetornarClave(string nombre)
        {
            NodoArbol aux = arbolito.Buscar(nombre);
            return aux.Contrasena;
        }
        [WebMethod]
        public bool Existe(string nickname)
        {
            if (arbolito.Buscar(nickname) == null)
            {
                return false;
            }
            return true;
        }
        [WebMethod]
        public bool ModificarUsuario(string nickname,string nuevonickname,string correo,string contrasena)
        {
            if (Existe(nuevonickname) == false)
            {
                arbolito.Actualizar(nickname, nuevonickname, correo, contrasena, 0);
                Espejo.Actualizar(nickname, nuevonickname, correo, contrasena, 0);
                return true;
            }
            return false;
        }
        [WebMethod]
        public bool EliminarUsuario(string nickname)
        {
            if (arbolito.Buscar(nickname) != null)
            {
                arbolito.Eliminar(nickname);
                Espejo.Eliminar(nickname);
                return true;
            }
            return false;
        }
    
        [WebMethod]
        public void InsertarLista(string UsuarioBase,string oponent,int Udesple,int Usobre,int Udestrui,int gano)
        {
            NodoArbol aux,es;
            aux = arbolito.Buscar(UsuarioBase);
            es = Espejo.Buscar(UsuarioBase);
            if (aux != null)
            {
                ListaJuego auxlista = aux.Lista;
                ListaJuego auxlistees = es.Lista;
                auxlista.insertar(oponent, Udesple, Usobre, Udestrui, gano, id);
                auxlistees.insertar(oponent, Udesple, Usobre, Udestrui, gano, id++);
            }

        }
        [WebMethod]
        public void GenerarArbolito()
        {
            string codigo="digraph G { \n";
            codigo += "node[shape=record,style=filled];\n";
            codigo += arbolito.Codigo();
            codigo += "}";
           
            string ruta = "C:\\Users\\User\\Desktop\\G\\Arbol.txt";
            try
            {
                File.WriteAllText(ruta, codigo);
            }
            catch(Exception ex)
            {

            }
            

        }
        [WebMethod]
        public void GenerarEspejo()
        {
            string codigo = "digraph G { \n";
            codigo += "node[shape=record,style=filled];\n";
            codigo += Espejo.Codigo();
            codigo += "}";

            string ruta = "C:\\Users\\User\\Desktop\\G\\Espejo.txt";
            try
            {
                File.WriteAllText(ruta, codigo);
            }
            catch (Exception ex)
            {

            }


        }
        [WebMethod]
       public void GenerarTablero()
        {
            string ruta = "C:\\Users\\User\\Desktop\\G\\TableroL0.txt";
            string ruta2 = "C:\\Users\\User\\Desktop\\G\\TableroL1.txt";
            string ruta3 = "C:\\Users\\User\\Desktop\\G\\TableroL2.txt";
            string ruta4 = "C:\\Users\\User\\Desktop\\G\\TableroL3.txt";
            try
            {
                File.WriteAllText(ruta, tablero.CodigoNivel0());
                File.WriteAllText(ruta2,tablero.CodigoNivel1());
                File.WriteAllText(ruta3,tablero.CodigoNivel2());
                File.WriteAllText(ruta4,tablero.CodigoNivel3());
            }
            catch (Exception ex)
            {

            }
        }

        [WebMethod]
        public bool MeterMatriz(string jugador,string columna,int fila,string unidad,int vivo)
        {
            string nombre=unidad;
        nombre= Regex.Replace(nombre, @"[\d-]", String.Empty);


            Unidad nave = new Unidad(nombre);
            Objeto nuevo = new Objeto(jugador, unidad, nave.Vida, nave.Movimiennto, nave.Alcance, nave.Dano, vivo);
            tablero.insertar(nuevo,tablero.Numero(columna), fila, nave.Nivel);
           if (vivo == 1)
            {
                vivos.insertar(nuevo, tablero.Numero(columna), fila, nave.Nivel);
            }
            else
            {
                eliminados.insertar(nuevo, tablero.Numero(columna), fila, nave.Nivel);
            }
            return true;
        }
        [WebMethod]
        public void GuardarConfiguracion(string jugador1,string jugador2,int n1,int n2,int n3,int n4,int tamx,int tamy,int tipo,string ho)
        {
            tablero.llenarConfig(jugador1, jugador2, n1, n2, n3, n4, tamx, tamy, tipo, ho);
        }
        [WebMethod]
        public string CargarConfiguracion()
        {
            string confi = "";
            if (tablero.Jugador1 != null)
            {
                confi += tablero.Jugador1 + "," + tablero.Jugador2 + "," + tablero.Submarinos1 + "," + tablero.Barcos1 + "," + tablero.Aviones1 + "," + tablero.Satelites1 +","+ tablero.Tamx + "," + tablero.Tamy + "," + tablero.TipoJuego + "," + tablero.Minutos;
            }
            return confi;
        }
        public bool ejecutarComando(string comando)
        {
            try
            {
                
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/C" + comando);
            
                procStartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                // Indicamos que la salida del proceso se redireccione en un Stream
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
                procStartInfo.CreateNoWindow = false;
                //Inicializa el proceso
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                proc.WaitForExit();
                proc.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        [WebMethod]
        public string ConvertirArbol(string archivo)
        {
            
            if (ejecutarComando("dot -Tjpg C:/Users/User/Desktop/G/"+archivo+".txt"+ " -o C:/Users/User/Desktop/G/ArbolNormal/"+archivo+(++contadorArbolNormal)+".jpg"))
            {
                MemoryStream ms = new MemoryStream();
                Image imagen = Image.FromFile("C:\\Users\\User\\Desktop\\G\\ArbolNormal\\" + archivo+contadorArbolNormal+".jpg" );
               
                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                string base64string = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                return base64string;
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                Image imagen = Image.FromFile("C:\\Users\\User\\Desktop\\G\\problemas.jpg");
                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                string base64string = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                return base64string;
            }
        }
        [WebMethod]
        public string ConvertirEspejo(string archivo)
        {

            if (ejecutarComando("dot -Tjpg C:/Users/User/Desktop/G/" + archivo + ".txt" + " -o C:/Users/User/Desktop/G/Tablero/" + archivo + (++contadorEspejo) + ".jpg"))
            {
                MemoryStream ms = new MemoryStream();
                Image imagen = Image.FromFile("C:\\Users\\User\\Desktop\\G\\ArbolNormal\\" + archivo + contadorEspejo + ".jpg");

                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                string base64string = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                return base64string;
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                Image imagen = Image.FromFile("C:\\Users\\User\\Desktop\\G\\problemas.jpg");
                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                string base64string = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                return base64string;
            }
        }
        [WebMethod]
        public string DatosArbol()
        {
            string cadena = "";
            cadena += "Numero de niveles: " + arbolito.Level()+"<p><p>";
            cadena += "Altura del arbol : " + (arbolito.Level() + 1) + "<p><p>";
            cadena += "Cantidad de nodos Hojas: " + arbolito.Hoja() + "<p><p>";
            cadena += "Cantidad de nodos rama: " + (arbolito.ImprimirPre() - arbolito.Hoja()) + "<p><p>";
                
            return cadena;
        }
        [WebMethod]
        public string HacerTableroL0(string archivo)
        {

            if (ejecutarComando("dot -Tjpg C:/Users/User/Desktop/G/" + archivo + ".txt" + " -o C:/Users/User/Desktop/G/Tablero/" + archivo + (++L0) + ".jpg"))
            {
                MemoryStream ms = new MemoryStream();
                Image imagen = Image.FromFile("C:\\Users\\User\\Desktop\\G\\Tablero\\" + archivo + L0 + ".jpg");

                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                string base64string = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                return base64string;
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                Image imagen = Image.FromFile("C:\\Users\\User\\Desktop\\G\\problemas.jpg");
                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                string base64string = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                return base64string;
            }
        }
        [WebMethod]
        public string HacerTableroL1(string archivo)
        {

            if (ejecutarComando("dot -Tjpg C:/Users/User/Desktop/G/" + archivo + ".txt" + " -o C:/Users/User/Desktop/G/Tablero/" + archivo + (++L1) + ".jpg"))
            {
                MemoryStream ms = new MemoryStream();
                Image imagen = Image.FromFile("C:\\Users\\User\\Desktop\\G\\Tablero\\" + archivo + L1 + ".jpg");

                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                string base64string = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                return base64string;
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                Image imagen = Image.FromFile("C:\\Users\\User\\Desktop\\G\\problemas.jpg");
                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                string base64string = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                return base64string;
            }
        }
        [WebMethod]
        public string HacerTableroL2(string archivo)
        {

            if (ejecutarComando("dot -Tjpg C:/Users/User/Desktop/G/" + archivo + ".txt" + " -o C:/Users/User/Desktop/G/Tablero/" + archivo + (++ContadorTablero) + ".jpg"))
            {
                MemoryStream ms = new MemoryStream();
                Image imagen = Image.FromFile("C:\\Users\\User\\Desktop\\G\\Tablero\\" + archivo + ContadorTablero + ".jpg");

                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                string base64string = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                return base64string;
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                Image imagen = Image.FromFile("C:\\Users\\User\\Desktop\\G\\problemas.jpg");
                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                string base64string = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                return base64string;
            }
        }
        [WebMethod]
        public string HacerTableroL3(string archivo)
        {

            if (ejecutarComando("dot -Tjpg C:/Users/User/Desktop/G/" + archivo + ".txt" + " -o C:/Users/User/Desktop/G/Tablero/" + archivo + (++ContadorTablero) + ".jpg"))
            {
                MemoryStream ms = new MemoryStream();
                Image imagen = Image.FromFile("C:\\Users\\User\\Desktop\\G\\Tablero\\" + archivo + ContadorTablero + ".jpg");

                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                string base64string = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                return base64string;
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                Image imagen = Image.FromFile("C:\\Users\\User\\Desktop\\G\\problemas.jpg");
                imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                string base64string = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                return base64string;
            }
        }
        [WebMethod]
        public string Ganados()
        {
            ListasOrdenadas gano = new ListasOrdenadas(0, arbolito.Raiz);
            return gano.generarLista(0);
        }
        [WebMethod]
        public string Prom()
        {
            ListasOrdenadas nuevo = new ListasOrdenadas(1, arbolito.Raiz);
            return nuevo.generarLista(1);
        }

    }
}
