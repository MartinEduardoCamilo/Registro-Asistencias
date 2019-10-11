using Aistencia.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aistencia.UI.Registro
{
    public partial class rAsistencia : Form
    {
        public List<AsistenciaDetalle> Detalle { get; set; }
        public rAsistencia()
        {
            InitializeComponent();
            this.Detalle = new List<AsistenciaDetalle>();
            this.DetalledataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
    }
}
