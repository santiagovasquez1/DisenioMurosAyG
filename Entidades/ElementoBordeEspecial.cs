using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    [Serializable]
    public class ElementoBordeEspecial : ElementoDeBorde
    {
        public ElementoBordeEspecial(float bw, float lebe, float fc, float fy, GradoDisipacionEnergia disipacionEnergia)
        {
            Tw = bw;
            LongEbe = lebe;
            Fc = fc;
            Fy = fy;
            GradoDisipacionEnergia = disipacionEnergia;
        }
        public override void CalculoCuantiaVolumetrica(float separacion, Diametro diametroestribo)
        {
            if (separacion != 0)
            {
                var as_estribo = DiccionariosRefuerzo.ReturnAsi(diametroestribo);
                RamasX = Cuantia_Volumetrica(LongEbe, recubrimiento: 0f, separacion, as_estribo);
                RamasY = Cuantia_Volumetrica(Tw, recubrimiento: 0f, separacion, as_estribo);
            }
        }

        public override int Cuantia_Volumetrica(float espesor, float recubrimiento, float separacion, float as_estribo)
        {
            float ash = 0;

            if (GradoDisipacionEnergia == GradoDisipacionEnergia.DMO | GradoDisipacionEnergia == GradoDisipacionEnergia.DMI)
            {
                ash = 0.06f * SepEstribo * (espesor - 2 * recubrimiento) * Fc / Fy;
            }
            else
            {
                ash = 0.09f * SepEstribo * (espesor - 2 * recubrimiento) * Fc / Fy;
            }

            var Cant = Math.Ceiling(ash * Math.Pow(100, 2) / as_estribo);
            return (int)Cant;
        }

        public override void CalculoSeparacionminima()
        {

            switch (GradoDisipacionEnergia)
            {
                case GradoDisipacionEnergia.DMI:
                case GradoDisipacionEnergia.DMO:
                    SepEstribo = Tw / 2 < 0.075 ? 0.075f : Tw / 2;
                    break;
                case GradoDisipacionEnergia.DES:
                    SepEstribo = Tw / 3 < 0.05 ? 0.05f : Tw / 3;
                    break;
                default:
                    SepEstribo = 0.075f;
                    break;
            }
        }

    }
}