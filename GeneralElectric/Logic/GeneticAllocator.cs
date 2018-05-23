﻿namespace Logic
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Classes;
    using Utils;
    using Individual = System.Collections.Generic.IEnumerable<Classes.Assignment>; // An alias for the Individual.

    public class GeneticAllocator : BackgroundWorker
    {
        private IEnumerable<Agent> agents;
        private IEnumerable<Service> services;
        private IEnumerable<Order> orders;
        private IEnumerable<IGrouping<string, Order>> groupedOrders;
        
        private Individual bestIndividual;
        private IEnumerable<Individual> currentPopulation;

        private int agentsCount;
        private int expectedPayment;
        private int minExpectedFitness;
        private int generationLimit;

        private Random random;

        private Thread workerThread;

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
            // The expected minimum fitness for the best individual.
            this.minExpectedFitness = int.MaxValue - int.MaxValue / this.agentsCount;

            this.random = new Random();

            this.WorkerReportsProgress = true;
        }

        public Individual BestIndividual { get { return this.bestIndividual; } }

        /// <summary>
        /// Executes the async process.
        /// </summary>
        /// <param name="generationLimit">A generation limit for the genetic process.</param>
        public void Execute(int generationLimit)
        {
            this.generationLimit = generationLimit;
            this.ReportProgress(0, Constants.Reports.PROCESS_BEGIN);
            this.RunWorkerAsync();
        }

        /// <summary>
        /// Stops the async process and sets the current best individual.
        /// </summary>
        public void Stop()
        {
            if (this.IsBusy)
            {
                if (this.workerThread != null)
                {
                    this.workerThread.Abort();
                    this.workerThread = null;
                    this.ReportProgress(0, Constants.Reports.PROCESS_STOP);
                }
            }
        }

        /// <summary>
        /// The async and genetic process core.
        /// </summary>
        /// <param name="e">Event args.</param>
        protected override void OnDoWork(DoWorkEventArgs e)
        {
            base.OnDoWork(e);
            this.workerThread = Thread.CurrentThread;

            this.currentPopulation = this.InitializePopulation();
            int generationCount = 0;
            // Default stop condition.
            while (++generationCount <= this.generationLimit && this.currentPopulation.Count() > 1)
            {
                this.ReportProgress(1, string.Format(Constants.Reports.CURRENT_GENERATION, generationCount));
                var populationFitness = this.LinkFitness();
                var bestCurrentIndividualFitness = this.BestByFitness(populationFitness);
                this.bestIndividual = bestCurrentIndividualFitness.Item1; // Best individual of each generation.
                // Evaluation.
                if (bestCurrentIndividualFitness.Item2 >= this.minExpectedFitness)
                {
                    this.ReportProgress(3, Constants.Reports.INDIVIDUAL_MEETS);
                    break; // Found result.
                }
                else
                    this.ReportProgress(3, Constants.Reports.INDIVIDUAL_DOESNT_MEETS);

                // Selection and crossover.
                this.currentPopulation = this.CrossPopulation(this.Selection(populationFitness));
                // Mutation with probability.
                int mutationCount = this.currentPopulation.Sum(individual =>
                {
                    if (this.random.NextDouble() < Constants.Percents.MUTATION)
                    {
                        this.Mutation(individual);
                        return 1;
                    }
                    return 0;
                });
                this.ReportProgress(2, string.Format(Constants.Reports.GENETIC_MUTATION, mutationCount));
                this.ReportProgress(0, string.Empty);
            }
        }

        /// <summary>
        /// Raises the <see cref="BackgroundWorker.ProgressChanged"/> event with provided data.
        /// </summary>
        /// <param name="level">The level from where the message is sent.</param>
        /// <param name="message">The message to send.</param>
        private void ReportProgress(int level, string message)
        {
            this.OnProgressChanged(new ProgressChangedEventArgs(0, Enumerable.Repeat("    ", level) + message));
        }

        /// <summary>
        /// Initializes a new population of individuals for the process.
        /// </summary>
        /// <returns>Yields randomly-generated individuals.</returns>
        private IEnumerable<Individual> InitializePopulation()
        {
            for (int i = 0; i < Constants.Numbers.INITIAL_POPULATION; i++)
            {
                Console.WriteLine(string.Format(Constants.Messages.GENERATING_POPULATION_MEMBER, i + 1));
                yield return this.GenerateIndividual();
            }
        }

        /// <summary>
        /// Calculates a fitness value for an individual.
        /// </summary>
        /// <param name="individual">The individual to analyze.</param>
        /// <returns>The fitness value of the analyzed individual.</returns>
        private int Evaluation(Individual individual)
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

        public IEnumerable<IEnumerable<Assignment>> Selection(IEnumerable<Tuple<IEnumerable<Assignment>, int>> generation)
        {
            int selection_percentage;
            double selection_percentage_best_individuals;
            double selection_percentage_worst_individuals;
            IEnumerable<IEnumerable<Assignment>> new_generation;

            List<Tuple<IEnumerable<Assignment>, int>> ordered_population;
            List<Tuple<IEnumerable<Assignment>, int>> best_individuals;
            List<Tuple<IEnumerable<Assignment>, int>> worst_individuals;

            //Sort the list by the greatest fitness
            ordered_population = generation.OrderBy(f => f.Item2).ToList(); 
            selection_percentage = (int)(ordered_population.Count() * (Constants.Percents.SELECTION));

            //Split the list in half according to the selection percentage
            best_individuals = ordered_population.GetRange(0, selection_percentage);
            worst_individuals = ordered_population.GetRange(selection_percentage, ordered_population.Count() - selection_percentage);

            //Percentage of selection of good and bad individuals
            selection_percentage_best_individuals = best_individuals.Count() * (Constants.Percents.BEST_INDIVIDUALS);
            selection_percentage_worst_individuals = worst_individuals.Count() * (Constants.Percents.WORST_INDIVIDUALS);

            best_individuals.RandomPops((int)selection_percentage_best_individuals);
            worst_individuals.RandomPops((int)selection_percentage_worst_individuals);

            //Add new individuals to create a new poblation
            new_generation = best_individuals.Select(best => best.Item1).Concat(worst_individuals.Select(worst => worst.Item1));
            return new_generation;
        }

        /// <summary>
        /// Cross two individuals to get a new child.
        /// </summary>
        /// <param name="parent1">The individual parent 1.</param>
        /// <param name="parent2">The individual parent 2.</param>
        /// <returns>A new child result of the crossing process.</returns>
        private Individual Crossover(Individual parent1, Individual parent2)
        {
            // 50% chance to switch the individuals.
            if (this.random.NextDouble() < Constants.Percents.SWITCH_INDIVIDUALS)
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

        /// <summary>
        /// Mutates an individual reassigning orders with a randomly selected service code.
        /// </summary>
        /// <param name="individual">The individual to mutate.</param>
        private void Mutation(Individual individual)
        {
            // Select a random service code.
            string selectedService = this.services.RandomElement().Code;
            // Remove All the orders of the individual that corresponds with the selected service code.
            Parallel.ForEach(individual.Select(assignment => assignment.Orders), orderGroup =>
                orderGroup.RemoveAll(order => order.Service.Code == selectedService)
            );
            // Distribute randomly the removed orders.
            this.DistributeOrders(individual, this.groupedOrders.Where(groupedOrder => groupedOrder.Key == selectedService));
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
        private void DistributeOrders(Individual individual, IEnumerable<IGrouping<string, Order>> groupedOrders)
        {
            List<Order> ungroupedOrders;
            Individual temporalAssignments;
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
        /// Bounds the current population individuals with its fitness value.
        /// </summary>
        /// <returns>A population of current individuals linked to its fitness value.</returns>
        private IEnumerable<Tuple<Individual, int>> LinkFitness()
        {
            this.ReportProgress(2, Constants.Reports.FITNESS_GENERATION);
            return this.currentPopulation.Select(individual => Tuple.Create(individual, this.Evaluation(individual)));
        }

        /// <summary>
        /// Orders the provided population fitness and selects its best individual.
        /// </summary>
        /// <returns>The best individual of the population fitness.</returns>
        private Tuple<Individual, int> BestByFitness(IEnumerable<Tuple<Individual, int>> populationFitness)
        {
            this.ReportProgress(3, Constants.Reports.FITNESS_BEST);
            populationFitness = populationFitness.OrderBy(individualFitness => individualFitness.Item2); // Order by the fitness value and set.
            return populationFitness
                .Take(1) // Select TOP 1.
                .Single(); // Convert from collection to single element.
        }

        /// <summary>
        /// Cross the individual of the given population randomly.
        /// </summary>
        /// <param name="population">The population to cross its individuals.</param>
        /// <returns>A new population result of the crossing process.</returns>
        private IEnumerable<Individual> CrossPopulation(IEnumerable<Individual> population)
        {
            this.ReportProgress(2, Constants.Reports.GENETIC_CROSSOVER);
            var listPopulation = population.ToList();
            while (listPopulation.Count >= 2)
                yield return this.Crossover(listPopulation.RandomPop(), listPopulation.RandomPop());
        }
    }
}
