using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Threading;
using System.Speech.Synthesis;
using System.Globalization;

namespace VoiceRecognitionMaze
{
    public partial class Maze : Form
    {
        SpeechRecognitionEngine escucha = new SpeechRecognitionEngine();
        SpeechSynthesizer habla = new SpeechSynthesizer();

        public int[,] Tablero; //Cuadricula donde 0 es vacio y 1 es obstaculo
        public double costo_diagonal;
        public Boolean diagonal;

        
        public List<Nodo> listaAbierta = new List<Nodo>();
        public List<int[]> listaCerrada = new List<int[]>();
        public List<int[]> Ruta = new List<int[]>();
        public List<Nodo> nodosAdyacentes = new List<Nodo>();

        int[] pos_inicio = new int[3];
        int[] pos_final = new int[3];

        // Variables para manejar el flujo del habla y qué opciones para el usuario
        int comenzar = 1;
        int terminar = 0;
        int dimensiones = 0;
        int banderaColumnas = 0;
        int banderaTamanoCasilla = 0;
        int banderaFilas = 0;
        int filas = 40;
        int columnas = 40;
        int tamanoCasillas = 15;
        int jugar = 0;
        int activarDiagonal = 0;
        int decisionFinal = 0;
        int permitirDiagonal = 0;
        int moverAgente = 0;
        int salida = 0;
        int otraVez = 1;
        int posInicio = 0;
        int posFinal = 0;
        int limpiar = 0;
        int cambiarN = 0;
        int cambiarM = 0;
        int cambiarA = 0;

        List<string> numerosEnLetras = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "zero","twenty"};
        List<string> numerosComunes = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0","20"};

        public Maze()
        {
            InitializeComponent();
            InicializarTablero();
            CrearRuta();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            Choices comandos = new Choices();

            // Crear gramática para escucha
            comandos.Add(new string[] { "start", "clean", "up", "down", "left", "right", "done", "yes", "no", "finish", "diagonal", "option", "rows", "columns", "stop",
                                        "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "zero","twenty", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0","20" });

            // Palabras que pueden ser escuchadas mal, las traducimos al idioma del programa
            comandos.Add(new SemanticResultValue("begin", "start"));
            comandos.Add(new SemanticResultValue("erase", "clean"));
            comandos.Add(new SemanticResultValue("delete", "clean"));
            comandos.Add(new SemanticResultValue("straight", "up"));
            comandos.Add(new SemanticResultValue("forward", "up"));
            comandos.Add(new SemanticResultValue("back", "down"));
            comandos.Add(new SemanticResultValue("behind", "down"));
            comandos.Add(new SemanticResultValue("turn left", "left"));
            comandos.Add(new SemanticResultValue("turn right", "right"));
            comandos.Add(new SemanticResultValue("ready", "done"));
            comandos.Add(new SemanticResultValue("check", "done"));
            comandos.Add(new SemanticResultValue("checked", "done"));
            comandos.Add(new SemanticResultValue("ok", "yes"));
            comandos.Add(new SemanticResultValue("yeah", "yes"));
            comandos.Add(new SemanticResultValue("yea", "yes"));
            comandos.Add(new SemanticResultValue("yas", "yes"));
            comandos.Add(new SemanticResultValue("yup", "yes"));
            comandos.Add(new SemanticResultValue("nope", "no"));
            comandos.Add(new SemanticResultValue("nop", "no"));
            comandos.Add(new SemanticResultValue("none", "no"));
            comandos.Add(new SemanticResultValue("don't", "no"));
            comandos.Add(new SemanticResultValue("finished", "finish"));

            // Cargar gramática para lo que se escuche en general
           /* GrammarBuilder gb = new GrammarBuilder();
            gb.Culture = new System.Globalization.CultureInfo("en-US"); // Se pone el idioma en inglés
            gb.Append(comandos);
            Grammar maze = new Grammar(gb);
            escucha.LoadGrammarAsync(maze); // Agregar la gramática al reconocedor

            escucha.SetInputToDefaultAudioDevice(); // Usar el micrófono

            habla.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Senior, 0, CultureInfo.GetCultureInfo("en-US"));

            escucha.RecognizeAsync(RecognizeMode.Multiple);

            habla.SpeakAsync("Hello, I am Charles and Welcome to Voice Maze, to start the game say start, or, to finish the game say finish.");

            escucha.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(escucha_reconocida);*/
        }

