using accesoDatos;
using Dominio;

namespace Presentacion
{
    public partial class FrmEliminarEstudiante : Form
    {
        private IFachada fachada;
        private int idEstudiante;
        public FrmEliminarEstudiante(int id)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.idEstudiante = id;
            this.fachada = new Fachada();
            this.CargarDatosEstudiante(this.idEstudiante);
        }

        private void CargarDatosEstudiante(int id)
        {
            Student estudiante = this.fachada.ConsultarPorIdEstudiante(id);
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
            this.fachada.EliminarEstudiante(id);
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
            this.fachada.EliminarTelefono(id);
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
            this.fachada.EliminarEmail(id);
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
            this.fachada.EliminarDireccion(id);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
