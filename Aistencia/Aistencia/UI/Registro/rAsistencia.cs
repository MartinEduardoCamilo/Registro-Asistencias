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
    public partial class rAsistencia : Form
    {
        public List<AsistenciaDetalle> Detalles { get; set; }
        private int cantidad = 0;

        public rAsistencia()
        {
            InitializeComponent();
            this.Detalles = new List<AsistenciaDetalle>();
            this.DetalledataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LlenarEstudianteCombobox();
            LlenarAsignaturaCombobox();
        }

        private void LlenarEstudianteCombobox()
        {
            RepositorioBase<Estudiante> repositorio = new RepositorioBase<Estudiante>();
            List<Estudiante> lista = new List<Estudiante>();
            lista = repositorio.GetList(p => true);
            EstudiantecomboBox.DataSource = lista;
            EstudiantecomboBox.ValueMember = "EstudianteID";
            EstudiantecomboBox.DisplayMember = "Nombre";
        }

        private void LlenarAsignaturaCombobox()
        {
            RepositorioBase<Asignatura> repositorio = new RepositorioBase<Asignatura>();
            List<Asignatura> lista = new List<Asignatura>();
            lista = repositorio.GetList(p => true);
            AsignaturacomboBox.DataSource = lista;
            AsignaturacomboBox.ValueMember = "AsignaturaId";
            AsignaturacomboBox.DisplayMember = "Nombre";
        }

        private void Limpiar()
        {
            MyError.Clear();
            AsistenciaIDnumericUpDown.Value = 0;
            AsignaturacomboBox.Text = string.Empty;
            EstudiantecomboBox.Text = string.Empty;
            PresentecheckBox.Checked = false;
            FechadateTimePicker.Value = DateTime.Now;
            CantidadtextBox.Text = string.Empty;
            cantidad = 0;
            this.Detalles = new List<AsistenciaDetalle>();
            CargarGrid();
        }

        private void CargarGrid()
        {
            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = this.Detalles;
        }

        private Asistencia LlenaClase()
        {
            Asistencia asistencia = new Asistencia();
            asistencia.AsistenciaID = Convert.ToInt32(AsistenciaIDnumericUpDown.Value);
            asistencia.Asignaturaid = Convert.ToInt32(AsignaturacomboBox.SelectedValue);

            asistencia.Fecha = FechadateTimePicker.Value;
            asistencia.Cantidad = Convert.ToInt32(CantidadtextBox.Text);
            asistencia.Presente = this.Detalles;
            return asistencia;
        }

        private void LlenaCampos(Asistencia a)
        {
            AsistenciaIDnumericUpDown.Value = a.AsistenciaID;
            AsignaturacomboBox.Text = getAsignatura(a.Asignaturaid);
            FechadateTimePicker.Value = a.Fecha;
            CantidadtextBox.Text = Convert.ToString(a.Cantidad);
            cantidad = a.Cantidad;
            this.Detalles = a.Presente;
            CargarGrid();
        }


        private string getAsignatura(int id)
        {
            string Nombre = string.Empty;
            RepositorioBase<Asignatura> repositorio = new RepositorioBase<Asignatura>();
            Nombre = repositorio.Buscar(id).Nombre;
            return Nombre;
        }

        private string getEstudiante()
        {
            string Nombre = string.Empty;
            RepositorioBase<Estudiante> repositorio = new RepositorioBase<Estudiante>();
            Nombre = repositorio.Buscar((int)EstudiantecomboBox.SelectedValue).Nombre;
            return Nombre;
        }


        private bool Validar()
        {
            bool paso = true;
            MyError.Clear();

            if (AsignaturacomboBox.SelectedIndex == -1)
            {
                MyError.SetError(AsignaturacomboBox, "Debe elegir una asignatura");
                AsignaturacomboBox.Focus();
                paso = false;
            }

            if (AsignaturacomboBox.Text == string.Empty)
            {
                MyError.SetError(AsignaturacomboBox, "Debe elegir una asignatura");
                AsignaturacomboBox.Focus();
                paso = false;
            }

            if (EstudiantecomboBox.SelectedIndex == -1)
            {
                MyError.SetError(EstudiantecomboBox, "Debe elegir un estudiante");
                EstudiantecomboBox.Focus();
                paso = false;
            }

            if (EstudiantecomboBox.Text == string.Empty)
            {
                MyError.SetError(EstudiantecomboBox, "Debe elegir un estudiante");
                EstudiantecomboBox.Focus();
                paso = false;
            }

            if (this.Detalles.Count == 0)
            {
                MyError.SetError(Agregarbutton, "Debe agregar por lo menos un estudiante");
                Agregarbutton.Focus();
                paso = false;
            }

            return paso;
        }

        private bool ValidoAgregar()
        {
            bool paso = true;
            MyError.Clear();

            if (EstudiantecomboBox.SelectedIndex == -1)
            {
                MyError.SetError(EstudiantecomboBox, "Debe elegir al menos un estudiante");
                EstudiantecomboBox.Focus();
                paso = false;
            }
            if (EstudiantecomboBox.Text == string.Empty)
            {
                MyError.SetError(EstudiantecomboBox, "Debe elegir al menos un estudiante");
                EstudiantecomboBox.Focus();
                paso = false;
            }

            if (paso)
            {
                foreach(var objeto in this.Detalles)
                {
                    if(objeto.EstudianteID == (int)(EstudiantecomboBox.SelectedValue))
                    {
                        MyError.SetError(EstudiantecomboBox, "Ya existe un estudiante");
                        EstudiantecomboBox.Focus();
                        return paso = false;
                    }
                }
            }

            return paso;
        }

        private bool ValidaRemover()
        {
            bool paso = true;

            if (DetalledataGridView.SelectedRows == null)
            {
                MyError.SetError(Removerbutton, "Debe seleccionar al menos una fila.");
                paso = false;
            }

            return paso;
        }

        private bool Existe()
        {
            Asistencia asistencia = AsistenciaBLL.Buscar((int)AsistenciaIDnumericUpDown.Value);
            return (asistencia != null);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(AsistenciaIDnumericUpDown.Value);
            Asistencia asistencia;

            asistencia = AsistenciaBLL.Buscar(ID);

            Limpiar();

            if (asistencia != null)
            {
                
                LlenaCampos(asistencia);
            }
            else
            {
                MessageBox.Show("Asistencia no encontrada");
            }
        }

        private void AgregarAsignaturabutton_Click(object sender, EventArgs e)
        {
            rAsignatura asignatura = new rAsignatura();
            asignatura.ShowDialog();
            LlenarAsignaturaCombobox();
        }

        private void AgregarEstudiantebutton_Click(object sender, EventArgs e)
        {
            rEstudiante estudiante = new rEstudiante();
            estudiante.ShowDialog();
            LlenarEstudianteCombobox();
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            if (DetalledataGridView.DataSource != null)
                this.Detalles = (List<AsistenciaDetalle>)DetalledataGridView.DataSource;
            if (!ValidoAgregar())
                return;

            RepositorioBase<Estudiante> repositorio = new RepositorioBase<Estudiante>();
            int id = repositorio.Buscar((int)EstudiantecomboBox.SelectedValue).EstudianteID;

            RepositorioBase<Asignatura> Base = new RepositorioBase<Asignatura>();
            int ID = Base.Buscar((int)AsignaturacomboBox.SelectedValue).AsignaturaId;

            this.Detalles.Add
                (
                    new AsistenciaDetalle(
                            iD: 0,
                            asistenciaId: (int)AsistenciaIDnumericUpDown.Value,
                            estudianteID: id,
                            asignaturaId: ID,
                            nombre: getEstudiante(),
                            presente: PresentecheckBox.Checked
                        )
                );
            cantidad++;
            CantidadtextBox.Text = cantidad.ToString();
            CargarGrid();
            MyError.Clear();
            PresentecheckBox.Checked = false;
            EstudiantecomboBox.Text = string.Empty;
            AsignaturacomboBox.Text = string.Empty;
        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (!ValidaRemover())
                return;
            int filaDetalle = Convert.ToInt32(DetalledataGridView.CurrentRow.Cells[0].Value);

            if (DetalledataGridView.Rows.Count > 0 && DetalledataGridView.CurrentRow != null && filaDetalle > 0)
            {
                this.Detalles.RemoveAt(DetalledataGridView.CurrentRow.Index);
                cantidad--;
                CantidadtextBox.Text = cantidad.ToString();
                CargarGrid();
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (!Validar())
                return;

            bool paso;
            Asistencia asistencia;
            asistencia = LlenaClase();

            if (AsistenciaIDnumericUpDown.Value == 0)
                paso = AsistenciaBLL.Guardar(asistencia);
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No se puede modificar porque no existe en la base de datos","Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = AsistenciaBLL.Modificar(asistencia);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            MyError.Clear();
            int id = Convert.ToInt32(AsistenciaIDnumericUpDown.Value);
            bool paso;

            if (!Existe())
            {
                MessageBox.Show("No se puede eliminar porque no existe.", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                paso = AsistenciaBLL.Eliminar(id);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Asistencia eliminada!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la asistencia", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

