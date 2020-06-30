using DataAcces;
using DisenioMurosAyG.Controller;
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
        public static ContextController ContextController { get; set; }
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _context = new ModeloContext();
            var contextView = new ContextView();
            ContextController = new ContextController(contextView);
            Application.Run(contextView);
        }
    }
}
