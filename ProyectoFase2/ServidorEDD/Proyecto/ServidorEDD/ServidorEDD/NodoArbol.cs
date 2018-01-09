using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ServidorEDD
{
    public class NodoArbol
    {
        string nickname;
        string contrasena;
        string correo;
        bool conectado;
        NodoArbol izquierdo;
        NodoArbol derecho;
        ListaJuego lista;
        ArbolAVL arbolitoAvl;
        public NodoArbol(string nickname,string contrasena,string correo,int conectado)
        {
            this.nickname = nickname;
            this.Contrasena = contrasena;
            this.correo = correo;
            this.conectado = Convert.ToBoolean(conectado);
             izquierdo = null;
            derecho = null;
            lista = new ListaJuego();
            arbolitoAvl = new ArbolAVL();

        }
        public string Contrasena {
            set { contrasena = value; }
            get { return contrasena; }
        }
        public string Nickname
        {
            set { nickname = value; }
            get { return nickname; }
        }
        public string Correo
        {
            set { correo = value; }
            get { return correo; }
        }
        public bool Conectado
        {
            set { conectado = value; }
            get { return conectado; }
        }
        public NodoArbol Izquierdo
        {
            set { izquierdo = value; }
            get { return izquierdo; }
        }
        public NodoArbol Derecho
        {
            set { derecho = value; }
            get { return derecho; }
        }
        public ListaJuego Lista
        {
            set { lista = value; }
            get { return lista; }
        }

        public ArbolAVL ArbolitoAvl { get => arbolitoAvl; set => arbolitoAvl = value; }
    }
}
