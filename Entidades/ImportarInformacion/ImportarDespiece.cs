using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
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

        public override void ExtraerInformacion(GradoDisipacionEnergia disipacionEnergia)
        {
            throw new NotImplementedException();
        }
    }
}
