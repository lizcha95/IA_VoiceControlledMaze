namespace Logic.Classes
{
    using System.Collections.Generic;
    using System.Linq;

    public class Agent
    {
        private int id;
        private string name;
        private List<string> serviceCodes;

        public Agent(int id, string name, IEnumerable<string> serviceCodes)
        {
            this.id = id;
            this.name = name;
            this.serviceCodes = serviceCodes.ToList();
        }

        public int ID { get { return this.id; } }
        public string Name { get { return this.name; } }
        public List<string> ServiceCodes { get { return this.serviceCodes; } }
    }
}
