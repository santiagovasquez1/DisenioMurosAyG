using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class BarraMuro
    {
        public string BarraId { get; set; }
        public string MuroName { get; set; }
        public Muro Muro { get; set; }
        public string BarraDenom { get; set; }
        public int Cantidad { get; set; }
        public Diametro Diametro { get; set; }
        public Traslapo Traslapo { get; set; }

        public BarraMuro(string barradenom, Traslapo traslapo)
        {
            BarraId = Guid.NewGuid().ToString();
            BarraDenom = barradenom;
            Traslapo = traslapo;
        }
        public BarraMuro(string nombremuro, Muro muro, string barradenom, int cantidad, Diametro diametro, Traslapo traslapo)
        {
            BarraId = Guid.NewGuid().ToString();
            MuroName = nombremuro;
            Muro = muro;
            BarraDenom = barradenom;
            Diametro = diametro;
            Cantidad = cantidad;
            Traslapo = traslapo;
        }
        public override string ToString()
        {
            return $"Capa {BarraDenom}-{Cantidad}#{DiccionariosRefuerzo.ReturnNombreDiametro(this.Diametro)}{Traslapo}";
        }
    }
}
