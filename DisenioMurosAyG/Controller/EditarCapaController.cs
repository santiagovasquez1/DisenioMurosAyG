using DataAcces;
using DisenioMurosAyG.Views;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisenioMurosAyG.Controller
{
    public class EditarCapaController
    {
        public Alzado AlzadoSeleccionado { get; set; }
        public EditarCapaView EditarCapaView { get; set; }
        public CapaRefuerzo CapaRefuerzo { get; set; }
        public ModeloContext _contex { get; set; }
        public DespieceController DespieceController { get; set; }
        public TipoEdicionCapa TipoEdicionCapa { get; set; }

        public EditarCapaController(EditarCapaView editarCapaView, CapaRefuerzo capaRefuerzo,Alzado alzado,DespieceController despieceController,TipoEdicionCapa tipoEdicionCapa)
        {
            CapaRefuerzo = capaRefuerzo;
            AlzadoSeleccionado = alzado;
            EditarCapaView = editarCapaView;
            DespieceController = despieceController;
            TipoEdicionCapa = tipoEdicionCapa;

            EditarCapaView.MaximizeBox = false;
            EditarCapaView.MinimizeBox = false;

            EditarCapaView.ListTraslapo.DataSource = Enum.GetValues(typeof(Traslapo));
            EditarCapaView.tbNombreCapa.DataBindings.Add("Text", CapaRefuerzo, "CapaNombre", true, DataSourceUpdateMode.OnPropertyChanged);
            EditarCapaView.tbNumeroCapas.DataBindings.Add("Text", CapaRefuerzo, "Cantidad", true, DataSourceUpdateMode.OnPropertyChanged);
            EditarCapaView.ListTraslapo.DataBindings.Add("Text", CapaRefuerzo, "Traslapo", true, DataSourceUpdateMode.OnPropertyChanged);

            EditarCapaView.cbAceptar.Click += new EventHandler(AceptarCapaClick);
            EditarCapaView.FormClosing += new FormClosingEventHandler(SendInfo);
        }

        private void SendInfo(object sender, FormClosingEventArgs e)
        {
            switch (TipoEdicionCapa)
            {
                case TipoEdicionCapa.Nuevo:
                    DespieceController.AddCapaDespiece();
                    break;
                case TipoEdicionCapa.Editar:
                    DespieceController.EditarCapaDespiece();
                    break;
            }

        }

        private void AceptarCapaClick(object sender, EventArgs e)
        {
            if (CapaRefuerzo.CapaNombre != null)
            {
                EditarCapaView.Close();
            }

        }
    }
}
