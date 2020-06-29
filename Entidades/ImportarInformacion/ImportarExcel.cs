using Entidades.Factorias;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.ImportarInformacion
{
    public abstract class ImportarExcel
    {
        public StoryFactory StoryFactory { get; set; }
        public MuroFactory MuroFactory { get; set; }
        public Application ExcelApp { get; set; }
         public string RutaArchivo { get; set; }
         public Workbook Workbook { get; set; }
         public object[,] Datos { get; set; }

        public object[,] LeerDatos()
        {

            Worksheet Sheet = Workbook.Worksheets[1] as Worksheet;

            var Filas = Sheet.Range["D10000"].End[XlDirection.xlUp].Row;
            var cols = Sheet.Range["XFD1"].End[XlDirection.xlToLeft].Column;

            var Cell1 = Sheet.Rows.Cells[1, 1];
            var Cell2 = Sheet.Rows.Cells[Filas, cols];

            var datos = Sheet.Range[Cell1, Cell2].Value;
            return datos as object[,];
        }

        public abstract void ExtraerInformacion(GradoDisipacionEnergia disipacionEnergia);

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
