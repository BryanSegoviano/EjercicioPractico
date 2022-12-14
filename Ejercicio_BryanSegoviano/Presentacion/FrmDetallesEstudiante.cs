using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using accesoDatos;
using Dominio;

namespace Presentacion
{
    public partial class FrmDetallesEstudiante : Form
    {
        private IFachada fachada;
        public FrmDetallesEstudiante(int id)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.fachada = new Fachada();    
            this.CargarDatosEstudiante(id);
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.CerrarVentana();
        }

        private void CerrarVentana()
        {
            this.Dispose(); 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
