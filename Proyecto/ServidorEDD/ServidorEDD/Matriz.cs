using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ServidorEDD
{
    public class Matriz
    {
        NodoMatriz Clip;
        string jugador1;
        string jugador2;
        int Submarinos;
        int Barcos;
        int Aviones;
        int Satelites;
        int tamx;
        int tamy;
        int tipoJuego;
        string minutos;
        internal NodoMatriz Clip1 { get => Clip; set => Clip = value; }
        public string Jugador1 { get => jugador1; set => jugador1 = value; }
        public string Jugador2 { get => jugador2; set => jugador2 = value; }
        public int Submarinos1 { get => Submarinos; set => Submarinos = value; }
        public int Barcos1 { get => Barcos; set => Barcos = value; }
        public int Aviones1 { get => Aviones; set => Aviones = value; }
        public int Satelites1 { get => Satelites; set => Satelites = value; }
        public int Tamx { get => tamx; set => tamx = value; }
        public int Tamy { get => tamy; set => tamy = value; }
        public int TipoJuego { get => tipoJuego; set => tipoJuego = value; }
        public string Minutos { get => minutos; set => minutos = value; }

        public Matriz()
        {
            Clip = new NodoMatriz(0, 0);
            Clip.Abajo1 = new NodoMatriz(0, 0);
            Clip.Arriba1 = new NodoMatriz(0, 0);
            Clip.Arriba1.Arriba1 = new NodoMatriz(0, 0);
        }

        public void llenarConfig(string jugador1, string jugador2, int submarinos, int barcos, int aviones, int satelites, int tamx, int tamy, int tipoJuego, string minutos)
        {
            this.jugador1 = jugador1;
            this.jugador2 = jugador2;
            Submarinos = submarinos;
            Barcos = barcos;
            Aviones = aviones;
            Satelites = satelites;
            this.tamx = tamx;
            this.tamy = tamy;
            this.tipoJuego = tipoJuego;
            this.minutos = minutos;
        }

        public void IncertarCabeceras(NodoMatriz aux, int x)
        {
            if (aux == null) return;
            NodoMatriz nuevo = new NodoMatriz(x, 0);
            if (aux.Este == null)
            {
                aux.Este = nuevo;
                nuevo.Oeste = aux;
            }
            else
            {
                NodoMatriz anterior, actual;
                anterior = actual = aux;
                while (actual.Este != null && x > actual.Posx)
                {
                    anterior = actual;
                    actual = actual.Este;
                }
                if (x > actual.Posx) { anterior = actual; actual = null; }
                nuevo.Este = anterior.Este;
                nuevo.Oeste = anterior;
                if (actual != null) actual.Oeste = nuevo;
                anterior.Este = nuevo;


            }

        }
        public void InsertarVertical(NodoMatriz aux,int y)
        {
            if (aux == null) return;
            NodoMatriz nuevo = new NodoMatriz(0, y);
            if (aux.Sur == null)
            {
                aux.Sur = nuevo;
                nuevo.Norte = aux;
            }
            else
            {
                NodoMatriz anterior, actual;
                anterior = actual = aux;
                while(actual.Sur!=null&& y > actual.Posy)
                {
                    anterior = actual;
                    actual = actual.Sur;
                }
                if (y > actual.Posy) { anterior = actual;actual = null; }
                nuevo.Sur = anterior.Sur;
                nuevo.Norte = anterior;
                if (actual != null) actual.Norte = nuevo;
                anterior.Sur = nuevo;
            }

        }
       public bool CabecerasCre(NodoMatriz inicial,int x,int y)
        {
            bool existe = true;
            NodoMatriz aux = inicial;
            while (aux.Este != null && x > aux.Posx)
            {
                aux = aux.Este;
            }
            if (aux.Posx != x)
            {
                IncertarCabeceras(inicial, x);
                existe = false;
            }
            aux = inicial;
            while (aux.Sur != null && y > aux.Posy)
            {
                aux = aux.Sur;
            }
            if (aux.Posy != y)
            {
                InsertarVertical(inicial, y);
                existe = false;
            }
            return existe;

        }
        public bool Existe(NodoMatriz inicial,int x,int y)
        {
            NodoMatriz aux = inicial;
            while (aux.Este != null && x > aux.Posx) aux = aux.Este;
            if (aux.Posx != x) return false;
            while (aux.Sur != null && y > aux.Posy) aux = aux.Sur;
            if (aux.Posy != y) return false;
            return true;
        }
        public bool insertar(Objeto dato,int x,int y,int nivel)
        {
            NodoMatriz aux = null;
            if (nivel == 0) aux = Clip1.Abajo1;
            if (nivel == 1) aux = Clip1;
            if (nivel == 2) aux = Clip1.Arriba1;
            if (nivel == 3) aux = Clip1.Arriba1.Arriba1;
            if (dato == null || aux == null) return false;
            if (CabecerasCre(aux, x, y))
            {
                if (Existe(aux, x, y)) return false;
            }
            NodoMatriz nuevo=new NodoMatriz(dato, x, y);
            if (!InsetarEnX(aux, nuevo, x, y))
            {
                return false;
            }
            if (!InsertarEnY(aux, nuevo, x, y))
            {
                return false;
            }
            return true;
            
        }
        public bool InsetarEnX(NodoMatriz inicial,NodoMatriz nuevo,int x,int y)
        {
            NodoMatriz aux = inicial;
            while (aux.Este != null && x > aux.Posx) aux = aux.Este;
            if (aux.Posx != x) return false;
            NodoMatriz anterior, actual;
            anterior = actual = aux;
            while (actual.Sur != null && y > actual.Posy)
            {
                anterior = actual;
                actual = actual.Sur;
            }
            if (y > actual.Posy) { anterior = actual;actual = null; }
            nuevo.Sur = anterior.Sur;
            nuevo.Norte = anterior;
            if (actual != null) actual.Norte = nuevo;
            anterior.Sur = nuevo;
            return true;
        }
        public bool InsertarEnY(NodoMatriz inicial,NodoMatriz nuevo,int x,int y)
        {
            NodoMatriz aux = inicial;
            while (aux.Sur != null && y > aux.Posy) aux = aux.Sur;
            if (aux.Posy != y) return false;
            NodoMatriz anterior, actual;
            anterior = actual = aux;
            while(actual.Este!=null&&x>actual.Posx)
            {
                anterior = actual;
                actual = actual.Este;
            }
            if (x > actual.Posx) { anterior = actual; actual = null; }
                nuevo.Este = anterior.Este;
                nuevo.Oeste = anterior;
                if (actual != null) actual.Oeste = nuevo;
                anterior.Este = nuevo;
                return true;
            
        }
        public bool eliminar(int x,int y,int nivel)
        {
            NodoMatriz aux = null;
            if (nivel == 0) aux = Clip1.Abajo1;
            if (nivel == 1) aux = Clip1;
            if (nivel == 2) aux = Clip1.Arriba1;
            if (nivel == 3) aux = Clip1.Arriba1.Arriba1;
            if (aux == null) return false;
            return Eliminar2(aux, x, y);
        }
        public bool Eliminar2(NodoMatriz inicial,int x,int y)
        {
            if (y == 0 && x == y) return false;
            if (!Existe(inicial, x, y)) return false;
            NodoMatriz aux = inicial;
            while (aux.Este != null && x > aux.Posx) aux = aux.Este;
            if (aux.Posx != x) return false;
            while (aux.Sur != null && y > aux.Posy) aux = aux.Sur;
            if (aux.Posy != y) return false;
            if (aux == null) return false;
            aux.Norte.Sur = aux.Sur;
            if (aux.Sur != null) aux.Sur.Norte = aux.Norte;
            aux.Oeste.Este = aux.Este;
            if (aux.Este != null) aux.Este.Oeste = aux.Oeste;
            EliminarCabeceras(inicial, x, y);
            return true;
        }
        public void EliminarCabeceras(NodoMatriz inicial,int x,int y)
        {
            NodoMatriz aux = inicial;
            while (aux.Este != null && x > aux.Posx) aux = aux.Este;
            if (aux.Posx == x)
            {
                if (aux.Sur == null)
                {
                    aux.Oeste.Este = aux.Este;
                    if (aux.Este != null) aux.Este.Oeste = aux.Oeste;
                }
            }
            aux = inicial;
            while (aux.Sur != null && y > aux.Posy) aux = aux.Sur;
            if (aux.Posy == y)
            {
                if (aux.Este == null)
                {
                    aux.Norte.Sur = aux.Sur;
                    if (aux.Sur != null) aux.Sur.Norte = aux.Norte;
                }
            }
        }
        public int Numero(string name)
        {
            int numero = 0;
            for(int i = 0; i < name.Length; i++)
            {
                numero = numero * 26 + (name[i] - ('A' - 1));
            }
            return numero;
        }
        public string Nombre(int number)
        {
            StringBuilder sb = new StringBuilder();
            while (number-- > 0)
            {
                sb.Append((char)('A' + (number % 26)));
                number /= 26;
            }
            char[] charArray = sb.ToString().ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public string CodigoNivel0()
        {
            string sintaxis = "digraph g{ \n node[shape=record,style=filled,color=midnightblue,fontcolor=white];\n";
            sintaxis += Codigo(Clip1.Abajo1);
            sintaxis += Codigo1(Clip1.Abajo1);
            sintaxis += Codigo2(Clip1.Abajo1);
            sintaxis += "} \n";
            return sintaxis;
        }
        public string CodigoNivel1()
        {
            string sintaxis = "digraph g{ \n node[shape=record,style=filled,color=midnightblue,fontcolor=white];\n";
            sintaxis += Codigo(Clip1);
            sintaxis += Codigo1(Clip1);
            sintaxis += Codigo2(Clip1);
            sintaxis += "} \n";
            return sintaxis;
        }
        public string CodigoNivel2()
        {
            string sintaxis = "digraph g{ \n node[shape=record,style=filled,color=midnightblue,fontcolor=white];\n";
            sintaxis += Codigo(Clip1.Arriba1);
            sintaxis += Codigo1(Clip1.Arriba1);
            sintaxis += Codigo2(Clip1.Arriba1);
            sintaxis += "} \n";
            return sintaxis;
        }
        public string CodigoNivel3()
        {
            string sintaxis = "digraph g{ \n node[shape=record,style=filled,color=midnightblue,fontcolor=white];\n";
            sintaxis += Codigo(Clip1.Arriba1.Arriba1);
            sintaxis += Codigo1(Clip1.Arriba1.Arriba1);
            sintaxis += Codigo2(Clip1.Arriba1.Arriba1);
            sintaxis += "} \n";
            return sintaxis;
        }
        public string Codigo(NodoMatriz raix)
        {
            
            NodoMatriz aux = raix;
            NodoMatriz aux2 = raix;
            string Nodos = "";
            while (aux != null)
            {
                aux2 = aux;
                while (aux2 != null)
                {
                    if (aux2.Datos != null)
                    {
                        //no seon cabeceras
                        Nodos+="Nodo"+aux2.Posx+aux2.Posy+ "[label=\"{Jugador:"+aux2.Datos.Jugador+"|Unidad:"+aux2.Datos.Unidad+"|Movimiento:"+aux2.Datos.Movimiento+"|Alcance:"+aux2.Datos.Alcance+"|Daño:"+aux2.Datos.Dano+"|Vida:"+aux2.Datos.Vida+"|Estado: "+aux2.Datos.Vivo+"}\"];\n";
                    }
                    else
                    {
                        //son cabeceras
                        if (aux2 == raix)
                        {
                            //es pivote
                            Nodos += "Nodo"+aux2.Posx+aux2.Posy+"[label=\"*\"];\n";
                        }
                        else
                        {
                            
                            if (aux2.Posx == 0)
                            {
                                Nodos += "Nodo" +aux2.Posx+aux2.Posy + "[label=\"" + aux2.Posy+"\"];\n";
                            } else if (aux2.Posy == 0&&aux2.Posx!=0)
                            {
                                Nodos += "Nodo" + aux2.Posx+aux2.Posy + "[label=\"" + Nombre(aux2.Posx) + "\"]; \n";
                            }
                            
                            
                        }
                    }
                    aux2 = aux2.Este;
                }
                aux = aux.Sur;
            }
            return Nodos;
        }
        public string Codigo1(NodoMatriz raix)
        {
          
            NodoMatriz aux = raix;
            NodoMatriz aux2 = raix;
            string Nodos = "";
            while (aux != null)
            {
                aux2 = aux;
                Nodos += "{rank=same;";
                while (aux2.Este != null)
                {

                    Nodos += "Nodo" +aux2.Posx+aux2.Posy+"->";
                    aux2 = aux2.Este;
                }
                Nodos += "Nodo" + aux2.Posx+aux2.Posy;
                Nodos += "}\n";
                Nodos += "{rank=same;";
                
                while (aux2.Oeste != null)
                {

                    Nodos += "Nodo" + aux2.Posx+aux2.Posy + "->";
                    aux2 = aux2.Oeste;
                }
                Nodos += "Nodo" + aux2.Posx+aux2.Posy;
                Nodos += "}\n";
                   
                
                aux = aux.Sur;
            }
            return Nodos;
         
           
        }
        public string Codigo2(NodoMatriz raix)
        {
            string Nodos = "";
            NodoMatriz aux = raix;
            NodoMatriz aux2 = raix;
            while (aux != null)
            {
                aux2 = aux;
             
                while (aux2.Sur != null)
                {

                    Nodos += "Nodo" + aux2.Posx + aux2.Posy + "->";
                    aux2 = aux2.Sur;
                }
                Nodos += "Nodo" + aux2.Posx + aux2.Posy+";\n";
              
                

                while (aux2.Norte != null)
                {

                    Nodos += "Nodo" + aux2.Posx + aux2.Posy + "->";
                    aux2 = aux2.Norte;
                }
                Nodos += "Nodo" + aux2.Posx + aux2.Posy+";\n";
               


                aux = aux.Este;
            }

            return Nodos;
        }
    }
}