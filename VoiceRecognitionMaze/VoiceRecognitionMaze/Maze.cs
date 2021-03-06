﻿using System;
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
        public Boolean buscar;
        public Boolean nodo;


        public List<Nodo> listaAbierta = new List<Nodo>();
        public List<int[]> listaCerrada = new List<int[]>();
        public List<int[]> Ruta = new List<int[]>();
        public List<Nodo> nodosAdyacentes = new List<Nodo>();

        int[] pos_inicio = new int[3];
        int[] pos_final = new int[3];

        // Variables para manejar el flujo del habla y qué opciones para el usuario
        int comenzar = 1;
        int dimensiones = 0;
        int banderaColumnas = 0;
        int banderaTamanoCasilla = 0;
        int banderaFilas = 0;
        int filas = 0;
        int columnas = 0;
        int tamanoCasillas = 0;
        int activarDiagonal = 0;
        int decisionFinal = 0;
        int moverAgente = 0;
        int salida = 0;
        int moverAgenteInicio = 0;
        int moverAgenteFinal = 0;
        int banderaNodoFinal = 0;
        int continuarJugando = 0;
        int decisionFinalSinRuta = 0;

        List<string> numerosEnLetras = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "zero","ten","eleven",
            "twelve","thirteen","fourteen","fifteen","sixteen","seventeen","eighteen","nineteen","twenty","twenty one","twenty two","twenty three",
        "twenty four", "twenty five","twenty six","twenty seven", "twenty eight", "twenty nine","thirty","thirty one","thirty two","thirty three",
        "thirty four", "thirty five", "thirty six", "thirty seven","thirty eight", "thirty nine","forty","forty one", "forty two","forty three",
        "forty five", "forty six", "forty seven","forty eight", "forty nine", "fifty","fifty one", "fifty two", "fifty three", "fifty four", "fifty five",
        "fifty six", "fifty seven", "fifty eight", "fifty nine","sixty","sixty one","sixty two","sixty three","sixty four","sixty five","sixty six",
        "sixty seven","sixty eight","sixty nine","seventy","seventy one","seventy two","seventy three","seventy four","seventy five","seventy six","seventy seven",
        "seventy eight", "seventy nine","eighty","eighty one", "eighty two","eighty three","eighty four","eighty five","eighty six","eighty seven","eighty eight",
        "eighty nine","ninety","ninety one","ninety two","ninety three","ninety four","ninety five","ninety six", "ninety seven","ninety eight","ninety nine",
         "hundred", "one hundred"};
        List<string> numerosComunes = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0","10","11","12","13","14","15","16","17","18","19","20",
        "21","22","23","24","25","26","27","28","29","30","31","32","33","34","35","36","37","38","39","40","41","42","43","44","45","46","47","48","49","50","51",
        "52","53","54","55","56","57","58","59","60","61","62","63","64","65","66","67","68","69","70","71","72","73","74","75","76","77","78","79","80","81","82",
        "83","84","85","86","87","88","89","90","91","92","93","94","95","96","97","98","99","100"};

        public Maze()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Choices comandos = new Choices();

            // Crear gramática para escucha
            comandos.Add(new string[] { "start", "clean", "up", "down", "left", "right", "done", "yes", "no", "finish", "diagonal", "option", "rows", "columns","play", "stop","show route","northeast","northwest",
                                         "southeast", "southwest","continue","one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "zero","ten","eleven","twelve","thirteen","fourteen","fifteen","sixteen",
                                         "seventeen","eighteen","nineteen","twenty","twenty one","twenty two","twenty three", "twenty four", "twenty five","twenty six","twenty seven",
                                         "twenty eight", "twenty nine","thirty","thirty one","thirty two","thirty three", "thirty four", "thirty five", "thirty six", "thirty seven","thirty eight",
                                         "thirty nine","forty","forty one", "forty two","forty three", "forty five", "forty six", "forty seven","forty eight", "forty nine", "fifty","fifty one",
                                         "fifty two", "fifty three", "fifty four", "fifty five", "fifty six", "fifty seven", "fifty eight", "fifty nine","sixty","sixty one","sixty two","sixty three",
                                         "sixty four","sixty five","sixty six", "sixty seven","sixty eight","sixty nine","seventy","seventy one","seventy two","seventy three","seventy four","seventy five",
                                         "seventy six","seventy seven", "seventy eight", "seventy nine","eighty","eighty one", "eighty two","eighty three","eighty four","eighty five","eighty six","eighty seven",
                                         "eighty eight", "eighty nine","ninety","ninety one","ninety two","ninety three","ninety four","ninety five","ninety six", "ninety seven","ninety eight","ninety nine",
                                         "hundred", "one hundred", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0","10","11","12","13","14","15","16","17","18","19","20", "21","22","23","24","25","26","27",
                                         "28","29","30","31","32","33","34","35","36","37","38","39","40","41","42","43","44","45","46","47","48","49","50","51","52","53","54","55","56","57","58","59","60",
                                         "61","62","63","64","65","66","67","68","69","70","71","72","73","74","75","76","77","78","79","80","81","82","83","84","85","86","87","88","89","90","91","92","93",
                                         "94","95","96","97","98","99","100"});

            // Cargar gramática para lo que se escuche en general
            GrammarBuilder gb = new GrammarBuilder();
            gb.Culture = new System.Globalization.CultureInfo("en-US"); // Se pone el idioma en inglés
            gb.Append(comandos);
            Grammar maze = new Grammar(gb);
            escucha.LoadGrammarAsync(maze); // Agregar la gramática al reconocedor

            escucha.SetInputToDefaultAudioDevice(); // Usar el micrófono

            habla.SelectVoiceByHints(VoiceGender.Male, VoiceAge.Senior, 0, CultureInfo.GetCultureInfo("en-US"));

            escucha.RecognizeAsync(RecognizeMode.Multiple);

            habla.SpeakAsync("Hello, I am Charles and Welcome to Voice Maze, to start the game say start, or, to finish the game say finish.");

            escucha.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(escucha_reconocida);
        }

        private void escucha_reconocida(object sender, SpeechRecognizedEventArgs e)
        {
            float confidence = e.Result.Confidence;

            if (confidence < 0.50)
            {
                Console.WriteLine("Low confidence");
            }

            // Comienza el juego y verifica si el usuario quiere settear dimensiones o no, si dice no, se termina el juego
            else if (comenzar == 1)
            {
                if (e.Result.Text == "start" || e.Result.Text == "play")
                {
                    habla.SpeakAsync("Do you want to set the maze dimensions, say yes or no");
                    comenzar = 0;
                    dimensiones = 1;
                }
                else if (e.Result.Text == "finish")
                {
                    habla.SpeakAsync("Thanks for playing, bye bye.");
                    this.Close();
                }
            }
            
            // Pregunta la cantidad de columnas para el laberinto
            else if (dimensiones == 1)
            {
                if (e.Result.Text == "yes")
                {
                    dimensiones = 0;
                    banderaColumnas = 1;
                    habla.SpeakAsync("Please say the number of columns for the maze");
                }
                else if (e.Result.Text == "no")
                {
                    habla.SpeakAsync("Thanks for playing, bye");
                    this.Close();
                }
            }

            // Agarra el número de columnas que dijo el usuario y lo convierte a int, luego lo asigna
            // a la variable global columnas
            else if (banderaColumnas == 1)
            {
                if (compararStringNumerosLetras(e.Result.Text, numerosEnLetras) != -1)
                {
                    if(compararStringNumerosLetras(e.Result.Text, numerosEnLetras) <= 1)
                    {
                        habla.SpeakAsync("Columns number must be greater than two, say a number again");
                    }
                    else
                    {
                        columnas = compararStringNumerosLetras(e.Result.Text, numerosEnLetras);
                        banderaColumnas = 0;
                        banderaFilas = 1;
                        habla.SpeakAsync("Please say the number of rows for the table");
                    }
                    
                }

                else if (compararStringNumeros(e.Result.Text, numerosComunes) != -1)
                {
                    if (compararStringNumeros(e.Result.Text, numerosComunes) <= 1)
                    {
                        habla.SpeakAsync("Columns number must be greater than two, say a number again");
                    }
                    else
                    {
                        columnas = compararStringNumeros(e.Result.Text, numerosComunes);
                        banderaColumnas = 0;
                        banderaFilas = 1;
                        habla.SpeakAsync("Please say the number of rows for the table");
                    }
                }
            }

            // Agarra el número de filas que dijo el usuario y lo convierte a int, luego lo asigna
            // a la variable global filas
            else if (banderaFilas == 1)
            {
                if (compararStringNumerosLetras(e.Result.Text, numerosEnLetras) != -1)
                {
                    if (compararStringNumerosLetras(e.Result.Text, numerosEnLetras) <= 1)
                    {
                        habla.SpeakAsync("Rows number must be greater than two, say a number again");
                    }
                    else
                    {
                        filas = compararStringNumerosLetras(e.Result.Text, numerosEnLetras);
                        banderaFilas = 0;
                        banderaTamanoCasilla = 1;
                        habla.SpeakAsync("Please say the number for the size of the squares");
                    }

                }

                else if (compararStringNumeros(e.Result.Text, numerosComunes) != -1)
                {
                    if (compararStringNumeros(e.Result.Text, numerosComunes) <= 1)
                    {
                        habla.SpeakAsync("Rows number must be greater than two, say a number again");
                    }
                    else
                    {
                        filas = compararStringNumeros(e.Result.Text, numerosComunes);
                        banderaFilas = 0;
                        banderaTamanoCasilla = 1;
                        habla.SpeakAsync("Please say the number for the size of the squares");
                    }

                }                
            }

            // Agarra el número de tamano de los cuadros que dijo el usuario y lo convierte a int, luego lo asigna
            // a la variable global tamanoCasillas
            else if (banderaTamanoCasilla == 1)
            {
                if (compararStringNumerosLetras(e.Result.Text, numerosEnLetras) != -1)
                {
                    if (compararStringNumerosLetras(e.Result.Text, numerosEnLetras) <= 9)
                    {
                        habla.SpeakAsync("Box size must be greater than or equals to ten, say a number again");
                    }
                    else if (compararStringNumerosLetras(e.Result.Text, numerosEnLetras) >= 51)
                    {
                        habla.SpeakAsync("Box size must be less than or equals to fifty, say a number again");
                    }
                    else
                    {
                        tamanoCasillas = compararStringNumerosLetras(e.Result.Text, numerosEnLetras);
                        banderaTamanoCasilla = 0;
                        habla.SpeakAsync("Creating maze");
                        InicializarTablero();

                        habla.SpeakAsync("Do you want the agent to be able to cross diagonals, say yes or no");
                        activarDiagonal = 1;
                    }

                }

                if (compararStringNumeros(e.Result.Text, numerosComunes) != -1)
                {
                    if (compararStringNumeros(e.Result.Text, numerosComunes) <= 9)
                    {
                        habla.SpeakAsync("Box size must be greater than or equals to ten, say a number again");
                    }
                    else if (compararStringNumeros(e.Result.Text, numerosComunes) >= 51)
                    {
                        habla.SpeakAsync("Box size must be less than or equals to fifty, say a number again");
                    }
                    else
                    {
                        tamanoCasillas = compararStringNumeros(e.Result.Text, numerosComunes);
                        banderaTamanoCasilla = 0;
                        habla.SpeakAsync("Creating maze");
                        InicializarTablero();

                        habla.SpeakAsync("Do you want the agent to be able to cross diagonals, say yes or no");
                        activarDiagonal = 1;
                    }
                }
            }
          
            //Verifica si el usuario quiere usar la acción de usar diagonales y las activa o desactiva según el caso
            // luego pregunta si quiere mover la casilla de inicio (o el agente)
            else if (activarDiagonal == 1)
            {
                if (e.Result.Text == "yes")
                {
                    habla.SpeakAsync("Diagonal feature activated");
                    diagonal = true;
                    moverAgente = 1;
                    activarDiagonal = 0;
                    habla.SpeakAsync("Do you want to move the start of the agent, say yes or no.");
                }

                else if (e.Result.Text == "no")
                {
                    habla.SpeakAsync("Diagonal feature deactivated");
                    diagonal = false;
                    moverAgente = 1;
                    activarDiagonal = 0;
                    habla.SpeakAsync("Do you want to move the start of the agent, say yes or no.");
                }
            }

            // Da las instrucciones para mover el agente. Luego pregunta si quiere mover la casilla de salida
            else if (moverAgente == 1)
            {
                if (e.Result.Text == "yes")
                {
                    moverAgenteInicio = 1;
                    moverAgente = 0;
                    nodo = true;

                    habla.SpeakAsync("To play, please say up, down, left, right, northwest, southeast, southwest, northeast or stop for fixing the agent's position.");
                }

                else if (e.Result.Text == "no")
                {
                    moverAgente = 0;
                    moverAgenteInicio = 0;
                    
                    banderaNodoFinal = 1;
                    habla.SpeakAsync("Do you want to move the end of the route, say yes or no");
                }
            }

            // Mueve al agente de inicio dependiendo del comando del usuario
            else if (moverAgenteInicio == 1)
            {
                if (e.Result.Text == "up")
                {
                    MoverArriba();
                }
                else if (e.Result.Text == "down")
                {
                    MoverAbajo();
                }
                else if (e.Result.Text == "left")
                {
                    MoverIzq();
                }
                else if (e.Result.Text == "right")
                {
                    MoverDer();
                }
                else if (e.Result.Text == "northeast")
                {
                    MoverDiagonalNorEste();
                }
                else if (e.Result.Text == "northwest")
                {
                    MoverDiagonalNorOeste();
                }
                else if (e.Result.Text == "southeast")
                {
                    MoverDiagonalSurEste();
                }
                else if (e.Result.Text == "southwest")
                {
                    MoverDiagonalSurOeste();
                }
                else if (e.Result.Text == "stop")
                {
                    Console.WriteLine(e.Result.Text);
                    habla.SpeakAsync("Do you want to move the end of the route, say yes or no");
                    moverAgenteInicio = 0;
                    banderaNodoFinal = 1;
                }

            }

            // Da las instrucciones para mover el agente. Luego pregunta si quiere ya saber la ruta hacia la salida
            else if (banderaNodoFinal == 1)
            {
                if (e.Result.Text == "yes")
                {
                    habla.SpeakAsync("To play, please say up, down, left, right, northwest, southeast, northeast, southwest or stop for fixing the end of the route");
                    banderaNodoFinal = 0;
                    moverAgenteFinal = 1;
                    nodo = false;
                }
                else if (e.Result.Text == "no")
                {
                    habla.SpeakAsync("Do you want to see the way out of the maze, say yes or no");
                    salida = 1;
                    banderaNodoFinal = 0;
                    moverAgenteFinal = 0;
                }
            }

            // Mueve la casilla del final dependiendo del comando del usuario. 
            // Luego pregunta si quiere ya saber la ruta hacia la salida
            else if (moverAgenteFinal == 1)
            {
                if (e.Result.Text == "up")
                {
                    MoverArriba();
                }
                else if (e.Result.Text == "down")
                {
                    MoverAbajo();
                }
                else if (e.Result.Text == "left")
                {
                    MoverIzq();
                }
                else if (e.Result.Text == "right")
                {
                    MoverDer();
                }
                else if (e.Result.Text == "northeast")
                {
                    MoverDiagonalNorEste();
                }
                else if (e.Result.Text == "northwest")
                {
                    MoverDiagonalNorOeste();
                }
                else if (e.Result.Text == "southeast")
                {
                    MoverDiagonalSurEste();
                }
                else if (e.Result.Text == "southwest")
                {
                    MoverDiagonalSurOeste();
                }
                else if (e.Result.Text == "stop")
                {
                    habla.SpeakAsync("Do you want to see the way out of the maze, say yes or no");
                    salida = 1;
                    moverAgenteFinal = 0;
                }
            }

            // Dibuja la ruta de salida en el laberinto, y luego pregunta al usuario qué quiere hacer ahora
            else if (salida == 1)
            {
                if (e.Result.Text == "yes")
                {
                    Boolean A_Estrella = CrearRuta();
                    if(A_Estrella == true)
                    {
                        habla.SpeakAsync("Showing the shortest path");
                        habla.SpeakAsync("Say play to play again, continue to stay in the current maze or finish to finish the game");
                        salida = 0;
                        decisionFinal = 1;
                    }
                    else if(A_Estrella == false)
                    {
                        habla.SpeakAsync("Say play to play again, continue to stay in the current maze or finish to finish the game");
                        salida = 0;
                        decisionFinal = 1;
                    }
                }  
                
                else if (e.Result.Text == "no")
                {
                    habla.SpeakAsync("Say play to play again, continue to stay in the current maze or finish to finish the game");
                    salida = 0;
                    decisionFinalSinRuta = 1;
                }
            }

            // Dependiendo de qué acción quiera hacer ahora el usuario, la ejecuta. Con la ruta dibujada en el laberinto
            else if (decisionFinal == 1)
            {
                if (e.Result.Text == "play")
                {
                    decisionFinal = 0;
                    volverAComenzar();
                    comenzar = 1;
                }
                else if(e.Result.Text == "continue")
                {
                    habla.SpeakAsync("Cleaning the current outlined route");
                    LimpiarRuta();
                    decisionFinal = 0;
                    habla.SpeakAsync("Do you want the agent to be able to cross diagonals, say yes or no");
                    continuarJugando = 1;
                }
                else if (e.Result.Text == "finish")
                {
                    habla.SpeakAsync("Thanks for playing, bye");
                    this.Close();
                }
            }

            // Dependiendo de qué acción quiera hacer ahora el usuario, la ejecuta. Sin la ruta dibujada en el laberinto
            else if (decisionFinalSinRuta == 1)
            {
                if (e.Result.Text == "play")
                {
                    decisionFinal = 0;
                    volverAComenzar();
                    comenzar = 1;
                }
                else if (e.Result.Text == "continue")
                {
                    LimpiarRuta();
                    decisionFinal = 0;
                    habla.SpeakAsync("Do you want the agent to be able to cross diagonals, say yes or no");
                    continuarJugando = 1;
                }
                else if (e.Result.Text == "finish")
                {
                    habla.SpeakAsync("Thanks for playing, bye");
                    this.Close();
                }
            }

            // Si el usuario quiere continuar jugando, mantiene el laberinto actual y vuelve a pedir las dimensiones
            else if (continuarJugando == 1)
            {
                continuarJugando = 0;
                activarDiagonal = 1;
            }
        }

        //---------------------------------------------Inicializar Tablero------------------------------------------------
        private void InicializarTablero()
        {
            matrizTablero.RowCount = filas; //m
            matrizTablero.ColumnCount = columnas; //n           

            Tablero = new int[columnas, filas];

            //Inicializar tablero con 0's y marcar inicio y fin
            llenarArreglo(Tablero);

            //Marcar en el Tablero en codigo el inicio y fin
            Console.WriteLine(filas);
            Console.WriteLine(columnas);
            Console.WriteLine(tamanoCasillas);

            buscar = true;

             Random random = new Random();
             int filaInicio = random.Next(0, filas);
             int columnaInicio = random.Next(0, columnas);

             Tablero[columnaInicio, filaInicio] = 2;
             pos_inicio[0] = columnaInicio;
             pos_inicio[1] = filaInicio;

             while (buscar)
             {
                 int filaFinal = random.Next(0, filas);
                 int columnaFinal = random.Next(0, columnas);

                 if (Tablero[columnaFinal, filaFinal] == 2)
                 {
                     buscar = true;
                 }
                 else
                 {
                     Tablero[columnaFinal, filaFinal] = 3;
                     pos_final[0] = columnaFinal; //columna
                     pos_final[1] = filaFinal;//fila
                     buscar = false;
                 }
             }
            costo_diagonal = Math.Sqrt(2) * tamanoCasillas;

            // Verifica si el porcentaje está en el rango 10-50
           
            int squareCount = columnas * filas,
            obstacleCount = squareCount * 10 / 100;

            //Sacar posiciones disponibles donde puedo poner obstaculos
            List<int[]> disponibles = new List<int[]>();
            disponibles = ObtenerPosicionesDisponibles(Tablero, filas, columnas);
            PonerObstaculos(Tablero, disponibles, obstacleCount);

            //Pintar Tablero
            matrizTablero.BackgroundColor = Color.White;
            matrizTablero.DefaultCellStyle.BackColor = Color.White;

            for (int i = 0; i < columnas; i++)
            {
                for (int j = 0; j < filas; j++)
                {
                    if (Tablero[i, j] == 2)
                    {
                        //Pintar nodo inicial
                        DataGridViewCell InicioAgente = matrizTablero[pos_inicio[0], pos_inicio[1]];
                        InicioAgente.Style.BackColor = Color.LawnGreen;
                        InicioAgente.ReadOnly = false;
                        InicioAgente.Style.SelectionBackColor = Color.LawnGreen;
                    }
                    if (Tablero[i, j] == 1)
                    {
                        //Pintar obstaculos
                        DataGridViewCell obstaculo = matrizTablero[i, j];
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

        }

        public Boolean CrearRuta()
        {
            Ruta = Algoritmo_A_Estrella(pos_inicio, pos_final, costo_diagonal, diagonal, Tablero);

            if (Ruta == null)
            {
                return false;
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
                return true;
            }
        }

        public void volverAComenzar()
        {
            matrizTablero.Rows.Clear();
            matrizTablero.Columns.Clear();
            matrizTablero.Refresh();
        }

        //------------------------------------------ Movimientos del Agente -----------------------------
        
        public void MoverArriba()
        {
            int filaActualAgente;
            int filaNuevaAgente;

            /*Si estoy en la fila 0 no me puedo mover hacia arriba
            pos_inicio[0] = columnas (coordenada x)
            pos_inicio[1] = filas (coordenada y)*/

            if (nodo == true)
            {
                if (pos_inicio[1] != 0)
                {
                    filaActualAgente = pos_inicio[1];
                    filaNuevaAgente = pos_inicio[1] - 1;

                    if ((Tablero[pos_inicio[0], filaNuevaAgente]) != 1 && (Tablero[pos_inicio[0], filaNuevaAgente] != 3))
                    {
                        DataGridViewCell agenteActual = matrizTablero[pos_inicio[0], filaActualAgente];
                        agenteActual.Style.BackColor = Color.White;
                        agenteActual.ReadOnly = false;
                        agenteActual.Style.SelectionBackColor = Color.White;

                        DataGridViewCell agenteNuevo = matrizTablero[pos_inicio[0], filaNuevaAgente];
                        agenteNuevo.Style.BackColor = Color.LawnGreen;
                        agenteNuevo.ReadOnly = false;
                        agenteNuevo.Style.SelectionBackColor = Color.LawnGreen;

                        Tablero[pos_inicio[0], filaActualAgente] = 0;
                        Tablero[pos_inicio[0], filaNuevaAgente] = 2;

                        pos_inicio[1] = filaNuevaAgente;

                    }
                    else
                    {
                        Console.WriteLine("Movimiento arriba invalido");
                        habla.SpeakAsync("Invalid move, cannot move past an obstacle, the beginning or end, say a move again");
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento arriba invalido");
                    habla.SpeakAsync("Invalid move, cannot move past the limit, say a move again");
                }
            }
            else
            {
                //Si estoy en la fila 0 no me puedo mover hacia arriba
                //pos_inicio[1] = filas (coordenada y)
                //pos_inicio[0] = columnas (coordenada x)
                if (pos_final[1] != 0)
                {
                    filaActualAgente = pos_final[1];
                    filaNuevaAgente = pos_final[1] - 1;

                    if ((Tablero[pos_final[0], filaNuevaAgente]) != 1 && (Tablero[pos_final[0], filaNuevaAgente] != 2))
                    {
                        DataGridViewCell agenteActual = matrizTablero[pos_final[0], filaActualAgente];
                        agenteActual.Style.BackColor = Color.White;
                        agenteActual.ReadOnly = false;
                        agenteActual.Style.SelectionBackColor = Color.White;

                        DataGridViewCell agenteNuevo = matrizTablero[pos_final[0], filaNuevaAgente];
                        agenteNuevo.Style.BackColor = Color.Red;
                        agenteNuevo.ReadOnly = false;
                        agenteNuevo.Style.SelectionBackColor = Color.Red;

                        Tablero[pos_final[0], filaActualAgente] = 0;
                        Tablero[pos_final[0], filaNuevaAgente] = 3;

                        pos_final[1] = filaNuevaAgente;

                    }
                    else
                    {
                        Console.WriteLine("Movimiento arriba invalido");
                        habla.SpeakAsync("Invalid move, cannot move past an obstacle, the beginning or end, say a move again");
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento arriba invalido");
                    habla.SpeakAsync("Invalid move, cannot move past the limit, say a move again");
                }

            }
        }

        public void MoverAbajo()
        {
            int filaActualAgente;
            int filaNuevaAgente;
            //pos_inicio[1] = filas (coordenada y)
            //pos_inicio[0] = columnas (coordenada x)

            if (nodo == true)
            {
                if (pos_inicio[1] != filas - 1)  //Si la cantidad de filas ya es mayor se salió del tablero
                {
                    filaActualAgente = pos_inicio[1];
                    filaNuevaAgente = pos_inicio[1] + 1;

                    if ((Tablero[pos_inicio[0], filaNuevaAgente]) != 1 && (Tablero[pos_inicio[0], filaNuevaAgente]) != 3)
                    {
                        DataGridViewCell agenteActual = matrizTablero[pos_inicio[0], filaActualAgente];
                        agenteActual.Style.BackColor = Color.White;
                        agenteActual.ReadOnly = false;
                        agenteActual.Style.SelectionBackColor = Color.White;

                        DataGridViewCell agenteNuevo = matrizTablero[pos_inicio[0], filaNuevaAgente];
                        agenteNuevo.Style.BackColor = Color.LawnGreen;
                        agenteNuevo.ReadOnly = false;
                        agenteNuevo.Style.SelectionBackColor = Color.LawnGreen;

                        Tablero[pos_inicio[0], filaActualAgente] = 0;
                        Tablero[pos_inicio[0], filaNuevaAgente] = 2;

                        pos_inicio[1] = filaNuevaAgente;
                    }
                    else
                    {
                        Console.WriteLine("Movimiento abajo invalido");
                        habla.SpeakAsync("Invalid move, cannot move past an obstacle, the beginning or end, say a move again");
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento abajo invalido");
                    habla.SpeakAsync("Invalid move, cannot move past the limit, say a move again");
                }
            }
            else
            {
                if (pos_final[1] != filas - 1)  //Si la cantidad de filas ya es mayor se salió del tablero
                {
                    filaActualAgente = pos_final[1];
                    filaNuevaAgente = pos_final[1] + 1;

                    if ((Tablero[pos_final[0], filaNuevaAgente]) != 1 && (Tablero[pos_final[0], filaNuevaAgente]) != 2)
                    {
                        DataGridViewCell agenteActual = matrizTablero[pos_final[0], filaActualAgente];
                        agenteActual.Style.BackColor = Color.White;
                        agenteActual.ReadOnly = false;
                        agenteActual.Style.SelectionBackColor = Color.White;

                        DataGridViewCell agenteNuevo = matrizTablero[pos_final[0], filaNuevaAgente];
                        agenteNuevo.Style.BackColor = Color.Red;
                        agenteNuevo.ReadOnly = false;
                        agenteNuevo.Style.SelectionBackColor = Color.Red;

                        Tablero[pos_final[0], filaActualAgente] = 0;
                        Tablero[pos_final[0], filaNuevaAgente] = 3;

                        pos_final[1] = filaNuevaAgente;
                    }
                    else
                    {
                        Console.WriteLine("Movimiento abajo invalido");
                        habla.SpeakAsync("Invalid move, cannot move past an obstacle, the beginning or end, say a move again");
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento abajo invalido");
                    habla.SpeakAsync("Invalid move, cannot move past the limit, say a move again");
                }
            }
        }

        public void MoverIzq()
        {
            int columnaActualAgente;
            int columnaNuevaAgente;

            //pos_inicio[1] = filas (coordenada y)
            //pos_inicio[0] = columnas (coordenada x)

            if (nodo == true)
            {
                if (pos_inicio[0] != 0)
                {
                    columnaActualAgente = pos_inicio[0];
                    columnaNuevaAgente = pos_inicio[0] - 1;

                    if ((Tablero[columnaNuevaAgente, pos_inicio[1]]) != 1 && (Tablero[columnaNuevaAgente, pos_inicio[1]]) != 3)
                    {
                        DataGridViewCell agenteActual = matrizTablero[columnaActualAgente, pos_inicio[1]];
                        agenteActual.Style.BackColor = Color.White;
                        agenteActual.ReadOnly = false;
                        agenteActual.Style.SelectionBackColor = Color.White;

                        DataGridViewCell agenteNuevo = matrizTablero[columnaNuevaAgente, pos_inicio[1]];
                        agenteNuevo.Style.BackColor = Color.LawnGreen;
                        agenteNuevo.ReadOnly = false;
                        agenteNuevo.Style.SelectionBackColor = Color.LawnGreen;

                        Tablero[columnaActualAgente, pos_inicio[1]] = 0;
                        Tablero[columnaNuevaAgente, pos_inicio[1]] = 2;

                        pos_inicio[0] = columnaNuevaAgente;

                        Console.WriteLine("Movimiento izquierda: Posicion actual");
                        Console.WriteLine(matrizTablero[columnaActualAgente, pos_inicio[1]]);

                        Console.WriteLine("Movimiento izquierda:: Posicion nueva");
                        Console.WriteLine(matrizTablero[columnaNuevaAgente, pos_inicio[1]]);
                    }
                    else
                    {
                        Console.WriteLine("Movimiento Izquierda invalido");
                        habla.SpeakAsync("Invalid move, cannot move past an obstacle, the beginning or end, say a move again");
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento Izquierda invalido");
                    habla.SpeakAsync("Invalid move, cannot move past the limit, say a move again");
                }
            }

            else
            {
                if (pos_final[0] != 0)
                {
                    columnaActualAgente = pos_final[0];
                    columnaNuevaAgente = pos_final[0] - 1;

                    if ((Tablero[columnaNuevaAgente, pos_final[1]]) != 1 && (Tablero[columnaNuevaAgente, pos_final[1]]) != 2)
                    {
                        DataGridViewCell agenteActual = matrizTablero[columnaActualAgente, pos_final[1]];
                        agenteActual.Style.BackColor = Color.White;
                        agenteActual.ReadOnly = false;
                        agenteActual.Style.SelectionBackColor = Color.White;

                        DataGridViewCell agenteNuevo = matrizTablero[columnaNuevaAgente, pos_final[1]];
                        agenteNuevo.Style.BackColor = Color.Red;
                        agenteNuevo.ReadOnly = false;
                        agenteNuevo.Style.SelectionBackColor = Color.Red;

                        Tablero[columnaActualAgente, pos_final[1]] = 0;
                        Tablero[columnaNuevaAgente, pos_final[1]] = 3;

                        pos_final[0] = columnaNuevaAgente;

                        Console.WriteLine("Movimiento izquierda: Posicion actual");
                        Console.WriteLine(matrizTablero[columnaActualAgente, pos_final[1]]);

                        Console.WriteLine("Movimiento izquierda:: Posicion nueva");
                        Console.WriteLine(matrizTablero[columnaNuevaAgente, pos_final[1]]);
                    }
                    else
                    {
                        Console.WriteLine("Movimiento Izquierda invalido");
                        habla.SpeakAsync("Invalid move, cannot move past an obstacle, the beginning or end, say a move again");
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento Izquierda invalido");
                    habla.SpeakAsync("Invalid move, cannot move past the limit, say a move again");
                }
            }
        }

        public void MoverDer()
        {
            int columnaActualAgente;
            int columnaNuevaAgente;

            //pos_inicio[1] = filas (coordenada y)
            //pos_inicio[0] = columnas (coordenada x)
            if (nodo == true)
            {
                if (pos_inicio[0] != columnas - 1) // Si estoy en el borde ya no me puedo mover hacia la derecha
                {
                    columnaActualAgente = pos_inicio[0];
                    columnaNuevaAgente = pos_inicio[0] + 1;

                    if ((Tablero[columnaNuevaAgente, pos_inicio[1]]) != 1 && (Tablero[columnaNuevaAgente, pos_inicio[1]]) != 3)
                    {
                        DataGridViewCell agenteActual = matrizTablero[columnaActualAgente, pos_inicio[1]];
                        agenteActual.Style.BackColor = Color.White;
                        agenteActual.ReadOnly = false;
                        agenteActual.Style.SelectionBackColor = Color.White;

                        DataGridViewCell agenteNuevo = matrizTablero[columnaNuevaAgente, pos_inicio[1]];
                        agenteNuevo.Style.BackColor = Color.LawnGreen;
                        agenteNuevo.ReadOnly = false;
                        agenteNuevo.Style.SelectionBackColor = Color.LawnGreen;

                        Tablero[columnaActualAgente, pos_inicio[1]] = 0;
                        Tablero[columnaNuevaAgente, pos_inicio[1]] = 2;

                        pos_inicio[0] = columnaNuevaAgente;

                        Console.WriteLine("Movimiento derecha: Posicion actual");
                        Console.WriteLine(matrizTablero[columnaActualAgente, pos_inicio[1]]);

                        Console.WriteLine("Movimiento derecha: Posicion nueva");
                        Console.WriteLine(matrizTablero[columnaNuevaAgente, pos_inicio[1]]);
                    }
                    else
                    {
                        Console.WriteLine("Movimiento derecha invalido");
                        habla.SpeakAsync("Invalid move, cannot move past an obstacle, the beginning or end, say a move again");
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento derecha invalido");
                    habla.SpeakAsync("Invalid move, cannot move past the limit, say a move again");
                }

            }
            else
            {
                if (pos_final[0] != columnas - 1) // Si estoy en el borde ya no me puedo mover hacia la derecha
                {
                    columnaActualAgente = pos_final[0];
                    columnaNuevaAgente = pos_final[0] + 1;

                    if ((Tablero[columnaNuevaAgente, pos_final[1]]) != 1 && (Tablero[columnaNuevaAgente, pos_final[1]]) != 2)
                    {
                        DataGridViewCell agenteActual = matrizTablero[columnaActualAgente, pos_final[1]];
                        agenteActual.Style.BackColor = Color.White;
                        agenteActual.ReadOnly = false;
                        agenteActual.Style.SelectionBackColor = Color.White;

                        DataGridViewCell agenteNuevo = matrizTablero[columnaNuevaAgente, pos_final[1]];
                        agenteNuevo.Style.BackColor = Color.Red;
                        agenteNuevo.ReadOnly = false;
                        agenteNuevo.Style.SelectionBackColor = Color.Red;

                        Tablero[columnaActualAgente, pos_final[1]] = 0;
                        Tablero[columnaNuevaAgente, pos_final[1]] = 3;

                        pos_final[0] = columnaNuevaAgente;

                        Console.WriteLine("Movimiento derecha: Posicion actual Final");
                        Console.WriteLine(matrizTablero[columnaActualAgente, pos_final[1]]);

                        Console.WriteLine("Movimiento derecha: Posicion nueva Final");
                        Console.WriteLine(matrizTablero[columnaNuevaAgente, pos_final[1]]);
                    }
                    else
                    {
                        Console.WriteLine("Movimiento derecha Final invalido");
                        habla.SpeakAsync("Invalid move, cannot move past an obstacle, the beginning or end, say a move again");
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento derecha Final invalido");
                    habla.SpeakAsync("Invalid move, cannot move past the limit, say a move again");
                }

            }
        }

        public void MoverDiagonalNorEste()
        {
            int filaActualAgente;
            int filaNuevaAgente;
            int columnaActualAgente;
            int columnaNuevaAgente;

            //pos_inicio[1] = filas (coordenada y)
            //pos_inicio[0] = columnas (coordenada x)
            if (nodo == true)
            {
                if (pos_inicio[1] != 0 && pos_inicio[0] != columnas - 1)
                {
                    filaActualAgente = pos_inicio[1];
                    columnaActualAgente = pos_inicio[0];

                    filaNuevaAgente = pos_inicio[1] - 1;
                    columnaNuevaAgente = pos_inicio[0] + 1;

                    if ((Tablero[columnaNuevaAgente, filaNuevaAgente]) != 1 && (Tablero[columnaNuevaAgente, filaNuevaAgente]) != 3)
                    {
                        DataGridViewCell agenteActual = matrizTablero[columnaActualAgente, filaActualAgente];
                        agenteActual.Style.BackColor = Color.White;
                        agenteActual.ReadOnly = false;
                        agenteActual.Style.SelectionBackColor = Color.White;

                        DataGridViewCell agenteNuevo = matrizTablero[columnaNuevaAgente, filaNuevaAgente];
                        agenteNuevo.Style.BackColor = Color.LawnGreen;
                        agenteNuevo.ReadOnly = false;
                        agenteNuevo.Style.SelectionBackColor = Color.LawnGreen;

                        Tablero[columnaActualAgente, filaActualAgente] = 0;
                        Tablero[columnaNuevaAgente, filaNuevaAgente] = 2;

                        pos_inicio[0] = columnaNuevaAgente;
                        pos_inicio[1] = filaNuevaAgente;

                        Console.WriteLine("Movimiento diagonal NorEste: Posicion actual");
                        Console.WriteLine(matrizTablero[columnaActualAgente, filaActualAgente]);

                        Console.WriteLine("Movimiento diagonal NorEste: Posicion nueva");
                        Console.WriteLine(matrizTablero[columnaNuevaAgente, filaNuevaAgente]);
                    }
                    else
                    {
                        Console.WriteLine("Movimiento diagonal NorEste invalido");
                        habla.SpeakAsync("Invalid move, cannot move past an obstacle, the beginning or end , say a move again");
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento diagonal NorEste invalido");
                    habla.SpeakAsync("Invalid move, cannot move past the limit, say a move again");
                }
            }
            else
            {
                if (pos_final[1] != 0 && pos_final[0] != columnas - 1)
                {
                    filaActualAgente = pos_final[1];
                    columnaActualAgente = pos_final[0];

                    filaNuevaAgente = pos_final[1] - 1;
                    columnaNuevaAgente = pos_final[0] + 1;

                    if ((Tablero[columnaNuevaAgente, filaNuevaAgente]) != 1 && (Tablero[columnaNuevaAgente, filaNuevaAgente]) != 2)
                    {
                        DataGridViewCell agenteActual = matrizTablero[columnaActualAgente, filaActualAgente];
                        agenteActual.Style.BackColor = Color.White;
                        agenteActual.ReadOnly = false;
                        agenteActual.Style.SelectionBackColor = Color.White;

                        DataGridViewCell agenteNuevo = matrizTablero[columnaNuevaAgente, filaNuevaAgente];
                        agenteNuevo.Style.BackColor = Color.Red;
                        agenteNuevo.ReadOnly = false;
                        agenteNuevo.Style.SelectionBackColor = Color.Red;

                        Tablero[columnaActualAgente, filaActualAgente] = 0;
                        Tablero[columnaNuevaAgente, filaNuevaAgente] = 3;

                        pos_final[0] = columnaNuevaAgente;
                        pos_final[1] = filaNuevaAgente;

                        Console.WriteLine("Movimiento diagonal NorEste: Posicion actual Final");
                        Console.WriteLine(matrizTablero[columnaActualAgente, filaActualAgente]);

                        Console.WriteLine("Movimiento diagonal NorEste: Posicion nueva Final");
                        Console.WriteLine(matrizTablero[columnaNuevaAgente, filaNuevaAgente]);
                    }
                    else
                    {
                        Console.WriteLine("Movimiento diagonal NorEste Final invalido");
                        habla.SpeakAsync("Invalid move, cannot move past an obstacle, the beginning or end, say a move again");
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento diagonal NorEste Final invalido");
                    habla.SpeakAsync("Invalid move, cannot move past the limit, say a move again");
                }
            }
        }

        public void MoverDiagonalNorOeste()
        {
            int filaActualAgente;
            int filaNuevaAgente;
            int columnaActualAgente;
            int columnaNuevaAgente;

            //pos_inicio[1] = filas (coordenada y)
            //pos_inicio[0] = columnas (coordenada x)
            if (nodo == true)
            {
                if (pos_inicio[0] != 0 && pos_inicio[1] != 0)
                {
                    filaActualAgente = pos_inicio[1];
                    columnaActualAgente = pos_inicio[0];

                    filaNuevaAgente = pos_inicio[1] - 1;
                    columnaNuevaAgente = pos_inicio[0] - 1;

                    if ((Tablero[columnaNuevaAgente, filaNuevaAgente]) != 1 && (Tablero[columnaNuevaAgente, filaNuevaAgente]) != 3)
                    {
                        DataGridViewCell agenteActual = matrizTablero[columnaActualAgente, filaActualAgente];
                        agenteActual.Style.BackColor = Color.White;
                        agenteActual.ReadOnly = false;
                        agenteActual.Style.SelectionBackColor = Color.White;

                        DataGridViewCell agenteNuevo = matrizTablero[columnaNuevaAgente, filaNuevaAgente];
                        agenteNuevo.Style.BackColor = Color.LawnGreen;
                        agenteNuevo.ReadOnly = false;
                        agenteNuevo.Style.SelectionBackColor = Color.LawnGreen;

                        Tablero[columnaActualAgente, filaActualAgente] = 0;
                        Tablero[columnaNuevaAgente, filaNuevaAgente] = 2;

                        pos_inicio[0] = columnaNuevaAgente;
                        pos_inicio[1] = filaNuevaAgente;

                        Console.WriteLine("Movimiento diagonal NorOeste: Posicion actual");
                        Console.WriteLine(matrizTablero[columnaActualAgente, filaActualAgente]);

                        Console.WriteLine("Movimiento diagonal NorOeste: Posicion nueva");
                        Console.WriteLine(matrizTablero[columnaNuevaAgente, filaNuevaAgente]);
                    }
                    else
                    {
                        Console.WriteLine("Movimiento diagonal NorOeste invalido");
                        habla.SpeakAsync("Invalid move, cannot move past an obstacle, the beginning or end, say a move again");
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento diagonal NorOeste invalido");
                    habla.SpeakAsync("Invalid move, cannot move past the limit, say a move again");
                }


            }
            else
            {
                if (pos_final[0] != 0 && pos_final[1] != 0)
                {
                    filaActualAgente = pos_final[1];
                    columnaActualAgente = pos_final[0];

                    filaNuevaAgente = pos_final[1] - 1;
                    columnaNuevaAgente = pos_final[0] - 1;

                    if ((Tablero[columnaNuevaAgente, filaNuevaAgente]) != 1 && (Tablero[columnaNuevaAgente, filaNuevaAgente]) != 2)
                    {
                        DataGridViewCell agenteActual = matrizTablero[columnaActualAgente, filaActualAgente];
                        agenteActual.Style.BackColor = Color.White;
                        agenteActual.ReadOnly = false;
                        agenteActual.Style.SelectionBackColor = Color.White;

                        DataGridViewCell agenteNuevo = matrizTablero[columnaNuevaAgente, filaNuevaAgente];
                        agenteNuevo.Style.BackColor = Color.Red;
                        agenteNuevo.ReadOnly = false;
                        agenteNuevo.Style.SelectionBackColor = Color.Red;

                        Tablero[columnaActualAgente, filaActualAgente] = 0;
                        Tablero[columnaNuevaAgente, filaNuevaAgente] = 3;

                        pos_final[0] = columnaNuevaAgente;
                        pos_final[1] = filaNuevaAgente;

                        Console.WriteLine("Movimiento diagonal NorOeste: Posicion actual Final");
                        Console.WriteLine(matrizTablero[columnaActualAgente, filaActualAgente]);

                        Console.WriteLine("Movimiento diagonal NorOeste: Posicion nueva Final");
                        Console.WriteLine(matrizTablero[columnaNuevaAgente, filaNuevaAgente]);
                    }
                    else
                    {
                        Console.WriteLine("Movimiento diagonal NorOeste Final invalido");
                        habla.SpeakAsync("Invalid move, cannot move past an obstacle, the beginning or end, say a move again");
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento diagonal NorOeste Final invalido");
                    habla.SpeakAsync("Invalid move, cannot move past the limit, say a move again");
                }

            }
        }
        public void MoverDiagonalSurEste()
        {
            int filaActualAgente;
            int filaNuevaAgente;
            int columnaActualAgente;
            int columnaNuevaAgente;

            //pos_inicio[1] = filas (coordenada y)
            //pos_inicio[0] = columnas (coordenada x)
            if (nodo == true)
            {
                if (pos_inicio[0] != columnas - 1 && pos_inicio[1] != filas - 1)
                {
                    filaActualAgente = pos_inicio[1];
                    columnaActualAgente = pos_inicio[0];

                    filaNuevaAgente = pos_inicio[1] + 1;
                    columnaNuevaAgente = pos_inicio[0] + 1;

                    if ((Tablero[columnaNuevaAgente, filaNuevaAgente]) != 1 && (Tablero[columnaNuevaAgente, filaNuevaAgente]) != 3)
                    {
                        DataGridViewCell agenteActual = matrizTablero[columnaActualAgente, filaActualAgente];
                        agenteActual.Style.BackColor = Color.White;
                        agenteActual.ReadOnly = false;
                        agenteActual.Style.SelectionBackColor = Color.White;

                        DataGridViewCell agenteNuevo = matrizTablero[columnaNuevaAgente, filaNuevaAgente];
                        agenteNuevo.Style.BackColor = Color.LawnGreen;
                        agenteNuevo.ReadOnly = false;
                        agenteNuevo.Style.SelectionBackColor = Color.LawnGreen;

                        Tablero[columnaActualAgente, filaActualAgente] = 0;
                        Tablero[columnaNuevaAgente, filaNuevaAgente] = 2;

                        pos_inicio[0] = columnaNuevaAgente;
                        pos_inicio[1] = filaNuevaAgente;

                        Console.WriteLine("Movimiento diagonal SurEste: Posicion actual");
                        Console.WriteLine(matrizTablero[columnaActualAgente, filaActualAgente]);

                        Console.WriteLine("Movimiento diagonal SurEste: Posicion nueva");
                        Console.WriteLine(matrizTablero[columnaNuevaAgente, filaNuevaAgente]);
                    }
                    else
                    {
                        Console.WriteLine("Movimiento diagonal SurEste invalido");
                        habla.SpeakAsync("Invalid move, cannot move past an obstacle, the beginning or end, say a move again");
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento diagonal SurEste invalido");
                    habla.SpeakAsync("Invalid move, cannot move past the limit, say a move again");
                }


            }
            else
            {
                if (pos_final[0] != columnas - 1 && pos_final[1] != filas - 1)
                {
                    filaActualAgente = pos_final[1];
                    columnaActualAgente = pos_final[0];

                    filaNuevaAgente = pos_final[1] + 1;
                    columnaNuevaAgente = pos_final[0] + 1;

                    if ((Tablero[columnaNuevaAgente, filaNuevaAgente]) != 1 && (Tablero[columnaNuevaAgente, filaNuevaAgente]) != 2)
                    {
                        DataGridViewCell agenteActual = matrizTablero[columnaActualAgente, filaActualAgente];
                        agenteActual.Style.BackColor = Color.White;
                        agenteActual.ReadOnly = false;
                        agenteActual.Style.SelectionBackColor = Color.White;

                        DataGridViewCell agenteNuevo = matrizTablero[columnaNuevaAgente, filaNuevaAgente];
                        agenteNuevo.Style.BackColor = Color.Red;
                        agenteNuevo.ReadOnly = false;
                        agenteNuevo.Style.SelectionBackColor = Color.Red;

                        Tablero[columnaActualAgente, filaActualAgente] = 0;
                        Tablero[columnaNuevaAgente, filaNuevaAgente] = 3;

                        pos_final[0] = columnaNuevaAgente;
                        pos_final[1] = filaNuevaAgente;

                        Console.WriteLine("Movimiento diagonal SurEste Final: Posicion actual");
                        Console.WriteLine(matrizTablero[columnaActualAgente, filaActualAgente]);

                        Console.WriteLine("Movimiento diagonal SurEste Final: Posicion nueva");
                        Console.WriteLine(matrizTablero[columnaNuevaAgente, filaNuevaAgente]);
                    }
                    else
                    {
                        Console.WriteLine("Movimiento diagonal SurEste Final invalido");
                        habla.SpeakAsync("Invalid move, cannot move past an obstacle, the beginning or end, say a move again");
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento diagonal SurEste Final invalido");
                    habla.SpeakAsync("Invalid move, cannot move past the limit, say a move again");
                }

            }
        }

        public void MoverDiagonalSurOeste()
        {
            int filaActualAgente;
            int filaNuevaAgente;
            int columnaActualAgente;
            int columnaNuevaAgente;

            //pos_inicio[1] = filas (coordenada y)
            //pos_inicio[0] = columnas (coordenada x)
            if (nodo == true)
            {
                if (pos_inicio[0] != columnas - 1 && pos_inicio[1] != filas - 1)
                {
                    filaActualAgente = pos_inicio[1];
                    columnaActualAgente = pos_inicio[0];

                    filaNuevaAgente = pos_inicio[1] + 1;
                    columnaNuevaAgente = pos_inicio[0] - 1;

                    if ((Tablero[columnaNuevaAgente, filaNuevaAgente]) != 1 && (Tablero[columnaNuevaAgente, filaNuevaAgente]) != 3)
                    {
                        DataGridViewCell agenteActual = matrizTablero[columnaActualAgente, filaActualAgente];
                        agenteActual.Style.BackColor = Color.White;
                        agenteActual.ReadOnly = false;
                        agenteActual.Style.SelectionBackColor = Color.White;

                        DataGridViewCell agenteNuevo = matrizTablero[columnaNuevaAgente, filaNuevaAgente];
                        agenteNuevo.Style.BackColor = Color.LawnGreen;
                        agenteNuevo.ReadOnly = false;
                        agenteNuevo.Style.SelectionBackColor = Color.LawnGreen;

                        Tablero[columnaActualAgente, filaActualAgente] = 0;
                        Tablero[columnaNuevaAgente, filaNuevaAgente] = 2;

                        pos_inicio[0] = columnaNuevaAgente;
                        pos_inicio[1] = filaNuevaAgente;

                        Console.WriteLine("Movimiento diagonal SurOEste: Posicion actual");
                        Console.WriteLine(matrizTablero[columnaActualAgente, filaActualAgente]);

                        Console.WriteLine("Movimiento diagonal SurOEste: Posicion nueva");
                        Console.WriteLine(matrizTablero[columnaNuevaAgente, filaNuevaAgente]);
                    }
                    else
                    {
                        Console.WriteLine("Movimiento diagonal SurOEste invalido");
                        habla.SpeakAsync("Invalid move, cannot move past an obstacle, the beginning or end, say a move again");
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento diagonal SurOEste invalido");
                    habla.SpeakAsync("Invalid move, cannot move past the limit, say a move again");
                }
            }
            else
            {
                if (pos_final[0] != columnas - 1 && pos_final[1] != filas - 1)
                {
                    filaActualAgente = pos_final[1];
                    columnaActualAgente = pos_final[0];

                    filaNuevaAgente = pos_final[1] + 1;
                    columnaNuevaAgente = pos_final[0] - 1;

                    if ((Tablero[columnaNuevaAgente, filaNuevaAgente]) != 1 && (Tablero[columnaNuevaAgente, filaNuevaAgente]) != 2)
                    {
                        DataGridViewCell agenteActual = matrizTablero[columnaActualAgente, filaActualAgente];
                        agenteActual.Style.BackColor = Color.White;
                        agenteActual.ReadOnly = false;
                        agenteActual.Style.SelectionBackColor = Color.White;

                        DataGridViewCell agenteNuevo = matrizTablero[columnaNuevaAgente, filaNuevaAgente];
                        agenteNuevo.Style.BackColor = Color.Red;
                        agenteNuevo.ReadOnly = false;
                        agenteNuevo.Style.SelectionBackColor = Color.Red;

                        Tablero[columnaActualAgente, filaActualAgente] = 0;
                        Tablero[columnaNuevaAgente, filaNuevaAgente] = 3;

                        pos_final[0] = columnaNuevaAgente;
                        pos_final[1] = filaNuevaAgente;

                        Console.WriteLine("Movimiento diagonal SurOEste: Posicion actual");
                        Console.WriteLine(matrizTablero[columnaActualAgente, filaActualAgente]);

                        Console.WriteLine("Movimiento diagonal SurOEste: Posicion nueva");
                        Console.WriteLine(matrizTablero[columnaNuevaAgente, filaNuevaAgente]);
                    }
                    else
                    {
                        Console.WriteLine("Movimiento diagonal SurOEste invalido");
                        habla.SpeakAsync("Invalid move, cannot move past an obstacle, the beginning or end, say a move again");
                    }
                }
                else
                {
                    Console.WriteLine("Movimiento diagonal SurOEste invalido");
                    habla.SpeakAsync("Invalid move, cannot move past the limit, say a move again");
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
                    case "ten":
                        numeroReal = 10;
                        break;
                    case "eleven":
                        numeroReal = 11;
                        break;
                    case "twelve":
                        numeroReal = 12;
                        break;
                    case "thirteen":
                        numeroReal = 13;
                        break;
                    case "fourteen":
                        numeroReal = 14;
                        break;
                    case "fifteen":
                        numeroReal = 15;
                        break;
                    case "sixteen":
                        numeroReal = 16;
                        break;
                    case "seventeen":
                        numeroReal = 17;
                        break;
                    case "eighteen":
                        numeroReal = 18;
                        break;
                    case "nineteen":
                        numeroReal = 19;
                        break;
                    case "twenty":
                        numeroReal = 20;
                        break;
                    case "twenty one":
                        numeroReal = 21;
                        break;
                    case "twenty two":
                        numeroReal = 22;
                        break;
                    case "twenty three":
                        numeroReal = 23;
                        break;
                    case "twenty four":
                        numeroReal = 24;
                        break;
                    case "twenty five":
                        numeroReal = 25;
                        break;
                    case "twenty six":
                        numeroReal = 26;
                        break;
                    case "twenty seven":
                        numeroReal = 27;
                        break;
                    case "twenty eight":
                        numeroReal = 28;
                        break;
                    case "twenty nine":
                        numeroReal = 29;
                        break;
                    case "thirty":
                        numeroReal = 30;
                        break;
                    case "thirty one":
                        numeroReal = 31;
                        break;
                    case "thirty two":
                        numeroReal = 32;
                        break;
                    case "thirty three":
                        numeroReal = 33;
                        break;
                    case "thirty four":
                        numeroReal = 34;
                        break;
                    case "thirty five":
                        numeroReal = 35;
                        break;
                    case "thirty six":
                        numeroReal = 36;
                        break;
                    case "thirty seven":
                        numeroReal = 37;
                        break;
                    case "thirty eight":
                        numeroReal = 38;
                        break;
                    case "thirty nine":
                        numeroReal = 39;
                        break;
                    case "forty":
                        numeroReal = 40;
                        break;
                    case "forty one":
                        numeroReal = 41;
                        break;
                    case "forty two":
                        numeroReal = 42;
                        break;
                    case "forty three":
                        numeroReal = 43;
                        break;
                    case "forty four":
                        numeroReal = 44;
                        break;
                    case "forty five":
                        numeroReal = 45;
                        break;
                    case "forty six":
                        numeroReal = 46;
                        break;
                    case "forty seven":
                        numeroReal = 47;
                        break;
                    case "forty eight":
                        numeroReal = 48;
                        break;
                    case "forty nine":
                        numeroReal = 49;
                        break;
                    case "fifty":
                        numeroReal = 50;
                        break;
                    case "fifty one":
                        numeroReal = 51;
                        break;
                    case "fifty two":
                        numeroReal = 52;
                        break;
                    case "fifty three":
                        numeroReal = 53;
                        break;
                    case "fifty four":
                        numeroReal = 54;
                        break;
                    case "fifty five":
                        numeroReal = 55;
                        break;
                    case "fifty six":
                        numeroReal = 56;
                        break;
                    case "fifty seven":
                        numeroReal = 57;
                        break;
                    case "fifty eight":
                        numeroReal = 58;
                        break;
                    case "fifty nine":
                        numeroReal = 59;
                        break;
                    case "sixty":
                        numeroReal = 60;
                        break;
                    case "sixty one":
                        numeroReal = 61;
                        break;
                    case "sixty two":
                        numeroReal = 62;
                        break;
                    case "sixty three":
                        numeroReal = 63;
                        break;
                    case "sixty four":
                        numeroReal = 64;
                        break;
                    case "sixty five":
                        numeroReal = 65;
                        break;
                    case "sixty six":
                        numeroReal = 66;
                        break;
                    case "sixty seven":
                        numeroReal = 67;
                        break;
                    case "sixty eight":
                        numeroReal = 68;
                        break;
                    case "sixty nine":
                        numeroReal = 69;
                        break;
                    case "seventy":
                        numeroReal = 70;
                        break;
                    case "seventy one":
                        numeroReal = 71;
                        break;
                    case "seventy two":
                        numeroReal = 72;
                        break;
                    case "seventy three":
                        numeroReal = 73;
                        break;
                    case "seventy four":
                        numeroReal = 74;
                        break;
                    case "seventy five":
                        numeroReal = 75;
                        break;
                    case "seventy six":
                        numeroReal = 76;
                        break;
                    case "seventy seven":
                        numeroReal = 77;
                        break;
                    case "seventy eight":
                        numeroReal = 78;
                        break;
                    case "seventy nine":
                        numeroReal = 79;
                        break;
                    case "eighty":
                        numeroReal = 80;
                        break;
                    case "eighty one":
                        numeroReal = 81;
                        break;
                    case "eighty two":
                        numeroReal = 82;
                        break;
                    case "eighty three":
                        numeroReal = 83;
                        break;
                    case "eighty four":
                        numeroReal = 84;
                        break;
                    case "eighty five":
                        numeroReal = 85;
                        break;
                    case "eighty six":
                        numeroReal = 86;
                        break;
                    case "eighty seven":
                        numeroReal = 87;
                        break;
                    case "eighty eight":
                        numeroReal = 88;
                        break;
                    case "eighty nine":
                        numeroReal = 89;
                        break;
                    case "ninety":
                        numeroReal = 90;
                        break;
                    case "ninety one":
                        numeroReal = 91;
                        break;
                    case "ninety two":
                        numeroReal = 92;
                        break;
                    case "ninety three":
                        numeroReal = 93;
                        break;
                    case "ninety four":
                        numeroReal = 94;
                        break;
                    case "ninety five":
                        numeroReal = 95;
                        break;
                    case "ninety six":
                        numeroReal = 96;
                        break;
                    case "ninety seven":
                        numeroReal = 97;
                        break;
                    case "ninety eight":
                        numeroReal = 98;
                        break;
                    case "ninety nine":
                        numeroReal = 99;
                        break;
                    case "hundred":
                        numeroReal = 100;
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
                    int pos = random.Next(0, pos_disponibles.Count());

                    if (valorOcupado(posOcupadas, pos_disponibles, pos) == true)
                    {
                        estado = true;
                    }
                    else
                    {
                        int[] ocupadas = new int[3];
                        x = pos_disponibles[pos][0];
                        y = pos_disponibles[pos][1];

                        ocupadas[0] = x;
                        ocupadas[1] = y;

                        tablero[x, y] = 1;
                        posOcupadas.Add(ocupadas);
                        
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

       
        public Nodo ObtenerNodo(List<Nodo> lista, Nodo nodo)
        {
            foreach (Nodo value in lista)
            {
                if (value.posicion[0] == nodo.posicion[0] && value.posicion[1] == nodo.posicion[1])
                {
                    return value;
                }
            }
            return null;
        }

        public Boolean EsIgual(List<Nodo> lista, Nodo nodo)
        {
            foreach (Nodo value in lista)
            {
                if (value.posicion[0] == nodo.posicion[0] && value.posicion[1] == nodo.posicion[1])
                {
                    return true;
                }
                continue;
            }
            return false;
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
                        fn = (Math.Abs(nodo_abierto.posicion[0] - nodoFinal.posicion[0]) + Math.Abs(nodo_abierto.posicion[1] - nodoFinal.posicion[1])) * tamanoCasillas + gn;
                        Nodo_Adyacente = new Nodo(nodoActual, nodo_abierto.posicion, gn, fn, nodo_abierto.movimiento);//Se crea el nodo adyacente con el nodo padre, gn y fn calculados

                        if (EsIgual(listaAbierta, nodo_abierto) == false)
                        {
                            agregarNodoAListaAbierta(Nodo_Adyacente);//Agrega todos los hijos del nodo actual.
                        }
                        else
                        {
                            Nodo nodoAntiguo = ObtenerNodo(listaAbierta, nodo_abierto);

                            if (nodoAntiguo.gn < Nodo_Adyacente.gn)
                            {
                                Nodo_Adyacente.gn = nodoAntiguo.gn;
                                Nodo_Adyacente.nodoPadre = nodoAntiguo.nodoPadre;

                                listaAbierta.Remove(nodoAntiguo);
                                agregarNodoAListaAbierta(Nodo_Adyacente);
                            }
                        }

                    }
                    else
                    {
                        gn = nodoActual.gn + costoDiagonal; //Movimiento en diagonal
                        fn = (Math.Abs(nodo_abierto.posicion[0] - nodoFinal.posicion[0]) + Math.Abs(nodo_abierto.posicion[1] - nodoFinal.posicion[1])) * tamanoCasillas + gn;
                        Nodo_Adyacente = new Nodo(nodoActual, nodo_abierto.posicion, gn, fn, nodo_abierto.movimiento);//Se crea el nodo adyacente con el nodo padre, gn y fn calculados

                        if (!listaAbierta.Contains(nodo_abierto))
                        {
                            agregarNodoAListaAbierta(Nodo_Adyacente);//Agrega todos los hijos del nodo actual.
                        }
                        else
                        {
                            Nodo nodoAntiguo = ObtenerNodo(listaAbierta, nodo_abierto);
                            if (nodoAntiguo.gn < Nodo_Adyacente.gn)
                            {
                                Nodo_Adyacente.gn = nodoAntiguo.gn;
                                Nodo_Adyacente.nodoPadre = nodoAntiguo.nodoPadre;

                                listaAbierta.Remove(nodoAntiguo);
                                agregarNodoAListaAbierta(Nodo_Adyacente);
                            }
                        }
                    }
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
                listaCerrada.Add(nodoActual.posicion);

                nodosAdyacentes = encontrarNodosAdyacentes(nodoActual, Tablero, diagonal); //Encuentra los nodos adyacentes del nodo actual
                calcular_fn(nodoActual, nodo_final, nodosAdyacentes, listaAbierta, listaCerrada, costo); //Calcula el fn de cada uno de los nodos adyacentes al nodo actual
            }
            return null;
        }
        
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