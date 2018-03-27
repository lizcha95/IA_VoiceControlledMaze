using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgortimoAEstrella
{
    class Algoritmo_Busqueda
    {
        public int costo_directo;
        public float costo_diagonal;
        Nodo nodoinicio;
        Nodo nodofinal;


        //Necesito interfaz
        public List<Nodo> encontrarNodosAdyacentes(int x, int y)
        {


        }

        //Necesito interfaz
        public List<Nodo> calcular_fn(Nodo nodoActual,Nodo nodoFinal,List<Nodo> adyacentes,List<Nodo> listaAbierta,List<Vector> listaCerrada)
        {

            float suma_costos;
            float fn;
            Nodo Nodo_Adyacente;
            Nodo Padre_actualizado;

            foreach(Nodo nodo_abierto in adyacentes)
            {
                if(listaCerrada.Contains(nodo_abierto.posicion) == false)
                {
                    if(listaAbierta.Contains(nodo_abierto) == true)
                    {
                        if (moverseDirecto)
                        {
                            suma_costos = costo_directo + nodoActual.gn;
                            if(suma_costos < nodo_abierto.gn) //Mejora el costo g(n)
                            {
                                nodo_abierto.nodoPadre = nodoActual;
                                nodo_abierto.gn = suma_costos;
                                fn = Math.Abs(nodo_abierto.posicion.posx - nodoFinal.posicion.posx) + Math.Abs(nodo_abierto.posicion.posy - nodoFinal.posicion.posy) + nodo_abierto.gn;
                            }
                        }
                        else
                        {
                            suma_costos = costo_diagonal + nodoActual.gn;
                            if (suma_costos < nodo_abierto.gn) //Mejora el costo g(n)
                            {
                                nodo_abierto.nodoPadre = nodoActual;
                                nodo_abierto.gn = suma_costos;
                                fn = Math.Abs(nodo_abierto.posicion.posx - nodoFinal.posicion.posx) + Math.Abs(nodo_abierto.posicion.posy - nodoFinal.posicion.posy) + nodo_abierto.gn;
                            }
                        }

                    }

                    if (moverseDirecto)
                    {
                        nodo_abierto.gn = nodoActual.gn + costo_directo;
                    }
                    else
                    {
                        nodo_abierto.gn = nodoActual.gn + costo_diagonal;
                    }
                    fn = Math.Abs(nodo_abierto.posicion.posx - nodoFinal.posicion.posx) + Math.Abs(nodo_abierto.posicion.posy - nodoFinal.posicion.posy) + nodo_abierto.gn;
                    Padre_actualizado = nodo_abierto.nodoPadre = nodoActual;
                    Nodo_Adyacente = new Nodo(Padre_actualizado, nodo_abierto.posicion, nodo_abierto.gn, nodo_abierto.fn);
                    listaAbierta.Add(Nodo_Adyacente);

                }
            }
           
        }


        public Boolean Algoritmo_AEstrella(Nodo nodo_n, Nodo nodoFinal)

        {
            Vector posicionInicio = new Vector(0, 0);
            Vector posicionFinal = new Vector(3, 2);

            nodo_n = new Nodo(null, posicionInicio, 0, 0);
            nodoFinal = new Nodo(null, posicionFinal, 0, 0);

            List<Nodo> listaAbierta = new List<Nodo>();
            List<Vector> listaCerrada = new List<Vector>();
            List<Nodo> nodosAdyacentes = new List<Nodo>();
           
          
            while (nodo_n.posicion.posx != nodofinal.posicion.posx || nodo_n.posicion.posy != nodoFinal.posicion.posy )
            {
                listaCerrada.Add(nodo_n.posicion);
                nodosAdyacentes = encontrarNodosAdyacentes(nodo_n.posicion.posx,nodo_n.posicion.posy);
                calcular_fn(nodo_n,nodoFinal,nodosAdyacentes,listaAbierta,listaCerrada);
                listaAbierta.OrderBy(f => f.fn);

                if (listaAbierta.Count == 0)
                {
                    Console.WriteLine("No hay ruta posible");
                    return false;

                }
                else
                {
                    nodo_n = listaAbierta[0];
                    listaAbierta.Remove(nodo_n);
                }
           

            }
            listaCerrada.Add(nodo_n.posicion);
            return true;

        }


    }
}
