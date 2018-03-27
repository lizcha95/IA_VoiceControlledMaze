using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceRecognitionMaze
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

            ArrayList grafo_costo;
            grafo_costo = new ArrayList();

            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/

            Dictionary<string, int> grafo_heuristica = new Dictionary<string, int>();
            grafo_costo.Add("Arad");
            ArrayList ciudadesArad;
            ciudadesArad = new ArrayList();
            ciudadesArad.Add("Zerind");
            ciudadesArad.Add(75);

            grafo_costo.Add(ciudadesArad);



            Console.WriteLine(grafo_costo);
            Console.ReadLine();




            grafo_heuristica.Add("Arad", 366);
            grafo_heuristica.Add("Bucharest", 0);
            grafo_heuristica.Add("Craiova", 160);
            grafo_heuristica.Add("Drobeta", 242);
            grafo_heuristica.Add("Eforie", 161);
            grafo_heuristica.Add("Fagaras", 176);
            grafo_heuristica.Add("Giurgiu", 77);
            grafo_heuristica.Add("Hirsova", 151);
            grafo_heuristica.Add("Iasi", 226);
            grafo_heuristica.Add("Lugoj", 244);
            grafo_heuristica.Add("Mehadia", 241);
            grafo_heuristica.Add("Neamt", 234);
            grafo_heuristica.Add("Oradea", 380);
            grafo_heuristica.Add("Pitesti", 100);
            grafo_heuristica.Add("RimnicuVilcea", 193);
            grafo_heuristica.Add("Sibiu", 253);
            grafo_heuristica.Add("Timisoara", 329);
            grafo_heuristica.Add("Urziceni", 80);
            grafo_heuristica.Add("Vaslui", 199);
            grafo_heuristica.Add("Zerind", 374);


            



        }
    }
}
