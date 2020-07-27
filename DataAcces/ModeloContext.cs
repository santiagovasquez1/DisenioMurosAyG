using Entidades;
using Entidades.Factorias;
using Entidades.ImportarInformacion;
using Entidades.LecturaExcel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAcces
{
    [Serializable]
    public class ModeloContext
    {
        public BindingList<Alzado> Alzados { get; set; }
        public BindingList<Muro> Muros { get; set; }
        public List<Malla> Mallas { get; set; }
        public string RutaArchivoDisenio { get; set; }
        public string RutaArchivoDespiece { get; set; }
        public GradoDisipacionEnergia GradoDisipacionEnergia { get; set; }
        public ModeloContext()
        {
            LoadMallasPredef();
        }
        public ModeloContext(string RutaArchivo1, string RutaArchivo2, GradoDisipacionEnergia disipacionEnergia)
        {
            RutaArchivoDisenio = RutaArchivo1;
            RutaArchivoDespiece = RutaArchivo2;
            GradoDisipacionEnergia = disipacionEnergia;
            LoadMallasPredef();
        }

        public void LoadDisenioContext()
        {
            if (File.Exists(RutaArchivoDisenio))
            {
                ImportarExcel Modelo = new ImportarDisenio(RutaArchivoDisenio);
                Modelo.ExtraerInformacion(GradoDisipacionEnergia,Mallas);
                Modelo.CerrarExcel();

                var AlzadosBuilder = new AlzadosFactory(Modelo.MuroFactory.Muros);

                var PierUnicos = Modelo.MuroFactory.Muros.Select(x => x.Label).Distinct();
                Alzados = new BindingList<Alzado>();

                foreach (var Pier in PierUnicos)
                {
                    AlzadosBuilder.CrearAlzado(Pier);
                    var alzadoi = AlzadosBuilder.Alzado;

                    if (Alzados.Count > 0)
                    {
                        var padre = (from alzado in Alzados
                                     where alzado.NombreDef == alzadoi.NombreDef
                                     select alzado).FirstOrDefault();
                        if (padre != null)
                        {
                            alzadoi.PadreId = padre.AlzadoId;
                            alzadoi.Padre = padre;
                            alzadoi.Dibujar = false;
                        }
                        else
                        {
                            alzadoi.IsMaestro = true;
                            alzadoi.Dibujar = true;
                        }

                    }
                    else
                    {
                        alzadoi.IsMaestro = true;
                        alzadoi.Dibujar = true;
                    }


                    Alzados.Add(alzadoi);
                }
                Muros = new BindingList<Muro>(Modelo.MuroFactory.Muros);

            }
        }

        public void LoadDespieceContext()
        {
            if (File.Exists(RutaArchivoDespiece))
            {
                ImportarExcel Modelo = new ImportarDespiece(RutaArchivoDespiece);
                Modelo.MurosModelo = this.Muros.ToList();
                Modelo.ExtraerInformacion();
                Modelo.CerrarExcel();
                          
            }
        }

        public void LoadMallasPredef()
        {
            var MallasTemp = new List<Malla>()
            {
                new Malla("M10-1", Diametro.Num2,2, 0.25f,0.25f, 0.10f),
                new Malla("M10-2", Diametro.Num2,1, 0.25f,0.25f, 0.10f),
                new Malla("M12-1", Diametro.Num2,2, 0.20f,0.20f, 0.125f),
                new Malla("M12-2", Diametro.Num2,2, 0.35f,0.35f, 0.125f),
                new Malla("M12-3", Diametro.Num2,2, 0.35f,0.20f, 0.125f),
                new Malla("M15-1", Diametro.Num2,2, 0.175f,0.175f, 0.15f),
                new Malla("M15-2", Diametro.Num2,2, 0.35f,0.35f, 0.15f),
                new Malla("M15-3", Diametro.Num2,2, 0.35f,0.175f, 0.15f),
                new Malla("M20-1", Diametro.Num3,2, 0.25f,0.25f, 0.20f),
            };

            Mallas = MallasTemp;
        }
    }
}
