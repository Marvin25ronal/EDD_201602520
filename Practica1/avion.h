#ifndef AVION_H
#define AVION_H

#include <string>
using namespace std;

typedef struct Avion{
    Avion(){AvionSiguiente=NULL;AvionAnterior=NULL;}
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
    void setPersonas(int Contador_){this->ContadorPersonasDesabordando=Contador_;}
    int getPersonas(){return ContadorPersonasDesabordando;}
    void setEsctritorios(int Contador_){this->ContadorEscritorios=Contador_;}
    int getEscritorios(){return ContadorEscritorios;}
      void setTiempos(int Contador_){this->contadorTiempos=Contador_;}
      int getTiempos(){return contadorTiempos;}
      int getAviones(){return contadorAviones;}
      void Eliminar();
      bool VerificarTurnosAvion();
    void insertarAvion(int ID);
    bool ListaVacia();
    bool VerificarDatos();
    string CodigoAvion();
  private:
    int contadorAviones;
    int contadorTiempos;
    int ContadorPersonasDesabordando;
    int ContadorEscritorios;



}Lista;





#endif // AVION_H
