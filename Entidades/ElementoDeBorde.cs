using System.Collections.Generic;

namespace Entidades
{
    public abstract class ElementoDeBorde
    {
        public float LongEbe { get; set; }
        public float Tw { get; set; }
        public float Fc { get; set; }
        public float Fy { get; set; }
        public GradoDisipacionEnergia GradoDisipacionEnergia { get; set; }
        public float SepEstribo { get; set; }
        public Diametro DiametroEstribo { get; set; }
        /// <summary>
        /// /Ramas a los largo de la longitud del elemento de borde especial
        /// </summary>
        public int RamasX { get; set; }
        /// <summary>
        /// Ramas a los largo del espesor del elemento de borde especial
        /// </summary>
        public int RamasY { get; set; }
        public List<Refuerzo> Estribos { get; set; }
        public abstract void CalculoCuantiaVolumetrica( float separacion, Diametro diametroestribo);
        public abstract void CalculoSeparacionminima();
        public abstract int Cuantia_Volumetrica(float espesor, float recubrimiento, float separacion, float as_estribo);

    }
}