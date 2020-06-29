using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Factorias
{
    public class MuroFactory
    {
        public Muro Muro { get; set; }
        public List<Muro> Muros { get; set; }
        public List<Story> Stories { get; set; }

        public MuroFactory(List<Story> stories)
        {
            Stories = stories;
        }

        public void BuildMuros(object[,] DatosDisenio, GradoDisipacionEnergia gradoDisipacionEnergia)
        {
            int filas = DatosDisenio.GetLength(0);
            Muros = new List<Muro>();

            for (int i = 2; i < filas; i += 3)
            {
                var StoryName = (string)DatosDisenio[i, 1];
                var Story = Stories.Find(x => x.StoryName == StoryName);
                var NombreMuro = (string)DatosDisenio[i, 2];
                var Lw = (float)(double)DatosDisenio[i, 5];
                var Bw = (float)(double)DatosDisenio[i + 1, 5];
                var Hw = (float)(double)DatosDisenio[i + 2, 5];
                var ZcIzq = (float)(double)DatosDisenio[i + 1, 7];
                var ZcDer = (float)(double)DatosDisenio[i + 2, 7];
                var Fc = (float)(double)DatosDisenio[i, 9];
                var Fy = (float)(double)DatosDisenio[i + 1, 9];
                var CapasRefuerzo = (int)(double)DatosDisenio[i + 2, 9];
                var AsH = (float)(double)DatosDisenio[i, 17];
                var AsV = (float)(double)DatosDisenio[i + 1, 17];
                var AsAdicional = (float)(double)DatosDisenio[i + 2, 17];
                var labelDef = Convert.ToString(DatosDisenio[i, 22]);

                Muro = new Muro()
                {
                    Label = NombreMuro,
                    LabelDef = labelDef,
                    Story = Story,
                    GradoDisipacionEnergia = gradoDisipacionEnergia,
                    Lw = Lw,
                    Bw = Bw,
                    AsH = AsH,
                    AsV = AsV,
                    AsAdicional = AsAdicional,
                    Capas = CapasRefuerzo,
                    Fc = Fc,
                    Fy = Fy
                };

                Muro.Hw = Math.Round(Hw, 2) == Math.Round(Story.StoryElevation, 2)
                    ? Story.StoryHeight
                    : Hw - Story.StoryElevation - Story.StoryElevation;

                if (ZcIzq > 0)
                {
                    ElementoBordeEspecial EbeIzq = new ElementoBordeEspecial(Bw, ZcIzq, Fc, Fy, gradoDisipacionEnergia);
                    EbeIzq.DiametroEstribo = Diametro.Num3;
                    EbeIzq.CalculoSeparacionminima();
                    EbeIzq.CalculoCuantiaVolumetrica(EbeIzq.SepEstribo, EbeIzq.DiametroEstribo);
                    Muro.EBE_Izq = EbeIzq;
                }
                if (ZcDer > 0)
                {
                    ElementoBordeEspecial EbeDer = new ElementoBordeEspecial(Bw, ZcDer, Fc, Fy, gradoDisipacionEnergia);
                    EbeDer.DiametroEstribo = Diametro.Num3;
                    EbeDer.CalculoSeparacionminima();
                    EbeDer.CalculoCuantiaVolumetrica(EbeDer.SepEstribo, EbeDer.DiametroEstribo);
                    Muro.EBE_Der = EbeDer;
                }

                Muro.CalcRhoH();
                Muro.CalcRhoL();

                Muros.Add(Muro);
            }

        }

    }
}
