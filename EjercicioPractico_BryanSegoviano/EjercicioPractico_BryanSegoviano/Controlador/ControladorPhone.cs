using MySql.Data.MySqlClient;
using System.Data;
using Vista.Modelo;

namespace Vista.Controlador
{
    internal class ControladorPhone : ControladorBase<Phone>
    {
        public override void Agregar(Phone telefono)
        {
            MySqlConnection conexion = this.ObtenerConexion();
            try
            {
                conexion.Open();
                string query = $"INSERT INTO phones " +
                    $"(student_id, phone) " +
                    $"VALUES ('{telefono.StudentId}', '{telefono.PhoneNumber}')";

                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error al registrar el teléfono.");
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        public override void Actualizar(Phone telefono)
        {
            MySqlConnection conexion = this.ObtenerConexion();
            try
            {
                conexion.Open();
                string query = $"UPDATE phones SET phone = '{telefono.PhoneNumber}' " +
                    $"WHERE (student_id = '{telefono.StudentId}')";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error al modificar el teléfono.");
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        public override void Eliminar(int id)
        {
            MySqlConnection conexion = this.ObtenerConexion();
            try
            {
                conexion.Open();
                string query = $"DELETE FROM phones WHERE student_id = {id}";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error al eliminar el teléfono.");
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        public override DataTable Consultar()
        {
            throw new NotImplementedException();
        }

        public override Phone ConsultarPorId(int id)
        {
            MySqlConnection conexion = this.ObtenerConexion();
            try
            {
                conexion.Open();
                string query = $"(SELECT phone_id, student_id, phone FROM phones WHERE student_id = {id})";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                MySqlDataReader mySqlDataReader = comando.ExecuteReader();
                Phone telefono = new Phone();
                if (mySqlDataReader.HasRows)
                {
                    while (mySqlDataReader.Read())
                    {
                        telefono.PhoneId = Int32.Parse(mySqlDataReader.GetString(0));
                        telefono.StudentId = Int32.Parse(mySqlDataReader.GetString(1));
                        telefono.PhoneNumber = mySqlDataReader.GetString(2);
                    }
                }
                conexion.Close();
                return telefono;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error al obtener el teléfono mediante su ID.");
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
