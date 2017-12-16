#ifndef MANTENIMIENTO_H
#define MANTENIMIENTO_H

#include <avion.h>
#include<string>
using namespace std;


typedef struct Hangar{
   int IdAvion;
   bool disponible;
   struct Hangar *siguiente;

}Hangar;

typedef struct ListaHangar
{
    ListaHangar(){Primero=NULL;Ultimo=NULL;}
    Hangar *Primero;
    Hangar *Ultimo;
    void insertar();
    void setHangares(int hangar){this->Hangares=hangar;}
    int getHangares(){return Hangares;}
    int Hangares;
    string CodigoHangar();
    bool VerificarHangar();
    void MoverAvion();
}ListaHangar;


typedef struct AvionesEsperandoturno{
    int id;
    int turnos;
    struct AvionesEsperandoturno *Siguiente;

}AvionesEsperandoturno;

typedef struct ListaAvionesEsperando{
    ListaAvionesEsperando(){Primeros=NULL;Final=NULL;}
    AvionesEsperandoturno *Primeros;
    AvionesEsperandoturno *Final;
    void insertar(Avion *avion);
    string codigoFilaAvionesEsperando();
}ListaAvionesEsperando;

#endif // MANTENIMIENTO_H
