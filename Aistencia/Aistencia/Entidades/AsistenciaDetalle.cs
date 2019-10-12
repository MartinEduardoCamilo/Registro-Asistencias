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
        public AsistenciaDetalle(int iD, int asistenciaId, int estudianteID, string nombre, bool presente)
        {
            this.ID = iD;
            this.AsistenciaId = asistenciaId;
            this.EstudianteID = estudianteID;
            this.Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            this.Presente = presente;
        }

        public AsistenciaDetalle(int estudianteID, string nombre, bool presente)
        {
            this.EstudianteID = estudianteID;
            this.Nombre = nombre;
            this.Presente = presente;
        }
    }
}
