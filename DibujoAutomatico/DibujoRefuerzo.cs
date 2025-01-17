﻿using Entidades;
using System;
using B_Operaciones_Matricialesl;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DibujoAutomatico
{
    public class DibujoRefuerzo : IDibujoElemento
    {
        public double[] InsertionPoint { get; set; }
        public Alzado Alzado { get; set; }
        public string LayerRefuerzo { get; set; }
        public string LayerCota { get; set; }
        public string LayerTexto { get; set; }
        public float HLosa { get; set; }
        public string LayerCoco { get; set; }

        public DibujoRefuerzo(Alzado alzado, double[] insertionpoint, float hlosa, string layercoco, string leyerrefuerzo, string layertexto)
        {
            Alzado = alzado;
            InsertionPoint = insertionpoint;
            HLosa = hlosa;
            LayerCoco = layercoco;
            LayerTexto = layertexto;
            LayerRefuerzo = leyerrefuerzo;
        }

        public void DibujarRefuerzoLongitudinal()
        {
            var PointI = new float[] { (float)InsertionPoint[0], (float)InsertionPoint[1] };

            foreach (var refuerzo in Alzado.RefuerzosLongitudinales)
            {
                var temp = Array.ConvertAll(InsertionPoint, x => (float)x);
                //var Prueba = Operaciones.TraslacionPoligono(temp, refuerzo.Coordenadas);

                var Coord = Array.ConvertAll(refuerzo.Coordenadas, x => (double)x);
                FunctionsAutoCAD.FunctionsAutoCAD.AddPolyline2D(Coord, LayerRefuerzo, false);
            }
        }

        public double[] SetCoorPoligono(float DeltaX, float longitud, float altitud, float nivel)
        {

            return null;
        }
    }
}
