using Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FunctionsAutoCAD;
using B_Operaciones_Matricialesl;

namespace DibujoAutomaticoAlzados
{
    public class DibujoRefuerzo : IDibujoElemento
    {
        public double[] InsertionPoint { get; set; }
        public Alzado Alzado { get; set; }
        public string LayerRefuerzo { get; set; }
        public string LayerCota { get; set; }
        public string LayerTexto { get; set; }
        public float HLosa { get; set; }
        public float HViga { get; set; }
        public float ProfRefuerzo { get; set; }
        public string LayerCoco { get; set; }
        public float LongitudCoco { get; set; }
        public DibujoRefuerzo(Alzado alzado, double[] insertionpoint, float hlosa, float hViga, float profRefuerzo, string layercoco, string leyerrefuerzo, string layertexto, string layerCota)
        {
            Alzado = alzado;
            InsertionPoint = insertionpoint;
            HLosa = hlosa;
            HViga = hViga;
            ProfRefuerzo = profRefuerzo;
            LayerCoco = layercoco;
            LayerTexto = layertexto;
            LayerRefuerzo = leyerrefuerzo;
            LayerCota = layerCota;
        }

        public void DibujarRefuerzoLongitudinal()
        {
            var InsertionPointText = new double[] { };

            var TempInsertion = new float[] { (float)InsertionPoint[0] + 0.50f, (float)InsertionPoint[1], (float)InsertionPoint[2] };
            var P1Cota = new double[] { };
            var P2Cota = new double[] { };

            var NivelMin = (from refuerzolong in Alzado.RefuerzosLongitudinales
                            select refuerzolong.Coordenadas[1]).Min();

            foreach (var refuerzo in Alzado.RefuerzosLongitudinales)
            {
                var Coord = Operaciones.TraslacionPoligono(TempInsertion, refuerzo.Coordenadas);
                var TextString = $"{refuerzo.Cantidad}ø{DiccionariosRefuerzo.ReturnNombreDiametro(refuerzo.Diametro, 2)}{(char)34} L=";

                InsertionPointText = Coord.Count() == 4
                    ? (new double[] { Coord[0] + 0.22, Coord[1] + 0.50, 0 })
                    : (new double[] { Coord[2] + 0.22, Coord[1] + ProfRefuerzo + 0.35, 0 });

                if (Coord.Count() == 4)
                {
                    P1Cota = new double[] { Coord[0], Coord.LastOrDefault() - refuerzo.LongTraslapo, 0 };
                    P2Cota = new double[] { Coord[0], Coord.LastOrDefault(), 0 };
                }
                else
                {
                    var indice = Coord.ToList().LastIndexOf(Coord.LastOrDefault()) - 1;
                    P1Cota = new double[] { Coord[indice], Coord.LastOrDefault() - refuerzo.LongTraslapo, 0 };
                    P2Cota = new double[] { Coord[indice], Coord.LastOrDefault(), 0 };
                }

                FunctionsAutoCAD.FunctionsAutoCAD.AddPolyline2DWithLengthText(Coord, LayerRefuerzo, TextString, InsertionPointText, 0.15, 0.15, LayerTexto, "ROMANS", 90, 2.50);
                FunctionsAutoCAD.FunctionsAutoCAD.AddCota(P1Cota, P2Cota, LayerCota, "ROMANS",
                    TextHeight: 1.50, ArrowheadSize: 0.85f, DesplazCota: -0.35f);

                if (refuerzo.Coordenadas[1] == NivelMin)
                {
                    var InsertionCircle = new double[] { Coord[2], InsertionPoint[1] - HViga - 0.30, 0 };
                    var InsertionText = new double[] { InsertionCircle[0] - 0.25, InsertionCircle[1] + 0.08, 0 };
                    FunctionsAutoCAD.FunctionsAutoCAD.AddCircle(InsertionCircle, 0.36f, "R60");
                    FunctionsAutoCAD.FunctionsAutoCAD.AddText(refuerzo.CapaRefuerzo.CapaNombre, InsertionText, 0.15f, 0.15f, "R60", "ROMANS", 0f, Width2: 0.50, justifyText: JustifyText.Center);
                }

            }
        }

        public void DibujarMuros()
        {
            LongitudCoco = Alzado.RefuerzosLongitudinales.LastOrDefault().Coordenadas[0] + 1.25f;

            var NivelMax = (from refuerzolong in Alzado.RefuerzosLongitudinales
                            select refuerzolong.Coordenadas.LastOrDefault()).Max();

            var TempInsertionPoint = SetCoorPoligono(0, LongitudCoco, HViga, 0);
            FunctionsAutoCAD.FunctionsAutoCAD.AddPolyline2D(TempInsertionPoint, LayerCoco, true);


            for (int i = Alzado.Muros.Count - 1; i >= 0; i--)
            {
                var muro = Alzado.Muros[i];

                if (muro.Story.StoryElevation <= NivelMax)
                {
                    var dibujomuroi = new DibujoMuro(muro, InsertionPoint, 0.10f, LongitudCoco, LayerCoco, "R80", LayerCota);
                    dibujomuroi.DibujarCoco();
                }
                else
                {
                    break;
                }
            }
        }

        public void DibujoCambioResistencia()
        {
            var NivelMax = (from refuerzolong in Alzado.RefuerzosLongitudinales
                            select refuerzolong.Coordenadas.LastOrDefault()).Max();

            var Resistencias = (from muro in Alzado.Muros
                                where muro.Story.StoryElevation <= NivelMax
                                select muro.Fc).Distinct().ToList();

            var LongitudCoco = Alzado.RefuerzosLongitudinales.LastOrDefault().Coordenadas[0] + 1.25f;

            foreach (var resistencia in Resistencias)
            {
                var NivelIni = Alzado.Muros.LastOrDefault(x => x.Fc == resistencia && x.Story.StoryElevation <= NivelMax).Story.StoryElevation - Alzado.Muros.LastOrDefault(x => x.Fc == resistencia && x.Story.StoryElevation <= NivelMax).Hw;
                var NivelFin = Alzado.Muros.FirstOrDefault(x => x.Fc == resistencia && x.Story.StoryElevation <= NivelMax).Story.StoryElevation;

                var Coord = SetCoorPoligono(LongitudCoco + 2.10f, 0, NivelFin - NivelIni, NivelFin);
                var Coord2 = SetCoorPoligono(LongitudCoco + 1.875f, 0.45f, 0, NivelFin);
                var InsertionPointText = new double[] { Coord[0] - 0.25f, (float)InsertionPoint[1] + NivelIni + (NivelFin - NivelIni) / 2, 0 };

                FunctionsAutoCAD.FunctionsAutoCAD.AddPolyline2D(Coord, "LINEA-CORTE");
                FunctionsAutoCAD.FunctionsAutoCAD.AddPolyline2D(Coord2, "LINEA-CORTE");
                FunctionsAutoCAD.FunctionsAutoCAD.AddText($"f'c={resistencia} MPa", InsertionPointText, 0.19f, 0.19f, "R80", "ROMANS", 90f, Width2: 2.0f);

            }
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
    }
}
