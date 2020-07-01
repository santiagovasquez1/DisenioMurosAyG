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
            Telerik.WinControls.ThemeSource themeSource1 = new Telerik.WinControls.ThemeSource();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.tbArchivoDiseno = new Telerik.WinControls.UI.RadTextBox();
            this.bCargar = new Telerik.WinControls.UI.RadButton();
            this.bAceptar = new Telerik.WinControls.UI.RadButton();
            this.cbGDE = new Telerik.WinControls.UI.RadDropDownList();
            this.tbArchivoDespiece = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbArchivoDiseno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCargar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGDE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbArchivoDespiece)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 23);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(207, 21);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Grado de disipacion de energia";
            this.radLabel1.ThemeName = "MaterialBlueGrey";
            // 
            // radThemeManager1
            // 
            themeSource1.StorageType = Telerik.WinControls.ThemeStorageType.Resource;
            themeSource1.ThemeLocation = "ss";
            this.radThemeManager1.LoadedThemes.AddRange(new Telerik.WinControls.ThemeSource[] {
            themeSource1});
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(12, 83);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(180, 21);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Archivo de excel de diseño";
            this.radLabel2.ThemeName = "MaterialBlueGrey";
            // 
            // tbArchivoDiseno
            // 
            this.tbArchivoDiseno.Location = new System.Drawing.Point(267, 68);
            this.tbArchivoDiseno.Name = "tbArchivoDiseno";
            this.tbArchivoDiseno.Size = new System.Drawing.Size(176, 36);
            this.tbArchivoDiseno.TabIndex = 4;
            this.tbArchivoDiseno.ThemeName = "MaterialBlueGrey";
            // 
            // bCargar
            // 
            this.bCargar.Location = new System.Drawing.Point(12, 182);
            this.bCargar.Name = "bCargar";
            this.bCargar.Size = new System.Drawing.Size(195, 36);
            this.bCargar.TabIndex = 5;
            this.bCargar.Text = "Cargar Archivos";
            this.bCargar.ThemeName = "MaterialBlueGrey";
            // 
            // bAceptar
            // 
            this.bAceptar.Location = new System.Drawing.Point(252, 182);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(191, 36);
            this.bAceptar.TabIndex = 6;
            this.bAceptar.Text = "Nuevo Proyecto";
            this.bAceptar.ThemeName = "MaterialBlueGrey";
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // cbGDE
            // 
            this.cbGDE.Location = new System.Drawing.Point(267, 17);
            this.cbGDE.Name = "cbGDE";
            this.cbGDE.Size = new System.Drawing.Size(176, 36);
            this.cbGDE.TabIndex = 7;
            this.cbGDE.Text = "radDropDownList1";
            this.cbGDE.ThemeName = "MaterialBlueGrey";
            // 
            // tbArchivoDespiece
            // 
            this.tbArchivoDespiece.Location = new System.Drawing.Point(267, 122);
            this.tbArchivoDespiece.Name = "tbArchivoDespiece";
            this.tbArchivoDespiece.Size = new System.Drawing.Size(176, 36);
            this.tbArchivoDespiece.TabIndex = 6;
            this.tbArchivoDespiece.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(12, 137);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(195, 21);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = "Archivo de excel de despiece";
            this.radLabel3.ThemeName = "MaterialBlueGrey";
            // 
            // InicioProyectoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 258);
            this.Controls.Add(this.tbArchivoDespiece);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.cbGDE);
            this.Controls.Add(this.bAceptar);
            this.Controls.Add(this.bCargar);
            this.Controls.Add(this.tbArchivoDiseno);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InicioProyectoView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "InicioPryecto2View";
            this.ThemeName = "MaterialBlueGrey";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbArchivoDiseno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bCargar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGDE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbArchivoDespiece)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        public Telerik.WinControls.UI.RadLabel radLabel1;
        public Telerik.WinControls.UI.RadLabel radLabel2;
        public Telerik.WinControls.UI.RadTextBox tbArchivoDiseno;
        public Telerik.WinControls.UI.RadButton bCargar;
        public Telerik.WinControls.UI.RadButton bAceptar;
        public Telerik.WinControls.UI.RadDropDownList cbGDE;
        public Telerik.WinControls.UI.RadTextBox tbArchivoDespiece;
        public Telerik.WinControls.UI.RadLabel radLabel3;
    }
}
