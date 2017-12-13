#include "avion.h"
#include <iostream>
#include <time.h>
#include <string.h>
#include <string>
#include <sstream>
#include <pasajeros.h>
ListaPasajeros p;

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
    nuevo->Pasajeros=5+(rand()%5);
    nuevo->Turnos=1;
    nuevo->Mantenimiento=1+rand()%3;

}else if(random1==1){
    srand(time(0));
    nuevo->Tamano="Mediano";
    nuevo->Pasajeros=15+(rand()%10);
    nuevo->Turnos=2;
    nuevo->Mantenimiento=2+rand()%3;

}else if(random1==2){
    srand(time(0));
    nuevo->Tamano="Grande";
    nuevo->Pasajeros=30+(rand()%11);
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
    if(getAviones()>0&&getTiempos()>0){
        return true;
    }else {
        return false;
    }
}
string Lista::CodigoAvion(){

    string Codigo="";
    Avion *aux=new Avion();
    aux=Ultimo;
    if(ListaVacia()==false){
        if(aux->AvionSiguiente==NULL){
            Codigo =Codigo+ "Avion_"+to_string(aux->id)+";";
        }
        while(aux->AvionSiguiente!=NULL){
            Codigo=Codigo+"Avion_"+to_string(aux->id)+"->Avion_"+to_string(aux->AvionSiguiente->id)+"; \n";
            Codigo=Codigo+"Avion_"+to_string(aux->AvionSiguiente->id)+"->Avion_"+to_string(aux->id)+"; \n ";
           aux= aux->AvionSiguiente;
        }
        Codigo=Codigo+"label=\"Aviones\" \n";

    }


    return Codigo;
}
bool Lista::ListaVacia()
{
    if(Primero!=NULL){
        return false;
    }else{
        return true;
    }
}
void Lista::VerificarTurnosAvion(){
    if(Primero!=NULL){
        if(Primero->Turnos>0){
            Primero->Turnos=Primero->Turnos-1;
        }else{
            int contador=0;
            if(Primero->AvionAnterior!=NULL){
                Avion *aux=new Avion();
                aux=Primero;
                //Saca al avion y baja personas
                contador=aux->Pasajeros;
                while(contador>0){
                    p.InsertarPasajero(cantidadpasajeros);
                    contador--;
                    cantidadpasajeros++;
                }


                //Saca al avion 2  lo hace cabeza
                aux=Primero->AvionAnterior;
                Primero->AvionAnterior=NULL;
                aux->AvionSiguiente=NULL;
                Primero=aux;
                Primero->Turnos=Primero->Turnos-1;

            }else{
                //Enviar a primero a la otra
                contador=Primero->Pasajeros;
                while(contador>0){
                    p.InsertarPasajero(cantidadpasajeros);
                    contador--;
                    cantidadpasajeros++;
                }
                Primero=NULL;
                free(Primero);
            }
            //Se manda a mantenimiento luego de tronar

        }
    }
}
