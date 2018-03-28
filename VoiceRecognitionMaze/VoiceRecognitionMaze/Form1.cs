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
    public partial class Form1 : Form
    {
        //SpeechRecognitionEngine escucha = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("es-ES"));
        SpeechRecognitionEngine escucha = new SpeechRecognitionEngine();
        public Form1()
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
        private void Form1_Load(object sender, EventArgs e){
           

        }

        private void InicializarTablero()
        {

            int columnas, filas, tamanio;
            columnas = int.Parse(TxbColumnas.Text);
            filas = int.Parse(TxbFilas.Text);
            tamanio = int.Parse(TxbTamano.Text);
            matrizTablero.ColumnCount = columnas;
            matrizTablero.RowCount = filas;

            matrizTablero.BackgroundColor = Color.White;
            matrizTablero.DefaultCellStyle.BackColor = Color.White;

            //Establecer el ancho de las columnas
            foreach (DataGridViewColumn c in matrizTablero.Columns)
            {
              //  c.Width = matrizTablero.Width / matrizTablero.Columns.Count;
                c.Width = tamanio;
                c.Width += matrizTablero.Width / matrizTablero.Columns.Count;


            }

            //Establecer el ancho de las filas
            foreach (DataGridViewRow r in matrizTablero.Rows)
            {
               //r.Height = matrizTablero.Height / matrizTablero.Rows.Count;
                r.Height =  tamanio;
                r.Height += matrizTablero.Height / matrizTablero.Rows.Count;

            }


        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            matrizTablero.Rows.Clear();
            matrizTablero.Columns.Clear();
            matrizTablero.Refresh();
        }
    }
}
