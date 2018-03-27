namespace VoiceRecognitionMaze
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.matrizTablero = new System.Windows.Forms.DataGridView();
            this.BtnIniciar = new System.Windows.Forms.Button();
            this.TxbColumnas = new System.Windows.Forms.TextBox();
            this.TxbFilas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxbTamano = new System.Windows.Forms.TextBox();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.matrizTablero)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // matrizTablero
            // 
            this.matrizTablero.AllowUserToAddRows = false;
            this.matrizTablero.AllowUserToDeleteRows = false;
            this.matrizTablero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matrizTablero.ColumnHeadersVisible = false;
            this.matrizTablero.Location = new System.Drawing.Point(295, 33);
            this.matrizTablero.Margin = new System.Windows.Forms.Padding(2);
            this.matrizTablero.Name = "matrizTablero";
            this.matrizTablero.ReadOnly = true;
            this.matrizTablero.RowHeadersVisible = false;
            this.matrizTablero.RowTemplate.Height = 28;
            this.matrizTablero.Size = new System.Drawing.Size(332, 285);
            this.matrizTablero.TabIndex = 1;
            // 
            // BtnIniciar
            // 
            this.BtnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIniciar.Location = new System.Drawing.Point(29, 25);
            this.BtnIniciar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnIniciar.Name = "BtnIniciar";
            this.BtnIniciar.Size = new System.Drawing.Size(69, 29);
            this.BtnIniciar.TabIndex = 2;
            this.BtnIniciar.Text = "Iniciar";
            this.BtnIniciar.UseVisualStyleBackColor = true;
            this.BtnIniciar.Click += new System.EventHandler(this.BtnIniciar_Click);
            // 
            // TxbColumnas
            // 
            this.TxbColumnas.Location = new System.Drawing.Point(55, 66);
            this.TxbColumnas.Margin = new System.Windows.Forms.Padding(2);
            this.TxbColumnas.Name = "TxbColumnas";
            this.TxbColumnas.Size = new System.Drawing.Size(68, 20);
            this.TxbColumnas.TabIndex = 3;
            // 
            // TxbFilas
            // 
            this.TxbFilas.Location = new System.Drawing.Point(55, 93);
            this.TxbFilas.Margin = new System.Windows.Forms.Padding(2);
            this.TxbFilas.Name = "TxbFilas";
            this.TxbFilas.Size = new System.Drawing.Size(68, 20);
            this.TxbFilas.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "m";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "a";
            // 
            // TxbTamano
            // 
            this.TxbTamano.Location = new System.Drawing.Point(55, 122);
            this.TxbTamano.Margin = new System.Windows.Forms.Padding(2);
            this.TxbTamano.Name = "TxbTamano";
            this.TxbTamano.Size = new System.Drawing.Size(68, 20);
            this.TxbTamano.TabIndex = 7;
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpiar.Location = new System.Drawing.Point(113, 25);
            this.BtnLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(69, 29);
            this.BtnLimpiar.TabIndex = 8;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 481);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.TxbTamano);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxbFilas);
            this.Controls.Add(this.TxbColumnas);
            this.Controls.Add(this.BtnIniciar);
            this.Controls.Add(this.matrizTablero);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "d";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.matrizTablero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView matrizTablero;
        private System.Windows.Forms.Button BtnIniciar;
        private System.Windows.Forms.TextBox TxbColumnas;
        private System.Windows.Forms.TextBox TxbFilas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxbTamano;
        private System.Windows.Forms.Button BtnLimpiar;
    }
}

