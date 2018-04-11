using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace AlgortimoAEstrella
{
    class Program
    {


        static int[,] Tablero; //Cuadricula donde 0 es vacio y 1 es obstaculo

        static int m, n, a, cant_obs;
        static double costo_diagonal;
        static Boolean diagonal;

        static List<Nodo> listaAbierta = new List<Nodo>();
        static List<int[]> listaCerrada = new List<int[]>();
        static List<int[]> Ruta = new List<int[]>();
        static List<Nodo> nodosAdyacentes = new List<Nodo>();


        //----------------------------------------Métodos para imprimir------------------------------------------------------------

        static void imprimir_ListaCerrada(List<int[]> cerrada)
        {
            foreach (int[] value in cerrada)
            {
                Console.Write("[" + value[0] + "," + value[1] + "]" + " ");
                Console.WriteLine();
            }
        }


        static void imprimir_ListaAbierta(List<Nodo> abierta)
        {
            foreach (Nodo value in abierta)
            {
                Console.Write("[" + value.posicion[0] + "," + value.posicion[1] + "]" + " ");
                Console.WriteLine();
            }
        }

        static void imprimir_Adyacentes(List<Nodo> adyacentes)
        {
            foreach (Nodo value in adyacentes)
            {
                Console.Write("[" + value.posicion[0] + "," + value.posicion[1] + "]" + " ");
                Console.WriteLine();
            }
        }

        static void imprimir_solucion(int[,] tablero)
        {
            Console.Write("Tablero con ruta\n");
            Console.WriteLine();

            for (int f = 0; f < tablero.GetLength(0); f++)
            {
                for (int c = 0; c < tablero.GetLength(1); c++)
                {
                    Console.Write(tablero[f, c] + " ");
                }
                Console.WriteLine();

            }
        }

        static void Imprimir_Tablero_Obstaculos(int[,] tablero)
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

        //----------------------------------------------------Métodos para modificar el tablero----------------------------------------------------------------------


        //Marca la ruta en el tablero de acuerdo al mejor camino obtenido
        static int[,] PonerRuta(List<int[]> ruta, int[,] tablero)
        {
            foreach (int[] value in ruta)
            {

                if(tablero[value[0], value[1]] == 2)
                {
                    continue;
                }
                if (tablero[value[0], value[1]] == 3)
                {
                    continue;
                }
                tablero[value[0], value[1]] = 4;

            }
            return tablero;


        }

        //LLena el arreglo con 0's
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

        //Obtiene las posiciones disponibles en el tablero para poner obstaculos
        static List<int[]> ObtenerPosicionesDisponibles(int[,] tablero, int n, int m)
        {

            List<int[]> posDisponibles = new List<int[]>();

            posDisponibles.Clear();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int[] posiciones = new int[3];

                    if (tablero[i, j] != 0)
                    {

                    }
                    else
                    {
                        posiciones[0] = i;
                        posiciones[1] = j;

                        posDisponibles.Add(posiciones);


                        /*Console.Write("Lo que tiene el arreglo en el momento\n");
                        foreach (int[] value in posDisponibles)
                        {
                            
                            Console.Write("[" + value[0] + "," + value[1] + "]" + " ");
                            Console.WriteLine();
                        }*/


                    }

                }

            }
            return posDisponibles;
        }

        //Determina si un valor en el tablero ya está ocupado
        static Boolean valorOcupado(List<int[]> posOcupadas, List<int[]> pos_disponibles, int pos)
        {
            foreach (int[] value in posOcupadas)
            {
                if (value[0] == pos_disponibles[pos][0] && value[1] == pos_disponibles[pos][1])
                {
                    return true;
                }
                continue;

            }
            return false;
        }

        //Pone los obstaculos en el tablero en las posiciones disponibles
        static int[,] PonerObstaculos(int[,] tablero, List<int[]> pos_disponibles, int cant_obstaculos)
        {
            int i = 0;
            int x = 0;
            int y = 0;
            Boolean estado;

            List<int[]> posOcupadas = new List<int[]>();
            Random random = new Random();

            while (i < cant_obstaculos)
            {
                estado = true;

                while (estado)
                {

                    //Console.Write("Posicion random en el ciclo \n");
                    int pos = random.Next(0, pos_disponibles.Count());
                    //Console.Write(pos);
                    //Console.WriteLine();

                    if (valorOcupado(posOcupadas, pos_disponibles, pos) == true)
                    {


                        //Console.Write("Existe elemento en la lista ocupada \n");


                        /*Console.Write("Pos disponibles \n");
                        Console.Write(pos_disponibles[pos][0]);
                        Console.WriteLine();
                        Console.Write(pos_disponibles[pos][1]);
                        Console.WriteLine();*/
                        estado = true;
                    }
                    else
                    {


                        int[] ocupadas = new int[3];

                        //Console.Write("Posicion x\n");
                        x = pos_disponibles[pos][0];
                        //Console.Write(x);
                        //Console.WriteLine();
                        //Console.Write("Posicion y\n");
                        y = pos_disponibles[pos][1];
                        //Console.Write(y);
                        //Console.WriteLine();

                        ocupadas[0] = x;
                        ocupadas[1] = y;

                        tablero[x, y] = 1;
                        posOcupadas.Add(ocupadas);


                        /*Console.Write("Posiciones ocupadas\n");
                        foreach (int[] value in posOcupadas)
                        {

                            Console.Write("[" + value[0] + "," + value[1] + "]" + " ");
                            Console.WriteLine();
                        }*/

                        estado = false;
                    }

                }
                i += 1;
            }
            return tablero;
        }

        //-------------------------------------------------Algoritmo de Búsqueda A Estrella-------------------------------------------------------------

        //Encuentra los nodos adyacentes del nodo actual
        static List<Nodo> encontrarNodosAdyacentes(Nodo nodoActual, int[,] Tablero,Boolean estado_diagonal)
        { 
            List<Nodo> adyacentes = new List<Nodo>();
            int x = nodoActual.posicion[0];
            int y = nodoActual.posicion[1];

            //Console.Write("Encontrando nodos adyacentes\n");
            if (x - 1 >= 0 && Tablero[x - 1, y] != 1)
            {
                int[] posIz = new int[2];
                posIz[0] = x - 1;
                posIz[1] = y;

                Nodo nodo = new Nodo(posIz, 0);  //Crea un nodo sólo con la posicion y el movimiento
                adyacentes.Add(nodo);
            }

            if (x + 1 < m && Tablero[x + 1, y] != 1)
            {
                int[] posDer = new int[2];
                posDer[0] = x + 1;
                posDer[1] = y;
                Nodo nodo = new Nodo(posDer, 0);
                adyacentes.Add(nodo);
            }

            if (y - 1 >= 0 && Tablero[x, y - 1] != 1)
            {
                int[] posArriba = new int[2];
                posArriba[0] = x;
                posArriba[1] = y - 1;
                Nodo nodo = new Nodo(posArriba, 0);
                adyacentes.Add(nodo);
            }

            if (y + 1 < n && Tablero[x, y + 1] != 1)
            {
                int[] posAbajo = new int[2];
                posAbajo[0] = x;
                posAbajo[1] = y + 1;
                Nodo nodo = new Nodo(posAbajo, 0);
                adyacentes.Add(nodo);
            }

            //Revisa diagonales
            if (estado_diagonal)
            {
                if (x - 1 >= 0 && y - 1 >= 0 && Tablero[x - 1, y - 1] != 1)
                {
                    int[] ArribaIzq = new int[2];
                    ArribaIzq[0] = x - 1;
                    ArribaIzq[1] = y - 1;
                    Nodo nodo = new Nodo(ArribaIzq, 1);
                    adyacentes.Add(nodo);
                }

                if (x + 1 < m && y - 1 >= 0 && Tablero[x + 1, y - 1] != 1)
                {
                    int[] ArribaDer = new int[2];
                    ArribaDer[0] = x + 1;
                    ArribaDer[1] = y - 1;
                    Nodo nodo = new Nodo(ArribaDer, 1);
                    adyacentes.Add(nodo);
                }

                if (x - 1 >= 0 && y + 1 < n && Tablero[x - 1, y + 1] != 1)
                {
                    int[] AbajoIzq = new int[2];
                    AbajoIzq[0] = x - 1;
                    AbajoIzq[1] = y + 1;
                    Nodo nodo = new Nodo(AbajoIzq, 1);
                    adyacentes.Add(nodo);
                }

                if (x + 1 < m && y + 1 < n && Tablero[x + 1, y + 1] != 1)
                {
                    int[] AbajoDer = new int[2];
                    AbajoDer[0] = x + 1;
                    AbajoDer[1] = y + 1;
                    Nodo nodo = new Nodo(AbajoDer, 1);
                    adyacentes.Add(nodo);
                }
            }
            return adyacentes;
        }

        //Agregar un nodo a la lista abierta de forma ordenada
        static void agregarNodoAListaAbierta(Nodo nodo)
        {
            Int32 indice = 0;
            double costo = nodo.fn;
            while ((listaAbierta.Count() > indice) &&
            (costo < listaAbierta[indice].fn))
            {
                indice++;
            }
            listaAbierta.Insert(indice, nodo);
        }

        //Calcula la heuristica de cada uno de los nodos adyacentes
        static void calcular_fn(Nodo nodoActual, Nodo nodoFinal, List<Nodo> adyacentes, List<Nodo> listaAbierta, List<int[]> listaCerrada,double costoDiagonal)
        {
            double fn;
            double gn;
            Nodo Nodo_Adyacente;

            foreach (Nodo nodo_abierto in adyacentes)
            {

                if (!listaCerrada.Contains(nodo_abierto.posicion))
                {
                    if (nodo_abierto.movimiento == 0) // Si el movimiento es directo
                    {
                        gn = nodoActual.gn + a;
                    }
                    else
                    {
                        gn = nodoActual.gn + costoDiagonal; //Movimiento en diagonal
                    }

                   
                    fn = (Math.Abs(nodo_abierto.posicion[0] - nodoFinal.posicion[0]) + Math.Abs(nodo_abierto.posicion[1] - nodoFinal.posicion[1])) * a + gn;
                    Nodo_Adyacente = new Nodo(nodoActual, nodo_abierto.posicion, gn, fn, nodo_abierto.movimiento);//Se crea el nodo adyacente con el nodo padre, gn y fn calculados
                    agregarNodoAListaAbierta(Nodo_Adyacente);//Agrega todos los hijos del nodo actual.
                    

                }
                
            }

        }

        static List<int[]> Algoritmo_A_Estrella(int[] pos_n, int[] pos_final, double costo, Boolean diagonal,int[,] Tablero)
        {
            Nodo nodo_n = new Nodo(null, pos_n, 0, 0, 0); //Posicion de inicio que se elija para el agente
            Nodo nodo_final = new Nodo(null, pos_final, 0, 0, 0); //Posicion final que se elija para el agente

            listaAbierta.Clear();
            listaCerrada.Clear();
            nodosAdyacentes.Clear();

            agregarNodoAListaAbierta(nodo_n);

            while (listaAbierta.Count() > 0)
            {
                Nodo nodoActual = listaAbierta[listaAbierta.Count() - 1];
                if (nodoActual.posicion[0] == nodo_final.posicion[0] && nodoActual.posicion[1] == nodo_final.posicion[1])
                {
                    List<int[]> mejorCamino = new List<int[]>();
                    while (nodoActual != null)
                    {
                        mejorCamino.Insert(0, nodoActual.posicion);
                        nodoActual = nodoActual.nodoPadre;
                    }
                    return mejorCamino;
                }
                listaAbierta.Remove(nodoActual);
                
                nodosAdyacentes = encontrarNodosAdyacentes(nodoActual, Tablero, diagonal); //Encuentra los nodos adyacentes del nodo actual
                calcular_fn(nodoActual, nodo_final, nodosAdyacentes, listaAbierta, listaCerrada,costo); //Calcula el fn de cada uno de los nodos adyacentes al nodo actual
                listaCerrada.Add(nodoActual.posicion);
            }
           
            return null;
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

            Tablero = new int[m, n];

            //Inicializar tablero con 0's y marcar inicio y fin
            llenarArreglo(Tablero);
            Tablero[1, 2] = 2;
            Tablero[m - 2, n - 2] = 3;

            //Coordenadas de la posicion de inicio y fin
            int[] pos_n = new int[3];
            int[] pos_final = new int[3];

            pos_n[0] = 1;
            pos_n[1] = 2;

            pos_final[0] = m - 2;
            pos_final[1] = n - 2;


            costo_diagonal = Math.Sqrt(2) * a;
            diagonal = true;

            //Sacar posiciones disponibles donde puedo poner obstaculos
            List<int[]> disponibles = new List<int[]>();
            disponibles = ObtenerPosicionesDisponibles(Tablero, n, m);

            /*foreach( int[] value in disponibles)
            {
                Console.Write("Posiciones disponibles\n");
                Console.Write("[" + value[0] + "," + value[1] + "]" + " ");
                Console.WriteLine();
            }*/

            //Tablero con obstaculos puestos
            PonerObstaculos(Tablero, disponibles, cant_obs);
            Imprimir_Tablero_Obstaculos(Tablero);
            Console.WriteLine();


            Console.Write("Ejecutando algoritmo estrella\n");
            Console.WriteLine();
            Ruta = Algoritmo_A_Estrella(pos_n, pos_final, costo_diagonal,diagonal,Tablero);

            if (Ruta == null)
            {
                Console.Write("No hay solucion\n");
            }
            else
            {
                Console.Write("Existe Solución\n");
                Console.WriteLine();
                int[,] ruta = PonerRuta(Ruta, Tablero);
                imprimir_solucion(ruta);
            }

            /*foreach (int[] value in Ruta)
            {
                Console.Write("Mejor camino\n");
                Console.Write("[" + value[0] + "," + value[1] + "]" + " ");
                Console.WriteLine();
            }*/

            Console.ReadKey();

        }
    }
}
