#include "pasajeros.h"
#include <time.h>
#include <iostream>
using namespace std;
void  ListaPasajeros::InsertarPasajero(int ID){
    srand(time(0));
    Pasajero *nuevo=new Pasajero();
    nuevo->id=ID;
    nuevo->Documentos=1+rand()%10;
    nuevo->TurnosRegistro=1+rand()%3;
    nuevo->MaletasCantidad=1+rand()%4;

    if(Primero!=NULL){
        Ultimo->PasajeroAnterior=nuevo;
        Ultimo=nuevo;
           cout<<ID<<endl;
    }else{
        Primero=nuevo;
        Ultimo=nuevo;
    }
}
