using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aistencia.Entidades
{
    public class Asistencia
    {
        public int AsistenciaId { get; set; }
        public DateTime Fecha { get; set; }
        public int Asignaturaid { get; set; }
        public int Cantidad { get; set; }

        public virtual List<AsistenciaDetalle> Presente { get; set; }

        public Asistencia()
        {
            AsistenciaId = 0;
            Fecha = DateTime.Now;
            Asignaturaid = 0;
            Cantidad = 0;
            Presente = new List<AsistenciaDetalle>();
        }
    }
}
