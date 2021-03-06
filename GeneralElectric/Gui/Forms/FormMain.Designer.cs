﻿namespace Gui.Forms
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
            this.materialTabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.LoadDataTab = new System.Windows.Forms.TabPage();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.labelPageNumberOrders = new MaterialSkin.Controls.MaterialLabel();
            this.labelPageNumberAgents = new MaterialSkin.Controls.MaterialLabel();
            this.gridViewOrders = new System.Windows.Forms.DataGridView();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.gridViewAgents = new System.Windows.Forms.DataGridView();
            this.AssignOrdersTab = new System.Windows.Forms.TabPage();
            this.labelGenerationLimit = new System.Windows.Forms.Label();
            this.labelPageNumberResult = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.gridViewResults = new System.Windows.Forms.DataGridView();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialTabControl.SuspendLayout();
            this.LoadDataTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAgents)).BeginInit();
            this.AssignOrdersTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // materialTabControl
            // 
            this.materialTabControl.Controls.Add(this.LoadDataTab);
            this.materialTabControl.Controls.Add(this.AssignOrdersTab);
            this.materialTabControl.Depth = 0;
            this.materialTabControl.Location = new System.Drawing.Point(12, 135);
            this.materialTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl.Name = "materialTabControl";
            this.materialTabControl.SelectedIndex = 0;
            this.materialTabControl.Size = new System.Drawing.Size(1146, 624);
            this.materialTabControl.TabIndex = 0;
            // 
            // LoadDataTab
            // 
            this.LoadDataTab.Controls.Add(this.materialLabel1);
            this.LoadDataTab.Controls.Add(this.labelPageNumberOrders);
            this.LoadDataTab.Controls.Add(this.labelPageNumberAgents);
            this.LoadDataTab.Controls.Add(this.gridViewOrders);
            this.LoadDataTab.Controls.Add(this.materialLabel2);
            this.LoadDataTab.Controls.Add(this.gridViewAgents);
            this.LoadDataTab.Location = new System.Drawing.Point(4, 26);
            this.LoadDataTab.Name = "LoadDataTab";
            this.LoadDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.LoadDataTab.Size = new System.Drawing.Size(1138, 594);
            this.LoadDataTab.TabIndex = 0;
            this.LoadDataTab.Text = "Load Data";
            this.LoadDataTab.UseVisualStyleBackColor = true;
            // 
            // materialLabel1
            // 
            this.materialLabel1.BackColor = System.Drawing.Color.SkyBlue;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(28, 28);
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
            this.labelPageNumberOrders.Location = new System.Drawing.Point(808, 554);
            this.labelPageNumberOrders.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelPageNumberOrders.Name = "labelPageNumberOrders";
            this.labelPageNumberOrders.Size = new System.Drawing.Size(140, 34);
            this.labelPageNumberOrders.TabIndex = 9;
            this.labelPageNumberOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPageNumberAgents
            // 
            this.labelPageNumberAgents.Depth = 0;
            this.labelPageNumberAgents.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelPageNumberAgents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPageNumberAgents.Location = new System.Drawing.Point(195, 554);
            this.labelPageNumberAgents.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelPageNumberAgents.Name = "labelPageNumberAgents";
            this.labelPageNumberAgents.Size = new System.Drawing.Size(140, 34);
            this.labelPageNumberAgents.TabIndex = 4;
            this.labelPageNumberAgents.Text = "\r\n";
            this.labelPageNumberAgents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridViewOrders
            // 
            this.gridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewOrders.Location = new System.Drawing.Point(631, 67);
            this.gridViewOrders.Name = "gridViewOrders";
            this.gridViewOrders.Size = new System.Drawing.Size(477, 480);
            this.gridViewOrders.TabIndex = 3;
            // 
            // materialLabel2
            // 
            this.materialLabel2.BackColor = System.Drawing.Color.SkyBlue;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(631, 28);
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
            this.gridViewAgents.Location = new System.Drawing.Point(28, 67);
            this.gridViewAgents.Name = "gridViewAgents";
            this.gridViewAgents.Size = new System.Drawing.Size(480, 480);
            this.gridViewAgents.TabIndex = 1;
            // 
            // AssignOrdersTab
            // 
            this.AssignOrdersTab.Controls.Add(this.labelGenerationLimit);
            this.AssignOrdersTab.Controls.Add(this.labelPageNumberResult);
            this.AssignOrdersTab.Controls.Add(this.materialLabel5);
            this.AssignOrdersTab.Controls.Add(this.listBoxLog);
            this.AssignOrdersTab.Controls.Add(this.gridViewResults);
            this.AssignOrdersTab.Controls.Add(this.materialLabel4);
            this.AssignOrdersTab.Location = new System.Drawing.Point(4, 26);
            this.AssignOrdersTab.Name = "AssignOrdersTab";
            this.AssignOrdersTab.Padding = new System.Windows.Forms.Padding(3);
            this.AssignOrdersTab.Size = new System.Drawing.Size(1138, 594);
            this.AssignOrdersTab.TabIndex = 1;
            this.AssignOrdersTab.Text = "Assign ";
            this.AssignOrdersTab.UseVisualStyleBackColor = true;
            // 
            // labelGenerationLimit
            // 
            this.labelGenerationLimit.AutoSize = true;
            this.labelGenerationLimit.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGenerationLimit.Location = new System.Drawing.Point(859, 561);
            this.labelGenerationLimit.Name = "labelGenerationLimit";
            this.labelGenerationLimit.Size = new System.Drawing.Size(134, 22);
            this.labelGenerationLimit.TabIndex = 7;
            this.labelGenerationLimit.Text = "Generation limit:";
            // 
            // labelPageNumberResult
            // 
            this.labelPageNumberResult.Depth = 0;
            this.labelPageNumberResult.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelPageNumberResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPageNumberResult.Location = new System.Drawing.Point(320, 554);
            this.labelPageNumberResult.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelPageNumberResult.Name = "labelPageNumberResult";
            this.labelPageNumberResult.Size = new System.Drawing.Size(140, 34);
            this.labelPageNumberResult.TabIndex = 6;
            this.labelPageNumberResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialLabel5
            // 
            this.materialLabel5.BackColor = System.Drawing.Color.SkyBlue;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(770, 28);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(334, 39);
            this.materialLabel5.TabIndex = 3;
            this.materialLabel5.Text = "Process";
            this.materialLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBoxLog
            // 
            this.listBoxLog.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 19;
            this.listBoxLog.Location = new System.Drawing.Point(770, 67);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(334, 479);
            this.listBoxLog.TabIndex = 2;
            // 
            // gridViewResults
            // 
            this.gridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewResults.Location = new System.Drawing.Point(28, 67);
            this.gridViewResults.Name = "gridViewResults";
            this.gridViewResults.Size = new System.Drawing.Size(705, 480);
            this.gridViewResults.TabIndex = 1;
            // 
            // materialLabel4
            // 
            this.materialLabel4.BackColor = System.Drawing.Color.SkyBlue;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(28, 28);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(705, 39);
            this.materialLabel4.TabIndex = 0;
            this.materialLabel4.Text = "Orders Assignment";
            this.materialLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.materialTabSelector1.BaseTabControl = this.materialTabControl;
            this.materialTabSelector1.CausesValidation = false;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 89);
            this.materialTabSelector1.MaximumSize = new System.Drawing.Size(1256, 40);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(1174, 40);
            this.materialTabSelector1.TabIndex = 1;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(1, 65);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(1173, 23);
            this.materialDivider1.TabIndex = 12;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Gui.Properties.Resources.general_electric;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(1135, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1174, 771);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.materialTabControl);
            this.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "General Electric Services";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.materialTabControl.ResumeLayout(false);
            this.LoadDataTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAgents)).EndInit();
            this.AssignOrdersTab.ResumeLayout(false);
            this.AssignOrdersTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl;
        private System.Windows.Forms.TabPage LoadDataTab;
        private System.Windows.Forms.TabPage AssignOrdersTab;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private System.Windows.Forms.DataGridView gridViewAgents;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.DataGridView gridViewOrders;
        private MaterialSkin.Controls.MaterialLabel labelPageNumberAgents;
        private MaterialSkin.Controls.MaterialLabel labelPageNumberOrders;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.DataGridView gridViewResults;
        private System.Windows.Forms.ListBox listBoxLog;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel labelPageNumberResult;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelGenerationLimit;
    }
}

