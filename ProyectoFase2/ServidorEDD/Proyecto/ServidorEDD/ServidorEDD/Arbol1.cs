using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ServidorEDD
{
    
   public  class Arbol1
    {
        NodoArbol raiz;
        string cadena = "";
        string codi1="";
        string codi2 ="";
        string codi3 ="";
        string codigo="";
        string consola = "";
        string jugador1 = "";
        string jugador2 = "";
        string Consola = "";
        int turno = 0;
        int contador=0;

        public NodoArbol Raiz { get => raiz; set => raiz = value; }
        public string Jugador1 { get => jugador1; set => jugador1 = value; }
        public string Jugador2 { get => jugador2; set => jugador2 = value; }
        public int Turno { get => turno; set => turno = value; }
        public string Consola1 { get => Consola; set => Consola = value; }

        public Arbol1()
        {
            Raiz = new NodoArbol("Marvin25", "Marvin25", "marvin1ronal@gmail.com", 0);
        }
        public void insertarNodo(string nickame, string contrasena, string correo, int conectado)
        {
           Raiz= insertarNodo(nickame, contrasena, correo, conectado, Raiz);
        }
        public NodoArbol insertarNodo(string nickname,string contrasena,string correo,int conectado,NodoArbol nodo)
        {
           
            if (nodo == null)
            {
                nodo = new NodoArbol(nickname, contrasena, correo, conectado);
            }
            else if(nickname.CompareTo(nodo.Nickname)<0)
            {
                NodoArbol izquierdo;
                izquierdo = insertarNodo(nickname, contrasena, correo, conectado, nodo.Izquierdo);
                nodo.Izquierdo=izquierdo;
            }
            else if (nickname.CompareTo(nodo.Nickname) > 0)
            {
                NodoArbol derecho;
                derecho = insertarNodo(nickname, contrasena, correo, conectado, nodo.Derecho);
                nodo.Derecho = derecho;

            }
            return nodo;
        }
       

        private string ImprimirPre(NodoArbol reco)
        {
            if (reco != null)
            {
                contador++;
                ImprimirPre(reco.Izquierdo);
                cadena += reco.Nickname + "<p>";
                ImprimirPre(reco.Derecho);
               
            }
            return cadena;
        }

        public int ImprimirPre()
        {
            cadena = "";
            contador = 0;
            ImprimirPre(Raiz);
            return contador;
           
        }
        public string Pre()
        {
            cadena = "";
            contador = 0;
            ImprimirPre(Raiz);
            return cadena;
        }


        public string Codigo()
        {
           
            codi1 = codi2 = codi3 = codigo="";
            return Codigo(Raiz)+ Codigo2(Raiz)+Codigo3(Raiz);
        }
        public string Codigo(NodoArbol aux)
        {
            if (aux != null)
            {
                Codigo(aux.Izquierdo);
                codi1+=aux.Nickname+"[label=\" < f0 > |{ < f1 >"+aux.Nickname+"|"+aux.Correo+"|"+aux.Contrasena+"|conectado:"+aux.Conectado+"}| < f2 > \"];";
                Codigo(aux.Derecho);
            }
            return codi1;


        }
        public string Codigo3(NodoArbol aux)
        {
            if (aux != null)
            {
                Codigo3(aux.Izquierdo);
                if (aux.Lista.CabezaN != null)
                {
                    
                    codigo+= aux.Nickname + "->"+"node"+aux.Lista.CabezaN.ID+";\n";
                    codigo+= aux.Lista.Codigo();
                   
                }
               
               
                Codigo3(aux.Derecho);
            }
            return codigo;


        }
        public string Codigo2(NodoArbol aux)
        {
           
            if (aux.Izquierdo != null)
            {
               codi2+="\"" + aux.Nickname + "\":f0->\"" + aux.Izquierdo.Nickname + "\":f1;";
                Codigo2(aux.Izquierdo);
            }
            if (aux.Derecho != null)
            {
                codi2+="\"" + aux.Nickname + "\":f2->\"" + aux.Derecho.Nickname + "\":f1;";
                Codigo2(aux.Derecho);
            }
            return codi2;

        }
        public NodoArbol Buscar(string nickname)
        {
            if (Raiz == null)
            {
                return null;
            }
            else
            {
                return localizar(Raiz, nickname);
            }
        }
        public NodoArbol localizar(NodoArbol anterior,string nickname)
        {
            if (anterior == null)
            {
                return null;
            }
            else if (nickname == anterior.Nickname)
            {
                return anterior;
            }else if (nickname.CompareTo(anterior.Nickname) < 0)
            {
                return localizar(anterior.Izquierdo,nickname);
            }
            else 
            {
                return localizar(anterior.Derecho, nickname);
            }
        }
        public void Eliminar(string nickname)
        {
            Raiz = Eliminar(nickname, Raiz);
        }
        public NodoArbol Eliminar(string nickname,NodoArbol nodo)
        {
            if (nickname.CompareTo(nodo.Nickname) < 0)
            {
                NodoArbol izquierdo;
                izquierdo = Eliminar(nickname, nodo.Izquierdo);
                nodo.Izquierdo = izquierdo;
            }
            else if (nickname.CompareTo(nodo.Nickname) > 0)
            {
                NodoArbol Derecho;
                Derecho = Eliminar(nickname, nodo.Derecho);
                nodo.Derecho = Derecho;
            }
            else if (nickname.CompareTo(nodo.Nickname) == 0)
            {
                NodoArbol aux;
                aux = nodo;
                if (aux.Izquierdo == null)
                {
                    nodo = aux.Derecho;
                }else if (aux.Derecho == null)
                {
                    nodo = aux.Izquierdo;
                }
                else
                {
                    aux = remplazar(aux);
                }
                aux = null;       
            }
            return nodo;
        }
        private NodoArbol remplazar(NodoArbol nodo)
        {
            NodoArbol aux1, aux2;
            aux2 = nodo;
            aux1 = nodo.Izquierdo;
            while (aux1.Derecho != null)
            {
                aux2 = aux1;
                aux1 = aux1.Derecho;
            }
            nodo.Nickname = aux1.Nickname;
            nodo.Correo = aux1.Correo;
            nodo.Conectado = aux1.Conectado;
            nodo.Contrasena = aux1.Contrasena;
            nodo.Lista = aux1.Lista;

            if (aux2 == nodo)
            {
                aux2.Izquierdo=aux1.Izquierdo;
            }
            else
            {
                aux2.Derecho = aux1.Izquierdo;
            }
            return nodo;

        }
        public void ObtenerDatos(string nickname)
        {
            NodoArbol cambiar;
            cambiar = Buscar(nickname);
            Console.WriteLine(cambiar.Nickname + " " + cambiar.Contrasena + " " + cambiar.Correo);
        }
        public void Actualizar(string nickname,string nuevoname,string correo,string contrasena,int estado)
        {
            NodoArbol aux = Buscar(nickname);
            ListaJuego lista = aux.Lista;
            ArbolAVL arbol = aux.ArbolitoAvl;
            Eliminar(nickname);
            insertarNodo(nuevoname, contrasena, correo, estado);
            NodoArbol nuevo = Buscar(nuevoname);
            nuevo.Lista = lista;
            nuevo.ArbolitoAvl = arbol;
        }
        public void CambiarEstado(string Nombre)
        {
            NodoArbol aux = Buscar(Nombre);
            if (aux.Conectado == true)
            {
                aux.Conectado = false;
            }
            else if(aux.Conectado==false)
            {
                aux.Conectado = true;
            }
        }
        public void limpiarcadena()
        {
            codigo = "";
        }
        public int Level()
        {
            return Nivel(Raiz);
        }
        public int Nivel(NodoArbol nodo)
        {
            if (nodo.Izquierdo == null && nodo.Derecho == null)
                return 0;
            else if (nodo.Izquierdo == null)
                return 1 + Nivel(nodo.Derecho);
            else if (nodo.Derecho == null)
                return 1 + Nivel(nodo.Izquierdo);
            else
                return 1 + Math.Max(Nivel(nodo.Izquierdo), Nivel(nodo.Derecho));

        }
        public int Hoja()
        {
           return NodosHoja(Raiz);
        }
        public int NodosHoja(NodoArbol nodo)
        {
            if (nodo == null)
                return 0;

            if (nodo.Izquierdo == null && nodo.Derecho == null)
                return 1;

            else
            {
                return NodosHoja(nodo.Derecho) + NodosHoja(nodo.Izquierdo);
            }
        }
        public void CopiarDatosParaEliminar(NodoArbol raix,string contacto)
        {
            if (raix != null)
            {
                NodoAVL aux = raix.ArbolitoAvl.Buscar(contacto);
                if (aux != null)
                {
                    aux.Nickname = aux.Usuario.Nickname;
                    aux.Correo = aux.Usuario.Correo;
                    aux.Conectado = aux.Usuario.Conectado;
                    aux.Contrasena = aux.Usuario.Contrasena;
                    aux.Usuario = null;
                        
                }
                CopiarDatosParaEliminar(raix.Derecho, contacto);
                CopiarDatosParaEliminar(raix.Izquierdo, contacto);
            }
        }
        public void Copiar(string contacto)
        {
            CopiarDatosParaEliminar(Raiz,contacto);
        }
        

    }

    
}
