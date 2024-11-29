using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;

namespace pv.Backend
{
    public class Clients
    {
        private Connection c; 
        public Clients()
        {
            c = new Connection(); 
        }

        // seleccionar clientes
        public List<Client> SelectClients()
        {
            List<Client> clients = new List<Client>();
            try
            {
                // seleccionamos de la tabla clientes todo y cada fila se pasa a una lista
                c.OpenConnection(); 
                string query = "SELECT * FROM clientes"; 
                MySqlCommand cmd = new MySqlCommand(query, c.GetConnection()); 

                MySqlDataReader reader = cmd.ExecuteReader(); 
                while (reader.Read())
                {
                    clients.Add(new Client
                    {
                        Id = reader.GetInt32("id"),
                        Nombre = reader.GetString("nombre"),
                        Telefono = reader.GetString("telefono"),
                        Edad = reader.GetInt32("edad"),
                        Sexo = reader.GetString("sexo")
                    });
                }
                reader.Close(); 
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                // cerrar conexion 
                c.CloseConnection(); 
            }
            return clients; 
        }

        // insertar cliente con store procedure
        public bool InsertClient(string p_nombre, string p_telefono, int p_edad, string p_sexo)
        {
            try
            {
                // preparamos cmd
                c.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("Insertar_Clientes", c.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;

                // le pasamos los parametros al cmd
                cmd.Parameters.AddWithValue("@p_nombre", p_nombre);
                cmd.Parameters.AddWithValue("@p_telefono", p_telefono);
                cmd.Parameters.AddWithValue("@p_edad", p_edad);
                cmd.Parameters.AddWithValue("p_sexo", p_sexo);

                // ejecutamos el store procedure
                cmd.ExecuteNonQuery();
                //Console.WriteLine("Cliente insertado.");
                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
            }
            finally
            {
                // cerramos la coneccion
                c.CloseConnection();
            }
            return false;
        }

        // funcion para validar datos
        public string validar_cliente(string nombre, string telefono, string edad, string sexo)
        {
            try
            {
                // que no haya campos vacios
                if (nombre == "" || telefono == "" || edad == "" || sexo == "")
                {
                    return "Debe llenar todos los campos de texto.";
                }

                // Matches

                // Validación del nombre (solo letras, espacios, tildes y ñ)
                if (!Regex.Match(nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").Success)
                {
                    return "El nombre solo debe contener letras, espacios, tildes y ñ.";
                }

                // Validación del teléfono (solo números)
                if (!Regex.Match(telefono, @"^\d+$").Success)
                {
                    return "El teléfono solo debe contener números.";
                }
                
                // retornamos string que identifica que todo salió bien
                else
                {
                    return "OK";
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                return "Error.";
            }
        }

        // Crear cliente con store procedures
        public bool UpdateClient(int p_id, string p_nombre, string p_telefono, int p_edad, string p_sexo)
        {
            try
            {
                // preparamos el cmd para que ejecute un store procedure
                c.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("Actualizar_Clientes", c.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;

                // le pasamos los parametros
                cmd.Parameters.AddWithValue("@p_id", p_id);
                cmd.Parameters.AddWithValue("@p_nombre", p_nombre);
                cmd.Parameters.AddWithValue("@p_telefono", p_telefono);
                cmd.Parameters.AddWithValue("@p_edad", p_edad);
                cmd.Parameters.AddWithValue("p_sexo", p_sexo);

                // ejecutamos el store procedure
                //cmd.ExecuteNonQuery();
                Console.WriteLine("Cliente insertado.");
                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
            }
            finally
            {
                c.CloseConnection();
            }
            return false;
        }

        // borrar cliente con store procedures
        public bool DeleteClient(int id)
        {
            try
            {
                // preparamos el cmd para ejecutar comandos en forma de store procedures
                c.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("Eliminar_Clientes", c.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@p_id", id);

                // ejecutamos y determinamos si se ha borrado el cliente correctamente
                int rowsAffected = cmd.ExecuteNonQuery(); 
                return rowsAffected > 0; 
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message); 
                return false; 
            }
            finally
            {
                c.CloseConnection();
            }
        }

    }

    // constructor
    public class Client
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
    }
}
