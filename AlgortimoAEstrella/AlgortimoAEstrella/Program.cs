using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace AlgortimoAEstrella

{

   
    class Program
    {

        
        static int[,] Tablero; //Cuadricula donde 0 es vacio y 1 es obstaculo
        static int m, n, a,cant_obs;
        static Boolean mov_directo = false;
        static Boolean diagonal = true;
        //static List<Nodo> listaAbierta = new List<Nodo>();
        //static List<int[]> listaCerrada = new List<int[]>();

        //static ArrayList listaAbierta = new ArrayList();
        //static ArrayList listaCerrada = new ArrayList();
       
       


        static int[,] PonerRuta(ArrayList listaCerrada, int[,] tablero)
        {

            

            foreach (int[] value in listaCerrada)
            {
                tablero[value[0], value[1]] = -1;

            }
            return tablero;


        }

        static void imprimir_solucion(int[,] tablero)
        {
            Console.Write("Tablero con ruta\n");
            for (int f = 0; f < tablero.GetLength(0); f++)
            {
                for (int c = 0; c < tablero.GetLength(1); c++)
                {
                    Console.Write(tablero[f, c] + " ");
                }
                Console.WriteLine();


            }


        }

        static ArrayList encontrarNodosAdyacentes(Nodo nodoActual, Nodo nodoFinal, int n, int m, int[,] Tablero, float costo_diagonal)
        {
            int[] pos = new int[2];
            int[] movimiento = new int[1];
            //List<Nodo> adyacentes = new List<Nodo>();// [[x,y]]
            ArrayList adyacentes = new ArrayList();


            Console.Write("Encontrando nodos adyacentes\n");

            //Izquierda
            if (nodoActual.posicion[0] - 1 >= 0 && Tablero[nodoActual.posicion[0] - 1, nodoActual.posicion[1]] != 1)
            {
                pos[0] = nodoActual.posicion[0] - 1;
                pos[1] = nodoActual.posicion[1];

                adyacentes.Add(new Nodo(nodoActual,nodoFinal,pos, a + nodoActual.gn));

            }

            //Derecha
            if (nodoActual.posicion[0] + 1 < m && Tablero[nodoActual.posicion[0] + 1, nodoActual.posicion[1]] != 1)
            {

                pos[0] = nodoActual.posicion[0] + 1;
                pos[1] = nodoActual.posicion[1];
                adyacentes.Add(new Nodo(nodoActual, nodoFinal, pos, a + nodoActual.gn));

            }

            //Arriba
            if (nodoActual.posicion[1] - 1 >= 0 && Tablero[nodoActual.posicion[0], nodoActual.posicion[1] - 1] != 1)
            {

                pos[0] = nodoActual.posicion[0];
                pos[1] = nodoActual.posicion[1] - 1;
                adyacentes.Add(new Nodo(nodoActual, nodoFinal, pos, a + nodoActual.gn));

            }

            //Abajo
            if (nodoActual.posicion[1] + 1 < n && Tablero[nodoActual.posicion[0], nodoActual.posicion[1] + 1] != 1)
            {

                pos[0] = nodoActual.posicion[0];
                pos[1] = nodoActual.posicion[1] + 1;
                adyacentes.Add(new Nodo(nodoActual, nodoFinal, pos, a + nodoActual.gn));

            }

            //Diagonales
            if (diagonal == true)
            {
                if (nodoActual.posicion[0] - 1 >= 0 && nodoActual.posicion[1] - 1 >= 0 && Tablero[nodoActual.posicion[0] - 1, nodoActual.posicion[1] - 1] != 1)
                {

                    pos[0] = nodoActual.posicion[0] - 1;
                    pos[1] = nodoActual.posicion[1] - 1;
                    adyacentes.Add(new Nodo(nodoActual, nodoFinal, pos, costo_diagonal + nodoActual.gn));
                }
                if (nodoActual.posicion[0] + 1 < m && nodoActual.posicion[1] - 1 >= 0 && Tablero[nodoActual.posicion[0] + 1, nodoActual.posicion[1] - 1] != 1)
                {

                    pos[0] = nodoActual.posicion[0] + 1;
                    pos[1] = nodoActual.posicion[1] - 1;
                    adyacentes.Add(new Nodo(nodoActual, nodoFinal, pos, costo_diagonal + nodoActual.gn));
                }
                if (nodoActual.posicion[0] - 1 >= 0 && nodoActual.posicion[1] + 1 < n && Tablero[nodoActual.posicion[0] - 1, nodoActual.posicion[1] + 1] != 1)
                {

                    pos[0] = nodoActual.posicion[0] - 1;
                    pos[1] = nodoActual.posicion[1] + 1;
                    adyacentes.Add(new Nodo(nodoActual, nodoFinal, pos, costo_diagonal + nodoActual.gn));
                }
                if (nodoActual.posicion[0] + 1 < m && nodoActual.posicion[1] + 1 < n && Tablero[nodoActual.posicion[0] + 1, nodoActual.posicion[1] + 1] != 1)
                {

                    pos[0] = nodoActual.posicion[0] + 1;
                    pos[1] = nodoActual.posicion[1] + 1;
                    adyacentes.Add(new Nodo(nodoActual, nodoFinal, pos, costo_diagonal + nodoActual.gn));
                }
            }
            return adyacentes;

        }

        static void agregarNodoAListaAbierta(Nodo nodo)
        {
            int indice = 0;
            double costo = nodo.fn;

            while (listaAbierta.Count > indice)
            {
                Nodo n = (Nodo)listaAbierta[indice];
                if (costo < n.fn)
                {
                    indice++;
                }
                break;
            }
            listaAbierta.Insert(indice, nodo);

        }

            static void encontrar_ruta(Nodo nodoActual, Nodo nodoFinal, ArrayList adyacentes, ArrayList listaAbierta, ArrayList listaCerrada)
           {

            
            Console.Write("Calculando fn\n");

            foreach (Nodo nodo_abierto in adyacentes)
            {
                Console.Write("Reviso si el nodo esta cerrado\n");
                if (listaCerrada.Contains(nodo_abierto.posicion) == false)
                {
                    if (listaAbierta.Contains(nodo_abierto) == true)
                    {
                        if(nodo_abierto.gn >= nodoActual.gn)
                        {
                            continue;
                        }
                    }
                     
                    Console.Write("Agrego el nodo a la lista abiera \n");
                    //fn = Math.Abs((nodo_abierto.posicion[0] - nodoFinal.posicion[0]) + Math.Abs(nodo_abierto.posicion[1] - nodoFinal.posicion[1])) * a + gn;
                    //Nodo_Adyacente = new Nodo(nodoActual, nodo_abierto.posicion, gn, fn, nodo_abierto.movimiento);//Se crea el nodo adyacente con el nodo padre, gn y fn calculados
                    agregarNodoAListaAbierta(nodo_abierto); //Agrega todos los hijos del nodo actual.

                }
            }

        }

      
        static Boolean Algoritmo_A_Estrella(int[] pos_n, int[] pos_final, int n, int m, int a, float costo_diagonal)
        {
            Console.Write("Definiendo nodo inicial y final\n");

            listaAbierta.Clear();
            listaCerrada.Clear();

            Nodo nodo_final = new Nodo(null, null, pos_final, 0);
            Nodo nodo_inicial = new Nodo(null, nodo_final, pos_n, 0);

            // List<Nodo> nodosAdyacentes = new List<Nodo>();
            ArrayList nodosAdyacentes = new ArrayList();

            Console.Write("Estoy en el ciclo\n");

            while (nodo_inicial.posicion[0] != nodo_final.posicion[0] || nodo_inicial.posicion[1] != nodo_final.posicion[1])
            {
                Console.Write("Agrego nodo a lista cerrada\n");
                listaCerrada.Add(nodo_inicial.posicion);
                Console.Write("Buscar nodos adyacentes\n");
                nodosAdyacentes = encontrarNodosAdyacentes(nodo_inicial, nodo_final, n, m, Tablero,costo_diagonal); //Encuentra los nodos adyacentes del nodo actual
                Console.Write("Encontrar ruta");
                encontrar_ruta(nodo_inicial, nodo_final, nodosAdyacentes, listaAbierta, listaCerrada); //Calcula el fn de cada uno de los nodos adyacentes al nodo actual
                

            Console.Write("Reviso si existe solucion\n");
                if (listaAbierta.Count == 0)
                {
                    //Console.WriteLine("No se ha encontrado una ruta");
                    Console.Write("No encontre solucion\n");
                    return false;

                }
                else
                {
                    Console.Write("Actualizo nodo con menor fn\n");
                    nodo_inicial = (Nodo)listaAbierta[0];  //Actualia el nodo actual al nodo con menor fn
                    listaAbierta.Remove(nodo_inicial); //Elimina el nodo de la lista abierta 
                   
                }


            }
            Console.Write("Termine\n");
            listaCerrada.Add(nodo_inicial.posicion);
            int[,] ruta = PonerRuta(listaCerrada, Tablero);
            imprimir_solucion(ruta);


            return true;

        }

      
        static int[,] llenarArreglo(int[,] tablero)
        {
            for (int f = 0; f < tablero.GetLength(0); f++)
            {
                for (int c = 0; c < tablero.GetLength(1); c++)
                {
                    
                    tablero[f, c] = 0;
                }
            }
            return tablero;
        }

        static void Imprimir(int[,] tablero)
        {
            Console.Write("Tablero con obstaculos\n");

            for (int f = 0; f < tablero.GetLength(0); f++)
            {
                for (int c = 0; c < tablero.GetLength(1); c++)
                {
                    Console.Write(tablero[f, c] + " ");
                }
                Console.WriteLine();
            }
        }


        

        static int[,] PonerObstaculos(int[,] tablero, int cant_obstaculos, int m ,int n)
        {
            Random random = new Random();


            for (int i = 0; i <= cant_obstaculos; i++)
            {

                int f = random.Next(0, n-1);
              
                int c = random.Next(1,m-1);

                
                tablero[f, c] = 1;

            }
            return tablero;

        }

     
        static void Main(string[] args)
        {

            Program main = new Program();

            Console.WriteLine("Ingrese la cantidad de columnas m:");
            string columnas = Console.ReadLine();
            m = int.Parse(columnas);


            Console.WriteLine("Ingrese la cantidad de filas n:");
            string filas = Console.ReadLine();
            n = int.Parse(filas);

            Console.WriteLine("Ingrese la cantidad de obstaculos:");
            string obs = Console.ReadLine();
            cant_obs = int.Parse(obs);

            Console.WriteLine("Ingrese el tamanio de cada cuadro a:");
            string tamanio = Console.ReadLine();
            a = int.Parse(tamanio);

            Tablero = new int[m,n];

            //Posicion inicial y final en el tablero

            int[] pos_n = new int[2];
            int[] pos_final = new int[2];

            pos_n[0] = 0;
            pos_n[1] = 0;

            pos_final[0] = m - 1;
            pos_final[1] = n - 1;

            double costo_diagonal = Math.Sqrt(2) * a;

            //Llenar tablero con 0's

            for (int f = 0; f < Tablero.GetLength(0); f++)
            {
                for (int c = 0; c < Tablero.GetLength(1); c++)
                {

                    Tablero[f, c] = 0;
                }
            }

            Tablero[0, 0] = 2;
            Tablero[n - 1, m - 1] = 3;


            //Poner obstaculos aleatoriamente
            Random random = new Random();
            for (int i = 0; i <= cant_obs; i++)
            {

                int f = random.Next(0, n - 1);

                int c = random.Next(1, m - 1);


                Tablero[f, c] = 1;

            }

            Imprimir(Tablero);

            Console.Write("Ejecutando algoritmo estrella\n");
            Boolean solucion = Algoritmo_A_Estrella(pos_n, pos_final, n, m, a, (float)costo_diagonal);

           
            if(solucion == true)
            {
                Console.Write("Hay solucion");
                
            }
            else
            {
                Console.Write("No hay solucion");
               
            }

            Console.ReadKey();





        }
    }
}
