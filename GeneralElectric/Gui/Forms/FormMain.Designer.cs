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
            this.ordersGridView = new System.Windows.Forms.DataGridView();
            this.buttonLoadAgents = new System.Windows.Forms.Button();
            this.buttonAssignOrders = new System.Windows.Forms.Button();
            this.buttonLoadOrders = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_Previous_Agent = new System.Windows.Forms.Button();
            this.button_Next_Agent = new System.Windows.Forms.Button();
            this.labelPageNumberAgent = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button_Previous_Order = new System.Windows.Forms.Button();
            this.button_Next_Order = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelPageNumberOrders = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.agentsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // agentsGridView
            // 
            this.agentsGridView.AllowUserToOrderColumns = true;
            this.agentsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.agentsGridView.Location = new System.Drawing.Point(146, 78);
            this.agentsGridView.Margin = new System.Windows.Forms.Padding(2);
            this.agentsGridView.Name = "agentsGridView";
            this.agentsGridView.RowTemplate.Height = 28;
            this.agentsGridView.Size = new System.Drawing.Size(400, 406);
            this.agentsGridView.TabIndex = 0;
            this.agentsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // ordersGridView
            // 
            this.ordersGridView.AllowUserToOrderColumns = true;
            this.ordersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersGridView.Location = new System.Drawing.Point(811, 78);
            this.ordersGridView.Margin = new System.Windows.Forms.Padding(2);
            this.ordersGridView.Name = "ordersGridView";
            this.ordersGridView.RowTemplate.Height = 28;
            this.ordersGridView.Size = new System.Drawing.Size(384, 406);
            this.ordersGridView.TabIndex = 1;
            // 
            // buttonLoadAgents
            // 
            this.buttonLoadAgents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadAgents.Location = new System.Drawing.Point(291, 630);
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
            this.buttonLoadOrders.Location = new System.Drawing.Point(980, 630);
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
            this.label2.Location = new System.Drawing.Point(975, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Orders";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 547);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // button_Previous_Agent
            // 
            this.button_Previous_Agent.Location = new System.Drawing.Point(160, 505);
            this.button_Previous_Agent.Name = "button_Previous_Agent";
            this.button_Previous_Agent.Size = new System.Drawing.Size(75, 23);
            this.button_Previous_Agent.TabIndex = 14;
            this.button_Previous_Agent.Text = "Previous";
            this.button_Previous_Agent.UseVisualStyleBackColor = true;
            this.button_Previous_Agent.Click += new System.EventHandler(this.button_Previous_Agent_Click);
            // 
            // button_Next_Agent
            // 
            this.button_Next_Agent.Location = new System.Drawing.Point(453, 505);
            this.button_Next_Agent.Name = "button_Next_Agent";
            this.button_Next_Agent.Size = new System.Drawing.Size(75, 23);
            this.button_Next_Agent.TabIndex = 15;
            this.button_Next_Agent.Text = "Next";
            this.button_Next_Agent.UseVisualStyleBackColor = true;
            this.button_Next_Agent.Click += new System.EventHandler(this.button_Next_Agent_Click);
            // 
            // labelPageNumberAgent
            // 
            this.labelPageNumberAgent.AutoSize = true;
            this.labelPageNumberAgent.Location = new System.Drawing.Point(325, 515);
            this.labelPageNumberAgent.Name = "labelPageNumberAgent";
            this.labelPageNumberAgent.Size = new System.Drawing.Size(35, 13);
            this.labelPageNumberAgent.TabIndex = 16;
            this.labelPageNumberAgent.Text = "label4";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            // 
            // button_Previous_Order
            // 
            this.button_Previous_Order.Location = new System.Drawing.Point(811, 503);
            this.button_Previous_Order.Name = "button_Previous_Order";
            this.button_Previous_Order.Size = new System.Drawing.Size(75, 26);
            this.button_Previous_Order.TabIndex = 17;
            this.button_Previous_Order.Text = "Previous";
            this.button_Previous_Order.UseVisualStyleBackColor = true;
            this.button_Previous_Order.Click += new System.EventHandler(this.button_Previous_Order_Click);
            // 
            // button_Next_Order
            // 
            this.button_Next_Order.Location = new System.Drawing.Point(1116, 502);
            this.button_Next_Order.Name = "button_Next_Order";
            this.button_Next_Order.Size = new System.Drawing.Size(79, 26);
            this.button_Next_Order.TabIndex = 18;
            this.button_Next_Order.Text = "Next";
            this.button_Next_Order.UseVisualStyleBackColor = true;
            this.button_Next_Order.Click += new System.EventHandler(this.button_Next_Order_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 0;
            // 
            // labelPageNumberOrders
            // 
            this.labelPageNumberOrders.AutoSize = true;
            this.labelPageNumberOrders.Location = new System.Drawing.Point(992, 510);
            this.labelPageNumberOrders.Name = "labelPageNumberOrders";
            this.labelPageNumberOrders.Size = new System.Drawing.Size(35, 13);
            this.labelPageNumberOrders.TabIndex = 19;
            this.labelPageNumberOrders.Text = "label5";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 709);
            this.Controls.Add(this.labelPageNumberOrders);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_Next_Order);
            this.Controls.Add(this.button_Previous_Order);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.labelPageNumberAgent);
            this.Controls.Add(this.button_Next_Agent);
            this.Controls.Add(this.button_Previous_Agent);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
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
        private System.Windows.Forms.Label label3;
    
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_Previous_Agent;
        private System.Windows.Forms.Button button_Next_Agent;
        private System.Windows.Forms.Label labelPageNumberAgent;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_Previous_Order;
        private System.Windows.Forms.Button button_Next_Order;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelPageNumberOrders;
    }
}

