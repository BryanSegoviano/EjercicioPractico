using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accesoDatos
{
    public interface IFachada
    {
        //Estudiante
        public abstract void AgregarEstudiante(Student entidad);
        public abstract void ActualizarEstudiante(Student entidad);
        public abstract void EliminarEstudiante(int id);
        public abstract DataTable ConsultarEstudiante();
        public abstract Student ConsultarPorIdEstudiante(int id);
        //Telefono
        public abstract void AgregarTelefono(Phone entidad);
        public abstract void ActualizarTelefono(Phone entidad);
        public abstract void EliminarTelefono(int id);
        public abstract DataTable ConsultarTelefono();
        public abstract Phone ConsultarPorIdTelefono(int id);
        //Email
        public abstract void AgregarEmail(Email entidad);
        public abstract void ActualizarEmail(Email entidad);
        public abstract void EliminarEmail(int id);
        public abstract DataTable ConsultarEmail();
        public abstract Email ConsultarPorIdEmail(int id);
        //Direccion
        public abstract void AgregarDireccion(Address entidad);
        public abstract void ActualizarDireccion(Address entidad);
        public abstract void EliminarDireccion(int id);
        public abstract DataTable ConsultarDireccion();
        public abstract Address ConsultarPorIdDireccion(int id);
    }
}
