using DataAcces;
using DisenioMurosAyG.ClasesEstaticas;
using DisenioMurosAyG.Views;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace DisenioMurosAyG.Controller
{
    public class ContextController
    {
        public ModeloContext _contex { get; set; }
        public ContextView ContextView { get; set; }
        public DespieceController DespieceController { get; set; }
        public AlzadoController AlzadoController { get; set; }
        public Alzado AlzadoSeleccionado { get; set; }
        public RadForm ControlActivo { get; set; }
        public ContextController(ContextView contextView)
        {
            _contex = Program._context;
            ContextView = contextView;            
            contextView.radRibbonBar1.OptionsButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            contextView.cbNuevo.Click += new EventHandler(NuevoCommand);
            contextView.ListViewAlzados.MultiSelect = false;
            contextView.ListViewAlzados.SelectedIndexChanged += new EventHandler(SeleccionAlzadoCommand);
            contextView.Infogeneraltab.Click += new EventHandler(InfoGeneralClick);
            contextView.DespieceTab.Click += new EventHandler(DespieceClick);
        }

        private void DespieceClick(object sender, EventArgs e)
        {
            var control = ContextView.ListViewAlzados;
            if (control != null)
            {
                var indice = control.SelectedIndex;
                indice = control.SelectedIndex < 0 ? 0 : control.SelectedIndex;

                AlzadoSeleccionado = control.Items[indice].Value as Alzado;

                if (AlzadoSeleccionado != null)
                {
                    var DespieceMuro = new DespieceView();
                    DespieceController = new DespieceController(DespieceMuro, AlzadoSeleccionado);
                    Cargar_Formularios.Open_From_Panel(ContextView.radPanel1, DespieceMuro);
                    ControlActivo = DespieceMuro;
                }
            }
        }

        private void InfoGeneralClick(object sender, EventArgs e)
        {
            LoadInfoAlzado();

            if (AlzadoSeleccionado != null)
            {
                var InformacionAlzado = new InformacionAlzadoView1();
                AlzadoController = new AlzadoController(InformacionAlzado, AlzadoSeleccionado);
                Cargar_Formularios.Open_From_Panel(ContextView.radPanel1, InformacionAlzado);
                ControlActivo = InformacionAlzado;
            }
        }

        private void SeleccionAlzadoCommand(object sender, EventArgs e)
        {
            LoadInfoAlzado();
        }

        private void LoadInfoAlzado()
        {
            var control = ContextView.ListViewAlzados;

            var indice = control.SelectedIndex;
            indice = control.SelectedIndex < 0 ? 0 : control.SelectedIndex;
            AlzadoSeleccionado = control.Items[indice].Value as Alzado;

            LoadAnyControl();
        }

        private void LoadAnyControl()
        {
            if (ControlActivo != null)
            {
                var Tipo = ControlActivo.GetType();

                switch (Tipo.Name)
                {
                    case "InformacionAlzadoView1":
                        var InformacionAlzado = new InformacionAlzadoView1();
                        AlzadoController = new AlzadoController(InformacionAlzado, AlzadoSeleccionado);
                        Cargar_Formularios.Open_From_Panel(ContextView.radPanel1, InformacionAlzado);
                        break;
                    case "DespieceView":
                        var DespieceMuro = new DespieceView();
                        DespieceController = new DespieceController(DespieceMuro, AlzadoSeleccionado);
                        Cargar_Formularios.Open_From_Panel(ContextView.radPanel1, DespieceMuro);
                        break;
                }

            }

        }

        private void NuevoCommand(object sender, EventArgs e)
        {
            var inicioView = new InicioProyectoView();
            inicioView.Show();
        }
    }
}
