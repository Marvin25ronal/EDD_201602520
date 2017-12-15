#ifndef CONTROL_H
#define CONTROL_H


typedef struct Control{
    void setAviones(int Contador_){this->contadorAviones=Contador_;}
      void setTiempos(int Contador_){this->contadorTiempos=Contador_;}
      int getTiempos(){return contadorTiempos;}
      int getAviones(){return contadorAviones;}
private:
  int contadorAviones;
  int contadorTiempos;

}Control;

#endif // CONTROL_H
