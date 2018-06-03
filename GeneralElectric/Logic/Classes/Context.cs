namespace Logic.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Utils;
    using Utils.Xml;
    using PagedList;

    public class Context
    {
        private static Context current;

        private IEnumerable<Agent> agents;
        private IEnumerable<Order> orders;
        private IEnumerable<Service> services;

        private GeneticAllocator geneticAllocator; 

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

        public bool ResultAvailable { get { return this.geneticAllocator.BestIndividual != null; } }

        private void Initialize()
        {
            this.services = XmlReader.ReadServices();
            this.LoadAgents();
            this.LoadOrders();
        }

        public void LoadAgents()
        {
            this.agents = XmlReader.ReadAgents();
        }

        public void LoadOrders()
        {
            this.orders = XmlReader.ReadOrders(this.services);
        }

        public IPagedList<Agent> GetAgentsPage(int number = 1)
        {
            return this.agents.ToPagedList(number, Constants.Numbers.PAGE_SIZE);
        }

        public IPagedList<Order> GetOrdersPage(int number = 1)
        {
            return this.orders.ToPagedList(number, Constants.Numbers.PAGE_SIZE);
        }

        public IPagedList<Assignment> GetResultPage(int number = 1)
        {
            return this.geneticAllocator.BestIndividual.ToPagedList(number, Constants.Numbers.PAGE_SIZE);
        }

        public void CreateAllocator(
            ProgressChangedEventHandler progressChangedDelegate,
            RunWorkerCompletedEventHandler runWorkerCompletedDelegate,
            EventHandler<EventArgs> stoppedDelegate)
        {
            this.geneticAllocator = new GeneticAllocator(this.agents, this.services, this.orders);
            this.geneticAllocator.ProgressChanged += progressChangedDelegate;
            this.geneticAllocator.RunWorkerCompleted += runWorkerCompletedDelegate;
            this.geneticAllocator.Stopped += stoppedDelegate;
        }

        public void ExecuteAllocator(int generationLimit)
        {
            if (this.geneticAllocator != null)
                this.geneticAllocator.Execute(generationLimit);
        }
    }
}
