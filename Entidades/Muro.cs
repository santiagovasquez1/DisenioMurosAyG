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
        public float Bw { get; set; }
        public float Lw { get; set; }
        public float Hw { get; set; }
        public float RhoH { get; set; }
        public float RhoV { get; set; }
        public float AsH { get; set; }
        public float AsV { get; set; }
        public float AsAdicional { get; set; }
        public int Capas { get; set; }
        public float Fc { get; set; }
        public float Fy { get; set; }
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
        public void CalcRhoH()
        {
            RhoH = (float)(AsH / (Bw * Math.Pow(100, 2)));
        }

        public void CalcRhoL()
        {
            float Long_Izq = 0;
            if (EBE_Izq != null)
                Long_Izq = EBE_Izq.LongEbe;

            float Long_Der = 0;
            if (EBE_Der != null)
                Long_Der = EBE_Der.LongEbe;

            float Numerdador = (AsV * (Lw - Long_Izq - Long_Der)) + AsAdicional;
            RhoV = (float)(Numerdador / (Lw * Bw * Math.Pow(100, 2)));
        }

        public void UploadAsLong()
        {
            float Long_Izq = 0;
            if (EBE_Izq != null)
                Long_Izq = EBE_Izq.LongEbe;

            float Long_Der = 0;
            if (EBE_Der != null)
                Long_Der = EBE_Der.LongEbe;

            var AsTotal = RhoV * Bw * Lw * Math.Pow(100, 2);
            var AsMalla = AsV * (Lw - Long_Izq - Long_Der);
            var asAdicional = AsTotal - AsMalla;
            AsAdicional = (float)asAdicional;
        }


        public override string ToString()
        {
            return $"{ Label}-{Story.StoryName}";
        }
    }
}