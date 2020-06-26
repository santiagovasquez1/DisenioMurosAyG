﻿using Entidades;
using Entidades.Factorias;
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
    public class ModeloContext: ApplicationContext
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
        public ModeloContext(string RutaArchivo1, string RutaArchivo2,GradoDisipacionEnergia disipacionEnergia)
        {
            RutaArchivoDisenio = RutaArchivo1;
            RutaArchivoDespiece = RutaArchivo2;
            GradoDisipacionEnergia = disipacionEnergia;
        }

        public void LoadDisenioContext(string RutaArchivo1)
        {
            if (File.Exists(RutaArchivo1))
            {
                ImportarDisenio Modelo = new ImportarDisenio(RutaArchivo1);
                Modelo.ExtraerInformacion(GradoDisipacionEnergia);
                Modelo.CerrarExcel();

                var AlzadosBuilder = new AlzadosFactory(Modelo.MuroFactory.Muros);

                var PierUnicos = Modelo.MuroFactory.Muros.Select(x => x.Label).Distinct();
                Alzados = new List<Alzado>();

                foreach (var Pier in PierUnicos)
                {
                    AlzadosBuilder.CrearAlzado(Pier);
                    Alzados.Add(AlzadosBuilder.Alzado);
                }
                Muros = Modelo.MuroFactory.Muros;
            }
        }
    }
}
