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
        public Nodo nodoFinal;
        public float fn;
        public float gn;
        public int[] posicion = new int[2];

        public Nodo(Nodo NodoPadre,Nodo NodoFinal, int[] Posicion, float costo_gn)
        {

            nodoPadre = NodoPadre;
            posicion = Posicion;
            gn = costo_gn;
            nodoFinal = NodoFinal;
            

            if (nodoFinal != null)
            {
                Console.Write("Calcular fn\n");
                fn= gn + CalcularHeuristica();
            }


        }

        public float CalcularHeuristica()
        {
            return (int)(Math.Sqrt(Math.Pow((posicion[0] - nodoFinal.posicion[0]), 2) + Math.Pow((posicion[1] -nodoFinal.posicion[1]), 2)));
            //return Math.Abs((posicion[0] - nodoFinal.posicion[0]) + Math.Abs(posicion[1] - nodoFinal.posicion[1]));
        }

        

    }

}

