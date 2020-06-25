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
                var ZcIzq = (float)(double)DatosDisenio[i + 1, 7];
                var ZcDer = (float)(double)DatosDisenio[i + 2, 7];
                var Fc = (float)(double)DatosDisenio[i, 9];
                var CapasRefuerzo = (int)DatosDisenio[i + 2, 9];
                var AsH = (float)(double)DatosDisenio[i, 17];
                var AsL = (float)(double)DatosDisenio[i + 1, 17];
                var AsAdicional = (float)(double)DatosDisenio[i + 2, 17];

                Muro = new Muro()
                {
                    Label = NombreMuro,
                    Story = Story,
                    GradoDisipacionEnergia = gradoDisipacionEnergia,
                    lw = Lw,
                    bw = Bw,
                    Ash = AsH,
                    Ast = AsL,
                    AsAdicional = AsAdicional,
                    Capas=CapasRefuerzo,
                    fc = Fc
                };

                if (ZcIzq > 0)
                {
                    ElementoBordeEspecial EbeIzq = new ElementoBordeEspecial(Bw, ZcIzq, Fc, gradoDisipacionEnergia);
                    EbeIzq.CalculoSeparacionminima();
                    Muro.EBE_Izq = EbeIzq;
                }
                if (ZcDer > 0)
                {
                    ElementoBordeEspecial EbeDer = new ElementoBordeEspecial(Bw, ZcDer, Fc, gradoDisipacionEnergia);
                    EbeDer.CalculoSeparacionminima();
                    Muro.EBE_Der = EbeDer;
                }


                Muros.Add(Muro);
            }

        }

        public float GetAs(string Asi)
        {
            var pos = Asi.IndexOf("cm²");
            var Asl = Asi.Substring(0, pos - 1);

            return 0f;
        }

    }
}
