namespace Gui.Forms
{
    using System;
    using System.Windows.Forms;
    using System.Linq;
    using Logic.Classes;
    using System.Drawing;

    public partial class FormMain : Form
    {
        private Context currentContext;
        private int currentPage = 0;
        private int currentSize = 10;
 

        public FormMain()
        {
            this.InitializeComponent();

            this.currentContext = Context.Current;
        }

        private void PagingAgents(int pagenum, int pagesize)
        {

            if (currentPage < 0) { currentPage = 0; return; }

            flowLayoutPanel1.Controls.OfType<Label>().Where(e => e.Tag.ToString() != (pagenum + 1).ToString())
                .ToList().ForEach((element) =>
                {
                    element.ForeColor = Color.Black;
                });

            /*flowLayoutPanel1.Controls.OfType<Label>().Where(e => e.Tag.ToString() == (pagenum + 1).ToString())
                .First().ForeColor = Color.Red;*/

            textBox1.Text = "Page " + (pagenum + 1) + " of " + (int)(this.currentContext.Agents.Count()/ pagesize);

           


            /*foreach (Agent agent in this.currentContext.Agents)
            {
                this.agentsGridView.Rows.Add(agent.ID, agent.Name, string.Join(", ", agent.ServicesCodes));
            }*/
           

        }

     

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ButtonLoadAgents_Click(object sender, System.EventArgs e)
        {
         
            PagingAgents(currentPage, currentSize);
            
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        

        private void button_first_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            PagingAgents(currentPage, currentSize);
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            currentPage = ((currentPage + 1) * currentSize) < this.currentContext.Agents.Count() ?
               (currentPage + 1) : currentPage;
            PagingAgents(currentPage, currentSize);

        }

        private void button_last_page_Click(object sender, EventArgs e)
        {
            currentPage = (this.currentContext.Agents.Count() / currentSize) - 1;
            PagingAgents(currentPage, currentSize);
        }

        private void button_previous_Click(object sender, EventArgs e)
        {

            currentPage = (currentPage - currentSize) < 0 ? (currentPage - 1) : 0;
            PagingAgents(currentPage, currentSize);

        }
    }
}
