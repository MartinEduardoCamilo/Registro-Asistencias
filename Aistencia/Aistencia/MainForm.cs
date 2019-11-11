using Aistencia.UI.Consulta;
using RegistroAsistencia.UI.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroAsistencia
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void asistenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rAsistencia asistencia = new rAsistencia();
            asistencia.MdiParent = this;
            asistencia.Show();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form asistencia = new cAsistencia();
            asistencia.MdiParent = this;
            asistencia.Show();
        }
    }
}
