using Entidades.Factorias;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Entidades.ImportarInformacion
{
    public class ImportarDespiece : ImportarExcel
    {

        public ImportarDespiece(string ruta)
        {
            RutaArchivo = ruta;
            ExcelApp = new Application();
            Workbook = ExcelApp.Workbooks.Open(ruta);
            Datos = LeerDatos(1);
        }

        public override void ExtraerInformacion()
        {
            int columns = Datos.GetLength(1);
            int filas = Datos.GetLength(0);

            if (MurosModelo != null)
            {
                var barrasfactory = new BarraMuroFactory(MurosModelo);

                for (int i = 1; i < columns; i += 28)
                {
                    var MuroName = Datos.GetValue(new int[] { 1, i }).ToString().Replace(" ", String.Empty).ToLower();

                    var Barra = GetRow(Datos, 2, i, i + 26);
                    var Cantidad = GetRow(Datos, 3, i, i + 26);

                    for (int j = 5; j < 100; j++)
                    {
                        var BarrasPiso = GetRow2(Datos, j, i, i + 26);
                        barrasfactory.BuildBarras(MuroName, Barra, Cantidad, BarrasPiso);                      
                    }
                }
            }

        }

        public override void ExtraerInformacion(GradoDisipacionEnergia disipacionEnergia)
        {

        }
    }
}
