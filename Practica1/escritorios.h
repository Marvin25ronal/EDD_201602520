#ifndef ESCRITORIOS_H
#define ESCRITORIOS_H
#include <iostream>
#include <pasajeros.h>
#include <string>
using namespace std;


typedef struct Persona{
    int id;
    int documentos;
    int tiemposentaquilla;
    int maletas;
    struct Persona *PasajeroAnterior;


}Persona;
typedef struct Documentos{
    int id;
    struct Documentos *documentoSiguiente;
}Documentos;
typedef struct PilaDocumentos{
    PilaDocumentos(){Cabeza=NULL;}
    Documentos *Cabeza;
    void Push(int id);
    int PopID();
    void VaciarPila();
}PilaDocumentos;

typedef struct ColaPersona{
    ColaPersona(){PasajeroAtendido=NULL;UltimoPasajero=NULL;}
     Persona *PasajeroAtendido;
     Persona *UltimoPasajero;
     int getNumeroEnTaquilla();

}ColaPersona;


typedef struct Escritorio{
    char Letra;
    Escritorio(){ ColaPersonas=new ColaPersona();PilaDoc=new PilaDocumentos();}
    PilaDocumentos *PilaDoc;
  ColaPersona *ColaPersonas;
 struct Escritorio *EscritorioSigueinte;
 struct Escritorio *EscritorioAnterior;



}Escritorio;
typedef struct ListaEscritorios{
    ListaEscritorios(){Primero=NULL;Ultimo=NULL;}
    Escritorio *Primero;
    Escritorio *Ultimo;
    void insertarEscritorio();
    void Imprimir();
    void setEscritorio(int Escritorios_){this->Escritorios=Escritorios_;}
    bool ListaVacia(){if(Primero!=NULL){return false;}else{return true;}}
    void SacarPersonas(ListaMochilas *meny);
    bool EliminarMaleta(ListaMochilas *mo,int mochila);
    void CrearPilaEscritorio();
    void VerificarEscritorios(ListaPasajeros *Ref_);
    string CodigoEscritorios();
    void insertarPersonas();
    int getEscritorio(){return Escritorios;}

    int Escritorios;
}ListaEscritorios;


#endif // ESCRITORIOS_H
