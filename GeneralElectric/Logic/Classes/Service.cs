namespace Logic.Classes
{
    public class Service
    {
        private string code;
        private string details;
        private int hours;
        private int payment;

        public Service(string code, string details, int hours, int payment)
        {
            this.code = code;
            this.details = details;
            this.hours = hours;
            this.payment = payment;
        }

        public string Code { get { return this.code; } }
        public string Details { get { return this.details; } }
        public int Hours { get { return this.hours; } }
        public int Payment { get { return this.payment; } }
    }
}
