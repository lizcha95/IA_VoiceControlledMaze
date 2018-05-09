namespace Gui.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Linq;

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

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void button_Cargar(object sender, System.EventArgs e)
        {
            var services = Logic.Utils.Xml.XmlReader.ReadServices().ToList();

            // Generate and save random agents.
            Logic.Utils.Xml.XmlWriter.WriteAgents(Logic.Utils.DataGenerator.GenerateAgents(Logic.Utils.Constants.Numbers.AGENTS_QUANTITY, services));

            Console.WriteLine();

            // Generate and save random orders.
            Logic.Utils.Xml.XmlWriter.WriteOrders(Logic.Utils.DataGenerator.GenerateOrders(Logic.Utils.Constants.Numbers.ORDER_QUANTITY, services));
        }
    }
}
