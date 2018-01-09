using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorEDD
{
    public class ArbolAVL
    {
     
            NodoAVL caiz;
            string cadena;
            string codigo;
            string codigo2;
        int Numeronodos;

        public NodoAVL Caiz { get => caiz; set => caiz = value; }
        public int Numeronodos1 { get => Numeronodos; set => Numeronodos = value; }

        //  string codigo3;


        public ArbolAVL()
            {
                caiz = null;
            Numeronodos1 = 0;
            }
            private NodoAVL RotDobleII(NodoAVL n, NodoAVL n1)
            {
                n.Izquierda = n1.Derecha;
                n1.Derecha = n;
                //valores de equilibrio
                if (n1.FactorE == -1)
                {
                    n.FactorE = 0;
                    n1.FactorE = 0;
                }
                else
                {
                    n.FactorE = -1;
                    n1.FactorE = 1;
                }
                return n1;
            }
            private NodoAVL RotDobleDD(NodoAVL n, NodoAVL n1)
            {
                n.Derecha = n1.Izquierda;
                n1.Izquierda = n;
                if (n1.FactorE == +1)
                {
                    n.FactorE = 0;
                    n1.FactorE = 0;
                }
                else
                {
                    n.FactorE = +1;
                    n1.FactorE = -1;
                }
                return n1;
            }
            private NodoAVL RotID(NodoAVL n, NodoAVL n1)
            {
                NodoAVL n2;
                n2 = n1.Derecha;
                n.Izquierda = n2.Derecha;
                n2.Derecha = n;
                n1.Derecha = n2.Izquierda;
                n2.Izquierda = n1;
                if (n2.FactorE == +1)
                    n1.FactorE = -1;
                else
                    n1.FactorE = 0;
                if (n2.FactorE == -1)
                    n.FactorE = 1;
                else
                    n.FactorE = 0;
                n2.FactorE = 0;
                return n2;
            }
            private NodoAVL RotDI(NodoAVL n, NodoAVL n1)
            {
                NodoAVL n2;
                n2 = n1.Izquierda;
                n.Derecha = n2.Izquierda;
                n2.Izquierda = n;
                n1.Izquierda = n2.Derecha;
                n2.Derecha = n1;
                if (n2.FactorE == +1)
                    n.FactorE = -1;
                else
                    n.FactorE = 0;
                if (n2.FactorE == -1)
                    n1.FactorE = 1;
                else
                    n1.FactorE = 0;
                n2.FactorE = 0;
                return n2;
            }
            public void insertar(string Nickname, string Contrasena, string Correo,NodoArbol usuario,int conectado)
            {
                Puerta h = new Puerta(false);
                Caiz = insertarAvl(h, Nickname, Contrasena, Correo, Caiz,usuario,conectado);
            Numeronodos1++;
            }
            private NodoAVL insertarAvl(Puerta h, string Nickname, string Contrasena, string Correo, NodoAVL raiz,NodoArbol usuario,int conectado)
            {
                NodoAVL n1;

                if (raiz == null)
                {
                    NodoAVL nuevo;
                if (usuario != null)
                {
                    nuevo = new NodoAVL(usuario);
                }
                else 
                {
                    nuevo = new NodoAVL(Nickname, Contrasena, Correo,conectado);
                }
                    h.setval(true);

                    raiz = nuevo;
                }
                else if (Nickname.CompareTo(raiz.Nickname) < 0)
                {
                    NodoAVL iz;
                    iz = insertarAvl(h, Nickname, Contrasena, Correo, raiz.Izquierda,usuario,conectado);
                    raiz.Izquierda = iz;
                    if (h.getval())
                    {
                        switch (raiz.FactorE)
                        {
                            case 1:
                                raiz.FactorE = 0;
                                h.setval(false);
                                break;
                            case 0:
                                raiz.FactorE = -1;
                                break;
                            case -1:
                                n1 = raiz.Izquierda;
                                if (n1.FactorE == -1)
                                    raiz = RotDobleII(raiz, n1);
                                else
                                    raiz = RotID(raiz, n1);
                                h.setval(false);
                                break;
                        }
                    }

                }
                else if (Nickname.CompareTo(raiz.Nickname) > 0)
                {
                    NodoAVL derecha;
                    derecha = insertarAvl(h, Nickname, Contrasena, Correo, raiz.Derecha,usuario,conectado);
                    raiz.Derecha = derecha;
                    if (h.getval())
                    {
                        switch (raiz.FactorE)
                        {
                            case 1:
                                n1 = raiz.Derecha;
                                if (n1.FactorE == +1)
                                    raiz = RotDobleDD(raiz, n1);
                                else
                                    raiz = RotDI(raiz, n1);
                                h.setval(false);
                                break;
                            case 0:
                                raiz.FactorE = +1;
                                break;
                            case -1:
                                raiz.FactorE = 0;
                                h.setval(false);
                                break;
                        }
                    }

                }
                return raiz;
            }
            public string ImprimirPre1(NodoAVL reco)
            {
                if (reco != null)
                {
                if (reco.Usuario == null)
                {
                    ImprimirPre1(reco.Izquierda);
                    cadena += reco.Nickname + "<p>";
                    ImprimirPre1(reco.Derecha);
                }
                else
                {
                    ImprimirPre1(reco.Izquierda);
                    cadena += reco.Usuario.Nickname + "<p>";
                    ImprimirPre1(reco.Derecha);
                }

            }
                return cadena;
            }
        public string ImprimirPre(NodoAVL reco)
        {
            cadena = "";
            ImprimirPre1(reco);
            return cadena;
        }
            public string CodigoAVl()
            {
                codigo = "";
            codigo2 = "";            
                return Codi1(Caiz) +Codi2(Caiz);
            }
            public string Codi1(NodoAVL raiz)
            {
                if (raiz != null)
                {
                if (raiz.Usuario == null)
                {
                    Codi1(raiz.Izquierda);
                    codigo += raiz.Nickname + "[label=\"<f0>|{<f1>" + raiz.Nickname + "|" + raiz.Correo + "|" + raiz.Contrasena + "}|<f2>\"]; \n";
                    Codi1(raiz.Derecha);
                }
                else if(raiz.Usuario!=null)
                {
                    Codi1(raiz.Izquierda);
                    codigo += raiz.Usuario.Nickname + "[label=\"<f0>|{<f1>" + raiz.Usuario.Nickname + "|" + raiz.Usuario.Correo + "|" + raiz.Usuario.Contrasena + "}|<f2>\"];\n";
                    Codi1(raiz.Derecha);
                }
                  
                }
                return codigo;

            }
            public string Codi2(NodoAVL aux)
            {
            if (aux != null)
            {
                if (aux.Izquierda != null)
                {
                    if (aux.Usuario == null)
                    {
                        codigo2 += "\"" + aux.Nickname + "\":f0->\"" + aux.Izquierda.Nickname + "\":f1;\n";
                        Codi2(aux.Izquierda);
                    }
                    else
                    {
                        codigo2 += "\"" + aux.Usuario.Nickname + "\":f0->\"" + aux.Izquierda.Nickname + "\":f1;\n";
                        Codi2(aux.Izquierda);
                    }

                }
                if (aux.Derecha != null)
                {
                    if (aux.Usuario == null)
                    {
                        codigo2 += "\"" + aux.Nickname + "\":f2->\"" + aux.Derecha.Nickname + "\":f1;\n";
                        Codi2(aux.Derecha);
                    }
                    else
                    {
                        codigo2 += "\"" + aux.Usuario.Nickname + "\":f2->\"" + aux.Derecha.Nickname + "\":f1;\n";
                        Codi2(aux.Derecha);
                    }

                }
            }
                return codigo2;
            }
        public void EliminarAvl(string nickname)
        {
            Puerta flag = new Puerta(false);
            Caiz = BorrarNodo(Caiz,nickname, flag);
            Numeronodos1--;
        }
        public NodoAVL BorrarNodo(NodoAVL raiz,string nickname,Puerta h)
        {
            if (raiz == null)
            {
                return null;
            }else if (nickname.CompareTo(raiz.Nickname) < 0)
            {
                NodoAVL izquierdo;
                izquierdo = BorrarNodo(raiz.Izquierda, nickname, h);
                raiz.Izquierda = izquierdo;
                if (h.getval())
                    raiz = Reajuste1(raiz, h);
            }else if (nickname.CompareTo(raiz.Nickname) > 0)
            {
                NodoAVL derecha;
                derecha = BorrarNodo(raiz.Derecha, nickname, h);
                raiz.Derecha = derecha;
                if (h.getval())
                {
                    raiz = Reajuste2(raiz, h);
                }

            } else if (nickname.CompareTo(raiz.Nickname) == 0)
            {
                NodoAVL encontrado;
                encontrado = raiz;
                if (encontrado.Izquierda == null)
                {
                    raiz = encontrado.Derecha;
                    h.setval(true);
                }else if (encontrado.Derecha == null)
                {
                    raiz = encontrado.Izquierda;
                    h.setval(true);
                }
                else 
                {
                    NodoAVL izquierda;
                    izquierda = Remplazar(raiz, raiz.Izquierda, h);
                    raiz.Izquierda = izquierda;
                    if (h.getval())
                        raiz = Reajuste1(raiz, h);
                    
                }
                encontrado = null;
            }
            return raiz;
        }
        private NodoAVL Remplazar(NodoAVL n,NodoAVL n2,Puerta h)
        {
            if (n2.Derecha != null)
            {
                NodoAVL aux;
                aux = Remplazar(n, n2.Derecha, h);
                n2.Derecha = aux;
                if (h.getval())
                    n2 = Reajuste2(n2, h);
            }
            else
            {
                n.Nickname = n2.Nickname;
                n.Contrasena = n2.Contrasena;
                n.Correo = n2.Correo;
                n.Usuario = n2.Usuario;
                n = n2;
                n2 = n2.Izquierda;
                n = null;
                h.setval(true);
            }
            return n2;
        }

        private NodoAVL Reajuste1(NodoAVL n,Puerta h)
        {
            NodoAVL n1;
            switch (n.FactorE)
            {
                case -1: n.FactorE = 0;
                    break;
                case 0: n.FactorE = 1;
                    break;
                case +1:
                    n1 = n.Derecha;
                    if (n1.FactorE >= 0)
                    {
                        if (n1.FactorE == 0)
                            h.setval(false);
                        n = RotDobleDD(n, n1);
                    }
                    else
                    {
                        n = RotDI(n, n1);
                    }
                    break;

            }
            return n;
        }
        public NodoAVL Buscar(string nickname)
        {
            if (Caiz == null)
            {
                return null;
            }
            else
            {
                return localizar(Caiz, nickname);
            }
        }
        public NodoAVL localizar(NodoAVL anterior, string nickname)
        {
            if (anterior == null)
            {
                return null;
            }
            else if (nickname == anterior.Nickname)
            {
                return anterior;
            }
            else if (nickname.CompareTo(anterior.Nickname) < 0)
            {
                return localizar(anterior.Izquierda, nickname);
            }
            else
            {
                return localizar(anterior.Derecha, nickname);
            }
        }
        private NodoAVL Reajuste2(NodoAVL n,Puerta h)
        {
            NodoAVL n1;
            switch (n.FactorE)
            {
                case -1:
                    n1 = n.Izquierda;
                    if (n1.FactorE <= 0)
                    {
                        if (n1.FactorE == 0)
                            h.setval(false);
                        n = RotDobleII(n, n1);
                    }
                    else
                    {
                        n = RotID(n, n1); 
                    }
                    break;
                case 0: n.FactorE = -1;
                    h.setval(false);
                    break;
                case +1:
                    n.FactorE = 0;
                    break;
            }
            return n;
        }
        }
  
    }

    public class Puerta
    {
        bool v;
        public Puerta(bool f)
        { this.v = f; }
        public void setval(bool f) { v = f; }
        public bool getval() { return v; }
    }


