using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aistencia.Entidades
{
    public class Estudiante
    {
        [Key]
        public int EstudianteID { get; set; }
        public string Nombre { get; set; }

        public Estudiante()
        {
            EstudianteID = 0;
            Nombre = string.Empty;
        }
    }
}
