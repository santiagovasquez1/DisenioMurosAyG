using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Muro
    {
        public string MuroId { get; set; }
        public string Label { get; set; }
        public GradoDisipacionEnergia GradoDisipacionEnergia { get; set; }
        public float bw { get; set; }
        public float lw { get; set; }
        public float hw { get; set; }
        public float rhot { get; set; }
        public float rhol { get; set; }
        public float Ast { get; set; }
        public float Ash { get; set; }
        public float AsAdicional { get; set; }
        public int Capas { get; set; }
        public float fc { get; set; }
        public Story Story { get; set; }
        public bool IsMaestro { get; set; }
        public string MuroPadreId { get; set; }
        public Muro MuroPadre { get; set; }
        public Refuerzo Malla { get; set; }
        public List<Refuerzo> RefuerzosLongitudinales { get; set; }
        public List<Refuerzo> Estribos { get; set; }
        public ElementoDeBorde EBE_Izq { get; set; }
        public ElementoDeBorde EBE_Der { get; set; }
        public ElementoDeBorde Zc_Izq { get; set; }
        public ElementoDeBorde Zc_Der { get; set; }
        public Muro()
        {
            MuroId = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{ Label}-{Story.StoryName}";
        }
    }
}