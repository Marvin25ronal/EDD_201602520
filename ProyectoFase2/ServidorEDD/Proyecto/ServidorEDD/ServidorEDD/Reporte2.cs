using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorEDD
{
    public class Reporte2
    {
        ListaOrdenada2 lista;
        ListaOrdenada2 unidadesEliminadas;
        string codigocontactos = "";
        public Reporte2()
        {
            lista = new ListaOrdenada2();
            unidadesEliminadas = new ListaOrdenada2();
        }
      
        public void insertarListaContactos(NodoArbol raiz)
        {
            if (raiz != null)
            {
                NodoContactos nuevo = new NodoContactos(raiz.Nickname, raiz.ArbolitoAvl.Numeronodos1);
                lista.InsertarOrdenada(nuevo);
                insertarListaContactos(raiz.Derecho);
                insertarListaContactos(raiz.Izquierdo);
            }
        }
        public void insertarDestruidas(NodoArbol raiz)
        {
            if (raiz != null)
            {
                if(raiz.Lista.CabezaN!=null)
                {
                    NodoListaJuego aux1 = raiz.Lista.CabezaN;
                    int contador=0;
                    while (aux1 != null)
                    {
                        contador += aux1.Udestru;
                        aux1 = aux1.Siguiente;
                    }
                    NodoContactos nuevo = new NodoContactos(raiz.Nickname, contador);
                    unidadesEliminadas.InsertarOrdenada(nuevo);
                }
                insertarDestruidas(raiz.Derecho);
                insertarDestruidas(raiz.Izquierdo);
            }
        }
        public string Contactos()
        {
            codigocontactos = "";
            return Cadena(lista);
        }
        public string Destruidos()
        {
            codigocontactos = "";
            return Cadena(unidadesEliminadas);
        }
        public string Cadena(ListaOrdenada2 lista) 
        {
            codigocontactos += "Top \n ";
            NodoContactos aux;
            aux = lista.Primero;
            int contador = 0;
            int indice = 1;
            if (lista.Primero != null)
            {
                contador = lista.Primero.Contactos;
            }
            while (aux != null && indice <= 10)
            {
                codigocontactos += indice + " " + aux.Nombre + " numero de contactos " + aux.Contactos + " \n";
                aux = aux.Siguiente;
                indice++;
            }
            return codigocontactos;

        }
        
    }
    public class NodoContactos{
        
        NodoContactos siguiente;
        string nombre;
        int contactos;

        public NodoContactos(string nombre, int contactos)
        {
            this.Nombre = nombre;
            this.contactos = contactos;
             Siguiente = null;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Contactos { get => contactos; set => contactos = value; }
        public NodoContactos Siguiente { get => siguiente; set => siguiente = value; }
    }
    public class ListaOrdenada2
    {
        NodoContactos primero;
        NodoContactos ultimo;
        int cantidad;
       public ListaOrdenada2()
        {
            Primero = null;
            Ultimo = null;
            Cantidad = 0;
        }

        public int Cantidad { get => cantidad; set => cantidad = value; }
        public NodoContactos Primero { get => primero; set => primero = value; }
        public NodoContactos Ultimo { get => ultimo; set => ultimo = value; }

        public void InsertarOrdenada(NodoContactos n)
        {
            if (Primero == null)
            {
                Primero = n;
                Ultimo = n;
            }
            else
            {
                if (n.Contactos >= Primero.Contactos)
                {
                    n.Siguiente = Primero;
                    Primero = n;
                }
                else if (n.Contactos < Ultimo.Contactos)
                {
                    Ultimo.Siguiente = n;
                    Ultimo = n;
                }
                else
                {
                    for(NodoContactos aux = Primero; aux.Siguiente != null; aux = aux.Siguiente)
                    {
                        if (n.Contactos > aux.Siguiente.Contactos)
                        {
                            NodoContactos extra;
                            extra = aux.Siguiente;
                            aux.Siguiente = n;
                            n.Siguiente = extra;
                            break;
                        }
                    }
                }

              
            }
            Cantidad++;
        }
    }
}
