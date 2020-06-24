using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class RefuerzoLong
    {
        public string RefuerzoLongId { get; set; }
        public Diametro Diametro { get; set; }
        public float Asi { get; set; }
        public float[] Coordenadas { get; set; }

        public RefuerzoLong()
        {

        }

    }
}