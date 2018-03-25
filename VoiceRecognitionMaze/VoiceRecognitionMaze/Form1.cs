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
            try
            {
                escucha.SetInputToDefaultAudioDevice();
                escucha.LoadGrammar(new DictationGrammar());
                escucha.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(reconocedor);
                escucha.RecognizeAsync(RecognizeMode.Multiple);
            }

            catch
            {
                MessageBox.Show("Ya dio acceso al uso del micrófono");
            }
        }

        public void reconocedor(object sender, SpeechRecognizedEventArgs e)
        {
            foreach (RecognizedWordUnit comando in e.Result.Words)
            {
                TxbColumnas.Text += comando.Text + " ";
            }


            /*int columna, fila;
            columna = int.Parse(TxbColumnas.Text);
            fila = int.Parse(TxbFilas.Text);

            matrizTablero.ColumnCount = columna;
            matrizTablero.RowCount = fila;  */          
        }

    }
}
