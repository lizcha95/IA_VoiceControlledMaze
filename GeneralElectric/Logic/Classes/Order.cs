namespace Logic.Classes
{
    public class Order
    {
        private int id;
        private string client;
        private Service service;

        public Order(int id, string client, Service service)
        {
            this.id = id;
            this.client = client;
            this.service = service;
        }

        public int ID { get { return this.id; } }
        public string Client { get { return this.client; } }
        public Service Service { get { return this.service; } }
    }
}
