using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    [Serializable]
    public class BarraMuro
    {
        public string BarraId { get; set; }
        public string MuroName { get; set; }
        public Muro Muro { get; set; }
        public string BarraDenom { get; set; }
        public int BaraDenomPos { get; set; }
        public int Cantidad { get; set; }
        public Diametro Diametro { get; set; }
        public Traslapo Traslapo { get; set; }
        public CapaRefuerzo CapaRefuerzo { get; set; }
        public BarraMuro(string nombremuro, Muro muro, CapaRefuerzo capaRefuerzo)
        {
            BarraId = Guid.NewGuid().ToString();
            MuroName = nombremuro;
            Muro = muro;
            CapaRefuerzo = capaRefuerzo;
            BarraDenom = CapaRefuerzo.CapaNombre;
            Cantidad = CapaRefuerzo.Cantidad;
            Traslapo = CapaRefuerzo.Traslapo;
        }
        public BarraMuro(string nombremuro, Muro muro, Diametro diametro, CapaRefuerzo capa)
        {
            BarraId = Guid.NewGuid().ToString();
            MuroName = nombremuro;
            Muro = muro;
            CapaRefuerzo = capa;
            BarraDenom = CapaRefuerzo.CapaNombre;
            Diametro = diametro;
            Cantidad = CapaRefuerzo.Cantidad;
            Traslapo = CapaRefuerzo.Traslapo;
        }
        public override string ToString()
        {
            return $"Capa {BarraDenom}-{Cantidad}#{DiccionariosRefuerzo.ReturnNombreDiametro(this.Diametro, 1)}{Traslapo}";
        }
    }
}
