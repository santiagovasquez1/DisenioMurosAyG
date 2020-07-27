using DataAcces;
using DisenioMurosAyG.Views;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisenioMurosAyG.Controller
{
    public class EditarMallaController
    {
        public EditarMallaView EditarMallaView { get; set; }
        public MallaViews MallaView { get; set; }
        public Malla Malla { get; set; }
        public ModeloContext _context { get; set; }

        public EditarMallaController(EditarMallaView editarMallaView, MallaViews mallaViews, Malla malla)
        {
            _context = Program._context;
            EditarMallaView = editarMallaView;
            MallaView = mallaViews;
            Malla = malla;

            EditarMallaView.lbDiametros.DataSource = Enum.GetValues(typeof(Diametro));

            EditarMallaView.tbDenominacion.DataBindings.Add("Text", Malla, "DenomMallla", true, DataSourceUpdateMode.OnPropertyChanged);
            EditarMallaView.lbDiametros.DataBindings.Add("Text", Malla, "Diametro", true, DataSourceUpdateMode.OnPropertyChanged);
            EditarMallaView.tbSeparacionHorizontal.DataBindings.Add("Text", Malla, "SeparacionHorizontal", true, DataSourceUpdateMode.OnPropertyChanged);
            EditarMallaView.tbSeparacionVertical.DataBindings.Add("Text", Malla, "SeparacionVertical", true, DataSourceUpdateMode.OnPropertyChanged);
            EditarMallaView.tbCapas.DataBindings.Add("Text", Malla, "Capas", true, DataSourceUpdateMode.OnPropertyChanged);
            EditarMallaView.tbEspesor.DataBindings.Add("Text", Malla, "Espesor", true, DataSourceUpdateMode.OnPropertyChanged);
            EditarMallaView.tbAsHorizontal.DataBindings.Add("Text", Malla, "AsHorizontal", true, DataSourceUpdateMode.OnPropertyChanged);
            EditarMallaView.tbAsVertical.DataBindings.Add("Text", Malla, "AsVertical", true, DataSourceUpdateMode.OnPropertyChanged);
            EditarMallaView.tbRhoMallaHorizontal.DataBindings.Add("Text", Malla, "RhoHorizontal", true, DataSourceUpdateMode.OnPropertyChanged);
            EditarMallaView.tbRhoMallaVertical.DataBindings.Add("Text", Malla, "RhoVertical", true, DataSourceUpdateMode.OnPropertyChanged);

            EditarMallaView.cbAceptar.Click += new EventHandler(AceptarMallaClick);
            EditarMallaView.cbCancelar.Click += new EventHandler(CancelarClick);
        }

        private void CancelarClick(object sender, EventArgs e)
        {
            //MallaView.Visible = true;
            EditarMallaView.Close();
        }

        private void AceptarMallaClick(object sender, EventArgs e)
        {
            if (_context.Mallas != null)
            {
                if (_context.Mallas.ToList().Exists(x => x.MallaId == Malla.MallaId) == false)
                    _context.Mallas.Add(Malla);
            }
            else
            {
                _context.Mallas = new List<Malla>
                {
                    Malla
                };
            }

            MallaView.Visible = true;
            EditarMallaView.Close();
        }
    }
}
