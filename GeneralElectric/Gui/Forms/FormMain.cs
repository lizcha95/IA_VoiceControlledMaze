namespace Gui.Forms
{
    using System;
    using System.Windows.Forms;
    using System.Linq;
    using Logic;
    using Logic.Classes;

    public partial class FormMain : Form
    {
        private Context currentContext;
        private GeneticAllocator geneticAllocator;

        public FormMain()
        {
            this.InitializeComponent();

            this.currentContext = Context.Current;
            this.geneticAllocator = new GeneticAllocator(
                this.currentContext.Agents,
                this.currentContext.Services,
                this.currentContext.Orders
            );
            this.geneticAllocator.Execute(10);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ButtonLoadAgents_Click(object sender, System.EventArgs e)
        {
            foreach (Agent agent in this.currentContext.Agents)
            {
                this.agentsGridView.Rows.Add(agent.ID, agent.Name, string.Join(", ", agent.ServicesCodes));
            }
        }

        private void buttonLoadOrders_Click(object sender, System.EventArgs e)
        {
            foreach (Order order in this.currentContext.Orders)
            {
                ordersGridView.Rows.Add(order.ID, order.Client, order.Service.Code);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
