namespace Logic.Utils
{
    using System.IO;
    using System.Linq;

    public static class Constants
    {
        public static class Messages
        {
            public const string FINISHED = "Listo!";
            public const string GENERATING_AGENT = "Generando agente número {0}.";
            public const string GENERATING_ORDER = "Generando orden número {0}.";
            public const string GENERATING_POPULATION_MEMBER = "Generando elemento población número: {0}";
        }

        public static class Numbers
        {
            public const int INITIAL_POPULATION = 100;
            public const int NAME_MINIMUM_LENGTH = 10;
            public const int NAME_MAXIMUM_LENGTH = 15;
            public const int MAX_HOURS = 40;
            public const int QUANTITY_AGENTS = 2000;
            public const int QUANTITY_ORDERS = 8000;
            public const double AVERAGE_LIMIT = 10;
        }

        public static class Paths
        {
            private static readonly string DATA_FOLDER = Path.Combine(Path.Combine(Enumerable.Repeat("..", 3).ToArray()), "Data");
            public static readonly string SERVICES_FILE = Path.Combine(DATA_FOLDER, "Services.xml");
            public static readonly string AGENTS_FILE = Path.Combine(DATA_FOLDER, "Agents.xml");
            public static readonly string ORDERS_FILE = Path.Combine(DATA_FOLDER, "Orders.xml");
        }

        public static class Percents
        {

            public const double BEST_INDIVIDUALS = 0.95;
            public const double MUTATION = 0.05;
            public const double SELECTION = 0.5;
            public const double SWITCH_INDIVIDUALS = 0.5;
            public const double WORST_INDIVIDUALS = 0.05;
        }

        public static class Reports
        {
            public const string CURRENT_GENERATION = "Evaluando generación número: {0}";
            public const string FITNESS_GENERATION = "Obteniendo el valor fitness de cada individuo.";
            public const string FITNESS_BEST = "Obteniendo el mejor individuo de la generación.";
            public const string GENETIC_CROSSOVER = "Aplicando cruces.";
            public const string GENETIC_MUTATION = "Mutaciones aplicadas: {0}";
            public const string GENETIC_SELECTION = "Aplicando selección.";
            public const string INDIVIDUAL_DOESNT_MEETS = "El individuo no es lo suficientemente bueno.";
            public const string INDIVIDUAL_MEETS = "El individuo cumple con los requisitos.";
            public const string PROCESS_BEGIN = "El proceso ha comenzado.";
            public const string PROCESS_STOP = "El proceso ha sido detenido.";
        }
    }
}
