namespace Gui.Forms
{
    using System;
    using System.ComponentModel;
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

        private int pageNumber = 1;

        private IPagedList<Agent> AgentsList;
        private IPagedList<Order> OrdersList;

        private Context currentContext;
        private GeneticAllocator geneticAllocator;

        private int generationLimit;

        public FormMain()
        {
            this.InitializeComponent();

            this.currentContext = Context.Current;
            this.geneticAllocator = new GeneticAllocator(
                this.currentContext.Agents,
                this.currentContext.Services,
                this.currentContext.Orders
            );
            this.geneticAllocator.ProgressChanged += this.GeneticAllocator_ProgressChanged;
            this.geneticAllocator.RunWorkerCompleted += this.GeneticAllocator_RunWorkerCompleted;
            this.geneticAllocator.Stopped += this.GeneticAllocator_Stopped;

            this.generationLimit = 10; // Hay que poner una opción para modificar esto.
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.gridViewAgents.BorderStyle = BorderStyle.FixedSingle;
            this.gridViewAgents.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            this.gridViewAgents.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            this.gridViewAgents.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            this.gridViewAgents.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            this.gridViewAgents.BackgroundColor = Color.White;

            this.gridViewAgents.EnableHeadersVisualStyles = false;
            this.gridViewAgents.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.gridViewAgents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            this.gridViewAgents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            this.gridViewOrders.BorderStyle = BorderStyle.FixedSingle;
            this.gridViewOrders.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            this.gridViewOrders.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            this.gridViewOrders.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            this.gridViewOrders.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            this.gridViewOrders.BackgroundColor = Color.White;

            this.gridViewOrders.EnableHeadersVisualStyles = false;
            this.gridViewOrders.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.gridViewOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            this.gridViewOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            this.gridViewResults.BorderStyle = BorderStyle.FixedSingle;
            this.gridViewResults.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            this.gridViewResults.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            this.gridViewResults.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            this.gridViewResults.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            this.gridViewResults.BackgroundColor = Color.White;

            this.gridViewResults.EnableHeadersVisualStyles = false;
            this.gridViewResults.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.gridViewResults.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            this.gridViewResults.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void GeneticAllocator_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.listBoxLog.Invoke(new Action(() =>
            {
                this.listBoxLog.Items.Add(e.UserState);
                this.listBoxLog.TopIndex = this.listBoxLog.Items.Count - 1;
            }));
        }

