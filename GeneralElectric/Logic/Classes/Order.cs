﻿namespace Logic.Classes
{
    using System.Collections.Generic;

    public class Order
    {
        private int id;
        private string client;
        private Service service;
        private static OrderComparer comparer = new OrderComparer();

        public Order(int id, string client, Service service)
        {
            this.id = id;
            this.client = client;
            this.service = service;
        }

        public int ID { get { return this.id; } }
        public string Client { get { return this.client; } }
        public Service Service { get { return this.service; } }

        public static OrderComparer Comparer { get { return comparer; } }

        public class OrderComparer : IEqualityComparer<Order>
        {
            public bool Equals(Order order1, Order order2)
            {
                return order1.ID == order2.ID;
            }

            public int GetHashCode(Order order)
            {
                return order.ID.GetHashCode();
            }
        }
    }
}
