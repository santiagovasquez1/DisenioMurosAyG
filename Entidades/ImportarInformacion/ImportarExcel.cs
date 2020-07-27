using Entidades.Factorias;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Entidades.ImportarInformacion
{
    public abstract class ImportarExcel
    {
        public bool disposed = false;
        public List<Muro> MurosModelo { get; set; }
        public List<Story> StoriesModelo { get; set; }
        public StoryFactory StoryFactory { get; set; }
        public MuroFactory MuroFactory { get; set; }
        public BarraMuroFactory BarraMuroFactory { get; set; }
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

        public object[,] LeerDatos(int Column)
        {
            Worksheet Sheet = Workbook.Worksheets[1] as Worksheet;

            var Filas = 100;
            var cols = Sheet.Range["XFD1"].End[XlDirection.xlToLeft].Column;

            var Cell1 = Sheet.Rows.Cells[1, 1];
            var Cell2 = Sheet.Rows.Cells[Filas, cols];

            var datos = Sheet.Range[Cell1, Cell2].Value;
            return datos as object[,];
        }

        public abstract void ExtraerInformacion(GradoDisipacionEnergia disipacionEnergia,List<Malla>mallas);
        public abstract void ExtraerInformacion();

        public void CerrarExcel()
        {
            Workbook.Save();
            ExcelApp.Quit();
            Marshal.FinalReleaseComObject(ExcelApp);
        }

        public List<object> GetColumn(object[,] matrix, int columnNumber)
        {

            var prueba = Enumerable.Range(0, matrix.GetLength(0)).
                Select(x => matrix[x + 1, columnNumber]).ToList();

            return prueba;
        }

        public List<object>GetRow(object[,] matrix, int RowNumber,int StartColumn,int EndColumn)
        {
            var prueba = Enumerable.Range(StartColumn, EndColumn-StartColumn).
                Select(x => matrix[RowNumber, x]).ToList();

            return prueba.FindAll(x=>x!=null).ToList();
        }

        public List<object> GetRow2(object[,] matrix, int RowNumber, int StartColumn, int EndColumn)
        {
            var prueba = Enumerable.Range(StartColumn, EndColumn - StartColumn).
                Select(x => matrix[RowNumber, x]).ToList();

            return prueba.ToList();
        }

    }
}
