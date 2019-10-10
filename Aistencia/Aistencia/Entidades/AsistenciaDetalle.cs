using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aistencia.Entidades
{
    public class AsistenciaDetalle
    {
        [Key]
        public int Id { get; set; }
        public int AsistenciaId { get; set; }
        public int AsignaturaId { get; set; }
        public int EstudianteID { get; set; }
        public string Nombre { get; set; }
        public bool Presente { get; set; }
        public AsistenciaDetalle()
        {
            Id = 0;
            AsistenciaId = 0;
            AsignaturaId = 0;
            EstudianteID = 0;
            Nombre = string.Empty;
            Presente =  false;
        }

        public AsistenciaDetalle(int id, int asistenciaId, int asignaturaId, int estudianteID, string nombre, bool presente)
        {
            this.Id = id;
            this.AsistenciaId = asistenciaId;
            this.AsignaturaId = asignaturaId;
            this.EstudianteID = estudianteID;
            this.Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            this.Presente = presente;
        }
    }
}
