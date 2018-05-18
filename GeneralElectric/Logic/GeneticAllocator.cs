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

        private int agentsCount;
        private int expectedPayment;
        private int selection_percentage;
        private float selection_percentage_best_individuals;
        private float selection_percentage_worst_individuals;


        private IEnumerable<IGrouping<string, Order>> groupedOrders;
        private IEnumerable<Tuple<IEnumerable<Assignment>, int>> fitness_generation;
        private List<Tuple<IEnumerable<Assignment>, int>> ordered_population;
        private List<Tuple<IEnumerable<Assignment>, int>> best_individuals;
        private List<Tuple<IEnumerable<Assignment>, int>> worst_individuals;
        private IEnumerable<IEnumerable<Assignment>> new_generation;

        public GeneticAllocator(IEnumerable<Agent> agents, IEnumerable<Service> services, IEnumerable<Order> orders)
        {
            this.agents = agents;
            this.services = services;
            this.orders = orders;

            this.agentsCount = agents.Count();
            this.expectedPayment = orders.Sum(order => order.Service.Payment) / this.agentsCount;
            this.groupedOrders = orders.GroupBy(order => order.Service.Code);
        }

        private IEnumerable<IEnumerable<Assignment>> InitializePopulation()
        {
            for (int i = 0; i < Constants.Numbers.INITIAL_POPULATION; i++)
            {
                Console.WriteLine(string.Format(Constants.Messages.GENERATING_POPULATION_MEMBER, i + 1));
                yield return this.GeneratePopulationMember();
            }
        }

        private List<Assignment> GeneratePopulationMember()
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

        //Add the fitness to each individual
        public IEnumerable<Tuple<IEnumerable<Assignment>, int>> CalculateFitness(IEnumerable<IEnumerable<Assignment>> generation)
        {
           return generation.Select(individual => new Tuple<IEnumerable<Assignment>, int>(individual, Evaluation(individual)));
           
        }
    
        public IEnumerable<IEnumerable<Assignment>> Selection(IEnumerable<Tuple<IEnumerable<Assignment>, int>> generation)
        {
            ordered_population = generation.OrderBy(f => f.Item2).ToList(); //Sort the list by the greatest fitness
            selection_percentage = ordered_population.Count() * (Constants.Numbers.SELECTION_PERCENTAGE);

            //Split the list in half according to the percentage of selection
            best_individuals = ordered_population.GetRange(0,selection_percentage);
            worst_individuals = ordered_population.GetRange(selection_percentage, ordered_population.Count()-selection_percentage);

            //Percentage of selection of good and bad individuals
            selection_percentage_best_individuals = best_individuals.Count() * (Constants.Numbers.BEST_INDIVIDUALS_PERCENTAGE);
            selection_percentage_worst_individuals = worst_individuals.Count() * (Constants.Numbers.WORST_INDIVIDUALS_PERCENTAGE);

            best_individuals.RandomPops((int)selection_percentage_best_individuals);
            worst_individuals.RandomPops((int)selection_percentage_worst_individuals);

            //Add new individuals
            foreach (Tuple<IEnumerable<Assignment>, int> best in best_individuals)
            {
                new_generation.ToList().Add(best.Item1);
            }

            foreach (Tuple<IEnumerable<Assignment>, int> worst in worst_individuals)
            {
                new_generation.ToList().Add(worst.Item1);
            }
            return new_generation;
        }

        public void Crossover()
        {

        }

        public void Mutation()
        {


        }
    }
}
