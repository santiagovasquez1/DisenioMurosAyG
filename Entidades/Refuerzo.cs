﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    [Serializable]
    public abstract class Refuerzo
    {
        public string RefuerzoId { get; set; }
        public Diametro Diametro { get; set; }
        public CapaRefuerzo CapaRefuerzo { get; set; }
        public int Cantidad { get; set; }
        public float Asi { get; set; }
        public float Peso { get; set; }
        public float Longitud { get; set; }
        public float Separacion { get; set; }
        public Traslapo TipoTraslapo { get; set; }
        public float LongTraslapo { get; set; }
        public TipoRefuerzo TipoRefuerzo { get; set; }
        public float[] Coordenadas { get; set; }
        public abstract float GetPeso(Diametro diametro, float longitud, int cantidad);
        public abstract float GetAsi(Diametro diametro, int cantidad);
        public abstract float GetLong(float[]Coordenadas);
    }
}