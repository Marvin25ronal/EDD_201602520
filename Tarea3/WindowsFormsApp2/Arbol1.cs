using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    
    class Arbol1
    {
        string aux = "";
        string aux1 = "";
        string aux2 = "";
        NodoArbol raiz;
  
    public Arbol1()
        {
            raiz = null;
        }
        public void insertarNodo(int valor)
        {
           raiz= insertarNodo( valor, raiz);
        }
        public NodoArbol insertarNodo(int valor,NodoArbol nodo)
        {
           
            if (nodo == null)
            {
                nodo = new NodoArbol(valor);
            }
            else if(valor<nodo.Numero)
            {
                NodoArbol izquierdo;
                izquierdo = insertarNodo(valor, nodo.Izquierdo);
                nodo.Izquierdo=izquierdo;
            }
            else if (valor>nodo.Numero)
            {
                NodoArbol derecho;
                derecho = insertarNodo(valor, nodo.Derecho);
                nodo.Derecho = derecho;

            }
            return nodo;
        }
       

        private string ImprimirIn(NodoArbol reco)
        {
            if (reco != null)
            {
               
                ImprimirIn(reco.Izquierdo);
                aux += reco.Numero + " ";
                ImprimirIn(reco.Derecho);
               
            }
            return aux;
        }

        public string ImprimirIn()
        {
            string extra = "";
            extra=ImprimirIn(raiz);
            aux = "";
            return extra;
        }
        private string Pos(NodoArbol reco)
        {
            if (reco != null)
            {

                Pos(reco.Izquierdo);
               
                Pos(reco.Derecho);
                aux2 += reco.Numero + " ";

            }
            return aux2;
        }

        public string Pos()
        {
            string extra = "";
            extra = Pos(raiz);
            aux1 = "";
            return extra;
        }
        private string Pre(NodoArbol reco)
        {
            if (reco != null)
            {
                aux1 += reco.Numero + " ";
                Pre(reco.Izquierdo);

                Pre(reco.Derecho);
               

            }
            return aux1;
        }

        public string Pre()
        {
            string extra = "";
            extra = Pre(raiz);
            aux2 = "";
            return extra;
        }







    }


}
