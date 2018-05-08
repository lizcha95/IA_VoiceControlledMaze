namespace Gui.Forms
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.agentsGridView = new System.Windows.Forms.DataGridView();
            this.ordersGridView = new System.Windows.Forms.DataGridView();
            this.agentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviciosXagente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonLoadAgents = new System.Windows.Forms.Button();
            this.buttonAssignOrders = new System.Windows.Forms.Button();
            this.buttonLoadOrders = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.agentsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // agentsGridView
            // 
            this.agentsGridView.AllowUserToOrderColumns = true;
            this.agentsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.agentsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.agentId,
            this.agentName,
            this.serviciosXagente});
            this.agentsGridView.Location = new System.Drawing.Point(36, 69);
            this.agentsGridView.Name = "agentsGridView";
            this.agentsGridView.RowTemplate.Height = 28;
            this.agentsGridView.Size = new System.Drawing.Size(743, 820);
            this.agentsGridView.TabIndex = 0;
            this.agentsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ordersGridView
            // 
            this.ordersGridView.AllowUserToOrderColumns = true;
            this.ordersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderId,
            this.orderClient,
            this.orderCode});
            this.ordersGridView.Location = new System.Drawing.Point(823, 69);
            this.ordersGridView.Name = "ordersGridView";
            this.ordersGridView.RowTemplate.Height = 28;
            this.ordersGridView.Size = new System.Drawing.Size(743, 820);
            this.ordersGridView.TabIndex = 1;
            // 
            // agentId
            // 
            this.agentId.HeaderText = "ID";
            this.agentId.Name = "agentId";
            // 
            // agentName
            // 
            this.agentName.HeaderText = "Name";
            this.agentName.Name = "agentName";
            this.agentName.Width = 300;
            // 
            // serviciosXagente
            // 
            this.serviciosXagente.HeaderText = "Services";
            this.serviciosXagente.Name = "serviciosXagente";
            this.serviciosXagente.Width = 300;
            // 
            // orderId
            // 
            this.orderId.HeaderText = "ID";
            this.orderId.Name = "orderId";
            // 
            // orderClient
            // 
            this.orderClient.HeaderText = "Client";
            this.orderClient.Name = "orderClient";
            this.orderClient.Width = 300;
            // 
            // orderCode
            // 
            this.orderCode.HeaderText = "Code";
            this.orderCode.Name = "orderCode";
            this.orderCode.Width = 300;
            // 
            // buttonLoadAgents
            // 
            this.buttonLoadAgents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadAgents.Location = new System.Drawing.Point(347, 926);
            this.buttonLoadAgents.Name = "buttonLoadAgents";
            this.buttonLoadAgents.Size = new System.Drawing.Size(146, 55);
            this.buttonLoadAgents.TabIndex = 2;
            this.buttonLoadAgents.Text = "Load Agents";
            this.buttonLoadAgents.UseVisualStyleBackColor = true;
            // 
            // buttonAssignOrders
            // 
            this.buttonAssignOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAssignOrders.Location = new System.Drawing.Point(716, 926);
            this.buttonAssignOrders.Name = "buttonAssignOrders";
            this.buttonAssignOrders.Size = new System.Drawing.Size(159, 55);
            this.buttonAssignOrders.TabIndex = 3;
            this.buttonAssignOrders.Text = "Assing Orders";
            this.buttonAssignOrders.UseVisualStyleBackColor = true;
            // 
            // buttonLoadOrders
            // 
            this.buttonLoadOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadOrders.Location = new System.Drawing.Point(1159, 926);
            this.buttonLoadOrders.Name = "buttonLoadOrders";
            this.buttonLoadOrders.Size = new System.Drawing.Size(146, 55);
            this.buttonLoadOrders.TabIndex = 4;
            this.buttonLoadOrders.Text = "Load Orders";
            this.buttonLoadOrders.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(341, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "Agents";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1153, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 36);
            this.label2.TabIndex = 6;
            this.label2.Text = "Orders";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1603, 1009);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLoadOrders);
            this.Controls.Add(this.buttonAssignOrders);
            this.Controls.Add(this.buttonLoadAgents);
            this.Controls.Add(this.ordersGridView);
            this.Controls.Add(this.agentsGridView);
            this.Name = "mainForm";
            this.Text = "General Electric Services";
            ((System.ComponentModel.ISupportInitialize)(this.agentsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView agentsGridView;
        private System.Windows.Forms.DataGridView ordersGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn agentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn agentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviciosXagente;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderCode;
        private System.Windows.Forms.Button buttonLoadAgents;
        private System.Windows.Forms.Button buttonAssignOrders;
        private System.Windows.Forms.Button buttonLoadOrders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

