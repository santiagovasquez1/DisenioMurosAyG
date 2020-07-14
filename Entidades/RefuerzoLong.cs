using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class RefuerzoLong : Refuerzo
    {
        public RefuerzoLong(Diametro diametro,CapaRefuerzo capa, float separacion, TipoRefuerzo tipo)
        {
            RefuerzoId = Guid.NewGuid().ToString();
            CapaRefuerzo = capa;
            Diametro = diametro;
            TipoRefuerzo = tipo;
            TipoTraslapo = capa.Traslapo;
            Cantidad = capa.Cantidad;
            Separacion = separacion;
            Asi = GetAsi(diametro, Cantidad);
        }
        public override float GetPeso(Diametro diametro, float longitud, int cantidad)
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
            double dist;
            double longitud = 0;

            for (int i = 0; i < Coordenadas.Count()-2; i += 2)
            {
                float x1 = Coordenadas[i];
                float y1 = Coordenadas[i + 1];
                float x2 = Coordenadas[i + 2];
                float y2 = Coordenadas[i + 3];

                dist = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
                longitud += dist;
            }

            return (float)longitud;
        }

        public override string ToString()
        {
            return $"{Cantidad}#{DiccionariosRefuerzo.ReturnNombreDiametro(Diametro,1)}L={Longitud}";
        }
    }
}