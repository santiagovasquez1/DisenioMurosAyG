﻿using DataAcces;
using DisenioMurosAyG.Views;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace DisenioMurosAyG.Controller
{
    public class MurosViewController
    {
        public MurosView MurosView { get; set; }
        public ModeloContext _context { get; set; }
        public DataTable DT_MurosModelo { get; set; }
        public BindingList<Alzado> Alzados { get; set; }
        public Alzado AlzadoSeleccionado { get; set; }
        public MurosViewController(MurosView murosView)
        {
            _context = Program._context;
            Alzados = _context.Alzados;
            MurosView = murosView;

            MurosView.MaximizeBox = false;
            MurosView.MinimizeBox = false;
            MurosView.ListlMuros.CellEndEdit += new GridViewCellEventHandler(EditAlzadoCommand);
            MurosView.cbAceptar.Click += new EventHandler(HeaderCellToggleStateChanged);
            MurosView.cbCancelar.Click += new EventHandler(CancelCommand);
            MurosView.ListlMuros.ValueChanged += new EventHandler(ValueChangedCommand);
            MurosView.ListlMuros.HeaderCellToggleStateChanged += new HeaderCellToggleStateChangedEventHandler(HeaderstateChangedCommand);

            Set_Columns_Data_Alzado();
            LoadMurosData();
            Cargar_DataGrid();
        }

        private void CancelCommand(object sender, EventArgs e)
        {
            MurosView.Close();
        }

        private void HeaderstateChangedCommand(object sender, GridViewHeaderCellEventArgs e)
        {
            var columnName = e.Column.Name;
            var estado = e.State;
            int x = 0;

            if (columnName == "IsMaestro")
            {
                foreach (var alzado in Alzados)
                {
                    if (estado == ToggleState.On)
                    {
                        MurosView.ListlMuros.Rows[x].Cells["Padre"].Value = string.Empty;
                        MurosView.ListlMuros.Columns["Padre"].ReadOnly = true;
                    }
                    else if (estado == ToggleState.Off)
                    {
                        MurosView.ListlMuros.Columns["Padre"].ReadOnly = false;
                    }
                    x++;
                }
            }
        }

        private void ValueChangedCommand(object sender, EventArgs e)
        {
            if (MurosView.ListlMuros.CurrentCell != null)
            {
                var columnName = MurosView.ListlMuros.CurrentCell.ColumnInfo.Name;
                var indice = MurosView.ListlMuros.CurrentCell.RowIndex;
                EditData(indice, columnName);
            }
        }

        private void HeaderCellToggleStateChanged(object sender, EventArgs e)
        {
            var ColumnName = "Dibujar";
            var ColumnName2 = "IsMaestro";

            for (int i = 0; i < Alzados.Count; i++)
            {
                EditData(i, ColumnName);
                EditData(i, ColumnName2);
            }
            MurosView.Close();
        }

        private void Set_Columns_Data_Alzado()
        {
            DT_MurosModelo = new DataTable();

            var Columnas = new List<DataColumn>()
            {
                DataGridController.CrearColumna("Muro",typeof(string),true),
                DataGridController.CrearColumna("NombreDef",typeof(string),false),
                DataGridController.CrearColumna("Dibujar",typeof(bool),false),
                DataGridController.CrearColumna("IsMaestro",typeof(bool),false),
                DataGridController.CrearColumna("Padre",typeof(string),false),
            };

            DataGridController.Set_Columns_Data(DT_MurosModelo, Columnas);
        }
        private void LoadMurosData()
        {
            if (DT_MurosModelo.Rows.Count > 0)
                DT_MurosModelo.Rows.Clear();

            foreach (var Alzado in Alzados)
            {
                DataRow dataRow = DT_MurosModelo.NewRow();
                dataRow[0] = Alzado.AlzadoName;
                dataRow[1] = Alzado.NombreDef;
                dataRow[2] = Alzado.Dibujar;
                dataRow[3] = Alzado.IsMaestro;

                if (Alzado.Padre != null)
                    dataRow[4] = Alzado.Padre.AlzadoName;

                DT_MurosModelo.Rows.Add(dataRow);
            }

        }

        private void Cargar_DataGrid()
        {
            MurosView.ListlMuros.AutoGenerateColumns = false;
            MurosView.ListlMuros.DataSource = DT_MurosModelo;
            AddColumns(MurosView.ListlMuros);

            MurosView.ListlMuros.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            MurosView.ListlMuros.ReadOnly = false;
            MurosView.ListlMuros.AllowColumnReorder = false;
            MurosView.ListlMuros.AllowAddNewRow = false;
            MurosView.ListlMuros.AllowDragToGroup = false;
            MurosView.ListlMuros.SelectionMode = GridViewSelectionMode.CellSelect;
            MurosView.ListlMuros.MultiSelect = true;

            int x = 0;
            foreach(var alzado in Alzados)
            {
                if (alzado.IsMaestro)
                {
                    MurosView.ListlMuros.Rows[x].Cells["Padre"].Value = string.Empty;
                    MurosView.ListlMuros.Columns["Padre"].ReadOnly = true;
                }
                else
                {
                    MurosView.ListlMuros.Columns["Padre"].ReadOnly = false;
                }
            }

        }

        private void AddColumns(RadGridView gridView)
        {
            DataGridController.AddGridViewColumn(gridView, typeof(GridViewTextBoxColumn), typeof(string), "Muro", "Muro", "Muro", true);
            DataGridController.AddGridViewColumn(gridView, typeof(GridViewTextBoxColumn), typeof(string), "NombreDef", "Nombre Def", "NombreDef", false);
            DataGridController.AddGridViewColumn(gridView, typeof(bool), "Dibujar", "Dibujar Muro", "Dibujar", false);
            DataGridController.AddGridViewColumn(gridView, typeof(bool), "IsMaestro", "Muro maestro", "IsMaestro", false);
            var DataSource = (from alzado in Alzados where alzado.IsMaestro select alzado.AlzadoName).ToList();
            DataGridController.AddGridViewColumn(gridView, typeof(GridViewComboBoxColumn), typeof(string), "Padre", "Similar a", "Padre", true, DataSource);
        }

        private void EditAlzadoCommand(object sender, GridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            int column = e.ColumnIndex;
            var ColumnName = MurosView.ListlMuros.Rows[indice].Cells[column].ColumnInfo.Name;
            EditData(indice, ColumnName);

            //LoadMurosData();
        }

        private void EditData(int indice, string ColumnName)
        {
            List<Alzado> AlzadosSeleccionados = new List<Alzado>();

            AlzadoSeleccionado = Alzados[indice];

            if (AlzadoSeleccionado.IsMaestro)
            {
                AlzadosSeleccionados = (from Alzado in Alzados
                                        where Alzado.PadreId == AlzadoSeleccionado.AlzadoId | Alzado.AlzadoId == AlzadoSeleccionado.AlzadoId
                                        select Alzado).ToList();
            }
            else
                AlzadosSeleccionados.Add(AlzadoSeleccionado);

            var ActiveEditor = MurosView.ListlMuros.ActiveEditor;

            switch (ColumnName)
            {
                case "NombreDef":
                    foreach (var alzado in AlzadosSeleccionados)
                    {
                        alzado.NombreDef = MurosView.ListlMuros.Rows[indice].Cells[ColumnName].Value.ToString();
                        foreach (var muro in alzado.Muros)
                            muro.LabelDef = MurosView.ListlMuros.Rows[indice].Cells[ColumnName].Value.ToString();
                    }
                    break;
                case "IsMaestro":
                    AlzadoSeleccionado.IsMaestro = (bool)MurosView.ListlMuros.Rows[indice].Cells["IsMaestro"].Value;

                    if (AlzadoSeleccionado.IsMaestro)
                    {
                        if (AlzadoSeleccionado.Padre != null)
                            AlzadoSeleccionado.Padre = null;

                        MurosView.ListlMuros.Rows[indice].Cells["Padre"].Value = string.Empty;
                        MurosView.ListlMuros.Columns["Padre"].ReadOnly = true;
                    }
                    else
                        MurosView.ListlMuros.Columns["Padre"].ReadOnly = false;
                    break;
                case "Padre":
                    var AlzadoPadre = (from alzado in Alzados
                                       where alzado.Padre != null
                                       where alzado.Padre.NombreDef == MurosView.ListlMuros.Rows[indice].Cells[ColumnName].Value.ToString()
                                       select alzado).FirstOrDefault();
                    AlzadoSeleccionado.Padre = AlzadoPadre;
                    break;
                case "Dibujar":
                    AlzadoSeleccionado.Dibujar = (bool)MurosView.ListlMuros.Rows[indice].Cells["Dibujar"].Value;
                    break;
            }
        }

    }
}
