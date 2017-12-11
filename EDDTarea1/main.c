#include <stdio.h>
#include <stdlib.h>
#include"Cabecera.h"

int main()
{

    ListaDoblementeEnlazada=malloc(sizeof(Lista));
    ListaDoblementeEnlazada->primero=NULL;
    ListaDoblementeEnlazada->ultimo=NULL;

    IniciarApp();
    return 0;
}
void IniciarApp(){
int opcion=0;
int valornodo=0;
while((opcion=MenuPrincipal())<4){
switch(opcion){
    case 1: printf("Ingrese un valor para insertar \n");
    scanf("%d",&valornodo);
    insertarNodo(ListaDoblementeEnlazada,valornodo);
    break;
case 2:
    printf("Ingrese el valor a eliminar \n");
    scanf("%d",&valornodo);
    EliminarDatos(ListaDoblementeEnlazada,valornodo);

    break;
case 3:
    mostrarNodo(ListaDoblementeEnlazada);

    break;
}
}


}
int MenuPrincipal(){
int opcion=0;
printf("------------------------Bienvenido a la Tarea 1--------------------------------- \n");
printf("Ingrese una opcion \n");
printf("1) Insertar un elemento a la lista \n");
printf("2) Eliminar un valor de la lista \n");
printf("3) Mostrar elementos de la lista \n");
scanf("%d",&opcion);

return opcion;
}
void insertarNodo(Lista *ListaDoblementeEnlazada,int valornodo){
Nodo *nuevo=malloc(sizeof(Nodo));
nuevo->valor=valornodo;
nuevo->siguiente=NULL;

if(ListaDoblementeEnlazada->primero==NULL){
    ListaDoblementeEnlazada->primero=nuevo;
    ListaDoblementeEnlazada->ultimo=nuevo;
}else{
    ListaDoblementeEnlazada->ultimo->siguiente=nuevo;
    nuevo->anterior=ListaDoblementeEnlazada->ultimo;
    ListaDoblementeEnlazada->ultimo=nuevo;

}
}
void mostrarNodo(Lista *ListaDoblementeEnlazada){
    if(ListaDoblementeEnlazada->primero==NULL){
        printf("La lista no contiene ningun elemento \n");
    }else{
    Nodo *aux=ListaDoblementeEnlazada->primero;
    printf("*************\n");
    while(aux!=NULL){
        printf("Valor es: %d \n",aux->valor,"\n");
        aux=aux->siguiente;
    }
    free(aux);
    printf("*************\n");
    }
}
void EliminarDatos(Lista *ListaDoblementeEnlazada,int valornodo){
    if(ListaDoblementeEnlazada->primero==NULL){
        printf("La lista se encuentra vacia \n");
    }else{
        if(ExaminarValor(ListaDoblementeEnlazada,valornodo)==1){
            Nodo *aux=ListaDoblementeEnlazada->primero;
        while(aux!=NULL){

            if(aux->valor==valornodo){
            if(aux->anterior==NULL&&aux->siguiente!=NULL){
                aux->siguiente->anterior=NULL;
            ListaDoblementeEnlazada->primero=aux->siguiente;
            free(aux);

            }
            else if(aux->siguiente==NULL&&aux->anterior!=NULL){
                aux->anterior->siguiente=NULL;
                ListaDoblementeEnlazada->ultimo=aux->anterior;
                free(aux);
            }
            else if(aux->siguiente!=NULL&&aux->anterior!=NULL){
                aux->anterior->siguiente=aux->siguiente;
                aux->siguiente->anterior=aux->anterior;
                free(aux);
            }
            else if(aux->siguiente==NULL&&aux->anterior==NULL){
                ListaDoblementeEnlazada->primero=NULL;
                ListaDoblementeEnlazada->ultimo=NULL;
            free(aux);
            }
            }

            aux=aux->siguiente;
        }
    free(aux);
        }else{
        printf("La lista no contiene ese valor para eliminarlo \n");
        }

    }
}
int ExaminarValor(Lista *ListaDoblementeEnlazada,int valornodo){
    int encontro=0;
    Nodo *aux=ListaDoblementeEnlazada->primero;
    while(aux!=NULL){
        if(aux->valor==valornodo){
            encontro=1;
            break;
        }
        aux=aux->siguiente;

    }
    return encontro;
}

