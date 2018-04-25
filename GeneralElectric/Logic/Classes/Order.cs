namespace Logic.Classes
{
    public class Order
    {
        private int id;
        private string client;
        private string serviceCode;

        public Order(int id, string client, string serviceCode)
        {
            this.id = id;
            this.client = client;
            this.serviceCode = serviceCode;
        }

        public int ID { get { return this.id; } }
        public string Client { get { return this.client; } }
        public string ServiceCode { get { return this.serviceCode; } }
    }
}
