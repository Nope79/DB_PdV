using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace pv.Backend
{
    internal class Employees
    {
        private int id;
        private string nombre;
        private string usuario { get; set; }
        private string pass { get; set; }
        private string correo;
        private string tel;
        private Connection c;
        public Employees()
        {
            c = new Connection();
        }

        // constructor para facilitar el acceso al usuario y contraseña
        public Employees(string Usuario, string Pass)
        {
            usuario = Usuario;
            pass = Pass;
        }

        // validar un login, devuelve un int y un string en forma de tupla, servirá para no malavarear con estos valores mas tarde
        public (int, string) validar_login(string usuario, string pass)
        {
            // se da por hecho que el usuario y contraseña son incorrectos
            string res = "Usuario o contraseña incorrectos.";
            int id = 0;
            try
            {
                // preparamos todo para hacer una consulta con los parametros de la funcion
                string query = "select id, usuario from empleados where usuario = @usuario and contrasena = sha2(@pass, 256)";

                c.OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(query, c.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@pass", pass);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // en caso de tener una fila con la consulta, se actualizan los valores que se retornaran en la funcion
                            id = reader.GetInt32("id");
                            res = reader.GetString("usuario");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
            }

            return (id, res);
        }

        // funcion para seleccionar todos los empleados
        public DataTable select_employees()
        {
            // instanciamos la tabla que se retornara, aqui pondremos los datos de la consulta
            DataTable dataTable = new DataTable();

            try
            {
                // preparamos la consulta y la ejecutamos, para pasar todo a la tabla
                c.OpenConnection();

                string query = "SELECT id, nombre, usuario, correo, telefono FROM empleados";
                using (MySqlCommand command = new MySqlCommand(query, c.GetConnection()))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                //Console.WriteLine("Datos cargados correctamente.");
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
            }
            finally
            {
                // cerramos la conexion
                c.CloseConnection();
            }

            // retornamos los datos de la consulta que se guardaron en la datatable
            return dataTable;
        }

        // insertar empleados mediante transacciones
        public bool insert_employees(string nombre, string usuario, string pass, string correo, string telefono)
        {
            MySqlTransaction tran = null;
            try
            {
                // sintaxis para iniciar una transaccion
                c.OpenConnection();
                tran = c.GetConnection().BeginTransaction();
                MySqlConnection connection = c.GetConnection();
                string query = "insert into empleados(nombre, usuario, contrasena, correo, telefono) values (@nombre, @usuario, sha2(@pass, 256), @correo, @telefono)";

                // pasamos los parametros a una cmd con la consulta y la conexion
                MySqlCommand cmd = new MySqlCommand(query, c.GetConnection());

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@telefono", telefono);

                // ejecutamos
                cmd.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    // en caso de fallar, hacemos un rollback para conservar la concistencia en la base de datos
                    //Console.WriteLine("Transacción no completada. Rollback.");
                    tran.Rollback();
                }
                //Console.WriteLine(ex);
                return false;
            }
            finally
            {
                c.CloseConnection();
            }
        }

        // funcion para validar la insercion de un empleado
        public string validar_insersion(int id, string nombre, string user, string pass, string passc, string correo, string tel)
        {
            try
            {
                // no debe de haber campos de texto vacios
                if (nombre == "" || user == "" || pass == "" || correo == "" || tel == "")
                {
                    return "Debe llenar todos los campos de texto.";
                }

                // verificar la existencia de un usuario con una funcion booleana a la que se le pasa el id y el usuario
                if (user == select_user(user, id))
                {
                    return "Este usuario ya existe.";
                }

                // contraseña vacia
                if (pass != passc)
                {
                    return "Las contraseñas deben coincidir.";
                }

                // Matches

                // Validación del nombre (solo letras, espacios, tildes y ñ)
                if (!Regex.Match(nombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").Success)
                {
                    return "El nombre solo debe contener letras, espacios, tildes y ñ.";
                }

                // Validación de la contraseña (min 8 caracteres, al menos 1 mayúscula, 1 minúscula, 1 número y 1 carácter especial)
                if (!Regex.Match(pass, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$").Success)
                {
                    return "La contraseña debe tener al menos 8 caracteres, incluir mayúsculas, minúsculas, números y caracteres especiales.";
                }

                // Validación del correo
                if (!Regex.Match(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$").Success)
                {
                    return "El correo no tiene un formato válido.";
                }

                // Validación del teléfono (solo números)
                if (!Regex.Match(tel, @"^\d+$").Success)
                {
                    return "El teléfono solo debe contener números.";
                }

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

        // funcion para actualizar empleados
        public bool update_employees(int id, string nombre, string usuario, string pass, string correo, string telefono)
        {
            // vamos preparando variables y objetos
            MySqlTransaction tran = null;
            bool res = true;
            string query = "update empleados set nombre = @nombre, usuario = @usuario, contrasena = sha2(@pass, 256), correo = @correo, telefono = @telefono where id = @id";

            try
            {
                // empezamos la transaccion
                c.OpenConnection();
                tran = c.GetConnection().BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand(query, c.GetConnection()))
                {
                    // añadimos los parametros
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    int filas = cmd.ExecuteNonQuery();
                    res = filas > 0;
                }

                // le damos commit a la transaccion para guardar los datos
                tran.Commit();
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    // en caso de tener fallos, hacemos un rollback
                    //Console.WriteLine("Transacción no completada. Rollback.");
                    tran.Rollback();
                }
                //Console.WriteLine(ex);
                res = false;
            }
            finally
            {
                // cerramos la conexion
                c.CloseConnection();
            }

            return res;
        }

        // funcion para borrar los empleados
        public bool delete_employees(int id)
        {
            // preparamos todo
            MySqlTransaction tran = null;
            bool res = true;
            string query = "delete from empleados where id = @id";

            try
            {
                // abrimos la conexion y empezamos la transaccion
                c.OpenConnection();
                tran = c.GetConnection().BeginTransaction();
                using (MySqlCommand cmd = new MySqlCommand(query, c.GetConnection()))
                {
                    // añadimos los parametros y ejecutamos la consulta, si se devuelve algo, existe el usuario a eliminar
                    cmd.Parameters.AddWithValue("@id", id);
                    int filas = cmd.ExecuteNonQuery();
                    res = filas > 0;
                }

                // hacemos un commit
                tran.Commit();
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    // en caso de tener errores, hacemos rollback
                    //Console.WriteLine("Transacción no completada. Rollback.");
                    tran.Rollback();
                }
                //Console.WriteLine(ex);
                res = false;
            }
            finally
            {
                // cerramos la conexion
                c.CloseConnection();
            }

            return res;
        }

        // funcion para seleccionar un usuario, usada en diferentes forms, ademas de que se usa tambien para saber si un usuario existe
        public string select_user(string usuario, int id)
        {
            string u = null;
            string query = "select usuario from empleados where usuario = @usuario and id != @id";

            try
            {
                // preparamos la consulta y la hacemos
                c.OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(query, c.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@id", id);

                    var resultado = cmd.ExecuteScalar();
                    if (resultado != null)
                    {
                        u = resultado.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
            }
            finally
            {
                // cerrar la conexion
                c.CloseConnection();
            }

            return u;
        }
    }
}
