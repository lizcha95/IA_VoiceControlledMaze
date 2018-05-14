namespace Logic.Classes
{
    using System.Collections.Generic;
    using Utils.Xml;

    public class Context
    {
        private static Context current;

        private IEnumerable<Agent> agents;
        private IEnumerable<Service> services;
        private IEnumerable<Order> orders;

        private Context()
        {
            this.Initialize();
        }

        public static Context Current
        {
            get
            {
                if (current == null)
                    current = new Context();
                return current;
            }
        }

        private void Initialize()
        {
            this.agents = XmlReader.ReadAgents();
            this.services = XmlReader.ReadServices();
            this.orders = XmlReader.ReadOrders(this.services);
        }

        public IEnumerable<Agent> Agents { get { return this.agents; } }
        public IEnumerable<Service> Services { get { return this.services; } }
        public IEnumerable<Order> Orders { get { return this.orders; } }
    }
}
