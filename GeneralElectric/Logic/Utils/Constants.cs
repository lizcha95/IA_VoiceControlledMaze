namespace Logic.Utils
{
    using System.IO;
    using System.Linq;

    public static class Constants
    {
        public static class Commands
        {
            public const string SWITCH = "switch";
            public const string AGENTS_LOAD = "load agents";
            public const string AGENTS_NEXT = "next agents";
            public const string AGENTS_PREVIOUS = "previous agents";
            public const string CLOSE = "close application";
            public const string DATA_LOAD = "load data";
            public const string DOWN = "down";
            public const string EXECUTE = "execute process";
            public const string LOWER = "lower";
            public const string ORDERS_LOAD = "load orders";
            public const string ORDERS_NEXT = "next orders";
            public const string ORDERS_PREVIOUS = "previous orders";
            public const string RESULT_NEXT = "next results";
            public const string RESULT_PREVIOUS = "previous results";
            public const string SILENCE = "silence";
            public const string STOP = "stop process";
            public const string UP = "up";
            public const string UPPER = "upper";

            public static readonly string[] COLLECTION = new string[] {
                SWITCH,
                AGENTS_LOAD,
                AGENTS_NEXT,
                AGENTS_PREVIOUS,
                CLOSE,
                DATA_LOAD,
                DOWN,
                EXECUTE,
                LOWER,
                ORDERS_LOAD,
                ORDERS_NEXT,
                ORDERS_PREVIOUS,
                RESULT_NEXT,
                RESULT_PREVIOUS,
                SILENCE,
                STOP,
                UP,
                UPPER
            };

            public const string RANGE_BASE = "Set generation limit to";
            public static readonly string[] RANGE_NUMBERS = Enumerable.Range(10, 1001).Select(number => number.ToString()).ToArray();
        }

        public static class Messages
        {
            public const string ASSIGN_FUNCTIONALITY = "In the assign window you can assign service orders to the service agents";
            public const string CANT_EXECUTE = "The process can't be executed right now, you need to load the data first";
            public const string LOAD_DATA = "Data loaded";
            public const string GOOD_BYE = "Thanks for using our service, good bye";
            public const string HINT_ASSIGN = "To assign service orders say " + Commands.EXECUTE;
            public const string HINT_LOAD_AGENTS = "To load agents' table say " + Commands.AGENTS_LOAD;
            public const string HINT_LOAD_DATA = "In the load data window you can load service agents and service orders";
            public const string HINT_LOAD_ORDERS = "To load orders' table say " + Commands.ORDERS_LOAD;
            public const string HINT_PAGE_AGENTS = "You can say " + Commands.AGENTS_NEXT + " or " + Commands.AGENTS_PREVIOUS + " to look all the agents in the table";
            public const string HINT_PAGE_ORDERS = "You can say " + Commands.ORDERS_NEXT + " or " + Commands.ORDERS_PREVIOUS + " to look all the orders in the table";
            public const string HINT_SWITCH = "To change the current tab say " + Commands.SWITCH;
            public const string LOAD_AGENTS_FIRST = "You have to load the agents first to do that";
            public const string LOAD_ORDERS_FIRST = "You have to load the orders first to do that";
            public const string LOW_CONFIDENCE = "Please speak louder, I don't understand what you say";
            public const string NO_NEXT_PAGE = "There's not {0} next page";
            public const string NO_PREVIOUS_PAGE = "There's not {0} previous page";
            public const string PROCESS_POSSIBLE_RESULT = "But I have found a result that may be useful, check it out";
            public const string PROCESS_RUN_FIRST = "You have to run the assignment process first";
            public const string PROCESS_STOP = "I have stopped the process";
            public const string PROCESS_WAIT = "Wait while the service assignment ends";
            public const string RESULT_FOUND = "I have found a result for the assignments";
            public const string WELCOME = "Hello, welcome to the General Electric Assign Service";
        }

        public static class Formats
        {
            public const string DIGIT = @"\d+";
            public const string GENERATION_LIMIT = "Generation limit: {0}";
            public const string PAGE_COUNT = "Page {0}/{1}";
        }

        public static class Numbers
        {
            public const int GENERATION_LIMIT = 10;
            public const int INITIAL_POPULATION = 100;
            public const int LOG_CHUNKS = 10;
            public const int NAME_MINIMUM_LENGTH = 10;
            public const int NAME_MAXIMUM_LENGTH = 15;
            public const int MAX_HOURS = 40;
            public const int PAGE_SIZE = 20;
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
            public const double CONFIDENCE = 0.70;
            public const double INDIVIDUALS_BEST = 0.95;
            public const double INDIVIDUALS_SWITCH = 0.5;
            public const double INDIVIDUALS_WORST = 0.05;
            public const double MUTATION = 0.05;
            public const double SELECTION_POINT = 0.5;
        }

        public static class Reports
        {
            public const string SPEECH_ERROR = "There's a problem with your speech recognition system";
            public const string CROSSING_COUPLE = "Crossing couple number: {0}, children: {1}";
            public const string CURRENT_GENERATION = "Evaluating generation number: {0}";
            public const string FINISHED = "Ready!";
            public const string FITNESS_GENERATION = "Obtaining the fitness value of each individual.";
            public const string FITNESS_BEST = "Obtaining the best individual of the generation.";
            public const string GENERATING_AGENT = "Generating agent number {0}.";
            public const string GENERATING_ORDER = "Generating order number {0}.";
            public const string GENETIC_CROSSOVER = "Applying crosses.";
            public const string GENETIC_INITIALIZE_POPULATION = "Generating initial population of individuals.";
            public const string GENETIC_MUTATION = "Applied mutations: {0}";
            public const string GENETIC_SELECTION = "Applying selection";
            public const string INDIVIDUAL_BEST_SURVIVES = "The current best individual survives.";
            public const string INDIVIDUAL_DOESNT_MEETS = "The individual is not good enough.";
            public const string INDIVIDUAL_GENERATION = "Generating individual for population number: {0}";
            public const string INDIVIDUAL_MEETS = "The individual meets the requirements.";
            public const string PROCESS_BEGIN = "The process has begun.";
            public const string PROCESS_END = "End of the process.";
            public const string PROCESS_STOP = "The process has been stopped.";
        }
    }
}
