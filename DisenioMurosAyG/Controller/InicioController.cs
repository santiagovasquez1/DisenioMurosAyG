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
    public class InicioController
    {
        public ModeloContext _contex { get; set; }
        public InicioProyectoView InicioView { get; set; }
        public ToolTip ToolTipTb { get; set; }
        ContextController ContextController { get; set; }

        public InicioController(InicioProyectoView proyectoView, ContextController contextController)
        {
            InicioView = proyectoView;
            ContextController = contextController;
            _contex = Program._context;

            InicioView.cbGDE.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            InicioView.cbGDE.DataSource = Enum.GetValues(typeof(GradoDisipacionEnergia));
            InicioView.cbGDE.SelectedIndexChanged += new PositionChangedEventHandler(SetGDEProyecto);

            InicioView.tbArchivoDiseno.Enabled = false;
            InicioView.tbArchivoDespiece.Enabled = false;

            InicioView.tbArchivoDiseno.MouseHover += new EventHandler(tbArchivoMouseHover);
            InicioView.tbArchivoDiseno.MouseLeave += new EventHandler(tbArchivoMouseLeave);

            InicioView.bCargar.Click += new EventHandler(CargarArchivosClick);
            InicioView.bAceptar.Click += new EventHandler(NuevoProyectoClick);
        }

        private void NuevoProyectoClick(object sender, EventArgs e)
        {
            if (_contex.RutaArchivoDisenio != null && _contex.RutaArchivoDespiece!=null)
            {
                _contex.LoadDisenioContext();
                _contex.LoadDespieceContext();

                ContextController.ContextView.ListViewAlzados.DataSource = _contex.Alzados;
                var DefaultItemSelect = ContextController.ContextView.ListViewAlzados.Items[0];
                ContextController.ContextView.ListViewAlzados.SelectedItem = DefaultItemSelect;

                InicioView.Close();
            }
        }

        private void CargarArchivosClick(object sender, EventArgs e)
        {
            OpenFileMethod("Archivo con información de diseño", InicioView.tbArchivoDiseno, 1);
            OpenFileMethod("Archivo con el despiece de los muros", InicioView.tbArchivoDespiece, 2);

            ContextController.ContextView.cbListMuros.Enabled = true;
            ContextController.ContextView.ViePageContainer.Enabled = true;
        }

        private void OpenFileMethod(string titulo, Telerik.WinControls.UI.RadTextBox textBox, int tipo)
        {
            using (OpenFileDialog File = new OpenFileDialog())
            {
                File.Title = titulo;
                File.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                File.FilterIndex = 1;
                File.RestoreDirectory = true;

                if (File.ShowDialog() == DialogResult.OK)
                {
                    if (tipo == 1)
                        _contex.RutaArchivoDisenio = File.FileName;
                    if (tipo == 2)
                        _contex.RutaArchivoDespiece = File.FileName;

                    textBox.Text = _contex.RutaArchivoDisenio;

                    ToolTipTb = new ToolTip();
                    ToolTipTb.SetToolTip(textBox, textBox.Text);
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
            _contex.GradoDisipacionEnergia = (GradoDisipacionEnergia)InicioView.cbGDE.SelectedItem.Value;
        }
    }
}
