namespace Gui.Forms
{
    using System;
    using System.Collections;
    using System.Windows.Forms;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Drawing;
    using Logic;
    using Logic.Classes;
    using PagedList;
    using System.Collections.Generic;

    public partial class FormMain : Form
    {
        private int currentPageAgents = 0;
        private int currentSizeAgents = 10;

        private int currentPageOrders = 0;
        private int currentSizeOrders = 10;

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
            AgentsList = await GetPagedAgentsList();
            button_Previous_Agent.Enabled = AgentsList.HasPreviousPage;
            button_Next_Agent.Enabled = AgentsList.HasNextPage;
            agentsGridView.DataSource = AgentsList.ToList();
            labelPageNumberAgent.Text = string.Format("Page {0}/{1}", pageNumber, AgentsList.PageCount);

            /*labelPageNumberAgent.Text = string.Format("Page {0}/{1}", currentPageAgents, this.currentContext.Agents.Count());
            foreach (Agent agent in GetPage(this.currentContext.Agents, currentPageAgents, currentSizeAgents))
            {
                this.agentsGridView.Rows.Add(agent.ID, agent.Name, string.Join(", ", agent.ServicesCodes));   
                
            }*/

        }

        private async void buttonLoadOrders_Click(object sender, System.EventArgs e)
        {
           /* labelPageNumberOrders.Text = string.Format("Page {0}/{1}", currentPageOrders, this.currentContext.Orders.Count());
            foreach (Order order in GetPage(this.currentContext.Orders, currentPageOrders, currentSizeOrders))
            {
                this.ordersGridView.Rows.Add(order.ID, order.Client, string.Join(", ", order.Service.Code));
            }*/
             OrdersList = await GetPagedOrdersList();
             button_Previous_Order.Enabled = OrdersList.HasPreviousPage;
             button_Next_Order.Enabled = OrdersList.HasNextPage;
             ordersGridView.DataSource = OrdersList.ToList();
             labelPageNumberOrders.Text = string.Format("Page {0}/{1}", pageNumber, OrdersList.PageCount);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            agentsGridView.BorderStyle = BorderStyle.FixedSingle;
            agentsGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            agentsGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
           
            agentsGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            agentsGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            agentsGridView.BackgroundColor = Color.White;

            agentsGridView.EnableHeadersVisualStyles = false;
            agentsGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            agentsGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            agentsGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            ordersGridView.BorderStyle = BorderStyle.FixedSingle;
            ordersGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            ordersGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            ordersGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            ordersGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            ordersGridView.BackgroundColor = Color.White;

            ordersGridView.EnableHeadersVisualStyles = false;
            ordersGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            ordersGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            ordersGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


        }

        IEnumerable<object> GetPage(IEnumerable<object> input, int page, int pagesize)
        {
            return input.Skip(page * pagesize).Take(pagesize);
        }

        
        private async void button_Next_Agent_Click(object sender, EventArgs e)
        {

            /*currentPageAgents = ((currentPageAgents + 1) * currentSizeAgents) < this.currentContext.Agents.Count() ?
              (currentPageAgents + 1) : currentPageAgents;

            labelPageNumberAgent.Text = string.Format("Page {0}/{1}", currentPageAgents,this.currentContext.Agents.Count());
            foreach (Agent agent in GetPage(this.currentContext.Agents, currentPageAgents, currentSizeAgents))
            {
                this.agentsGridView.Rows.Add(agent.ID, agent.Name, string.Join(", ", agent.ServicesCodes));
               

            }*/

            if (AgentsList.HasNextPage)
              {
                  AgentsList = await GetPagedAgentsList(++pageNumber);
                  button_Previous_Agent.Enabled = AgentsList.HasPreviousPage;
                  button_Next_Agent.Enabled = AgentsList.HasNextPage;
                  agentsGridView.DataSource = AgentsList.ToList();
                  labelPageNumberAgent.Text = string.Format("Page {0}/{1}", pageNumber, AgentsList.PageCount);
              }
        }

        private async void button_Previous_Agent_Click(object sender, EventArgs e)
        {
            /*currentPageAgents = (currentPageAgents - currentSizeOrders) < 0 ? (currentPageAgents - 1) : 0;

            labelPageNumberAgent.Text = string.Format("Page {0}/{1}", currentPageAgents, this.currentContext.Agents.Count());
            foreach (Agent agent in GetPage(this.currentContext.Agents, currentPageAgents, currentSizeAgents))
            {
               this.agentsGridView.Rows.Add(agent.ID, agent.Name, string.Join(", ", agent.ServicesCodes));

            }*/

            if (AgentsList.HasPreviousPage)
            {
                AgentsList = await GetPagedAgentsList(--pageNumber);
                button_Previous_Agent.Enabled = AgentsList.HasPreviousPage;
                button_Next_Agent.Enabled = AgentsList.HasNextPage;
                agentsGridView.DataSource = AgentsList.ToList();
                labelPageNumberAgent.Text = string.Format("Page {0}/{1}", pageNumber, AgentsList.PageCount);
            }
        }
        private async void button_Previous_Order_Click(object sender, EventArgs e)
        {
            /*currentPageOrders = (currentPageOrders - currentSizeOrders) < 0 ? (currentPageOrders - 1) : 0;

            labelPageNumberOrders.Text = string.Format("Page {0}/{1}", currentPageOrders, this.currentContext.Orders.Count());
            foreach (Order order in GetPage(this.currentContext.Orders, currentPageOrders, currentSizeOrders))
            {
                this.ordersGridView.Rows.Add(order.ID, order.Client, string.Join(", ", order.Service.Code));
            }*/

            
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

            /*currentPageOrders = ((currentPageOrders + 1) * currentSizeOrders) < this.currentContext.Agents.Count() ?
              (currentPageOrders + 1) : currentPageOrders;

            labelPageNumberOrders.Text = string.Format("Page {0}/{1}", currentPageOrders, this.currentContext.Orders.Count());
            foreach (Order order in GetPage(this.currentContext.Orders, currentPageOrders, currentSizeOrders))
            {
                this.ordersGridView.Rows.Add(order.ID, order.Client, string.Join(", ", order.Service.Code));
            }*/
            if (OrdersList.HasNextPage)
             {

                 OrdersList = await GetPagedOrdersList(++pageNumber);
                 button_Previous_Order.Enabled = OrdersList.HasPreviousPage;
                 button_Next_Order.Enabled = OrdersList.HasNextPage;
                 ordersGridView.DataSource = OrdersList.ToList();
                 labelPageNumberOrders.Text = string.Format("Page {0}/{1}", pageNumber, OrdersList.PageCount);
             }
        }

        
    }
    
}
        
    

