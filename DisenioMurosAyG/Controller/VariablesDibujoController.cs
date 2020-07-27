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
using Entidades.Factorias;

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
        public float HVigaFundacion { get; set; }
        public float ProfRefuerzo { get; set; }
        public VariablesDibujoController(VariablesDibujoView variablesDibujoView)
        {
            _context = Program._context;
            LayersModelo = Program.LayersModelo;
            VariablesDibujoView = variablesDibujoView;
            VariablesDibujoView.cbDibujar.Click += new EventHandler(DibujarAlzadoCommand);

            if (_context.Alzados != null)
            {
                Alzados = _context.Alzados;
                VariablesDibujoView.cbDibujar.Enabled = true;
            }
            else
                VariablesDibujoView.cbDibujar.Enabled = false;

            VariablesDibujoView.tbAlturaViga.DataBindings.Add("Text", this, "Hlosa", true, DataSourceUpdateMode.OnPropertyChanged);
            VariablesDibujoView.tbHVigaFunda.DataBindings.Add("Text", this, "HVigaFundacion", true, DataSourceUpdateMode.OnPropertyChanged);
            VariablesDibujoView.tbProfRefuerzo.DataBindings.Add("Text", this, "ProfRefuerzo", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void DibujarAlzadoCommand(object sender, EventArgs e)
        {
            var InsertionPoint = new double[2];
            FunctionsAutoCAD.FunctionsAutoCAD.OpenAutoCAD();

            RadMessageBox.SetThemeName(VariablesDibujoView.ThemeName);
            RadMessageBox.Show("Localice el cursor donde se iniciara el dibujo", "AyG");

            FunctionsAutoCAD.FunctionsAutoCAD.GetPoint(ref InsertionPoint);

            LayerCota = "COTA";
            LayerTexto = "R80";
            LayerCoco = "MUROS-ELEV";

            foreach (var alzadoi in Alzados)
            {
                if (alzadoi.Dibujar)
                {
                    var DibujoAlzado = new DibujoAlzado(alzadoi, InsertionPoint, "SUBRAYADO1", "SUBRAYADO2", HLosa, LayerCoco, "SOLIDO-ZCON", LayerCota, LayerTexto);
                    DibujoAlzado.DibujarNombreMuro();
                    DibujoAlzado.CotaLongitudMuro();
                    DibujoAlzado.DibujarMuros();
                    DibujoAlzado.DibujoCambioEspesor();
                    DibujoAlzado.DibujoCambioResistencia();
                    InsertionPoint[0] += alzadoi.Muros.FirstOrDefault().Lw + 4.50f;

                    var ExisteDespiece = alzadoi.Muros.Exists(x => x.BarrasMuros != null);

                    if (ExisteDespiece)
                    {
                        var RefuerzoFactory = new RefuerzoLongFactory(alzadoi, ProfRefuerzo);
                        RefuerzoFactory.SetRefuerzoMuro();
                        var DibujoRefuerzo = new DibujoRefuerzo(alzadoi, InsertionPoint, HLosa, HVigaFundacion, ProfRefuerzo, "BORDES", "HIERROS", "R-60", "COTA");
                        DibujoRefuerzo.DibujarMuros();
                        DibujoRefuerzo.DibujoCambioResistencia();
                        DibujoRefuerzo.DibujarRefuerzoLongitudinal();

                        var InsertionPoint2 = new double[] { InsertionPoint[0], InsertionPoint[1] - 2.40, InsertionPoint[2] };
                        var DibujoSeccion = new DibujoSeccion(alzadoi, InsertionPoint2, "REFUERZO-SECCION", "COTAS-MUROS", "R60", "R-100", "BORDES", 6.70f, 0.04f);
                        DibujoSeccion.DibujoCocoSeccion();

                        if (DibujoSeccion.LongSeccion > DibujoRefuerzo.LongitudCoco)
                            InsertionPoint[0] += DibujoSeccion.LongSeccion + 4.50f;
                        else
                            InsertionPoint[0] += DibujoRefuerzo.LongitudCoco + 4.50f;
                    }

                }
            }
        }

        private void CargarVariablesCommand(object sender, EventArgs e)
        {
            FunctionsAutoCAD.FunctionsAutoCAD.OpenAutoCAD();
            LayersModelo = FunctionsAutoCAD.FunctionsAutoCAD.GetLayersModel();
            Program.LayersModelo = LayersModelo;
        }
    }
}
