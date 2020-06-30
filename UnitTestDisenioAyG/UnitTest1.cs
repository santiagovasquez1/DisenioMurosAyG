using System;
using System.IO;
using Entidades;
using Entidades.Factorias;
using System.Linq;
using Entidades.LecturaExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades.ImportarInformacion;

namespace UnitTestDisenioAyG
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            string Ruta = "F:\\Proyectos Visual Studio\\Desarrollo_Software\\Programa Dibujo Muros ETAPA 1\\Programa Dibujo Muros ETAPA 1\\Refuerzo.xlsx";

            if (File.Exists(Ruta))
            {
                ImportarExcel AppExcel = new ImportarDespiece(Ruta);
                AppExcel.ExtraerInformacion(28);
                AppExcel.CerrarExcel();

            }

        }
    }
}
