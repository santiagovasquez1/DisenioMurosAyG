using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.Factorias;
using Entidades.ImportarInformacion;
using Microsoft.Office.Interop.Excel;

namespace Entidades.LecturaExcel
{
    public class ImportarDisenio : ImportarExcel
    {
        public ImportarDisenio(string ruta)
        {
            RutaArchivo = ruta;
            ExcelApp = new Application();
            Workbook = ExcelApp.Workbooks.Open(ruta);
            Datos = LeerDatos();
        }

        public override void ExtraerInformacion(GradoDisipacionEnergia disipacionEnergia)
        {
            int Filas = Datos.GetLength(0);

            var pisos = GetColumn(Datos, 1);
            var DatosGeometria = GetColumn(Datos, 5);

            StoryFactory = new StoryFactory();
            StoryFactory.BuildStories(pisos, DatosGeometria);
            MuroFactory = new MuroFactory(StoryFactory.Stories);
            MuroFactory.BuildMuros(Datos, disipacionEnergia);

        }


        public override void ExtraerInformacion(int a)
        {

        }


    }
}
