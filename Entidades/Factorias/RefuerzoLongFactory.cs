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
                    var Barrai = BarrasDenom[i];

                    fc = FindFc(BarrasDenom, i);

                    LongTraslapo = DiccionariosRefuerzo.ReturnTraslapo(BarrasDenom[i].Diametro, fc);
                    if (Barrai.Diametro != Diametro.Num3)
                    {
                        if (x % 2 == 0 && Barrai.Traslapo == Traslapo.Impar)
                        {
                            VariablesImpar(out NivelInicial, out NivelFinal, LongTraslapo, fc, out tipoBarra, BarrasDenom, i);
                            deltax = deltax == 0 ? 0.10f : 0f;

                            var Refuerzoi = SetRefuerzo(NivelInicial, NivelFinal, BarrasDenom[i].CapaRefuerzo, BarrasDenom[i].Diametro, BarrasDenom[i].Cantidad, Barrai.Traslapo, PosX + deltax, tipoBarra, LongTraslapo);
                            Alzado.RefuerzosLongitudinales.Add(Refuerzoi);
                        }
                        else if (x % 2 > 0 && Barrai.Traslapo == Traslapo.Par)
                        {
                            //if (BarrasDenom[i + 1].Diametro == BarrasDenom[i].Diametro)
                            //{
                            VariablesPar(out NivelInicial, out NivelFinal, LongTraslapo, fc, out tipoBarra, BarrasDenom, i);
                            deltax = deltax == 0 ? 0.10f : 0f;

                            var Refuerzoi = SetRefuerzo(NivelInicial, NivelFinal, BarrasDenom[i].CapaRefuerzo, BarrasDenom[i].Diametro, BarrasDenom[i].Cantidad, Barrai.Traslapo, PosX + deltax, tipoBarra, LongTraslapo);
                            Alzado.RefuerzosLongitudinales.Add(Refuerzoi);
                            //}
                            //else
                            //{
                            //    VariableRefuerzoUnPiso(out NivelInicial, out NivelFinal, LongTraslapo, fc, out tipoBarra, BarrasDenom, i);
                            //    //deltax = deltax == 0 ? 0.10f : 0f;

                            //    var Refuerzoi = SetRefuerzo(NivelInicial, NivelFinal, BarrasDenom[i].BarraDenom, BarrasDenom[i].Diametro, BarrasDenom[i].Cantidad, Barrai.Traslapo, PosX + deltax, tipoBarra, LongTraslapo);
                            //    Alzado.RefuerzosLongitudinales.Add(Refuerzoi);

                            //    VariableRefuerzoUnPiso(out NivelInicial, out NivelFinal, LongTraslapo, fc, out tipoBarra, BarrasDenom, i+1);
                            //    deltax = deltax == 0 ? 0.10f : 0f;

                            //    var Refuerzoi2 = SetRefuerzo(NivelInicial, NivelFinal, BarrasDenom[i+1].BarraDenom, BarrasDenom[i+1].Diametro, BarrasDenom[i+1].Cantidad, Barrai.Traslapo, PosX + deltax, tipoBarra, LongTraslapo);
                            //    Alzado.RefuerzosLongitudinales.Add(Refuerzoi2);
                            //}
                        }
                        else if (x % 2 > 0 && Barrai.Traslapo == Traslapo.Impar && i == 0 || x % 2 == 0 && Barrai.Traslapo == Traslapo.Par && i == 0)
                        {
                            NivelInicial = BarrasDenom[i].Muro.Story.StoryElevation - BarrasDenom[i].Muro.Hw;
                            NivelFinal = fc > 0
                                ? BarrasDenom[i].Muro.Story.StoryElevation + LongTraslapo
                                : BarrasDenom[i].Muro.Story.StoryElevation;

                            tipoBarra = fc == 0 ? TipoBarra.Tipo3 : TipoBarra.Tipo1;
                            deltax = deltax == 0 ? 0.10f : 0f;
                            var Refuerzoi = SetRefuerzo(NivelInicial, NivelFinal, BarrasDenom[i].CapaRefuerzo, BarrasDenom[i].Diametro, BarrasDenom[i].Cantidad, Barrai.Traslapo, PosX + deltax, tipoBarra, LongTraslapo);
                            Alzado.RefuerzosLongitudinales.Add(Refuerzoi);
                        }
                    }
                    else if (Barrai.Diametro == Diametro.Num3)
                    {
                        if (Barrai.Traslapo == Traslapo.Impar)
                        {
                            VariableRefuerzoUnPisoImpar(out NivelInicial, out NivelFinal, LongTraslapo, fc, out tipoBarra, BarrasDenom, i);

                            deltax = deltax == 0 ? 0.10f : 0f;
                            var Refuerzoi = SetRefuerzo(NivelInicial, NivelFinal, BarrasDenom[i].CapaRefuerzo, BarrasDenom[i].Diametro, BarrasDenom[i].Cantidad, Barrai.Traslapo, PosX + deltax, tipoBarra, LongTraslapo);
                            Alzado.RefuerzosLongitudinales.Add(Refuerzoi);

                        }
                        else if (Barrai.Traslapo == Traslapo.Par)
                        {
                            VariableRefuerzoUnPisoPar(out NivelInicial, out NivelFinal, LongTraslapo, fc, out tipoBarra, BarrasDenom, i);

                            deltax = deltax == 0 ? 0.10f : 0f;
                            var Refuerzoi = SetRefuerzo(NivelInicial, NivelFinal, BarrasDenom[i].CapaRefuerzo, BarrasDenom[i].Diametro, BarrasDenom[i].Cantidad, Barrai.Traslapo, PosX + deltax, tipoBarra, LongTraslapo);
                            Alzado.RefuerzosLongitudinales.Add(Refuerzoi);
                        }
                    }
                    x++;
                }
                PosX += 1.45f;
            }
        }

        private static void VariableRefuerzoUnPisoPar(out float NivelInicial, out float NivelFinal, float LongTraslapo, float fc, out TipoBarra tipoBarra, List<BarraMuro> BarrasDenom, int i)
        {
            NivelInicial = BarrasDenom[i].Muro.Story.StoryElevation - BarrasDenom[i].Muro.Hw;

            NivelFinal = fc > 0
                ? BarrasDenom[i].Muro.Story.StoryElevation + LongTraslapo
                : BarrasDenom[i].Muro.Story.StoryElevation;

            tipoBarra = fc == 0 ? TipoBarra.Tipo3 : TipoBarra.Tipo1;
            if (NivelInicial == 0) tipoBarra = TipoBarra.Tipo2;
        }

        private static void VariableRefuerzoUnPisoImpar(out float NivelInicial, out float NivelFinal, float LongTraslapo, float fc, out TipoBarra tipoBarra, List<BarraMuro> BarrasDenom, int i)
        {
            NivelInicial = BarrasDenom[i].Muro.Story.StoryElevation - BarrasDenom[i].Muro.Hw - LongTraslapo;

            NivelFinal = fc > 0
                ? BarrasDenom[i].Muro.Story.StoryElevation
                : BarrasDenom[i].Muro.Story.StoryElevation;

            tipoBarra = fc == 0 ? TipoBarra.Tipo3 : TipoBarra.Tipo1;
            if (NivelInicial == 0) tipoBarra = TipoBarra.Tipo2;
        }

        private static void VariablesPar(out float NivelInicial, out float NivelFinal, float LongTraslapo, float fc, out TipoBarra tipoBarra, List<BarraMuro> BarrasDenom, int i)
        {

            NivelInicial = BarrasDenom[i + 1].Muro.Story.StoryElevation - BarrasDenom[i + 1].Muro.Hw;

            NivelFinal = fc > 0
                ? BarrasDenom[i].Muro.Story.StoryElevation + LongTraslapo
                : BarrasDenom[i].Muro.Story.StoryElevation;


            tipoBarra = fc == 0 ? TipoBarra.Tipo3 : TipoBarra.Tipo1;
            if (NivelInicial == 0) tipoBarra = TipoBarra.Tipo2;
        }

        private static void VariablesImpar(out float NivelInicial, out float NivelFinal, float LongTraslapo, float fc, out TipoBarra tipoBarra, List<BarraMuro> BarrasDenom, int i)
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
        }

        private float FindFc(List<BarraMuro> BarrasDenom, int i)
        {
            float fc;
            if (i > 0)
            {
                fc = (from muro in Alzado.Muros
                      where muro.Story.StoryId == BarrasDenom[i - 1].Muro.Story.StoryId
                      select muro.Fc).FirstOrDefault();
            }
            else
            {
                var IndiceFc = Alzado.Muros.FindIndex(y => y.Story.StoryId == BarrasDenom[i].Muro.Story.StoryId) - 1;

                if (IndiceFc > 0)
                {
                    fc = Alzado.Muros[IndiceFc].Fc;
                }
                else
                {
                    fc = 0;
                }

            }

            return fc;
        }

        private RefuerzoLong SetRefuerzo(float NivelInicial, float NivelFinal, CapaRefuerzo capa, Diametro diametro, int cantidad, Traslapo traslapo, float posx, TipoBarra tipoBarra, float longTraslapo)
        {
            float[] Coord = new float[] { };
            var refuerzotemp = new RefuerzoLong(diametro, capa, 0f, TipoRefuerzo.Longitudinal);
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
