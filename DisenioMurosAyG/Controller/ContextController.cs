using DataAcces;
using DisenioMurosAyG.ClasesEstaticas;
using DisenioMurosAyG.Views;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace DisenioMurosAyG.Controller
{
    public class ContextController
    {
        public ModeloContext _contex { get; set; }
        public ContextView ContextView { get; set; }
        public AlzadoController AlzadoController { get; set; }
        public Alzado AlzadoSeleccionado { get; set; }

        public ContextController(ContextView contextView)
        {
            _contex = Program._context;
            ContextView = contextView;
            var stilo = contextView.radMenuHeaderItem1.Style;
            contextView.radRibbonBar1.OptionsButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            contextView.cbNuevo.Click += new EventHandler(NuevoCommand);
            contextView.ListViewAlzados.MultiSelect = false;
            contextView.ListViewAlzados.SelectedIndexChanged += new EventHandler(SeleccionAlzadoCommand);
        }

        private void SeleccionAlzadoCommand(object sender, EventArgs e)
        {
            var control = sender as RadListViewElement;

            var indice = control.SelectedIndex;
            indice = control.SelectedIndex < 0 ? 0 : control.SelectedIndex;

            AlzadoSeleccionado = control.Items[indice].Value as Alzado;

            if (AlzadoSeleccionado != null)
            {
                var InformacionAlzado = new InformacionAlzadoView1();
                AlzadoController = new AlzadoController(InformacionAlzado, AlzadoSeleccionado);
                Cargar_Formularios.Open_From_Panel(ContextView.radPanel1, InformacionAlzado);
            }

            //try
            //{
            //    var indice =(RadListView)sender.SelectedIndex;
            //    if (prueba != null)
            //    {
            //        AlzadoSeleccionado = (Alzado)prueba.Value;
            //        var InformacionAlzado = new InformacionAlzadoView1();
            //        AlzadoController = new AlzadoController(InformacionAlzado,AlzadoSeleccionado);                   
            //        Cargar_Formularios.Open_From_Panel(ContextView.radPanel1, InformacionAlzado);
            //    }
            //}
            //catch (Exception mensaje)
            //{
            //    System.Windows.Forms.MessageBox.Show(mensaje.Message);
            //}
        }

        private void NuevoCommand(object sender, EventArgs e)
        {
            var inicioView = new InicioProyectoView();
            inicioView.Show();
        }
    }
}
