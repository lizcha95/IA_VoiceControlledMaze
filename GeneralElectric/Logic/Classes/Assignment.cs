namespace Logic.Classes
{
    using System.Collections.Generic;
    using System.Linq;
    using Utils;

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

        public int Payment { get { return this.orders.Sum(order => order.Service.Payment); } }
        public bool Exceeded { get { return this.orders.Sum(order => order.Service.Hours) > Constants.Numbers.MAX_HOURS; } }
    }
}
