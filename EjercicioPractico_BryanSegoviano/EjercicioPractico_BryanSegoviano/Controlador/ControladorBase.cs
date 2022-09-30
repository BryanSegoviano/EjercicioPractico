using MySql.Data.MySqlClient;
using System.Data;

namespace Vista.Controlador
{
    internal abstract class ControladorBase<T>
    {
        readonly private string server = "localhost";
        readonly private string user = "root";
        readonly private string password = "1234";
        readonly private string port = "3306";
        readonly private string database = "school";
        protected MySqlConnection ObtenerConexion()
        {
            string conexion = $"Server={server};" +
                $"User={user};" +
                $"Password={password};" +
                $"Port={port};" +
                $"database={database}";
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(conexion);
                return mySqlConnection;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error al iniciar la base de datos");
                throw;
            }
        }

        public abstract void Agregar(T entidad);

        public abstract void Actualizar(T entidad);

        public abstract void Eliminar(int id);

        public abstract DataTable Consultar();

        public abstract T ConsultarPorId(int id);
    }
}
