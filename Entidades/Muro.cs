﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    [Serializable]
    public class Muro
    {
        private Malla malla;

        public string MuroId { get; set; }
        public string Label { get; set; }
        public string LabelDef { get; set; }
        public GradoDisipacionEnergia GradoDisipacionEnergia { get; set; }
        public float Bw { get; set; }
        public float Lw { get; set; }
        public float Hw { get; set; }
        public float RhoH { get; set; }
        public float RhoV { get; set; }
        public float AsH { get; set; }
        public float AsV { get; set; }
        public float AsAdicional { get; set; }
        public float AsTotalAdicional { get; set; }
        public int Capas { get; set; }
        public float Fc { get; set; }
        public float Fy { get; set; }
        public Story Story { get; set; }
        public Malla Malla
        {
            get => malla;
            set
            {
                malla = value;
                UploadAsLong();
            }
        }
        public List<BarraMuro> BarrasMuros { get; set; }
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

            if (Lw > 4.00f && RhoH < 0.002f)
                RhoH = 0.0020f;
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

            float AsTotal = RhoV * Bw * Lw * (float)Math.Pow(100, 2);

            float AsMalla;
            if (Malla != null)
                AsMalla = Malla.AsVertical * (Lw - Long_Izq - Long_Der);
            else
                AsMalla = 0;

                float asAdicional;
            if (AsTotal - AsMalla < 0)
                asAdicional = 0;
            else
                asAdicional = AsTotal - AsMalla;

            AsAdicional = (float)asAdicional;
        }

        public void CalcAsTotal()
        {
            var astotal = 0f;

            if (BarrasMuros != null)
            {
                foreach (var barra in BarrasMuros)
                {
                    var asi = barra.Cantidad * DiccionariosRefuerzo.ReturnAsi(barra.Diametro);
                    astotal += asi;
                }
            }
            AsTotalAdicional = astotal;
        }
        public override string ToString()
        {
            return $"{ Label}-{Story.StoryName}";
        }
    }
}