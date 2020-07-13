using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Factorias
{
    public class RefuerzoLongFactory
    {
        internal enum TipoBarra
        {
            /// <summary>
            /// Barra Darecha
            /// </summary>
            Tipo1,
            /// <summary>
            /// Barra con gancho en el arranque
            /// </summary>
            Tipo2,
            /// <summary>
            /// Barra con gancho al final
            /// </summary>
            Tipo3,
            /// <summary>
            /// Barra con gancho al inicio y al final
            /// </summary>
            Tipo4,
        }
        public Alzado Alzado { get; set; }
        public float ProfRefuerzo { get; set; }
        public List<BarraMuro> BarrasMuros { get; set; }

        public RefuerzoLongFactory(Alzado alzado, float profRefuerzo)
        {
            Alzado = alzado;
            ProfRefuerzo = profRefuerzo;
            Alzado.RefuerzosLongitudinales = new List<Refuerzo>();
        }

        public void SetRefuerzoMuro()
        {
            var NumBarrasMax = (from muro in Alzado.Muros
                                where muro.BarrasMuros != null
                                select muro.BarrasMuros.Count).ToList().Max();

            var Denominaciones = (from muro in Alzado.Muros
                                  where muro.BarrasMuros != null
                                  where muro.BarrasMuros.Count == NumBarrasMax
                                  select muro).FirstOrDefault().BarrasMuros.Select(x => x.BarraDenom).ToList();

            float PosX = 0;

            foreach (var denominacion in Denominaciones)
            {
                float NivelInicial;
                float NivelFinal;
                float deltax = 0;
                float LongTraslapo = 0f;
                float fc = 0;

                TipoBarra tipoBarra = TipoBarra.Tipo1;

                var BarrasDenom = (from muro in Alzado.Muros
                                   where muro.BarrasMuros != null
                                   from barra in muro.BarrasMuros
                                   where barra.BarraDenom == denominacion
                                   select barra).ToList();
                int x = 0;
                for (int i = BarrasDenom.Count - 1; i >= 0; i--)
                {
                    if (i > 0)
                    {
                        fc = (from muro in Alzado.Muros
                              where muro.Story.StoryId == BarrasDenom[i - 1].Muro.Story.StoryId
                              select muro.Fc).FirstOrDefault();
                    }
                    else
                    {
                        var IndiceFc = Alzado.Muros.FindIndex(y => y.Story.StoryId == BarrasDenom[i].Muro.Story.StoryId) - 1;

                        if (IndiceFc < 0) IndiceFc = 0;

                        fc = Alzado.Muros[IndiceFc].Fc;
                    }

                    var Barrai = BarrasDenom[i];

                    LongTraslapo = DiccionariosRefuerzo.ReturnTraslapo(BarrasDenom[i].Diametro, fc);

                    if (x % 2 == 0 && Barrai.Traslapo == Traslapo.Impar)
                    {

                        if (i == BarrasDenom.Count - 1)
                        {
                            NivelInicial = BarrasDenom[i].Muro.Story.StoryElevation - BarrasDenom[i].Muro.Hw;
                            NivelFinal = BarrasDenom[i].Muro.Story.StoryElevation + LongTraslapo;
                            tipoBarra = TipoBarra.Tipo2;
                        }
                        else
                        {

                            NivelInicial = BarrasDenom[i + 1].Muro.Story.StoryElevation - BarrasDenom[i + 1].Muro.Hw;
                            NivelFinal = fc > 0
                                ? BarrasDenom[i].Muro.Story.StoryElevation + LongTraslapo
                                : BarrasDenom[i].Muro.Story.StoryElevation;

                            tipoBarra = fc == 0 ? TipoBarra.Tipo3 : TipoBarra.Tipo1;
                        }

                        deltax = deltax == 0 ? 0.10f : 0f;
                        var Refuerzoi = SetRefuerzo(NivelInicial, NivelFinal, BarrasDenom[i].BarraDenom, BarrasDenom[i].Diametro, BarrasDenom[i].Cantidad, Barrai.Traslapo, PosX + deltax, tipoBarra, LongTraslapo);
                        Alzado.RefuerzosLongitudinales.Add(Refuerzoi);
                    }
                    else if (x % 2 > 0 && Barrai.Traslapo == Traslapo.Par)
                    {
                        NivelInicial = BarrasDenom[i + 1].Muro.Story.StoryElevation - BarrasDenom[i + 1].Muro.Hw;

                        NivelFinal = fc > 0
                            ? BarrasDenom[i].Muro.Story.StoryElevation + LongTraslapo
                            : BarrasDenom[i].Muro.Story.StoryElevation;

                        tipoBarra = fc == 0 ? TipoBarra.Tipo3 : TipoBarra.Tipo1;
                        if (NivelInicial == 0) tipoBarra = TipoBarra.Tipo2;

                        deltax = deltax == 0 ? 0.10f : 0f;
                        var Refuerzoi = SetRefuerzo(NivelInicial, NivelFinal, BarrasDenom[i].BarraDenom, BarrasDenom[i].Diametro, BarrasDenom[i].Cantidad, Barrai.Traslapo, PosX + deltax, tipoBarra, LongTraslapo);
                        Alzado.RefuerzosLongitudinales.Add(Refuerzoi);
                    }
                    else if (x % 2 > 0 && Barrai.Traslapo == Traslapo.Impar && i == 0 || x % 2 == 0 && Barrai.Traslapo == Traslapo.Par && i == 0)
                    {
                        NivelInicial = BarrasDenom[i].Muro.Story.StoryElevation - BarrasDenom[i].Muro.Hw;
                        NivelFinal = fc > 0
                            ? BarrasDenom[i].Muro.Story.StoryElevation + LongTraslapo
                            : BarrasDenom[i].Muro.Story.StoryElevation;

                        tipoBarra = fc == 0 ? TipoBarra.Tipo3 : TipoBarra.Tipo1;
                        deltax = deltax == 0 ? 0.10f : 0f;
                        var Refuerzoi = SetRefuerzo(NivelInicial, NivelFinal, BarrasDenom[i].BarraDenom, BarrasDenom[i].Diametro, BarrasDenom[i].Cantidad, Barrai.Traslapo, PosX + deltax, tipoBarra,LongTraslapo);
                        Alzado.RefuerzosLongitudinales.Add(Refuerzoi);
                    }
                    x++;
                }
                PosX += 1.45f;
            }
        }

        private RefuerzoLong SetRefuerzo(float NivelInicial, float NivelFinal, string denom, Diametro diametro, int cantidad, Traslapo traslapo, float posx, TipoBarra tipoBarra,float longTraslapo)
        {
            float[] Coord = new float[] { };
            var refuerzotemp = new RefuerzoLong(diametro,denom, cantidad, 0f, TipoRefuerzo.Longitudinal, traslapo);
            refuerzotemp.LongTraslapo = longTraslapo;

            switch (tipoBarra)
            {
                default:
                    Coord = new float[] { posx, NivelInicial, posx, NivelFinal };
                    refuerzotemp.Coordenadas = Coord;
                    break;
                case TipoBarra.Tipo2:
                    Coord = new float[] {posx-DiccionariosRefuerzo.ReturnLongGancho90(diametro),NivelInicial-ProfRefuerzo,
                    posx,NivelInicial-ProfRefuerzo,
                    posx,NivelFinal};
                    refuerzotemp.Coordenadas = Coord;
                    break;
                case TipoBarra.Tipo3:
                    Coord = new float[] {posx,NivelInicial,
                    posx,NivelFinal-0.05f,
                    posx+DiccionariosRefuerzo.ReturnLongGancho90(diametro),NivelFinal-0.05f};
                    refuerzotemp.Coordenadas = Coord;
                    break;
            }

            refuerzotemp.Coordenadas = Coord;
            refuerzotemp.Longitud = refuerzotemp.GetLong(Coord);
            return refuerzotemp;
        }
    }
}
