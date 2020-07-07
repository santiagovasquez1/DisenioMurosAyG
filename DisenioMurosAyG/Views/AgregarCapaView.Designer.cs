namespace DisenioMurosAyG.Views
{
    partial class AgregarCapaView
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
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.tbNombreCapa = new Telerik.WinControls.UI.RadTextBox();
            this.cbAceptar = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.ListTraslapo = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNombreCapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAceptar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListTraslapo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(16, 32);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(134, 21);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Nombre de la Capa:";
            this.radLabel1.ThemeName = "MaterialBlueGrey";
            // 
            // tbNombreCapa
            // 
            this.tbNombreCapa.Location = new System.Drawing.Point(170, 17);
            this.tbNombreCapa.Name = "tbNombreCapa";
            this.tbNombreCapa.Size = new System.Drawing.Size(101, 36);
            this.tbNombreCapa.TabIndex = 2;
            this.tbNombreCapa.ThemeName = "MaterialBlueGrey";
            // 
            // cbAceptar
            // 
            this.cbAceptar.Location = new System.Drawing.Point(76, 130);
            this.cbAceptar.Name = "cbAceptar";
            this.cbAceptar.Size = new System.Drawing.Size(120, 36);
            this.cbAceptar.TabIndex = 3;
            this.cbAceptar.Text = "Aceptar";
            this.cbAceptar.ThemeName = "MaterialBlueGrey";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(16, 81);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(116, 21);
            this.radLabel2.TabIndex = 4;
            this.radLabel2.Text = "Tipo de traslapo:";
            this.radLabel2.ThemeName = "MaterialBlueGrey";
            // 
            // ListTraslapo
            // 
            this.ListTraslapo.Location = new System.Drawing.Point(170, 66);
            this.ListTraslapo.Name = "ListTraslapo";
            this.ListTraslapo.Size = new System.Drawing.Size(100, 36);
            this.ListTraslapo.TabIndex = 5;
            this.ListTraslapo.Text = "radDropDownList1";
            this.ListTraslapo.ThemeName = "MaterialBlueGrey";
            // 
            // AgregarCapaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 189);
            this.Controls.Add(this.ListTraslapo);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.cbAceptar);
            this.Controls.Add(this.tbNombreCapa);
            this.Controls.Add(this.radLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AgregarCapaView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "AgregarCapaView";
            this.ThemeName = "MaterialBlueGrey";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNombreCapa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAceptar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListTraslapo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.RadThemeManager radThemeManager1;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        public Telerik.WinControls.UI.RadButton cbAceptar;
        public Telerik.WinControls.UI.RadTextBox tbNombreCapa;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        public Telerik.WinControls.UI.RadDropDownList ListTraslapo;
    }
}