        private void GeneticAllocator_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Esto se ejecuta cuando el algoritmo genético terminó. Falta imprimir los resultados.
        }

        private void GeneticAllocator_Stopped(object sender, EventArgs e)
        {
            // Esto se ejecuta cuando se cancela el proceso.
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
            this.buttonPreviousAgent.Enabled = AgentsList.HasPreviousPage;
            this.buttonNextAgent.Enabled = AgentsList.HasNextPage;
            this.gridViewAgents.DataSource = AgentsList.ToList();
            this.labelPageNumberAgent.Text = string.Format("Page {0}/{1}", pageNumber, AgentsList.PageCount);

            /*this.labelPageNumberAgent.Text = string.Format("Page {0}/{1}", currentPageAgents, this.currentContext.Agents.Count());
            foreach (Agent agent in GetPage(this.currentContext.Agents, currentPageAgents, currentSizeAgents))
            {
                this.agentsGridView.Rows.Add(agent.ID, agent.Name, string.Join(", ", agent.ServicesCodes));   
                
            }*/

        }

        private async void buttonLoadOrders_Click(object sender, System.EventArgs e)
        {
           /* this.labelPageNumberOrders.Text = string.Format("Page {0}/{1}", currentPageOrders, this.currentContext.Orders.Count());
            foreach (Order order in GetPage(this.currentContext.Orders, currentPageOrders, currentSizeOrders))
            {
                this.ordersGridView.Rows.Add(order.ID, order.Client, string.Join(", ", order.Service.Code));
            }*/
             OrdersList = await GetPagedOrdersList();
             this.buttonPreviousOrder.Enabled = OrdersList.HasPreviousPage;
             this.buttonNextOrder.Enabled = OrdersList.HasNextPage;
             this.gridViewOrders.DataSource = OrdersList.ToList();
             this.labelPageNumberOrders.Text = string.Format("Page {0}/{1}", pageNumber, OrdersList.PageCount);
        }        

        IEnumerable<object> GetPage(IEnumerable<object> input, int page, int pagesize)
        {
            return input.Skip(page * pagesize).Take(pagesize);
        }

        
        private async void ButtonNextAgent_Click(object sender, EventArgs e)
        {

            /*currentPageAgents = ((currentPageAgents + 1) * currentSizeAgents) < this.currentContext.Agents.Count() ?
              (currentPageAgents + 1) : currentPageAgents;

            this.labelPageNumberAgent.Text = string.Format("Page {0}/{1}", currentPageAgents,this.currentContext.Agents.Count());
            foreach (Agent agent in GetPage(this.currentContext.Agents, currentPageAgents, currentSizeAgents))
            {
                this.agentsGridView.Rows.Add(agent.ID, agent.Name, string.Join(", ", agent.ServicesCodes));
               

            }*/

            if (AgentsList.HasNextPage)
              {
                  AgentsList = await GetPagedAgentsList(++pageNumber);
                  this.buttonPreviousAgent.Enabled = AgentsList.HasPreviousPage;
                  this.buttonNextAgent.Enabled = AgentsList.HasNextPage;
                  this.gridViewAgents.DataSource = AgentsList.ToList();
                  this.labelPageNumberAgent.Text = string.Format("Page {0}/{1}", pageNumber, AgentsList.PageCount);
              }
        }

        private async void ButtonPreviousAgent_Click(object sender, EventArgs e)
        {
            /*currentPageAgents = (currentPageAgents - currentSizeOrders) < 0 ? (currentPageAgents - 1) : 0;

            this.labelPageNumberAgent.Text = string.Format("Page {0}/{1}", currentPageAgents, this.currentContext.Agents.Count());
            foreach (Agent agent in GetPage(this.currentContext.Agents, currentPageAgents, currentSizeAgents))
            {
               this.agentsGridView.Rows.Add(agent.ID, agent.Name, string.Join(", ", agent.ServicesCodes));

            }*/

            if (AgentsList.HasPreviousPage)
            {
                AgentsList = await GetPagedAgentsList(--pageNumber);
                this.buttonPreviousAgent.Enabled = AgentsList.HasPreviousPage;
                this.buttonNextAgent.Enabled = AgentsList.HasNextPage;
                this.gridViewAgents.DataSource = AgentsList.ToList();
                this.labelPageNumberAgent.Text = string.Format("Page {0}/{1}", pageNumber, AgentsList.PageCount);
            }
        }
        private async void ButtonPreviousOrder_Click(object sender, EventArgs e)
        {
            /*currentPageOrders = (currentPageOrders - currentSizeOrders) < 0 ? (currentPageOrders - 1) : 0;

            this.labelPageNumberOrders.Text = string.Format("Page {0}/{1}", currentPageOrders, this.currentContext.Orders.Count());
            foreach (Order order in GetPage(this.currentContext.Orders, currentPageOrders, currentSizeOrders))
            {
                this.ordersGridView.Rows.Add(order.ID, order.Client, string.Join(", ", order.Service.Code));
            }*/

            
            if (OrdersList.HasPreviousPage)
            {
                OrdersList = await GetPagedOrdersList(--pageNumber);
                this.buttonPreviousOrder.Enabled = OrdersList.HasPreviousPage;
                this.buttonNextOrder.Enabled = OrdersList.HasNextPage;
                this.gridViewOrders.DataSource = OrdersList.ToList();
                this.labelPageNumberOrders.Text = string.Format("Page {0}/{1}", pageNumber, OrdersList.PageCount);
            }

        }

        private async void ButtonNextOrder_Click(object sender, EventArgs e)
        {

            /*currentPageOrders = ((currentPageOrders + 1) * currentSizeOrders) < this.currentContext.Agents.Count() ?
              (currentPageOrders + 1) : currentPageOrders;

            this.labelPageNumberOrders.Text = string.Format("Page {0}/{1}", currentPageOrders, this.currentContext.Orders.Count());
            foreach (Order order in GetPage(this.currentContext.Orders, currentPageOrders, currentSizeOrders))
            {
                this.ordersGridView.Rows.Add(order.ID, order.Client, string.Join(", ", order.Service.Code));
            }*/
            if (OrdersList.HasNextPage)
             {

                 OrdersList = await GetPagedOrdersList(++pageNumber);
                 this.buttonPreviousOrder.Enabled = OrdersList.HasPreviousPage;
                 this.buttonNextOrder.Enabled = OrdersList.HasNextPage;
                 this.gridViewOrders.DataSource = OrdersList.ToList();
                 this.labelPageNumberOrders.Text = string.Format("Page {0}/{1}", pageNumber, OrdersList.PageCount);
             }
        }

        private void ButtonAssignOrders_Click(object sender, EventArgs e)
        {
            this.geneticAllocator.Execute(this.generationLimit);
        }

        
    }
    
}
        
    

