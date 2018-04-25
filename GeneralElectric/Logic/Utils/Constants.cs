namespace Logic.Utils
{
    using System.IO;

    public static class Constants
    {
        public static class Paths
        {
            private static readonly string DATA_FOLDER = Path.Combine("..", "..", "..", "Data");
            public static readonly string SERVICES_FILE = Path.Combine(DATA_FOLDER, "Services.xml");
            public static readonly string AGENTS_FILE = Path.Combine(DATA_FOLDER, "Agents.xml");
            public static readonly string ORDERS_FILE = Path.Combine(DATA_FOLDER, "Orders.xml");
        }

        public static class Numbers
        {
            public const int AGENTS_QUANTITY = 2000;
            public const int NAME_MINIMUM_LENGTH = 10;
            public const int NAME_MAXIMUM_LENGTH = 15;
        }

        public static class Objects
        {
            public static readonly string[] CONSONANTS = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            public static readonly string[] VOWELS = { "a", "e", "i", "o", "u", "ae", "y" };
        }
    }
}
