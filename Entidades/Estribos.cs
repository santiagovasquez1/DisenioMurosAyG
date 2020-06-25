using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Estribos : Refuerzo
    {
        public Estribos(Diametro diametro, int cantidad, float separacion, TipoRefuerzo tipo, Traslapo traslapo)
        {
            RefuerzoId = Guid.NewGuid().ToString();
            Diametro = diametro;
            TipoRefuerzo = tipo;
            TipoTraslapo = traslapo;
            Cantidad = cantidad;
            Separacion = separacion;
            Asi = GetAsi(diametro, cantidad);
        }
        public override float GetAsi(Diametro diametro, int cantidad)
        {
            throw new NotImplementedException();
        }

        public override float GetLong(float[] Coordenadas)
        {
            throw new NotImplementedException();
        }

        public override float GetPeso(Diametro diametro, float longitud, int cantidad)
        {
            throw new NotImplementedException();
        }
    }
}
