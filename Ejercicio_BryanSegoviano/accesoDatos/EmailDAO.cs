using MySql.Data.MySqlClient;
using System.Data;
using Dominio;

namespace accesoDatos
{
    public class EmailDAO : BaseDAO<Email>
    {
        public override void Agregar(Email email)
        {
            MySqlConnection conexion = this.ObtenerConexion();
            try
            {
                conexion.Open();
                string query = $"INSERT INTO emails " +
                    $"(student_id, email) " +
                    $"VALUES ('{email.StudentId}', '{email.EmailStudent}')";

                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error al registrar el email.");
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        public override void Actualizar(Email email)
        {
            MySqlConnection conexion = this.ObtenerConexion();
            try
            {
                conexion.Open();
                string query = $"UPDATE emails SET email = '{email.EmailStudent}' " +
                    $"WHERE (student_id = '{email.StudentId}')";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error al modificar el email.");
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
                string query = $"DELETE FROM emails WHERE student_id = {id}";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error al eliminar el email.");
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

        public override Email ConsultarPorId(int id)
        {
            MySqlConnection conexion = this.ObtenerConexion();
            try
            {
                conexion.Open();
                string query = $"(SELECT email_id, student_id, email FROM emails WHERE student_id = {id})";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                MySqlDataReader mySqlDataReader = comando.ExecuteReader();
                Email email = new Email();
                if (mySqlDataReader.HasRows)
                {
                    while (mySqlDataReader.Read())
                    {
                        email.EmailId = int.Parse(mySqlDataReader.GetString(0));
                        email.StudentId = int.Parse(mySqlDataReader.GetString(1));
                        email.EmailStudent = mySqlDataReader.GetString(2);
                    }
                }
                conexion.Close();
                return email;
            }
            catch
            {
                MessageBox.Show("Error al obtener el email mediante su ID.");
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
