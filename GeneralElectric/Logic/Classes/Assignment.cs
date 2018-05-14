namespace Logic.Classes
{
    using System.Collections.Generic;

    public class Assignment
    {
        private Agent agent;
        private List<Order> orders;

        public Assignment(Agent agent, List<Order> orders)
        {
            this.agent = agent;
            this.orders = orders;
        }

        public Agent Agent { get { return this.agent; } }
        public List<Order> Orders { get { return this.orders; } }
    }
}