        /*private void escucha_reconocida(object sender, SpeechRecognizedEventArgs e)
        {
            TxbTamano.Text = e.Result.Text;
            float confidence = e.Result.Confidence;
            if (confidence < 0.50)
            {
                Console.WriteLine("Low confidence");
            }
            else if (comenzar == 1)
            {
                if (e.Result.Text == "start")
                {
                    habla.SpeakAsync("Do you want to set the table dimensions? Say yes or no");
                    comenzar = 0;
                    dimensiones = 1;
                }
                else if (e.Result.Text == "finish")
                {
                    habla.SpeakAsync("Thanks for playing, bye bye.");
                    this.Close();
                }
            }
            else if (dimensiones == 1)
            {
                if (e.Result.Text == "yes")
                {
                    habla.SpeakAsync("Please say the number of columns for the table");
                    dimensiones = 0;
                    banderaColumnas = 1;
                }
                else if (e.Result.Text == "No")
                {
                    this.Close();
                }
            }
            else if (banderaColumnas == 1)
            {
                if (compararStringNumerosLetras(e.Result.Text, numerosEnLetras) != -1)
                {
                    columnas = compararStringNumerosLetras(e.Result.Text, numerosEnLetras);
                }
                else if (compararStringNumeros(e.Result.Text, numerosComunes) != -1)
                {
                    columnas = compararStringNumeros(e.Result.Text, numerosComunes);
                }

                habla.SpeakAsync("Please say the number of rows for the table");
                banderaColumnas = 0;
                banderaFilas = 1;
            }
            else if (banderaFilas == 1)
            {
                if (compararStringNumerosLetras(e.Result.Text, numerosEnLetras) != -1)
                {
                    filas = compararStringNumerosLetras(e.Result.Text, numerosEnLetras);
                }
                else if (compararStringNumeros(e.Result.Text, numerosComunes) != -1)
                {
                    filas = compararStringNumeros(e.Result.Text, numerosComunes);
                }

                habla.SpeakAsync("Please say the number for the size of the table boxes");
                banderaFilas = 0;
                banderaTamanoCasilla = 1;
            }
            else if (banderaTamanoCasilla == 1)
            {
                if (compararStringNumerosLetras(e.Result.Text, numerosEnLetras) != -1)
                {
                    tamanoCasillas = compararStringNumerosLetras(e.Result.Text, numerosEnLetras);
                }
                else if (compararStringNumeros(e.Result.Text, numerosComunes) != -1)
                {
                    tamanoCasillas = compararStringNumeros(e.Result.Text, numerosComunes);
                }

                habla.SpeakAsync("Creating table");
                banderaTamanoCasilla = 0;
                
                jugar = 1;
            }
            else if (jugar == 1)
            {
                habla.SpeakAsync("Do you want the agent to be able to cross diagonals? Say yes or no");
                jugar = 0;
                activarDiagonal = 1;
            }
            else if (activarDiagonal == 1)
            {
                if (e.Result.Text == "yes")
                {
                    habla.SpeakAsync("Diagonal feature activated");
                    activarDiagonal = 0;
                    permitirDiagonal = 1;
                    habla.SpeakAsync("To play, please say up, down, left, right, left or stop for fixing the agent's position.");
                    moverAgente = 1;
                }
                else if (e.Result.Text == "no")
                {
                    habla.SpeakAsync("Diagonal feature deactivated");
                    habla.SpeakAsync("To play, please say up, down, left, right, left or stop for fixing the agent's position.");
                    permitirDiagonal = 0;
                    activarDiagonal = 0;
                    moverAgente = 1;
                }
            }
            else if (moverAgente == 1)
            {                
                if (e.Result.Text == "up")
                {
                    Console.WriteLine(e.Result.Text);
                    // Mover agente hacia arriba. TODO: ver qué hacer cuando se encuentra con un límite del tablero
                }
                else if (e.Result.Text == "down")
                {
                    Console.WriteLine(e.Result.Text);
                    // Mover agente hacia abajo. TODO: ver qué hacer cuando se encuentra con un límite del tablero
                }
                else if (e.Result.Text == "left")
                {
                    Console.WriteLine(e.Result.Text);
                    // Mover agente hacia la izquierda. TODO: ver qué hacer cuando se encuentra con un límite del tablero
                }
                else if (e.Result.Text == "right")
                {
                    Console.WriteLine(e.Result.Text);
                    // Mover agente hacia la derecha. TODO: ver qué hacer cuando se encuentra con un límite del tablero
                }
                else if (e.Result.Text == "stop")
                {
                    Console.WriteLine(e.Result.Text);
                    habla.SpeakAsync("Do you want to see the way out of the maze? Say yes or no");
                    salida = 1;
                }
                else if (salida == 1)
                {
                    if(e.Result.Text == "yes")
                    {
                        habla.SpeakAsync("The way out is outlined in the color red, what do you want to do next, say play to play again or finish to finish the game");
                        decisionFinal = 1;
                    }
                    else if (e.Result.Text == "no")
                    {
                        habla.SpeakAsync("Thanks for playing, what do you want to do next, say play to play again or finish to finish the game");
                        decisionFinal = 1;
                    }
                    else if (decisionFinal == 1)
                    {
                        // Ver como hacer para volver a poner al usuario a jugar, tal vez un or en la bandera de dimensiones
                    }
                }
            }
        }*/


        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            matrizTablero.Rows.Clear();
            matrizTablero.Columns.Clear();
            matrizTablero.Refresh();
        }

       /* private void formatoCelda(int [] pos_n, int[] pos_final)
         {
             if(Tablero[pos_n[0]][pos_n[1]] == 2)
             {
                 DataGridViewCell celda = matrizTablero[pos_n[0], pos_n[1]];
                 celda.Style.BackColor = Color.Green;
                 celda.ReadOnly = false;
                 celda.Style.SelectionBackColor = Color.Green;
             }
             if (Tablero[pos_final[0]][pos_final[1]] == 3)
             {
                 DataGridViewCell celda = matrizTablero[pos_final[0], pos_final[1]];
                 celda.Style.BackColor = Color.Red;
                 celda.ReadOnly = false;
                 celda.Style.SelectionBackColor = Color.Red;
             }
         }*/

 //---------------------------------------------Inicializar Tablero------------------------------------------------
        private void InicializarTablero()
        {
            matrizTablero.RowCount = filas; //m
            matrizTablero.ColumnCount = columnas; //n

            Tablero = new int[columnas, filas];

            //Inicializar tablero con 0's y marcar inicio y fin
            llenarArreglo(Tablero);

            //Marcar en el Tablero en codigo el inicio y fin
            Tablero[2, 2] = 2;
            Tablero[columnas - 2, filas - 2] = 3;

            //Coordenadas de la posicion de inicio y fin
            pos_inicio[0] = 2;
            pos_inicio[1] = 2;

            pos_final[0] = columnas-2; //columna
            pos_final[1] = filas-2;//fila


            costo_diagonal = Math.Sqrt(2) * tamanoCasillas;
            diagonal = true;

            //Sacar posiciones disponibles donde puedo poner obstaculos
            List<int[]> disponibles = new List<int[]>();
            disponibles = ObtenerPosicionesDisponibles(Tablero, filas, columnas);
            PonerObstaculos(Tablero, disponibles, (columnas * filas) / 3);

            //Pintar Tablero
            matrizTablero.BackgroundColor = Color.White;
            matrizTablero.DefaultCellStyle.BackColor = Color.White;

            //Pintar nodo inicial
            DataGridViewCell InicioAgente = matrizTablero[pos_inicio[0], pos_inicio[1]];
            InicioAgente.Style.BackColor = Color.Green;
            InicioAgente.ReadOnly = false;
            InicioAgente.Style.SelectionBackColor = Color.Green;

            for (int i = 0; i < columnas; i++)
            {
                for (int j = 0; j < filas; j++)
                {

                    if (Tablero[i, j] == 1)
                    {
                        //Pintar obstaculos
                        DataGridViewCell obstaculo = matrizTablero[i,j];
                        obstaculo.Style.BackColor = Color.Black;
                        obstaculo.ReadOnly = false;
                        obstaculo.Style.SelectionBackColor = Color.Black;
                    }

                    if (Tablero[i, j] == 3)
                    {
                        //Pintar nodo final
                        DataGridViewCell PuntoLlegada = matrizTablero[pos_final[0], pos_final[1]];
                        PuntoLlegada.Style.BackColor = Color.Red;
                        PuntoLlegada.ReadOnly = false;
                        PuntoLlegada.Style.SelectionBackColor = Color.Red;
                        jugar = 1;
                    }

                }

            }        
            //Establecer tamaño de cada cuadro
            foreach (DataGridViewColumn c in matrizTablero.Columns)
            {
                c.Width = tamanoCasillas;
            }

            foreach (DataGridViewRow r in matrizTablero.Rows)
            {
                r.Height = tamanoCasillas;  
            }
            jugar = 1;
        }

    public void CrearRuta()
        {
            Ruta = Algoritmo_A_Estrella(pos_inicio, pos_final, costo_diagonal, diagonal, Tablero);

            if (Ruta == null)
            {
                System.Console.WriteLine("No hay solucion");
            }
            else
            {
                PonerRuta(Ruta);
                for (int i = 0; i < Tablero.GetLength(0); i++)
                {
                    for (int j = 0; j < Tablero.GetLength(1); j++)
                    {
                        if (Tablero[i, j] == 4)
                        {
                            DataGridViewCell camino = matrizTablero[i, j];
                            camino.Style.BackColor = Color.Blue;
                            camino.ReadOnly = false;
                            camino.Style.SelectionBackColor = Color.Blue;

                        }
                        else
                        {
                            continue;
                        }
                    }

                }
            }
        }
