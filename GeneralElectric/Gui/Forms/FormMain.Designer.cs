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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gridViewAgents = new System.Windows.Forms.DataGridView();
            this.gridViewOrders = new System.Windows.Forms.DataGridView();
            this.buttonLoadAgents = new System.Windows.Forms.Button();
            this.buttonLoadOrders = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonPreviousAgent = new System.Windows.Forms.Button();
            this.buttonNextAgent = new System.Windows.Forms.Button();
            this.labelPageNumberAgent = new System.Windows.Forms.Label();
            this.buttonPreviousOrder = new System.Windows.Forms.Button();
            this.buttonNextOrder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelPageNumberOrders = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.LoadData = new System.Windows.Forms.TabPage();
            this.AssignOrders = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.labelNumberPageAssign = new System.Windows.Forms.Label();
            this.buttonNextAssign = new System.Windows.Forms.Button();
            this.buttonPreviousAssign = new System.Windows.Forms.Button();
            this.buttonAssignOrders = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.gridViewResults = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAgents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrders)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.LoadData.SuspendLayout();
            this.AssignOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResults)).BeginInit();
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
            // gridViewAgents
            // 
            this.gridViewAgents.AllowUserToOrderColumns = true;
            this.gridViewAgents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridViewAgents.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridViewAgents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewAgents.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridViewAgents.Location = new System.Drawing.Point(34, 100);
            this.gridViewAgents.Margin = new System.Windows.Forms.Padding(2);
            this.gridViewAgents.Name = "gridViewAgents";
            this.gridViewAgents.RowTemplate.Height = 30;
            this.gridViewAgents.Size = new System.Drawing.Size(467, 426);
            this.gridViewAgents.TabIndex = 0;
            this.gridViewAgents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // gridViewOrders
            // 
            this.gridViewOrders.AllowUserToOrderColumns = true;
            this.gridViewOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewOrders.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridViewOrders.Location = new System.Drawing.Point(716, 100);
            this.gridViewOrders.Margin = new System.Windows.Forms.Padding(2);
            this.gridViewOrders.Name = "gridViewOrders";
            this.gridViewOrders.RowTemplate.Height = 28;
            this.gridViewOrders.Size = new System.Drawing.Size(448, 426);
            this.gridViewOrders.TabIndex = 1;
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
            this.label1.Location = new System.Drawing.Point(34, 56);
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
            this.label2.Location = new System.Drawing.Point(716, 56);
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
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 9;
            // 
            // buttonPreviousAgent
            // 
            this.buttonPreviousAgent.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonPreviousAgent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPreviousAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPreviousAgent.ForeColor = System.Drawing.Color.White;
            this.buttonPreviousAgent.Location = new System.Drawing.Point(34, 565);
            this.buttonPreviousAgent.Name = "buttonPreviousAgent";
            this.buttonPreviousAgent.Size = new System.Drawing.Size(90, 30);
            this.buttonPreviousAgent.TabIndex = 14;
            this.buttonPreviousAgent.Text = "Previous";
            this.buttonPreviousAgent.UseVisualStyleBackColor = false;
            this.buttonPreviousAgent.Click += new System.EventHandler(this.ButtonPreviousAgent_Click);
            // 
            // buttonNextAgent
            // 
            this.buttonNextAgent.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonNextAgent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonNextAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNextAgent.ForeColor = System.Drawing.Color.White;
            this.buttonNextAgent.Location = new System.Drawing.Point(411, 565);
            this.buttonNextAgent.Name = "buttonNextAgent";
            this.buttonNextAgent.Size = new System.Drawing.Size(90, 30);
            this.buttonNextAgent.TabIndex = 15;
            this.buttonNextAgent.Text = "Next";
            this.buttonNextAgent.UseVisualStyleBackColor = false;
            this.buttonNextAgent.Click += new System.EventHandler(this.ButtonNextAgent_Click);
            // 
            // labelPageNumberAgent
            // 
            this.labelPageNumberAgent.AutoSize = true;
            this.labelPageNumberAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPageNumberAgent.Location = new System.Drawing.Point(222, 566);
            this.labelPageNumberAgent.Name = "labelPageNumberAgent";
            this.labelPageNumberAgent.Size = new System.Drawing.Size(117, 20);
            this.labelPageNumberAgent.TabIndex = 16;
            this.labelPageNumberAgent.Text = "Page Number";
            // 
            // buttonPreviousOrder
            // 
            this.buttonPreviousOrder.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonPreviousOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPreviousOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPreviousOrder.ForeColor = System.Drawing.Color.White;
            this.buttonPreviousOrder.Location = new System.Drawing.Point(716, 551);
            this.buttonPreviousOrder.Name = "buttonPreviousOrder";
            this.buttonPreviousOrder.Size = new System.Drawing.Size(90, 30);
            this.buttonPreviousOrder.TabIndex = 17;
            this.buttonPreviousOrder.Text = "Previous";
            this.buttonPreviousOrder.UseVisualStyleBackColor = false;
            this.buttonPreviousOrder.Click += new System.EventHandler(this.ButtonPreviousOrder_Click);
            // 
            // buttonNextOrder
            // 
            this.buttonNextOrder.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonNextOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonNextOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNextOrder.ForeColor = System.Drawing.Color.White;
            this.buttonNextOrder.Location = new System.Drawing.Point(1074, 551);
            this.buttonNextOrder.Name = "buttonNextOrder";
            this.buttonNextOrder.Size = new System.Drawing.Size(90, 30);
            this.buttonNextOrder.TabIndex = 18;
            this.buttonNextOrder.Text = "Next";
            this.buttonNextOrder.UseVisualStyleBackColor = false;
            this.buttonNextOrder.Click += new System.EventHandler(this.ButtonNextOrder_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(446, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(282, 26);
            this.label5.TabIndex = 20;
            this.label5.Text = "General Electric Services";
            // 
            // labelPageNumberOrders
            // 
            this.labelPageNumberOrders.AutoSize = true;
            this.labelPageNumberOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPageNumberOrders.Location = new System.Drawing.Point(902, 552);
            this.labelPageNumberOrders.Name = "labelPageNumberOrders";
            this.labelPageNumberOrders.Size = new System.Drawing.Size(117, 20);
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
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1265, 813);
            this.tabControl1.TabIndex = 21;
            // 
            // LoadData
            // 
            this.LoadData.Controls.Add(this.gridViewAgents);
            this.LoadData.Controls.Add(this.label5);
            this.LoadData.Controls.Add(this.gridViewOrders);
            this.LoadData.Controls.Add(this.labelPageNumberOrders);
            this.LoadData.Controls.Add(this.buttonLoadAgents);
            this.LoadData.Controls.Add(this.buttonNextOrder);
            this.LoadData.Controls.Add(this.buttonLoadOrders);
            this.LoadData.Controls.Add(this.buttonPreviousOrder);
            this.LoadData.Controls.Add(this.label1);
            this.LoadData.Controls.Add(this.label2);
            this.LoadData.Controls.Add(this.labelPageNumberAgent);
            this.LoadData.Controls.Add(this.label3);
            this.LoadData.Controls.Add(this.buttonNextAgent);
            this.LoadData.Controls.Add(this.buttonPreviousAgent);
            this.LoadData.Location = new System.Drawing.Point(4, 22);
            this.LoadData.Name = "LoadData";
            this.LoadData.Padding = new System.Windows.Forms.Padding(3);
            this.LoadData.Size = new System.Drawing.Size(1257, 787);
            this.LoadData.TabIndex = 0;
            this.LoadData.Text = "Load Data";
            this.LoadData.UseVisualStyleBackColor = true;
            // 
            // AssignOrders
            // 
            this.AssignOrders.Controls.Add(this.label7);
            this.AssignOrders.Controls.Add(this.listBoxLog);
            this.AssignOrders.Controls.Add(this.labelNumberPageAssign);
            this.AssignOrders.Controls.Add(this.buttonNextAssign);
            this.AssignOrders.Controls.Add(this.buttonPreviousAssign);
            this.AssignOrders.Controls.Add(this.buttonAssignOrders);
            this.AssignOrders.Controls.Add(this.label6);
            this.AssignOrders.Controls.Add(this.gridViewResults);
            this.AssignOrders.Location = new System.Drawing.Point(4, 22);
            this.AssignOrders.Name = "AssignOrders";
            this.AssignOrders.Padding = new System.Windows.Forms.Padding(3);
            this.AssignOrders.Size = new System.Drawing.Size(1257, 787);
            this.AssignOrders.TabIndex = 1;
            this.AssignOrders.Text = "Assign Orders";
            this.AssignOrders.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(880, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(339, 44);
            this.label7.TabIndex = 23;
            this.label7.Text = "Process";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(880, 80);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(339, 485);
            this.listBoxLog.TabIndex = 22;
            // 
            // labelNumberPageAssign
            // 
            this.labelNumberPageAssign.AutoSize = true;
            this.labelNumberPageAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberPageAssign.Location = new System.Drawing.Point(357, 594);
            this.labelNumberPageAssign.Name = "labelNumberPageAssign";
            this.labelNumberPageAssign.Size = new System.Drawing.Size(57, 20);
            this.labelNumberPageAssign.TabIndex = 19;
            this.labelNumberPageAssign.Text = "label4";
            // 
            // buttonNextAssign
            // 
            this.buttonNextAssign.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonNextAssign.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonNextAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNextAssign.ForeColor = System.Drawing.Color.White;
            this.buttonNextAssign.Location = new System.Drawing.Point(640, 594);
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
            this.buttonPreviousAssign.Location = new System.Drawing.Point(23, 588);
            this.buttonPreviousAssign.Name = "buttonPreviousAssign";
            this.buttonPreviousAssign.Size = new System.Drawing.Size(90, 30);
            this.buttonPreviousAssign.TabIndex = 17;
            this.buttonPreviousAssign.Text = "Previous";
            this.buttonPreviousAssign.UseVisualStyleBackColor = false;
            // 
            // buttonAssignOrders
            // 
            this.buttonAssignOrders.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonAssignOrders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAssignOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAssignOrders.ForeColor = System.Drawing.Color.White;
            this.buttonAssignOrders.Location = new System.Drawing.Point(296, 658);
            this.buttonAssignOrders.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAssignOrders.Name = "buttonAssignOrders";
            this.buttonAssignOrders.Size = new System.Drawing.Size(197, 31);
            this.buttonAssignOrders.TabIndex = 7;
            this.buttonAssignOrders.Text = "Assign Orders";
            this.buttonAssignOrders.UseVisualStyleBackColor = false;
            this.buttonAssignOrders.Click += new System.EventHandler(this.ButtonAssignOrders_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(23, 31);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(744, 44);
            this.label6.TabIndex = 6;
            this.label6.Text = "Orders Assignment";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridViewResults
            // 
            this.gridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewResults.Location = new System.Drawing.Point(23, 78);
            this.gridViewResults.Name = "gridViewResults";
            this.gridViewResults.RowTemplate.Height = 28;
            this.gridViewResults.Size = new System.Drawing.Size(744, 495);
            this.gridViewResults.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 880);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "General Electric Services";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAgents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrders)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.LoadData.ResumeLayout(false);
            this.LoadData.PerformLayout();
            this.AssignOrders.ResumeLayout(false);
            this.AssignOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView gridViewAgents;
        private System.Windows.Forms.DataGridView gridViewOrders;
        private System.Windows.Forms.Button buttonLoadAgents;
        private System.Windows.Forms.Button buttonLoadOrders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonPreviousAgent;
        private System.Windows.Forms.Button buttonNextAgent;
        private System.Windows.Forms.Label labelPageNumberAgent;
        private System.Windows.Forms.Button buttonPreviousOrder;
        private System.Windows.Forms.Button buttonNextOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelPageNumberOrders;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage LoadData;
        private System.Windows.Forms.TabPage AssignOrders;
        private System.Windows.Forms.DataGridView gridViewResults;
        private System.Windows.Forms.Button buttonAssignOrders;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelNumberPageAssign;
        private System.Windows.Forms.Button buttonNextAssign;
        private System.Windows.Forms.Button buttonPreviousAssign;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Label label7;
    }
}

