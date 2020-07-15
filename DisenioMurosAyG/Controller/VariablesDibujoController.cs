﻿using DisenioMurosAyG.Views;
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

            RadMessageBox.SetThemeName(VariablesDibujoView.ThemeName);
            RadMessageBox.Show("Localice el cursor donde se iniciara el dibujo", "AyG");

            FunctionsAutoCAD.FunctionsAutoCAD.GetPoint(ref InsertionPoint);

            LayerCota = VariablesDibujoView.listCotas.Text;
            LayerTexto = VariablesDibujoView.listTextos.Text;
            LayerCoco = VariablesDibujoView.listLayerMuro.Text;

            foreach (var alzadoi in Alzados)
            {
                if (alzadoi.Dibujar)
                {
                    var DibujoAlzado = new DibujoAlzado(alzadoi, InsertionPoint, "SUBRAYADO1", "SUBRAYADO2",HLosa,LayerCoco,"SOLIDO-ZCON",LayerCota,LayerTexto);
                    DibujoAlzado.DibujarNombreMuro();
                    DibujoAlzado.CotaLongitudMuro();
                    DibujoAlzado.DibujarMuros();
                    DibujoAlzado.DibujoCambioEspesor();
                    DibujoAlzado.DibujoCambioResistencia();
                    InsertionPoint[0] += alzadoi.Muros.FirstOrDefault().Lw + 4.50f;

                    var ExisteDespiece = alzadoi.Muros.Exists(x => x.BarrasMuros != null);

                    if (ExisteDespiece)
                    {
                        var RefuerzoFactory = new RefuerzoLongFactory(alzadoi, 1.00f);
                        RefuerzoFactory.SetRefuerzoMuro();
                        var DibujoRefuerzo = new DibujoRefuerzo(alzadoi, InsertionPoint, 0.10f, 1.20f, 1.00f, "BORDES", "HIERROS", "R-60", "COTA");
                        DibujoRefuerzo.DibujarMuros();
                        DibujoRefuerzo.DibujoCambioResistencia();
                        DibujoRefuerzo.DibujarRefuerzoLongitudinal();
                        InsertionPoint[0] += DibujoRefuerzo.LongitudCoco + 4.50f;
                    }

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
