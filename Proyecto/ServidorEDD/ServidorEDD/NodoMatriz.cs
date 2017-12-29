using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorEDD
{
    public class NodoMatriz
    { NodoMatriz norte;
        NodoMatriz sur;
        NodoMatriz oeste;
        NodoMatriz este;
        NodoMatriz Arriba;
        NodoMatriz Abajo;
        Objeto datos;
        int posx, posy;
       
        public NodoMatriz(Objeto datos_,int x,int y)
        {
            this.datos = datos_;
            this.Posx = x;
            this.Posy = y;
            
            Norte = Sur = Oeste = Este = null;
        }
        public NodoMatriz(int x, int y)
        {
            this.datos = null;
            this.Posx = x;
            this.Posy = y;
            
            Norte = Sur = Oeste = Este = null;
        }


        public NodoMatriz Norte { get => norte; set => norte = value; }
        public NodoMatriz Sur { get => sur; set => sur = value; }
        public NodoMatriz Oeste { get => oeste; set => oeste = value; }
        public NodoMatriz Este { get => este; set => este = value; }
        public Objeto Datos { get => datos; set => datos = value; }
        public int Posx { get => posx; set => posx = value; }
        public int Posy { get => posy; set => posy = value; }
        public NodoMatriz Arriba1 { get => Arriba; set => Arriba = value; }
        public NodoMatriz Abajo1 { get => Abajo; set => Abajo = value; }
    }
}