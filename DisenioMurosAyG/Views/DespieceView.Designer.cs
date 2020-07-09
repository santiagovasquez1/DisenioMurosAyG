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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.Data.FilterDescriptor filterDescriptor1 = new Telerik.WinControls.Data.FilterDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.gbInfoAlzado = new Telerik.WinControls.UI.RadGroupBox();
            this.cbAgregarCapa = new Telerik.WinControls.UI.RadButton();
            this.gvDespieceMuro = new Telerik.WinControls.UI.RadGridView();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.rdAyudaDespiece = new Telerik.WinControls.UI.RadGridView();
            this.radSplitContainer1 = new Telerik.WinControls.UI.RadSplitContainer();
            this.splitPanel1 = new Telerik.WinControls.UI.SplitPanel();
            this.splitPanel2 = new Telerik.WinControls.UI.SplitPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gbInfoAlzado)).BeginInit();
            this.gbInfoAlzado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAgregarCapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDespieceMuro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDespieceMuro.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdAyudaDespiece)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdAyudaDespiece.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).BeginInit();
            this.radSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).BeginInit();
            this.splitPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).BeginInit();
            this.splitPanel2.SuspendLayout();
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
            this.gbInfoAlzado.Controls.Add(this.radSplitContainer1);
            this.gbInfoAlzado.Controls.Add(this.cbAgregarCapa);
            this.gbInfoAlzado.HeaderText = "Información despiece ";
            this.gbInfoAlzado.Location = new System.Drawing.Point(12, 12);
            this.gbInfoAlzado.Name = "gbInfoAlzado";
            this.gbInfoAlzado.Size = new System.Drawing.Size(1010, 638);
            this.gbInfoAlzado.TabIndex = 0;
            this.gbInfoAlzado.Text = "Información despiece ";
            this.gbInfoAlzado.ThemeName = "Office2013Light";
            // 
            // cbAgregarCapa
            // 
            this.cbAgregarCapa.Location = new System.Drawing.Point(17, 21);
            this.cbAgregarCapa.Name = "cbAgregarCapa";
            this.cbAgregarCapa.Size = new System.Drawing.Size(134, 36);
            this.cbAgregarCapa.TabIndex = 1;
            this.cbAgregarCapa.Text = "AgregarAlzado";
            this.cbAgregarCapa.ThemeName = "Office2013Light";
            // 
            // gvDespieceMuro
            // 
            this.gvDespieceMuro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDespieceMuro.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.gvDespieceMuro.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.gvDespieceMuro.Name = "gvDespieceMuro";
            this.gvDespieceMuro.Size = new System.Drawing.Size(1006, 471);
            this.gvDespieceMuro.TabIndex = 0;
            this.gvDespieceMuro.ThemeName = "Office2013Light";
            // 
            // rdAyudaDespiece
            // 
            this.rdAyudaDespiece.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdAyudaDespiece.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.rdAyudaDespiece.MasterTemplate.AllowAddNewRow = false;
            this.rdAyudaDespiece.MasterTemplate.AllowColumnReorder = false;
            filterDescriptor1.IsFilterEditor = true;
            this.rdAyudaDespiece.MasterTemplate.FilterDescriptors.AddRange(new Telerik.WinControls.Data.FilterDescriptor[] {
            filterDescriptor1});
            this.rdAyudaDespiece.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rdAyudaDespiece.Name = "rdAyudaDespiece";
            this.rdAyudaDespiece.ReadOnly = true;
            this.rdAyudaDespiece.Size = new System.Drawing.Size(1006, 69);
            this.rdAyudaDespiece.TabIndex = 2;
            this.rdAyudaDespiece.ThemeName = "Office2013Light";
            // 
            // radSplitContainer1
            // 
            this.radSplitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radSplitContainer1.Controls.Add(this.splitPanel1);
            this.radSplitContainer1.Controls.Add(this.splitPanel2);
            this.radSplitContainer1.Location = new System.Drawing.Point(2, 75);
            this.radSplitContainer1.Name = "radSplitContainer1";
            this.radSplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // 
            // 
            this.radSplitContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.radSplitContainer1.Size = new System.Drawing.Size(1006, 545);
            this.radSplitContainer1.SplitterWidth = 5;
            this.radSplitContainer1.TabIndex = 3;
            this.radSplitContainer1.TabStop = false;
            this.radSplitContainer1.ThemeName = "Office2013Light";
            // 
            // splitPanel1
            // 
            this.splitPanel1.Controls.Add(this.rdAyudaDespiece);
            this.splitPanel1.Location = new System.Drawing.Point(0, 0);
            this.splitPanel1.Name = "splitPanel1";
            // 
            // 
            // 
            this.splitPanel1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel1.Size = new System.Drawing.Size(1006, 69);
            this.splitPanel1.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, -0.3722222F);
            this.splitPanel1.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, -201);
            this.splitPanel1.TabIndex = 0;
            this.splitPanel1.TabStop = false;
            this.splitPanel1.Text = "splitPanel1";
            this.splitPanel1.ThemeName = "Office2013Light";
            // 
            // splitPanel2
            // 
            this.splitPanel2.Controls.Add(this.gvDespieceMuro);
            this.splitPanel2.Location = new System.Drawing.Point(0, 74);
            this.splitPanel2.Name = "splitPanel2";
            // 
            // 
            // 
            this.splitPanel2.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.splitPanel2.Size = new System.Drawing.Size(1006, 471);
            this.splitPanel2.SizeInfo.AutoSizeScale = new System.Drawing.SizeF(0F, 0.3722222F);
            this.splitPanel2.SizeInfo.SplitterCorrection = new System.Drawing.Size(0, 201);
            this.splitPanel2.TabIndex = 1;
            this.splitPanel2.TabStop = false;
            this.splitPanel2.Text = "splitPanel2";
            this.splitPanel2.ThemeName = "Office2013Light";
            // 
            // DespieceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 662);
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
            this.gbInfoAlzado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbAgregarCapa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDespieceMuro.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDespieceMuro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdAyudaDespiece.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdAyudaDespiece)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radSplitContainer1)).EndInit();
            this.radSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel1)).EndInit();
            this.splitPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitPanel2)).EndInit();
            this.splitPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.RadThemeManager radThemeManager1;
        public Telerik.WinControls.UI.RadGroupBox gbInfoAlzado;
        public Telerik.WinControls.UI.RadGridView gvDespieceMuro;
        public Telerik.WinControls.UI.RadButton cbAgregarCapa;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        public Telerik.WinControls.UI.RadGridView rdAyudaDespiece;
        private Telerik.WinControls.UI.RadSplitContainer radSplitContainer1;
        private Telerik.WinControls.UI.SplitPanel splitPanel1;
        private Telerik.WinControls.UI.SplitPanel splitPanel2;
    }
}
