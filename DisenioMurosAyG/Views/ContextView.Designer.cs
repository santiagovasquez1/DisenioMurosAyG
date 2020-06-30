namespace DisenioMurosAyG.Views
{
    partial class ContextView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContextView));
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.radMenuHeaderItem1 = new Telerik.WinControls.UI.RadMenuHeaderItem();
            this.ribbonTab2 = new Telerik.WinControls.UI.RibbonTab();
            this.radRibbonBarGroup1 = new Telerik.WinControls.UI.RadRibbonBarGroup();
            this.ribbonTab3 = new Telerik.WinControls.UI.RibbonTab();
            this.cbNuevo = new Telerik.WinControls.UI.RadMenuItem();
            this.cbCargar = new Telerik.WinControls.UI.RadMenuItem();
            this.cbGuardar = new Telerik.WinControls.UI.RadMenuItem();
            this.radRibbonBar1 = new Telerik.WinControls.UI.RadRibbonBar();
            this.PanelAlzados = new Telerik.WinControls.UI.RadScrollablePanel();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.ListViewAlzados = new Telerik.WinControls.UI.RadListView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PanelAlzados)).BeginInit();
            this.PanelAlzados.PanelContainer.SuspendLayout();
            this.PanelAlzados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListViewAlzados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radMenuHeaderItem1
            // 
            this.radMenuHeaderItem1.Name = "radMenuHeaderItem1";
            this.radMenuHeaderItem1.Text = "radMenuHeaderItem1";
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.AutoEllipsis = false;
            this.ribbonTab2.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.ribbonTab2.IsSelected = true;
            this.ribbonTab2.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radRibbonBarGroup1});
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Text = "Información General";
            this.ribbonTab2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.ribbonTab2.UseCompatibleTextRendering = false;
            this.ribbonTab2.UseMnemonic = false;
            // 
            // radRibbonBarGroup1
            // 
            this.radRibbonBarGroup1.MaxSize = new System.Drawing.Size(0, 144);
            this.radRibbonBarGroup1.MinSize = new System.Drawing.Size(70, 144);
            this.radRibbonBarGroup1.Name = "radRibbonBarGroup1";
            this.radRibbonBarGroup1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.radRibbonBarGroup1.Text = "Modelo";
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.AutoEllipsis = false;
            this.ribbonTab3.DisabledTextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.ribbonTab3.Name = "ribbonTab3";
            this.ribbonTab3.Text = "Despiece muros concreto";
            this.ribbonTab3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.ribbonTab3.UseCompatibleTextRendering = false;
            this.ribbonTab3.UseMnemonic = false;
            // 
            // cbNuevo
            // 
            this.cbNuevo.Name = "cbNuevo";
            this.cbNuevo.Text = "Nuevo";
            this.cbNuevo.UseCompatibleTextRendering = false;
            // 
            // cbCargar
            // 
            this.cbCargar.Name = "cbCargar";
            this.cbCargar.Text = "Abrir";
            this.cbCargar.UseCompatibleTextRendering = false;
            // 
            // cbGuardar
            // 
            this.cbGuardar.Name = "cbGuardar";
            this.cbGuardar.Text = "Cargar";
            this.cbGuardar.UseCompatibleTextRendering = false;
            // 
            // radRibbonBar1
            // 
            this.radRibbonBar1.CommandTabs.AddRange(new Telerik.WinControls.RadItem[] {
            this.ribbonTab2,
            this.ribbonTab3});
            // 
            // 
            // 
            // 
            // 
            // 
            this.radRibbonBar1.ExitButton.ButtonElement.ShowBorder = false;
            this.radRibbonBar1.ExitButton.Text = "Salir";
            this.radRibbonBar1.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radRibbonBar1.LocalizationSettings.LayoutModeText = "Simplified Layout";
            this.radRibbonBar1.Location = new System.Drawing.Point(0, 0);
            this.radRibbonBar1.Name = "radRibbonBar1";
            // 
            // 
            // 
            // 
            // 
            // 
            this.radRibbonBar1.OptionsButton.ButtonElement.ShowBorder = false;
            this.radRibbonBar1.OptionsButton.Text = "Options";
            this.radRibbonBar1.OptionsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            // 
            // 
            // 
            this.radRibbonBar1.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren;
            this.radRibbonBar1.SimplifiedHeight = 140;
            this.radRibbonBar1.Size = new System.Drawing.Size(1088, 245);
            this.radRibbonBar1.StartButtonImage = ((System.Drawing.Image)(resources.GetObject("radRibbonBar1.StartButtonImage")));
            this.radRibbonBar1.StartMenuItems.AddRange(new Telerik.WinControls.RadItem[] {
            this.cbNuevo,
            this.cbCargar,
            this.cbGuardar});
            this.radRibbonBar1.TabIndex = 0;
            this.radRibbonBar1.Text = "InformacionAlzadoView1";
            this.radRibbonBar1.ThemeName = "MaterialBlueGrey";
            // 
            // PanelAlzados
            // 
            this.PanelAlzados.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelAlzados.Location = new System.Drawing.Point(0, 245);
            this.PanelAlzados.Name = "PanelAlzados";
            this.PanelAlzados.Padding = new System.Windows.Forms.Padding(0);
            // 
            // PanelAlzados.PanelContainer
            // 
            this.PanelAlzados.PanelContainer.Controls.Add(this.radGroupBox1);
            this.PanelAlzados.PanelContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelAlzados.PanelContainer.Size = new System.Drawing.Size(212, 361);
            this.PanelAlzados.Size = new System.Drawing.Size(212, 361);
            this.PanelAlzados.TabIndex = 1;
            this.PanelAlzados.ThemeName = "MaterialBlueGrey";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.ListViewAlzados);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold);
            this.radGroupBox1.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox1.HeaderText = "Lista de muros";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(212, 361);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.Text = "Lista de muros";
            this.radGroupBox1.ThemeName = "MaterialBlueGrey";
            // 
            // ListViewAlzados
            // 
            this.ListViewAlzados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListViewAlzados.GroupItemSize = new System.Drawing.Size(200, 36);
            this.ListViewAlzados.ItemSize = new System.Drawing.Size(200, 36);
            this.ListViewAlzados.Location = new System.Drawing.Point(7, 34);
            this.ListViewAlzados.Name = "ListViewAlzados";
            this.ListViewAlzados.Size = new System.Drawing.Size(200, 315);
            this.ListViewAlzados.TabIndex = 0;
            this.ListViewAlzados.ThemeName = "MaterialBlueGrey";
            this.ListViewAlzados.SelectedItemChanged += new System.EventHandler(this.ListViewAlzados_SelectedItemChanged);
            // 
            // radPanel1
            // 
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(212, 245);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(876, 361);
            this.radPanel1.TabIndex = 2;
            this.radPanel1.ThemeName = "MaterialBlueGrey";
            // 
            // ContextView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 606);
            this.Controls.Add(this.radPanel1);
            this.Controls.Add(this.PanelAlzados);
            this.Controls.Add(this.radRibbonBar1);
            this.MainMenuStrip = null;
            this.Name = "ContextView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "InformacionAlzadoView1";
            this.ThemeName = "MaterialBlueGrey";
            ((System.ComponentModel.ISupportInitialize)(this.radRibbonBar1)).EndInit();
            this.PanelAlzados.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PanelAlzados)).EndInit();
            this.PanelAlzados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListViewAlzados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Telerik.WinControls.UI.RibbonTab ribbonTab2;
        public Telerik.WinControls.UI.RibbonTab ribbonTab3;
        public Telerik.WinControls.UI.RadMenuItem cbNuevo;
        public Telerik.WinControls.UI.RadMenuItem cbCargar;
        public Telerik.WinControls.UI.RadMenuItem cbGuardar;
        public Telerik.WinControls.UI.RadRibbonBar radRibbonBar1;
        public Telerik.WinControls.UI.RadRibbonBarGroup radRibbonBarGroup1;
        public Telerik.WinControls.RadThemeManager radThemeManager1;
        public Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        public Telerik.WinControls.UI.RadMenuHeaderItem radMenuHeaderItem1;
        public Telerik.WinControls.UI.RadScrollablePanel PanelAlzados;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        public Telerik.WinControls.UI.RadListView ListViewAlzados;
        public Telerik.WinControls.UI.RadPanel radPanel1;
    }
}
