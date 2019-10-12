using RegistroAsistencia.BLL;
using RegistroAsistencia.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aistencia.UI.Consulta
{
    public partial class cAsistencia : Form
    {
        public cAsistencia()
        {
            InitializeComponent();
        }

        private void Consultabutton_Click(object sender, EventArgs e)
        {
            var listado = new List<Asistencia>();

            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0:
                        listado = AsistenciaBLL.GetList(p => true);
                        break;

                    case 1:
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = AsistenciaBLL.GetList(p => p.AsistenciaID == id);
                        break;
                    case 2:
                        int ID = Convert.ToInt32(CriteriotextBox.Text);
                        listado = AsistenciaBLL.GetList(p => p.Asignaturaid == ID);
                        break;
                }

                listado = listado.Where(c => c.Fecha.Date >= DesdedateTimePicker.Value.Date && c.Fecha.Date <= HastadateTimePicker.Value.Date).ToList();
            }
            else
            {
                listado = AsistenciaBLL.GetList(p => true);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listado;
        }
    }
    
}
