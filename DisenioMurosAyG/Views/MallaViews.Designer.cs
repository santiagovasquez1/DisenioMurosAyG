namespace DisenioMurosAyG.Views
{
    partial class MallaViews
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
            this.radThemeManager1 = new Telerik.WinControls.RadThemeManager();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.cbEliminar = new Telerik.WinControls.UI.RadButton();
            this.cbEditar = new Telerik.WinControls.UI.RadButton();
            this.cbNuevaMalla = new Telerik.WinControls.UI.RadButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ListaMallas = new Telerik.WinControls.UI.RadListControl();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNuevaMalla)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaMallas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox2.Controls.Add(this.cbEliminar);
            this.radGroupBox2.Controls.Add(this.cbEditar);
            this.radGroupBox2.Controls.Add(this.cbNuevaMalla);
            this.radGroupBox2.FooterText = "";
            this.radGroupBox2.FooterVisibility = Telerik.WinControls.ElementVisibility.Visible;
            this.radGroupBox2.HeaderText = "Comandos";
            this.radGroupBox2.Location = new System.Drawing.Point(259, 22);
            this.radGroupBox2.Name = "radGroupBox2";
            // 
            // 
            // 
            this.radGroupBox2.RootElement.BorderHighlightColor = System.Drawing.Color.White;
            this.radGroupBox2.RootElement.EnableBorderHighlight = false;
            this.radGroupBox2.RootElement.EnableFocusBorder = false;
            this.radGroupBox2.RootElement.EnableFocusBorderAnimation = false;
            this.radGroupBox2.RootElement.FocusBorderWidth = 3;
            this.radGroupBox2.Size = new System.Drawing.Size(212, 349);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Comandos";
            this.radGroupBox2.ThemeName = "Office2013Light";
            // 
            // cbEliminar
            // 
            this.cbEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEliminar.Location = new System.Drawing.Point(29, 234);
            this.cbEliminar.Name = "cbEliminar";
            this.cbEliminar.Size = new System.Drawing.Size(162, 56);
            this.cbEliminar.TabIndex = 1;
            this.cbEliminar.Text = "Eliminar Malla";
            this.cbEliminar.ThemeName = "Office2013Light";
            // 
            // cbEditar
            // 
            this.cbEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEditar.Location = new System.Drawing.Point(29, 127);
            this.cbEditar.Name = "cbEditar";
            this.cbEditar.Size = new System.Drawing.Size(162, 56);
            this.cbEditar.TabIndex = 1;
            this.cbEditar.Text = "Editar Malla";
            this.cbEditar.ThemeName = "Office2013Light";
            // 
            // cbNuevaMalla
            // 
            this.cbNuevaMalla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbNuevaMalla.Location = new System.Drawing.Point(29, 31);
            this.cbNuevaMalla.Name = "cbNuevaMalla";
            this.cbNuevaMalla.Size = new System.Drawing.Size(162, 56);
            this.cbNuevaMalla.TabIndex = 0;
            this.cbNuevaMalla.Text = "Crear Malla";
            this.cbNuevaMalla.ThemeName = "Office2013Light";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.radGroupBox2);
            this.groupBox1.Location = new System.Drawing.Point(7, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 389);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ListaMallas);
            this.groupBox2.Location = new System.Drawing.Point(18, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 349);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista de Mallas";
            // 
            // ListaMallas
            // 
            this.ListaMallas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListaMallas.Location = new System.Drawing.Point(6, 22);
            this.ListaMallas.Name = "ListaMallas";
            this.ListaMallas.Size = new System.Drawing.Size(207, 312);
            this.ListaMallas.TabIndex = 0;
            this.ListaMallas.ThemeName = "Office2013Light";
            // 
            // MallaViews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 396);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MallaViews";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Mallas";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNuevaMalla)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListaMallas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.RadThemeManager radThemeManager1;
        public Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        public Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        public Telerik.WinControls.UI.RadButton cbEliminar;
        public Telerik.WinControls.UI.RadButton cbEditar;
        public Telerik.WinControls.UI.RadButton cbNuevaMalla;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox groupBox2;
        public Telerik.WinControls.UI.RadListControl ListaMallas;
    }
}
