#ifndef IMAGEN_H
#define IMAGEN_H
#include <string>
#include <avion.h>
using namespace std;
typedef struct Imagen{
    string GenerarCodigo(string CodigoA);
    void GenerarImagen(string Code);
}Imagen;

#endif // IMAGEN_H
