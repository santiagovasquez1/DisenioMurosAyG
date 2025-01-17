﻿using System.Collections.Generic;
using System.Linq;

namespace Entidades.Factorias
{
    public class BarraMuroFactory
    {
        public CapaRefuerzo CapaRefuerzo { get; set; }
        public BarraMuro BarraMuro { get; set; }
        public List<BarraMuro> BarrasMuros { get; set; }
        public List<Muro> Muros { get; set; }

        public BarraMuroFactory(List<Muro> murosmodelo)
        {
            Muros = murosmodelo;
        }

        public List<CapaRefuerzo> BuildCapas(List<object> DenomBarras, List<object> CantidadesBarras)
        {
            int x = 0;
            List<CapaRefuerzo> TempCapas = new List<CapaRefuerzo>();
            for (int i = 1; i < DenomBarras.Count; i++)
            {
                var barradenom = DenomBarras[i].ToString();
                var cant = int.Parse(CantidadesBarras[i].ToString());

                Traslapo traslapo;
                if (x % 2 == 0)
                    traslapo = Traslapo.Par;
                else
                    traslapo = Traslapo.Impar;

                CapaRefuerzo = new CapaRefuerzo(barradenom, cant, traslapo, x);
                TempCapas.Add(CapaRefuerzo);

                x++;
            }
            return TempCapas;
        }

        /// <summary>
        /// Instanciacion de lista de barras por piso
        /// </summary>
        /// <param name="muroName">Nombre del muro</param>
        /// <param name="DenomBarras">Nombre del alzado en planos</param>
        /// <param name="CantidadesBarras">Cantidad de barras por capa de alzado</param>
        /// <param name="BarrasPiso">Diamertros de las barras</param>
        public void BuildBarras(string muroName, List<object> DenomBarras, List<object> CantidadesBarras, List<object> BarrasPiso, List<CapaRefuerzo> capas)
        {
            if (BarrasPiso.Count > 0)
            {
                if (BarrasPiso[0] != null)
                {
                    var StoryName = $"piso{int.Parse(BarrasPiso[0].ToString()) + 1}".Replace(" ", string.Empty).ToLower();

                    var muros = (from muro in Muros
                                 where ($"muro{muro.LabelDef}").ToLower() == muroName
                                 where muro.Story.StoryName.ToLower().Replace(" ", string.Empty) == StoryName
                                 select muro).ToList();

                    foreach (Muro muro in muros)
                    {
                        var barras = new List<BarraMuro>();
                        int x = 0;
                        int y = 0;

                        for (int i = 1; i < DenomBarras.Count; i++)
                        {
                            if (BarrasPiso[i] != null)
                            {
                                var barradenom = DenomBarras[i].ToString();

                                var capa = (from capai in capas
                                            where capai.Pos == i - 1
                                            select capai).FirstOrDefault();

                                var cant = int.Parse(CantidadesBarras[i].ToString());
                                var diametro = DiccionariosRefuerzo.ReturnDiametro(BarrasPiso[i].ToString());

                                var barra = new BarraMuro(muro.Label, muro, diametro, capa);
                                barras.Add(barra);
                                y++;
                            }
                            x++;
                        }
                        muro.BarrasMuros = barras;
                        muro.CalcAsTotal();
                    }
                }
            }
        }
    }
}