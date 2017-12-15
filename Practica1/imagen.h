#ifndef IMAGEN_H
#define IMAGEN_H
#include <string>
#include <avion.h>
using namespace std;
typedef struct Imagen{
    string GenerarCodigo(string CodigoA,string CodigoB,string CodigoC,string CodigoE);
    void GenerarImagen(string Code);
}Imagen;

#endif // IMAGEN_H
