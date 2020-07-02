using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

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

        public static void AddGridViewColumn(RadGridView gridView,Type typecolumn,Type typevalue,string columnName,string headerText,string fieldName,bool isreadonly)
        {
            GridViewColumn viewColumn = null;

            switch (typecolumn.Name)
            {
                case "GridViewTextBoxColumn":
                    viewColumn = TextBoxColumn(typevalue, columnName, headerText, fieldName,isreadonly);
                    gridView.MasterTemplate.Columns.Add((GridViewDataColumn)viewColumn);
                    break;

            }   
        }

        private static GridViewTextBoxColumn TextBoxColumn(Type typevalue, string columnName,string headerText, string fieldName, bool isreadonly)
        {
            GridViewTextBoxColumn textBoxColumn = new GridViewTextBoxColumn();
            textBoxColumn.Name = columnName;
            textBoxColumn.HeaderText = headerText;
            textBoxColumn.FieldName = fieldName;
            textBoxColumn.DataType = typevalue;
            textBoxColumn.ReadOnly = isreadonly;
            textBoxColumn.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            return textBoxColumn;
        }
    }
}
