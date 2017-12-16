#include "pasajeros.h"
#include <time.h>
#include<avion.h>
#include <iostream>
#include <string>
using namespace std;
int persona=1;
int mohila=1;
int condador=0;
int insert=0;
void  ListaPasajeros::InsertarPasajero(int Tam){
    int maleta;
    srand(time(NULL));
    int conta=0;
    for (int var = 0; var < Tam; ++var) {
     Pasajero *nuevo=new Pasajero();
     nuevo->PasajeroAnterior=NULL;
     nuevo->id=persona;
      nuevo->Documentos=1+rand()%10;
       nuevo->TurnosRegistro=1+rand()%3;
       maleta=1+rand()%4;
       cout<<maleta<<"Este es el valor crado"<<endl;

       nuevo->MaletasCantidad=maleta;
       condador=nuevo->MaletasCantidad;
       cout<<nuevo->MaletasCantidad<<"Este es el valor pasado"<<endl;
       conta+=nuevo->MaletasCantidad;
       if(Primero!=NULL){
           Ultimo->PasajeroAnterior=nuevo;
           Ultimo=nuevo;

       }else{
           Primero=nuevo;
           Ultimo=nuevo;
       }
       persona++;

    }
    cout<<"Comparar 2 "<<conta<<endl;

}
string ListaPasajeros::CodigoDesabordaje(){
    string codigo="subgraph cluster1{ \n";
    if(Primero!=NULL){
        Pasajero *aux=new Pasajero();
        aux=Primero;
        if(aux->PasajeroAnterior==NULL){
            codigo=codigo + "Pasajero_"+to_string(aux->id)+"; \n";
        }
        while(aux->PasajeroAnterior!=NULL){
            codigo=codigo+"Pasajero_"+to_string(aux->id)+"->Pasajero_"+to_string(aux->PasajeroAnterior->id)+" ; \n";
            aux=aux->PasajeroAnterior;
        }
        codigo=codigo+"label=\"Pasajeros\" \n";


    }
    return codigo;
}
void ListaMochilas::insertarMochila(ListaPasajeros *Ref){

    Pasajero *aux=new Pasajero();
    int mientras=0;
    aux=Ref->Primero;
    int contador=0;


    while(aux!=NULL){
  mientras=aux->MaletasCantidad;

        for (int var = 0; var < mientras; ++var) {
            Mochilas *nuevo=new Mochilas();
            nuevo->id=mohila;

            if(Primera==NULL){
            Primera=nuevo;
              Ultima=Primera;
          Ultima->MochilaSiguiente=Primera;

          Primera->MochilaAnterior=Ultima;


        }else{
           Ultima->MochilaSiguiente=nuevo;
           nuevo->MochilaSiguiente=Primera;
           nuevo->MochilaAnterior=Ultima;
           Ultima=nuevo;
           Primera->MochilaAnterior=Ultima;


        }
            insert++;
            mohila++;
    }
        aux=aux->PasajeroAnterior;


    }
    cout<<"Ya llevame Diosito"<<insert<<endl;
}

string ListaMochilas::CodigoMoschilas()
{
    string codigo="subgraph cluster2{ \n";


    Mochilas *aux;
    if(Primera!=NULL){


        aux=Primera;

        while(aux!=Ultima){

            codigo=codigo+"Mochila"+to_string(aux->id)+"->Mochila"+to_string(aux->MochilaSiguiente->id)+"; \n";
            codigo=codigo+"Mochila"+to_string(aux->MochilaSiguiente->id)+"->Mochila"+to_string(aux->id)+"; \n";

            aux=aux->MochilaSiguiente;
        }
        codigo=codigo+"Mochila"+to_string(aux->id)+"->Mochila"+to_string(aux->MochilaSiguiente->id)+"; \n";
        codigo=codigo+"Mochila"+to_string(aux->MochilaSiguiente->id)+"->Mochila"+to_string(aux->id)+"; \n";


    }
    codigo=codigo+"label=\"Maletas\"";


return codigo;
}
void ListaPasajeros::EliminarPasajero(){
    Pasajero *aux =new Pasajero();

    aux=Primero;
    if(aux->PasajeroAnterior!=NULL){
         Primero=aux->PasajeroAnterior;
         delete (aux);
    }else{
        Primero=NULL;
        Ultimo=NULL;
    }





}
int ListaMochilas::CantidadMochilas(){
    Mochilas *aux;
    int contador=0;
    if(Ultima!=NULL){
        aux=Ultima;
       contador=aux->id;
    }

    return contador;
}



