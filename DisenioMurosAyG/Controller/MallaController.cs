using DataAcces;
using DisenioMurosAyG.Views;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI.Data;

namespace DisenioMurosAyG.Controller
{
    public class MallaController
    {
        public MallaViews MallaView { get; set; }
        public ModeloContext _context { get; set; }
        public EditarMallaController EditarMallaController { get; set; }
        public Malla MallaSeleccionada { get; set; }

        public MallaController(MallaViews mallaView)
        {
            MallaView = mallaView;
            _context = Program._context;

            MallaView.cbNuevaMalla.Click += new EventHandler(CrearMallaClick);
            MallaView.cbEditar.Click += new EventHandler(EditarMallaClick);
            MallaView.cbEliminar.Click += new EventHandler(EliminarMallaClick);

            MallaView.ListaMallas.DataSource = _context.Mallas;

            MallaView.ListaMallas.DataBindings.Add("Text", this, "MallaSeleccionada", true, DataSourceUpdateMode.OnPropertyChanged);
            //MallaView.ListaMallas.SelectedIndexChanged += new PositionChangedEventHandler(SeleccionMallaCommand);
        }

        private void SeleccionMallaCommand(object sender, PositionChangedEventArgs e)
        {
            var Indice = e.Position;
            MallaSeleccionada = _context.Mallas[Indice];
        }

        private void EliminarMallaClick(object sender, EventArgs e)
        {

        }

        private void EditarMallaClick(object sender, EventArgs e)
        {
            var editarMallaView = new EditarMallaView();
            EditarMallaController = new EditarMallaController(editarMallaView,MallaView, MallaSeleccionada);
            MallaView.Visible = false;
            editarMallaView.ShowDialog();
        }

        private void CrearMallaClick(object sender, EventArgs e)
        {
            var editarMallaView = new EditarMallaView();
            EditarMallaController = new EditarMallaController(editarMallaView, MallaView, new Malla());
            MallaView.Visible = false;
            editarMallaView.ShowDialog();
        }
    }
}
