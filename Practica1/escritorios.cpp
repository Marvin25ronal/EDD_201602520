#include "escritorios.h"
#include <pasajeros.h>

void ListaEscritorios::insertarEscritorio(){
    char a='A';
    while(getEscritorio()>0){
        Escritorio *nuevo=new Escritorio();
        nuevo->Letra=a;
        nuevo->EscritorioSigueinte=NULL;
        nuevo->EscritorioAnterior=NULL;
        if(Primero==NULL){
            Primero=nuevo;
            Ultimo=nuevo;

        }else{
            if((int)nuevo->Letra<(int)Primero->Letra){
                Primero->EscritorioAnterior=nuevo;
                nuevo->EscritorioSigueinte=Primero;
                Primero=nuevo;

            }
            if((int)nuevo->Letra>(int)Ultimo->Letra){
                Ultimo->EscritorioSigueinte=nuevo;
                nuevo->EscritorioAnterior=Ultimo;
                Ultimo=nuevo;
            }
            Escritorio *aux;
            for(aux=Primero;aux!=Ultimo;aux=aux->EscritorioSigueinte){
                if((int)nuevo->Letra<(int)aux->Letra){
                    aux->EscritorioAnterior->EscritorioSigueinte=nuevo;
                    nuevo->EscritorioAnterior=aux->EscritorioAnterior;
                    nuevo->EscritorioSigueinte=aux;
                    aux->EscritorioAnterior=nuevo;
                }
            }

        }
        a++;
        setEscritorio(getEscritorio()-1);
    }

}
void ListaEscritorios::Imprimir(){
    Escritorio *aux;
    aux=Primero;
    while(aux!=NULL){
        cout<<aux->Letra<<endl;
        aux=aux->EscritorioSigueinte;
    }
}
void ListaEscritorios::VerificarEscritorios(ListaPasajeros *Ref){

    Escritorio *auxEscritorio;
    auxEscritorio=Primero;
ListaPasajeros *h=Ref;


        while(auxEscritorio!=NULL){
    if(h->Primero!=NULL){
            if(auxEscritorio->ColaPersonas->getNumeroEnTaquilla()>=0){

                while(auxEscritorio->ColaPersonas->getNumeroEnTaquilla()<10&&h->Primero!=NULL){
                   Persona *auxiliarPersona=new Persona();
                   auxiliarPersona->PasajeroAnterior=NULL;
                   auxiliarPersona->id=h->Primero->id;

                   auxiliarPersona->documentos=h->Primero->Documentos;
                   auxiliarPersona->maletas=h->Primero->MaletasCantidad;
                   auxiliarPersona->tiemposentaquilla=h->Primero->TurnosRegistro;

                   if(auxEscritorio->ColaPersonas->PasajeroAtendido!=NULL){
                    auxEscritorio->ColaPersonas->UltimoPasajero->PasajeroAnterior=auxiliarPersona;
                    auxEscritorio->ColaPersonas->UltimoPasajero=auxiliarPersona;
                }else{
                    auxEscritorio->ColaPersonas->PasajeroAtendido=auxiliarPersona;
                    auxEscritorio->ColaPersonas->UltimoPasajero=auxiliarPersona;
                }
                   h->EliminarPasajero();

                }
            }

        }
     auxEscritorio=auxEscritorio->EscritorioSigueinte;
    }



}
int ColaPersona::getNumeroEnTaquilla(){
    Persona *aux;
    aux=PasajeroAtendido;
    int contador=0;
    for(aux=PasajeroAtendido;aux!=NULL;aux=aux->PasajeroAnterior){
        contador++;
    }
    return contador;
}
void ListaEscritorios::insertarPersonas(){

}
string ListaEscritorios::CodigoEscritorios(){
    string codigo;
    codigo="subgraph  cluster3{ \n  " ;
    Escritorio *aux;
    aux=Primero;

    codigo=codigo+"{rank=same; \n";


    while(aux->EscritorioSigueinte!=NULL){
        codigo=codigo+aux->Letra+"->"+aux->EscritorioSigueinte->Letra+"->"+aux->Letra+";\n";
        aux=aux->EscritorioSigueinte;
    }
    codigo=codigo+" } \n";

    aux=Primero;
    Persona *auxper;
    while(aux!=NULL&&aux->ColaPersonas->PasajeroAtendido!=NULL){
        auxper=aux->ColaPersonas->PasajeroAtendido;
        codigo=codigo+aux->Letra+"->Pasajero"+to_string(auxper->id)+";\n";
        while(auxper->PasajeroAnterior!=NULL){
            codigo=codigo+"Pasajero"+to_string(auxper->id)+"->Pasajero"+to_string(auxper->PasajeroAnterior->id)+"; \n";
            auxper=auxper->PasajeroAnterior;
        }
        aux=aux->EscritorioSigueinte;
    }
    Documentos *auxDoc;
    aux=Primero;

    while(aux!=NULL&&aux->PilaDoc->Cabeza!=NULL){
        auxDoc=aux->PilaDoc->Cabeza;

        while(auxDoc->documentoSiguiente!=NULL){
            codigo=codigo+"Doc"+to_string(auxDoc->id)+"->Doc"+to_string(auxDoc->documentoSiguiente->id)+"; \n";
            auxDoc=auxDoc->documentoSiguiente;
        }
        codigo=codigo+"Doc"+to_string(auxDoc->id)+"->"+aux->Letra+";\n";
           aux=aux->EscritorioSigueinte;

    }


    cout<<codigo<<endl;
    return codigo;
}
int PilaDocumentos::PopID(){
return 0;
}
void PilaDocumentos::Push(int id){
Documentos *nuevo=new Documentos();
nuevo->id=id;
nuevo->documentoSiguiente=Cabeza;
Cabeza=nuevo;
}
void ListaEscritorios::CrearPilaEscritorio(){

       Escritorio *aux;
       Persona *auxper;
      int contador=0;
      int idDoc=1;
       aux=Primero;

       while(aux!=NULL){

           if(aux->PilaDoc->Cabeza==NULL&&aux->ColaPersonas->PasajeroAtendido!=NULL){

             auxper=Primero->ColaPersonas->PasajeroAtendido;


              contador=aux->ColaPersonas->PasajeroAtendido->documentos;
              while(contador>0){
                  aux->PilaDoc->Push(idDoc);
                  idDoc++;
                  contador--;
              }

           }
              aux=aux->EscritorioSigueinte;

       }


}
void ListaEscritorios::SacarPersonas(ListaMochilas *meny){
    Escritorio *aux;
    aux=Primero;


    while(aux!=NULL){
         Persona *auxper;
         auxper=aux->ColaPersonas->PasajeroAtendido;
        if(auxper!=NULL){
            if(auxper->tiemposentaquilla>0){
                auxper->tiemposentaquilla=auxper->tiemposentaquilla-1;
            }else{

             auxper=aux->ColaPersonas->PasajeroAtendido;
             aux->ColaPersonas->PasajeroAtendido=auxper->PasajeroAnterior;


                  delete(auxper);
            }
        }
        aux=aux->EscritorioSigueinte;
    }

}
bool ListaEscritorios::EliminarMaleta(ListaMochilas *mo,int mochila){
 ListaMochilas *aux;
 aux=mo;

Mochilas *momo;
momo=mo->Primera;
Mochilas *Mochilaextra;
Mochilaextra=NULL;
bool encontrado=false;
int nodoBuscado;
nodoBuscado=mochila;
if(aux->Primera!=NULL){
    do{
        if(momo->id==mochila){
            if(aux->Primera==aux->Primera->MochilaSiguiente){
                aux->Primera=aux->Primera->MochilaSiguiente;
                aux->Primera->MochilaAnterior=aux->Ultima;
                aux->Ultima->MochilaSiguiente=aux->Primera;
            }else if(momo==aux->Ultima){
aux->Ultima=Mochilaextra;
aux->Ultima->MochilaSiguiente=aux->Primera;
Mochilaextra->MochilaAnterior=aux->Ultima;

            }

            encontrado=true;
        }
        Mochilaextra=momo;
        momo=momo->MochilaSiguiente;
    }
    while(momo!=aux->Primera&&encontrado!=true);
    if(!encontrado){

    }
}else{

}




}

