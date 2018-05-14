namespace Logic.Utils.Xml
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Classes;

    internal static class XmlWriter
    {
        public static void WriteAgents(IEnumerable<Agent> agents)
        {
            new XDocument(
                new XElement("Agents",
                    from agent in agents
                    select new XElement("Agent",
                        new XElement("ID", agent.ID),
                        new XElement("Name", agent.Name),
                        new XElement("ServiceCodes", 
                            from serviceCode in agent.Services.Select(service => service.Code)
                            select new XElement("Code", serviceCode)
                        )
                    )
                )
            ).Save(Constants.Paths.AGENTS_FILE);
        }

        public static void WriteOrders(IEnumerable<Order> orders)
        {
            new XDocument(
                new XElement("Orders",
                    from order in orders
                    select new XElement("Order",
                        new XElement("ID", order.ID),
                        new XElement("Client", order.Client),
                        new XElement("ServiceCode", order.Service.Code)
                    )
                )
            ).Save(Constants.Paths.ORDERS_FILE);
        }
    }
}
