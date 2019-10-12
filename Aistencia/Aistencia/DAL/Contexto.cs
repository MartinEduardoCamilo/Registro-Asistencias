using RegistroAsistencia.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAsistencia.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }
        public Contexto() : base("ConStr") { }
    }
}
