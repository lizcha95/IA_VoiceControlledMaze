namespace Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Classes;
    using Utils;

    public class GeneticAllocator
    {
        private IEnumerable<Agent> agents;
        private IEnumerable<Service> services;
        private IEnumerable<Order> orders;
        private IEnumerable<IGrouping<string, Order>> groupedOrders;

        public GeneticAllocator(IEnumerable<Agent> agents, IEnumerable<Service> services, IEnumerable<Order> orders)
        {
            this.agents = agents;
            this.services = services;
            this.orders = orders;
            this.groupedOrders = orders.GroupBy(order => order.Service.Code);
        }

        public IEnumerable<IEnumerable<Assignment>> InitializePopulation()
        {
            for (int i = 0; i < Constants.Numbers.INITIAL_POPULATION; i++)
            {
                Console.WriteLine(string.Format(Constants.Messages.GENERATING_POPULATION_MEMBER, i + 1));
                yield return this.GeneratePopulationMember();
            }
        }

        public List<Assignment> GeneratePopulationMember()
        {
            List<Assignment> assignments = this.agents.Select(agent => new Assignment(agent)).ToList();
            List<Order> ungroupedOrders;
            IEnumerable<Assignment> temporalAssignments;
            int ordersQuotient, ordersRemainder;
            foreach (var groupedOrder in this.groupedOrders)
            {
                temporalAssignments = assignments
                    .Where(assignment => assignment.Agent.ServicesCodes.Contains(groupedOrder.Key))
                    .OrderByDescending(assignment => assignment.Orders.Count);
                ungroupedOrders = groupedOrder.Select(group => group).ToList();
                ordersQuotient = groupedOrder.Count() / temporalAssignments.Count();
                ordersRemainder = groupedOrder.Count() % temporalAssignments.Count();
                foreach (Assignment assignment in temporalAssignments)
                    assignment.Orders.AddRange(ungroupedOrders.RandomPops(ordersQuotient + (ordersRemainder-- > 0 ? 1 : 0)));
            }
            return assignments;
        }

        public bool Evaluation(IEnumerable<Assignment> assignments)
        {
            var orderSums = assignments.Select(assignment => assignment.Orders.Sum(order => order.Service.Payment));
            double paymentAverage = orderSums.Average();
            return !assignments.Where(assignment => assignment.Orders.Sum(order => order.Service.Hours) > Constants.Numbers.MAX_HOURS).Any()
                && orderSums.Min() >= paymentAverage - Constants.Numbers.AVERAGE_LIMIT 
                && paymentAverage + Constants.Numbers.AVERAGE_LIMIT >= orderSums.Max();
        }

        public void Selection()
        {

        }

        public void Crossover()
        {

        }

        public void Mutation()
        {

        }
    }
}
