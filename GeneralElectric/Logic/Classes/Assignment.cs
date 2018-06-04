namespace Logic.Classes
{
    using System.Collections.Generic;
    using System.ComponentModel;
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
        
        [DisplayName("Agent Name")]
        public string AgentName { get { return this.agent.Name; } }
        [DisplayName("Payment")]
        public int Payment { get { return this.orders.Sum(order => order.Service.Payment); } }
        [DisplayName("Hours")]
        public int Hours { get { return this.orders.Sum(order => order.Service.Hours); } }
        [DisplayName("Assigned orders")]
        public string OrdersValue { get { return string.Join(", ", this.orders.Select(order => order.ID).OrderBy(id => id)) + "."; } }
        internal List<Order> Orders { get { return this.orders; } }
        internal Agent Agent { get { return this.agent; } }
        internal bool Exceeded { get { return this.Hours > Constants.Numbers.MAX_HOURS; } }
    }
}
