using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Alzado
    {
        public string AlzadoId { get; set; }
        public string AlzadoName { get; set; }
        public List<Muro> Muros { get; set; }
        public List<Refuerzo> RefuerzosLongitudinales { get; set; }
        public List<Refuerzo> Estribos { get; set; }
        public Alzado(string nombre,List<Muro>murosAlzado)
        {
            AlzadoName = nombre;
            Muros = murosAlzado;
            AlzadoId = Guid.NewGuid().ToString();
        }
    }
}
