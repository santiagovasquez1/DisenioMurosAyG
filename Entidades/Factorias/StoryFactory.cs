using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Factorias
{

    public class StoryFactory
    {
        public List<Story> Stories { get; set; }
        public Story Story { get; set; }

        public void BuildStories(List<object> NombrePisos, List<object> DatosGeometria)
        {
            int filas = NombrePisos.Count;
            var StoryProp = new List<Tuple<string, double>>();

            for (int i = 3; i < filas; i += 3)
            {
                string Story = (string)NombrePisos[i];
                double h = (double)DatosGeometria[i];
                StoryProp.Add(new Tuple<string, double>(Story, h));
            }

            var pisosDistintos = StoryProp.Distinct().ToList();
            SetStory(pisosDistintos);

        }

        private void SetStory(List<Tuple<string, double>> PisosUnicos)
        {
            Stories = new List<Story>();
            float H = 0;

            for (int i = 0; i < PisosUnicos.Count; i++)
            {
                if (i < PisosUnicos.Count - 1)
                {
                    H = (float)Math.Round(PisosUnicos[i].Item2 - PisosUnicos[i + 1].Item2, 2);
                }
                else
                {
                    H = (float)Math.Round(PisosUnicos[i].Item2);
                }

                Story = new Story(PisosUnicos[i].Item1, H, (float)PisosUnicos[i].Item2);
                Stories.Add(Story);
            }
        }

    }
}
