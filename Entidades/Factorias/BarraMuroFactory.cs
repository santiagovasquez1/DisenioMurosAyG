﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Factorias
{
    public class BarraMuroFactory
    {
        public BarraMuro BarraMuro { get; set; }
        public List<BarraMuro> BarrasMuros { get; set; }
        public List<Muro> Muros { get; set; }

        public BarraMuroFactory(List<Muro> murosmodelo)
        {
            Muros = murosmodelo;
        }
        /// <summary>
        /// Instanciacion de lista de barras por piso
        /// </summary>
        /// <param name="muroName">Nombre del muro</param>
        /// <param name="DenomBarras">Nombre del alzado en planos</param>
        /// <param name="CantidadesBarras">Cantidad de barras por capa de alzado</param>
        /// <param name="BarrasPiso">Diamertros de las barras</param>
        public void BuildBarras(string muroName, List<object> DenomBarras, List<object> CantidadesBarras, List<object> BarrasPiso)
        {
            if (BarrasPiso.Count > 0)
            {
                var StoryName = $"piso{int.Parse(BarrasPiso[0].ToString()) + 1}";

                var muros = (from muro in Muros
                             where $"muro {muro.LabelDef}" == muroName
                             where muro.Story.StoryName.ToLower().Replace(" ", String.Empty) == StoryName
                             select muro).ToList();

                foreach (Muro muro in muros)
                {
                    var barras = new List<BarraMuro>();
                    for (int i = 1; i < BarrasPiso.Count; i++)
                    {
                        var barradenom = DenomBarras[i].ToString();
                        var cant = int.Parse(CantidadesBarras[i].ToString());
                        var diametro = DiccionariosRefuerzo.ReturnDiametro(BarrasPiso[i].ToString());

                        var barra = new BarraMuro(muro.Label, barradenom, cant, diametro);
                        barras.Add(barra);
                    }
                    muro.BarrasMuros = barras;

                }

            }
        }

    }
}
