using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorEDD
{
    public class Unidad
    {
        int vida;
        int movimiennto;
        int alcance;
        int dano;
        string nombre;
        int nivel;

        public int Vida { get => vida; set => vida = value; }
        public int Movimiennto { get => movimiennto; set => movimiennto = value; }
        public int Dano { get => dano; set => dano = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Alcance { get => alcance; set => alcance = value; }
        public int Nivel { get => nivel; set => nivel = value; }

        public Unidad(string name)
        {
            if (name == "Neosatelite")
            {
                Vida = 10;
                Dano = 2;
                Alcance = 0;
                Nombre = name;
                Movimiennto = 6;
                Nivel = 3;
              
            } if (name == "Bombardero")
            {
                Vida = 10;
                Dano = 5;
                Movimiennto = 7;
                Alcance = 0;
                Nombre = name;
                Nivel = 2;
            }
             if (name == "Caza")
            {
                Vida = 20;
                Dano = 2;
                Movimiennto = 9;
                Alcance = 1;
                Nombre = name;
                Nivel = 2;
            }
             if (name == "Helicoptero")
            {
                Vida = 15;
                Dano = 3;
                Movimiennto = 9;
                Alcance = 1;
                Nombre = name;
                Nivel = 2;
            }
             if (name == "Fragata")
            {
                Vida = 10;
                Dano = 3;
                Movimiennto = 5;
                Alcance = 6;
                Nombre = name;
                Nivel = 1;
            }
             if (name == "Crucero")
            {
                Vida = 15;
                Dano = 3;
                Movimiennto = 6;
                Alcance = 1;
                Nombre = name;
                Nivel = 1;
            }
             if (name == "Submarino")
            {
                Vida = 10;
                Dano = 2;
                Movimiennto = 5;
                Alcance = 1;
                Nombre = name;
                Nivel = 0;
            }
        }
    }
}