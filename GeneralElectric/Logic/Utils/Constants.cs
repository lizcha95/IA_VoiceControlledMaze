namespace Logic.Utils
{
    using System.IO;
    using System.Linq;

    public static class Constants
    {
        public static class Messages
        {
            public const string FINISHED = "Ready!";
            public const string GENERATING_AGENT = "Generating agent number {0}.";
            public const string GENERATING_ORDER = "Generating order number {0}.";
        }

        public static class Numbers
        {
            public const int INITIAL_POPULATION = 100;
            public const int NAME_MINIMUM_LENGTH = 10;
            public const int NAME_MAXIMUM_LENGTH = 15;
            public const int MAX_HOURS = 40;
            public const int QUANTITY_AGENTS = 100;
            public const int QUANTITY_ORDERS = 400;
            public const double AVERAGE_LIMIT = 10;
        }

        public static class Paths
        {
            private static readonly string DATA_FOLDER = Path.Combine(Path.Combine(Enumerable.Repeat("..", 3).ToArray()), "Data");
            public static readonly string SERVICES_FILE = Path.Combine(DATA_FOLDER, "Services.xml");
            public static readonly string AGENTS_FILE = Path.Combine(DATA_FOLDER, "Agents.xml");
            public static readonly string ORDERS_FILE = Path.Combine(DATA_FOLDER, "Orders.xml");
            public static readonly string PROBABILITIES_FILE = Path.Combine(DATA_FOLDER, "Probabilities.xml");
        }

        public static class Percents
        {
            public const double INDIVIDUALS_BEST = 0.95;
            public const double INDIVIDUALS_SWITCH = 0.5;
            public const double INDIVIDUALS_WORST = 0.05;
            public const double MUTATION = 0.05;
            public const double SELECTION_POINT = 0.5;
        }

        public static class Reports
        {
            public const string CROSSING_COUPLE = "Crossing couple number: {0}, children: {1}";
            public const string CURRENT_GENERATION = "Evaluating number generation: {0}";
            public const string FITNESS_GENERATION = "Obtaining the fitness value of each individual.";
            public const string FITNESS_BEST = "Obtaining the best individual of the generation.";
            public const string GENETIC_CROSSOVER = "Applying crosses.";
            public const string GENETIC_INITIALIZE_POPULATION = "Generating initial population of individuals.";
            public const string GENETIC_MUTATION = "Applied mutations: {0}";
            public const string GENETIC_SELECTION = "Applying selection";
            public const string INDIVIDUAL_DOESNT_MEETS = "The individual is not good enough.";
            public const string INDIVIDUAL_GENERATION = "Generating individual from population number: {0}";
            public const string INDIVIDUAL_MEETS = "The individual meets the requirements.";
            public const string PROCESS_BEGIN = "The process has begun.";
            public const string PROCESS_END = "End of the process.";
            public const string PROCESS_STOP = "The process has been stopped.";
        }
    }
}
