using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ServidorEDD
{
    public class NodoListaJuego
    {
        NodoListaJuego siguiente;
        NodoListaJuego anterior;
        string NicknameOponente;
        int UnidadesDesplegadas;
        int UnidadesSobrevivientes;
        int UnidadesDestruidas;
        int id;
        bool Gano;
        public NodoListaJuego(string NicknameO,int Udes,int Usobrevi,int Udestruidas,int gano,int id)
        {
            this.NicknameOponente = NicknameO;
            this.UnidadesDesplegadas = Udes;
            this.UnidadesDestruidas = Udestruidas;
            this.UnidadesSobrevivientes = Usobrevi;
            this.Gano = Convert.ToBoolean(gano);
            this.id = id;
            siguiente = null;
            anterior = null;
        }
         public string NicknameO
        {
            set { NicknameOponente = value; }
            get { return NicknameOponente; }
        }
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        public int Udesple
        {
            set { UnidadesDesplegadas = value; }
            get { return UnidadesDesplegadas; }
        }
        public int Udestru
        {
            set { UnidadesDestruidas = value; }
            get { return UnidadesDestruidas; }
        }
        public int USobre
        {
            set { UnidadesSobrevivientes = value; }
            get { return UnidadesSobrevivientes; }
        }
        public bool Ga
        {
            set { Gano = value; }
            get { return Gano; }
        }
        public NodoListaJuego Siguiente
        {
            set { siguiente = value; }
            get { return siguiente; }
        }
        public NodoListaJuego Anterior
        {
            set { anterior = value; }
            get { return anterior; }
        }



    }
}
