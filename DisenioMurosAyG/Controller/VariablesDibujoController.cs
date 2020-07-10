using DisenioMurosAyG.Views;
using System;
using System.Collections.Generic;
using FunctionsAutoCAD;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAcces;
using DibujoAutomaticoAlzados;
using Entidades;
using Telerik.WinControls;
using System.ComponentModel;

namespace DisenioMurosAyG.Controller
{
    public class VariablesDibujoController
    { 
        public VariablesDibujoView VariablesDibujoView { get; set; }
        public List<string> LayersModelo { get; set; }
        public BindingList<Alzado> Alzados { get; set; }
        public ModeloContext _context { get; set; }
        public string LayerCoco { get; set; }
        public string LayerHatchEBE { get; set; }
        public string LayerTexto { get; set; }
        public string LayerCota { get; set; }
        public float HLosa { get; set; }

        public VariablesDibujoController(VariablesDibujoView variablesDibujoView)
        {
            _context = Program._context;
            LayersModelo = Program.LayersModelo;
            VariablesDibujoView = variablesDibujoView;
            VariablesDibujoView.cbVariables.Click += new EventHandler(CargarVariablesCommand);
            VariablesDibujoView.cbDibujar.Click += new EventHandler(DibujarAlzadoCommand);

            if (_context.Alzados != null)
            {
                Alzados = _context.Alzados;
                VariablesDibujoView.cbDibujar.Enabled = true;
            }

            else
                VariablesDibujoView.cbDibujar.Enabled = false;

            if (LayersModelo != null)
            {
                VariablesDibujoView.listCotas.Items.AddRange(LayersModelo);
                VariablesDibujoView.listCotas.Text = "COTAS";
                VariablesDibujoView.listTextos.Items.AddRange(LayersModelo);
                VariablesDibujoView.listTextos.Text = "R80";
                VariablesDibujoView.listLayerMuro.Items.AddRange(LayersModelo);
                VariablesDibujoView.listLayerMuro.Text = "MUROS-ELEV";
                VariablesDibujoView.listLayerRefuerzo.Items.AddRange(LayersModelo);
                VariablesDibujoView.listLayerRefuerzo.Text = "HIERROS";
            }

            VariablesDibujoView.tbAlturaViga.DataBindings.Add("Text", this, "Hlosa",true, DataSourceUpdateMode.OnPropertyChanged);

        }

        private void DibujarAlzadoCommand(object sender, EventArgs e)
        {
            var InsertionPoint = new double[2];
            FunctionsAutoCAD.FunctionsAutoCAD.OpenAutoCAD();

            RadMessageBox.SetThemeName("MaterialBlueGrey");
            RadMessageBox.Show("Localice el cursor donde se iniciara el dibujo", "AyG");

            FunctionsAutoCAD.FunctionsAutoCAD.GetPoint(ref InsertionPoint);

            LayerCota = VariablesDibujoView.listCotas.Text;
            LayerTexto = VariablesDibujoView.listTextos.Text;
            LayerCoco = VariablesDibujoView.listLayerMuro.Text;

            foreach (var alzadoi in Alzados)
            {
                if (alzadoi.IsMaestro)
                {
                    var DibujoAlzado = new DibujoAlzado(alzadoi, InsertionPoint, "SUBRAYADO1", "SUBRAYADO2",HLosa,LayerCoco,"SOLIDO-ZCON",LayerTexto);
                    DibujoAlzado.DibujarNombreMuro();
                    DibujoAlzado.CotaLongitudMuro();
                    DibujoAlzado.DibujarMuros();
                    DibujoAlzado.DibujoCambioEspesor();
                    DibujoAlzado.DibujoCambioResistencia();
                    InsertionPoint[0] += alzadoi.Muros.FirstOrDefault().Lw + 4.50f;
                }
            }
        }

        private void CargarVariablesCommand(object sender, EventArgs e)
        {
            FunctionsAutoCAD.FunctionsAutoCAD.OpenAutoCAD();
            LayersModelo = FunctionsAutoCAD.FunctionsAutoCAD.GetLayersModel();

            VariablesDibujoView.listCotas.Items.AddRange(LayersModelo);
            VariablesDibujoView.listCotas.Text = "COTAS";
            VariablesDibujoView.listTextos.Items.AddRange(LayersModelo);
            VariablesDibujoView.listTextos.Text = "R80";
            VariablesDibujoView.listLayerMuro.Items.AddRange(LayersModelo);
            VariablesDibujoView.listLayerMuro.Text = "MUROS-ELEV";
            VariablesDibujoView.listLayerRefuerzo.Items.AddRange(LayersModelo);
            VariablesDibujoView.listLayerRefuerzo.Text = "HIERROS";

            Program.LayersModelo = LayersModelo;
        }
    }
}
