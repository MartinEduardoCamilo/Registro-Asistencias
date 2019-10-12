using System;
using System.Collections.Generic; 
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistroAsistencia.BLL;
using RegistroAsistencia.Entidades;

namespace RegistroAsistencia.UI.Registro
{
    public partial class rEstudiante : Form
    {
        RepositorioBase<Estudiante> repositorio;
        public rEstudiante()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            errorProvider1.Clear();
            IDnumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty; 
        }

        private Estudiante LlenaClase()
        {
            Estudiante estudiante = new Estudiante();
            estudiante.EstudianteID = Convert.ToInt32(IDnumericUpDown.Value);
            estudiante.Nombre = NombretextBox.Text;
            return estudiante;
        }

        private void LlenaCampo(Estudiante e)
        {
            IDnumericUpDown.Value = e.EstudianteID;
            NombretextBox.Text = e.Nombre;
        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                errorProvider1.SetError(NombretextBox, "El campo nombre no debe estar vacio");
                paso = false;
            }
            return paso;
        }

        private bool Existe()
        {
            repositorio = new RepositorioBase<Estudiante>();
            Estudiante estudiante = repositorio.Buscar((int)IDnumericUpDown.Value);
            return (estudiante != null);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            repositorio = new RepositorioBase<Estudiante>();
            Estudiante estudiante = new Estudiante();
            int id = (int)(IDnumericUpDown.Value);

            estudiante = repositorio.Buscar(id);

            if (estudiante != null)
            {
                Limpiar();
                LlenaCampo(estudiante);
            }
            else
            {
                MessageBox.Show("Estudiante no encontrado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso;
            repositorio = new RepositorioBase<Estudiante>();
            Estudiante estudiante = new Estudiante();

            if (!Validar())
                return;

            estudiante = LlenaClase();

            if (IDnumericUpDown.Value == 0)
            {
                paso = repositorio.Guardar(estudiante);
            }
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No existe este estudiante en la base de datos", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = repositorio.Modificar(estudiante);
            }

            if (paso)
            {
                MessageBox.Show("Estudiante Guardar", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            bool paso;
            int id = ((int)IDnumericUpDown.Value);
            repositorio = new RepositorioBase<Estudiante>();

            if (!Existe())
            {
                MessageBox.Show("No se puede eliminar porque no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                paso = repositorio.Eliminar(id);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Eliminado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo elimina", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
