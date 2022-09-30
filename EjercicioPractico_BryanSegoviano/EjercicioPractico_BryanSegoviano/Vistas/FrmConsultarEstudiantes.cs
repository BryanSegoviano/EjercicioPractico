using EjercicioPractico_BryanSegoviano;
using Vista.Controlador;

namespace Vista.Vistas
{
    public partial class FrmConsultarEstudiantes : Form
    {
        private ControladorStudent controladorEstudiante;
        private string? indiceSeleccionado;

        public FrmConsultarEstudiantes()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.controladorEstudiante = new ControladorStudent();
        }

        private void FrmConsultarEstudiantes_Load(object sender, EventArgs e)
        {
            this.cargarDatosTabla();
        }

        private void cargarDatosTabla()
        {
            this.tableEstudiantes.DataSource = controladorEstudiante.Consultar();
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            this.DetallesEstudiante();
        }

        private void DetallesEstudiante()
        {
            if (this.indiceSeleccionado != null)
            {
                int id = int.Parse(this.indiceSeleccionado);
                new FrmDetallesEstudiante(id).ShowDialog();
            }
            else
            {
                MessageBox.Show($"Debe seleccionar un estudiante"
                    , "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tableEstudiantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                indiceSeleccionado = tableEstudiantes.CurrentRow.Cells["student_id"].Value.ToString();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.ModificarEstudiante();
        }

        private void ModificarEstudiante()
        {
            if (this.indiceSeleccionado != null)
            {
                int id = int.Parse(this.indiceSeleccionado);
                new FrmModificarEstudiante(id).ShowDialog();
                this.cargarDatosTabla();
            }
            else
            {
                MessageBox.Show($"Debe seleccionar un estudiante"
                    , "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.EliminarEstudiante();
        }

        public void EliminarEstudiante()
        {
            if (this.indiceSeleccionado != null)
            {
                int id = int.Parse(this.indiceSeleccionado);
                new FrmEliminarEstudiante(id).ShowDialog();
                this.cargarDatosTabla();
            }
            else
            {
                MessageBox.Show($"Debe seleccionar un estudiante"
                    , "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.AgregarEstudiante();
            this.cargarDatosTabla();
        }

        private void AgregarEstudiante()
        {
            FrmAltaEstudiantes frmAltaEstudiantes = new FrmAltaEstudiantes();
            frmAltaEstudiantes.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
