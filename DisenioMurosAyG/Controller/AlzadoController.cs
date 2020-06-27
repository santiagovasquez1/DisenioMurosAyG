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
using static System.Windows.Forms.DataGridViewComboBoxCell;

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

            DataColumn dataColumn = new DataColumn();

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
                DataGridController.CrearColumna("Separacion (m)",typeof(float),false),
                DataGridController.CrearColumna("Ramas Izq",typeof(int),true),
                DataGridController.CrearColumna("Ramas Der",typeof(int),true),
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

            var Estribos = new List<string>() { "#3", "#4", "#5" };

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

                if (muro.EBE_Izq != null | muro.EBE_Der != null)
                {
                    if (muro.EBE_Izq != null)
                        dataRow[8] = muro.EBE_Izq.SepEstribo;
                    else if (muro.EBE_Der != null)
                        dataRow[8] = muro.EBE_Der.SepEstribo;
                }
                else
                    dataRow[8] = 0f;

                dataRow[9] = muro.EBE_Izq != null ? muro.EBE_Izq.RamasX : (object)0f;
                dataRow[10] = muro.EBE_Der != null ? muro.EBE_Der.RamasX : (object)0f;

                dataRow[11] = muro.Fc;
                dataRow[12] = muro.Fy;
                dataRow[13] = muro.AsH;
                dataRow[14] = muro.AsV;
                dataRow[15] = muro.AsAdicional;

                DT_AlzadoSeleccionado.Rows.Add(dataRow);
            }

        }

        private void Cargar_DataGrid()
        {
            DataGridViewComboBoxColumn ColumnEstribos = new DataGridViewComboBoxColumn();
            ColumnEstribos.Name = "Estribos";
            ColumnEstribos.HeaderText = "Estribos";
            ColumnEstribos.DisplayIndex = 8;
            ColumnEstribos.DataSource = new List<string>() { " ", "#3", "#4", "#5" };

            InformacionAlzadoView.dgAlzado.DataSource = DT_AlzadoSeleccionado;
            InformacionAlzadoView.dgAlzado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            InformacionAlzadoView.dgAlzado.ReadOnly = false;
            InformacionAlzadoView.dgAlzado.AllowUserToOrderColumns = false;
            InformacionAlzadoView.dgAlzado.AllowUserToAddRows = false;

            try
            {
                InformacionAlzadoView.dgAlzado.Columns.Remove(InformacionAlzadoView.dgAlzado.Columns[ColumnEstribos.Name]);
                InformacionAlzadoView.dgAlzado.Columns.Add(ColumnEstribos);
            }
            catch (Exception)
            {
                InformacionAlzadoView.dgAlzado.Columns.Add(ColumnEstribos);
            }

            SetEstribosCells();

        }

        private void SetEstribosCells()
        {
            int x = 0;
            var Estribos = new List<string>() { " ", "#3", "#4", "#5" };

            foreach (var muro in AlzadoSeleccionado.Muros)
            {
                if (muro.EBE_Der != null | muro.EBE_Izq != null)
                {
                    InformacionAlzadoView.dgAlzado.Rows[x].Cells["Estribos"].ReadOnly = false;
                    if (muro.EBE_Der != null)
                        InformacionAlzadoView.dgAlzado.Rows[x].Cells["Estribos"].Value = GetEstribo(x, Estribos, muro.EBE_Der.DiametroEstribo);
                    if (muro.EBE_Izq != null)
                        InformacionAlzadoView.dgAlzado.Rows[x].Cells["Estribos"].Value = GetEstribo(x, Estribos, muro.EBE_Izq.DiametroEstribo);
                }
                else
                    InformacionAlzadoView.dgAlzado.Rows[x].Cells["Estribos"].ReadOnly = true;

                x++;
            }
        }

        private string GetEstribo(int x, List<string> Estribos, Diametro diametroEbe)
        {
            string Estribo = "";

            switch (diametroEbe)
            {
                case Diametro.Num3:
                    Estribo = Estribos[1];
                    break;
                case Diametro.Num4:
                    Estribo = Estribos[2];
                    break;
                case Diametro.Num5:
                    Estribo = Estribos[3];
                    break;
            }

            return Estribo;
        }

        private void EditMuroCommand(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            int column = e.ColumnIndex;
            var ColumnName = InformacionAlzadoView.dgAlzado.Rows[indice].Cells[column].OwningColumn.Name;
            float LongEbe = 0;

            MuroSeleccionado = AlzadoSeleccionado.Muros[indice];

            switch (ColumnName)
            {
                case "L (m)":
                    MuroSeleccionado.Lw = float.Parse(InformacionAlzadoView.dgAlzado.Rows[indice].Cells[ColumnName].Value.ToString());
                    break;
                case "t (m)":
                    MuroSeleccionado.Bw = float.Parse(InformacionAlzadoView.dgAlzado.Rows[indice].Cells[ColumnName].Value.ToString());
                    break;
                case "h (m)":
                    MuroSeleccionado.Hw = float.Parse(InformacionAlzadoView.dgAlzado.Rows[indice].Cells[ColumnName].Value.ToString());
                    break;
                case "Zc_Izq (m)":
                    LongEbe = float.Parse(InformacionAlzadoView.dgAlzado.Rows[indice].Cells[ColumnName].Value.ToString());
                    UploadEbe(indice, LongEbe, MuroSeleccionado.EBE_Izq, "Ramas Izq");
                    break;
                case "Zc_Der (m)":
                    LongEbe = float.Parse(InformacionAlzadoView.dgAlzado.Rows[indice].Cells[ColumnName].Value.ToString());
                    UploadEbe(indice, LongEbe, MuroSeleccionado.EBE_Der, "Ramas Der");
                    break;
                case "Estribos":
                    string Diametro = InformacionAlzadoView.dgAlzado.Rows[indice].Cells[ColumnName].Value.ToString();
                    UploadEbe(indice, Diametro, MuroSeleccionado.EBE_Izq, "Ramas Izq");
                    UploadEbe(indice, Diametro, MuroSeleccionado.EBE_Der, "Ramas Der");
                    break;
            }

        }

        private void UploadEbe(int indice, float LongEbe, ElementoDeBorde elementoBorde, string ColumnName)
        {
            if (LongEbe > 0)
            {
                if (elementoBorde == null)
                {
                    elementoBorde = new ElementoBordeEspecial(MuroSeleccionado.Bw, LongEbe, MuroSeleccionado.Fc, MuroSeleccionado.Fy, _contex.GradoDisipacionEnergia);
                    elementoBorde.DiametroEstribo = Diametro.Num3;
                    elementoBorde.CalculoSeparacionminima();
                    DT_AlzadoSeleccionado.Rows[indice]["Separacion (m)"] = elementoBorde.SepEstribo;
                }
                else
                    elementoBorde.LongEbe = LongEbe;

                elementoBorde.CalculoCuantiaVolumetrica(elementoBorde.SepEstribo, elementoBorde.DiametroEstribo);

                DT_AlzadoSeleccionado.Columns[ColumnName].ReadOnly = false;
                DT_AlzadoSeleccionado.Rows[indice][ColumnName] = elementoBorde.RamasX;
                DT_AlzadoSeleccionado.Columns[ColumnName].ReadOnly = true;
            }
            else
            {
                elementoBorde = null;
                DT_AlzadoSeleccionado.Columns[ColumnName].ReadOnly = false;
                DT_AlzadoSeleccionado.Rows[indice][ColumnName] = 0f;
                DT_AlzadoSeleccionado.Columns[ColumnName].ReadOnly = true;
            }
        }

        private void UploadEbe(int indice, string DiametroEstribo, ElementoDeBorde elementoBorde, string ColumnName)
        {
            if (elementoBorde != null)
            {
                switch (DiametroEstribo)
                {
                    case "#3":
                        elementoBorde.DiametroEstribo = Diametro.Num3;
                        break;
                    case "#4":
                        elementoBorde.DiametroEstribo = Diametro.Num4;
                        break;
                    case "#5":
                        elementoBorde.DiametroEstribo = Diametro.Num5;
                        break;
                }

                elementoBorde.CalculoCuantiaVolumetrica(elementoBorde.SepEstribo, elementoBorde.DiametroEstribo);
                DT_AlzadoSeleccionado.Columns[ColumnName].ReadOnly = false;
                DT_AlzadoSeleccionado.Rows[indice][ColumnName] = elementoBorde.RamasX;
                DT_AlzadoSeleccionado.Columns[ColumnName].ReadOnly = true;
            }
        }
    }
}
