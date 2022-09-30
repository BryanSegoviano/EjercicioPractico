using accesoDatos;
using Dominio;

namespace Presentacion
{
    public partial class FrmAltaEstudiantes : Form
    {
        private IFachada fachada;
        public FrmAltaEstudiantes()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.fachada = new Fachada();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            this.AltaEstudiante();
        }

        private void AltaEstudiante()
        {
            if (this.ValidarCampos() == false)
            {
                return;
            }
            //Student
            string nombres = txtNombre.Text;
            string apellidos = txtApellidos.Text;
            DateTime fechaCreado = DateTime.Now;
            DateTime fechaActualizacion = DateTime.Now;
            //Phone
            string numTelefono = txtTelefono.Text;
            Phone telefono = new Phone(numTelefono);
            //Email
            string correoElectronico = txtEmail.Text;
            Email email = new Email(correoElectronico);
            //Address
            string addressInf = txtDomicilio.Text;
            string city = txtCiudad.Text;
            int zipCode = Convert.ToInt32(txtCodigoPostal.Text);
            string state = txtEstado.Text;
            Address address = new Address(addressInf, city, zipCode, state);
            //
            Student estudianteNuevo = new Student(nombres, apellidos, fechaCreado,
                fechaActualizacion, telefono, email, address);
            this.fachada.AgregarEstudiante(estudianteNuevo);
            this.LimpiarCampos();
            this.Dispose();
        }

        private bool ValidarCampos()
        {
            if (txtNombre.Text == "" ||
                txtApellidos.Text == "" ||
                txtTelefono.Text == "" ||
                txtEmail.Text == "" ||
                txtDomicilio.Text == "" ||
                txtCiudad.Text == "" ||
                txtCodigoPostal.Text == "" ||
                txtEstado.Text == "")
            {
                MessageBox.Show($"Debe llenar todos los campos"
                    , "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int num;
            bool validarCodigoPostal = int.TryParse(txtCodigoPostal.Text, out num);

            if (validarCodigoPostal == false)
            {
                MessageBox.Show($"El código postal debe ser numérico"
                    , "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtDomicilio.Text = string.Empty;
            this.txtCiudad.Text = string.Empty;
            this.txtCodigoPostal.Text = string.Empty;
            this.txtEstado.Text = string.Empty;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}