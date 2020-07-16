using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DibujoAutomaticoAlzados
{
    public class DibujoSeccion : IDibujoElemento
    {
        public Alzado Alzado { get; set; }
        public double[] InsertionPoint { get; set; }
        public string LayerRefuerzo { get; set; }
        public string LayerCota { get; set; }
        public string LayerTexto { get; set; }
        public string LayerNombreSeccion { get; set; }
        public string LayerCoco { get; set; }
        public float Escala { get; set; }
        public float Recubrimiento { get; set; }
        public float Separacion { get; set; }
        public int NumCapas { get; set; }
        public DibujoSeccion(Alzado alzado, double[] insertionpoint, string layerrefuerzo, string layercota, string layertexto, string layernombreseccion, string layercoco, float escala, float recubrimiento)
        {
            Alzado = alzado;
            InsertionPoint = insertionpoint;
            LayerRefuerzo = layerrefuerzo;
            LayerCota = layercota;
            LayerTexto = layertexto;
            LayerNombreSeccion = layernombreseccion;
            LayerCoco = layercoco;
            Escala = escala;
            Recubrimiento = recubrimiento;
        }

        public void DibujoCocoSeccion()
        {
            string TextoSeccion = string.Empty;

            var NumeroSecciones = (from muro in Alzado.Muros
                                   where muro.BarrasMuros != null
                                   select muro.BarrasMuros.Count).Distinct().Reverse().ToList();

            int x = 1;
            float DeltaY = -4.30f;

            var Muroinicial = (from muro in Alzado.Muros
                               where muro.BarrasMuros != null
                               where muro.BarrasMuros.Count == NumeroSecciones.FirstOrDefault()
                               select muro).LastOrDefault();

            var NumBarras = (from barra in Muroinicial.BarrasMuros
                             select barra.Cantidad).Sum();

            NumCapas = NumBarras / 2;

            if (Muroinicial.RhoV >= 0.01)
                Separacion = ((Muroinicial.Lw - 2 * Recubrimiento) / (NumCapas - 1)) * Escala;
            else
                Separacion = 0.15f * Escala;

            foreach (int seccioni in NumeroSecciones)
            {
                var muroi = (from muro in Alzado.Muros
                             where muro.BarrasMuros != null
                             where muro.BarrasMuros.Count == seccioni
                             select muro).LastOrDefault();

                var NivelInicial = (from muro in Alzado.Muros
                                    where muro.BarrasMuros != null
                                    where muro.BarrasMuros.Count == seccioni
                                    select muro.Story.StoryName).LastOrDefault();

                var NivelFinal = (from muro in Alzado.Muros
                                  where muro.BarrasMuros != null
                                  where muro.BarrasMuros.Count == seccioni
                                  select muro.Story.StoryName).FirstOrDefault();

                if (NivelInicial != NivelFinal)
                    TextoSeccion = $"SECCION TRAMO {x} ({NivelInicial} a {NivelFinal})";
                else
                    TextoSeccion = $"SECCION TRAMO {x} ({NivelInicial})";


                var tempcoor = new double[] { 0, 0, 0, -muroi.Bw, muroi.Lw, -muroi.Bw, muroi.Lw, 0 };

                var CoordEscalada = B_Operaciones_Matricialesl.Operaciones.Escalar2(Escala, tempcoor);

                var CoordDef = B_Operaciones_Matricialesl.Operaciones.TraslacionPoligono(Array.ConvertAll(InsertionPoint, y => (float)y), Array.ConvertAll(CoordEscalada, y => (float)y));

                var X1 = (float)CoordDef[0];
                var X2 = (float)CoordDef[4];
                var Y1 = (float)CoordDef[1];
                var Y2 = (float)CoordDef[3];

                var TempCapas = (from barra in muroi.BarrasMuros
                                 where barra != null
                                 select barra.Cantidad).Sum() / 2;

                FunctionsAutoCAD.FunctionsAutoCAD.AddPolyline2D(CoordDef, LayerCoco, true);

                AgregarCota(X1, X2, Y1, Y1, 0.52f, 0f);
                AgregarCota(X1, X1, Y1, Y2, -0.43f, -1.35f);
                AgregarCota(X2, X2, Y1, Y2, 0.43f, -1.35f);

                DibujarRefuerzo(X1, X2, Y1, Y2, TempCapas);
                DibujarTextoSeccion(TextoSeccion, InsertionPoint, X1, X2);
                InsertionPoint = new double[] { InsertionPoint[0], InsertionPoint[1] + DeltaY, InsertionPoint[2] };

                x++;
            }

        }

        public void DibujarTextoSeccion(string TextoSeccion, double[] InsertionPoint, float x1, float x2)
        {
            var CoordText = new double[] { InsertionPoint[0] + (x2 - x1) / 2, InsertionPoint[1] - 2.60, InsertionPoint[2] };
            FunctionsAutoCAD.FunctionsAutoCAD.AddText(TextoSeccion, CoordText, 0.25, 0.25, LayerNombreSeccion, "REG", 0f, Width2: 9.00, justifyText: FunctionsAutoCAD.JustifyText.Left);
        }

        public void DibujarRefuerzo(double X1, double X2, double Y1, double Y2, int numerocapas)
        {
            var PosX1 = X1 + (Recubrimiento * Escala);
            var PosY1 = Y1 - (Recubrimiento * Escala);
            var PosX2 = X2 - (Recubrimiento * Escala);
            var PosY2 = Y2 + (Recubrimiento * Escala);

            if (numerocapas % 2 == 0)
            {
                for (int i = 1; i <= (numerocapas / 2); i++)
                {
                    var CoordCirculo1 = new double[] { PosX1, PosY1, 0 };
                    var CoordCirculo2 = new double[] { PosX1, PosY2, 0 };

                    FunctionsAutoCAD.FunctionsAutoCAD.AddCircle(CoordCirculo1, 0.14f, "REFUERZO-SECCION");
                    FunctionsAutoCAD.FunctionsAutoCAD.AddCircle(CoordCirculo2, 0.14f, "REFUERZO-SECCION");

                    if (i > 1)
                        AgregarCota(PosX1 - Separacion, PosX1, PosY1, PosY1, (Recubrimiento * Escala) + 0.20f, 0f);

                    PosX1 += Separacion;
                }


                for (int i = 1; i <= (numerocapas / 2); i++)
                {
                    var CoordCirculo1 = new double[] { PosX2, PosY1, 0 };
                    var CoordCirculo2 = new double[] { PosX2, PosY2, 0 };

                    FunctionsAutoCAD.FunctionsAutoCAD.AddCircle(CoordCirculo1, 0.14f, "REFUERZO-SECCION");
                    FunctionsAutoCAD.FunctionsAutoCAD.AddCircle(CoordCirculo2, 0.14f, "REFUERZO-SECCION");

                    if (i < numerocapas / 2)
                        AgregarCota(PosX2 - Separacion, PosX2, PosY1, PosY1, (Recubrimiento * Escala) + 0.20f, 0f);

                    PosX2 -= Separacion;
                }
            }
            else
            {
                var Limite1 = (numerocapas / 2);
                var Limite2 = numerocapas - Limite1;

                for (int i = 1; i <= Limite2; i++)
                {
                    var CoordCirculo1 = new double[] { PosX1, PosY1, 0 };
                    var CoordCirculo2 = new double[] { PosX1, PosY2, 0 };

                    FunctionsAutoCAD.FunctionsAutoCAD.AddCircle(CoordCirculo1, 0.14f, "REFUERZO-SECCION");
                    FunctionsAutoCAD.FunctionsAutoCAD.AddCircle(CoordCirculo2, 0.14f, "REFUERZO-SECCION");

                    if (i > 1)
                        AgregarCota(PosX1 - Separacion, PosX1, PosY1, PosY1, (Recubrimiento * Escala) + 0.20f, 0f);

                    PosX1 += Separacion;
                }

                for (int i = 1; i <= Limite1; i++)
                {
                    var CoordCirculo1 = new double[] { PosX2, PosY1, 0 };
                    var CoordCirculo2 = new double[] { PosX2, PosY2, 0 };

                    FunctionsAutoCAD.FunctionsAutoCAD.AddCircle(CoordCirculo1, 0.14f, "REFUERZO-SECCION");
                    FunctionsAutoCAD.FunctionsAutoCAD.AddCircle(CoordCirculo2, 0.14f, "REFUERZO-SECCION");

                    if (i < Limite1)
                        AgregarCota(PosX2 - Separacion, PosX2, PosY1, PosY1, (Recubrimiento * Escala) + 0.20f, 0f);

                    PosX2 -= Separacion;
                }

            }


        }

        public void AgregarCota(double X1, double X2, double Y1, double Y2, float OffsetCota, float despTexto)
        {
            var CoordCota1 = new double[] { X1, Y1, 0 };
            var CoordCota2 = new double[] { X2, Y2, 0 };
            FunctionsAutoCAD.FunctionsAutoCAD.AddCota2(CoordCota1, CoordCota2, LayerCota, "ROMANS", Color.Cyan, DesplazCota: OffsetCota,
                TextHeight: 1.50, scaleLinear: 1 / Escala, ArrowheadSize: 0.85f, DeplazaTextY: despTexto);

        }
        public double[] SetCoorPoligono(float DeltaX, float longitud, float altitud, float nivel)
        {
            return null;
        }
    }
}
