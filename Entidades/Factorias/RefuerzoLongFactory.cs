using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Factorias
{
    public class RefuerzoLongFactory
    {
        public Alzado Alzado { get; set; }
        public List<BarraMuro> BarrasMuros { get; set; }

        public RefuerzoLongFactory(Alzado alzado)
        {
            Alzado = alzado;
        }

        public void SetRefuerzo()
        {
            var NumBarrasMax = (from muro in Alzado.Muros
                                where muro.BarrasMuros != null
                                select muro.BarrasMuros.Count).ToList().Max();

            var Denominaciones = (from muro in Alzado.Muros
                                  where muro.BarrasMuros != null
                                  where muro.BarrasMuros.Count == NumBarrasMax
                                  select muro).FirstOrDefault().BarrasMuros.Select(x => x.BarraDenom).ToList();

            foreach (var denominacion in Denominaciones)
            {
                var BarrasDenom = (from muro in Alzado.Muros
                                   where muro.BarrasMuros != null
                                   from barra in muro.BarrasMuros
                                   where barra.BarraDenom == denominacion
                                   select barra).ToList();

                for (int i = BarrasDenom.Count - 1; i >= 0; i--)
                {
                    var Barrai = BarrasDenom[i];
                    //var BarraFin = BarrasDenom[i - 1];
                    switch (Barrai.Traslapo)
                    {
                        case Traslapo.T1:
                               
                            break;
                        case Traslapo.T2:
                            break;
                        case Traslapo.T3:
                            break;
                        default:
                            break;
                    }

                }

            }
        }


        private RefuerzoLong SetT1(float NivelInicial,float NivelFinal,float fc,Diametro diametro,int cantidad,Traslapo traslapo)
        {
            var refuerzotemp = new RefuerzoLong(diametro, cantidad, 0f, TipoRefuerzo.Longitudinal, traslapo);



            return null;
        }
    }
}
