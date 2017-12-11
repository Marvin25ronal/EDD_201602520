#ifndef CABECERA_H_INCLUDED
#define CABECERA_H_INCLUDED

typedef struct Nodo{
int valor;
struct Nodo *siguiente;
struct Nodo *anterior;
}Nodo;

typedef struct {
     Nodo *primero;
    Nodo *ultimo;

}Lista;
Lista *ListaDoblementeEnlazada;
void IniciarApp();
int MenuPrincipal();
void insertarNodo(Lista *ListaDoblementeEnlazada,int valornodo);
void mostrarNodo(Lista *ListaDoblementeEnlazada);
void EliminarDatos(Lista *ListaDoblementeEnlazada, int valornodo);
int ExaminarValor(Lista *ListaDoblementeEnlazada, int valornodo);


#endif // CABECERA_H_INCLUDED
