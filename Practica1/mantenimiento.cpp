#include "mantenimiento.h"
#include <avion.h>
#include <string>
#include <iostream>
using namespace std;
int contadopr=0;
 void ListaHangar::insertar()
 {
     int cotador=0;
     while(getHangares()>0){
         Hangar *nuevo=new Hangar();
         nuevo->IdAvion=cotador;
         cotador++;
         nuevo->disponible=true;

         if(Primero==NULL){
             Primero=nuevo;
             Ultimo=nuevo;
         }else{
             Ultimo->siguiente=nuevo;
             Ultimo=nuevo;

         }
         setHangares(getHangares()-1);
     }

 }
 string ListaHangar::CodigoHangar(){
     string codigo="subgraph cluster4{ \n";
     Hangar *aux;
     codigo+="{rank=same;";
     aux=Primero;
     if(aux->siguiente!=NULL){
         while(aux->siguiente!=NULL){
            codigo+="Hangar"+to_string(aux->IdAvion)+"->Hangar"+to_string(aux->siguiente->IdAvion)+";";
             aux=aux->siguiente;
         }
     }
     codigo+=" } \n";

     return codigo;
 }
 void ListaAvionesEsperando::insertar(Avion *avion)
 {
 AvionesEsperandoturno *Avin=new AvionesEsperandoturno();
 Avin->Siguiente=NULL;
 Avin->id=avion->id;
 cout<<"Esto es exacto"<<Avin->id<<endl;
 Avin->turnos=avion->Turnos;
 if(Primeros!=NULL){
     Final->Siguiente=Avin;
     Final=Avin;
 }else{
     Final=Avin;
     Primeros=Avin;
 }
 }
 string ListaAvionesEsperando::codigoFilaAvionesEsperando(){
     string codigo="subgraph cluster5 { \n";

     if(Primeros!=NULL){
      AvionesEsperandoturno *aux;
      aux=Primeros;
      if(aux->Siguiente==NULL){
       codigo+="AAvion"+to_string(aux->id);
      }
      aux=Primeros;
      while(aux->Siguiente!=NULL){
          codigo+="Avi"+to_string(aux->id)+"->Avi"+to_string(aux->Siguiente->id)+"; \n";
     aux=aux->Siguiente;
      }



     }
     return codigo;
 }
 bool ListaHangar::VerificarHangar()
 {
     if(Primero!=NULL){
         Hangar *aux;
         aux=Primero;
         while(aux!=NULL){
             if(aux->disponible==true){
                 return true;
             }
             aux=aux->siguiente;
         }
     }
 }
 void ListaHangar::MoverAvion(){
     if(VerificarHangar()==true){
       ListaAvionesEsperando *auex;


         Hangar *aux;
         aux=Primero;
         if(auex->Primeros!=NULL){
             while(aux!=NULL){
                 if(aux->disponible==true){
                     AvionesEsperandoturno *men;
                     men=auex->Primeros;
                     aux->IdAvion=auex->Primeros->id;
                     auex->Primeros=auex->Primeros->Siguiente;
                     delete men;;
                 }
                 aux=aux->siguiente;
             }
         }

     }
 }
