using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DibujoAutomatico
{
    public class DibujoAlzado : IDibujoElemento
    {
        public Alzado Alzado { get; set; }
        public double[] InsertionPoint { get; set; }
        public double[] InsertionPointNombreMuro { get; set; }
        public string Subrayado1 { get; set; }
        public string Subrayado2 { get; set; }
        public DibujoAlzado(Alzado alzado, double[] insertionpoint, string subrayado1, string subrayado2)
        {
            Alzado = alzado;
            InsertionPoint = insertionpoint;
            Subrayado1 = subrayado1;
            Subrayado2 = subrayado2;
            InsertionPointNombreMuro = new double[] { InsertionPoint[0], InsertionPoint[1] - 1.90f, 0 };
        }
        public double[] SetCoorPoligono(float DeltaX, float longitud, float altitud, float nivel)
        {
            var niveltemp = nivel - altitud;
            double[] tempCoor = {
                InsertionPoint[0]+DeltaX,InsertionPoint[1]+niveltemp,
                InsertionPoint[0]+DeltaX+longitud,InsertionPoint[1]+niveltemp,
                InsertionPoint[0]+DeltaX+longitud,InsertionPoint[1]+altitud+niveltemp,
                InsertionPoint[0]+DeltaX,InsertionPoint[1]+altitud+niveltemp
            };
            return tempCoor;
        }

        public void DibujarMuros()
        {
            for (int i = Alzado.Muros.Count - 1; i >= 0; i--)
            {
                var muro = Alzado.Muros[i];
                var dibujomuroi = new DibujoMuro(muro, InsertionPoint, 0.1f, "MUROS-ELEV", "SOLIDO-ZCON", "R80");
                dibujomuroi.DibujarCoco();
                dibujomuroi.DibujarCotasMuro(muro.Hw, muro.Story.StoryElevation);
                dibujomuroi.DibujarCotasViga(0.1f, muro.Story.StoryElevation);

                if (muro.EBE_Izq != null)
                {
                    dibujomuroi.CoordEBE = dibujomuroi.SetCoorPoligono(0f, muro.EBE_Izq.LongEbe, muro.Hw, muro.Story.StoryElevation);
                    dibujomuroi.DibujarEBE();
                }

                if (muro.EBE_Der != null)
                {
                    var deltax = muro.Lw - muro.EBE_Der.LongEbe;
                    dibujomuroi.CoordEBE = dibujomuroi.SetCoorPoligono(deltax, muro.EBE_Der.LongEbe, muro.Hw, muro.Story.StoryElevation);
                    dibujomuroi.DibujarEBE();
                }
            }
        }

        public void DibujarNombreMuro()
        {
            var Coord1 = SetCoorPoligono(0, 2.60f, 0f, -2.40f);
            var Coord2 = SetCoorPoligono(0, 2.60f, 0f, -2.52f);
            FunctionsAutoCAD.FunctionsAutoCAD.AddText($"Muro {Alzado.NombreDef}", InsertionPointNombreMuro, 0.46f, 0.46f, "R180", "ROMANS", 0, Width2: 2.60f);
            FunctionsAutoCAD.FunctionsAutoCAD.AddPolyline2D(Coord1, Subrayado1);
            FunctionsAutoCAD.FunctionsAutoCAD.AddPolyline2D(Coord2, Subrayado2);
        }

        public void DibujoCambioEspesor()
        {
            var espesores = (from muro in Alzado.Muros
                             select muro.Bw).Distinct().ToList();

            foreach (var espesor in espesores)
            {
                var NivelIni = Alzado.Muros.LastOrDefault(x => x.Bw == espesor).Story.StoryElevation - Alzado.Muros.LastOrDefault(x => x.Bw == espesor).Hw;
                var NivelFin = Alzado.Muros.FirstOrDefault(x => x.Bw == espesor).Story.StoryElevation;

                var Coord = SetCoorPoligono(Alzado.Muros.FirstOrDefault().Lw + 1.65f, 0, NivelFin - NivelIni, NivelFin);
                var Coord2 = SetCoorPoligono(Alzado.Muros.FirstOrDefault().Lw + 1.425f, 0.45f, 0, NivelFin);
                var InsertionPointText = new double[] { Coord[0] - 0.25f, NivelIni + (NivelFin - NivelIni) / 2, 0 };

                FunctionsAutoCAD.FunctionsAutoCAD.AddPolyline2D(Coord, "LINEA-CORTE");
                FunctionsAutoCAD.FunctionsAutoCAD.AddPolyline2D(Coord2, "LINEA-CORTE");
                FunctionsAutoCAD.FunctionsAutoCAD.AddText($"\\pxcqc;e={espesor}", InsertionPointText, 0.19f, 0.19f, "R80", "ROMANS", 90f);
            }
        }

        public void DibujoCambioResistencia()
        {
            var Resistencias = (from muro in Alzado.Muros
                                select muro.Fc).Distinct().ToList();

            foreach (var resistencia in Resistencias)
            {
                var NivelIni = Alzado.Muros.LastOrDefault(x => x.Fc == resistencia).Story.StoryElevation - Alzado.Muros.LastOrDefault(x => x.Fc == resistencia).Hw;
                var NivelFin = Alzado.Muros.FirstOrDefault(x => x.Fc == resistencia).Story.StoryElevation;

                var Coord = SetCoorPoligono(Alzado.Muros.FirstOrDefault().Lw + 2.10f, 0, NivelFin - NivelIni, NivelFin);
                var Coord2 = SetCoorPoligono(Alzado.Muros.FirstOrDefault().Lw + 1.875f, 0.45f, 0, NivelFin);
                var InsertionPointText = new double[] { Coord[0] - 0.25f, NivelIni + (NivelFin - NivelIni) / 2, 0 };

                FunctionsAutoCAD.FunctionsAutoCAD.AddPolyline2D(Coord, "LINEA-CORTE");
                FunctionsAutoCAD.FunctionsAutoCAD.AddPolyline2D(Coord2, "LINEA-CORTE");
                FunctionsAutoCAD.FunctionsAutoCAD.AddText($"f'c={resistencia} MPa", InsertionPointText, 0.19f, 0.19f, "R80", "ROMANS", 90f, Width2: 2.0f);
            }

        }

    }
}
