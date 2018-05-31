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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.labelNumberPageAssign = new System.Windows.Forms.Label();
            this.buttonNextAssign = new System.Windows.Forms.Button();
            this.buttonPreviousAssign = new System.Windows.Forms.Button();
            this.buttonAssignOrders = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.gridViewResults = new System.Windows.Forms.DataGridView();
            this.listBoxLog = new System.Windows.Forms.ListBox();
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewAgents.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridViewAgents.Location = new System.Drawing.Point(34, 111);
            this.gridViewAgents.Margin = new System.Windows.Forms.Padding(2);
            this.gridViewAgents.Name = "gridViewAgents";
            this.gridViewAgents.RowTemplate.Height = 30;
            this.gridViewAgents.Size = new System.Drawing.Size(467, 437);
            this.gridViewAgents.TabIndex = 0;
            this.gridViewAgents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // gridViewOrders
            // 
            this.gridViewOrders.AllowUserToOrderColumns = true;
            this.gridViewOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridViewOrders.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridViewOrders.Location = new System.Drawing.Point(716, 111);
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
            this.label3.Size = new System.Drawing.Size(0, 18);
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
            this.labelPageNumberAgent.Size = new System.Drawing.Size(143, 25);
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
            this.label5.Location = new System.Drawing.Point(407, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(344, 31);
            this.label5.TabIndex = 20;
            this.label5.Text = "General Electric Services";
            // 
            // labelPageNumberOrders
            // 
            this.labelPageNumberOrders.AutoSize = true;
            this.labelPageNumberOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPageNumberOrders.Location = new System.Drawing.Point(902, 552);
            this.labelPageNumberOrders.Name = "labelPageNumberOrders";
            this.labelPageNumberOrders.Size = new System.Drawing.Size(143, 25);
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
            this.LoadData.Location = new System.Drawing.Point(4, 27);
            this.LoadData.Name = "LoadData";
            this.LoadData.Padding = new System.Windows.Forms.Padding(3);
            this.LoadData.Size = new System.Drawing.Size(1198, 706);
            this.LoadData.TabIndex = 0;
            this.LoadData.Text = "Load Data";
            this.LoadData.UseVisualStyleBackColor = true;
            // 
            // AssignOrders
            // 
            this.AssignOrders.Controls.Add(this.labelNumberPageAssign);
            this.AssignOrders.Controls.Add(this.buttonNextAssign);
            this.AssignOrders.Controls.Add(this.buttonPreviousAssign);
            this.AssignOrders.Controls.Add(this.buttonAssignOrders);
            this.AssignOrders.Controls.Add(this.label6);
            this.AssignOrders.Controls.Add(this.gridViewResults);
            this.AssignOrders.Location = new System.Drawing.Point(4, 27);
            this.AssignOrders.Name = "AssignOrders";
            this.AssignOrders.Padding = new System.Windows.Forms.Padding(3);
            this.AssignOrders.Size = new System.Drawing.Size(1198, 706);
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
            this.labelNumberPageAssign.Size = new System.Drawing.Size(70, 25);
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
            // buttonAssignOrders
            // 
            this.buttonAssignOrders.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonAssignOrders.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAssignOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAssignOrders.ForeColor = System.Drawing.Color.White;
            this.buttonAssignOrders.Location = new System.Drawing.Point(536, 666);
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
            this.label6.Location = new System.Drawing.Point(213, 43);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(795, 44);
            this.label6.TabIndex = 6;
            this.label6.Text = "Orders Assignment";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridViewResults
            // 
            this.gridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewResults.Location = new System.Drawing.Point(213, 87);
            this.gridViewResults.Name = "gridViewResults";
            this.gridViewResults.RowTemplate.Height = 28;
            this.gridViewResults.Size = new System.Drawing.Size(795, 495);
            this.gridViewResults.TabIndex = 0;
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 17;
            this.listBoxLog.Location = new System.Drawing.Point(484, 755);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(271, 123);
            this.listBoxLog.TabIndex = 22;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 926);
            this.Controls.Add(this.listBoxLog);
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
    }
}

