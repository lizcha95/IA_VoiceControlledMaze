namespace Gui.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class mainForm : Form
    {
        public mainForm()
        {
            this.InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonLoadAgents_Click(object sender, System.EventArgs e)
        {
            foreach (Logic.Classes.Agent agent in Logic.Utils.Xml.XmlReader.ReadAgents())
            {
                agentsGridView.Rows.Add(agent.ID, agent.Name, listToString(agent.ServiceCodes));
            }
        }

        private void buttonLoadOrders_Click(object sender, System.EventArgs e)
        {
            foreach (Logic.Classes.Order order in Logic.Utils.Xml.XmlReader.ReadOrders())
            {
                ordersGridView.Rows.Add(order.ID, order.Client, order.ServiceCode);
            }
        }

        private string listToString(List<string> list)
        {
            string servicesList = String.Join(",", list);
            return servicesList;
        }
    }
}
