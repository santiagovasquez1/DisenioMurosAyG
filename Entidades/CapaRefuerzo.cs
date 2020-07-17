using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
     [Serializable]
    public class CapaRefuerzo
    {
        public string CapaId { get; set; }
        public string CapaNombre { get; set; }
        public int Pos { get; set; }
        public int Cantidad { get; set; }
        public Traslapo Traslapo { get; set; }

        public CapaRefuerzo()
        {
            CapaId = Guid.NewGuid().ToString();
        }

        public CapaRefuerzo(string nombre, int cant, Traslapo traslapo,int pos)
        {
            CapaId = Guid.NewGuid().ToString();
            CapaNombre = nombre;
            Cantidad = cant;
            Traslapo = traslapo;
            Pos = pos;
        }
    }
}
