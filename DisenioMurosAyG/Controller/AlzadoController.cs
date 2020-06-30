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
using Telerik.WinControls.UI;
using static System.Windows.Forms.DataGridViewComboBoxCell;

namespace DisenioMurosAyG.Controller
{
    public class AlzadoController
    {
        public ModeloContext _contex { get; set; }
        public InformacionAlzadoView InformacionAlzadoView { get; set; }
        public InformacionAlzadoView1 InformacionAlzadoView1 { get; set; }
        public Alzado AlzadoSeleccionado { get; set; }
        public Muro MuroSeleccionado { get; set; }
        public DataTable DT_AlzadoSeleccionado { get; set; }
        public AlzadoController(InformacionAlzadoView1 informacionAlzadoView, Alzado alzadoi)
        {
            _contex = Program._context;
            InformacionAlzadoView1 = informacionAlzadoView;
            AlzadoSeleccionado = alzadoi;

            if (AlzadoSeleccionado != null)
            {
                informacionAlzadoView.dgAlzado.CellEndEdit += new GridViewCellEventHandler(EditMuroCommand);
                Set_Columns_Data_Alzado();
                LoadAlzadoData();
                Cargar_DataGrid();
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
                DataGridController.CrearColumna("Nombre Definitivo",typeof(string),true),
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
                DataGridController.CrearColumna("RhoH",typeof(float),true),
                DataGridController.CrearColumna("RhoV",typeof(float),true),
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
                dataRow[3] = muro.LabelDef;
                dataRow[4] = muro.Lw;
                dataRow[5] = muro.Bw;
                dataRow[6] = muro.Hw;
                dataRow[7] = muro.EBE_Izq != null ? muro.EBE_Izq.LongEbe : (object)0f;
                dataRow[8] = muro.EBE_Der != null ? muro.EBE_Der.LongEbe : (object)0f;

                if (muro.EBE_Izq != null | muro.EBE_Der != null)
                {
                    if (muro.EBE_Izq != null)
                        dataRow[9] = muro.EBE_Izq.SepEstribo;
                    else if (muro.EBE_Der != null)
                        dataRow[9] = muro.EBE_Der.SepEstribo;
                }
                else
                    dataRow[9] = 0f;

                dataRow[10] = muro.EBE_Izq != null ? muro.EBE_Izq.RamasX : (object)0f;
                dataRow[11] = muro.EBE_Der != null ? muro.EBE_Der.RamasX : (object)0f;

                dataRow[12] = muro.Fc;
                dataRow[13] = muro.Fy;
                dataRow[14] = muro.RhoH;
                dataRow[15] = muro.RhoV;
                dataRow[16] = muro.AsH;
                dataRow[17] = muro.AsV;
                dataRow[18] = muro.AsAdicional;

                DT_AlzadoSeleccionado.Rows.Add(dataRow);
            }

        }

        private void Cargar_DataGrid()
        {
            GridViewComboBoxColumn ColumnEstribos = new GridViewComboBoxColumn();
            ColumnEstribos.Name = "Estribos";
            ColumnEstribos.HeaderText = "Estribos";
            ColumnEstribos.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            ColumnEstribos.DataSource = new List<string>() { "#3", "#4", "#5" };

            InformacionAlzadoView1.dgAlzado.DataSource = DT_AlzadoSeleccionado;
            InformacionAlzadoView1.dgAlzado.Columns["Zc_Izq (m)"].FormatString = "{0:F3}";
            InformacionAlzadoView1.dgAlzado.Columns["Zc_Der (m)"].FormatString = "{0:F3}";
            InformacionAlzadoView1.dgAlzado.Columns["Separacion (m)"].FormatString = "{0:F3}";
            InformacionAlzadoView1.dgAlzado.Columns["RhoH"].FormatString = "{0:F4}";
            InformacionAlzadoView1.dgAlzado.Columns["RhoV"].FormatString = "{0:F4}";
            InformacionAlzadoView1.dgAlzado.Columns["RefHoriz (cm²/m)"].FormatString = "{0:F2}";
            InformacionAlzadoView1.dgAlzado.Columns["RefVert (cm²/m)"].FormatString = "{0:F2}";
            InformacionAlzadoView1.dgAlzado.Columns["RefAdicional (cm²)"].FormatString = "{0:F2}";

            try
            {
                InformacionAlzadoView1.dgAlzado.Columns.Remove(InformacionAlzadoView1.dgAlzado.Columns[ColumnEstribos.Name]);
                InformacionAlzadoView1.dgAlzado.Columns.Add(ColumnEstribos);
            }
            catch (Exception)
            {
                InformacionAlzadoView1.dgAlzado.Columns.Add(ColumnEstribos);
            }
            var index = InformacionAlzadoView1.dgAlzado.Columns["Estribos"].Index;
            InformacionAlzadoView1.dgAlzado.Columns.Move(index, 9);
            SetEstribosCells();

            InformacionAlzadoView1.dgAlzado.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            InformacionAlzadoView1.dgAlzado.ReadOnly = false;
            InformacionAlzadoView1.dgAlzado.AllowColumnReorder = false;
            InformacionAlzadoView1.dgAlzado.AllowAddNewRow = false;
            InformacionAlzadoView1.dgAlzado.AllowDragToGroup = false;

        }

