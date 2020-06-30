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
        public string BarraDenom { get; set; }
        public int Cantidad { get; set; }
        public Diametro Diametro { get; set; }

        public BarraMuro(string nombremuro, string barradenom, int cantidad, Diametro diametro)
        {
            BarraId = Guid.NewGuid().ToString();
            MuroName = nombremuro;
            BarraDenom = barradenom;
            Diametro = diametro;
            Cantidad = cantidad;
        }
        public override string ToString()
        {
            return $"Capa {BarraDenom}-{Cantidad}#{DiccionariosRefuerzo.ReturnNombreDiametro(this.Diametro)}";
        }
    }
}
