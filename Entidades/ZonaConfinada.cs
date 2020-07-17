using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    [Serializable]
    public class ZonaConfinada : ElementoDeBorde
    {
        public override void CalculoCuantiaVolumetrica(float separacion, Diametro diametroestribo)
        {
            throw new NotImplementedException();
        }

        public override void CalculoSeparacionminima()
        {
            throw new NotImplementedException();
        }

        public override int Cuantia_Volumetrica(float espesor, float recubrimiento, float separacion, float as_estribo)
        {
            throw new NotImplementedException();
        }
    }
}