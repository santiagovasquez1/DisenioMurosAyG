using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisenioMurosAyG.Controller
{
    public static class DataGridController
    {
        public static void Set_Columns_Data(DataTable dataTable, List<DataColumn> columns)
        {
            foreach (var column in columns)
            {
                dataTable.Columns.Add(column);
            }

        }
        public static DataColumn CrearColumna(string Name, Type type, bool IsReadOnly)
        {
            var columna = new DataColumn(Name, type);
            columna.ReadOnly = IsReadOnly;
            return columna;
        }

    }
}
