﻿using DataAcces;
using DisenioMurosAyG.Views;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace DisenioMurosAyG.Controller
{
    public class DespieceController
    {
        public ModeloContext _contex { get; set; }
        public DespieceView DespieceView { get; set; }
        public AgregarCapaView AgregarCapaView { get; set; }
        public Alzado AlzadoSeleccionado { get; set; }
        public Muro MuroSeleccionado { get; set; }
        public DataTable DT_AlzadoSeleccionado { get; set; }
        public bool ExisteDespiece { get; set; }

        public DespieceController(DespieceView despieceView, Alzado alzadoi)
        {
            _contex = Program._context;
            DespieceView = despieceView;
            AlzadoSeleccionado = alzadoi;

            DespieceView.cbAgregarCapa.Click += new EventHandler(AddCapaDespiece);
            DespieceView.gvDespieceMuro.CellEndEdit += new GridViewCellEventHandler(EditMuroCommand);

            Set_Columns_Data_Alzado();
            LoadAlzadoData();
            Cargar_DataGrid();
        }

        private void AceptarCapaClick(object sender, EventArgs e)
        {
            if (AgregarCapaView.tbNombreCapa.Text != "")
                AgregarCapaView.Close();
        }

        private void Set_Columns_Data_Alzado()
        {
            DT_AlzadoSeleccionado = new DataTable();

            var Columnas = new List<DataColumn>()
            {
                DataGridController.CrearColumna("Piso",typeof(string),true),
                DataGridController.CrearColumna("Nivel (m)",typeof(string),true),
                DataGridController.CrearColumna("Muro",typeof(string),true),
                DataGridController.CrearColumna("Nombre Definitivo",typeof(string),true),
                DataGridController.CrearColumna("AsReq",typeof(float),true),
                DataGridController.CrearColumna("AsTotal",typeof(float),false),
            };

            ExisteDespiece = AlzadoSeleccionado.Muros.Exists(x => x.BarrasMuros != null);

            if (ExisteDespiece == true)
            {
                List<BarraMuro> Alzados = ExtraerAlzados();

                foreach (var alzadoi in Alzados)
                    Columnas.Add(DataGridController.CrearColumna(alzadoi.BarraId, typeof(string), false));
            }

            DataGridController.Set_Columns_Data(DT_AlzadoSeleccionado, Columnas);

        }

        private List<BarraMuro> ExtraerAlzados()
        {
            var NumBarrasMax = (from muro in AlzadoSeleccionado.Muros
                                where muro.BarrasMuros != null
                                select muro.BarrasMuros.Count).ToList().Max();

            var Alzados = (from muro in AlzadoSeleccionado.Muros
                           where muro.BarrasMuros != null
                           where muro.BarrasMuros.Count == NumBarrasMax
                           select muro).FirstOrDefault().BarrasMuros.ToList();
            return Alzados;
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
                dataRow[3] = muro.LabelDef;
                dataRow[4] = muro.AsAdicional;
                dataRow[5] = muro.AsTotalAdicional;

                if (ExisteDespiece == true)
                {
                    if (muro.BarrasMuros != null)
                    {
                        int x = 6;
                        foreach (var barra in muro.BarrasMuros)
                        {
                            dataRow[x] = $"{barra.Cantidad}#{DiccionariosRefuerzo.ReturnNombreDiametro(barra.Diametro)}";
                            x++;
                        }
                    }
                }

                DT_AlzadoSeleccionado.Rows.Add(dataRow);
            }
        }
        private void Cargar_DataGrid()
        {
            DespieceView.gvDespieceMuro.AutoGenerateColumns = false;
            DespieceView.gvDespieceMuro.DataSource = DT_AlzadoSeleccionado;
            AddColumns(DespieceView.gvDespieceMuro);

            DespieceView.gvDespieceMuro.Columns["AsReq"].FormatString = "{0:F3}";
            DespieceView.gvDespieceMuro.Columns["AsTotal"].FormatString = "{0:F3}";
            DespieceView.gvDespieceMuro.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            DespieceView.gvDespieceMuro.ReadOnly = false;
            DespieceView.gvDespieceMuro.AllowColumnReorder = false;
            DespieceView.gvDespieceMuro.AllowAddNewRow = false;
            DespieceView.gvDespieceMuro.AllowDragToGroup = false;
            DespieceView.gvDespieceMuro.SelectionMode = GridViewSelectionMode.CellSelect;
            DespieceView.gvDespieceMuro.MultiSelect = true;
        }

        private void AddColumns(RadGridView gridView)
        {
            DataGridController.AddGridViewColumn<GridViewColumn>(gridView, typeof(GridViewTextBoxColumn), typeof(string), "Piso", "Piso", "Piso", true, null);
            DataGridController.AddGridViewColumn<GridViewColumn>(gridView, typeof(GridViewTextBoxColumn), typeof(string), "Nivel (m)", "Nivel (m)", "Nivel (m)", true, null);
            DataGridController.AddGridViewColumn<GridViewColumn>(gridView, typeof(GridViewTextBoxColumn), typeof(string), "Muro", "Muro", "Muro", true, null);
            DataGridController.AddGridViewColumn<GridViewColumn>(gridView, typeof(GridViewTextBoxColumn), typeof(string), "Nombre Definitivo", "Nombre Definitivo", "Nombre Definitivo", true, null);
            DataGridController.AddGridViewColumn<GridViewColumn>(gridView, typeof(GridViewTextBoxColumn), typeof(string), "AsReq", "AsReq", "AsReq", true, null);
            DataGridController.AddGridViewColumn<GridViewColumn>(gridView, typeof(GridViewTextBoxColumn), typeof(string), "AsTotal", "AsTotal", "AsTotal", true, null);

            if (ExisteDespiece == true)
            {
                List<BarraMuro> Alzados = ExtraerAlzados();

                foreach (var alzadoi in Alzados)
                    DataGridController.AddGridViewColumn<GridViewColumn>(gridView, typeof(GridViewTextBoxColumn), typeof(string), alzadoi.BarraId, alzadoi.BarraDenom, alzadoi.BarraId, false, null);
            }
        }

        private void AddCapaDespiece(object sender, EventArgs e)
        {
            BarraMuro NuevaCapa = null;
            AgregarCapaView = new AgregarCapaView();
            AgregarCapaView.ListTraslapo.DataSource = Enum.GetValues(typeof(Traslapo));
            AgregarCapaView.cbAceptar.Click += new EventHandler(AceptarCapaClick);
            AgregarCapaView.ShowDialog();

            string barraDenom = AgregarCapaView.tbNombreCapa.Text;
            if (barraDenom != "")
                NuevaCapa = new BarraMuro(barraDenom, Traslapo.T);

            if (NuevaCapa != null)
            {
                var Columnas = new List<DataColumn>(){
                DataGridController.CrearColumna(NuevaCapa.BarraId, typeof(string), false)};
                DataGridController.Set_Columns_Data(DT_AlzadoSeleccionado, Columnas);
                DataGridController.AddGridViewColumn<GridViewColumn>(DespieceView.gvDespieceMuro, typeof(GridViewTextBoxColumn), typeof(string), NuevaCapa.BarraId, NuevaCapa.BarraDenom, NuevaCapa.BarraId, false, null);
            }
        }

        private void EditMuroCommand(object sender, GridViewCellEventArgs e)
        {
            int indice = e.RowIndex;
            int column = e.ColumnIndex;
            var ColumnHeader = DespieceView.gvDespieceMuro.Rows[indice].Cells[column].ColumnInfo.HeaderText;
            string[] infoRef;
            int Cantidad = 0;
            string diametro = "";
            Traslapo traslapo = Traslapo.T;
            List<Muro> MurosSeleccionados = new List<Muro>();

            MuroSeleccionado = AlzadoSeleccionado.Muros[indice];
            var CapaRef = DespieceView.gvDespieceMuro.Rows[indice].Cells[column].Value.ToString();

            if (AlzadoSeleccionado.IsMaestro)
            {
                MurosSeleccionados = (from Alzado in _contex.Alzados
                                      where Alzado.PadreId == AlzadoSeleccionado.AlzadoId | Alzado.AlzadoId == AlzadoSeleccionado.AlzadoId
                                      select Alzado.Muros[indice]).ToList();
            }
            else
                MurosSeleccionados.Add(MuroSeleccionado);

            if (CapaRef != "" && CapaRef.Contains("#"))
            {
                if (CapaRef.ToLower().Contains("t") == false)
                {
                    infoRef = CapaRef.Split('#');
                    Cantidad = int.Parse(infoRef[0]);
                    diametro = infoRef[1];
                    traslapo = Traslapo.T;
                }
                else
                {
                    infoRef = CapaRef.ToLower().Split(new char[] { '#', 't' });
                    Cantidad = int.Parse(infoRef[0]);
                    diametro = infoRef[1];

                    switch (infoRef[3])
                    {
                        case "1":
                            traslapo = Traslapo.T1;
                            break;
                        case "2":
                            traslapo = Traslapo.T2;
                            break;
                        case "3":
                            traslapo = Traslapo.T3;
                            break;
                        default:
                            traslapo = Traslapo.T;
                            break;
                    }
                }

                foreach (var muro in MurosSeleccionados)
                {
                    if (muro.BarrasMuros != null)
                    {
                        var indiceBarra = muro.BarrasMuros.FindIndex(x => x.BarraDenom == ColumnHeader);

                        if (indiceBarra >= 0)
                        {
                            var Barra = muro.BarrasMuros[indiceBarra];
                            Barra.Cantidad = Cantidad;
                            Barra.Diametro = DiccionariosRefuerzo.ReturnDiametro(diametro);
                        }
                        else
                        {
                            var Barra = new BarraMuro(muro.Label, muro, ColumnHeader, Cantidad, DiccionariosRefuerzo.ReturnDiametro(diametro), traslapo);
                            muro.BarrasMuros.Add(Barra);
                        }
                        muro.CalcAsTotal();
                        DespieceView.gvDespieceMuro.Columns["AsTotal"].ReadOnly = false;
                        DespieceView.gvDespieceMuro.Rows[indice].Cells["AsTotal"].Value = muro.AsTotalAdicional;
                        DespieceView.gvDespieceMuro.Columns["AsTotal"].ReadOnly = true;
                    }
                    else
                    {
                        var Barra = new BarraMuro(muro.Label, muro, ColumnHeader, Cantidad, DiccionariosRefuerzo.ReturnDiametro(diametro), traslapo);
                        muro.BarrasMuros = new List<BarraMuro>();
                        muro.BarrasMuros.Add(Barra);
                        muro.CalcAsTotal();
                        DespieceView.gvDespieceMuro.Columns["AsTotal"].ReadOnly = false;
                        DespieceView.gvDespieceMuro.Rows[indice].Cells["AsTotal"].Value = muro.AsTotalAdicional;
                        DespieceView.gvDespieceMuro.Columns["AsTotal"].ReadOnly = true;
                    }
                }

            }
        }
    }
}