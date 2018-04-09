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

        public List<int[]> Tablero = new List<int[]>(); //Cuadricula donde 0 es vacio y 1 es obstaculo
        public List<int[]> Obstaculos = new List<int[]>();  
       
        public Boolean diagonal; //Si se activa la opción para diagonales

        // Variables para manejar el flujo del habla y qué opciones para el usuario
        int comenzar = 1;
        int terminar = 0;
        int dimensiones = 0;
        int banderaColumnas = 0;
        int banderaTamanoCasilla = 0;
        int banderaFilas = 0;
        int filas = 0;
        int columnas = 0;
        int tamanoCasillas = 0;
        int activarDiagonal = 0;
        int posInicio = 0;
        int posFinal = 0;
        int limpiar = 0;
        int cambiarN = 0;
        int cambiarM = 0;
        int cambiarA = 0;

        List<string> numerosEnLetras = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "zero"};
        List<string> numerosComunes = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};

        public Maze()
        {
            InitializeComponent();
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            InicializarTablero();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Choices comandos = new Choices();

            // Crear gramática para escucha
            comandos.Add(new string[] { "start", "clean", "up", "down", "left", "right", "done", "yes", "no", "finish", "diagonal", "option", "rows", "columns",
                                        "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "zero", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" });

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
            TxbTamano.Text = e.Result.Text;
            float confidence = e.Result.Confidence;
            if (confidence < 0.50)
            {
                Console.WriteLine("Low confidence");
            }
            else if (comenzar == 1)
            {
                Console.WriteLine("comenzar");
                if (e.Result.Text == "start")
                {
                    habla.SpeakAsync("Do you want to set the table dimensions? Say yes or no");
                    comenzar = 0;
                    dimensiones = 1;
                }
                else if (e.Result.Text == "finish")
                {
                    Console.WriteLine("termino");
                    habla.SpeakAsync("Thanks for playing, bye bye.");
                    this.Close();
                }
            }
            else if (dimensiones == 1)
            {
                Console.WriteLine("cambiar dimensiones");
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
                Console.WriteLine("Poner columnas");
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

                habla.SpeakAsync("Please say the number for the size for the table boxes");
                banderaFilas = 0;
                banderaTamanoCasilla = 1;
                Console.WriteLine(columnas.ToString() + filas.ToString());
            }
        }

        private void InicializarTablero()
        {
            double costo_diagonal;
            matrizTablero.ColumnCount = columnas;
            matrizTablero.RowCount = filas;

            int[] pos_n = { 0, 0 };
            int[] pos_final = { columnas - 1, filas - 1 };
            costo_diagonal = Math.Sqrt(2) * tamanoCasillas;

            //CrearTablero(n, m);
            //LlenarTablero(n, m, pos_n, pos_final);
            //cargarDatos(pos_n,pos_final);
            //formatoCelda(pos_n,pos_final);

            //Nodo nodo_n = new Nodo(null, pos_n, 0, 0, 0); //Posicion de inicio que se elija para el agente
            //Nodo nodo_final = new Nodo(null, pos_final, 0, 0, 0); //Posicion final que se elija para el agente

            //Color tablero
            matrizTablero.BackgroundColor = Color.White;
            matrizTablero.DefaultCellStyle.BackColor = Color.White;

            //Establecer el ancho de las columnas
            foreach (DataGridViewColumn c in matrizTablero.Columns)
            {
                // c.Width = matrizTablero.Width / matrizTablero.Columns.Count;
                c.Width = tamanoCasillas;
                c.Width += matrizTablero.Width / matrizTablero.Columns.Count;
            }

            //Establecer el ancho de las filas
            foreach (DataGridViewRow r in matrizTablero.Rows)
            {
                //r.Height = matrizTablero.Height / matrizTablero.Rows.Count;
                r.Height = tamanoCasillas;
                r.Height += matrizTablero.Height / matrizTablero.Rows.Count;
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            matrizTablero.Rows.Clear();
            matrizTablero.Columns.Clear();
            matrizTablero.Refresh();
        }
        
        private void LlenarTablero(int n, int m,int[] pos_inicio, int[] pos_final)
        {
            int i = 0;
            int j = 0;
            while(i < n)
            {
                while (j < m)
                {
                    Tablero[i][j] = 0;
                    j += 1;
                }
                i += 1;
                j = 0;
            }
        }

        private void CrearTablero(int n, int m)
        {
            int[] filas = new int[m];
            for(int i =0; i< n; i++)
            {
                Tablero.Add(filas);
            }
        }

        private void GuardarObstaculos(int x, int y, int identificador)
        {
            int[] marca_obstaculo = new int[3];
            marca_obstaculo[0] = x;
            marca_obstaculo[1] = y;
            marca_obstaculo[2] = identificador;
            Obstaculos.Add(marca_obstaculo);
           // cargarDatos();
        }

        private void cargarDatos(int [] pos_n, int [] pos_final)
        {
            Tablero[pos_n[0]][pos_n[1]] = 2;
            Tablero[pos_final[0]][pos_final[1]] = 3;
        }

        private void formatoCelda(int [] pos_n, int[] pos_final)
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
        }

        private void matrizTablero_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewCell celda in matrizTablero.SelectedCells)
            {
                celda.Style.BackColor = Color.Black;
                celda.ReadOnly = false;
                celda.Style.SelectionBackColor = Color.Black;

                /*string msg = String.Format("Row: {0}, Column: {1}",celda.RowIndex,
                celda.ColumnIndex);
                MessageBox.Show(msg, "Current Cell");*/

                if(celda.Style.BackColor == Color.Black)
                {
                    int fila = celda.RowIndex;
                    int columna = celda.ColumnIndex;
                    GuardarObstaculos(fila, columna, 1);
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
    }
}
