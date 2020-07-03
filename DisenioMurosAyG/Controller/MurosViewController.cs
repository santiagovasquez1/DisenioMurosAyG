using DataAcces;
using DisenioMurosAyG.Views;
using Entidades;
using System;
using System.Collections.Generic;
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
        public List<Alzado> Alzados { get; set; }
        public Alzado AlzadoSeleccionado { get; set; }
        public MurosViewController(MurosView murosView)
        {
            _context = Program._context;
            Alzados = _context.Alzados;
            MurosView = murosView;

            MurosView.ListlMuros.CellEndEdit += new GridViewCellEventHandler(EditAlzadoCommand);
            MurosView.ListlMuros.HeaderCellToggleStateChanged += new HeaderCellToggleStateChangedEventHandler(HeaderCellToggleStateChanged);

            Set_Columns_Data_Alzado();
            LoadMurosData();
            Cargar_DataGrid();
        }

        private void HeaderCellToggleStateChanged(object sender, GridViewHeaderCellEventArgs e)
        {
            int column = e.ColumnIndex;
            var ColumnName = e.Column.Name;

            for (int i = 0; i < Alzados.Count; i++)
            {
                EditData(i, column, ColumnName);
            }
        }

        private void Set_Columns_Data_Alzado()
        {
            DT_MurosModelo = new DataTable();

            var Columnas = new List<DataColumn>()
            {
                DataGridController.CrearColumna("Muro",typeof(string),true),
                DataGridController.CrearColumna("NombreDef",typeof(string),false),
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
                dataRow[2] = Alzado.IsMaestro;
                if (Alzado.Padre != null)
                    dataRow[3] = Alzado.Padre.AlzadoName;

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
        }

        private void AddColumns(RadGridView gridView)
        {
            DataGridController.AddGridViewColumn<GridViewColumn>(gridView, typeof(GridViewTextBoxColumn), typeof(string), "Muro", "Muro", "Muro", true, null);
            DataGridController.AddGridViewColumn<GridViewColumn>(gridView, typeof(GridViewTextBoxColumn), typeof(string), "NombreDef", "Nombre Def", "NombreDef", false, null);
            DataGridController.AddGridViewColumn(gridView, typeof(bool), "IsMaestro", "Muro maestro", "IsMaestro", false);

            var DataSource = (from alzado in Alzados where alzado.IsMaestro select alzado.AlzadoName).ToList();
            DataGridController.AddGridViewColumn(gridView, typeof(GridViewComboBoxColumn), typeof(string), "Padre", "Similar a", "Padre", true, DataSource);
        }

        private void EditAlzadoCommand(object sender, GridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            int column = e.ColumnIndex;
            var ColumnName = MurosView.ListlMuros.Rows[indice].Cells[column].ColumnInfo.Name;
            EditData(indice, column, ColumnName);

            //LoadMurosData();
        }

        private void EditData(int indice, int column, string ColumnName)
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
                        alzado.NombreDef = MurosView.ListlMuros.Rows[indice].Cells[column].Value.ToString();
                        foreach (var muro in alzado.Muros)
                            muro.LabelDef = MurosView.ListlMuros.Rows[indice].Cells[column].Value.ToString();
                    }
                    break;
                case "IsMaestro":
                    AlzadoSeleccionado.IsMaestro = (bool)MurosView.ListlMuros.Rows[indice].Cells["IsMaestro"].Value;

                    if (AlzadoSeleccionado.IsMaestro)
                    {
                        if (AlzadoSeleccionado.Padre != null)
                            AlzadoSeleccionado.Padre = null;

                        MurosView.ListlMuros.Rows[indice].Cells["Padre"].Value = "";
                        MurosView.ListlMuros.Columns["Padre"].ReadOnly = true;
                    }
                    else
                        MurosView.ListlMuros.Columns["Padre"].ReadOnly = false;
                    break;
                case "Padre":
                    var AlzadoPadre = (from alzado in Alzados
                                       where alzado.Padre != null
                                       where alzado.Padre.NombreDef == MurosView.ListlMuros.Rows[indice].Cells[column].Value.ToString()
                                       select alzado).FirstOrDefault();
                    AlzadoSeleccionado.Padre = AlzadoPadre;
                    break;
            }
        }

        private void ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            MurosView.ListlMuros.MasterTemplate.AllowAddNewRow = args.ToggleState == ToggleState.On;
        }

    }
}
