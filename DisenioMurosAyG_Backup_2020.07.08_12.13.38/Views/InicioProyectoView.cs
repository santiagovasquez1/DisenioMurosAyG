using DisenioMurosAyG.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace DisenioMurosAyG.Views
{
    public partial class InicioProyectoView : Telerik.WinControls.UI.RadForm
    {
        public InicioProyectoView()
        {
            InitializeComponent();
            var contextcontroller = Program.ContextController;
            InicioController inicioController = new InicioController(this,contextcontroller);
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {

        }

        private void cbGDE_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }
    }
}
