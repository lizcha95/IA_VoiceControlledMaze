namespace Logic.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Classes;

    public static class DataGenerator
    {
        private static Random random = new Random();

        public static List<Agent> GenerateAgents(int expectedQuantity, List<Service> availableServices)
        {
            List<Agent> agents = new List<Agent>();
            NameGenerator nameGenerator = new NameGenerator(random);
            ServicesChooser servicesChooser = new ServicesChooser(random, availableServices);
            int currentQuantity = 0;
            while (++currentQuantity <= expectedQuantity)
            {
                Console.WriteLine(string.Format("Generating agents number: {0}", currentQuantity));
                agents.Add(new Agent(
                    currentQuantity,
                    nameGenerator.GenerateName(random.Next(Constants.Numbers.NAME_MINIMUM_LENGTH, Constants.Numbers.NAME_MAXIMUM_LENGTH + 1)),
                    servicesChooser.ChooseServicesCodes())
                );
            }
            return agents;
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

            public ServicesChooser(Random random, IEnumerable<Service> availableServices)
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
