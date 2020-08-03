using DataAcces;
using DisenioMurosAyG.Views;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace DisenioMurosAyG.Controller
{
    public class DespieceController
    {
        public ModeloContext _contex { get; set; }
        public int IndiceCapaRefuerzo { get; set; }
        public DespieceView DespieceView { get; set; }
        public EditarCapaView EditarCapaView { get; set; }
        public EditarCapaController EditarCapaController { get; set; }
        public Alzado AlzadoSeleccionado { get; set; }
        public CapaRefuerzo CapaRefuerzoSeleccionada { get; set; }
        public Muro MuroSeleccionado { get; set; }
        public DataTable DT_AlzadoSeleccionado { get; set; }
        public DataTable DT_AyudaAlzadoSeleccionado { get; set; }
        public string ColumnaSeleccionadaName { get; set; }
        public bool ExisteDespiece { get; set; }
        private GridViewCellStyle defaultStyle;

        public DespieceController(DespieceView despieceView, Alzado alzadoi)
        {
            _contex = Program._context;
            DespieceView = despieceView;
            AlzadoSeleccionado = alzadoi;

           DespieceView.gvDespieceMuro.CellEndEdit += new GridViewCellEventHandler(EditMuroCommand);
            DespieceView.gvDespieceMuro.ContextMenuOpening += new ContextMenuOpeningEventHandler(ColumnContextMenuOpening);

            Set_Columns_Data_Alzado();
            LoadAlzadoData();
            Cargar_DataGrid();
        }

        private void AceptarCapaClick(object sender, EventArgs e)
        {
            if (EditarCapaView.tbNombreCapa.Text != "")
                EditarCapaView.Close();
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
                DataGridController.CrearColumna("AsReq",typeof(float),false),
                DataGridController.CrearColumna("AsTotal",typeof(float),false),
            };

            ExisteDespiece = AlzadoSeleccionado.Muros.Exists(x => x.BarrasMuros != null);

            if (ExisteDespiece == true)
            {
                List<BarraMuro> Alzados = ExtraerAlzados();
                int x = 0;
                foreach (var alzadoi in Alzados)
                {
                    Columnas.Add(DataGridController.CrearColumna(alzadoi.CapaRefuerzo.CapaId, typeof(string), false));
                    x++;
                }
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
                        string ColumnName = string.Empty;

                        foreach (var barra in muro.BarrasMuros)
                        {
                            foreach (DataColumn col in DT_AlzadoSeleccionado.Columns)
                            {
                                if (col.ColumnName == barra.CapaRefuerzo.CapaId)
                                {
                                    ColumnName = col.ColumnName;
                                    break;
                                }
                            }

                            dataRow[ColumnName] = int.Parse(DiccionariosRefuerzo.ReturnNombreDiametro(barra.Diametro, 1));
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
            defaultStyle = DespieceView.gvDespieceMuro.Rows[0].Cells["AsTotal"].Style;

            DespieceView.gvDespieceMuro.Columns["AsReq"].FormatString = "{0:F2}";
            DespieceView.gvDespieceMuro.Columns["AsTotal"].FormatString = "{0:F2}";
            DespieceView.gvDespieceMuro.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            DespieceView.gvDespieceMuro.ReadOnly = false;
            DespieceView.gvDespieceMuro.AllowColumnReorder = false;
            DespieceView.gvDespieceMuro.AllowAddNewRow = false;
            DespieceView.gvDespieceMuro.AllowDragToGroup = false;
            DespieceView.gvDespieceMuro.SelectionMode = GridViewSelectionMode.CellSelect;
            DespieceView.gvDespieceMuro.MultiSelect = true;

            DespieceView.gvDespieceMuro.TableElement.TableHeaderHeight = 80;

            for (int i = 0; i < DespieceView.gvDespieceMuro.RowCount; i++)
            {
                WarningAs(AlzadoSeleccionado.Muros[i], i);
            }

        }

        private void AddColumns(RadGridView gridView)
        {
            DataGridController.AddGridViewColumn(gridView, typeof(GridViewTextBoxColumn), typeof(string), "Piso", "Piso", "Piso", true);
            DataGridController.AddGridViewColumn(gridView, typeof(GridViewTextBoxColumn), typeof(string), "Nivel (m)", "Nivel (m)", "Nivel (m)", true);
            DataGridController.AddGridViewColumn(gridView, typeof(GridViewTextBoxColumn), typeof(string), "Muro", "Muro", "Muro", true);
            DataGridController.AddGridViewColumn(gridView, typeof(GridViewTextBoxColumn), typeof(string), "Nombre Definitivo", "Nombre Definitivo", "Nombre Definitivo", true);
            DataGridController.AddGridViewColumn(gridView, typeof(GridViewTextBoxColumn), typeof(float), "AsReq", "AsReq", "AsReq", true);
            DataGridController.AddGridViewColumn(gridView, typeof(GridViewTextBoxColumn), typeof(float), "AsTotal", "AsTotal", "AsTotal", true);

            if (ExisteDespiece == true)
            {
                List<BarraMuro> Alzados = ExtraerAlzados();

                int x = 0;
                foreach (var alzadoi in Alzados)
                {
                    var ColumnHeaderText = $"{ alzadoi.BarraDenom}\nCantidad: {alzadoi.CapaRefuerzo.Cantidad}\nTraslapo: {alzadoi.CapaRefuerzo.Traslapo.ToString()}";

                    DataGridController.AddGridViewColumn(gridView, typeof(GridViewTextBoxColumn), typeof(string), alzadoi.CapaRefuerzo.CapaId, ColumnHeaderText, alzadoi.CapaRefuerzo.CapaId, false);
                    x++;
                }
            }
        }


        private void ColumnContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
            var controlprovider = e.ContextMenuProvider as GridHeaderCellElement;

            if (controlprovider != null)
            {
                ExisteDespiece = AlzadoSeleccionado.Muros.Exists(x => x.BarrasMuros != null);

                if (ExisteDespiece == true)
                {
                    CapaRefuerzoSeleccionada = (from barrai in AlzadoSeleccionado.Muros.LastOrDefault().BarrasMuros
                                                where barrai.CapaRefuerzo.CapaId == controlprovider.ColumnInfo.Name
                                                select barrai.CapaRefuerzo).FirstOrDefault();
                }


                ColumnaSeleccionadaName = controlprovider.ColumnInfo.Name;

                IndiceCapaRefuerzo = controlprovider.ColumnIndex;
                e.ContextMenu.Items.Clear();

                RadMenuItem AgregarCapa = new RadMenuItem("Agregar capa de refuerzo");
                AgregarCapa.Click += new EventHandler(AddCapaDespieceClick);
                e.ContextMenu.Items.Add(AgregarCapa);

                if (CapaRefuerzoSeleccionada != null)
                {
                    RadMenuItem EditarCapa = new RadMenuItem();
                    EditarCapa.Text = $"Editar capa {CapaRefuerzoSeleccionada.CapaNombre}";
                    EditarCapa.Click += new EventHandler(EditarCapaDespieceClick);
                    e.ContextMenu.Items.Add(EditarCapa);

                    RadMenuItem EliminarCapa = new RadMenuItem();
                    EliminarCapa.Text = $"Eliminar capa {CapaRefuerzoSeleccionada.CapaNombre}";
                    EliminarCapa.Click += new EventHandler(EliminarCapaDespiece);
                    e.ContextMenu.Items.Add(EliminarCapa);
                }

            }

        }

        private void EliminarCapaDespiece(object sender, EventArgs e)
        {
            var barras = (from prueba in AlzadoSeleccionado.Muros
                          where prueba.BarrasMuros != null
                          from barra in prueba.BarrasMuros
                          where barra.CapaRefuerzo.CapaId == CapaRefuerzoSeleccionada.CapaId
                          select barra).ToList();

            foreach (var muro in AlzadoSeleccionado.Muros)
            {
                if (muro.BarrasMuros != null)
                {
                    var barrai = (from prueba in barras
                                  where prueba.Muro.MuroId == muro.MuroId
                                  select prueba).FirstOrDefault();

                    muro.BarrasMuros.Remove(barrai);
                    muro.CalcAsTotal();

                    var indice = AlzadoSeleccionado.Muros.FindIndex(x => x.MuroId == muro.MuroId);
                    if (indice >= 0)
                        DespieceView.gvDespieceMuro.Rows[indice].Cells["AsTotal"].Value = muro.AsTotalAdicional;
                }
            }

            var ColumnaEliminar = (from DataColumn columna in DT_AlzadoSeleccionado.Columns
                                   where columna.ColumnName == CapaRefuerzoSeleccionada.CapaId
                                   select columna).FirstOrDefault();

            var ColumnaEliminar2 = (from GridViewColumn columna in DespieceView.gvDespieceMuro.Columns
                                    where columna.Name == CapaRefuerzoSeleccionada.CapaId
                                    select columna).FirstOrDefault();


            DT_AlzadoSeleccionado.Columns.Remove(ColumnaEliminar);
            DespieceView.gvDespieceMuro.Columns.Remove(ColumnaEliminar2.Name);
        }

        private void AddCapaDespieceClick(object sender, EventArgs e)
        {
            var capaRefuerzo = new CapaRefuerzo();
            EditarCapaView = new EditarCapaView();

            EditarCapaController = new EditarCapaController(EditarCapaView, capaRefuerzo, AlzadoSeleccionado, this, TipoEdicionCapa.Nuevo);
            EditarCapaView.ShowDialog();
        }
        public void AddCapaDespiece()
        {
            if (EditarCapaController.CapaRefuerzo.CapaNombre != string.Empty && EditarCapaController.CapaRefuerzo.CapaNombre != null)
            {
                var ColumnHeaderText = $"{ EditarCapaController.CapaRefuerzo.CapaNombre}\nCantidad: {EditarCapaController.CapaRefuerzo.Cantidad}\nTraslapo: {EditarCapaController.CapaRefuerzo.Traslapo}";
                if (AlzadoSeleccionado.Muros.LastOrDefault().BarrasMuros == null)
                {
                    var barra = new BarraMuro(AlzadoSeleccionado.Muros.LastOrDefault().Label, AlzadoSeleccionado.Muros.LastOrDefault(), EditarCapaController.CapaRefuerzo);
                    AlzadoSeleccionado.Muros.LastOrDefault().BarrasMuros = new List<BarraMuro>();
                    AlzadoSeleccionado.Muros.LastOrDefault().BarrasMuros.Add(barra);
                }
                else
                {
                    var barra = new BarraMuro(AlzadoSeleccionado.Muros.LastOrDefault().Label, AlzadoSeleccionado.Muros.LastOrDefault(), EditarCapaController.CapaRefuerzo);
                    AlzadoSeleccionado.Muros.LastOrDefault().BarrasMuros.Add(barra);
                }
                var Columnas = new List<DataColumn>(){
                DataGridController.CrearColumna(EditarCapaController.CapaRefuerzo.CapaNombre, typeof(string), false)};
                DataGridController.Set_Columns_Data(DT_AlzadoSeleccionado, Columnas);
                DataGridController.AddGridViewColumn(DespieceView.gvDespieceMuro, typeof(GridViewTextBoxColumn), typeof(string), EditarCapaController.CapaRefuerzo.CapaId, ColumnHeaderText, EditarCapaController.CapaRefuerzo.CapaId, false);
            }
        }

        private void EditarCapaDespieceClick(object sender, EventArgs e)
        {
            EditarCapaView = new EditarCapaView();
            EditarCapaController = new EditarCapaController(EditarCapaView, CapaRefuerzoSeleccionada, AlzadoSeleccionado, this, TipoEdicionCapa.Editar);
            EditarCapaView.ShowDialog();
        }

        public void EditarCapaDespiece()
        {
            var ColumnHeaderText = $"{ CapaRefuerzoSeleccionada.CapaNombre}\nCantidad: {CapaRefuerzoSeleccionada.Cantidad}\nTraslapo: {CapaRefuerzoSeleccionada.Traslapo}";
            DespieceView.gvDespieceMuro.Columns[ColumnaSeleccionadaName].HeaderText = ColumnHeaderText;

            var barras = (from prueba in AlzadoSeleccionado.Muros
                          where prueba.BarrasMuros != null
                          from barra in prueba.BarrasMuros
                          where barra.CapaRefuerzo.CapaId == CapaRefuerzoSeleccionada.CapaId
                          select barra).ToList();

            foreach (var barrai in barras)
            {
                barrai.CapaRefuerzo = CapaRefuerzoSeleccionada;
                barrai.Cantidad = CapaRefuerzoSeleccionada.Cantidad;
                barrai.Traslapo = CapaRefuerzoSeleccionada.Traslapo;

                barrai.Muro.CalcAsTotal();
                var x = AlzadoSeleccionado.Muros.FindIndex(y => y.MuroId == barrai.Muro.MuroId);
                DespieceView.gvDespieceMuro.Rows[x].Cells["AsTotal"].Value = barrai.Muro.AsTotalAdicional;
                x++;
            }

        }

        private void EditMuroCommand(object sender, GridViewCellEventArgs e)
        {
            var ValorCelda = string.Empty;
            int indice = e.RowIndex;
            int column = e.ColumnIndex;
            var ColumnName = DespieceView.gvDespieceMuro.Rows[indice].Cells[column].ColumnInfo.Name;
            BarraMuro barra = null;
            List<Muro> MurosSeleccionados = new List<Muro>();

            MuroSeleccionado = AlzadoSeleccionado.Muros[indice];

            if (AlzadoSeleccionado.IsMaestro)
            {
                MurosSeleccionados = (from Alzado in _contex.Alzados
                                      where Alzado.PadreId == AlzadoSeleccionado.AlzadoId | Alzado.AlzadoId == AlzadoSeleccionado.AlzadoId
                                      select Alzado.Muros[indice]).ToList();
            }
            else
                MurosSeleccionados.Add(MuroSeleccionado);

            if (AlzadoSeleccionado.Muros.LastOrDefault().BarrasMuros != null)
            {
                var CapaRefuerzo = (from barrai in AlzadoSeleccionado.Muros.LastOrDefault().BarrasMuros
                                    where barrai.CapaRefuerzo.CapaId == ColumnName
                                    select barrai.CapaRefuerzo).FirstOrDefault();

                if (CapaRefuerzo == null)
                    CapaRefuerzo = EditarCapaController.CapaRefuerzo;

                if (DespieceView.gvDespieceMuro.Rows[indice].Cells[column].Value != null)
                    ValorCelda = DespieceView.gvDespieceMuro.Rows[indice].Cells[column].Value.ToString();

                int Diametro = 0;

                if (ValorCelda != string.Empty)
                {
                    if (int.TryParse(ValorCelda, out Diametro))
                    {
                        if (Diametro >= 3 && Diametro <= 8)
                        {
                            foreach (var muroi in MurosSeleccionados)
                            {
                                barra = EditBarraMuro(ColumnName, CapaRefuerzo, Diametro, muroi, indice);
                            }
                        }
                        else
                        {
                            DespieceView.gvDespieceMuro.Rows[indice].Cells[column].Value = "Error";
                        }
                    }
                    else
                    {
                        DespieceView.gvDespieceMuro.Rows[indice].Cells[column].Value = "Error";
                    }
                }
                else
                {
                    foreach (var muroi in MurosSeleccionados)
                    {
                        if (muroi.BarrasMuros != null)
                        {
                            var index = muroi.BarrasMuros.FindIndex(x => x.CapaRefuerzo.CapaId == ColumnName);
                            if (index >= 0)
                            {
                                muroi.BarrasMuros.RemoveAt(index);
                                muroi.CalcAsTotal();
                                DespieceView.gvDespieceMuro.Rows[indice].Cells["AsTotal"].Value = muroi.AsTotalAdicional;
                            }

                        }
                    }
                }
            }

            WarningAs(MuroSeleccionado, indice);
        }

        private BarraMuro EditBarraMuro(string ColumnName, CapaRefuerzo CapaRefuerzo, int Diametro, Muro muroi, int indice)
        {
            BarraMuro barra;
            if (muroi.BarrasMuros != null)
            {
                barra = (from barrai in muroi.BarrasMuros
                         where barrai.CapaRefuerzo.CapaId == ColumnName
                         select barrai).FirstOrDefault();
                if (barra != null)
                {
                    barra.Diametro = DiccionariosRefuerzo.ReturnDiametro(Diametro.ToString());
                }
                else
                {
                    barra = new BarraMuro(muroi.Label, muroi, DiccionariosRefuerzo.ReturnDiametro(Diametro.ToString()), CapaRefuerzo);
                    muroi.BarrasMuros.Add(barra);
                }
            }
            else
            {
                barra = new BarraMuro(muroi.Label, muroi, DiccionariosRefuerzo.ReturnDiametro(Diametro.ToString()), CapaRefuerzo);
                muroi.BarrasMuros = new List<BarraMuro> { barra };
            }
            muroi.CalcAsTotal();
            DespieceView.gvDespieceMuro.Rows[indice].Cells["AsTotal"].Value = muroi.AsTotalAdicional;
            return barra;
        }

        private void WarningAs(Muro muro, int indice)
        {
            if (muro.AsTotalAdicional > 0)
            {
                if (muro.AsTotalAdicional / muro.AsAdicional < 0.95)
                {
                    DespieceView.gvDespieceMuro.Rows[indice].Cells["AsTotal"].Style.CustomizeFill = true;
                    DespieceView.gvDespieceMuro.Rows[indice].Cells["AsTotal"].Style.BackColor = Color.FromArgb(221, 79, 67);
                    DespieceView.gvDespieceMuro.Rows[indice].Cells["AsTotal"].Style.BackColor2 = Color.FromArgb(221, 79, 67);
                    DespieceView.gvDespieceMuro.Rows[indice].Cells["AsTotal"].Style.ForeColor = Color.FromArgb(139, 0, 0);
                    DespieceView.gvDespieceMuro.Rows[indice].Cells["AsTotal"].Style.DrawFill = true;
                }
                else
                {
                    DespieceView.gvDespieceMuro.Rows[indice].Cells["AsTotal"].Style.CustomizeFill = false;
                    DespieceView.gvDespieceMuro.Rows[indice].Cells["AsTotal"].Style.ForeColor = defaultStyle.ForeColor;
                }
            }
            else
            {
                DespieceView.gvDespieceMuro.Rows[indice].Cells["AsTotal"].Style.CustomizeFill = false;
                DespieceView.gvDespieceMuro.Rows[indice].Cells["AsTotal"].Style.ForeColor = defaultStyle.ForeColor;

            }

        }
    }
}