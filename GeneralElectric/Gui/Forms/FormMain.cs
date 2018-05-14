namespace Gui.Forms
{
    using System;
    using System.Windows.Forms;
    using System.Linq;
    using Logic.Classes;

    public partial class FormMain : Form
    {
        private Context currentContext;

        public FormMain()
        {
            this.InitializeComponent();

            this.currentContext = Context.Current;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ButtonLoadAgents_Click(object sender, System.EventArgs e)
        {
            foreach (Agent agent in this.currentContext.Agents)
            {
                this.agentsGridView.Rows.Add(agent.ID, agent.Name, string.Join(", ", agent.Services.Select(service => service.Code)));
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
