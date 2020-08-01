using DisenioMurosAyG.Views;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisenioMurosAyG.Controller
{
    public class InfoRefuerzoController
    {
        public InfoRefuerzoView InfoRefuerzoView { get; set; }
        public Refuerzo Refuerzo { get; set; }

        public InfoRefuerzoController(InfoRefuerzoView infoRefuerzoView, Refuerzo refuerzo)
        {
            InfoRefuerzoView = infoRefuerzoView;
            Refuerzo = refuerzo;

            infoRefuerzoView.Num_Barras.Text = Refuerzo.CapaRefuerzo.Cantidad.ToString();
            infoRefuerzoView.D_Barra.Text = DiccionariosRefuerzo.ReturnNombreDiametro(Refuerzo.Diametro, 0);
            infoRefuerzoView.Num_alzado.Text = Refuerzo.CapaRefuerzo.CapaNombre;
            infoRefuerzoView.L_Barra.Text = string.Format("{0:F2}", Refuerzo.Longitud);
        }

    }
}
