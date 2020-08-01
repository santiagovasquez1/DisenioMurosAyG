using DisenioMurosAyG.Views;
using Entidades;
using Entidades.Factorias;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using B_Operaciones_Matricialesl;
using Telerik.WinControls;

namespace DisenioMurosAyG.Controller
{
    public class AlzadoDespieceController
    {
        private InfoRefuerzoView InfoRefuerzoView;

        public AlzadoDespieceView AlzadoDespieceView { get; set; }
        public Alzado AlzadoSeleccionado { get; set; }
        public float EscalaX { get; set; }
        public float EscalaY { get; set; }
        public double EscalaR { get; set; }
        private GraphicsPath GraphicsPathRefuerzo { get; set; }
        private List<Tuple<GraphicsPath, Refuerzo>> InfoRefuerzo { get; set; }
        private Refuerzo InfoRefuerzoSeleccionado { get; set; }
        public InfoRefuerzoController InfoRefuerzoController { get; set; }
        public AlzadoDespieceController(Alzado alzadoseleccionado, AlzadoDespieceView despieceView)
        {
            AlzadoSeleccionado = alzadoseleccionado;
            AlzadoDespieceView = despieceView;
            InfoRefuerzoView = new InfoRefuerzoView();
            AlzadoDespieceView.pbAlzadoDespiece.Paint += new PaintEventHandler(AlzadoPaint);
            AlzadoDespieceView.pbAlzadoDespiece.MouseMove += new MouseEventHandler(Grafica_MouseMove);
        }

        private void Grafica_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseOverPoligono(e.Location))
            {
                InfoRefuerzoController = new InfoRefuerzoController(InfoRefuerzoView, InfoRefuerzoSeleccionado);
                InfoRefuerzoView.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
                InfoRefuerzoView.Visible = true;
            }
            else
            {
                InfoRefuerzoView.Visible = false;
            }
        }

        private void AlzadoPaint(object sender, PaintEventArgs e)
        {
            var Hmax = (from muro in AlzadoSeleccionado.Muros
                        select muro.Story.StoryElevation).Max();

            GraphicsPathRefuerzo = new GraphicsPath();
            InfoRefuerzo = new List<Tuple<GraphicsPath, Refuerzo>>();
            EscalaY = (AlzadoDespieceView.pbAlzadoDespiece.Height - 5f) / (Hmax + Program.VariablesDibujoController.ProfRefuerzo);
            EscalaX = (AlzadoDespieceView.pbAlzadoDespiece.Width - 5f) / 25f;

            Bitmap newImg = new Bitmap(AlzadoDespieceView.pbAlzadoDespiece.Width, AlzadoDespieceView.pbAlzadoDespiece.Height);
            Graphics g = Graphics.FromImage(newImg);
            g.Clear(Color.White);

            Crear_grilla(g, AlzadoDespieceView.pbAlzadoDespiece.Height, AlzadoDespieceView.Width);
            DibujarAlzado(g, AlzadoDespieceView.pbAlzadoDespiece.Height);
            AlzadoDespieceView.pbAlzadoDespiece.Image = newImg;
        }

        private void Crear_grilla(Graphics g, int Height, int Width)
        {
            Pen P = new Pen(Color.Black, 1)
            {
                Brush = Brushes.LightGray,
                Color = Color.LightGray,
                Alignment = PenAlignment.Center
            };

            float TamanoFuente = 0.75f * (EscalaY);
            Font Fuente = new Font("Calibri", TamanoFuente, FontStyle.Bold);

            foreach (var muro in AlzadoSeleccionado.Muros)
            {
                PointF PointString = new PointF(0, Height - (muro.Story.StoryElevation + Program.VariablesDibujoController.ProfRefuerzo) * EscalaY);
                PointF point1 = new PointF(0, Height - (muro.Story.StoryElevation + Program.VariablesDibujoController.ProfRefuerzo) * EscalaY);
                PointF point2 = new PointF(Width, Height - (muro.Story.StoryElevation + Program.VariablesDibujoController.ProfRefuerzo) * EscalaY);

                g.DrawString(muro.Story.StoryName, Fuente, Brushes.Black, PointString);
                g.DrawLine(P, point1, point2);
            }
        }

        private void DibujarAlzado(Graphics g, int Height)
        {
            var ExisteDespiece = AlzadoSeleccionado.Muros.Exists(x => x.BarrasMuros != null);
            float Xi = 1.5f;
            float Yi = -Program.VariablesDibujoController.ProfRefuerzo * EscalaY;

            float TamanoFuente = 0.75f * (EscalaY);
            Font Fuente = new Font("Calibri", TamanoFuente, FontStyle.Regular);

            if (ExisteDespiece)
            {
                var RefuerzoFactory = new RefuerzoLongFactory(AlzadoSeleccionado, 0.0f);
                RefuerzoFactory.SetRefuerzoMuro();
                List<PointF> Cord_Escala = new List<PointF>();

                foreach (var refuerzo in AlzadoSeleccionado.RefuerzosLongitudinales)
                {
                    Cord_Escala = new List<PointF>();

                    Pen P = new Pen(Color.Black, 1)
                    {
                        Color = DiccionariosRefuerzo.ReturnColorRefuerzo(refuerzo.Diametro),
                        Alignment = PenAlignment.Center,
                    };

                    for (int i = 0; i < refuerzo.Coordenadas.Count(); i += +2)
                    {
                        PointF point = new PointF((Xi + refuerzo.Coordenadas[i]) * EscalaX, Height - refuerzo.Coordenadas[i + 1] * EscalaY + Yi);
                        Cord_Escala.Add(point);
                    }
                    g.DrawLines(P, Cord_Escala.ToArray());
                    GraphicsPathRefuerzo.AddLines(Cord_Escala.ToArray());

                    var temp = new GraphicsPath();
                    if (Cord_Escala.Count > 2)
                        temp.AddLines(Cord_Escala.ToArray());
                    else
                        temp.AddLine(Cord_Escala[0], Cord_Escala[1]);

                    InfoRefuerzo.Add(new Tuple<GraphicsPath, Refuerzo>(temp, refuerzo));
                }
            }
        }

        private bool MouseOverPoligono(PointF mouse_pt)
        {
            GraphicsPath path = new GraphicsPath();
            Graphics g = null;

            PointF Temp;
            float X_r, Y_r;

            X_r = mouse_pt.X;
            Y_r = mouse_pt.Y;

            Temp = new PointF(X_r, Y_r);

            foreach (var tupla in InfoRefuerzo)
            {
                if (tupla.Item1.IsVisible(Temp))
                {
                    InfoRefuerzoSeleccionado = tupla.Item2;
                    return true;
                }
            }

            //if (GraphicsPathRefuerzo.IsVisible(Temp))
            //{
            //    InfoRefuerzoSeleccionado = (from tupla in InfoRefuerzo
            //                  where tupla.Item1.IsVisible(Temp)==true
            //                  select tupla.Item2).FirstOrDefault();

            //    return true;
            //}

            return false;
        }

        private void RotarTexto(Graphics gr, float angle,
            string txt, float x, float y, Font fuente, Brush brush)
        {
            GraphicsState state = gr.Save();
            gr.ResetTransform();

            gr.RotateTransform(angle);

            gr.TranslateTransform(x, y, MatrixOrder.Append);

            gr.DrawString(txt, fuente, brush, 0, 0);

            gr.Restore(state);
        }
    }
}
