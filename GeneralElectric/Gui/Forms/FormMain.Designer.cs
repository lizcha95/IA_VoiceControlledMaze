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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.agentsGridView = new System.Windows.Forms.DataGridView();
            this.ordersGridView = new System.Windows.Forms.DataGridView();
            this.buttonLoadAgents = new System.Windows.Forms.Button();
            this.buttonLoadOrders = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Previous_Agent = new System.Windows.Forms.Button();
            this.button_Next_Agent = new System.Windows.Forms.Button();
            this.labelPageNumberAgent = new System.Windows.Forms.Label();
            this.button_Previous_Order = new System.Windows.Forms.Button();
            this.button_Next_Order = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelPageNumberOrders = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.LoadData = new System.Windows.Forms.TabPage();
            this.AssignOrders = new System.Windows.Forms.TabPage();
            this.labelNumberPageAssign = new System.Windows.Forms.Label();
            this.buttonNextAssign = new System.Windows.Forms.Button();
            this.buttonPreviousAssign = new System.Windows.Forms.Button();
            this.buttonAssign = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridAssignOrders = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.agentsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersGridView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.LoadData.SuspendLayout();
            this.AssignOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAssignOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 24);
            this.button1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 24);
            this.button2.TabIndex = 0;
            // 
            // agentsGridView
            // 
            this.agentsGridView.AllowUserToOrderColumns = true;
            this.agentsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.agentsGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.agentsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.agentsGridView.DefaultCellStyle = dataGridViewCellStyle7;
            this.agentsGridView.Location = new System.Drawing.Point(34, 111);
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
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ordersGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.ordersGridView.Location = new System.Drawing.Point(716, 111);
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
            this.buttonLoadAgents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadAgents.ForeColor = System.Drawing.Color.White;
            this.buttonLoadAgents.Location = new System.Drawing.Point(202, 654);
            this.buttonLoadAgents.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLoadAgents.Name = "buttonLoadAgents";
            this.buttonLoadAgents.Size = new System.Drawing.Size(120, 30);
            this.buttonLoadAgents.TabIndex = 2;
            this.buttonLoadAgents.Text = "Load Agents";
            this.buttonLoadAgents.UseVisualStyleBackColor = false;
            this.buttonLoadAgents.Click += new System.EventHandler(this.ButtonLoadAgents_Click);
            // 
            // buttonLoadOrders
            // 
            this.buttonLoadOrders.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonLoadOrders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLoadOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadOrders.ForeColor = System.Drawing.Color.White;
            this.buttonLoadOrders.Location = new System.Drawing.Point(881, 654);
            this.buttonLoadOrders.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLoadOrders.Name = "buttonLoadOrders";
            this.buttonLoadOrders.Size = new System.Drawing.Size(120, 30);
            this.buttonLoadOrders.TabIndex = 4;
            this.buttonLoadOrders.Text = "Load Orders";
            this.buttonLoadOrders.UseVisualStyleBackColor = false;
            this.buttonLoadOrders.Click += new System.EventHandler(this.buttonLoadOrders_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(34, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 44);
            this.label1.TabIndex = 5;
            this.label1.Text = "Agents";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(716, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(448, 44);
            this.label2.TabIndex = 6;
            this.label2.Text = "Orders";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 588);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 22);
            this.label3.TabIndex = 9;
            // 
            // button_Previous_Agent
            // 
            this.button_Previous_Agent.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button_Previous_Agent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Previous_Agent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Previous_Agent.ForeColor = System.Drawing.Color.White;
            this.button_Previous_Agent.Location = new System.Drawing.Point(34, 565);
            this.button_Previous_Agent.Name = "button_Previous_Agent";
            this.button_Previous_Agent.Size = new System.Drawing.Size(90, 30);
            this.button_Previous_Agent.TabIndex = 14;
            this.button_Previous_Agent.Text = "Previous";
            this.button_Previous_Agent.UseVisualStyleBackColor = false;
            this.button_Previous_Agent.Click += new System.EventHandler(this.button_Previous_Agent_Click);
            // 
            // button_Next_Agent
            // 
            this.button_Next_Agent.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button_Next_Agent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Next_Agent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Next_Agent.ForeColor = System.Drawing.Color.White;
            this.button_Next_Agent.Location = new System.Drawing.Point(411, 565);
            this.button_Next_Agent.Name = "button_Next_Agent";
            this.button_Next_Agent.Size = new System.Drawing.Size(90, 30);
            this.button_Next_Agent.TabIndex = 15;
            this.button_Next_Agent.Text = "Next";
            this.button_Next_Agent.UseVisualStyleBackColor = false;
            this.button_Next_Agent.Click += new System.EventHandler(this.button_Next_Agent_Click);
            // 
            // labelPageNumberAgent
            // 
            this.labelPageNumberAgent.AutoSize = true;
            this.labelPageNumberAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPageNumberAgent.Location = new System.Drawing.Point(222, 566);
            this.labelPageNumberAgent.Name = "labelPageNumberAgent";
            this.labelPageNumberAgent.Size = new System.Drawing.Size(174, 29);
            this.labelPageNumberAgent.TabIndex = 16;
            this.labelPageNumberAgent.Text = "Page Number";
            // 
            // button_Previous_Order
            // 
            this.button_Previous_Order.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button_Previous_Order.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Previous_Order.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Previous_Order.ForeColor = System.Drawing.Color.White;
            this.button_Previous_Order.Location = new System.Drawing.Point(716, 551);
            this.button_Previous_Order.Name = "button_Previous_Order";
            this.button_Previous_Order.Size = new System.Drawing.Size(90, 30);
            this.button_Previous_Order.TabIndex = 17;
            this.button_Previous_Order.Text = "Previous";
            this.button_Previous_Order.UseVisualStyleBackColor = false;
            this.button_Previous_Order.Click += new System.EventHandler(this.button_Previous_Order_Click);
            // 
            // button_Next_Order
            // 
            this.button_Next_Order.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button_Next_Order.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Next_Order.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Next_Order.ForeColor = System.Drawing.Color.White;
            this.button_Next_Order.Location = new System.Drawing.Point(1074, 551);
            this.button_Next_Order.Name = "button_Next_Order";
            this.button_Next_Order.Size = new System.Drawing.Size(90, 30);
            this.button_Next_Order.TabIndex = 18;
            this.button_Next_Order.Text = "Next";
            this.button_Next_Order.UseVisualStyleBackColor = false;
            this.button_Next_Order.Click += new System.EventHandler(this.button_Next_Order_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(407, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(397, 37);
            this.label5.TabIndex = 20;
            this.label5.Text = "General Electric Services";
            // 
            // labelPageNumberOrders
            // 
            this.labelPageNumberOrders.AutoSize = true;
            this.labelPageNumberOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPageNumberOrders.Location = new System.Drawing.Point(902, 552);
            this.labelPageNumberOrders.Name = "labelPageNumberOrders";
            this.labelPageNumberOrders.Size = new System.Drawing.Size(174, 29);
            this.labelPageNumberOrders.TabIndex = 19;
            this.labelPageNumberOrders.Text = "Page Number";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 24);
            this.label4.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.LoadData);
            this.tabControl1.Controls.Add(this.AssignOrders);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1206, 737);
            this.tabControl1.TabIndex = 21;
            // 
            // LoadData
            // 
            this.LoadData.Controls.Add(this.agentsGridView);
            this.LoadData.Controls.Add(this.label5);
            this.LoadData.Controls.Add(this.ordersGridView);
            this.LoadData.Controls.Add(this.labelPageNumberOrders);
            this.LoadData.Controls.Add(this.buttonLoadAgents);
            this.LoadData.Controls.Add(this.button_Next_Order);
            this.LoadData.Controls.Add(this.buttonLoadOrders);
            this.LoadData.Controls.Add(this.button_Previous_Order);
            this.LoadData.Controls.Add(this.label1);
            this.LoadData.Controls.Add(this.label2);
            this.LoadData.Controls.Add(this.labelPageNumberAgent);
            this.LoadData.Controls.Add(this.label3);
            this.LoadData.Controls.Add(this.button_Next_Agent);
            this.LoadData.Controls.Add(this.button_Previous_Agent);
            this.LoadData.Location = new System.Drawing.Point(4, 31);
            this.LoadData.Name = "LoadData";
            this.LoadData.Padding = new System.Windows.Forms.Padding(3);
            this.LoadData.Size = new System.Drawing.Size(1198, 702);
            this.LoadData.TabIndex = 0;
            this.LoadData.Text = "Load Data";
            this.LoadData.UseVisualStyleBackColor = true;
            // 
            // AssignOrders
            // 
            this.AssignOrders.Controls.Add(this.labelNumberPageAssign);
            this.AssignOrders.Controls.Add(this.buttonNextAssign);
            this.AssignOrders.Controls.Add(this.buttonPreviousAssign);
            this.AssignOrders.Controls.Add(this.buttonAssign);
            this.AssignOrders.Controls.Add(this.label6);
            this.AssignOrders.Controls.Add(this.dataGridAssignOrders);
            this.AssignOrders.Location = new System.Drawing.Point(4, 31);
            this.AssignOrders.Name = "AssignOrders";
            this.AssignOrders.Padding = new System.Windows.Forms.Padding(3);
            this.AssignOrders.Size = new System.Drawing.Size(1198, 702);
            this.AssignOrders.TabIndex = 1;
            this.AssignOrders.Text = "Assign Orders";
            this.AssignOrders.UseVisualStyleBackColor = true;
            // 
            // labelNumberPageAssign
            // 
            this.labelNumberPageAssign.AutoSize = true;
            this.labelNumberPageAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberPageAssign.Location = new System.Drawing.Point(592, 598);
            this.labelNumberPageAssign.Name = "labelNumberPageAssign";
            this.labelNumberPageAssign.Size = new System.Drawing.Size(85, 29);
            this.labelNumberPageAssign.TabIndex = 19;
            this.labelNumberPageAssign.Text = "label4";
            // 
            // buttonNextAssign
            // 
            this.buttonNextAssign.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonNextAssign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonNextAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNextAssign.ForeColor = System.Drawing.Color.White;
            this.buttonNextAssign.Location = new System.Drawing.Point(918, 594);
            this.buttonNextAssign.Name = "buttonNextAssign";
            this.buttonNextAssign.Size = new System.Drawing.Size(90, 30);
            this.buttonNextAssign.TabIndex = 18;
            this.buttonNextAssign.Text = "Next";
            this.buttonNextAssign.UseVisualStyleBackColor = false;
            // 
            // buttonPreviousAssign
            // 
            this.buttonPreviousAssign.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonPreviousAssign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPreviousAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPreviousAssign.ForeColor = System.Drawing.Color.White;
            this.buttonPreviousAssign.Location = new System.Drawing.Point(213, 594);
            this.buttonPreviousAssign.Name = "buttonPreviousAssign";
            this.buttonPreviousAssign.Size = new System.Drawing.Size(90, 30);
            this.buttonPreviousAssign.TabIndex = 17;
            this.buttonPreviousAssign.Text = "Previous";
            this.buttonPreviousAssign.UseVisualStyleBackColor = false;
            // 
            // buttonAssign
            // 
            this.buttonAssign.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonAssign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAssign.ForeColor = System.Drawing.Color.White;
            this.buttonAssign.Location = new System.Drawing.Point(536, 666);
            this.buttonAssign.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAssign.Name = "buttonAssign";
            this.buttonAssign.Size = new System.Drawing.Size(197, 31);
            this.buttonAssign.TabIndex = 7;
            this.buttonAssign.Text = "Assign Orders";
            this.buttonAssign.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(213, 43);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(795, 44);
            this.label6.TabIndex = 6;
            this.label6.Text = "Orders Assignment";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridAssignOrders
            // 
            this.dataGridAssignOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAssignOrders.Location = new System.Drawing.Point(213, 87);
            this.dataGridAssignOrders.Name = "dataGridAssignOrders";
            this.dataGridAssignOrders.RowTemplate.Height = 28;
            this.dataGridAssignOrders.Size = new System.Drawing.Size(795, 495);
            this.dataGridAssignOrders.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 760);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "General Electric Services";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.agentsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersGridView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.LoadData.ResumeLayout(false);
            this.LoadData.PerformLayout();
            this.AssignOrders.ResumeLayout(false);
            this.AssignOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAssignOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView agentsGridView;
        private System.Windows.Forms.DataGridView ordersGridView;
        private System.Windows.Forms.Button buttonLoadAgents;
        private System.Windows.Forms.Button buttonLoadOrders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_Previous_Agent;
        private System.Windows.Forms.Button button_Next_Agent;
        private System.Windows.Forms.Label labelPageNumberAgent;
        private System.Windows.Forms.Button button_Previous_Order;
        private System.Windows.Forms.Button button_Next_Order;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelPageNumberOrders;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage LoadData;
        private System.Windows.Forms.TabPage AssignOrders;
        private System.Windows.Forms.DataGridView dataGridAssignOrders;
        private System.Windows.Forms.Button buttonAssign;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelNumberPageAssign;
        private System.Windows.Forms.Button buttonNextAssign;
        private System.Windows.Forms.Button buttonPreviousAssign;
    }
}

