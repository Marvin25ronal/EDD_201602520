#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <avion.h>
#include <iostream>
#include <imagen.h>
#include <pasajeros.h>
#include <escritorios.h>
#include <QScrollArea>
#include <mantenimiento.h>

int contador=1;
int contadorPasajero=0;
Lista *A=new Lista;
Imagen im;
ListaMochilas *mo=new ListaMochilas;
ListaEscritorios *e=new ListaEscritorios;
ListaPasajeros *pa=new ListaPasajeros;
ListaHangar *Han=new ListaHangar;

using namespace std;
MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{

    ui->setupUi(this);
    ui->scrollArea->setWidget(ui->Imagen);

    ui->pushButton_2->setVisible(false);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_pushButton_clicked()
{


  QString aux=ui->Aviones->text();


  A->setAviones(aux.toInt());
    aux=ui->Escritorios->text();

   e->setEscritorio(aux.toInt());
   A->setEsctritorios(aux.toInt());
  aux=ui->Turnos->text();
  A->setTiempos(aux.toInt());
  aux=ui->Estaciones->text();
  cout<<"Estos son los de mantenimiento "<<aux.toInt()<<endl;
   Han->setHangares(aux.toInt());

  if(A->VerificarDatos()==true){
      ui->pushButton->setVisible(false);
      ui->pushButton_2->setVisible(true);
 e->insertarEscritorio();
Han->insertar();

  }else{
      ui->Consola->setText("Porfavor verifique los datos");

  }

}

void MainWindow::on_pushButton_2_clicked()
{
    if(A->getTiempos()>0){
        A->insertarAvion(contador);
        contador++;
       if(A->VerificarTurnosAvion()==true){
          pa->InsertarPasajero(A->Primero->Pasajeros);
          mo->insertarMochila(pa);
          e->CodigoEscritorios();

                    A->Eliminar();

          }
   e->CrearPilaEscritorio();
        e->VerificarEscritorios(pa);


       e->SacarPersonas(mo);


    e->Imprimir();

        im.GenerarCodigo(A->CodigoAvion(),pa->CodigoDesabordaje(),mo->CodigoMoschilas(),e->CodigoEscritorios(),Han->CodigoHangar(),A->codigo2());
        QPixmap pix("/home/marvin/Diagram.jpg");

        ui->Imagen->setPixmap(pix);

        A->setTiempos(A->getTiempos()-1);
    }else{
        exit(0);
    }


}
