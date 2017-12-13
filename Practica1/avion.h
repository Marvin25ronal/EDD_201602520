#ifndef AVION_H
#define AVION_H

#include <string>
using namespace std;

typedef struct Avion{
    string Tamano;
    int Pasajeros;
    int Desabordaje;
    int Turnos;
    int id;
    int Mantenimiento;
    struct Avion *AvionSiguiente;
    struct Avion *AvionAnterior;

}Avion;

typedef struct Lista{
    Lista(){Primero=NULL;Ultimo=NULL;}
    Avion *Primero;
    Avion *Ultimo;
    void setAviones(int Contador_){this->contadorAviones=Contador_;}
      void setTiempos(int Contador_){this->contadorTiempos=Contador_;}
      int getTiempos(){return contadorTiempos;}
      int getAviones(){return contadorAviones;}
      void VerificarTurnosAvion();
    void insertarAvion(int ID);
    bool ListaVacia();
    bool VerificarDatos();
    string CodigoAvion();
  private:
    int contadorAviones;
    int contadorTiempos;



}Lista;





#endif // AVION_H
