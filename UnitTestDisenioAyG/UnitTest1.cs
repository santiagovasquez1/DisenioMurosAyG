using System;
using System.IO;
using Entidades;
using Entidades.Factorias;
using System.Linq;
using Entidades.LecturaExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades.ImportarInformacion;
using System.Collections.Generic;
using FunctionsAutoCAD;
using DataAcces;
using DibujoAutomatico;

namespace UnitTestDisenioAyG
{
    [TestClass]
    public class UnitTest1
    {
        public ModeloContext ModeloContext { get; set; }

        [TestMethod]
        public void TestMethod1()
        {

            string Ruta1 = "F:\\Proyectos Visual Studio\\Desarrollo_Software\\Programa Dibujo Muros ETAPA 1\\Programa Dibujo Muros ETAPA 1\\Muros.xlsx";
            string Ruta2 = "F:\\Proyectos Visual Studio\\Desarrollo_Software\\Programa Dibujo Muros ETAPA 1\\Programa Dibujo Muros ETAPA 1\\Refuerzo.xlsx";
            ModeloContext = new ModeloContext();

            if (File.Exists(Ruta1) && File.Exists(Ruta2))
            {
                ModeloContext.RutaArchivoDisenio = Ruta1;
                ModeloContext.RutaArchivoDespiece = Ruta2;

                ModeloContext.LoadDisenioContext();
                ModeloContext.LoadDespieceContext();
            }

            ProbarDespiece(ModeloContext.Alzados.FirstOrDefault());
            //AutocadController();
        }

        public void ProbarDespiece(Alzado alzado)
        {
            var RefuerzoFactory = new RefuerzoLongFactory(alzado,1.00f);
            RefuerzoFactory.SetRefuerzoMuro();
            DibujarRefuerzo(alzado);
        }

        public void DibujarRefuerzo(Alzado alzado)
        {
            var InsertionPoint = new double[2];
            FunctionsAutoCAD.FunctionsAutoCAD.OpenAutoCAD();
            FunctionsAutoCAD.FunctionsAutoCAD.GetPoint(ref InsertionPoint);
            var DibujarRefuerzo = new DibujoRefuerzo(alzado, InsertionPoint, 0.10f, "BORDES", "HIERROS", "R-60");
            DibujarRefuerzo.DibujarRefuerzoLongitudinal();
        }

        public void AutocadController()
        {
            var InsertionPoint = new double[2];
            FunctionsAutoCAD.FunctionsAutoCAD.OpenAutoCAD();
            FunctionsAutoCAD.FunctionsAutoCAD.GetPoint(ref InsertionPoint);

            //var Alzado = ModeloContext.Alzados.FirstOrDefault();
            //var Prueba = new DibujoAlzado(Alzado, InsertionPoint, "SUBRAYADO1", "SUBRAYADO2");
            //Prueba.DibujarNombreMuro();
            //Prueba.CotaLongitudMuro();
            //Prueba.DibujarMuros();
            //Prueba.DibujoCambioEspesor();
            //Prueba.DibujoCambioResistencia();

            foreach (Alzado alzadoi in ModeloContext.Alzados)
            {
                if (alzadoi.IsMaestro)
                {
                    var DibujoAlzado = new DibujoAlzado(alzadoi, InsertionPoint, "SUBRAYADO1", "SUBRAYADO2",0.1f,"","","");
                    DibujoAlzado.DibujarNombreMuro();
                    DibujoAlzado.CotaLongitudMuro();
                    DibujoAlzado.DibujarMuros();
                    DibujoAlzado.DibujoCambioEspesor();
                    DibujoAlzado.DibujoCambioResistencia();
                    InsertionPoint[0] += alzadoi.Muros.FirstOrDefault().Lw + 4.50f;
                }
            }

        }
    }
}
