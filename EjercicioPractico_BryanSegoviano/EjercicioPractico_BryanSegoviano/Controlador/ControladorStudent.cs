using MySql.Data.MySqlClient;
using System.Data;
using Vista.Modelo;

namespace Vista.Controlador
{
    internal class ControladorStudent : ControladorBase<Student>
    {
        readonly private ControladorPhone controladorTelefono = new ControladorPhone();
        readonly private ControladorEmail controladorEmail = new ControladorEmail();
        readonly private ControladorAddress controladorAddress = new ControladorAddress();

        public override void Agregar(Student estudiante)
        {
            MySqlConnection conexion = this.ObtenerConexion();
            try
            {
                conexion.Open();
                string fechaCreacionFormato = estudiante.CreatedOn.ToString("yyyy-MM-dd HH:mm:ss");
                string fechaActualizacionFormato = estudiante.UpdatedOn.ToString("yyyy-MM-dd HH:mm:ss");
                string query = $"INSERT INTO students " +
                    $"(name, last_name, created_on, updated_on) " +
                    $"VALUES ('{estudiante.Name}', '{estudiante.LastName}', " +
                    $"'{fechaCreacionFormato}', '{fechaActualizacionFormato}')";

                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.ExecuteNonQuery();
                int estudianteID = Convert.ToInt32(comando.LastInsertedId);
                //Elementos asociados
                Phone phone = new Phone(estudianteID, estudiante.Phone.PhoneNumber);
                controladorTelefono.Agregar(phone);
                Email email = new Email(estudianteID, estudiante.Email.EmailStudent);
                controladorEmail.Agregar(email);
                Address address = new Address(estudianteID, estudiante.Address.AddressInf,
                    estudiante.Address.City, estudiante.Address.ZipCode, estudiante.Address.State);
                controladorAddress.Agregar(address);
                //
                MessageBox.Show($"El estudiante {estudiante.Name} fue agregado correctamente."
                    , "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error al registrar un nuevo estudiante.");
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        public override void Actualizar(Student estudiante)
        {
            MySqlConnection conexion = this.ObtenerConexion();
            try
            {
                conexion.Open();
                string query = $"UPDATE students SET name = '{estudiante.Name}'," +
                    $" last_name = '{estudiante.LastName}'," +
                    $" updated_on = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' " +
                    $"WHERE (student_id = '{estudiante.StudentId}')";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.ExecuteNonQuery();
                this.controladorTelefono.Actualizar(estudiante.Phone);
                this.controladorEmail.Actualizar(estudiante.Email);
                this.controladorAddress.Actualizar(estudiante.Address);
                MessageBox.Show($"Los datos del estudiante {estudiante.Name} se modificaron correctamente."
                    , "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error al modificar el estudiante.");
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
                this.controladorTelefono.Eliminar(id);
                this.controladorEmail.Eliminar(id);
                this.controladorAddress.Eliminar(id);
                conexion.Open();
                string query = $"DELETE FROM students WHERE student_id = {id}";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error al eliminar el estudiante");
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        public override DataTable Consultar()
        {
            MySqlConnection conexion = this.ObtenerConexion();
            try
            {
                conexion.Open();
                string query = "(SELECT * FROM students LIMIT 50)";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                //comando.ExecuteNonQuery();
                DataTable listaEstudiantes = new DataTable();
                adaptador.Fill(listaEstudiantes);
                conexion.Close();
                return listaEstudiantes;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error al obtener todos los estudiantes.");
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        public override Student ConsultarPorId(int id)
        {
            MySqlConnection conexion = this.ObtenerConexion();
            try
            {
                conexion.Open();
                string query = $"(SELECT student_id, name, last_name, created_on, updated_on" +
                    $" FROM students " +
                    $"WHERE student_id = {id})";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                MySqlDataReader mySqlDataReader = comando.ExecuteReader();
                Student estudiante = new Student();
                if (mySqlDataReader.HasRows)
                {
                    while (mySqlDataReader.Read())
                    {
                        estudiante.StudentId = int.Parse(mySqlDataReader.GetString(0));
                        estudiante.Name = mySqlDataReader.GetString(1);
                        estudiante.LastName = mySqlDataReader.GetString(2);
                        estudiante.CreatedOn = DateTime.Parse(mySqlDataReader.GetString(3));
                        estudiante.UpdatedOn = DateTime.Parse(mySqlDataReader.GetString(4));
                    }
                }
                estudiante.Phone = this.controladorTelefono.ConsultarPorId(id);
                estudiante.Email = this.controladorEmail.ConsultarPorId(id);
                estudiante.Address = this.controladorAddress.ConsultarPorId(id);
                conexion.Close();
                return estudiante;
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error al obtener el estudiante mediante su ID.");
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
