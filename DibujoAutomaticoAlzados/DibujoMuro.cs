﻿using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using FunctionsAutoCAD;

namespace DibujoAutomaticoAlzados
{
    public class DibujoMuro : IDibujoElemento
    {
        public Muro Muro { get; set; }
        public double[] InsertionPoint { get; set; }
        public double[] InsertionPointText { get; set; }
        public double[] CoordCoco { get; set; }
        public double[] CoordEBE { get; set; }
        public double[] CoordNivel { get; set; }
        public double[] CoordLosa { get; set; }
        public string LayerCoco { get; set; }
        public string LayerHatchEBE { get; set; }
        public string LayerTexto { get; set; }
        public string LayerCota { get; set; }
        public float HLosa { get; set; }
        public DibujoMuro(Muro muro, double[] insertionpoint, float hlosa, string layercoco, string layerebe, string layertexto, string layerCota)
        {
            Muro = muro;
            InsertionPoint = insertionpoint;
            HLosa = hlosa;
            LayerCoco = layercoco;
            LayerCota = layerCota;
            LayerHatchEBE = layerebe;
            LayerTexto = layertexto;
            CoordCoco = SetCoorPoligono(0, muro.Lw, muro.Hw, muro.Story.StoryElevation);
            CoordLosa = SetCoorPoligono(0, Muro.Lw, 0f, muro.Story.StoryElevation - HLosa);
            CoordNivel = SetCoorPoligono(-1.78f, 1.54f, 0f, muro.Story.StoryElevation);
            InsertionPointText = new double[] { -1.78f + insertionpoint[0], insertionpoint[1] + muro.Story.StoryElevation + 0.25f, 0f };
        }
        public DibujoMuro(Muro muro, double[] insertionpoint, float hlosa, float LwCoco, string layercoco, string layertexto, string layerCota)
        {
            Muro = muro;
            InsertionPoint = insertionpoint;
            HLosa = hlosa;
            LayerCota = layerCota;
            LayerCoco = layercoco;
            LayerTexto = layertexto;
            CoordCoco = SetCoorPoligono(0, LwCoco, muro.Hw, muro.Story.StoryElevation);
            CoordLosa = SetCoorPoligono(0, LwCoco, 0f, muro.Story.StoryElevation - HLosa);
            CoordNivel = SetCoorPoligono(-1.78f, 1.54f, 0f, muro.Story.StoryElevation);
            InsertionPointText = new double[] { -1.78f + insertionpoint[0], insertionpoint[1] + muro.Story.StoryElevation + 0.25f, 0f };
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

        public void DibujarCoco()
        {
            FunctionsAutoCAD.FunctionsAutoCAD.AddPolyline2D(CoordCoco, LayerCoco, true);
            FunctionsAutoCAD.FunctionsAutoCAD.AddPolyline2D(CoordLosa, LayerCoco, true);
            FunctionsAutoCAD.FunctionsAutoCAD.AddPolyline2D(CoordNivel, LayerTexto, true);
            FunctionsAutoCAD.FunctionsAutoCAD.AddText(Muro.Story.StoryName, InsertionPointText, 0.20f, 0.20f, LayerTexto, "ROMANS", 0f, Width2: 2.0f);
        }

        public void DibujarEBE()
        {
            FunctionsAutoCAD.FunctionsAutoCAD.AddPolyline2D(CoordEBE, LayerCoco, "SOLID", LayerHatchEBE, 0f);
        }

        public void DibujarCotasMuro(float altitud, float nivel)
        {
            var niveltemp = nivel - altitud;
            var P1 = new double[] { InsertionPoint[0] + Muro.Lw, InsertionPoint[1] + niveltemp, 0 };
            var P2 = new double[] { InsertionPoint[0] + Muro.Lw, InsertionPoint[1] + niveltemp + altitud - HLosa, 0 };
            FunctionsAutoCAD.FunctionsAutoCAD.AddCota(P1, P2, LayerCota, "ROMANS", 0.75f, TextHeight: 1.50, ArrowheadSize: 0.85f);
        }
        public void DibujarCotasViga(float altitud, float nivel)
        {
            var niveltemp = nivel - altitud;
            var P1 = new double[] { InsertionPoint[0] + Muro.Lw, InsertionPoint[1] + niveltemp, 0 };
            var P2 = new double[] { InsertionPoint[0] + Muro.Lw, InsertionPoint[1] + niveltemp + altitud, 0 };
            FunctionsAutoCAD.FunctionsAutoCAD.AddCota(P1, P2, LayerCota, "ROMANS", 0.75f, TextHeight: 1.50, ArrowheadSize: 0.85f, DeplazaTextX: 0.40f);
        }

        public void DibujarMalla(float altitud, float nivel)
        {
            var niveltemp = nivel - altitud;
            var TextString = Muro.Malla.DenomMallla;
            var TextInsertion = new double[] { InsertionPoint[0] - 0.50 + Muro.Lw / 2, InsertionPoint[1] + niveltemp + (Muro.Hw / 2), 0 };
            var RectCoord = new double[] {TextInsertion[0]-0.05,TextInsertion[1]-0.25,
                                                               TextInsertion[0]+1.05,TextInsertion[1]-0.25,
                                                               TextInsertion[0]+1.05 ,TextInsertion[1]+0.05,
                                                               TextInsertion[0]-0.05,TextInsertion[1]+0.05};

            FunctionsAutoCAD.FunctionsAutoCAD.AddText(TextString, TextInsertion, 0.20f, 0.20f, LayerTexto, "ROMANS", 0f, Width2: 1.05f);
            FunctionsAutoCAD.FunctionsAutoCAD.AddPolyline2D(RectCoord, "LINEA-CORTE", true);
        }

    }
}
