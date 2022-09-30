using MySql.Data.MySqlClient;
using System.Data;
using Dominio;

namespace accesoDatos
{
    public class AddressDAO : BaseDAO<Address>
    {
        public override void Agregar(Address address)
        {
            MySqlConnection conexion = this.ObtenerConexion();
            try
            {
                conexion.Open();
                string query = $"INSERT INTO addresses " +
                $"(student_id, address, city, zip_code, state) " +
                    $"VALUES ('{address.StudentId}', '{address.AddressInf}', " +
                    $"'{address.City}', '{address.ZipCode}', '{address.State}')";

                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error al registrar la dirección.");
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        public override void Actualizar(Address direccion)
        {
            MySqlConnection conexion = this.ObtenerConexion();
            try
            {
                conexion.Open();
                string query = $"UPDATE addresses SET address = '{direccion.AddressInf}'," +
                    $" city= '{direccion.City}'," +
                    $" zip_code = '{direccion.ZipCode}'," +
                    $" state = '{direccion.State}'" +
                    $"WHERE (student_id = '{direccion.StudentId}')";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error al modificar la dirección.");
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
                string query = $"DELETE FROM addresses WHERE student_id = {id}";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error al eliminar la dirección.");
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

        public override Address ConsultarPorId(int id)
        {
            MySqlConnection conexion = this.ObtenerConexion();
            try
            {
                conexion.Open();
                string query = $"(SELECT address_id, student_id, address, city, zip_code, state FROM addresses WHERE student_id = {id})";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                MySqlDataReader mySqlDataReader = comando.ExecuteReader();
                Address address = new Address();
                if (mySqlDataReader.HasRows)
                {
                    while (mySqlDataReader.Read())
                    {
                        address.AddressId = int.Parse(mySqlDataReader.GetString(0));
                        address.StudentId = int.Parse(mySqlDataReader.GetString(1));
                        address.AddressInf = mySqlDataReader.GetString(2);
                        address.City = mySqlDataReader.GetString(3);
                        address.ZipCode = int.Parse(mySqlDataReader.GetString(4));
                        address.State = mySqlDataReader.GetString(5);
                    }
                }
                conexion.Close();
                return address;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error al obtener la dirección mediante su ID.");
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
