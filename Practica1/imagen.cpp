#include "imagen.h"
#include <string.h>
#include <avion.h>
#include <iostream>
#include <fstream>
#include <stdlib.h>

using namespace std;

string Imagen::GenerarCodigo (string CodigoA){

    string codigo="";
    codigo="digraph G { \n";
    codigo=codigo+CodigoA;
    codigo=codigo+"\n }";
    GenerarImagen(codigo);
    return codigo;
}
void Imagen::GenerarImagen(string Code){
    ofstream Archivo("/home/marvin/Codigo.dot");

    Archivo<<Code<<endl;
    Archivo.close();

    system("dot -Tjpg /home/marvin/Codigo.dot -o /home/marvin/Diagram.jpg");
}


