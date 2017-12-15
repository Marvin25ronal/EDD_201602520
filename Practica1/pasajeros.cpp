#include "pasajeros.h"
#include <time.h>
#include<avion.h>
#include <iostream>
#include <string>
using namespace std;
int persona=1;
int mohila=1;
void  ListaPasajeros::InsertarPasajero(int Tam){
    srand(time(NULL));

    for (int var = 0; var < Tam; ++var) {
     Pasajero *nuevo=new Pasajero();
     nuevo->PasajeroAnterior=NULL;
     nuevo->id=persona;
      nuevo->Documentos=1+rand()%10;
       nuevo->TurnosRegistro=1+rand()%3;
       nuevo->MaletasCantidad=1+rand()%4;

       if(Primero!=NULL){
           Ultimo->PasajeroAnterior=nuevo;
           Ultimo=nuevo;

       }else{
           Primero=nuevo;
           Ultimo=nuevo;
       }
       persona++;

    }




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
            mohila++;
    }
        aux=aux->PasajeroAnterior;


    }
}

string ListaMochilas::CodigoMoschilas()
{
    string codigo="subgraph cluster2{ \n";


    Mochilas *aux;
    if(Primera!=NULL){


        aux=Primera;
     //   codigo=codigo+"{rank=same; \n";
        while(aux!=Ultima){
         //   if(aux->id==Cantidad){
         //       codigo=codigo+"} \n";
         //   }
         //   if(aux->id==Cantidad*2+1){
         //       codigo=codigo+"{rank=same ; \n";
          /*  }
            if(aux->id==Cantidad*3+1){
                codigo=codigo+"} \n" ;
            }
            */
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
    Primero=aux->PasajeroAnterior;

    delete (aux);

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



