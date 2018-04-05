using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace VoiceRecognitionMaze
{
    class Algoritmo_Busqueda
    {
       List<int> Obstaculos = new List<int>();
       
       public List<Nodo> encontrarNodosAdyacentes(int x, int y, int n, int m, List<int[]> Tablero,Boolean diagonal)
       {
            List<Nodo> adyacentes = new List<Nodo>();
            int[] pos = new int[2];
            
            if (x-1 >= 0 && Tablero[x-1][y] != 1)
            {

                pos[0] = x - 1;
                pos[1] = y;
                Nodo nodo = new Nodo(pos, 0); //Crea un nodo sólo con la posicion y el movimiento
                adyacentes.Add(nodo);

            }

            if(x+1 < m && Tablero[x+1][y] != 1)
            {
               
                pos[0] = x + 1;
                pos[1] = y;
                Nodo nodo = new Nodo(pos, 0);
                adyacentes.Add(nodo);

            }
            if(y-1 >=0 && Tablero[x][y-1] != 1)
            {
              
                pos[0] = x;
                pos[1] = y-1;
                Nodo nodo = new Nodo(pos, 0);
                adyacentes.Add(nodo);

            }
            if(y+1 < n && Tablero[x][y+1] != 1)
            {
                
                pos[0] = x;
                pos[1] = y + 1;
                Nodo nodo = new Nodo(pos, 0);
                adyacentes.Add(nodo);

            }

            if (diagonal == true)
            {
                if (x - 1 >= 0 && y - 1 >= 0 && Tablero[x - 1][y - 1] != 1)
                {
                   
                    pos[0] = x - 1;
                    pos[1] = y - 1;
                    Nodo nodo = new Nodo(pos, 1);
                    adyacentes.Add(nodo);
                }
                if (x + 1 < m && y - 1 >= 0 && Tablero[x + 1][y - 1] != 1)
                {
                    
                    pos[0] = x + 1;
                    pos[1] = y - 1;
                    Nodo nodo = new Nodo(pos, 1);
                    adyacentes.Add(nodo);
                }
                if (x - 1 >= 0 && y + 1 < n && Tablero[x - 1][y + 1] != 1)
                {
                    
                    pos[0] = x - 1;
                    pos[1] = y + 1;
                    Nodo nodo = new Nodo(pos, 1);
                    adyacentes.Add(nodo);
                }
                if (x + 1 < m && y + 1 < n && Tablero[x + 1][y + 1] != 1)
                {
                  
                    pos[0] = x + 1;
                    pos[1] = y + 1;
                    Nodo nodo = new Nodo(pos, 1);
                    adyacentes.Add(nodo);
                }
            }
            return adyacentes;
               
    }  
       public void calcular_fn(Nodo nodoActual, Nodo nodoFinal, List<Nodo> adyacentes, List<Nodo> listaAbierta, List<int[]> listaCerrada,int a,double costo_diagonal)
       {
           
           double fn;
           double gn;
           Nodo Nodo_Adyacente;
           
           foreach (Nodo nodo_abierto in adyacentes)
           {
               if (listaCerrada.Contains(nodo_abierto.posicion) == false)
               {
                  /* if (listaAbierta.Contains(nodo_abierto) == true)
                   {
                       if (nodo_abierto.movimiento == 0) 
                       {
                           suma_costos = costo_directo + nodoActual.gn;
                           if (suma_costos < nodo_abierto.gn) //Mejora el costo g(n)
                           {
                               nodo_abierto.nodoPadre = nodoActual;
                               nodo_abierto.gn = suma_costos;
                               fn = Math.Abs((nodo_abierto.posicion[0] - nodoFinal.posicion[0]) + Math.Abs(nodo_abierto.posicion[1] - nodoFinal.posicion[1]))*a + nodo_abierto.gn;
                           }
                       }
                       else
                       {
                           suma_costos = costo_diagonal + nodoActual.gn;
                           if (suma_costos < nodo_abierto.gn) //Mejora el costo g(n)
                           {
                               nodo_abierto.nodoPadre = nodoActual;
                               nodo_abierto.gn = suma_costos;
                               fn = Math.Abs((nodo_abierto.posicion[0] - nodoFinal.posicion[0]) + Math.Abs(nodo_abierto.posicion[1] - nodoFinal.posicion[1])) * a + nodo_abierto.gn;
                           }
                       }*/

                   if (nodo_abierto.movimiento == 0) // Si el movimiento es directo
                   {
                       gn = nodoActual.gn + a;
                   }
                   else
                   {
                       gn = nodoActual.gn + costo_diagonal; //Movimiento en diagonal
                   }
                   fn = Math.Abs((nodo_abierto.posicion[0] - nodoFinal.posicion[0]) + Math.Abs(nodo_abierto.posicion[1]- nodoFinal.posicion[1])) * a + gn;
                   Nodo_Adyacente = new Nodo(nodoActual, nodo_abierto.posicion, gn, fn,nodo_abierto.movimiento);//Se crea el nodo adyacente con el nodo padre, gn y fn calculados
                   listaAbierta.Add(Nodo_Adyacente); //Agrega todos los hijos del nodo actual.

                }
           }

       }

        public Boolean Algoritmo_AEstrella(Nodo nodo_n, Nodo nodo_final, int[] pos_n, int[] pos_final,int n, int m, int a, double costo_diagonal,Boolean diagonal, List<int[]> Tablero)
        {

           nodo_n = new Nodo(null, pos_n, 0, 0,0); //Posicion de inicio que se elija para el agente
           nodo_final = new Nodo(null, pos_final, 0, 0,0); //Posicion final que se elija para el agente

           List<Nodo> listaAbierta = new List<Nodo>();
           List<int[]> listaCerrada = new List<int[]>();
           List<Nodo> nodosAdyacentes = new List<Nodo>();


           while (nodo_n.posicion[0] != nodo_final.posicion[0] || nodo_n.posicion[1] != nodo_final.posicion[1])
           {
               listaCerrada.Add(nodo_n.posicion);
               nodosAdyacentes = encontrarNodosAdyacentes(nodo_n.posicion[0],nodo_n.posicion[1],n,m,Tablero,diagonal); //Encuentra los nodos adyacentes del nodo actual
               calcular_fn(nodo_n, nodo_final, nodosAdyacentes, listaAbierta, listaCerrada,a,costo_diagonal); //Calcula el fn de cada uno de los nodos adyacentes al nodo actual
               listaAbierta.OrderBy(f => f.fn); //Ordena los nodos de menor a mayor por el fn

               if (listaAbierta.Count == 0)
               {
                   Console.WriteLine("No se ha encontrado una ruta");
                   return false;

               }
               else
               {
                   nodo_n = listaAbierta[0];  //Actualiza el nodo actual al nodo con menor fn
                   listaAbierta.Remove(nodo_n); //Elimina el nodo de la lista abierta 
               }


           }
           listaCerrada.Add(nodo_n.posicion);
           return true;

       }
}


}

