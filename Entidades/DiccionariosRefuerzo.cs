using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public static class DiccionariosRefuerzo
    {
        private static Dictionary<Diametro, float> AreasRefuerzo { get; set; }
        private static Dictionary<Diametro, float> PesoRefuerzoLong { get; set; }
        private static Dictionary<string, Diametro> NombreRefuerzo { get; set; }
        private static Dictionary<Diametro, float> TraslapoRefuerzo { get; set; }
        private static Dictionary<Diametro, float> LongitudGancho90 { get; set; }

        private static Dictionary<Diametro, float> SetAreasRefuerzo()
        {
            var areasrefuerzo = new Dictionary<Diametro, float>();
            areasrefuerzo.Add(Diametro.Num45mm, 0.16f);
            areasrefuerzo.Add(Diametro.Num2, 0.32f);
            areasrefuerzo.Add(Diametro.Num3, 0.71f);
            areasrefuerzo.Add(Diametro.Num4, 1.29f);
            areasrefuerzo.Add(Diametro.Num5, 1.99f);
            areasrefuerzo.Add(Diametro.Num6, 2.84f);
            areasrefuerzo.Add(Diametro.Num7, 3.87f);
            areasrefuerzo.Add(Diametro.Num8, 5.10f);

            return areasrefuerzo;
        }

        private static Dictionary<Diametro, float> SetPesosRefuerzo()
        {
            var pesosrefuerzo = new Dictionary<Diametro, float>();
            pesosrefuerzo.Add(Diametro.Num45mm, 0.16f);
            pesosrefuerzo.Add(Diametro.Num2, 0.25f);
            pesosrefuerzo.Add(Diametro.Num3, 0.56f);
            pesosrefuerzo.Add(Diametro.Num4, 1.0f);
            pesosrefuerzo.Add(Diametro.Num5, 1.56f);
            pesosrefuerzo.Add(Diametro.Num6, 2.25f);
            pesosrefuerzo.Add(Diametro.Num7, 3.06f);
            pesosrefuerzo.Add(Diametro.Num8, 4f);

            return pesosrefuerzo;
        }

        private static Dictionary<string, Diametro> SetNombreRefuerzo()
        {
            var nombrerefuerzo = new Dictionary<string, Diametro>();
            nombrerefuerzo.Add("4.5mm", Diametro.Num45mm);
            nombrerefuerzo.Add("2", Diametro.Num2);
            nombrerefuerzo.Add("3", Diametro.Num3);
            nombrerefuerzo.Add("4", Diametro.Num4);
            nombrerefuerzo.Add("5", Diametro.Num5);
            nombrerefuerzo.Add("6", Diametro.Num6);
            nombrerefuerzo.Add("7", Diametro.Num7);
            nombrerefuerzo.Add("8", Diametro.Num8);
            return nombrerefuerzo;
        }
        private static Dictionary<Diametro, float> SetTraslapo(float fc)
        {
            var TraslapoRefuerzo = new Dictionary<Diametro, float>();
            switch (fc)
            {
                case 210:
                    TraslapoRefuerzo.Add(Diametro.Num45mm, 0.55f);
                    TraslapoRefuerzo.Add(Diametro.Num2, 0.55f);
                    TraslapoRefuerzo.Add(Diametro.Num3, 0.55f);
                    TraslapoRefuerzo.Add(Diametro.Num4, 0.75f);
                    TraslapoRefuerzo.Add(Diametro.Num5, 0.90f);
                    TraslapoRefuerzo.Add(Diametro.Num6, 1.10f);
                    TraslapoRefuerzo.Add(Diametro.Num7, 1.60f);
                    TraslapoRefuerzo.Add(Diametro.Num8, 1.80f);
                    break;
                case 280:
                    TraslapoRefuerzo.Add(Diametro.Num45mm, 0.50f);
                    TraslapoRefuerzo.Add(Diametro.Num2, 0.50f);
                    TraslapoRefuerzo.Add(Diametro.Num3, 0.50f);
                    TraslapoRefuerzo.Add(Diametro.Num4, 0.65f);
                    TraslapoRefuerzo.Add(Diametro.Num5, 0.80f);
                    TraslapoRefuerzo.Add(Diametro.Num6, 0.95f);
                    TraslapoRefuerzo.Add(Diametro.Num7, 1.40f);
                    TraslapoRefuerzo.Add(Diametro.Num8, 1.60f);
                    break;
                default:
                    TraslapoRefuerzo.Add(Diametro.Num45mm, 0.45f);
                    TraslapoRefuerzo.Add(Diametro.Num2, 0.45f);
                    TraslapoRefuerzo.Add(Diametro.Num3, 0.45f);
                    TraslapoRefuerzo.Add(Diametro.Num4, 0.55f);
                    TraslapoRefuerzo.Add(Diametro.Num5, 0.70f);
                    TraslapoRefuerzo.Add(Diametro.Num6, 0.85f);
                    TraslapoRefuerzo.Add(Diametro.Num7, 1.25f);
                    TraslapoRefuerzo.Add(Diametro.Num8, 1.40f);
                    break;
            }

            return TraslapoRefuerzo;
        }
        private static Dictionary<Diametro, float> SetLongGancho90()
        {
            var LongGancho = new Dictionary<Diametro, float>();
            LongGancho.Add(Diametro.Num45mm, 0.09f);
            LongGancho.Add(Diametro.Num2, 0.09f);
            LongGancho.Add(Diametro.Num3, 0.14f);
            LongGancho.Add(Diametro.Num4, 0.18f);
            LongGancho.Add(Diametro.Num5, 0.23f);
            LongGancho.Add(Diametro.Num6, 0.27f);
            LongGancho.Add(Diametro.Num7, 0.32f);
            LongGancho.Add(Diametro.Num8, 0.36f);
            return LongGancho;
        }

        public static float ReturnAsi(Diametro diametro)
        {
            AreasRefuerzo = SetAreasRefuerzo();
            var Asi = AreasRefuerzo[diametro];
            return Asi;
        }
        public static float ReturnPesoi(Diametro diametro)
        {
            PesoRefuerzoLong = SetPesosRefuerzo();
            var Pesoi = PesoRefuerzoLong[diametro];
            return Pesoi;
        }

        public static Diametro ReturnDiametro(string nombrediametro)
        {
            NombreRefuerzo = SetNombreRefuerzo();
            var diametro = NombreRefuerzo[nombrediametro];
            return diametro;
        }

        public static string ReturnNombreDiametro(Diametro diametro)
        {
            NombreRefuerzo = SetNombreRefuerzo();
            var diametronombre = NombreRefuerzo.FirstOrDefault(x => x.Value == diametro).Key;
            return diametronombre;
        }
        public static float ReturnTraslapo(Diametro diametro,float fc)
        {
            TraslapoRefuerzo = SetTraslapo(fc);
            var Traslapo = TraslapoRefuerzo[diametro];
            return Traslapo;
        }
        public static float ReturnLongGancho90(Diametro diametro)
        {
            LongitudGancho90 = SetLongGancho90();
            var LongGancho = LongitudGancho90[diametro];
            return LongGancho;
        }
    }
}
