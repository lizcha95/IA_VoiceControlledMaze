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
        static void Main(string[] args)
        {

            ArrayList grafo_costo;
            grafo_costo = new ArrayList();
            ArrayList ciudades;
            ciudades = new ArrayList();

            ArrayList Arad;
            Arad = new ArrayList();

            ArrayList ciudad;
            ciudad = new ArrayList();
            ciudad.Add("Zerind");
            ciudad.Add(75);
            Arad.Add(ciudad);
            ciudad.Clear();

            ciudad.Add("Sibiu");
            ciudad.Add(140);
            Arad.Add(ciudad);
            ciudad.Clear();
            
            ciudad.Add("Timisoara");
            ciudad.Add(118);
            Arad.Add(ciudad);

            Arad[0] = "hola";

            ArrayList Zerind;
            Zerind = new ArrayList();
            Zerind.Add("Oradea");
            Zerind.Add(71);
            Zerind.Add("Arad");
            Zerind.Add(75);


            Nodo nodo = new Nodo();
            foreach (int value in nodo.posicion_actual){
                Console.Write("{0}, ", value);
            }
         





           
            Console.ReadKey();


        }
    }
}
