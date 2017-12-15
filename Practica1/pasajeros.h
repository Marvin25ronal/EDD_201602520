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
    ListaPasajeros(){Primero=NULL;Ultimo=NULL;}
void InsertarPasajero(int Tam);
void EliminarPasajero();
string CodigoDesabordaje();

    Pasajero *Primero;
    Pasajero *Ultimo;
}ListaPasajeros;


typedef struct Mochilas{
    int id;
    struct Mochilas *MochilaAnterior;
    struct Mochilas *MochilaSiguiente;
}Mochilas;

typedef struct ListaMochilas{
    ListaMochilas(){Primera=NULL;Ultima=NULL;}
    void insertarMochila(ListaPasajeros *Ref);
    int CantidadMochilas();
    string CodigoMoschilas();

    Mochilas *Primera;
    Mochilas *Ultima;
}ListaMochilas;



#endif // PASAJEROS_H
