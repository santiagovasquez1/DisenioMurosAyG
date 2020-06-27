namespace DisenioMurosAyG.Views
{
    partial class InicioProyectoView
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
            this.cbGDE = new System.Windows.Forms.ComboBox();
            this.bAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbArchivoDiseno = new System.Windows.Forms.TextBox();
            this.bCargar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Grado de disipacion";
            // 
            // cbGDE
            // 
            this.cbGDE.FormattingEnabled = true;
            this.cbGDE.Location = new System.Drawing.Point(155, 25);
            this.cbGDE.Name = "cbGDE";
            this.cbGDE.Size = new System.Drawing.Size(121, 21);
            this.cbGDE.TabIndex = 2;
            // 
            // bAceptar
            // 
            this.bAceptar.Location = new System.Drawing.Point(155, 141);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(114, 31);
            this.bAceptar.TabIndex = 3;
            this.bAceptar.Text = "Nuevo Proyecto";
            this.bAceptar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Archivo Excel Diseño";
            // 
            // tbArchivoDiseno
            // 
            this.tbArchivoDiseno.Location = new System.Drawing.Point(155, 78);
            this.tbArchivoDiseno.Name = "tbArchivoDiseno";
            this.tbArchivoDiseno.Size = new System.Drawing.Size(121, 20);
            this.tbArchivoDiseno.TabIndex = 5;
            // 
            // bCargar
            // 
            this.bCargar.Location = new System.Drawing.Point(29, 141);
            this.bCargar.Name = "bCargar";
            this.bCargar.Size = new System.Drawing.Size(114, 31);
            this.bCargar.TabIndex = 6;
            this.bCargar.Text = "Cargar Archivos";
            this.bCargar.UseVisualStyleBackColor = true;
            // 
            // InicioProyectoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 193);
            this.Controls.Add(this.bCargar);
            this.Controls.Add(this.tbArchivoDiseno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bAceptar);
            this.Controls.Add(this.cbGDE);
            this.Controls.Add(this.label1);
            this.Name = "InicioProyectoView";
            this.Text = "InicioProyectoView";
            this.Load += new System.EventHandler(this.InicioProyectoView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbGDE;
        public System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbArchivoDiseno;
        public System.Windows.Forms.Button bCargar;
    }
}