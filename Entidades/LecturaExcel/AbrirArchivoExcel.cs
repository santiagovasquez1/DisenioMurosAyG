using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Factorias;
using Microsoft.Office.Interop.Excel;

namespace Entidades.LecturaExcel
{
    public class AbrirArchivoExcel
    {
        StoryFactory StoryFactory { get; set; }
        MuroFactory MuroFactory { get; set; }
        public Application ExcelApp { get; set; }
        public string RutaArchivo { get; set; }
        private Workbook Workbook { get; set; }
        private object[,] DatosDisenio { get; set; }

        public AbrirArchivoExcel(string ruta)
        {
            RutaArchivo = ruta;
            ExcelApp = new Application();
            Workbook = ExcelApp.Workbooks.Open(ruta);
            DatosDisenio = LeerDisenio();
        }
        private object[,] LeerDisenio()
        {

            Worksheet Sheet = Workbook.Worksheets[1] as Worksheet;

            var Filas = Sheet.Range["D10000"].End[XlDirection.xlUp].Row;
            var cols = Sheet.Range["XFD1"].End[XlDirection.xlToLeft].Column;

            var Cell1 = Sheet.Rows.Cells[1, 1];
            var Cell2 = Sheet.Rows.Cells[Filas, cols];

            var datosDisenio = Sheet.Range[Cell1, Cell2].Value;
            return datosDisenio as object[,];
        }
        public void ExtraerInformacion(GradoDisipacionEnergia disipacionEnergia)
        {
            int Filas = DatosDisenio.GetLength(0);

            var pisos = GetColumn(DatosDisenio, 1);
            //var NombreMuros = GetColumn(DatosDisenio, 2);
            var DatosGeometria = GetColumn(DatosDisenio, 5);

            StoryFactory = new StoryFactory();
            StoryFactory.BuildStories(pisos, DatosGeometria);
            MuroFactory = new MuroFactory(StoryFactory.Stories);
            MuroFactory.BuildMuros(DatosDisenio,disipacionEnergia);

            //foreach (Range celda in DatosDisenio)
            //{
            //    var prueba = celda.Value;
            //}

        }

        public void CerrarExcel()
        {
            Workbook.Save();
            ExcelApp.Quit();
        }


        public List<object> GetColumn(object[,] matrix, int columnNumber)
        {

            var prueba = Enumerable.Range(0, matrix.GetLength(0)).
                Select(x => matrix[x + 1, columnNumber]).ToList();

            return prueba;
        }


    }
}
