using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DibujoAutomatico
{
   public static class OperacionesMatriciales
    {
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

    }
}
