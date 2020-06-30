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
            Datos = LeerDatos();
        }

        public override void ExtraerInformacion(int NumPisos)
        {
            int columns = Datos.GetLength(1);

            for (int i = 1; i < columns; i += 28)
            {
                var MuroName = Datos.GetValue(new int[] { 1, i });
                var Barra = GetRow(Datos, 2, i + 1, i + 27);
                var Cantidad = GetRow(Datos, 3, i + 1, i + 27);

                for (int j = 5; j < NumPisos + 5; j++)
                {
                    var BarrasPiso = GetRow(Datos, j, i, i + 27);
                }
            }

        }

        public override void ExtraerInformacion(GradoDisipacionEnergia disipacionEnergia)
        {

        }
    }
}
