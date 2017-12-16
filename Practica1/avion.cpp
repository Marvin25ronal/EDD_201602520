#include "avion.h"
#include <iostream>
#include <time.h>
#include <string.h>
#include <string>
#include <sstream>
#include <pasajeros.h>
#include <mantenimiento.h>
ListaPasajeros p;

ListaAvionesEsperando *Alv=new ListaAvionesEsperando;
using namespace std;
int conta=1;
int cantidadpasajeros=0;
void Lista::insertarAvion(int ID)
{
Avion *nuevo=new Avion();
nuevo->AvionAnterior=NULL;
nuevo->AvionSiguiente=NULL;
srand(time(0));
if(getAviones()>0){
int random1=rand() %3;
if(random1==0){
    srand(time(0));
    nuevo->Tamano="Pequeno";
    nuevo->Pasajeros=5+rand()%10;
    nuevo->Turnos=1;
    nuevo->Mantenimiento=1+rand()%3;

}else if(random1==1){
    srand(time(0));
    nuevo->Tamano="Mediano";
    nuevo->Pasajeros=15+rand()%11;
    nuevo->Turnos=2;
    nuevo->Mantenimiento=2+rand()%3;

}else if(random1==2){
    srand(time(0));
    nuevo->Tamano="Grande";
    nuevo->Pasajeros=30+rand()%11;
    nuevo->Turnos=3;
    nuevo->Mantenimiento=3+rand()%4;

}
nuevo->id=ID;
if(Primero==NULL){
    Primero=nuevo;
    Ultimo=nuevo;
}else{
    Ultimo->AvionAnterior=nuevo;
    nuevo->AvionSiguiente=Ultimo;
    Ultimo=nuevo;
}
setAviones(getAviones()-1);
}

}
bool Lista:: VerificarDatos(){
    if(getAviones()>0&&getTiempos()>0&&getEscritorios()>0){
        return true;
    }else {
        return false;
    }
}
string Lista::CodigoAvion(){

    string Codigo=" \n  \n subgraph  cluster0{ \n";
    Avion *aux;

    if(Ultimo!=NULL&&Primero!=NULL){
          aux=Ultimo;
        if(aux->AvionSiguiente==NULL){
            Codigo =Codigo+ "Avion_"+to_string(aux->id)+"; \n";
        }
        while(aux->AvionSiguiente!=NULL){
            Codigo=Codigo+"Avion_"+to_string(aux->id)+"->Avion_"+to_string(aux->AvionSiguiente->id)+"; \n";
            Codigo=Codigo+"Avion_"+to_string(aux->AvionSiguiente->id)+"->Avion_"+to_string(aux->id)+"; \n ";
           aux= aux->AvionSiguiente;
        }
        Codigo=Codigo+"label=\"Aviones\" ;  \n";

    }


    return Codigo;
}
bool Lista::ListaVacia()
{
    if(Primero!=NULL&&Ultimo!=NULL){
        return false;
    }else{
        return true;
    }
}
bool Lista::VerificarTurnosAvion(){
    bool EstaDesavordandoAvion=false;
    if(Primero!=NULL){
        if(Primero->Turnos>0){
            Primero->Turnos=Primero->Turnos-1;
        }else{

                EstaDesavordandoAvion=true;
        }
    }
    return EstaDesavordandoAvion;
}
void Lista::Eliminar()
{

    Avion *Aux;
    Alv->insertar(Primero);

    Aux=Primero;
    if(Primero!=NULL){
        if(Primero->AvionAnterior!=NULL){
            Aux=Primero;

            Primero=Aux->AvionAnterior;
                Primero->AvionSiguiente=NULL;


           delete Aux;
        }else {
            Primero=NULL;
             Ultimo=NULL;

            delete Aux;

        }

    }
}
string Lista::codigo2(){
    return Alv->codigoFilaAvionesEsperando();
}
void Lista::sacarAvion(){
    if(Alv->Primeros!=NULL){
        AvionesEsperandoturno *aux;
        aux=Alv->Primeros;
        if(aux->turnos>0){
            aux->turnos-=1;
        }else{
            Alv->Primeros=aux->Siguiente;
            delete aux;
        }
    }
}
