namespace Logic.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Classes;

    public static class DataGenerator
    {
        private static Random random = new Random();
        private static NameGenerator nameGenerator = new NameGenerator(random);

        private static string RandomName
        {
            get
            {
                return nameGenerator.GenerateName(random.Next(Constants.Numbers.NAME_MINIMUM_LENGTH, Constants.Numbers.NAME_MAXIMUM_LENGTH + 1));
            }
        }

        public static IEnumerable<Agent> GenerateAgents(int quantity, List<Service> availableServices)
        {
            ServicesChooser servicesChooser = new ServicesChooser(random, availableServices);
            return Enumerable.Range(1, quantity).Select(i =>
            {
                Console.WriteLine(string.Format(Constants.Messages.GENERATING_AGENT, i));
                return new Agent(i, Faker.Name.FullName(), servicesChooser.ChooseServicesCodes());
            });
        }

        public static IEnumerable<Order> GenerateOrders(int quantity, List<Service> availableServices)
        {
            return Enumerable.Range(1, quantity).Select(i =>
            {
                Console.WriteLine(string.Format(Constants.Messages.GENERATING_ORDER, i));
                return new Order(i, Faker.Company.Name(), availableServices.ElementAt(random.Next(0, availableServices.Count)).Code);
            });
        }

        private class NameGenerator
        {
            private Random random;
            private HashSet<string> usedNames;
            private string[] consonants;
            private string[] vowels;
            private int consonantsLength;
            private int vowelsLength;

            public NameGenerator(Random random)
            {
                this.random = random;
                this.usedNames = new HashSet<string>();
                this.consonants = Constants.Objects.CONSONANTS;
                this.vowels = Constants.Objects.VOWELS;
                this.consonantsLength = this.consonants.Length;
                this.vowelsLength = this.vowels.Length;
            }

            public string GenerateName(int expectedNameLength)
            {
                string name;
                int currentNameLength;
                do
                {
                    name = string.Empty;
                    currentNameLength = 0;
                    while (currentNameLength < expectedNameLength)
                    {
                        name += this.consonants[this.random.Next(this.consonantsLength)] + this.vowels[this.random.Next(this.vowelsLength)];
                        currentNameLength += 2;
                    }
                }
                while (this.usedNames.Contains(name));
                this.usedNames.Add(name);
                return name.First().ToString().ToUpper() + name.Substring(1);
            }

           
        }

        private class ServicesChooser
        {
            private Random random;
            private List<Service> availableServices;
            private int availableServicesCount;

            public ServicesChooser(Random random, List<Service> availableServices)
            {
                this.random = random;
                this.availableServices = availableServices.ToList();
                this.availableServicesCount = this.availableServices.Count;
            }

            public IEnumerable<Service> ChooseServices()
            {
                HashSet<Service> choosedServices = new HashSet<Service>();
                int quantity = this.random.Next(1, this.availableServicesCount);
                IEnumerable<Service> servicesRange = this.availableServices.Where(service => !choosedServices.Contains(service));
                while (quantity-- > 0)
                    choosedServices.Add(servicesRange.ElementAt(this.random.Next(0, this.availableServicesCount - choosedServices.Count)));
                return choosedServices;
            }

            public IEnumerable<string> ChooseServicesCodes()
            {
                return ChooseServices().Select(service => service.Code);
            }
        }
    }
}
