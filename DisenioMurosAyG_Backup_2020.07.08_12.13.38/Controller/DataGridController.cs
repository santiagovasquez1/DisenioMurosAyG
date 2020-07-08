﻿using System;
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

        public static void AddGridViewColumn<T>(RadGridView gridView, Type typecolumn, Type typevalue, string columnName, string headerText, string fieldName, bool isreadonly, List<T> dataSource)
        {
            GridViewDataColumn viewColumn = null;

            switch (typecolumn.Name)
            {
                case "GridViewTextBoxColumn":
                    viewColumn = TextBoxColumn(typevalue, columnName, headerText, fieldName, isreadonly);
                    gridView.MasterTemplate.Columns.Add(viewColumn);
                    break;
                case "GridViewComboBoxColumn":
                    viewColumn = ComboBoxColumn(typevalue, columnName, headerText, fieldName, isreadonly, dataSource);
                    gridView.MasterTemplate.Columns.Add(viewColumn);
                    break;
            }
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
            textBoxColumn.DataSourceNullValue = "Error";
            return textBoxColumn;
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

        private static void SetPropertiesColumn(Type typevalue, string columnName, string headerText, string fieldName, bool isreadonly, GridViewDataColumn  boxColumn)
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