namespace DisenioMurosAyG.Views
{
    partial class DespieceView
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
            Telerik.WinControls.ThemeSource themeSource1 = new Telerik.WinControls.ThemeSource();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.gbInfoAlzado = new Telerik.WinControls.UI.RadGroupBox();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.gvDespieceMuro = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gbInfoAlzado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDespieceMuro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDespieceMuro.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radThemeManager1
            // 
            this.radThemeManager1.LoadedThemes.AddRange(new Telerik.WinControls.ThemeSource[] {
            themeSource1});
            // 
            // gbInfoAlzado
            // 
            this.gbInfoAlzado.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.gbInfoAlzado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInfoAlzado.HeaderText = "Información despiece ";
            this.gbInfoAlzado.Location = new System.Drawing.Point(12, 12);
            this.gbInfoAlzado.Name = "gbInfoAlzado";
            this.gbInfoAlzado.Size = new System.Drawing.Size(1010, 638);
            this.gbInfoAlzado.TabIndex = 0;
            this.gbInfoAlzado.Text = "Información despiece ";
            this.gbInfoAlzado.ThemeName = "Office2013Light";
            // 
            // gvDespieceMuro
            // 
            this.gvDespieceMuro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvDespieceMuro.Location = new System.Drawing.Point(11, 51);
            // 
            // 
            // 
            this.gvDespieceMuro.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gvDespieceMuro.Name = "gvDespieceMuro";
            this.gvDespieceMuro.Size = new System.Drawing.Size(1006, 594);
            this.gvDespieceMuro.TabIndex = 0;
            this.gvDespieceMuro.ThemeName = "Office2013Light";
            // 
            // DespieceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 662);
            this.Controls.Add(this.gvDespieceMuro);
            this.Controls.Add(this.gbInfoAlzado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DespieceView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "DespieceView";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.gbInfoAlzado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDespieceMuro.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDespieceMuro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.RadThemeManager radThemeManager1;
        public Telerik.WinControls.UI.RadGroupBox gbInfoAlzado;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        public Telerik.WinControls.UI.RadGridView gvDespieceMuro;
    }
}
