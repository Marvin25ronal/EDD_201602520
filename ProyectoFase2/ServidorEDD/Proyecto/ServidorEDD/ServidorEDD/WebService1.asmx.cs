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
        static TablaHash Tabla;
        static int contadorArbolNormal=0;
        static int id = 0;
        static int contadorEspejo = 0;
        static int ContadorTablero = 0;
        static int L0=0, L1=0, L2=0, L3 = 0;
        static int D1=0 , D2 = 0,D3 = 0,D4 = 0;
        static int hash = 0;
        static string codigo="";
        
        static int Contac = 0;

        public static string Codigo { get => codigo; set => codigo = value; }

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
        public string CargarContactos(string nickname)
        {
            NodoArbol aux = arbolito.Buscar(nickname);
            if (aux != null)
            {
                return aux.ArbolitoAvl.ImprimirPre(aux.ArbolitoAvl.Caiz);
            }
            return "";
           
        }
        [WebMethod]
        public bool MeterContacto(string nickname,string contacto,string contrasena,string correo,int conectado)
        {
            if (arbolito.Buscar(nickname) != null)
            {
                NodoArbol aux = arbolito.Buscar(nickname);
                aux.ArbolitoAvl.insertar(contacto, contrasena, correo, arbolito.Buscar(contacto), conectado);
                return true;
            }
            return false;
        }
        [WebMethod]
        public bool ExisteContacto(string nickname,string contacto)
        {
            NodoArbol aux1 = arbolito.Buscar(nickname);
            if (aux1 != null)
            {
                if (aux1.ArbolitoAvl.Buscar(contacto) == null)
                {
                    return false;
                }
            }
            return true;
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
                NodoArbol aux = arbolito.Buscar(nuevonickname);
                ActualizarDemas(arbolito.Raiz, nickname,nuevonickname,aux);
                return true;
            }
            return false;
        }
        public void ActualizarDemas(NodoArbol rai,string nickname,string nuevo,NodoArbol aux)
        {
            
            if (rai != null)
            {
                if (rai.ArbolitoAvl.Buscar(nickname) != null)
                {
                    rai.ArbolitoAvl.EliminarAvl(nickname);
                    rai.ArbolitoAvl.insertar("h","h","h",aux,0);
                }
                ActualizarDemas(rai.Derecho, nickname, nuevo, aux);
                ActualizarDemas(rai.Izquierdo, nickname, nuevo, aux);
            }
        }
        [WebMethod]
        public bool EliminarUsuario(string nickname)
        {
            if (arbolito.Buscar(nickname) != null)
            {
                //Copiar datos antes
                arbolito.Copiar(nickname);
              //  Tabla.eliminar(nickname);    
                arbolito.Eliminar(nickname);
                Espejo.Eliminar(nickname);
                return true;
            }
            return false;
        }
        [WebMethod]
        public bool EliminarContacto(string nickname,string contacto)
        {
            NodoArbol aux = arbolito.Buscar(nickname);
            if (aux.ArbolitoAvl.Buscar(contacto) != null)
            {
                
                aux.ArbolitoAvl.EliminarAvl(contacto);
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
        public void GenerarContac(string nickname)
        {
            string codigo = "digraph G { \n";
            codigo += "node[shape=record,style=filled];\n";
            NodoArbol aux = arbolito.Buscar(nickname);
            codigo += aux.ArbolitoAvl.CodigoAVl();
            codigo += "}";

            string ruta = "C:\\Users\\User\\Desktop\\G\\Contactos.txt";
            try
            {
                File.WriteAllText(ruta, codigo);
            }
            catch (Exception ex)
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
        public void GenerarDestruidas()
        {
            string ruta = "C:\\Users\\User\\Desktop\\G\\DestruL0.txt";
            string ruta2 = "C:\\Users\\User\\Desktop\\G\\DestruL1.txt";
            string ruta3 = "C:\\Users\\User\\Desktop\\G\\DestruL2.txt";
            string ruta4 = "C:\\Users\\User\\Desktop\\G\\DestruL3.txt";
            try
            {
                File.WriteAllText(ruta, eliminados.CodigoNivel0());
                File.WriteAllText(ruta2, eliminados.CodigoNivel1());
                File.WriteAllText(ruta3, eliminados.CodigoNivel2());
                File.WriteAllText(ruta4, eliminados.CodigoNivel3());
            }
            catch (Exception ex)
            {

            }
        }
        [WebMethod]
        public void GenerarSobrevivientes()
        {
            string ruta = "C:\\Users\\User\\Desktop\\G\\Vivos0.txt";
            string ruta2 = "C:\\Users\\User\\Desktop\\G\\Vivos1.txt";
            string ruta3 = "C:\\Users\\User\\Desktop\\G\\Vivos2.txt";
            string ruta4 = "C:\\Users\\User\\Desktop\\G\\Vivos3.txt";
            try
            {
                File.WriteAllText(ruta, vivos.CodigoNivel0());
                File.WriteAllText(ruta2, vivos.CodigoNivel1());
                File.WriteAllText(ruta3, vivos.CodigoNivel2());
                File.WriteAllText(ruta4, vivos.CodigoNivel3());
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


            ///jajajjajaa
            try
            {
                Process a = new Process();
                a.StartInfo.FileName = "\"C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe\"";
                a.StartInfo.Arguments = comando;
                a.StartInfo.UseShellExecute = false;
                a.Start();
                a.WaitForExit();
                a.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        
        [WebMethod]
        public string ConvertirContactos(string archivo)
        {

            if (ejecutarComando("dot -Tjpg C:/Users/User/Desktop/G/" + archivo + ".txt" + " -o C:/Users/User/Desktop/G/ArbolNormal/" + archivo + (++Contac) + ".jpg"))
            {
                MemoryStream ms = new MemoryStream();
                Image imagen = Image.FromFile("C:\\Users\\User\\Desktop\\G\\ArbolNormal\\" + archivo + Contac + ".jpg");

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
                Image imagen = Image.FromFile("C:\\Users\\User\\Desktop\\G\\Tablero\\" + archivo + contadorEspejo + ".jpg");

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
        public string HacerDestruL0(string archivo)
        {

            if (ejecutarComando("dot -Tjpg C:/Users/User/Desktop/G/" + archivo + ".txt" + " -o C:/Users/User/Desktop/G/Tablero/" + archivo + (++D1) + ".jpg"))
            {
                MemoryStream ms = new MemoryStream();
                Image imagen = Image.FromFile("C:\\Users\\User\\Desktop\\G\\Tablero\\" + archivo + D1 + ".jpg");

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
        public string HacerDestruL1(string archivo)
        {

            if (ejecutarComando("dot -Tjpg C:/Users/User/Desktop/G/" + archivo + ".txt" + " -o C:/Users/User/Desktop/G/Tablero/" + archivo + (++D2) + ".jpg"))
            {
                MemoryStream ms = new MemoryStream();
                Image imagen = Image.FromFile("C:\\Users\\User\\Desktop\\G\\Tablero\\" + archivo + D2 + ".jpg");

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
        public string HacerDestruL2(string archivo)
        {

            if (ejecutarComando("dot -Tjpg C:/Users/User/Desktop/G/" + archivo + ".txt" + " -o C:/Users/User/Desktop/G/Tablero/" + archivo + (++D3) + ".jpg"))
            {
                MemoryStream ms = new MemoryStream();
                Image imagen = Image.FromFile("C:\\Users\\User\\Desktop\\G\\Tablero\\" + archivo + D3 + ".jpg");

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
        public string HacerDestruL4(string archivo)
        {

            if (ejecutarComando("dot -Tjpg C:/Users/User/Desktop/G/" + archivo + ".txt" + " -o C:/Users/User/Desktop/G/Tablero/" + archivo + (++D4) + ".jpg"))
            {
                MemoryStream ms = new MemoryStream();
                Image imagen = Image.FromFile("C:\\Users\\User\\Desktop\\G\\Tablero\\" + archivo + D4 + ".jpg");

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
        [WebMethod]
        public void InsertarHash()
        {
            Tabla = new TablaHash();
            InsertarTablaHash(arbolito.Raiz);
        }
        public void InsertarTablaHash(NodoArbol raiz) 
        {
            if (raiz != null)
            {
                if (Tabla.buscarNodo(raiz.Nickname) == null)
                {
                    NodoHash nuevo = new NodoHash(raiz.Nickname, raiz.Correo, raiz.Contrasena);
                    Tabla.insertar(nuevo);
                }
                InsertarTablaHash(raiz.Izquierdo);
                InsertarTablaHash(raiz.Derecho);
            }
           
        }
        [WebMethod]
        public void GenerarTablaHash()
        {
            string codigo = "digraph G { \n";
            codigo += "node[shape=record,style=filled];\n";
            codigo += Tabla.CodigoHash();
            codigo += "}";

            string ruta = "C:\\Users\\User\\Desktop\\G\\Hash.txt";
            try
            {
                File.WriteAllText(ruta, codigo);
                Tabla = null;
            }
            catch (Exception ex)
            {

            }
        }
        [WebMethod]
        public string HacerHash(string archivo)
        {
            if (ejecutarComando("dot -Tjpg C:/Users/User/Desktop/G/" + archivo + ".txt" + " -o C:/Users/User/Desktop/G/Tablero/" + archivo + (++hash) + ".jpg"))
            {
                MemoryStream ms = new MemoryStream();
                Image imagen = Image.FromFile("C:\\Users\\User\\Desktop\\G\\Tablero\\" + archivo + hash + ".jpg");

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
        public string TopMasContactos()
        {
            Reporte2 n = new Reporte2();
            n.insertarListaContactos(arbolito.Raiz);
            return n.Contactos();
        }
        [WebMethod]
        public string TopMasDestruidos()
        {
            Reporte2 n = new Reporte2();
            n.insertarDestruidas(arbolito.Raiz);
            return n.Destruidos();
        }
        [WebMethod]
        public void asignarUsuario(string usuario)
        {
            if (string.IsNullOrEmpty(arbolito.Jugador1) == true)
            {
                arbolito.Jugador1 = usuario;
            }
            else if (string.IsNullOrEmpty(arbolito.Jugador2) == true)
            {
                arbolito.Jugador2 = usuario;
            }
          
        }
        [WebMethod]
        public string usuario1()
        {
            return arbolito.Jugador1;

        }

        [WebMethod]
        public string usuario2()
        {
            return arbolito.Jugador2;

        }
       [WebMethod]
       public void setcosola(string n)
        {
            arbolito.Consola1 = n;
        }
        [WebMethod]
        public string getConsola()
        {
            return arbolito.Consola1;
        }
        [WebMethod]
        public bool puedeColocarseI(string x,int y)
        {
            int xaux = tablero.Numero(x);
            if (xaux <= tablero.Tamx && y <= tablero.Tamy)
            {
                return true;
            }
            return false;
        }
        [WebMethod]
        public bool ExisteUnoEnesaPos(string objeto, string x,int y)
        {
            Unidad nuevo = new Unidad(objeto);
            NodoMatriz aux=tablero.Clip1;
            if (nuevo.Nivel == 0) { aux = tablero.Clip1.Abajo1; }
           else if (nuevo.Nivel == 1) { aux = tablero.Clip1; }
            else if (nuevo.Nivel == 2) { aux = tablero.Clip1.Arriba1; }
           else if (nuevo.Nivel == 3) { aux = tablero.Clip1.Arriba1.Arriba1; }
            if (tablero.Existe(aux, tablero.Numero(x), y)==true){
                return true;

            }
            return false;
        }
        [WebMethod]
        public void Mover(string objeto, string xan, int yan,string x,int y)
        {
            Unidad nuevo = new Unidad(objeto);
            NodoMatriz aux = tablero.Clip1;
            if (nuevo.Nivel == 0) { aux = tablero.Clip1.Abajo1; }
            else if (nuevo.Nivel == 1) { aux = tablero.Clip1; }
            else if (nuevo.Nivel == 2) { aux = tablero.Clip1.Arriba1; }
            else if (nuevo.Nivel == 3) { aux = tablero.Clip1.Arriba1.Arriba1; }
            NodoMatriz mover = tablero.obtener(aux, tablero.Numero(xan), yan);
            Objeto nuev = new Objeto(mover.Datos1.Jugador, mover.Datos1.Unidad, mover.Datos1.Vida, mover.Datos1.Movimiento, mover.Datos1.Alcance, mover.Datos1.Dano, 1);


            tablero.insertar(nuev, tablero.Numero(x), y, nuevo.Nivel);
            tablero.eliminar(tablero.Numero(xan), yan, nuevo.Nivel);

        } 
    }
}
