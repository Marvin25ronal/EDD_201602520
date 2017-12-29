using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorEDD
{
    public class Objeto
    {
        string jugador;
        string unidad;
        int vida;
        int movimiento;
        int alcance;
        int dano;
        bool vivo;
        public Objeto(string jugador,string unidad,int vida,int movimiento,int alcance,int dano,int vivo)
        {
            this.jugador = jugador;
            this.unidad = unidad;
            this.vida = vida;
            this.movimiento = movimiento;
            this.alcance = alcance;
            this.dano = dano;
            this.vivo = Convert.ToBoolean(vivo);

        }

        public string Jugador { get => jugador; set => jugador = value; }
        public string Unidad { get => unidad; set => unidad = value; }
        public int Vida { get => vida; set => vida = value; }
        public int Movimiento { get => movimiento; set => movimiento = value; }
        public int Alcance { get => alcance; set => alcance = value; }
        public int Dano { get => dano; set => dano = value; }
        public bool Vivo { get => vivo; set => vivo = value; }
    }
}