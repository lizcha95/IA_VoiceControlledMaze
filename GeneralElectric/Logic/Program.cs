namespace Logic
{
    using System.Linq;
    using Utils;
    using Utils.Xml;

    public class Program
    {
        public static void Main(string[] args)
        {
            // Generate and save random agents.
            XmlWriter.WriteAgents(DataGenerator.GenerateAgents(Constants.Numbers.AGENTS_QUANTITY, XmlReader.ReadServices().ToList()));
        }
    }
}
