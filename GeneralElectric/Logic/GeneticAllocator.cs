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

        private int agentsCount;
        private int expectedPayment;

        private Random random;

        public GeneticAllocator(IEnumerable<Agent> agents, IEnumerable<Service> services, IEnumerable<Order> orders)
        {
            this.agents = agents;
            this.services = services;
            this.orders = orders;
            this.groupedOrders = orders.GroupBy(order => order.Service.Code);

            this.agentsCount = agents.Count();
            this.expectedPayment = orders.Sum(order => order.Service.Payment) / this.agentsCount;

            this.random = new Random();
        }

        public IEnumerable<Assignment> Execute()
        {
            return null;
        }

        private IEnumerable<IEnumerable<Assignment>> InitializePopulation()
        {
            for (int i = 0; i < Constants.Numbers.INITIAL_POPULATION; i++)
            {
                Console.WriteLine(string.Format(Constants.Messages.GENERATING_POPULATION_MEMBER, i + 1));
                yield return this.GenerateIndividual();
            }
        }

        public List<Assignment> GenerateIndividual()
        {
            List<Assignment> assignments = this.agents.Select(agent => new Assignment(agent)).ToList();
            List<Order> ungroupedOrders;
            IEnumerable<Assignment> temporalAssignments;
            int ordersQuotient, ordersRemainder;
            foreach (var groupedOrder in this.groupedOrders)
            {
                temporalAssignments = assignments
                    .Where(assignment => assignment.Agent.ServicesCodes.Contains(groupedOrder.Key))
                    .OrderByDescending(assignment => assignment.Orders.Count)
                    .ThenByDescending(assignment => assignment.Orders.Sum(order => order.Service.Hours));
                ungroupedOrders = groupedOrder.Select(group => group).ToList();
                ordersQuotient = groupedOrder.Count() / temporalAssignments.Count();
                ordersRemainder = groupedOrder.Count() % temporalAssignments.Count();
                foreach (Assignment assignment in temporalAssignments)
                    assignment.Orders.AddRange(ungroupedOrders.RandomPops(ordersQuotient + (ordersRemainder-- > 0 ? 1 : 0)));
            }
            return assignments;
        }

        private int Evaluation(IEnumerable<Assignment> assignments)
        {
            var orderPayments = assignments.Select(assignment => assignment.Orders.Sum(order => order.Service.Payment));
            var exceedOrdersQuantity = assignments
                .Where(assignment => assignment.Orders.Sum(order => order.Service.Hours) > Constants.Numbers.MAX_HOURS)
                .Count();
            return int.MaxValue 
                - int.MaxValue / this.agentsCount * exceedOrdersQuantity
                - orderPayments.Sum(orderPayment => Math.Abs(this.expectedPayment - orderPayment));
        }

        public void Selection()
        {

        }

        public IEnumerable<Assignment> Crossover(IEnumerable<Assignment> individual1, IEnumerable<Assignment> individual2)
        {
            // 50% chance to switch the individuals.
            if (this.random.Next(0, 2) == 1)
            {
                var temporalIndividual = individual1;
                individual1 = individual2;
                individual2 = temporalIndividual;
            }
            int crossingPoint = this.random.Next(this.agentsCount / 4 - 1, this.agentsCount / 4 * 3 - 1);
            List<Assignment> listIndividual1 = individual1.ToList(),
                listIndividual2 = individual2.ToList(),
                listNewIndividual = listIndividual1.GetRange(0, crossingPoint)
                    .Concat(listIndividual2.GetRange(crossingPoint, listIndividual2.Count - crossingPoint))
                    .ToList();

            return listNewIndividual;
        }

        public void Mutation(IEnumerable<Assignment> individual)
        {

        }
    }
}
