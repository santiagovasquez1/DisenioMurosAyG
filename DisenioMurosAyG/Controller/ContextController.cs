using DataAcces;
using DisenioMurosAyG.Views;
using Entidades;
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
        public ToolTip ToolTipTb { get; set; }

        public ContextController(InicioProyectoView proyectoView)
        {
            InicioView = proyectoView;
            _contex = Program._context;
            InicioView.cbGDE.DropDownStyle = ComboBoxStyle.DropDownList;
            InicioView.cbGDE.DataSource = Enum.GetValues(typeof(GradoDisipacionEnergia));
            InicioView.cbGDE.SelectedIndexChanged += new EventHandler(SetGDEProyecto);

            InicioView.tbArchivoDiseno.Enabled = false;
            InicioView.tbArchivoDiseno.MouseHover += new EventHandler(tbArchivoMouseHover);
            InicioView.tbArchivoDiseno.MouseLeave += new EventHandler(tbArchivoMouseLeave);

            InicioView.bCargar.Click += new EventHandler(CargarArchivosClick);
            InicioView.bAceptar.Click += new EventHandler(NuevoProyectoClick);
        }

        private void NuevoProyectoClick(object sender, EventArgs e)
        {
            if (_contex.RutaArchivoDisenio != null)
            {
                _contex.LoadDisenioContext();
                InformacionAlzadoView informacionAlzadoView = new InformacionAlzadoView();
                informacionAlzadoView.Show();
            }
        }

        private void CargarArchivosClick(object sender, EventArgs e)
        {
            using (OpenFileDialog File = new OpenFileDialog())
            {
                File.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                File.FilterIndex = 1;
                File.RestoreDirectory = true;

                if (File.ShowDialog() == DialogResult.OK)
                {
                    _contex.RutaArchivoDisenio = File.FileName;
                    InicioView.tbArchivoDiseno.Text = _contex.RutaArchivoDisenio;

                    ToolTipTb = new ToolTip();
                    ToolTipTb.SetToolTip(InicioView.tbArchivoDiseno, _contex.RutaArchivoDisenio);
                }
            }
        }

        private void tbArchivoMouseHover(object sender, EventArgs e)
        {
            if (ToolTipTb != null)
            {
                ToolTipTb.Show(_contex.RutaArchivoDisenio, InicioView.tbArchivoDiseno);
            }
        }

        private void tbArchivoMouseLeave(object sender, EventArgs e)
        {
            if (ToolTipTb != null)
            {
                ToolTipTb.Hide(InicioView.tbArchivoDiseno);
            }
        }


        private void SetGDEProyecto(object sender, EventArgs e)
        {
            _contex.GradoDisipacionEnergia = (GradoDisipacionEnergia)InicioView.cbGDE.SelectedItem;
        }
    }
}
