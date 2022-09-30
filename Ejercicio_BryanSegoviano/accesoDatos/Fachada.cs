using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accesoDatos
{
    public class Fachada : IFachada
    {
        private readonly AddressDAO addressDAO;
        private readonly EmailDAO emailDAO;
        private readonly PhoneDAO phoneDAO;
        private readonly StudentDAO studentDAO;

        public Fachada()
        {
            this.addressDAO = new AddressDAO();
            this.emailDAO = new EmailDAO();
            this.phoneDAO = new PhoneDAO();
            this.studentDAO = new StudentDAO();
        }

        public void ActualizarDireccion(Address entidad)
        {
            this.addressDAO.Actualizar(entidad);
        }

        public void ActualizarEmail(Email entidad)
        {
            this.emailDAO.Actualizar(entidad);
        }

        public void ActualizarEstudiante(Student entidad)
        {
            this.studentDAO.Actualizar(entidad);
        }

        public void ActualizarTelefono(Phone entidad)
        {
            this.phoneDAO.Actualizar(entidad);
        }

        public void AgregarDireccion(Address entidad)
        {
            this.addressDAO.Agregar(entidad);
        }

        public void AgregarEmail(Email entidad)
        {
            this.emailDAO.Agregar(entidad);
        }

        public void AgregarEstudiante(Student entidad)
        {
            this.studentDAO.Agregar(entidad);
        }

        public void AgregarTelefono(Phone entidad)
        {
            this.phoneDAO.Agregar(entidad);
        }

        public DataTable ConsultarDireccion()
        {
            return this.addressDAO.Consultar();
        }

        public DataTable ConsultarEmail()
        {
            return this.emailDAO.Consultar();
        }

        public DataTable ConsultarEstudiante()
        {
            return this.studentDAO.Consultar();
        }

        public Address ConsultarPorIdDireccion(int id)
        {
            return this.addressDAO.ConsultarPorId(id);
        }

        public Email ConsultarPorIdEmail(int id)
        {
            return this.emailDAO.ConsultarPorId(id);
        }

        public Student ConsultarPorIdEstudiante(int id)
        {
            return this.studentDAO.ConsultarPorId(id);
        }

        public Phone ConsultarPorIdTelefono(int id)
        {
            return this.phoneDAO.ConsultarPorId(id);
        }

        public DataTable ConsultarTelefono()
        {
            return this.phoneDAO.Consultar();
        }

        public void EliminarDireccion(int id)
        {
            this.addressDAO.Eliminar(id);
        }

        public void EliminarEmail(int id)
        {
            this.emailDAO.Eliminar(id);
        }

        public void EliminarEstudiante(int id)
        {
            this.studentDAO.Eliminar(id);
        }

        public void EliminarTelefono(int id)
        {
            this.phoneDAO.Eliminar(id);
        }
    }
}
