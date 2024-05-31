using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EXAMEN_FINAL_PROGRA.DATA.DATA_ACCES
{
    internal class model

    {
        // Información de conexión a la base de datos
        string connectionString = "Server=localhost;Database=tallermecanico;user=root;Pwd=root";
        MySqlConnection connection;

        //constructor
        public model()

        {
           
            connection = new MySqlConnection(connectionString);
        }

        public bool ProbarConexion()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
       
        public void Insertar(usuarios2 usr)
        {
            try
            {
                string sql = "INSERT INTO SERVICIOS (placa, nombre, marca, dpi, precio, saldo, numero, des, fecha1, fecha2) VALUES (@placa, @nombre, @marca, @dpi, @precio, @saldo, @numero, @des, @fecha1, @fecha2)";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@placa",usr.placa);
                command.Parameters.AddWithValue("@nombre", usr.nombre);
                command.Parameters.AddWithValue("@marca", usr.marca);
                command.Parameters.AddWithValue("@dpi", usr.dpi);
                command.Parameters.AddWithValue("@precio", usr.precio);
                command.Parameters.AddWithValue("@saldo", usr.saldo);
                command.Parameters.AddWithValue("@numero", usr.numero);
                command.Parameters.AddWithValue("@des", usr.des);
                command.Parameters.AddWithValue("@fecha1", usr.fecha1);
                command.Parameters.AddWithValue("@fecha2", usr.fecha2);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception )
            {
                MessageBox.Show("Error al agregar el registro");
            }
            finally
            {
                connection.Close();
            }
        }
        public void Actualizar(usuarios2 usr)
        {
            try
            {
                string sql = "UPDATE SERVICIOS SET placa = @placa, nombre = @nombre, marca = @marca, dpi = @dpi, precio = @precio, saldo = @saldo, numero = @numero, des = @des, fecha1 = @fecha1, fecha2 = @fecha2 WHERE id=@id";

                MySqlCommand comando = new MySqlCommand(sql, connection);
               
                comando.Parameters.AddWithValue("@id", usr.id);
                comando.Parameters.AddWithValue("@placa", usr.placa);
                comando.Parameters.AddWithValue("@nombre", usr.nombre);
                comando.Parameters.AddWithValue("@marca", usr.marca);
                comando.Parameters.AddWithValue("@dpi", usr.dpi);
                comando.Parameters.AddWithValue("@precio", usr.precio);
                comando.Parameters.AddWithValue("@saldo", usr.saldo);
                comando.Parameters.AddWithValue("@numero", usr.numero);
                comando.Parameters.AddWithValue("@des", usr.des);
                comando.Parameters.AddWithValue("@fecha1", usr.fecha1);
                comando.Parameters.AddWithValue("@fecha2",usr.fecha2);
               
                MessageBox.Show("cliente actualizado");

                connection.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception )
            {
                MessageBox.Show("error de actualizacion llene bien los campos ");
            }
            finally
            {
                connection.Close();
            }
        }
      
        public DataTable LeerTodos()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM SERVICIOS";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                connection.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer los registros: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
     
       
        public DataRow LeerPorId(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM SERVICIOS WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                connection.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt.Rows[0];
        }

        public DataTable Buscarfecha(DateTime fecha1)
        {
            DataTable personaje = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Utiliza la función DATE para comparar solo la parte de la fecha
                string sql = "SELECT * FROM SERVICIOS WHERE DATE(fecha1) = @fecha1";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@fecha1", fecha1.Date);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(personaje);
                    }
                }
            }
            return personaje;
        }
        public DataTable Buscarfecha1(DateTime fecha2)
        {
            DataTable personaje = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Utiliza la función DATE para comparar solo la parte de la fecha
                string sql = "SELECT * FROM SERVICIOS WHERE DATE(fecha2) = @fecha2";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@fecha2", fecha2.Date);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(personaje);
                    }
                }
            }
            return personaje;
        }
        public void EliminarPersonaje(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "DELETE FROM SERVICIOS WHERE id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                }
            }
        }
        public DataTable Buscardes(string des)
        {
            DataTable personaje = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM SERVICIOS WHERE des like @des";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@des", "%" + des + "%");

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(personaje);
                    }
                }
            }
            return personaje;
        }
        public DataTable Buscarplaca(string placa)
        {
            DataTable personaje = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM SERVICIOS WHERE placa like @placa";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@placa", "%" + placa + "%");

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(personaje);
                    }
                }
            }
            return personaje;
        }
        public DataTable Buscardpi(string dpi)
        {
            DataTable personaje = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM SERVICIOS WHERE dpi like @dpi";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@dpi", "%" + dpi + "%");

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(personaje);
                    }
                }
            }
            return personaje;
        }
        public DataTable Buscarnombre(string nombre)
        {
            DataTable personaje = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM SERVICIOS WHERE nombre like @nombre";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@nombre", "%" + nombre + "%");

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(personaje);
                    }
                }
            }
            return personaje;
        }


    }
}
