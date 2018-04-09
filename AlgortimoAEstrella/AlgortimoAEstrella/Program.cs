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

        List<int[]> Obstaculos = new List<int[]>();
        static int[,] Tablero; //Cuadricula donde 0 es vacio y 1 es obstaculo
        static string[,] Ruta;
       
        static int m, n, a, cant_obs;
        static Boolean mov_directo = false;
        static List<Nodo> listaAbierta = new List<Nodo>();
        static List<int[]> listaCerrada = new List<int[]>();
        static List<int[]> Ruta_Nodo = new List<int[]>();
        static List<Nodo> nodosAdyacentes = new List<Nodo>();



        static int[,] PonerRuta(List<int[]> listaCerrada, int[,] tablero)
        {
            foreach (int[] value in listaCerrada)
            {
                tablero[value[0], value[1]] = 4;

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


        static string[,] llenarTableroRuta(int[,] tablero)
        {

            for (int f = 0; f < tablero.GetLength(0); f++)
            {
                for (int c = 0; c < tablero.GetLength(1); c++)
                {
                    
                    Ruta[f, c] = "O";
                }
            }
            return Ruta;
        }

        static string[,] PonerCamino(List<int[]> listaCerrada, string[,] tablero)
        {
            foreach (int[] value in listaCerrada)
            {
                
                tablero[value[0], value[1]] = "X";

            }
            return tablero;


        }

        static List<Nodo> encontrarNodosAdyacentes(int x, int y, int n, int m, int[,] Tablero, Boolean diagonal)
        {
            int[] pos = new int[2];
            int[] movimiento = new int[1];
            List<Nodo> adyacentes = new List<Nodo>();// [[x,y]]

            Console.Write("Encontrando nodos adyacentes\n");
            if (x - 1 >= 0 && Tablero[x - 1, y] != 1)
            {


                pos[0] = x - 1;
                pos[1] = y;


                //[x-1,y]

                Nodo nodo = new Nodo(pos, 0);
                adyacentes.Add(nodo);

                //Nodo nodo = new Nodo(pos, 0); //Crea un nodo sólo con la posicion y el movimiento

            }

            if (x + 1 < m && Tablero[x + 1, y] != 1)
            {

                pos[0] = x + 1;
                pos[1] = y;
                Nodo nodo = new Nodo(pos, 0);
                adyacentes.Add(nodo);

            }
            if (y - 1 >= 0 && Tablero[x, y - 1] != 1)
            {

                pos[0] = x;
                pos[1] = y - 1;
                Nodo nodo = new Nodo(pos, 0);
                adyacentes.Add(nodo);

            }
            if (y + 1 < n && Tablero[x, y + 1] != 1)
            {

                pos[0] = x;
                pos[1] = y + 1;
                Nodo nodo = new Nodo(pos, 0);
                adyacentes.Add(nodo);

            }

            if (diagonal == true)
            {
                if (x - 1 >= 0 && y - 1 >= 0 && Tablero[x - 1, y - 1] != 1)
                {

                    pos[0] = x - 1;
                    pos[1] = y - 1;
                    Nodo nodo = new Nodo(pos, 1);
                    adyacentes.Add(nodo);
                }
                if (x + 1 < m && y - 1 >= 0 && Tablero[x + 1, y - 1] != 1)
                {

                    pos[0] = x + 1;
                    pos[1] = y - 1;
                    Nodo nodo = new Nodo(pos, 1);
                    adyacentes.Add(nodo);
                }
                if (x - 1 >= 0 && y + 1 < n && Tablero[x - 1, y + 1] != 1)
                {

                    pos[0] = x - 1;
                    pos[1] = y + 1;
                    Nodo nodo = new Nodo(pos, 1);
                    adyacentes.Add(nodo);
                }
                if (x + 1 < m && y + 1 < n && Tablero[x + 1, y + 1] != 1)
                {

                    pos[0] = x + 1;
                    pos[1] = y + 1;
                    Nodo nodo = new Nodo(pos, 1);
                    adyacentes.Add(nodo);
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


        static void calcular_fn(Nodo nodoActual, Nodo nodoFinal, List<Nodo> adyacentes, List<Nodo> listaAbierta, List<int[]> listaCerrada, int a, double costo_diagonal)
        {
         
            double fn;
            double gn;
            Nodo Nodo_Adyacente;
            Console.Write("Calculando fn\n");

            foreach (Nodo nodo_abierto in adyacentes)
            {
                Console.Write("Reviso si el nodo esta cerrado\n");

                if (!listaCerrada.Contains(nodo_abierto.posicion))
                {

                    if (nodo_abierto.movimiento == 0) // Si el movimiento es directo
                    {
                        Console.Write("Movimiento directo\n");
                        gn = nodoActual.gn + a;
                    }
                    else
                    {
                        Console.Write("Movimiento diagonal\n");
                        gn = nodoActual.gn + costo_diagonal; //Movimiento en diagonal
                    }

                    Console.Write("Calculo heuristica\n");
                    fn = (Math.Abs(nodo_abierto.posicion[0] - nodoFinal.posicion[0]) + Math.Abs(nodo_abierto.posicion[1] - nodoFinal.posicion[1]))*a+ gn;
                    
                    Nodo_Adyacente = new Nodo(nodoActual, nodo_abierto.posicion, gn, fn, nodo_abierto.movimiento);//Se crea el nodo adyacente con el nodo padre, gn y fn calculados
                    agregarNodoAListaAbierta(Nodo_Adyacente);
                    //listaAbierta.Add(Nodo_Adyacente); //Agrega todos los hijos del nodo actual.

                }
                Console.Write("Ignoro el nodo");
            }

            }

        static Boolean Algoritmo_A_Estrella(int[] pos_n, int[] pos_final, int n, int m, int a, double costo_diagonal, Boolean diagonal, int[,] Tablero)
        {
            Console.Write("Definiendo nodo inicial y final\n");
            Nodo nodo_n = new Nodo(null, pos_n, 0, 0, 0); //Posicion de inicio que se elija para el agente
            Nodo nodo_final = new Nodo(null, pos_final, 0, 0, 0); //Posicion final que se elija para el agente

            listaAbierta.Clear();
            listaCerrada.Clear();
            nodosAdyacentes.Clear();



            Console.Write("Estoy en el ciclo\n");

            while (nodo_n.posicion[0] != nodo_final.posicion[0] && nodo_n.posicion[1] != nodo_final.posicion[1])
            {
                Console.Write("Agrego nodo a lista cerrada\n");
                listaCerrada.Add(nodo_n.posicion);
                

                nodosAdyacentes = encontrarNodosAdyacentes(nodo_n.posicion[0], nodo_n.posicion[1], n, m, Tablero, diagonal); //Encuentra los nodos adyacentes del nodo actual
                calcular_fn(nodo_n, nodo_final, nodosAdyacentes, listaAbierta, listaCerrada, a, costo_diagonal); //Calcula el fn de cada uno de los nodos adyacentes al nodo actual
                Console.Write("Ordeno lista abierta por fn\n");
                //listaAbierta.OrderBy(f => f.fn); //Ordena los nodos de menor a mayor por el fn

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
                    nodo_n = listaAbierta[0];  //Actualiza el nodo actual al nodo con menor fn
                    listaAbierta.Remove(listaAbierta[0]); //Elimina el nodo de la lista abierta 
                }


            }
            Console.Write("Termine\n");
            
            listaCerrada.Add(nodo_n.posicion);
           



            int[,] ruta = PonerRuta(listaCerrada, Tablero);
            imprimir_solucion(ruta);
            //string [,] obstaculos = PonerObstaculosString(llenarTableroRuta(Tablero), Tablero);
            //imprimir_solucion(obstaculos);
            //string[,] ruta = PonerCamino(listaCerrada,obstaculos);
            //imprimir_solucion(ruta);


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


        static string[,] PonerObstaculosString(string[,] tablero1, int[,] tablero2)
        {

            for (int i = 0; i < tablero2.GetLength(0); i++)
            {
                for (int j = 0; j < tablero2.GetLength(1); j++)
                {
                    if (tablero2[i, j] == 1)
                    {
                        tablero1[i, j] = "z";
                    }
                    if(tablero2[i,j] == 2)
                    {
                        tablero1[i, j] = "2";
                    }
                    if (tablero2[i, j] == 3)
                    {
                        tablero1[i, j] = "3";
                    }

                }
            }
            return tablero1;

        }


        static int[,] PonerObstaculos(int[,] tablero, int cant_obstaculos, int m, int n)
        {
            Random random = new Random();


            for (int i = 0; i <= cant_obstaculos; i++)
            {

                int f = random.Next(0, n - 1);

                int c = random.Next(1, m - 1);


                tablero[f, c] = 1;

            }
            return tablero;

        }

        public void entradas()
        {
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

        }

        public void InicializarTablero()
        {

            Tablero = new int[n, m];

            int[,] tablero_lleno = llenarArreglo(Tablero);
            tablero_lleno[0, 0] = 2;
            tablero_lleno[m - 1, n - 1] = 3;


            int[,] tablero_obstaculos = PonerObstaculos(tablero_lleno, cant_obs, m, n);
            Imprimir(tablero_obstaculos);





        }

        public void Algoritmo_Estrella(int[,] tablero)
        {
            int[] pos_n = { 0, 0 };
            int[] pos_final = { m - 1, n - 1 };
            double costo_diagonal = Math.Sqrt(2) * a;


            //List<int[]> solucion = Algoritmo_A_Estrella(pos_n, pos_final, n, m, a, costo_diagonal, true, tablero);

            //int[,] ruta = PonerRuta(solucion, tablero);
            //imprimir_solucion(ruta);


            Console.Write("Lista Cerrada");

            /* foreach(int[] value in solucion)
             {
                 Console.WriteLine(value);
             }*/




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

            Tablero = new int[n, m];
            Ruta = new string[n, m];

            llenarArreglo(Tablero);
            Tablero[0, 0] = 2;
            Tablero[m - 1, n- 1] = 3;


            int[] pos_n = new int[2];
            int[] pos_final = new int[2];

            pos_n[0] = 0;
            pos_n[1] = 0;

            pos_final[0] = n - 1;
            pos_final[1] = m - 1;

            double costo_diagonal = Math.Sqrt(2) * a;

            
            int[,] tablero_obstaculos = PonerObstaculos(Tablero, cant_obs, m, n);
            Imprimir(tablero_obstaculos);

            
           

        

            Console.Write("Ejecutando algoritmo estrella\n");
            Boolean solucion = Algoritmo_A_Estrella(pos_n, pos_final, n, m, a, costo_diagonal, true, tablero_obstaculos);


            
            Console.ReadKey();





        }
    }
}
