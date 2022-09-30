using Vista.Controlador;
using Vista.Modelo;

namespace Vista.Vistas
{
    public partial class FrmEliminarEstudiante : Form
    {
        private ControladorStudent controladorEstudiante;
        private ControladorPhone controladorTelefono;
        private ControladorEmail controladorEmail;
        private ControladorAddress controladorDireccion;
        private int idEstudiante;
        public FrmEliminarEstudiante(int id)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.idEstudiante = id;
            this.controladorEstudiante = new ControladorStudent();
            this.controladorTelefono = new ControladorPhone();
            this.controladorEmail = new ControladorEmail();
            this.controladorDireccion = new ControladorAddress();
            this.CargarDatosEstudiante(this.idEstudiante);
        }

        private void CargarDatosEstudiante(int id)
        {
            Student estudiante = controladorEstudiante.ConsultarPorId(id);
            txtNombre.Text = estudiante.Name;
            txtApellidos.Text = estudiante.LastName;
            txtTelefono.Text = estudiante.Phone.PhoneNumber;
            txtEmail.Text = estudiante.Email.EmailStudent;
            txtDomicilio.Text = estudiante.Address.AddressInf;
            txtCiudad.Text = estudiante.Address.City;
            txtCodigoPostal.Text = estudiante.Address.ZipCode.ToString();
            txtEstado.Text = estudiante.Address.State;
        }

        private void btnEliminarEstudiante_Click(object sender, EventArgs e)
        {
            bool opcion = MessageBox.Show("¿Esta seguro de eliminar toda la información del estudiante?",
                "Aviso",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes;
            if (opcion)
            {
                this.EliminarEstudiante(this.idEstudiante);
                this.Dispose();
            }
        }

        private void EliminarEstudiante(int id)
        {
            this.controladorEstudiante.Eliminar(id);
        }

        private void btnEliminarTelefono_Click(object sender, EventArgs e)
        {
            bool opcion = MessageBox.Show("¿Esta seguro de eliminar el teléfono del estudiante?",
                "Aviso",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes;
            if (opcion)
            {
                this.EliminarTelefono(this.idEstudiante);
                this.Dispose();
            }
        }

        private void EliminarTelefono(int id)
        {
            this.controladorTelefono.Eliminar(id);
        }
        private void btnEliminarEmail_Click(object sender, EventArgs e)
        {
            bool opcion = MessageBox.Show("¿Esta seguro de eliminar el correo electrónico del estudiante?",
                "Aviso",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes;
            if (opcion)
            {
                this.EliminarEmail(this.idEstudiante);
                this.Dispose();
            }
        }

        private void EliminarEmail(int id)
        {
            this.controladorEmail.Eliminar(id);
        }

        private void btnEliminarDireccion_Click(object sender, EventArgs e)
        {
            bool opcion = MessageBox.Show("¿Esta seguro de eliminar toda la dirección del estudiante?",
                "Aviso",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes;
            if (opcion)
            {
                this.EliminarDireccion(this.idEstudiante);
                this.Dispose();
            }
        }

        private void EliminarDireccion(int id)
        {
            this.controladorDireccion.Eliminar(id);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
