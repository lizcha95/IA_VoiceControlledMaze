﻿namespace Logic.Utils.Xml
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Classes;

    public static class XmlWriter
    {
        public static void WriteAgents(List<Agent> agents)
        {
            new XDocument(
                new XElement("Agents",
                    from agent in agents
                    select new XElement("Agent",
                        new XElement("ID", agent.ID),
                        new XElement("Name", agent.Name),
                        new XElement("ServiceCodes", 
                            from serviceCode in agent.ServiceCodes
                            select new XElement("Code", serviceCode)
                        )
                    )
                )
            ).Save(Constants.Paths.AGENTS_FILE);
        }

        public static void WriteOrders(List<Order> orders)
        {
            new XDocument(
                new XElement("Orders",
                    from order in orders
                    select new XElement("Order",
                        new XElement("ID", order.ID),
                        new XElement("Client", order.Client),
                        new XElement("ServiceCode", order.ServiceCode)
                    )
                )
            ).Save(Constants.Paths.ORDERS_FILE);
        }
    }
}
