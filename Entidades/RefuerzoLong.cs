using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class RefuerzoLong:Refuerzo
    {
        public override DiccionariosRefuerzo DiccionarioRefuerzo { get => base.DiccionarioRefuerzo; set => base.DiccionarioRefuerzo = value; }
        public RefuerzoLong(Diametro diametro, int cantidad, float separacion, TipoRefuerzo tipo, Traslapo traslapo, DiccionariosRefuerzo diccionarioRefuerzo)
        {
            RefuerzoId = Guid.NewGuid().ToString();
            Diametro = diametro;
            TipoRefuerzo = tipo;
            TipoTraslapo = traslapo;
            Cantidad = cantidad;
            Separacion = separacion;
            DiccionarioRefuerzo = diccionarioRefuerzo;
            Asi = GetAsi(diametro, cantidad);
        }
        public override float GetPeso(Diametro diametro,float longitud,int cantidad)
        {
            var Pesoi = cantidad * longitud * DiccionarioRefuerzo.ReturnPesoi(diametro);
            return Pesoi;
        }

        public override float GetAsi(Diametro diametro, int cantidad)
        {
            var Asi = cantidad * DiccionarioRefuerzo.ReturnAsi(diametro);
            return Asi;
        }
        public override float GetLong(float[] Coordenadas)
        {
            throw new NotImplementedException();
        }
    }
}