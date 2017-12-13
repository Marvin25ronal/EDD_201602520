#ifndef PASAJEROS_H
#define PASAJEROS_H
#include <string>
using namespace std;
typedef struct Pasajero{
    int id;
    int Documentos;
    int TurnosRegistro;
    int MaletasCantidad;
    struct Pasajero *PasajeroAnterior;

}Pasajero;



typedef struct ListaPasajeros{
    ListaPasajeros(){Primero=NULL;}
void InsertarPasajero(int ID);
    Pasajero *Primero;
    Pasajero *Ultimo;
}ListaPasajeros;

#endif // PASAJEROS_H
