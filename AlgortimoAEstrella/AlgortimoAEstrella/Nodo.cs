using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;



namespace AlgortimoAEstrella
{

    class Nodo
    {
        public Nodo nodoPadre;
        public double fn;
        public double gn;
        public int movimiento;
        public int[] posicion = new int[2];


        public Nodo(Nodo NodoPadre, int[] Posicion, double costoDirecto, double costoTotal, int Movimiento)
        {

            nodoPadre = NodoPadre;
            posicion = Posicion;
            fn = costoTotal;
            gn = costoDirecto;
            movimiento = Movimiento;



        }

        public Nodo(int[] Posicion, int Movimiento)
        {
            posicion = Posicion;
            movimiento = Movimiento;

        }

        public Boolean esIgual(Nodo nodo)
        {
            return (posicion[0] == nodo.posicion[0] && posicion[1] == nodo.posicion[1]);
        }

    }

}





