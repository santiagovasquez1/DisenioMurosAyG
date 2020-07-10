using Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DibujoAutomatico
{
    public class DibujoRefuerzo : IDibujoElemento
    {
        public double[] InsertionPoint { get ; set; }
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
            foreach(var refuerzo in Alzado.RefuerzosLongitudinales)
            {
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
