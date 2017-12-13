#include "mainwindow.h"
#include "ui_mainwindow.h"
#include <avion.h>
#include <iostream>
#include <imagen.h>
int contador=1;
Lista A;
Imagen im;
using namespace std;
MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    ui->setupUi(this);
    ui->pushButton_2->setVisible(false);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::on_pushButton_clicked()
{


  QString aux=ui->Aviones->text();
  A.setAviones(aux.toInt());

  aux=ui->Turnos->text();
  A.setTiempos(aux.toInt());

  if(A.VerificarDatos()==true){
      ui->pushButton->setVisible(false);
      ui->pushButton_2->setVisible(true);
  }else{
      ui->Consola->setText("Porfavor verifique los datos");

  }

}

void MainWindow::on_pushButton_2_clicked()
{
    if(A.getTiempos()>0){
        A.insertarAvion(contador);
        contador++;
        A.VerificarTurnosAvion();
        im.GenerarCodigo(A.CodigoAvion());
        QPixmap pix("/home/marvin/Diagram.jpg");

        ui->Imagen->setPixmap(pix.scaled(761,451,Qt::KeepAspectRatio));
        A.setTiempos(A.getTiempos()-1);
    }else{
        exit(0);
    }


}
