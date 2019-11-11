using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAsistencia.Entidades
{
    public class AsistenciaDetalle
    {

        [Key]
        public int ID { get; set; }
        public int AsistenciaId { get; set; }
        public int EstudianteID { get; set; }
        public int AsignaturaId { get; set; }
        public string Nombre { get; set; }
        public bool Presente { get; set; }

        public AsistenciaDetalle()
        {
            ID = 0;
            AsistenciaId = 0;
            EstudianteID = 0;
            Nombre = string.Empty;
            Presente = false;
        }

        public AsistenciaDetalle(int iD, int asistenciaId, int estudianteID, int asignaturaId, string nombre, bool presente)
        {
            ID = iD;
            AsistenciaId = asistenciaId;
            EstudianteID = estudianteID;
            AsignaturaId = asignaturaId;
            Nombre = nombre;
            Presente = presente;
        }
    }
}
