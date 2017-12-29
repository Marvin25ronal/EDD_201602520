using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorEDD
{
    public class Espejo
    {
        NodoArbol raiz;
        string cadena = "";
        string codi1 = "";
        string codi2 = "";
        string codi3 = "";
        string codigo = "";
        public Espejo()
        {
            raiz = new NodoArbol("Marvin25", "Marvin25", "marvin1ronal@gmail.com", 0);
        }
        public void insertarNodo(string nickame, string contrasena, string correo, int conectado)
        {
            raiz = insertarNodo(nickame, contrasena, correo, conectado, raiz);
        }
        public NodoArbol insertarNodo(string nickname, string contrasena, string correo, int conectado, NodoArbol nodo)
        {

            if (nodo == null)
            {
                nodo = new NodoArbol(nickname, contrasena, correo, conectado);
            }
            else if (nickname.CompareTo(nodo.Nickname) > 0)
            {
                NodoArbol izquierdo;
                izquierdo = insertarNodo(nickname, contrasena, correo, conectado, nodo.Izquierdo);
                nodo.Izquierdo = izquierdo;
            }
            else if (nickname.CompareTo(nodo.Nickname) < 0)
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

                ImprimirPre(reco.Izquierdo);
                cadena += reco.Nickname + "<p>";
                ImprimirPre(reco.Derecho);

            }
            return cadena;
        }

        public string ImprimirPre()
        {
            cadena = "";
            ImprimirPre(raiz);
            return cadena;

        }


        public string Codigo()
        {

            codi1 = codi2 = codi3 = codigo = "";
            return Codigo(raiz) + Codigo2(raiz) + Codigo3(raiz);
        }
        public string Codigo(NodoArbol aux)
        {
            if (aux != null)
            {
                Codigo(aux.Izquierdo);
                codi1 += aux.Nickname + "[label=\" < f0 > |{ < f1 >" + aux.Nickname + "|" + aux.Correo + "|" + aux.Contrasena + "|conectado:" + aux.Conectado + "}| < f2 > \"];";
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

                    codigo += aux.Nickname + "->" + "node" + aux.Lista.CabezaN.ID + ";\n";
                    codigo += aux.Lista.Codigo();

                }


                Codigo3(aux.Derecho);
            }
            return codigo;


        }
        public string Codigo2(NodoArbol aux)
        {

            if (aux.Izquierdo != null)
            {
                codi2 += "\"" + aux.Nickname + "\":f0->\"" + aux.Izquierdo.Nickname + "\":f1;";
                Codigo2(aux.Izquierdo);
            }
            if (aux.Derecho != null)
            {
                codi2 += "\"" + aux.Nickname + "\":f2->\"" + aux.Derecho.Nickname + "\":f1;";
                Codigo2(aux.Derecho);
            }
            return codi2;

        }
        public NodoArbol Buscar(string nickname)
        {
            if (raiz == null)
            {
                return null;
            }
            else
            {
                return localizar(raiz, nickname);
            }
        }
        public NodoArbol localizar(NodoArbol anterior, string nickname)
        {
            if (anterior == null)
            {
                return null;
            }
            else if (nickname == anterior.Nickname)
            {
                return anterior;
            }
            else if (nickname.CompareTo(anterior.Nickname) > 0)
            {
                return localizar(anterior.Izquierdo, nickname);
            }
            else
            {
                return localizar(anterior.Derecho, nickname);
            }
        }
        public void Eliminar(string nickname)
        {
            raiz = Eliminar(nickname, raiz);
        }
        public NodoArbol Eliminar(string nickname, NodoArbol nodo)
        {
            if (nickname.CompareTo(nodo.Nickname) > 0)
            {
                NodoArbol izquierdo;
                izquierdo = Eliminar(nickname, nodo.Izquierdo);
                nodo.Izquierdo = izquierdo;
            }
            else if (nickname.CompareTo(nodo.Nickname) < 0)
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
                }
                else if (aux.Derecho == null)
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
                aux2.Izquierdo = aux1.Izquierdo;
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
        public void Actualizar(string nickname, string nuevoname, string correo, string contrasena, int estado)
        {
            NodoArbol aux = Buscar(nickname);
            ListaJuego lista = aux.Lista;
            Eliminar(nickname);
            insertarNodo(nuevoname, contrasena, correo, estado);
            NodoArbol nuevo = Buscar(nuevoname);
            nuevo.Lista = lista;
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


    }
}