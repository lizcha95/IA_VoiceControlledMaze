namespace Logic.Classes
{
    using System.Collections.Generic;

    public class Assignment
    {
        private Agent agent;
        private List<Order> orders;

        public Assignment(Agent agent)
        {
            this.agent = agent;
            this.orders = new List<Order>();
        }

        public Agent Agent { get { return this.agent; } }
        public List<Order> Orders { get { return this.orders; } }
    }
}
