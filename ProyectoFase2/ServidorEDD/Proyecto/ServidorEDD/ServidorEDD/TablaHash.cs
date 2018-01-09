using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorEDD
{
    public class TablaHash
    {
        public int TamanoOriginal = 43;
        private int ElementosT;
        private double PorcentajeOcupacion;
        private NodoHash[] tabla;
        string Codigo="";

        public NodoHash[] Tabla { get => tabla; set => tabla = value; }

        public TablaHash()
        {
            Tabla = new NodoHash[TamanoOriginal];
            for (int i = 0; i < TamanoOriginal; i++)
                Tabla[i] = null;
            ElementosT = 0;
            PorcentajeOcupacion = 0.0;
        }
        public double ValorCadena(string nickname)
        {
            double auxiliar = 0;
            char[] arrego = nickname.ToCharArray();
            for (int i = 0; i < arrego.Length; i++)
            {
                auxiliar += arrego[i];
            }
            return auxiliar;
        }
        public int direccion(string nickname,NodoHash[] tabl)
        {
            int aux = 0;
            int i = 0;
            double aux1 = ValorCadena(nickname);
            aux = (int)(aux1 % TamanoOriginal);
            while (tabl[aux] != null && tabl[aux].Nickname != nickname)
            {
                i++;
                aux = aux + i * i;
                aux = aux % TamanoOriginal;
            }
            return aux;
        }
        public void insertar(NodoHash r)
        {
            int posicion;
            posicion = direccion(r.Nickname,Tabla);
            Tabla[posicion] = r;
            ElementosT++;
            PorcentajeOcupacion = ((Double)ElementosT / (Double)TamanoOriginal);
            if (PorcentajeOcupacion < 0.3)
            {

                Tabla = NuevoArrego(Tabla, Disminuir());
                //Conviene disminuir
            }
            if (PorcentajeOcupacion > 0.5)
            {
                //Conviene Ahumentar
                Tabla = NuevoArrego(Tabla, Ahumentar());
            }
        }
        public NodoHash buscarNodo(string nickname)
        {
            NodoHash aux;
            int posicion;
            posicion = direccion(nickname,Tabla);
            aux = Tabla[posicion];
            return aux;
        }
        public void eliminar(string nickname)
        {
            int posicion;
            posicion = direccion(nickname,Tabla);
            if (Tabla[posicion] != null)
            {
                Tabla[posicion] = null;
            }
        }
        public NodoHash[] Disminuir()
        {
            int ProximoTamanoGrande;
            double factor = 0;

            ProximoTamanoGrande = TamanoOriginal - 1;
            factor = (Double)ElementosT / (Double)ProximoTamanoGrande;
            while (factor > 0.5 || factor < 0.3)
            {
                if (Esprimo(ProximoTamanoGrande) == false)
                {
                    ProximoTamanoGrande--;
                }
                else
                {
                    factor = (Double)ElementosT / (Double)ProximoTamanoGrande;
                    if (factor > 0.3 && factor < 0.5)
                    {
                        break;
                    }
                    else
                    {
                        ProximoTamanoGrande--;
                    }
                }


            }
            TamanoOriginal = ProximoTamanoGrande;
            NodoHash[] nuevo = new NodoHash[TamanoOriginal];

            return nuevo;

        }
        public NodoHash[] Ahumentar()
        {
            int ProximoTamanoPequeno;
            double factor = 0;

            ProximoTamanoPequeno = TamanoOriginal + 1;
            factor = (Double)ElementosT / (Double)ProximoTamanoPequeno;
            while (factor <= 0.5)
            {
                if (Esprimo(ProximoTamanoPequeno) == false)
                {
                    ProximoTamanoPequeno++;
                }
                else
                {
                    factor = (Double)ElementosT / (Double)ProximoTamanoPequeno;
                    if (factor < 0.5)
                    {
                        break;
                    }
                    else
                    {
                        ProximoTamanoPequeno++;
                    }
                }


            }
            TamanoOriginal = ProximoTamanoPequeno;
            NodoHash[] nuevo = new NodoHash[TamanoOriginal];

            return nuevo;

        }
        public bool Esprimo(int numero)
        {
            int a = 0;
            for (int i = 1; i < (numero + 1); i++)
            {
                if (numero % i == 0)
                {
                    a++;
                }
            }
            if (a != 2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public NodoHash[] NuevoArrego(NodoHash[] anterior, NodoHash[] nuevo)
        {
            ElementosT = 0;
            for (int i = 0; i < anterior.Length; i++)
            {
                if (anterior[i] != null)
                {
                    PasarDatos(anterior[i], nuevo);
                }
            }
            return nuevo;
        }
        public void PasarDatos(NodoHash r, NodoHash[] arreglo)
        {
            int posicion;
            posicion = direccion(r.Nickname,arreglo);
            arreglo[posicion] = r;
            ElementosT++;
            PorcentajeOcupacion = (double)(ElementosT / TamanoOriginal);

        }
        public string CodigoHash()
        {
            Codigo = "";
            int indice = 0;
            for (int i = 0; i < Tabla.Length; i++)
            {
                if (Tabla[i] != null)
                {
                    Codigo += "node" + indice + "[label=\"{" + Tabla[i].Nickname + "|" + Tabla[i].Correo + "|" + Tabla[i].Contrasena + "|Key:"+i+"}\"];\n";
                    indice++;
                }
            }
            for(int i = 0; i < indice-1; i++)
            {
                Codigo += "node" + i + "->" + "node" + (++i)+";\n";
                --i;
            }
            return Codigo;
        }
    }
}