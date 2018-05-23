namespace Logic
{
    using System;
    using System.Linq;
    using Utils;
    using Utils.Xml;

    public class Program
    {
        public static void Main(string[] args)
        {
            var services = XmlReader.ReadServices().ToList();

            // Generate and save random agents.
            XmlWriter.WriteAgents(DataGenerator.GenerateAgents(Constants.Numbers.QUANTITY_AGENTS, services));

            Console.WriteLine();

            // Generate and save random orders.
            XmlWriter.WriteOrders(DataGenerator.GenerateOrders(Constants.Numbers.QUANTITY_ORDERS, services));

            Console.WriteLine("\n\n" + Constants.Messages.FINISHED);
            Console.ReadKey();
        }
    }
}
