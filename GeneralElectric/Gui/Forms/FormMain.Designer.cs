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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.LoadData = new System.Windows.Forms.TabPage();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.labelPageNumberOrders = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.gridViewOrders = new System.Windows.Forms.DataGridView();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.gridViewAgents = new System.Windows.Forms.DataGridView();
            this.AssignOrders = new System.Windows.Forms.TabPage();
            this.labelPageNumberOrdersAssignment = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.gridViewResults = new System.Windows.Forms.DataGridView();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.materialTabControl1.SuspendLayout();
            this.LoadData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAgents)).BeginInit();
            this.AssignOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.LoadData);
            this.materialTabControl1.Controls.Add(this.AssignOrders);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(36, 204);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1146, 584);
            this.materialTabControl1.TabIndex = 0;
            // 
            // LoadData
            // 
            this.LoadData.Controls.Add(this.materialLabel1);
            this.LoadData.Controls.Add(this.labelPageNumberOrders);
            this.LoadData.Controls.Add(this.materialLabel3);
            this.LoadData.Controls.Add(this.gridViewOrders);
            this.LoadData.Controls.Add(this.materialLabel2);
            this.LoadData.Controls.Add(this.gridViewAgents);
            this.LoadData.Location = new System.Drawing.Point(4, 23);
            this.LoadData.Name = "LoadData";
            this.LoadData.Padding = new System.Windows.Forms.Padding(3);
            this.LoadData.Size = new System.Drawing.Size(1138, 557);
            this.LoadData.TabIndex = 0;
            this.LoadData.Text = "Load Data";
            this.LoadData.UseVisualStyleBackColor = true;
            // 
            // materialLabel1
            // 
            this.materialLabel1.BackColor = System.Drawing.Color.SkyBlue;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(28, 18);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(480, 39);
            this.materialLabel1.TabIndex = 10;
            this.materialLabel1.Text = "Agents";
            this.materialLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPageNumberOrders
            // 
            this.labelPageNumberOrders.Depth = 0;
            this.labelPageNumberOrders.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelPageNumberOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPageNumberOrders.Location = new System.Drawing.Point(818, 492);
            this.labelPageNumberOrders.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelPageNumberOrders.Name = "labelPageNumberOrders";
            this.labelPageNumberOrders.Size = new System.Drawing.Size(139, 33);
            this.labelPageNumberOrders.TabIndex = 9;
            // 
            // materialLabel3
            // 
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(166, 494);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(180, 33);
            this.materialLabel3.TabIndex = 4;
            this.materialLabel3.Text = "\r\n";
            this.materialLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridViewOrders
            // 
            this.gridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewOrders.Location = new System.Drawing.Point(631, 59);
            this.gridViewOrders.Name = "gridViewOrders";
            this.gridViewOrders.Size = new System.Drawing.Size(477, 394);
            this.gridViewOrders.TabIndex = 3;
            // 
            // materialLabel2
            // 
            this.materialLabel2.BackColor = System.Drawing.Color.SkyBlue;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(631, 16);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(477, 45);
            this.materialLabel2.TabIndex = 2;
            this.materialLabel2.Text = "Orders";
            this.materialLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridViewAgents
            // 
            this.gridViewAgents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewAgents.Location = new System.Drawing.Point(28, 57);
            this.gridViewAgents.Name = "gridViewAgents";
            this.gridViewAgents.Size = new System.Drawing.Size(480, 396);
            this.gridViewAgents.TabIndex = 1;
            // 
            // AssignOrders
            // 
            this.AssignOrders.Controls.Add(this.labelPageNumberOrdersAssignment);
            this.AssignOrders.Controls.Add(this.materialLabel5);
            this.AssignOrders.Controls.Add(this.listBoxLog);
            this.AssignOrders.Controls.Add(this.gridViewResults);
            this.AssignOrders.Controls.Add(this.materialLabel4);
            this.AssignOrders.Location = new System.Drawing.Point(4, 23);
            this.AssignOrders.Name = "AssignOrders";
            this.AssignOrders.Padding = new System.Windows.Forms.Padding(3);
            this.AssignOrders.Size = new System.Drawing.Size(1138, 557);
            this.AssignOrders.TabIndex = 1;
            this.AssignOrders.Text = "Assign ";
            this.AssignOrders.UseVisualStyleBackColor = true;
            // 
            // labelPageNumberOrdersAssignment
            // 
            this.labelPageNumberOrdersAssignment.Depth = 0;
            this.labelPageNumberOrdersAssignment.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelPageNumberOrdersAssignment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPageNumberOrdersAssignment.Location = new System.Drawing.Point(184, 484);
            this.labelPageNumberOrdersAssignment.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelPageNumberOrdersAssignment.Name = "labelPageNumberOrdersAssignment";
            this.labelPageNumberOrdersAssignment.Size = new System.Drawing.Size(143, 20);
            this.labelPageNumberOrdersAssignment.TabIndex = 6;
            // 
            // materialLabel5
            // 
            this.materialLabel5.BackColor = System.Drawing.Color.SkyBlue;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(754, 33);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(334, 35);
            this.materialLabel5.TabIndex = 3;
            this.materialLabel5.Text = "Process";
            this.materialLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBoxLog
            // 
            this.listBoxLog.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 15;
            this.listBoxLog.Location = new System.Drawing.Point(754, 68);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(334, 409);
            this.listBoxLog.TabIndex = 2;
            // 
            // gridViewResults
            // 
            this.gridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewResults.Location = new System.Drawing.Point(6, 68);
            this.gridViewResults.Name = "gridViewResults";
            this.gridViewResults.Size = new System.Drawing.Size(529, 402);
            this.gridViewResults.TabIndex = 1;
            // 
            // materialLabel4
            // 
            this.materialLabel4.BackColor = System.Drawing.Color.SkyBlue;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(6, 33);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(529, 35);
            this.materialLabel4.TabIndex = 0;
            this.materialLabel4.Text = "Orders Assignment";
            this.materialLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.CausesValidation = false;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 89);
            this.materialTabSelector1.MaximumSize = new System.Drawing.Size(1256, 40);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(1214, 40);
            this.materialTabSelector1.TabIndex = 1;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gui.Properties.Resources.general_electric1;
            this.pictureBox1.Location = new System.Drawing.Point(567, 132);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 92);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(1, 65);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(1214, 23);
            this.materialDivider1.TabIndex = 12;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1213, 800);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.materialTabControl1);
            this.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "General Electric Services";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.LoadData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAgents)).EndInit();
            this.AssignOrders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage LoadData;
        private System.Windows.Forms.TabPage AssignOrders;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private System.Windows.Forms.DataGridView gridViewAgents;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.DataGridView gridViewOrders;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel labelPageNumberOrders;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.DataGridView gridViewResults;
        private System.Windows.Forms.ListBox listBoxLog;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel labelPageNumberOrdersAssignment;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
    }
}

