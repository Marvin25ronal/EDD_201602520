#include "escritorios.h"
#include <pasajeros.h>
 int idDoc=1;

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

                   auxiliarPersona->id=h->Primero->id;

                   auxiliarPersona->documentos=h->Primero->Documentos;
                   cout<<auxiliarPersona->documentos<<endl;
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
    codigo+="node[shape=record]; \n";
    while(aux!=NULL&&aux->ColaPersonas->PasajeroAtendido!=NULL){

        auxper=aux->ColaPersonas->PasajeroAtendido;
        codigo=codigo+aux->Letra+"->Persona"+to_string(auxper->id)+";\n";
        while(auxper!=NULL){

            codigo+="Persona"+to_string(auxper->id)+"[label=\"{ ID: "+to_string(auxper->id)+" |Maletas: "+to_string(auxper->maletas)+"| Documentos: "+to_string(auxper->documentos)+" |Turnos:  "+to_string(auxper->tiemposentaquilla)+" <ref>}\"]; \n";

            auxper=auxper->PasajeroAnterior;
        }

        aux=aux->EscritorioSigueinte;
    }
    aux=Primero;
    while(aux!=NULL&&aux->ColaPersonas->PasajeroAtendido!=NULL){

        auxper=aux->ColaPersonas->PasajeroAtendido;

        while(auxper->PasajeroAnterior!=NULL){

           codigo+="Persona"+to_string(auxper->id)+"->Persona"+to_string(auxper->PasajeroAnterior->id)+"; \n";
            auxper=auxper->PasajeroAnterior;
        }

        aux=aux->EscritorioSigueinte;
    }
    codigo+="label=\"Escritorios\";  \n";





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
void ListaEscritorios::SacarPersonas(ListaMochilas *mo){
    Escritorio *aux;
    aux=Primero;


    while(aux!=NULL){
         Persona *auxper;
         auxper=aux->ColaPersonas->PasajeroAtendido;
        if(auxper!=NULL){
            if(auxper->tiemposentaquilla>0){
                auxper->tiemposentaquilla=auxper->tiemposentaquilla-1;
            }else{
            if(auxper->PasajeroAnterior!=NULL){

                     EliminarMaleta(mo,auxper->maletas);
             auxper=aux->ColaPersonas->PasajeroAtendido;
             aux->ColaPersonas->PasajeroAtendido=auxper->PasajeroAnterior;


                  delete(auxper);
                  //Aqui va crear



            }else{
                 EliminarMaleta(mo,auxper->maletas);


                aux->ColaPersonas->PasajeroAtendido=NULL;
                aux->ColaPersonas->UltimoPasajero=NULL;
            }
            }
        }
        aux=aux->EscritorioSigueinte;
    }

}
bool ListaEscritorios::EliminarMaleta(ListaMochilas *mo,int mochila){
    cout<<mochila<<endl;
    if(mo->Primera!=NULL){
        Mochilas *Corredor;
        Corredor=mo->Primera;
        int contador=mochila;
        cout<<"Se van a eliminar"<<mochila<<endl;
        while(contador>0){

           Mochilas *aux=Corredor;
           if(Corredor!=mo->Primera){
               aux->MochilaAnterior->MochilaSiguiente=aux->MochilaSiguiente;
               aux->MochilaSiguiente->MochilaAnterior=aux->MochilaAnterior;
               delete aux;
           }
           if(Corredor==mo->Primera){
               if(mo->Primera->MochilaSiguiente!=mo->Ultima){
                   mo->Ultima->MochilaSiguiente=aux->MochilaSiguiente;
                   mo->Primera=aux->MochilaSiguiente;
                   mo->Primera->MochilaAnterior=mo->Ultima;
                   delete aux;
               }else{
                   mo->Ultima=NULL;
                   mo->Primera=NULL;
               }

           }

           Corredor=Corredor->MochilaSiguiente;
contador=contador-1;
        }
    }

}








