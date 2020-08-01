namespace DisenioMurosAyG.Views
{
    partial class MurosView
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.ListlMuros = new Telerik.WinControls.UI.RadGridView();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.cbAceptar = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListlMuros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListlMuros.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.cbAceptar);
            this.radGroupBox1.Controls.Add(this.ListlMuros);
            this.radGroupBox1.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox1.HeaderText = "Muros estructurales";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(422, 528);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Muros estructurales";
            this.radGroupBox1.ThemeName = "Office2013Light";
            // 
            // ListlMuros
            // 
            this.ListlMuros.Location = new System.Drawing.Point(17, 31);
            // 
            // 
            // 
            this.ListlMuros.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.ListlMuros.Name = "ListlMuros";
            this.ListlMuros.Size = new System.Drawing.Size(386, 427);
            this.ListlMuros.TabIndex = 0;
            this.ListlMuros.ThemeName = "Office2013Light";
            // 
            // cbAceptar
            // 
            this.cbAceptar.Location = new System.Drawing.Point(17, 478);
            this.cbAceptar.Name = "cbAceptar";
            this.cbAceptar.Size = new System.Drawing.Size(386, 33);
            this.cbAceptar.TabIndex = 2;
            this.cbAceptar.Text = "Aceptar";
            this.cbAceptar.ThemeName = "Office2013Light";
            // 
            // MurosView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 552);
            this.Controls.Add(this.radGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MurosView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Lista de Muros";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListlMuros.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListlMuros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public Telerik.WinControls.UI.RadGridView ListlMuros;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        public Telerik.WinControls.UI.RadButton cbAceptar;
    }
}
