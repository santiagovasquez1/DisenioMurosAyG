using System;
using System.Collections.Generic;
using System.Text;

namespace DibujoAutomaticoAlzados
{
   public interface  IDibujoElemento
    {
        double[] InsertionPoint { get; set; }
        double[] SetCoorPoligono(float DeltaX, float longitud, float altitud, float nivel);

    }
}
