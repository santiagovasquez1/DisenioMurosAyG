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

        private static Dictionary<string, Diametro> SetNombreRefuerzo()
        {
            var nombrerefuerzo=new Dictionary<string,Diametro>();
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
    }
}
