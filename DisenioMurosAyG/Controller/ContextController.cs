using DataAcces;
using DisenioMurosAyG.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisenioMurosAyG.Controller
{
    public class ContextController
    {
        public ModeloContext _contex { get; set; }
        public InicioProyectoView InicioView { get; set; }

        public ContextController(InicioProyectoView proyectoView)
        {
            InicioView = proyectoView;
            _contex = Program._context;

            var bindingGde = new BindingSource();
            bindingGde.DataSource = _contex.GradoDisipacionEnergia.toList ();

            InicioView.cbGDE.DataSource = bindingGde.DataSource;

        }
    }
}
