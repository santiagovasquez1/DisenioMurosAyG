using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class RefuerzoLong:Refuerzo
    {
        public RefuerzoLong(Diametro diametro, int cantidad, float separacion, TipoRefuerzo tipo, Traslapo traslapo)
        {
            RefuerzoId = Guid.NewGuid().ToString();
            Diametro = diametro;
            TipoRefuerzo = tipo;
            TipoTraslapo = traslapo;
            Cantidad = cantidad;
            Separacion = separacion;
            Asi = GetAsi(diametro, cantidad);
        }
        public override float GetPeso(Diametro diametro,float longitud,int cantidad)
        {
            var Pesoi = cantidad * longitud * DiccionariosRefuerzo.ReturnPesoi(diametro);
            return Pesoi;
        }

        public override float GetAsi(Diametro diametro, int cantidad)
        {
            var Asi = cantidad * DiccionariosRefuerzo.ReturnAsi(diametro);
            return Asi;
        }
        public override float GetLong(float[] Coordenadas)
        {
            throw new NotImplementedException();
        }
    }
}