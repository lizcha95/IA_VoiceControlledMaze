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


namespace VoiceRecognitionMaze
{
    public partial class Maze : Form
    {
        //SpeechRecognitionEngine escucha = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("es-ES"));
        //SpeechRecognitionEngine escucha = new SpeechRecognitionEngine();

        public List<int[]> Tablero = new List<int[]>(); //Cuadricula donde 0 es vacio y 1 es obstaculo
        public List<int[]> Obstaculos = new List<int[]>();
       
        public Boolean diagonal; //Si se activa la opción para diagonales
        

        public Maze()
        {
            InitializeComponent();
            

        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            /*try
            {
                escucha.SetInputToDefaultAudioDevice();
                escucha.LoadGrammar(new DictationGrammar());
                escucha.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(reconocedor);
                escucha.RecognizeAsync(RecognizeMode.Multiple);
            }

            catch
            {
                MessageBox.Show("Ya dio acceso al uso del micrófono");
            }*/

            InicializarTablero();
            


        }

        public void reconocedor(object sender, SpeechRecognizedEventArgs e)
        {
            foreach (RecognizedWordUnit comando in e.Result.Words)
            {
                TxbColumnas.Text += comando.Text + " ";
            }

        }

        private void Form1_Load(object sender, EventArgs e) {


        }

        private void InicializarTablero()
        {

            //m = columnas
            //n = filas
            //a = tamaño de cada cuadro 

            int m, n, a;
            double costo_diagonal;
            m = int.Parse(TxbColumnas.Text);
            n = int.Parse(TxbFilas.Text);
            a = int.Parse(TxbTamano.Text);
            matrizTablero.ColumnCount = m;
            matrizTablero.RowCount = n;


            int[] pos_n = { 0, 0 };
            int[] pos_final = { m - 1, n - 1 };
            costo_diagonal = Math.Sqrt(2) * a;

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
                c.Width = a;
                c.Width += matrizTablero.Width / matrizTablero.Columns.Count;


            }

            //Establecer el ancho de las filas
            foreach (DataGridViewRow r in matrizTablero.Rows)
            {
                //r.Height = matrizTablero.Height / matrizTablero.Rows.Count;
                r.Height = a;
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
    }
}
