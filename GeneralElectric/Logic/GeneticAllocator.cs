namespace Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using Classes;
    using Utils;

    public class GeneticAllocator
    {
        public IEnumerable<Assignment> InitializePopulation(IEnumerable<Agent> agents, IEnumerable<Order> orders)
        {
            List<Order> cloneOrders = orders.ToList();
            int ordersQuotient = cloneOrders.Count / agents.Count(),
                ordersRemainder = cloneOrders.Count % agents.Count();
            foreach (Agent agent in agents)
                yield return new Assignment(agent, cloneOrders.RandomPops(ordersQuotient + (ordersRemainder-- > 0 ? 1 : 0)));
        }
    }
}
