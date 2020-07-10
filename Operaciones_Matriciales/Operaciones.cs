using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Operaciones_Matriciales
{
    public class Operaciones
    {
        public static List<double> Rotacion(double DiX, double DiY, double Theta)
        {
            Matrix<double> mOriginal;
            Matrix<double> mRotacion;
            Matrix<double> mProdPunto;
            List<double> Temp = new List<double>();

            mOriginal = Matrix<double>.Build.DenseOfArray(new double[,] { { DiX, DiY } });
            mRotacion = Matrix<double>.Build.DenseOfArray(new double[,] { { Math.Cos(Theta), -Math.Sin(Theta) }, { Math.Sin(Theta), Math.Cos(Theta) } });

            mProdPunto = mOriginal * mRotacion;

            for (int i = 0; i < mProdPunto.ColumnCount; i++)
            {
                Temp.Add(mProdPunto[0, i]);
            }

            Temp.Add(0);
            return Temp;
        }
        /// <summary>
        /// Traslacion de  un punto
        /// </summary>
        /// <param name="PointC">Punto de origen</param>
        /// <param name="PointI">Punto a Trasladar</param>
        /// <returns></returns>
        public static List<double> Traslacion(float[] PointC, float[] PointI)
        {
            Matrix<double> mOriginal;
            Matrix<double> mTraslacion;
            Matrix<double> mProdPunto;
            List<double> Temp = new List<double>();

            var Xc = PointC[0];
            var Yc = PointC[1];
            var Xi = PointI[0];
            var Yi = PointI[1];

            mOriginal = Matrix<double>.Build.DenseOfArray(new double[,] { { 1, 0, Xc }, { 0, 1, Yc }, { 0, 0, 1 } });
            mTraslacion = Matrix<double>.Build.DenseOfArray(new double[,] { { Xi }, { Yi }, { 1 } });

            mProdPunto = mOriginal * mTraslacion;

            for (int i = 0; i < mProdPunto.RowCount; i++)
            {
                Temp.Add(mProdPunto[i, 0]);
            }

            return Temp;
        }
        /// <summary>
        /// Traslacion de puntos de un vector de coordenadas
        /// </summary>
        /// <param name="PointC"></param>
        /// <param name="Coordenadas"></param>
        /// <returns></returns>
        public static double[] TraslacionPoligono(float[] PointC, float[] Coordenadas)
        {
            Matrix<double> mOriginal;
            Matrix<double> mTraslacion;
            Matrix<double> mProdPunto;

            var Xc = PointC[0];
            var Yc = PointC[1];

            mOriginal = Matrix<double>.Build.DenseOfArray(new double[,] { { 1, 0, Xc }, { 0, 1, Yc }, { 0, 0, 1 } });

            for (int i = 0; i < Coordenadas.Count() - 2; i += 2)
            {
                var Xi = Coordenadas[i];
                var Yi = Coordenadas[i + 1];

                mTraslacion = Matrix<double>.Build.DenseOfArray(new double[,] { { Xi }, { Yi }, { 1 } });
                mProdPunto = mOriginal * mTraslacion;
            }
            return null;
        }

        public static List<float[]> Escalar(double Escala, List<float[]> Matriz)
        {
            List<float[]> Temp = new List<float[]>();

            for (int i = 0; i < Matriz.Count; i++)
            {
                Temp.Add(Matriz[i]);

                for (int j = 0; j < Temp[i].Count(); j++)
                {
                    Temp[i][j] = (float)Escala * Matriz[i][j];
                }
            }

            return Temp;
        }

        public static List<float[]> OffSet(float D_off, List<float[]> Matriz, bool Incremento)
        {
            List<float[]> Temp = new List<float[]>();
            float Xmin, Xmax;
            float Ymin, Ymax;

            Xmin = Matriz.Select(x => x[0]).Distinct().Min();
            Xmax = Matriz.Select(x => x[0]).Distinct().Max();

            Ymin = Matriz.Select(x => x[1]).Distinct().Min();
            Ymax = Matriz.Select(x => x[1]).Distinct().Max();

            for (int i = 0; i < Matriz.Count; i++)
            {
                Temp.Add(Matriz[i]);

                #region Offset DirX

                if (Matriz[i][0] == Xmax & Incremento == true)
                {
                    Temp[i][0] = Matriz[i][0] + D_off;
                }
                else if (Matriz[i][0] == Xmin & Incremento == true)
                {
                    Temp[i][0] = Matriz[i][0] - D_off;
                }

                if (Matriz[i][0] == Xmax & Incremento == false)
                {
                    Temp[i][0] = Matriz[i][0] - D_off;
                }
                else if (Matriz[i][0] == Xmin & Incremento == false)
                {
                    Temp[i][0] = Matriz[i][0] + D_off;
                }

                #endregion Offset DirX

                #region Offset DirY

                if (Matriz[i][1] == Ymax & Incremento == true)
                {
                    Temp[i][1] = Matriz[i][1] + D_off;
                }
                else if (Matriz[i][1] == Ymin & Incremento == true)
                {
                    Temp[i][1] = Matriz[i][1] - D_off;
                }

                if (Matriz[i][1] == Ymax & Incremento == false)
                {
                    Temp[i][1] = Matriz[i][1] - D_off;
                }
                else if (Matriz[i][1] == Ymin & Incremento == false)
                {
                    Temp[i][1] = Matriz[i][1] + D_off;
                }

                #endregion Offset DirY
            }

            return Temp;
        }
    }
}
