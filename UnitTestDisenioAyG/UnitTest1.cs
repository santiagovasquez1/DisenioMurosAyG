using System;
using System.IO;
using Entidades.LecturaExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDisenioAyG
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            string Ruta = "D:\\Desarrollo_Software\\Programa Dibujo Muros ETAPA 1\\Programa Dibujo Muros ETAPA 1\\Muros.xlsx";

            if (File.Exists(Ruta))
            {
                AbrirArchivoExcel AppExcel = new AbrirArchivoExcel(Ruta);
                AppExcel.ExtraerInformacion(Entidades.GradoDisipacionEnergia.DES);
                AppExcel.CerrarExcel();
            }


        }
    }
}
