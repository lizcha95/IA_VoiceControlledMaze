using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlgortimoAEstrella
{
     class Nodo
    {
        public Nodo nodoPadre;
        public float fn;
        public float gn;
        public Vector posicion;
        
   
      public Nodo(Nodo NodoPadre, Vector Posicion, float costoDirecto, float costoTotal)
      {

            nodoPadre = NodoPadre;
            posicion = Posicion;
            fn = costoTotal;
            gn = costoDirecto;
          


        }
        


   
        
    
        


    }
}
