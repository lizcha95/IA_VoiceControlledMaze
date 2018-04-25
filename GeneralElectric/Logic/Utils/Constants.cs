namespace Logic.Utils
{
    using System.IO;

    public static class Constants
    {
        public static class Paths
        {
            private static readonly string DATA_FOLDER = Path.Combine("..", "Data");
            public static readonly string SERVICES_FILE = Path.Combine(DATA_FOLDER, "Services.xml");
            public static readonly string AGENTS_FILE = Path.Combine(DATA_FOLDER, "Agents.xml");
            public static readonly string ORDERS_FILE = Path.Combine(DATA_FOLDER, "Orders.xml");
        }
    }
}
