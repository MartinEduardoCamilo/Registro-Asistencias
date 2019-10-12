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

namespace RegistroAsistencia.UI.Registro
{
    public partial class rAsignatura : Form
    {
        RepositorioBase<Asignatura> repositorio;
        public rAsignatura()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            errorProvider1.Clear();
            AsignarturaidnumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
        }

        private Asignatura LlenaClase()
        {
            Asignatura asignatura = new Asignatura();
            asignatura.AsignaturaId = Convert.ToInt32(AsignarturaidnumericUpDown.Value);
            asignatura.Nombre = NombretextBox.Text;
            return asignatura;
        }

        private void LlenaCampo(Asignatura a)
        {
            AsignarturaidnumericUpDown.Value = a.AsignaturaId;
            NombretextBox.Text = a.Nombre;
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
            repositorio = new RepositorioBase<Asignatura>();
            Asignatura asignatura = repositorio.Buscar((int)AsignarturaidnumericUpDown.Value);
            return (asignatura != null);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            repositorio = new RepositorioBase<Asignatura>();
            Asignatura asignatura = new Asignatura();
            int id = (int)(AsignarturaidnumericUpDown.Value);

            asignatura = repositorio.Buscar(id);

            if (asignatura != null)
            {
                Limpiar();
                LlenaCampo(asignatura);
            }
            else
            {
                MessageBox.Show("Asignatura no encontrado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso;
            repositorio = new RepositorioBase<Asignatura>();
            Asignatura asignatura = new Asignatura();

            if (!Validar())
                return;

            asignatura = LlenaClase();

            if (AsignarturaidnumericUpDown.Value == 0)
            {
                paso = repositorio.Guardar(asignatura);
            }
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No existe esta asignatura en la base de datos", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = repositorio.Modificar(asignatura);
            }

            if (paso)
            {
                MessageBox.Show("asignatura Guardada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int id = ((int)AsignarturaidnumericUpDown.Value);
            repositorio = new RepositorioBase<Asignatura>();

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
