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
            this.components = new System.ComponentModel.Container();
            this.alzadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.muroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modeloContextBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbGDE = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.alzadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.muroBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeloContextBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // alzadoBindingSource
            // 
            this.alzadoBindingSource.DataSource = typeof(Entidades.Alzado);
            // 
            // muroBindingSource
            // 
            this.muroBindingSource.DataSource = typeof(Entidades.Muro);
            // 
            // modeloContextBindingSource
            // 
            this.modeloContextBindingSource.DataSource = typeof(DataAcces.ModeloContext);
            // 
            // programBindingSource
            // 
            this.programBindingSource.DataSource = typeof(DisenioMurosAyG.Program);
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
            // InicioProyectoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 193);
            this.Controls.Add(this.cbGDE);
            this.Controls.Add(this.label1);
            this.Name = "InicioProyectoView";
            this.Text = "InicioProyectoView";
            this.Load += new System.EventHandler(this.InicioProyectoView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.alzadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.muroBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeloContextBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource alzadoBindingSource;
        private System.Windows.Forms.BindingSource muroBindingSource;
        private System.Windows.Forms.BindingSource modeloContextBindingSource;
        private System.Windows.Forms.BindingSource programBindingSource;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbGDE;
    }
}