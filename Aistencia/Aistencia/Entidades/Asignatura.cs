using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAsistencia.Entidades
{
    public class Asignatura
    {
       [Key]
        public int  AsignaturaId { get; set; }
        public string Nombre { get; set; }

        public Asignatura()
        {
            AsignaturaId = 0;
            Nombre = string.Empty;
        }
    }
}
