using accesoDatos;
using Dominio;

namespace Presentacion
{
    public partial class FrmModificarEstudiante : Form
    {
        private IFachada fachada;
        private Student? estudiante;
        public FrmModificarEstudiante(int id)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.fachada = new Fachada();
            this.CargarDatosEstudiante(id);
        }
        private void CargarDatosEstudiante(int id)
        {
            estudiante = this.fachada.ConsultarPorIdEstudiante(id);
            txtNombre.Text = estudiante.Name;
            txtApellidos.Text = estudiante.LastName;
            txtTelefono.Text = estudiante.Phone.PhoneNumber;
            txtEmail.Text = estudiante.Email.EmailStudent;
            txtDomicilio.Text = estudiante.Address.AddressInf;
            txtCiudad.Text = estudiante.Address.City;
            txtCodigoPostal.Text = estudiante.Address.ZipCode.ToString();
            txtEstado.Text = estudiante.Address.State;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.ModificarEstudiante();
        }
        private void ModificarEstudiante()
        {
            if (this.ValidarCampos() == false)
            {
                return;
            }
            this.estudiante.Name = txtNombre.Text;
            this.estudiante.LastName = txtApellidos.Text;
            this.estudiante.Phone.PhoneNumber = txtTelefono.Text;
            this.estudiante.Email.EmailStudent = txtEmail.Text;
            this.estudiante.Address.AddressInf = txtDomicilio.Text;
            this.estudiante.Address.City = txtCiudad.Text;
            this.estudiante.Address.ZipCode = int.Parse(txtCodigoPostal.Text);
            this.estudiante.Address.State = txtEstado.Text;
            this.fachada.ActualizarEstudiante(estudiante);
            this.Dispose();
        }

        private bool ValidarCampos()
        {
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
    }
}
