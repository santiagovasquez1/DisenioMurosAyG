namespace DisenioMurosAyG.Views
{
    partial class InformacionAlzadoView
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbAlzados = new System.Windows.Forms.ComboBox();
            this.dgAlzado = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgAlzado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alzado de muro :";
            // 
            // cbAlzados
            // 
            this.cbAlzados.FormattingEnabled = true;
            this.cbAlzados.Location = new System.Drawing.Point(104, 19);
            this.cbAlzados.Name = "cbAlzados";
            this.cbAlzados.Size = new System.Drawing.Size(125, 21);
            this.cbAlzados.TabIndex = 1;
            // 
            // dgAlzado
            // 
            this.dgAlzado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAlzado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAlzado.Location = new System.Drawing.Point(22, 83);
            this.dgAlzado.Name = "dgAlzado";
            this.dgAlzado.Size = new System.Drawing.Size(709, 339);
            this.dgAlzado.TabIndex = 2;
            // 
            // InformacionAlzadoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 450);
            this.Controls.Add(this.dgAlzado);
            this.Controls.Add(this.cbAlzados);
            this.Controls.Add(this.label1);
            this.Name = "InformacionAlzadoView";
            this.Text = "InformacionAlzadoView";
            ((System.ComponentModel.ISupportInitialize)(this.dgAlzado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbAlzados;
        public System.Windows.Forms.DataGridView dgAlzado;
    }
}