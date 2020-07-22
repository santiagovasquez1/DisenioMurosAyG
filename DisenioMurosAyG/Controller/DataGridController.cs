using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// <summary>
        ///  Adicion de columnas del tipo TextBox
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="typecolumn"></param>
        /// <param name="typevalue"></param>
        /// <param name="columnName"></param>
        /// <param name="headerText"></param>
        /// <param name="fieldName"></param>
        /// <param name="isreadonly"></param>
        public static void AddGridViewColumn(RadGridView gridView, Type typecolumn, Type typevalue, string columnName, string headerText, string fieldName, bool isreadonly)
        {
            GridViewTextBoxColumn viewColumn = null;
            viewColumn = TextBoxColumn(typevalue, columnName, headerText, fieldName, isreadonly);
            gridView.MasterTemplate.Columns.Add(viewColumn);

        }

        /// <summary>
        /// Adicion de columnas del tipo combobox
        /// </summary>
        /// <typeparam name="T">Tipo de clase de los datos</typeparam>
        /// <param name="gridView"></param>
        /// <param name="typecolumn"></param>
        /// <param name="typevalue"></param>
        /// <param name="columnName"></param>
        /// <param name="headerText"></param>
        /// <param name="fieldName"></param>
        /// <param name="isreadonly"></param>
        /// <param name="dataSource"></param>
        public static void AddGridViewColumn<T>(RadGridView gridView, Type typecolumn, Type typevalue, string columnName, string headerText, string fieldName, bool isreadonly, List<T> dataSource)
        {
            GridViewComboBoxColumn viewColumn = null;
            viewColumn = ComboBoxColumn(typevalue, columnName, headerText, fieldName, isreadonly, dataSource);
            gridView.MasterTemplate.Columns.Add(viewColumn);
        }
        /// <summary>
        /// Adicion de columnas del tipo checkbox
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="columnName"></param>
        /// <param name="headerText"></param>
        /// <param name="fieldName"></param>
        /// <param name="isreadonly"></param>
        public static void AddGridViewColumn(RadGridView gridView, Type typevalue, string columnName, string headerText, string fieldName, bool isreadonly)
        {
            GridViewCheckBoxColumn viewColumn = CheckBoxColumn(typevalue, columnName, headerText, fieldName, isreadonly);
            viewColumn.EnableHeaderCheckBox = true;
            viewColumn.EditMode = EditMode.OnValueChange;
            SetPropertiesColumn(typevalue, columnName, headerText, fieldName, isreadonly, viewColumn);
            gridView.MasterTemplate.Columns.Add(viewColumn);
        }


        private static GridViewTextBoxColumn TextBoxColumn(Type typevalue, string columnName, string headerText, string fieldName, bool isreadonly)
        {
            GridViewTextBoxColumn textBoxColumn = new GridViewTextBoxColumn();
            SetPropertiesColumn(typevalue, columnName, headerText, fieldName, isreadonly, textBoxColumn);
            textBoxColumn.DataType = typevalue;
            return textBoxColumn;
        }

        private static GridViewDecimalColumn DecimalColumn(Type typevalue, string columnName, string headerText, string fieldName, bool isreadonly)
        {
            GridViewDecimalColumn DecimalBox= new GridViewDecimalColumn();
            SetPropertiesColumn(typevalue, columnName, headerText, fieldName, isreadonly, DecimalBox);
            DecimalBox.DataType = typevalue;
            DecimalBox.DecimalPlaces = 3;
            return DecimalBox;
        }

        private static GridViewCheckBoxColumn CheckBoxColumn(Type typevalue, string columnName, string headerText, string fieldName, bool isreadonly)
        {
            GridViewCheckBoxColumn checkBoxColumn = new GridViewCheckBoxColumn();
            SetPropertiesColumn(typevalue, columnName, headerText, fieldName, isreadonly, checkBoxColumn);
            checkBoxColumn.FieldName = "";
            checkBoxColumn.EditMode = EditMode.OnValueChange;
            return checkBoxColumn;
        }

        private static GridViewComboBoxColumn ComboBoxColumn<T>(Type typevalue, string columnName, string headerText, string fieldName, bool isreadonly, List<T> dataSource)
        {
            GridViewComboBoxColumn gridViewComboBox = new GridViewComboBoxColumn();
            SetPropertiesColumn(typevalue, columnName, headerText, fieldName, isreadonly, gridViewComboBox);
            gridViewComboBox.DataSource = dataSource;
            return gridViewComboBox;
        }

        private static void SetPropertiesColumn(Type typevalue, string columnName, string headerText, string fieldName, bool isreadonly, GridViewDataColumn boxColumn)
        {
            boxColumn.Name = columnName;
            boxColumn.HeaderText = headerText;
            boxColumn.FieldName = fieldName;
            boxColumn.ReadOnly = isreadonly;
            boxColumn.DataType = typevalue;
            boxColumn.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
        }
    }
}
