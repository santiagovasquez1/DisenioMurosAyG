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
        public ModeloContext _context { get; set; }
        public ContextView ContextView { get; set; }
        public DespieceController DespieceController { get; set; }
        public AlzadoController AlzadoController { get; set; }
        public MallaController MallaController { get; set; }
        public MurosViewController MurosViewController { get; set; }
        public VariablesDibujoController VariablesDibujoController { get; set; }
        public Alzado AlzadoSeleccionado { get; set; }
        public RadForm ControlActivo { get; set; }
        public int TabIndex { get; set; }
        public ContextController(ContextView contextView)
        {
            _context = Program._context;
            ContextView = contextView;

            contextView.radRibbonBar1.OptionsButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            contextView.cbNuevo.Click += new EventHandler(NuevoCommand);
            contextView.ListViewAlzados.MultiSelect = false;
            contextView.ListViewAlzados.SelectedIndexChanged += new EventHandler(SeleccionAlzadoCommand);
            contextView.cbListMuros.Click += new EventHandler(OpenListMurosClick);
            contextView.cbVariablesDibujo.Click += new EventHandler(VariablesDibujoClick);
            contextView.cbMAlla.Click += new EventHandler(MallaClick);
            contextView.ViePageContainer.SelectedPageChanged += new EventHandler(SelectPageCommand);
            contextView.cbGuardar.Click += new EventHandler(GuardarCommand);
            contextView.cbGuardarComo.Click += new EventHandler(GuardarComoCommand);
            contextView.cbCargar.Click += new EventHandler(CargarCommand);
        }

        private void CargarCommand(object sender, EventArgs e)
        {
            using (OpenFileDialog File = new OpenFileDialog())
            {
                File.Title = "Cargar Proyecto de muros de concreto";
                File.Filter = "AyG files (*.walls)|*.walls|All files (*.*)|*.*";
                File.FilterIndex = 1;
                File.RestoreDirectory = true;

                if (File.ShowDialog() == DialogResult.OK)
                {
                    Program.RutaProyecto = File.FileName;
                    var context = _context;
                    ModeloSerialization.Deserealizar(Program.RutaProyecto, ref context);
                    Program._context = context;
                    _context = Program._context;
                    ContextView.ListViewAlzados.DataSource = _context.Alzados;
                    var DefaultItemSelect = ContextView.ListViewAlzados.Items[0];
                    ContextView.ListViewAlzados.SelectedItem = DefaultItemSelect;

                    ContextView.cbListMuros.Enabled = true;
                    ContextView.ViePageContainer.Enabled = true;
                }
            }

        }

        private void GuardarComoCommand(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Diseño muros concreto |*.walls";
            saveFileDialog.Title = "Guardar proyecto";
            DialogResult dr = saveFileDialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                Program.RutaProyecto = saveFileDialog.FileName;
                ModeloSerialization.Serializar(Program.RutaProyecto, _context);
            }
        }

        private void GuardarCommand(object sender, EventArgs e)
        {
            if (Program.RutaProyecto == null)
            {
                GuardarComoCommand(sender, e);
            }
            else
            {
                ModeloSerialization.Serializar(Program.RutaProyecto, _context);
            }
        }

        private void SelectPageCommand(object sender, EventArgs e)
        {
            var ContextViewPage = ContextView.ViePageContainer.SelectedPage;
            TabIndex = ContextViewPage.TabIndex;
            if (TabIndex == 0)
            {
                InfoGeneralClick();
            }
            else
            {
                DespieceClick();
            }

        }

        private void MallaClick(object sender, EventArgs e)
        {
            var MallaView = new MallaViews();
            MallaController = new MallaController(MallaView);
            MallaView.ShowDialog();
        }

        private void VariablesDibujoClick(object sender, EventArgs e)
        {
            var variablesdibujoView = new VariablesDibujoView();
            VariablesDibujoController = new VariablesDibujoController(variablesdibujoView);
            variablesdibujoView.ShowDialog();
        }

        private void OpenListMurosClick(object sender, EventArgs e)
        {

            var listaMurosView = new MurosView();
            MurosViewController = new MurosViewController(listaMurosView);
            listaMurosView.ShowDialog();
        }

        private void DespieceClick()
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
                    Cargar_Formularios.Open_From_Panel(ContextView.ViewPageDespiece, DespieceMuro);
                    ControlActivo = DespieceMuro;
                }
            }
        }

        private void InfoGeneralClick()
        {
            //LoadInfoAlzado();

            if (AlzadoSeleccionado != null)
            {
                var InformacionAlzado = new InformacionAlzadoView1();
                AlzadoController = new AlzadoController(InformacionAlzado, AlzadoSeleccionado);
                Cargar_Formularios.Open_From_Panel(ContextView.ViewPageAlzado, InformacionAlzado);
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
                        Cargar_Formularios.Open_From_Panel(ContextView.ViewPageAlzado, InformacionAlzado);
                        break;
                    case "DespieceView":
                        var DespieceMuro = new DespieceView();
                        DespieceController = new DespieceController(DespieceMuro, AlzadoSeleccionado);
                        Cargar_Formularios.Open_From_Panel(ContextView.ViewPageDespiece, DespieceMuro);
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
