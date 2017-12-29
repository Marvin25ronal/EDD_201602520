using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorEDD
{
   public class NodoOrdenado
    {
        string usuario;
        double valor;
        NodoOrdenado siguiente;
        public NodoOrdenado(string usuario, double valor)
        {
            this.Usuario = usuario;
            this.Valor = valor;
        }

        public string Usuario { get => usuario; set => usuario = value; }
        public double Valor { get => valor; set => valor = value; }
        public NodoOrdenado Siguiente
        {
            get => siguiente; set => siguiente = value;
        }
    }
   




    public class ListasOrdenadas
    {
        NodoOrdenado primero;

        public ListasOrdenadas(int t, NodoArbol raiz)
        {
            if (t == 0) generarTop10(raiz);
            else generarPromedios(raiz);
        }

        public void insertar(string nombre, double entrada)
            {
            NodoOrdenado nuevo;
                nuevo = new NodoOrdenado(nombre,entrada);
                if (primero == null) primero = nuevo;
                else if (entrada > primero.Valor)
                {
                    nuevo.Siguiente=primero;
                    primero = nuevo;
                }
                else {
                NodoOrdenado anterior, p;
                    anterior = p = primero;
                    while ((p.Siguiente != null) && (entrada < p.Valor))
                    {
                        anterior = p;
                        p = p.Siguiente;
                    }
                    if (entrada < p.Valor) anterior = p;
                    nuevo.Siguiente=anterior.Siguiente;
                    anterior.Siguiente=nuevo;
                }               
            }

        public void generarTop10(NodoArbol raiz)
        {
            if (raiz != null)
            {
                insertar(raiz.Nickname, contarDatos(raiz.Lista));
                generarTop10(raiz.Izquierdo);
                generarTop10(raiz.Derecho);
            }
        }
        public void generarPromedios(NodoArbol raiz)
        {
            if (raiz != null)
            {
                insertar(raiz.Nickname, contarDouble(raiz.Lista));
                generarPromedios(raiz.Izquierdo);
                generarPromedios(raiz.Derecho);
            }
        }
        double contarDouble(ListaJuego juegos)
        {
            double contador = 0;
            double veces=0;
            NodoListaJuego aux;
            for (aux = juegos.CabezaN; aux != null; aux = aux.Siguiente)
            {
                contador += ((double)aux.Udestru /(double) aux.Udesple);
                veces++;
            }
            if (veces != 0) return (contador/veces)*100;
            else return 0;
        }

        int contarDatos(ListaJuego juegos)
        {
            int contador = 0;
            NodoListaJuego aux;
            for (aux = juegos.CabezaN; aux != null; aux = aux.Siguiente)
            {
                if (aux.Ga) contador++;
            }
            return contador;
        }

        public string generarLista(int param)
        {
            string texto = "";
            NodoOrdenado aux;
            int contador = 0;
            for (aux = primero; aux != null && contador<10; aux = aux.Siguiente,contador++) {
                if (contador == 10) break;
                if(param==0)texto +=(contador+1)+") Usuario: " + aux.Usuario + "            Veces que gano: " + aux.Valor + Environment.NewLine;
                if (param == 1) texto += (contador + 1) + ") Usuario: " + aux.Usuario + "            Porcentaje de victorias: " + (int)aux.Valor + "% "+Environment.NewLine;

            }
            return texto;

        }

        }
        
    }
