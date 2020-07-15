using DataAcces;
using DisenioMurosAyG.Views;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
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
        public Alzado AlzadoSeleccionado { get; set; }
        public List<CapaRefuerzo> CapasRefuerzos { get; set; }
        public Muro MuroSeleccionado { get; set; }
        public DataTable DT_AlzadoSeleccionado { get; set; }
        public DataTable DT_AyudaAlzadoSeleccionado { get; set; }
        public bool ExisteDespiece { get; set; }

        public DespieceController(DespieceView despieceView, Alzado alzadoi)
        {
            _contex = Program._context;
            DespieceView = despieceView;
            AlzadoSeleccionado = alzadoi;

            DespieceView.gvDespieceMuro.CellEndEdit += new GridViewCellEventHandler(EditMuroCommand);
            despieceView.gvDespieceMuro.ContextMenuOpening += new ContextMenuOpeningEventHandler(ColumnContextMenuOpening);

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
                DataGridController.CrearColumna("AsReq",typeof(float),true),
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
                        int x = 6;
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
        }

        private void AddColumns(RadGridView gridView)
        {
            DataGridController.AddGridViewColumn(gridView, typeof(GridViewTextBoxColumn), typeof(string), "Piso", "Piso", "Piso", true);
            DataGridController.AddGridViewColumn(gridView, typeof(GridViewTextBoxColumn), typeof(string), "Nivel (m)", "Nivel (m)", "Nivel (m)", true);
            DataGridController.AddGridViewColumn(gridView, typeof(GridViewTextBoxColumn), typeof(string), "Muro", "Muro", "Muro", true);
            DataGridController.AddGridViewColumn(gridView, typeof(GridViewTextBoxColumn), typeof(string), "Nombre Definitivo", "Nombre Definitivo", "Nombre Definitivo", true);
            DataGridController.AddGridViewColumn(gridView, typeof(GridViewTextBoxColumn), typeof(string), "AsReq", "AsReq", "AsReq", true);
            DataGridController.AddGridViewColumn(gridView, typeof(GridViewTextBoxColumn), typeof(string), "AsTotal", "AsTotal", "AsTotal", true);

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

        private void AddCapaDespiece(object sender, EventArgs e)
        {
            var capaRefuerzo = new CapaRefuerzo();

            EditarCapaView = new EditarCapaView();
            EditarCapaView.ListTraslapo.DataSource = Enum.GetValues(typeof(Traslapo));
            EditarCapaView.cbAceptar.Click += new EventHandler(AceptarCapaClick);

            EditarCapaView.tbNombreCapa.DataBindings.Add("Text", capaRefuerzo, "CapaNombre", true, DataSourceUpdateMode.OnPropertyChanged);
            EditarCapaView.tbNumeroCapas.DataBindings.Add("Text", capaRefuerzo, "Cantidad", true, DataSourceUpdateMode.OnPropertyChanged);
            EditarCapaView.ListTraslapo.DataBindings.Add("Text", capaRefuerzo, "Traslapo", true, DataSourceUpdateMode.OnPropertyChanged);
            EditarCapaView.ShowDialog();

            if (capaRefuerzo.CapaNombre != string.Empty)
            {
                var Columnas = new List<DataColumn>(){
                DataGridController.CrearColumna(capaRefuerzo.CapaNombre, typeof(string), false)};
                DataGridController.Set_Columns_Data(DT_AlzadoSeleccionado, Columnas);
                DataGridController.AddGridViewColumn(DespieceView.gvDespieceMuro, typeof(GridViewTextBoxColumn), typeof(string), capaRefuerzo.CapaNombre, capaRefuerzo.CapaNombre, capaRefuerzo.CapaNombre, false);
            }
        }

        private void ColumnContextMenuOpening(object sender, Telerik.WinControls.UI.ContextMenuOpeningEventArgs e)
        {
            var controlprovider = e.ContextMenuProvider as GridHeaderCellElement;

            if (controlprovider != null)
            {
                IndiceCapaRefuerzo = controlprovider.ColumnIndex;
                e.ContextMenu.Items.Clear();

                RadMenuItem AgregarCapa = new RadMenuItem("Agregar capa de refuerzo");
                AgregarCapa.Click += new EventHandler(AddCapaDespiece);
                e.ContextMenu.Items.Add(AgregarCapa);

                RadMenuItem EditarCapa = new RadMenuItem();
                EditarCapa.Text = $"Editar capa {controlprovider.AccessibleName}";
                EditarCapa.Click += new EventHandler(EditarCapaDespiece);
                e.ContextMenu.Items.Add(EditarCapa);

                RadMenuItem EliminarCapa = new RadMenuItem();
                EliminarCapa.Text = $"Eliminar capa {controlprovider.AccessibleName}";
                EliminarCapa.Click += new EventHandler(EliminarCapaDespiece);
                e.ContextMenu.Items.Add(EliminarCapa);
            }

        }

        private void EliminarCapaDespiece(object sender, EventArgs e)
        {

        }

        private void EditarCapaDespiece(object sender, EventArgs e)
        {

        }

        private void EditMuroCommand(object sender, GridViewCellEventArgs e)
        {
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

                var ValorCelda = DespieceView.gvDespieceMuro.Rows[indice].Cells[column].Value.ToString();
                int Diametro = 0;

                if (ValorCelda != string.Empty)
                {
                    if (int.TryParse(ValorCelda, out Diametro))
                    {
                        if (Diametro >= 3 && Diametro <= 8)
                        {
                            foreach (var muroi in MurosSeleccionados)
                            {
                                barra = EditBarraMuro(ColumnName, CapaRefuerzo, Diametro, muroi);
                            }
                        }
                        else
                        {
                            ValorCelda = "Error";
                        }
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
                                muroi.BarrasMuros.RemoveAt(index);
                        }
                    }
                }
            }
        }

        private static BarraMuro EditBarraMuro(string ColumnName, CapaRefuerzo CapaRefuerzo, int Diametro, Muro muroi)
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
                muroi.BarrasMuros = new List<BarraMuro>
                                    {
                                        barra
                                    };
            }

            return barra;
        }
    }
}