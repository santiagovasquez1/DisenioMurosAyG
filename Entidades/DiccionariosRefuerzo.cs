﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public static class DiccionariosRefuerzo
    {
        private static Dictionary<Diametro, float> AreasRefuerzo { get; set; }
        private static Dictionary<Diametro, float> PesoRefuerzoLong { get; set; }
        
        private static Dictionary<Diametro, float> SetAreasRefuerzo()
        {
            var areasrefuerzo= new Dictionary<Diametro, float>();
            areasrefuerzo.Add(Diametro.Num45mm, 0.16f);
            areasrefuerzo.Add(Diametro.Num2, 0.32f);
            areasrefuerzo.Add(Diametro.Num3, 0.71f);
            areasrefuerzo.Add(Diametro.Num4, 1.29f);
            areasrefuerzo.Add(Diametro.Num5, 1.99f);
            areasrefuerzo.Add(Diametro.Num6, 1.99f);
            areasrefuerzo.Add(Diametro.Num7, 1.99f);
            areasrefuerzo.Add(Diametro.Num8, 5.10f);

            return areasrefuerzo;
        }

        private  static  Dictionary<Diametro, float> SetPesosRefuerzo()
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
    }
}