using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Factorias
{
    public class AlzadosFactory
    {
        public Alzado Alzado { get; set; }
        public List<Muro> MurosModelo { get; set; }
        public AlzadosFactory(List<Muro> muros)
        {
            MurosModelo = muros;
        }

        public void CrearAlzado(string PierName)
        {
            var MurosAlzado = (from muro in MurosModelo
                              where muro.Label == PierName
                              select muro).ToList();

            Alzado = new Alzado(PierName,MurosAlzado);

        }

    }
}
