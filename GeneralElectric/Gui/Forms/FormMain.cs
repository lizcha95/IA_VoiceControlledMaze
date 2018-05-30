namespace Gui.Forms
{
    using System;
    using System.Windows.Forms;
    using System.Threading.Tasks;
    using System.Linq;
    using Logic;
    using Logic.Classes;
    using PagedList;

    public partial class FormMain : Form
    {
        int pageNumber = 1;
        IPagedList<Agent> AgentsList;
        IPagedList<Order> OrdersList;
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


        public async Task<IPagedList<Agent>> GetPagedAgentsList(int pageNumber = 1, int pageSize = 12)
        {

            return await Task.Factory.StartNew(() =>
            {
                return this.currentContext.Agents.ToPagedList(pageNumber, pageSize);



                //return this.agentsGridView.Rows.Add(agent.ID, agent.Name, string.Join(", ", agent.ServicesCodes));

            });
        }


        public async Task<IPagedList<Order>> GetPagedOrdersList(int pageNumber = 1, int pageSize = 12){

              return await Task.Factory.StartNew(() =>
              {
                  return this.currentContext.Orders.ToPagedList(pageNumber,pageSize);

              });
          }

        private async void ButtonLoadAgents_Click(object sender, System.EventArgs e)
        {
            /* (Agent agent in this.currentContext.Agents)
            {
                this.agentsGridView.Rows.Add(agent.ID, agent.Name, string.Join(", ", agent.ServicesCodes));
            }*/

            AgentsList = await GetPagedAgentsList();
            button_Previous_Agent.Enabled = AgentsList.HasPreviousPage;
            button_Next_Agent.Enabled = AgentsList.HasNextPage;
            agentsGridView.DataSource = AgentsList.ToList();
            labelPageNumberAgent.Text = string.Format("Page {0}/{1}", pageNumber, AgentsList.PageCount);

        }

        private async void buttonLoadOrders_Click(object sender, System.EventArgs e)
        {
            /*foreach (Order order in this.currentContext.Orders)
            {
                ordersGridView.Rows.Add(order.ID, order.Client, order.Service.Code);
            }*/



            OrdersList = await GetPagedOrdersList();
            button_Previous_Order.Enabled = OrdersList.HasPreviousPage;
            button_Next_Order.Enabled = OrdersList.HasNextPage;
            ordersGridView.DataSource = OrdersList.ToList();
            labelPageNumberOrders.Text = string.Format("Page {0}/{1}", pageNumber, OrdersList.PageCount);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private async void button_Next_Agent_Click(object sender, EventArgs e)
        {

            if (AgentsList.HasNextPage)
            {
                AgentsList = await GetPagedAgentsList(++pageNumber);
                button_Previous_Agent.Enabled = AgentsList.HasPreviousPage;
                button_Next_Agent.Enabled = AgentsList.HasNextPage;
                agentsGridView.DataSource = AgentsList.ToList();
                labelPageNumberAgent.Text = string.Format("Page {0}/{1}", pageNumber, AgentsList.PageCount);
            }
        }

        private async void button_Previous_Order_Click(object sender, EventArgs e)
        {

            if (OrdersList.HasPreviousPage)
            {
                OrdersList = await GetPagedOrdersList(--pageNumber);
                button_Previous_Order.Enabled = OrdersList.HasPreviousPage;
                button_Next_Order.Enabled = OrdersList.HasNextPage;
                ordersGridView.DataSource = OrdersList.ToList();
                labelPageNumberOrders.Text = string.Format("Page {0}/{1}", pageNumber, OrdersList.PageCount);
            }

        }

        private async void button_Next_Order_Click(object sender, EventArgs e)
        {

            if (OrdersList.HasNextPage)
            {

                OrdersList = await GetPagedOrdersList(++pageNumber);
                button_Previous_Order.Enabled = OrdersList.HasPreviousPage;
                button_Next_Order.Enabled = OrdersList.HasNextPage;
                ordersGridView.DataSource = OrdersList.ToList();
                labelPageNumberOrders.Text = string.Format("Page {0}/{1}", pageNumber, OrdersList.PageCount);
            }
        }

        private async void button_Previous_Agent_Click(object sender, EventArgs e)
        {

            if (AgentsList.HasPreviousPage)
            {
                AgentsList = await GetPagedAgentsList(--pageNumber);
                button_Previous_Agent.Enabled = AgentsList.HasPreviousPage;
                button_Next_Agent.Enabled = AgentsList.HasNextPage;
                agentsGridView.DataSource = AgentsList.ToList();
                labelPageNumberAgent.Text = string.Format("Page {0}/{1}", pageNumber, AgentsList.PageCount);
            }
        }
    }
    
}
        
    

