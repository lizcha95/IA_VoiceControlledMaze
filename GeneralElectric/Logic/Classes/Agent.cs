namespace Logic.Classes
{
    using System.Collections.Generic;
    using System.Linq;

    public class Agent
    {
        private int id;
        private string name;
        private List<Service> services;
        private IEnumerable<string> servicesCodes;

        public Agent(int id, string name, IEnumerable<Service> services)
        {
            this.id = id;
            this.name = name;
            this.services = services.ToList();
            this.servicesCodes = services.Select(service => service.Code);
        }

        public int ID { get { return this.id; } }
        public string Name { get { return this.name; } }
        public List<Service> Services { get { return this.services; } }
        public IEnumerable<string> ServicesCodes { get { return this.servicesCodes; } }
    }
}
