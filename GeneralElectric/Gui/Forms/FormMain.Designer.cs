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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.agentsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // agentsGridView
            // 
            this.agentsGridView.AllowUserToOrderColumns = true;
            this.agentsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.agentsGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.agentsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.agentsGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.agentsGridView.Location = new System.Drawing.Point(170, 112);
            this.agentsGridView.Margin = new System.Windows.Forms.Padding(2);
            this.agentsGridView.Name = "agentsGridView";
            this.agentsGridView.RowTemplate.Height = 30;
            this.agentsGridView.Size = new System.Drawing.Size(467, 437);
            this.agentsGridView.TabIndex = 0;
            this.agentsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // ordersGridView
            // 
            this.ordersGridView.AllowUserToOrderColumns = true;
            this.ordersGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ordersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ordersGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.ordersGridView.Location = new System.Drawing.Point(852, 112);
            this.ordersGridView.Margin = new System.Windows.Forms.Padding(2);
            this.ordersGridView.Name = "ordersGridView";
            this.ordersGridView.RowTemplate.Height = 28;
            this.ordersGridView.Size = new System.Drawing.Size(448, 426);
            this.ordersGridView.TabIndex = 1;
            // 
            // buttonLoadAgents
            // 
            this.buttonLoadAgents.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonLoadAgents.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLoadAgents.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadAgents.ForeColor = System.Drawing.Color.White;
            this.buttonLoadAgents.Location = new System.Drawing.Point(336, 655);
            this.buttonLoadAgents.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLoadAgents.Name = "buttonLoadAgents";
            this.buttonLoadAgents.Size = new System.Drawing.Size(113, 38);
            this.buttonLoadAgents.TabIndex = 2;
            this.buttonLoadAgents.Text = "Load Agents";
            this.buttonLoadAgents.UseVisualStyleBackColor = false;
            this.buttonLoadAgents.Click += new System.EventHandler(this.ButtonLoadAgents_Click);
            // 
            // buttonAssignOrders
            // 
            this.buttonAssignOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonAssignOrders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAssignOrders.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAssignOrders.ForeColor = System.Drawing.Color.White;
            this.buttonAssignOrders.Location = new System.Drawing.Point(680, 655);
            this.buttonAssignOrders.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAssignOrders.Name = "buttonAssignOrders";
            this.buttonAssignOrders.Size = new System.Drawing.Size(124, 38);
            this.buttonAssignOrders.TabIndex = 3;
            this.buttonAssignOrders.Text = "Assing Orders";
            this.buttonAssignOrders.UseVisualStyleBackColor = false;
            // 
            // buttonLoadOrders
            // 
            this.buttonLoadOrders.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonLoadOrders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLoadOrders.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadOrders.ForeColor = System.Drawing.Color.White;
            this.buttonLoadOrders.Location = new System.Drawing.Point(1027, 655);
            this.buttonLoadOrders.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLoadOrders.Name = "buttonLoadOrders";
            this.buttonLoadOrders.Size = new System.Drawing.Size(113, 38);
            this.buttonLoadOrders.TabIndex = 4;
            this.buttonLoadOrders.Text = "Load Orders";
            this.buttonLoadOrders.UseVisualStyleBackColor = false;
            this.buttonLoadOrders.Click += new System.EventHandler(this.buttonLoadOrders_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(170, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 44);
            this.label1.TabIndex = 5;
            this.label1.Text = "Agents";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(852, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(448, 44);
            this.label2.TabIndex = 6;
            this.label2.Text = "Orders";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 589);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 14);
            this.label3.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 24);
            this.button1.TabIndex = 0;
            // 
            // button_Previous_Agent
            // 
            this.button_Previous_Agent.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button_Previous_Agent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Previous_Agent.ForeColor = System.Drawing.Color.White;
            this.button_Previous_Agent.Location = new System.Drawing.Point(170, 566);
            this.button_Previous_Agent.Name = "button_Previous_Agent";
            this.button_Previous_Agent.Size = new System.Drawing.Size(87, 24);
            this.button_Previous_Agent.TabIndex = 14;
            this.button_Previous_Agent.Text = "Previous";
            this.button_Previous_Agent.UseVisualStyleBackColor = false;
            this.button_Previous_Agent.Click += new System.EventHandler(this.button_Previous_Agent_Click);
            // 
            // button_Next_Agent
            // 
            this.button_Next_Agent.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button_Next_Agent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Next_Agent.ForeColor = System.Drawing.Color.White;
            this.button_Next_Agent.Location = new System.Drawing.Point(550, 561);
            this.button_Next_Agent.Name = "button_Next_Agent";
            this.button_Next_Agent.Size = new System.Drawing.Size(87, 24);
            this.button_Next_Agent.TabIndex = 15;
            this.button_Next_Agent.Text = "Next";
            this.button_Next_Agent.UseVisualStyleBackColor = false;
            this.button_Next_Agent.Click += new System.EventHandler(this.button_Next_Agent_Click);
            // 
            // labelPageNumberAgent
            // 
            this.labelPageNumberAgent.AutoSize = true;
            this.labelPageNumberAgent.Location = new System.Drawing.Point(362, 566);
            this.labelPageNumberAgent.Name = "labelPageNumberAgent";
            this.labelPageNumberAgent.Size = new System.Drawing.Size(41, 14);
            this.labelPageNumberAgent.TabIndex = 16;
            this.labelPageNumberAgent.Text = "label4";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 24);
            this.button2.TabIndex = 0;
            // 
            // button_Previous_Order
            // 
            this.button_Previous_Order.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button_Previous_Order.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Previous_Order.ForeColor = System.Drawing.Color.White;
            this.button_Previous_Order.Location = new System.Drawing.Point(852, 554);
            this.button_Previous_Order.Name = "button_Previous_Order";
            this.button_Previous_Order.Size = new System.Drawing.Size(87, 28);
            this.button_Previous_Order.TabIndex = 17;
            this.button_Previous_Order.Text = "Previous";
            this.button_Previous_Order.UseVisualStyleBackColor = false;
            this.button_Previous_Order.Click += new System.EventHandler(this.button_Previous_Order_Click);
            // 
            // button_Next_Order
            // 
            this.button_Next_Order.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button_Next_Order.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Next_Order.ForeColor = System.Drawing.Color.White;
            this.button_Next_Order.Location = new System.Drawing.Point(1204, 552);
            this.button_Next_Order.Name = "button_Next_Order";
            this.button_Next_Order.Size = new System.Drawing.Size(92, 28);
            this.button_Next_Order.TabIndex = 18;
            this.button_Next_Order.Text = "Next";
            this.button_Next_Order.UseVisualStyleBackColor = false;
            this.button_Next_Order.Click += new System.EventHandler(this.button_Next_Order_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 24);
            this.label4.TabIndex = 0;
            // 
            // labelPageNumberOrders
            // 
            this.labelPageNumberOrders.AutoSize = true;
            this.labelPageNumberOrders.Location = new System.Drawing.Point(1070, 561);
            this.labelPageNumberOrders.Name = "labelPageNumberOrders";
            this.labelPageNumberOrders.Size = new System.Drawing.Size(41, 14);
            this.labelPageNumberOrders.TabIndex = 19;
            this.labelPageNumberOrders.Text = "label5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(617, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "General Electric Services";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 734);
            this.Controls.Add(this.label5);
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
            this.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        private System.Windows.Forms.Label label5;
    }
}

