using Entidades;
using Entidades.Factorias;
using Entidades.ImportarInformacion;
using Entidades.LecturaExcel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAcces
{
    public class ModeloContext : ApplicationContext
    {
        public List<Alzado> Alzados { get; set; }
        public List<Muro> Muros { get; set; }
        public List<Refuerzo> Refuerzos { get; set; }
        public List<Refuerzo> Estribos { get; set; }
        public string RutaArchivoDisenio { get; set; }
        public string RutaArchivoDespiece { get; set; }
        public GradoDisipacionEnergia GradoDisipacionEnergia { get; set; }
        public ModeloContext()
        {

        }
        public ModeloContext(string RutaArchivo1, string RutaArchivo2, GradoDisipacionEnergia disipacionEnergia)
        {
            RutaArchivoDisenio = RutaArchivo1;
            RutaArchivoDespiece = RutaArchivo2;
            GradoDisipacionEnergia = disipacionEnergia;
        }

        public void LoadDisenioContext(string prueba)
        {
            if (File.Exists(RutaArchivoDisenio))
            {

            }
        }

        public void LoadDisenioContext()
        {
            if (File.Exists(RutaArchivoDisenio))
            {
                ImportarExcel Modelo = new ImportarDisenio(RutaArchivoDisenio);
                Modelo.ExtraerInformacion(GradoDisipacionEnergia);
                Modelo.CerrarExcel();

                var AlzadosBuilder = new AlzadosFactory(Modelo.MuroFactory.Muros);

                var PierUnicos = Modelo.MuroFactory.Muros.Select(x => x.Label).Distinct();
                Alzados = new List<Alzado>();

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
                        }
                        else
                            alzadoi.IsMaestro = true;
                    }
                    else
                        alzadoi.IsMaestro = true;

                    Alzados.Add(alzadoi);
                }
                Muros = Modelo.MuroFactory.Muros;

            }
        }

        public  void LoadDespieceContext()
        {
            if (File.Exists(RutaArchivoDespiece))
            {
                ImportarExcel Modelo = new ImportarDespiece(RutaArchivoDespiece);
                Modelo.MurosModelo = this.Muros;
                Modelo.ExtraerInformacion();
                Modelo.CerrarExcel();
            }
        }
    }
}
