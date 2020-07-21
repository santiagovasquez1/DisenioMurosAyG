using DisenioMurosAyG.Context;
using ControlUsuariosProyectos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisenioMurosAyG.Controller
{
    public class UsuarioController
    {
        public readonly ControlContext _context;
        public Usuario Usuario { get; set; }
        public AplicacionSVG Aplicacion { get; set; }
        public Operacion Operacion { get; set; }
        public List<string> IpV4 { get; set; }
        public UsuarioController(ControlContext context)
        {
            _context = context;
            Usuario = (from usuario in _context.Usuarios
                       where usuario.UsuarioName == "Ana Badillo"
                       select usuario).FirstOrDefault();

            Aplicacion = (from aplicacion in _context.Aplicaciones
                          where aplicacion.AplicacionName == "Diseño de muros AyG"
                          select aplicacion).FirstOrDefault();

            IpV4 = (from operacion in _context.Operaciones
                    select operacion.IpV4).Distinct().ToList();
        }

        public void CreateOperacion()
        {
            Operacion = new Operacion(Usuario, Aplicacion);
            Operacion.InicioOperacion = DateTime.Now;
            _context.Operaciones.Add(Operacion);
            _context.SaveChanges();
        }

        public void EndOperacion()
        {
            Operacion.FinOperacion = DateTime.Now;
            using (var db = new ControlContext())
            {
                db.Operaciones.Update(Operacion);
                db.SaveChanges();
            }
        }

    }
}