//------------------------------------------Limpiar la ruta-----------------------------
        public void LimpiarRuta()
        {
            for (int i = 0; i < Tablero.GetLength(0); i++)
            {
                for (int j = 0; j < Tablero.GetLength(1); j++)
                {
                    if (Tablero[i, j] == 4)
                    {
                        Tablero[i, j] = 0;
                        DataGridViewCell camino = matrizTablero[i, j];
                        camino.Style.BackColor = Color.White;
                        camino.ReadOnly = false;
                        camino.Style.SelectionBackColor = Color.White;
                    }
                    else
                    {
                        continue;
                    }
                }

            }
        }
        private int compararStringNumerosLetras(String entradaAComparar, List<string> ListaAComparar)
        {
            bool contenido = ListaAComparar.Contains(entradaAComparar, StringComparer.OrdinalIgnoreCase);
            int numeroReal = -1;

            if (contenido)
            {
                switch (entradaAComparar)
                {
                    case "one":
                        numeroReal = 1;
                        break;
                    case "two":
                        numeroReal = 2;
                        break;
                    case "three":
                        numeroReal = 3;
                        break;
                    case "four":
                        numeroReal = 4;
                        break;
                    case "five":
                        numeroReal = 5;
                        break;
                    case "six":
                        numeroReal = 6;
                        break;
                    case "seven":
                        numeroReal = 7;
                        break;
                    case "eight":
                        numeroReal = 8;
                        break;
                    case "nine":
                        numeroReal = 9;
                        break;
                    case "zero":
                        numeroReal = 0;
                        break;
                    
                    default:
                        break;
                }
                return numeroReal;
            }
            return numeroReal;
        }

        private int compararStringNumeros(String entradaAComparar, List<string> ListaAComparar)
        {
            bool contains = ListaAComparar.Contains(entradaAComparar, StringComparer.OrdinalIgnoreCase);
            return contains ? Int32.Parse(entradaAComparar) : -1;
        }

        private void matrizTablero_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //----------------------------------------Métodos para imprimir------------------------------------------------------------

        public void imprimir_ListaCerrada(List<int[]> cerrada)
        {
            foreach (int[] value in cerrada)
            {
                Console.Write("[" + value[0] + "," + value[1] + "]" + " ");
                Console.WriteLine();
            }
        }


        public void imprimir_ListaAbierta(List<Nodo> abierta)
        {
            foreach (Nodo value in abierta)
            {
                Console.Write("[" + value.posicion[0] + "," + value.posicion[1] + "]" + " ");
                Console.WriteLine();
            }
        }

        public void imprimir_Adyacentes(List<Nodo> adyacentes)
        {
            foreach (Nodo value in adyacentes)
            {
                Console.Write("[" + value.posicion[0] + "," + value.posicion[1] + "]" + " ");
                Console.WriteLine();
            }
        }

        public void imprimir_solucion(int[,] tablero)
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

        public void Imprimir_Tablero_Obstaculos(int[,] tablero)
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
        public int[,] PonerRuta(List<int[]> ruta)
        {
            foreach (int[] value in ruta)
            {

                if (Tablero[value[0], value[1]] == 2)
                {
                    continue;
                }
                if (Tablero[value[0], value[1]] == 3)
                {
                    continue;
                }
                Tablero[value[0], value[1]] = 4;

            }
            return Tablero;


        }

        //LLena el arreglo con 0's
        public int[,] llenarArreglo(int[,] tablero)
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
        public List<int[]> ObtenerPosicionesDisponibles(int[,] tablero, int filas, int columnas)
        {

            List<int[]> posDisponibles = new List<int[]>();

            posDisponibles.Clear();

            for (int i = 0; i < columnas ; i++)
            {
                for (int j = 0; j < filas; j++)
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
        public Boolean valorOcupado(List<int[]> posOcupadas, List<int[]> pos_disponibles, int pos)
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
        public int[,] PonerObstaculos(int[,] tablero, List<int[]> pos_disponibles, int cant_obstaculos)
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
        public List<Nodo> encontrarNodosAdyacentes(Nodo nodoActual, int[,] Tablero, Boolean estado_diagonal)
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

            if (x + 1 < columnas && Tablero[x + 1, y] != 1)
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

            if (y + 1 < filas && Tablero[x, y + 1] != 1)
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

                if (x + 1 < columnas && y - 1 >= 0 && Tablero[x + 1, y - 1] != 1)
                {
                    int[] ArribaDer = new int[2];
                    ArribaDer[0] = x + 1;
                    ArribaDer[1] = y - 1;
                    Nodo nodo = new Nodo(ArribaDer, 1);
                    adyacentes.Add(nodo);
                }

                if (x - 1 >= 0 && y + 1 < filas && Tablero[x - 1, y + 1] != 1)
                {
                    int[] AbajoIzq = new int[2];
                    AbajoIzq[0] = x - 1;
                    AbajoIzq[1] = y + 1;
                    Nodo nodo = new Nodo(AbajoIzq, 1);
                    adyacentes.Add(nodo);
                }

                if (x + 1 < columnas && y + 1 < filas && Tablero[x + 1, y + 1] != 1)
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
        public void agregarNodoAListaAbierta(Nodo nodo)
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
        public void calcular_fn(Nodo nodoActual, Nodo nodoFinal, List<Nodo> adyacentes, List<Nodo> listaAbierta, List<int[]> listaCerrada, double costoDiagonal)
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
                        gn = nodoActual.gn + tamanoCasillas;
                    }
                    else
                    {
                        gn = nodoActual.gn + costoDiagonal; //Movimiento en diagonal
                    }


                    fn = (Math.Abs(nodo_abierto.posicion[0] - nodoFinal.posicion[0]) + Math.Abs(nodo_abierto.posicion[1] - nodoFinal.posicion[1])) * tamanoCasillas + gn;
                    Nodo_Adyacente = new Nodo(nodoActual, nodo_abierto.posicion, gn, fn, nodo_abierto.movimiento);//Se crea el nodo adyacente con el nodo padre, gn y fn calculados
                    agregarNodoAListaAbierta(Nodo_Adyacente);//Agrega todos los hijos del nodo actual.


                }

            }

        }

        public List<int[]> Algoritmo_A_Estrella(int[] pos_n, int[] pos_final, double costo, Boolean diagonal, int[,] Tablero)
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
                calcular_fn(nodoActual, nodo_final, nodosAdyacentes, listaAbierta, listaCerrada, costo); //Calcula el fn de cada uno de los nodos adyacentes al nodo actual
                listaCerrada.Add(nodoActual.posicion);
            }

            return null;
        }

        //Refrescar la pantalla

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarRuta();
        }
   
       
    }
}
