namespace DisenioMurosAyG.Views
{
    partial class AlzadoDespieceView
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.pbAlzadoDespiece = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlzadoDespiece)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.pbAlzadoDespiece);
            this.radGroupBox1.HeaderText = "Vista Alzado Despiece";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(541, 532);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Vista Alzado Despiece";
            this.radGroupBox1.ThemeName = "Office2013Light";
            // 
            // pbAlzadoDespiece
            // 
            this.pbAlzadoDespiece.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbAlzadoDespiece.BackColor = System.Drawing.Color.Gainsboro;
            this.pbAlzadoDespiece.Location = new System.Drawing.Point(2, 18);
            this.pbAlzadoDespiece.Name = "pbAlzadoDespiece";
            this.pbAlzadoDespiece.Size = new System.Drawing.Size(537, 512);
            this.pbAlzadoDespiece.TabIndex = 0;
            this.pbAlzadoDespiece.TabStop = false;
            // 
            // AlzadoDespieceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 556);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "AlzadoDespieceView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "AlzadoDespieceView";
            this.ThemeName = "Office2013Light";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAlzadoDespiece)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Telerik.WinControls.RadThemeManager radThemeManager1;
        public Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        public Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        public System.Windows.Forms.PictureBox pbAlzadoDespiece;
    }
}
