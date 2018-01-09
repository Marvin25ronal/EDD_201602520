using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorEDD
{
    public class NodoAVL
    {
        int factorE;
        string nickname;
        string contrasena;
        string correo;
        bool conectado;
        NodoAVL derecha;
        NodoAVL izquierda;
        NodoArbol usuario;

        public NodoAVL( string nickname, string contrasena, string correo,int conectado)
        {
            this.Usuario = null;
            this.FactorE = 0;
            this.Nickname = nickname;
            this.Contrasena = contrasena;
            this.Correo = correo;
            this.Derecha = null;
            this.Izquierda =  null;
            this.conectado = Convert.ToBoolean(conectado);
        }
        public NodoAVL(NodoArbol datos)
        {
            this.usuario = datos;
            this.Nickname = datos.Nickname;
            this.Contrasena = datos.Contrasena;
            this.Correo = datos.Correo;
            this.Derecha = null;
            this.izquierda = null;
        }

        public int FactorE { get => factorE; set => factorE = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public string Correo { get => correo; set => correo = value; }
        public NodoAVL Derecha { get => derecha; set => derecha = value; }
        public NodoAVL Izquierda { get => izquierda; set => izquierda = value; }
        public NodoArbol Usuario { get => usuario; set => usuario = value; }
        public bool Conectado { get => conectado; set => conectado = value; }
    }
}