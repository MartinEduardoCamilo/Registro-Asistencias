using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAsistencia.Entidades
{
    public class Estudiante
    {
        [Key]
        public int EstudianteID { get; set; }
        public string Nombre { get; set; }
        public int Presente { get; set; }
        public int Ausente { get; set; }

        public Estudiante()
        {
            EstudianteID = 0;
            Nombre = string.Empty;
            Presente = 0;
            Ausente = 0;

        }
    }
}
