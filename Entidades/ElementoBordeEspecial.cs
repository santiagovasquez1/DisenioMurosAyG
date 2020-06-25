using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class ElementoBordeEspecial : ElementoDeBorde
    {
        public ElementoBordeEspecial(float bw, float lebe, float fc, GradoDisipacionEnergia disipacionEnergia)
        {
            Tw = bw;
            LongEbe = lebe;
            Fc = fc;
            GradoDisipacionEnergia = disipacionEnergia;
        }
        public override void CalculoCuantiaVolumetrica(float bw)
        {
            throw new NotImplementedException();
        }

        public override void CalculoSeparacionminima()
        {

            switch (GradoDisipacionEnergia)
            {
                case GradoDisipacionEnergia.DMI:
                case GradoDisipacionEnergia.DMO:
                    Sepmin = Tw / 2 < 0.075 ? 0.075f : Tw / 2;
                    break;
                case GradoDisipacionEnergia.DES:
                    Sepmin = Tw / 3 < 0.05 ? 0.05f : Tw / 3;
                    break;
                default:
                    Sepmin = 0.075f;
                    break;
            }
        }
    }
}