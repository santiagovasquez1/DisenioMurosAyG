using DisenioMurosAyG.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DisenioMurosAyG.Views
{
    public partial class ContextView : Telerik.WinControls.UI.RadRibbonForm
    {
        public ContextView()
        {
            InitializeComponent();
            //var ContextController = new ContextController(this);
        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void ListViewAlzados_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}
