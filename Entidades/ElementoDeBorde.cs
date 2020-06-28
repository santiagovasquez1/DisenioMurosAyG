using System.Collections.Generic;

namespace Entidades
{
    public delegate void Notify();
    public abstract class ElementoDeBorde
    {
        private float longEbe;
        private float tw;
        private float sepEstribo;
        private Diametro diametroEstribo;

        public float LongEbe
        {
            get => longEbe;
            set
            {
                longEbe = value;
                CalculoCuantiaVolumetrica(SepEstribo, DiametroEstribo);
            }
        }
        public float Tw { get => tw; set { tw = value; CalculoCuantiaVolumetrica(SepEstribo, DiametroEstribo); } }
        public float Fc { get; set; }
        public float Fy { get; set; }
        public GradoDisipacionEnergia GradoDisipacionEnergia { get; set; }
        public float SepEstribo
        {
            get => sepEstribo; set
            {
                sepEstribo = value;
                CalculoCuantiaVolumetrica(SepEstribo, DiametroEstribo);
            }
        }
        public Diametro DiametroEstribo
        {
            get => diametroEstribo; set
            {
                diametroEstribo = value;
                CalculoCuantiaVolumetrica(SepEstribo, DiametroEstribo);
            }
        }
        /// <summary>
        /// /Ramas a los largo de la longitud del elemento de borde especial
        /// </summary>
        public int RamasX { get; set; }
        /// <summary>
        /// Ramas a los largo del espesor del elemento de borde especial
        /// </summary>
        public int RamasY { get; set; }
        public List<Refuerzo> Estribos { get; set; }
        public event Notify ChangeEbe;
        public abstract void CalculoCuantiaVolumetrica(float separacion, Diametro diametroestribo);
        public abstract void CalculoSeparacionminima();
        public abstract int Cuantia_Volumetrica(float espesor, float recubrimiento, float separacion, float as_estribo);

        protected virtual void OnChangeEbe()
        {
            ChangeEbe?.Invoke();
        }
    }
}