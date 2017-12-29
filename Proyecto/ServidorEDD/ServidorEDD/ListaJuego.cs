using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ServidorEDD
{
   public class ListaJuego
    {
       NodoListaJuego Cabeza;
        
        string codigo = "";
        int nodo = 0;
        public ListaJuego()
        {
            Cabeza = null;
        
        }
        public void insertar(string oponente,int desplegadas,int sobrevivientes,int destruidas,int gano,int id)
        {
            NodoListaJuego nuevo = new NodoListaJuego(oponente, desplegadas, sobrevivientes, destruidas, gano,id);
            nuevo.Siguiente = Cabeza;
            if (Cabeza != null)
            {
                Cabeza.Anterior = nuevo;
                
            }
            Cabeza = nuevo;

        }
       
        
        public string Codigo()
        {
            codigo = "";
            codigo += Codigo1();
            Codigo2();
            return codigo;
        }
        public string Codigo1()
        {
            NodoListaJuego temp;
            temp = Cabeza;
            string cadena = "";
            if (temp != null)
            {
                while (temp != null)
                {
                    cadena += "node"+temp.ID + "[label=\"{Oponente:" + temp.NicknameO + "|U destruidas:" + temp.Udestru + "|U desplegadas:" + temp.Udesple + "|U sobrevivientes:" + temp.USobre + "|Gano:" + temp.Ga + "}\"]\n";
                    temp = temp.Siguiente;
                }
            }

            return cadena;
        }
        public string Codigo2()
        {
            NodoListaJuego aux = Cabeza;
            if(aux!=null)
            while (aux.Siguiente != null)
            {
                codigo += "node"+aux.ID + "->" +"node"+ aux.Siguiente.ID+"; \n";
                    codigo += "node" + aux.Siguiente.ID + "->" + "node" + aux.Siguiente.Anterior.ID + "; \n";  
                 aux = aux.Siguiente;
            }
            return codigo;
        }
        public NodoListaJuego CabezaN
        {
            set { Cabeza = value; }
            get { return Cabeza; }
        }

    }
}
