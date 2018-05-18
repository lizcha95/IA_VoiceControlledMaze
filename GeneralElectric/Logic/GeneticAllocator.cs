namespace Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Classes;
    using Utils;

    public class GeneticAllocator
    {
        private IEnumerable<Agent> agents;
        private IEnumerable<Service> services;
        private IEnumerable<Order> orders;
        private IEnumerable<IGrouping<string, Order>> groupedOrders;
        private List<Tuple<IEnumerable<Assignment>, int>> ordered_population;
        private List<Tuple<IEnumerable<Assignment>, int>> best_individuals;
        private List<Tuple<IEnumerable<Assignment>, int>> worst_individuals;
        

      

        private int agentsCount;
        private int expectedPayment;
        private int selection_percentage;
        private float selection_percentage_best_individuals;
        private float selection_percentage_worst_individuals;

        private Random random;

        public GeneticAllocator(IEnumerable<Agent> agents, IEnumerable<Service> services, IEnumerable<Order> orders)
        {
            this.agents = agents;
            this.services = services;
            this.orders = orders;
            // Group the orders by service code.
            this.groupedOrders = orders.GroupBy(order => order.Service.Code);

            this.agentsCount = agents.Count();
            // Expected payment for each assignment.
            this.expectedPayment = orders.Sum(order => order.Service.Payment) / this.agentsCount;

            this.random = new Random();
        }

        public IEnumerable<Assignment> Execute()
        {
            return null;
        }

        /// <summary>
        /// Initializes a new population of individuals for the process.
        /// </summary>
        /// <returns>Yields randomly-generated individuals.</returns>
        private IEnumerable<IEnumerable<Assignment>> InitializePopulation()
        {
            for (int i = 0; i < Constants.Numbers.INITIAL_POPULATION; i++)
            {
                Console.WriteLine(string.Format(Constants.Messages.GENERATING_POPULATION_MEMBER, i + 1));
                yield return this.GenerateIndividual();
            }
        }

        /// <summary>
        /// Generates randomly a new individual using the total amount of existing <see cref="Order"/>s.
        /// </summary>
        /// <returns>A new randomly-generated individual.</returns>
        private List<Assignment> GenerateIndividual()
        {
            // Generate a base individual using the total amount of existing agents.
            List<Assignment> individual = this.agents.Select(agent => new Assignment(agent)).ToList();
            // Distribute orders for the individual in a random way.
            this.DistributeOrders(individual, this.groupedOrders);
            return individual;
        }

        /// <summary>
        /// Distributes <see cref="Order"/>s for an individual in an equitable and random way.
        /// </summary>
        /// <param name="individual">The individual to assign it <see cref="Order"/>s randomly.</param>
        /// <param name="groupedOrders">The orders to distribute grouped by <see cref="Service.Code"/>.</param>
        private void DistributeOrders(IEnumerable<Assignment> individual, IEnumerable<IGrouping<string, Order>> groupedOrders)
        {
            List<Order> ungroupedOrders;
            IEnumerable<Assignment> temporalAssignments;
            int ordersQuotient, ordersRemainder;
            // Iterate each orders group.
            foreach (var ordersGroup in groupedOrders)
            {
                // Select assignments of agents that can handle the current type of order ordering them by descending 
                // orders count and descending orders hours.
                temporalAssignments = individual
                    .Where(assignment => assignment.Agent.ServicesCodes.Contains(ordersGroup.Key))
                    .OrderByDescending(assignment => assignment.Orders.Count)
                    .ThenByDescending(assignment => assignment.Orders.Sum(order => order.Service.Hours));
                // Flatten the grouped orders.
                ungroupedOrders = ordersGroup.Select(group => group).ToList();
                // Calculate the amount of orders for each assign.
                ordersQuotient = ordersGroup.Count() / temporalAssignments.Count();
                // Calculate the remainder orders quantity.
                ordersRemainder = ordersGroup.Count() % temporalAssignments.Count();
                // Iterate the temporal assignments to add to its orders the calculated amount of orders randomly.
                foreach (Assignment assignment in temporalAssignments)
                    assignment.Orders.AddRange(ungroupedOrders.RandomPops(ordersQuotient + (ordersRemainder-- > 0 ? 1 : 0)));
            }
        }

        /// <summary>
        /// Calculates a fitness value for an individual.
        /// </summary>
        /// <param name="individual">The individual to analyze.</param>
        /// <returns>The fitness value of the analyzed individual.</returns>
        private int Evaluation(IEnumerable<Assignment> individual)
        {
            // Get the total payment of each assignment.
            var orderPayments = individual.Select(assignment => assignment.Orders.Sum(order => order.Service.Payment));
            // Get the quantity of exceeded-in-hours assignments.
            var exceedOrdersQuantity = individual
                .Where(assignment => assignment.Orders.Sum(order => order.Service.Hours) > Constants.Numbers.MAX_HOURS)
                .Count();
            // Calculate the fitness strongly penalizing the exceeded-in-hours assignments and softly penalizing differences in payments.
            return int.MaxValue 
                - int.MaxValue / this.agentsCount * exceedOrdersQuantity
                - orderPayments.Sum(orderPayment => Math.Abs(this.expectedPayment - orderPayment));
        }

        //Add the fitness to each individual
        public IEnumerable<Tuple<IEnumerable<Assignment>, int>> CalculateFitness(IEnumerable<IEnumerable<Assignment>> generation)
        {
            //Evaluate each individual and add the fitness
            return generation.Select(individual => new Tuple<IEnumerable<Assignment>, int>(individual, Evaluation(individual)));

        }

        public IEnumerable<IEnumerable<Assignment>> Selection(IEnumerable<Tuple<IEnumerable<Assignment>, int>> generation)
        {
            IEnumerable<IEnumerable<Assignment>> new_generation;
            //Sort the list by the greatest fitness
            ordered_population = generation.OrderBy(f => f.Item2).ToList(); 
            selection_percentage = ordered_population.Count() * (Constants.Numbers.SELECTION_PERCENTAGE);

            //Split the list in half according to the selection percentage
            best_individuals = ordered_population.GetRange(0, selection_percentage);
            worst_individuals = ordered_population.GetRange(selection_percentage, ordered_population.Count() - selection_percentage);

            //Percentage of selection of good and bad individuals
            selection_percentage_best_individuals = best_individuals.Count() * (Constants.Numbers.BEST_INDIVIDUALS_PERCENTAGE);
            selection_percentage_worst_individuals = worst_individuals.Count() * (Constants.Numbers.WORST_INDIVIDUALS_PERCENTAGE);

            best_individuals.RandomPops((int)selection_percentage_best_individuals);
            worst_individuals.RandomPops((int)selection_percentage_worst_individuals);

            //Add new individuals to create a new poblation
            new_generation = best_individuals.Select(best => best.Item1).Concat(worst_individuals.Select(worst => worst.Item1));
            return new_generation;
        }

        private IEnumerable<Assignment> Crossover(IEnumerable<Assignment> parent1, IEnumerable<Assignment> parent2)
        {
            // 50% chance to switch the individuals.
            if (this.random.Next(0, 2) == 1)
            {
                var temporalParent = parent1;
                parent1 = parent2;
                parent2 = temporalParent;
            }
            // Cross the parents in a simple way to obtain a child.
            var child = parent1.CrossWith(parent2, this.random.Next(this.agentsCount / 4 - 1, this.agentsCount / 4 * 3 - 1));
            // Select the child orders grouped by assignments.
            var childGroupedOrders = child.Select(assignment => assignment.Orders);
            // Get the IDs of repeatead orders of the child.
            var childRepeatedOrdersIDs = childGroupedOrders.SelectMany(order => order)
                .GroupBy(order => order.ID)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key);
            // Remove ALL the repeated orders of the child assignments.
            foreach (int id in childRepeatedOrdersIDs)
                Parallel.ForEach(childGroupedOrders, orderGroup => orderGroup.RemoveAll(order1 =>
                    orderGroup.Where(order2 => order2.ID == id).Contains(order1, Order.Comparer))
                );
            // Get the child missing orders grouped by service.
            var missingGroupedOrders = this.orders.Except(
                child.Select(assignment => assignment.Orders).SelectMany(order => order), 
                Order.Comparer
            ).GroupBy(order => order.Service.Code);
            // Distribute randomly the missing orders.
            this.DistributeOrders(child, missingGroupedOrders);
            return child;
        }        

        public void Mutation(IEnumerable<Assignment> individual)
        {

        }
    }
}
