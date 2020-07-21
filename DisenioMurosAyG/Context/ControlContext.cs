using ControlUsuariosProyectos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisenioMurosAyG.Context
{
    public class ControlContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<AplicacionSVG> Aplicaciones { get; set; }
        public DbSet<Operacion> Operaciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ConnectionString = "Server=usuariossvg.cidxy8evidix.us-east-1.rds.amazonaws.com;" +
                "Database=usuarios_svg;" +
                "Uid=usuariosvg;Pwd=Bucefalo_1205;";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(ConnectionString);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var Usuarios = CrearUsuarios();
            var Aplicaciones = CrearAplicaciones();
            var Aplicacion = Aplicaciones.FirstOrDefault();
            var Operaciones = CrearOperaciones(Usuarios, Aplicacion);

            modelBuilder.Entity<Usuario>().HasData(Usuarios.ToArray());
            modelBuilder.Entity<AplicacionSVG>().HasData(Aplicaciones.ToArray());
            modelBuilder.Entity<Operacion>().HasData(Operaciones.ToArray());
        }

        public List<Usuario> CrearUsuarios()
        {
            var Usuarios = new List<Usuario>()
            {
                new Usuario()
                {
                    UsuarioName="Santiago Vasquez Gomez",
                    UsuarioMail="santivasquez1@gmail.com",
                    Password="Bucefalo_1205",
                    Rol=Roles.SuperAdmin
                },
                new Usuario()
                {
                    UsuarioName="Ana Badillo",
                    UsuarioMail="anabadillo@agingenieria.com.co",
                    Password="12345",
                    Rol=Roles.Admin
                }
            };

            return Usuarios;
        }

        public List<AplicacionSVG> CrearAplicaciones()
        {
            var Aplicaciones = new List<AplicacionSVG>()
            {
                new AplicacionSVG()
                {
                    AplicacionName="Diseño de muros AyG",
                    Version="1.00"
                }
            };

            return Aplicaciones;
        }

        public List<Operacion> CrearOperaciones(List<Usuario> usuarios, AplicacionSVG aplicacion)
        {
            var Operaciones = new List<Operacion>();

            foreach (var usuario in usuarios)
            {
                var operacion = new Operacion();
                operacion.UsuarioId = usuario.UsuarioId;
                operacion.AplicacionId = aplicacion.AplicacionId;
                operacion.InicioOperacion = DateTime.Now;
                operacion.FinOperacion = DateTime.Now.AddMinutes(60);
                Operaciones.Add(operacion);
            }

            return Operaciones;
        }
    }
}
