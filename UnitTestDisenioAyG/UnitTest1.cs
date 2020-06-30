using System;
using System.IO;
using Entidades;
using Entidades.Factorias;
using System.Linq;
using Entidades.LecturaExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades.ImportarInformacion;
using System.Collections.Generic;

namespace UnitTestDisenioAyG
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            string Ruta1 = "F:\\Proyectos Visual Studio\\Desarrollo_Software\\Programa Dibujo Muros ETAPA 1\\Programa Dibujo Muros ETAPA 1\\Muros.xlsx";
            string Ruta2 = "F:\\Proyectos Visual Studio\\Desarrollo_Software\\Programa Dibujo Muros ETAPA 1\\Programa Dibujo Muros ETAPA 1\\Refuerzo.xlsx";
            List<Muro> MurosModelo = new List<Muro>();
            List<Story> stories = new List<Story>();

            if (File.Exists(Ruta1))
            {
                ImportarExcel AppExcel = new ImportarDisenio(Ruta1);
                AppExcel.ExtraerInformacion(GradoDisipacionEnergia.DES);
                MurosModelo = AppExcel.MuroFactory.Muros;
                stories = AppExcel.StoryFactory.Stories;
                AppExcel.CerrarExcel();

            }

            if (File.Exists(Ruta2))
            {
                ImportarExcel AppExcel = new ImportarDespiece(Ruta2);
                AppExcel.MurosModelo = MurosModelo;
                AppExcel.ExtraerInformacion();
                AppExcel.CerrarExcel();
            }

        }
    }
}
