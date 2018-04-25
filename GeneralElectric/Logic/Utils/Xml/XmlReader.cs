namespace Logic.Utils.Xml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Classes;

    public static class XmlReader
    {
        public static IEnumerable<Service> ReadServices()
        {
            return from serviceElement in XDocument.Load(Constants.Paths.SERVICES_FILE).Root.Elements()
                   select new Service(
                        serviceElement.Element("Code").Value,
                        serviceElement.Element("Details").Value,
                        Convert.ToInt32(serviceElement.Element("Hours").Value),
                        Convert.ToInt32(serviceElement.Element("Payment").Value));
        }

        public static IEnumerable<Agent> ReadAgents()
        {
            return from agentElement in XDocument.Load(Constants.Paths.AGENTS_FILE).Root.Elements()
                   select new Agent(
                       Convert.ToInt32(agentElement.Element("ID").Value),
                       agentElement.Element("Name").Value,
                       from codeElement in agentElement.Element("ServiceCodes").Elements() select codeElement.Value);
        }

        public static IEnumerable<Order> ReadOrders()
        {
            return from orderElement in XDocument.Load(Constants.Paths.ORDERS_FILE).Root.Elements()
                   select new Order(
                       Convert.ToInt32(orderElement.Element("ID").Value),
                       orderElement.Element("Client").Value,
                       orderElement.Element("ServiceCode").Value);
        }
    }
}
