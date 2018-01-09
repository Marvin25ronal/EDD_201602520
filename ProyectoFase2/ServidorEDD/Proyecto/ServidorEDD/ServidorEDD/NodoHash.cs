using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorEDD
{
    public class NodoHash
    {
        string nickname;
        string correo;
        string contrasena;

        public NodoHash(string nickname,string correo,string contrasena)
        {
            this.nickname = nickname;
            this.correo = correo;
            this.contrasena = contrasena;
        }

        public string Nickname { get => nickname; set => nickname = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
    }
}