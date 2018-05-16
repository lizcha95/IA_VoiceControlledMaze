namespace Gui.Forms
{
    partial class FormMain
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
            this.agentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviciosXagente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordersGridView = new System.Windows.Forms.DataGridView();
            this.orderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonLoadAgents = new System.Windows.Forms.Button();
            this.buttonAssignOrders = new System.Windows.Forms.Button();
            this.buttonLoadOrders = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.button_first = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_next = new System.Windows.Forms.Button();
            this.button_last_page = new System.Windows.Forms.Button();
            this.button_previous = new System.Windows.Forms.Button();
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
            this.agentsGridView.Location = new System.Drawing.Point(53, 45);
            this.agentsGridView.Margin = new System.Windows.Forms.Padding(2);
            this.agentsGridView.Name = "agentsGridView";
            this.agentsGridView.RowTemplate.Height = 28;
            this.agentsGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.agentsGridView.Size = new System.Drawing.Size(563, 422);
            this.agentsGridView.TabIndex = 0;
            this.agentsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // agentId
            // 
            this.agentId.HeaderText = "ID";
            this.agentId.Name = "agentId";
            this.agentId.Width = 50;
            // 
            // agentName
            // 
            this.agentName.HeaderText = "Name";
            this.agentName.Name = "agentName";
            // 
            // serviciosXagente
            // 
            this.serviciosXagente.HeaderText = "Services";
            this.serviciosXagente.Name = "serviciosXagente";
            // 
            // ordersGridView
            // 
            this.ordersGridView.AllowUserToOrderColumns = true;
            this.ordersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderId,
            this.orderClient,
            this.orderCode});
            this.ordersGridView.Location = new System.Drawing.Point(773, 45);
            this.ordersGridView.Margin = new System.Windows.Forms.Padding(2);
            this.ordersGridView.Name = "ordersGridView";
            this.ordersGridView.RowTemplate.Height = 28;
            this.ordersGridView.Size = new System.Drawing.Size(667, 520);
            this.ordersGridView.TabIndex = 1;
            // 
            // orderId
            // 
            this.orderId.HeaderText = "ID";
            this.orderId.Name = "orderId";
            this.orderId.Width = 50;
            // 
            // orderClient
            // 
            this.orderClient.HeaderText = "Client";
            this.orderClient.Name = "orderClient";
            // 
            // orderCode
            // 
            this.orderCode.HeaderText = "Code";
            this.orderCode.Name = "orderCode";
            // 
            // buttonLoadAgents
            // 
            this.buttonLoadAgents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadAgents.Location = new System.Drawing.Point(303, 594);
            this.buttonLoadAgents.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLoadAgents.Name = "buttonLoadAgents";
            this.buttonLoadAgents.Size = new System.Drawing.Size(97, 36);
            this.buttonLoadAgents.TabIndex = 2;
            this.buttonLoadAgents.Text = "Load Agents";
            this.buttonLoadAgents.UseVisualStyleBackColor = true;
            this.buttonLoadAgents.Click += new System.EventHandler(this.ButtonLoadAgents_Click);
            // 
            // buttonAssignOrders
            // 
            this.buttonAssignOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAssignOrders.Location = new System.Drawing.Point(681, 594);
            this.buttonAssignOrders.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAssignOrders.Name = "buttonAssignOrders";
            this.buttonAssignOrders.Size = new System.Drawing.Size(106, 36);
            this.buttonAssignOrders.TabIndex = 3;
            this.buttonAssignOrders.Text = "Assing Orders";
            this.buttonAssignOrders.UseVisualStyleBackColor = true;
            // 
            // buttonLoadOrders
            // 
            this.buttonLoadOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadOrders.Location = new System.Drawing.Point(1099, 594);
            this.buttonLoadOrders.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLoadOrders.Name = "buttonLoadOrders";
            this.buttonLoadOrders.Size = new System.Drawing.Size(97, 36);
            this.buttonLoadOrders.TabIndex = 4;
            this.buttonLoadOrders.Text = "Load Orders";
            this.buttonLoadOrders.UseVisualStyleBackColor = true;
            this.buttonLoadOrders.Click += new System.EventHandler(this.buttonLoadOrders_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(323, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Agents";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1089, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Orders";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(155, 483);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(404, 20);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 490);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Go to Page:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button_first
            // 
            this.button_first.Location = new System.Drawing.Point(55, 524);
            this.button_first.Name = "button_first";
            this.button_first.Size = new System.Drawing.Size(75, 23);
            this.button_first.TabIndex = 9;
            this.button_first.Text = "First Page";
            this.button_first.UseVisualStyleBackColor = true;
            this.button_first.Click += new System.EventHandler(this.button_first_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(276, 526);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 11;
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(412, 523);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(75, 23);
            this.button_next.TabIndex = 12;
            this.button_next.Text = "Next Page";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // button_last_page
            // 
            this.button_last_page.Location = new System.Drawing.Point(510, 523);
            this.button_last_page.Name = "button_last_page";
            this.button_last_page.Size = new System.Drawing.Size(75, 23);
            this.button_last_page.TabIndex = 13;
            this.button_last_page.Text = "Last Page";
            this.button_last_page.UseVisualStyleBackColor = true;
            this.button_last_page.Click += new System.EventHandler(this.button_last_page_Click);
            // 
            // button_previous
            // 
            this.button_previous.Location = new System.Drawing.Point(155, 524);
            this.button_previous.Name = "button_previous";
            this.button_previous.Size = new System.Drawing.Size(103, 23);
            this.button_previous.TabIndex = 14;
            this.button_previous.Text = "Previous Page";
            this.button_previous.UseVisualStyleBackColor = true;
            this.button_previous.Click += new System.EventHandler(this.button_previous_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 646);
            this.Controls.Add(this.button_previous);
            this.Controls.Add(this.button_last_page);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_first);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLoadOrders);
            this.Controls.Add(this.buttonAssignOrders);
            this.Controls.Add(this.buttonLoadAgents);
            this.Controls.Add(this.ordersGridView);
            this.Controls.Add(this.agentsGridView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "General Electric Services";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.agentsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView agentsGridView;
        private System.Windows.Forms.DataGridView ordersGridView;
        private System.Windows.Forms.Button buttonLoadAgents;
        private System.Windows.Forms.Button buttonAssignOrders;
        private System.Windows.Forms.Button buttonLoadOrders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn agentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn agentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviciosXagente;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderCode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_first;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Button button_last_page;
        private System.Windows.Forms.Button button_previous;
    }
}

