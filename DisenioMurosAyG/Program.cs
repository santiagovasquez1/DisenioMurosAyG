using DataAcces;
using DisenioMurosAyG.Controller;
using DisenioMurosAyG.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace DisenioMurosAyG
{
    static class Program
    {
        public static string FicheroExterno { get; set; }
        public static ModeloContext _context { get; set; }
        public static ContextController ContextController { get; set; }
        public static List<string> LayersModelo { get; set; }
        public static string RutaProyecto { get; set; }
        public static VariablesDibujoController VariablesDibujoController { get; set; }
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FicheroExterno = Environment.CommandLine;
            //FicheroExterno =$"{(char)34}C:\\Program Files (x86)\\AyGSoftware\\Diseño Muros AyG\\DisenioMurosAyG.exe{(char)34} {(char)34}F:\\Proyectos Visual Studio\\Desarrollo_Software\\Programa Dibujo Muros ETAPA 1\\Programa Dibujo Muros ETAPA 1\\Prueba1.walls{(char)34}";
            _context = new ModeloContext();
            var contextView = new ContextView();
            ContextController = new ContextController(contextView);
            Application.Run(contextView);
        }
    }
}
