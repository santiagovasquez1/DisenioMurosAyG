using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    [Serializable]
    public class Malla
    {
        public string MallaId { get; set; }
        public string DenomMallla { get; set; }

        private Diametro diametro;

        public Diametro Diametro
        {
            get { return diametro; }
            set
            {
                diametro = value;
                AsVertical = GetAsi(diametro, separacionVertical, capas);
                AsHorizontal = GetAsi(diametro, separacionHorizontal, capas);
            }
        }
        private int capas;

        public int Capas
        {
            get { return capas; }
            set
            {
                capas = value;
                AsVertical = GetAsi(diametro, separacionVertical, capas);
                AsHorizontal = GetAsi(diametro, separacionHorizontal, capas);
            }
        }

        private float separacionVertical;

        public float SeparacionVertical
        {
            get { return separacionVertical; }
            set
            {
                separacionVertical = value;
                AsVertical = GetAsi(diametro, separacionVertical, capas);
            }
        }

        private float separacionHorizontal;

        public float SeparacionHorizontal
        {
            get { return separacionHorizontal; }
            set
            {
                separacionHorizontal = value;
                AsHorizontal = GetAsi(diametro, separacionHorizontal, capas);
            }
        }

        private float espesor;

        public float Espesor
        {
            get { return espesor; }
            set
            {
                espesor = value;
                RhoVertical = GetRho(AsVertical, espesor);
                RhoHorizontal = GetRho(AsHorizontal, espesor);
            }
        }
        private float asiVertical;
        /// <summary>
        /// Area de refuerzo por m de malla
        /// </summary>
        public float AsVertical
        {
            get { return asiVertical; }
            set
            {
                asiVertical = value;
                RhoVertical = GetRho(AsVertical, espesor);
            }
        }
        /// <summary>
        /// Area de refuerzo por m de malla
        /// </summary>
        private float asHorizontal;

        public float AsHorizontal
        {
            get { return asHorizontal; }
            set
            {
                asHorizontal = value;
                RhoHorizontal= GetRho(asHorizontal, espesor);
            }
        }
        public float RhoHorizontal { get; set; }
        public float RhoVertical { get; set; }
        public Malla()
        {
            MallaId = Guid.NewGuid().ToString();
        }
        public Malla(string denomMalla, Diametro diametro, int capas, float separacionVertical,float separacionHorizontal, float espesor)
        {
            DenomMallla = denomMalla;
            MallaId = Guid.NewGuid().ToString();
            Diametro = diametro;
            Capas = capas;
            SeparacionHorizontal = separacionHorizontal;
            SeparacionVertical = separacionVertical;
            Espesor = espesor;
        }

        private float GetAsi(Diametro diametro, float separacion, int cantidad)
        {
            float asi = 0;
            if (separacion > 0)
            {
                asi = cantidad * DiccionariosRefuerzo.ReturnAsi(diametro) / separacion;
            }
            return asi;
        }

        private float GetRho(float asi, float espesor)
        {
            float rho = 0;

            if (asi > 0 & espesor > 0)
            {
                rho = asi / (espesor * 100 * 100);
            }
            return rho;
        }

        public override string ToString()
        {
            return $"{DenomMallla}";
        }
    }
}
