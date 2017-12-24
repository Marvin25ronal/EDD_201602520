using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class NodoArbol
    {
        int numero;
        NodoArbol derecho;
        NodoArbol izquierdo;
        public NodoArbol(int numero)
        {
            this.numero = numero;
            derecho = null;
            izquierdo = null;

        }
       public int Numero
        {
            set { numero = value; }
            get { return numero; }
        }

        internal NodoArbol Derecho { get => derecho; set => derecho = value; }
        internal NodoArbol Izquierdo { get => izquierdo; set => izquierdo = value; }
    }
}
