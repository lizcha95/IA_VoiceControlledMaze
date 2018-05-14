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
        }

        public static class Numbers
        {
            public const int AGENTS_QUANTITY = 2000;
            public const int ORDER_QUANTITY = 8000;
            public const int NAME_MINIMUM_LENGTH = 10;
            public const int NAME_MAXIMUM_LENGTH = 15;
        }

        public static class Paths
        {
            private static readonly string DATA_FOLDER = Path.Combine(Path.Combine(Enumerable.Repeat("..", 3).ToArray()), "Data");
            public static readonly string SERVICES_FILE = Path.Combine(DATA_FOLDER, "Services.xml");
            public static readonly string AGENTS_FILE = Path.Combine(DATA_FOLDER, "Agents.xml");
            public static readonly string ORDERS_FILE = Path.Combine(DATA_FOLDER, "Orders.xml");
        }
    }
}
