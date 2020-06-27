using DataAcces;
using DisenioMurosAyG.Views;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisenioMurosAyG.Controller
{
    public class AlzadoController
    {
        public ModeloContext _contex { get; set; }
        public InformacionAlzadoView InformacionAlzadoView { get; set; }
        public Alzado AlzadoSeleccionado { get; set; }
        public Muro MuroSeleccionado { get; set; }
        public DataTable DT_AlzadoSeleccionado { get; set; }
        public AlzadoController(InformacionAlzadoView informacionAlzadoView)
        {
            _contex = Program._context;
            InformacionAlzadoView = informacionAlzadoView;
            InformacionAlzadoView.cbAlzados.DropDownStyle = ComboBoxStyle.DropDownList;

            if (_contex.Alzados != null)
            {
                InformacionAlzadoView.cbAlzados.DataSource = _contex.Alzados;
                InformacionAlzadoView.cbAlzados.SelectedIndexChanged += new EventHandler(SeleccionarAlzadoCommand);
                informacionAlzadoView.dgAlzado.CellEndEdit += new DataGridViewCellEventHandler(EditMuroCommand);

                Set_Columns_Data_Alzado();
            }

        }


        private void SeleccionarAlzadoCommand(object sender, EventArgs e)
        {
            AlzadoSeleccionado = (Alzado)InformacionAlzadoView.cbAlzados.SelectedItem;
            LoadAlzadoData();
            Cargar_DataGrid();
        }

        private void Set_Columns_Data_Alzado()
        {
            DT_AlzadoSeleccionado = new DataTable();

            var Columnas = new List<DataColumn>()
            {
                DataGridController.CrearColumna("Piso",typeof(string),true),
                DataGridController.CrearColumna("Nivel (m)",typeof(string),true),
                DataGridController.CrearColumna("Muro",typeof(string),true),
                DataGridController.CrearColumna("L (m)",typeof(float),false),
                DataGridController.CrearColumna("t (m)",typeof(float),false),
                DataGridController.CrearColumna("h (m)",typeof(float),false),
                DataGridController.CrearColumna("Zc_Izq (m)",typeof(float),false),
                DataGridController.CrearColumna("Zc_Der (m)",typeof(float),false),
                DataGridController.CrearColumna("F'c (MPa)",typeof(float),true),
                DataGridController.CrearColumna("Fy (MPa)",typeof(float),true),
                DataGridController.CrearColumna("RefHoriz (cm²/m)",typeof(float),true),
                DataGridController.CrearColumna("RefVert (cm²/m)",typeof(float),true),
                DataGridController.CrearColumna("RefAdicional (cm²)",typeof(float),true),
            };

            DataGridController.Set_Columns_Data(DT_AlzadoSeleccionado, Columnas);
        }

        private void LoadAlzadoData()
        {
            if (DT_AlzadoSeleccionado.Rows.Count > 0)
                DT_AlzadoSeleccionado.Rows.Clear();

            foreach (var muro in AlzadoSeleccionado.Muros)
            {
                DataRow dataRow = DT_AlzadoSeleccionado.NewRow();
                dataRow[0] = muro.Story.StoryName;
                dataRow[1] = muro.Story.StoryElevation;
                dataRow[2] = muro.Label;
                dataRow[3] = muro.Lw;
                dataRow[4] = muro.Bw;
                dataRow[5] = muro.Hw;
                dataRow[6] = muro.EBE_Izq != null ? muro.EBE_Izq.LongEbe : (object)0f;
                dataRow[7] = muro.EBE_Der != null ? muro.EBE_Der.LongEbe : (object)0f;
                dataRow[8] = muro.Fc;
                dataRow[9] = muro.Fy;
                dataRow[10] = muro.AsH;
                dataRow[11] = muro.AsV;
                dataRow[12] = muro.AsAdicional;

                DT_AlzadoSeleccionado.Rows.Add(dataRow);
            }

        }

        private void Cargar_DataGrid()
        {
            InformacionAlzadoView.dgAlzado.DataSource = DT_AlzadoSeleccionado;
            InformacionAlzadoView.dgAlzado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            InformacionAlzadoView.dgAlzado.ReadOnly = false;
            InformacionAlzadoView.dgAlzado.AllowUserToOrderColumns = false;
            InformacionAlzadoView.dgAlzado.AllowUserToAddRows = false;

        }

        private void EditMuroCommand(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            int column = e.ColumnIndex;

            MuroSeleccionado = AlzadoSeleccionado.Muros[indice];

            switch (column)
            {
                case 3:
                    MuroSeleccionado.Lw = float.Parse(InformacionAlzadoView.dgAlzado.Rows[indice].Cells[column].Value.ToString());
                    break;
                case 4:
                    MuroSeleccionado.Bw = float.Parse(InformacionAlzadoView.dgAlzado.Rows[indice].Cells[column].Value.ToString());
                    break;
                case 5:
                    MuroSeleccionado.Hw = float.Parse(InformacionAlzadoView.dgAlzado.Rows[indice].Cells[column].Value.ToString());
                    break;
            }

        }
    }
}
