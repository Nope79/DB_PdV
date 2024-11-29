using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace pv.Backend
{
    internal class Productos
    {
        private int id;
        private string nombre;
        private double precio;
        private double iva;
        private int stock;
        private string marca;
        private string descripcion;
        private double peso;
        private string cod;
        private Connection c;

        public Productos()
        {
            c = new Connection();
        }
        
        // funcion para seleccionar un producto segun su codigo de barras
        public DataRow select_productos(string cod)
        {
            // elegimos un datarow y datatable porque es muy comodo trabajar con estas estructuras de datos al usar datagreedview
            DataRow row = null;
            DataTable table = new DataTable();

            try
            {
                // preparamos todo para hacer la consulta
                c.OpenConnection();
                string query = "select id, nombre, precio, 1 as cantidad, (precio * 1) as subtotal, iva, round((precio * iva / 100), 2) as impuesto, cod from productos where cod = @cod";

                using (MySqlCommand command = new MySqlCommand(query, c.GetConnection()))
                {
                    command.Parameters.AddWithValue("@cod", cod);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }

                // en caso de que haya una fila, la retornamos
                if (table.Rows.Count > 0)
                {
                    row = table.Rows[0];
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error al obtener el producto: " + ex.Message);
            }
            finally
            {
                // cerrar conexion
                c.CloseConnection();
            }

            return row;
        }

        // seleccionamos todos los productos
        public DataTable select_productos()
        {
            // instanciamos un datatable para guardar los datos de la consulta
            DataTable dataTable = new DataTable();

            try
            {
                // abrimos la conexion, hacemos la consulta y se llena el datatable con todo lo que se obtenga
                c.OpenConnection();

                string query = "SELECT * FROM productos";
                using (MySqlCommand command = new MySqlCommand(query, c.GetConnection()))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error al obtener los productos: " + ex.Message);
            }
            finally
            {
                // cerrar conexion
                c.CloseConnection();
            }

            return dataTable;
        }

        // funcion para insertar los productos mediante transacciones
        public void insert_productos(string nombre, double precio, double iva, int stock, string marca, string descripcion, double peso, string cod)
        {
            MySqlTransaction tran = null;
            try
            {
                // abrimos la conexion e iniciamos la transaccion
                c.OpenConnection();
                tran = c.GetConnection().BeginTransaction();

                string query = "Insert into productos(nombre, precio, iva, stock, marca, descripcion, peso, cod) values (@nombre, @precio, @iva, @stock, @marca, @descripcion, @peso, @cod)";

                MySqlCommand cmd = new MySqlCommand(query, c.GetConnection());
                cmd.Transaction = tran;

                // le pasamos los parametros a la cmd que configuramos anteriormente
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@iva", iva);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@marca", marca);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@peso", peso);
                cmd.Parameters.AddWithValue("@cod", cod);

                // ejecutamos y hacemos un commit
                cmd.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    // en caso de un error, hacemos rollback
                    tran.Rollback();
                }
                //Console.WriteLine("Error en la inserción: " + ex.Message);
            }
            finally
            {
                // cerramos la conexion
                c.CloseConnection();
            }
        }

        // funcion para validar la insercion de un producto
        public string validar_insersion(int id, string nombre, string precio, string iva, string stock, string marca, string descripcion, string peso, string cod)
        {
            // verificamos que todos los datos excepto el codigo no sea null
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(precio) || string.IsNullOrEmpty(iva) || string.IsNullOrEmpty(stock) || string.IsNullOrEmpty(marca) || string.IsNullOrEmpty(descripcion) || string.IsNullOrEmpty(peso))
            {
                return "Debe llenar todos los campos de texto.";
            }

            // verificamos que exista un producto 
            if (nombre == select_product(nombre, id))
            {
                return "Este producto ya existe.";
            }

            // precio (dos decimales)
            if (!Regex.Match(precio, @"^\d+(\.\d{2})$").Success)
            {
                return "El precio solo debe contener números con dos decimales (por ejemplo, 123.45).";
            }

            // iva (dos decimales)
            if (!Regex.Match(iva, @"^\d+(\.\d{2})$").Success)
            {
                return "El iva solo debe contener números con dos decimales (por ejemplo, 12.45).";
            }

            // stock (solo números)
            if (!Regex.Match(stock, @"^\d+$").Success)
            {
                return "El stock solo debe contener números.";
            }

            // descripción (solo letras, espacios, tildes y ñ)
            if (!Regex.Match(descripcion, @"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ\s.,!?\-():]+$").Success)
            {
                return "La descripción solo debe contener letras, números, espacios, tildes y ñ.";
            }

            // peso (tres decimales)
            if (!Regex.Match(peso, @"^\d+(\.\d{3})$").Success)
            {
                return "El peso solo debe contener números con tres decimales (por ejemplo, 123.456).";
            }

            // string vacio o que tenga entre 8 y 13 caracteres
            if (!Regex.Match(cod, @"^[a-zA-Z0-9]{8,13}$").Success && cod != "")
            {
                MessageBox.Show("El código debe contener entre 8 y 13 caracteres alfanuméricos o estar vacío.");
            }

            return "OK";
        }

        // funcion para actualizar los productos mediante transacciones
        public bool update_productos(int id, string nombre, double precio, double iva, int stock, string marca, string descripcion, double peso, string cod)
        {
            // preparamos la consulta y el objeto transaccion
            bool res = true;
            string query = "UPDATE productos SET nombre = @nombre, precio = @precio, iva = @iva, stock = @stock, marca = @marca, descripcion = @descripcion, peso = @peso, cod = @cod where id = @id";
            MySqlTransaction tran = null;

            try
            {
                // abrimos la conexion, iniciamos la transaccion y le pasamos los parametros a la cmd generada 
                c.OpenConnection();
                tran = c.GetConnection().BeginTransaction();

                using (MySqlCommand cmd = new MySqlCommand(query, c.GetConnection()))
                {
                    cmd.Transaction = tran;

                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@iva", iva);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@marca", marca);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@peso", peso);
                    cmd.Parameters.AddWithValue("@cod", cod);

                    // ejecutamos y asignamos a la variable booleana el resultado de si hay o no filas
                    int filas = cmd.ExecuteNonQuery();
                    res = filas > 0;
                }

                // hacemos commit
                tran.Commit();
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    // en caso de errores, hacemos rollback
                    tran.Rollback();
                }
                //Console.WriteLine("Error en la actualización: " + ex.Message);
                res = false;
            }
            finally
            {
                // cerramos la conexion
                c.CloseConnection();
            }

            return res;
        }

        // borrar productos con transacciones
        public bool delete_productos(int id)
        {
            // preparamos todo
            bool res = true;
            string query = "delete from productos where id = @id";
            MySqlTransaction tran = null;

            try
            {
                // abrimos la conexion y empezamos la transaccion
                c.OpenConnection();
                tran = c.GetConnection().BeginTransaction();

                using (MySqlCommand cmd = new MySqlCommand(query, c.GetConnection()))
                {
                    cmd.Transaction = tran;

                    // añadimos los parametros al cmd y ejecutamos la consulta, se verifica si se ha hecho o no el delete
                    cmd.Parameters.AddWithValue("@id", id);
                    int filas = cmd.ExecuteNonQuery();
                    res = filas > 0;
                }

                // hacemos el commit
                tran.Commit();
            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    // hacemos el rollback si hay erroes
                    tran.Rollback();
                }
                //Console.WriteLine("Error en la eliminación: " + ex.Message);
                res = false;
            }
            finally
            {
                // cerramos la conexion
                c.CloseConnection();
            }

            return res;
        }

        // funcion para seleccionar un producto segun su nombre e id, se usará en los forms de apoyo para diversas cosas, como comprobar que existe un producto
        public string select_product(string nombre, int id)
        {
            string u = null;
            string query = "select nombre from productos where nombre = @nombre and id != @id";

            try
            {

                // abrimos la conexion, preparamos el cmd y se ejecuta la consulta
                c.OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(query, c.GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@id", id);

                    var resultado = cmd.ExecuteScalar();

                    // en caso de que se haya encontrado un resultado, asignamos el string u al resultado obtenido
                    if (resultado != null)
                    {
                        u = resultado.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error al buscar el producto: " + ex.Message);
            }
            finally
            {
                // cerramos la conexion
                c.CloseConnection();
            }

            return u;
        }
    }
}
