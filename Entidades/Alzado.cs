using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Alzado
    {
        public string AlzadoId { get; set; }
        public string AlzadoName { get; set; }
        public string NombreDef { get; set; }
        public bool IsMaestro { get; set; }
        public string PadreId { get; set; }
        public Alzado Padre { get; set; }
        public List<Muro> Muros { get; set; }
        public List<Refuerzo> RefuerzosLongitudinales { get; set; }
        public List<Refuerzo> Estribos { get; set; }
        public Alzado(string nombre,string nombredef,List<Muro>murosAlzado)
        {
            AlzadoName = nombre;
            NombreDef = nombredef;
            Muros = murosAlzado;
            AlzadoId = Guid.NewGuid().ToString();
        }
        public override string ToString()
        {
            return $"{ AlzadoName}";
        }
    }
}
