namespace Logic.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Classes;

    public static class DataGenerator
    {
        private static Random random = new Random();

        public static IEnumerable<Agent> GenerateAgents(int quantity, List<Service> availableServices)
        {
            return Enumerable.Range(1, quantity).Select(i =>
            {
                Console.WriteLine(string.Format(Constants.Messages.GENERATING_AGENT, i));
                return new Agent(i, Faker.Name.FullName(), availableServices.RandomElements());
            });
        }

        public static IEnumerable<Order> GenerateOrders(int quantity, List<Service> availableServices)
        {
            return Enumerable.Range(1, quantity).Select(i =>
            {
                Console.WriteLine(string.Format(Constants.Messages.GENERATING_ORDER, i));
                return new Order(i, Faker.Company.Name(), availableServices.ElementAt(random.Next(0, availableServices.Count)));
            });
        }
    }
}
