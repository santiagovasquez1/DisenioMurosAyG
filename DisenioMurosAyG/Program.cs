using DataAcces;
using DisenioMurosAyG.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisenioMurosAyG
{
    static class Program
    {
        public static ModeloContext _context{ get; set; }
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _context = new ModeloContext();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InicioProyectoView());
        }
    }
}