        private void SetEstribosCells()
        {
            int x = 0;
            var Estribos = new List<string>() { "#3", "#4", "#5" };

            foreach (var muro in AlzadoSeleccionado.Muros)
            {
                if (muro.EBE_Der != null | muro.EBE_Izq != null)
                {
                    InformacionAlzadoView1.dgAlzado.Rows[x].Cells["Estribos"].ReadOnly = false;
                    if (muro.EBE_Der != null)
                        InformacionAlzadoView1.dgAlzado.Rows[x].Cells["Estribos"].Value = GetEstribo(x, Estribos, muro.EBE_Der.DiametroEstribo);
                    if (muro.EBE_Izq != null)
                        InformacionAlzadoView1.dgAlzado.Rows[x].Cells["Estribos"].Value = GetEstribo(x, Estribos, muro.EBE_Izq.DiametroEstribo);
                }
                else
                    InformacionAlzadoView1.dgAlzado.Rows[x].Cells["Estribos"].ReadOnly = true;

                x++;
            }
        }

        private string GetEstribo(int x, List<string> Estribos, Diametro diametroEbe)
        {
            string Estribo = "";

            switch (diametroEbe)
            {
                case Diametro.Num3:
                    Estribo = Estribos[0];
                    break;
                case Diametro.Num4:
                    Estribo = Estribos[1];
                    break;
                case Diametro.Num5:
                    Estribo = Estribos[2];
                    break;
            }

            return Estribo;
        }

        private void EditMuroCommand(object sender, GridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            int column = e.ColumnIndex;
            var ColumnName = InformacionAlzadoView1.dgAlzado.Rows[indice].Cells[column].ColumnInfo.Name;
            float LongEbe = 0;

            MuroSeleccionado = AlzadoSeleccionado.Muros[indice];

            switch (ColumnName)
            {
                case "L (m)":
                    MuroSeleccionado.Lw = float.Parse(InformacionAlzadoView1.dgAlzado.Rows[indice].Cells[ColumnName].Value.ToString());
                    UploadAsLongMuroSeleccionado(indice, "RefAdicional (cm²)");
                    break;
                case "t (m)":
                    MuroSeleccionado.Bw = float.Parse(InformacionAlzadoView1.dgAlzado.Rows[indice].Cells[ColumnName].Value.ToString());
                    UploadAsLongMuroSeleccionado(indice, "RefAdicional (cm²)");
                    break;
                case "h (m)":
                    MuroSeleccionado.Hw = float.Parse(InformacionAlzadoView1.dgAlzado.Rows[indice].Cells[ColumnName].Value.ToString());
                    break;
                case "Zc_Izq (m)":
                    LongEbe = float.Parse(InformacionAlzadoView1.dgAlzado.Rows[indice].Cells[ColumnName].Value.ToString());
                    UploadEbe(indice, LongEbe, MuroSeleccionado.EBE_Izq, "Ramas Izq");
                    UploadAsLongMuroSeleccionado(indice, "RefAdicional (cm²)");
                    break;
                case "Zc_Der (m)":
                    LongEbe = float.Parse(InformacionAlzadoView1.dgAlzado.Rows[indice].Cells[ColumnName].Value.ToString());
                    UploadEbe(indice, LongEbe, MuroSeleccionado.EBE_Der, "Ramas Der");
                    UploadAsLongMuroSeleccionado(indice, "RefAdicional (cm²)");
                    break;
                case "Estribos":
                    string Diametro = InformacionAlzadoView1.dgAlzado.Rows[indice].Cells[ColumnName].Value.ToString();
                    UploadEbe(indice, Diametro, MuroSeleccionado.EBE_Izq, "Ramas Izq");
                    UploadEbe(indice, Diametro, MuroSeleccionado.EBE_Der, "Ramas Der");
                    break;
                case "Separacion (m)":
                    float separacion = float.Parse(InformacionAlzadoView1.dgAlzado.Rows[indice].Cells[ColumnName].Value.ToString());
                    UploadEbe(indice, MuroSeleccionado.EBE_Izq, separacion, "Ramas Izq");
                    UploadEbe(indice, MuroSeleccionado.EBE_Izq, separacion, "Ramas Der");
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
                    DT_AlzadoSeleccionado.Rows[indice]["Separacion (m)"] = elementoBorde.SepEstribo;
                }
                else
                    elementoBorde.LongEbe = LongEbe;

                DT_AlzadoSeleccionado.Columns[ColumnName].ReadOnly = false;
                DT_AlzadoSeleccionado.Rows[indice][ColumnName] = elementoBorde.RamasX;
                DT_AlzadoSeleccionado.Columns[ColumnName].ReadOnly = true;
            }
            else
            {
                elementoBorde.LongEbe = 0;
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

                DT_AlzadoSeleccionado.Columns[ColumnName].ReadOnly = false;
                DT_AlzadoSeleccionado.Rows[indice][ColumnName] = elementoBorde.RamasX;
                DT_AlzadoSeleccionado.Columns[ColumnName].ReadOnly = true;
            }
        }

        private void UploadEbe(int indice, ElementoDeBorde elementoDeBorde, float separacion, string ColumnName)
        {
            if (elementoDeBorde != null)
            {
                elementoDeBorde.SepEstribo = separacion;
                DT_AlzadoSeleccionado.Columns[ColumnName].ReadOnly = false;
                DT_AlzadoSeleccionado.Rows[indice][ColumnName] = elementoDeBorde.RamasX;
                DT_AlzadoSeleccionado.Columns[ColumnName].ReadOnly = true;
            }

        }

        private void UploadAsLongMuroSeleccionado(int Indice, string ColumnName)
        {
            MuroSeleccionado.UploadAsLong();
            DT_AlzadoSeleccionado.Columns[ColumnName].ReadOnly = false;
            DT_AlzadoSeleccionado.Rows[Indice][ColumnName] = MuroSeleccionado.AsAdicional;
            DT_AlzadoSeleccionado.Columns[ColumnName].ReadOnly = true;
        }
    }
}
