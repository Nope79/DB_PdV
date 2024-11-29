using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace pv.Backend
{
    public class Venta
    {
        private int id;
        private int id_empleado;
        private string fecha;
        private string descripcion;
        private string met_pago;
        private double importe;
        private double subtotal;
        private double iva;
        private double total;
        private Connection c;

        public Venta()
        {
            c = new Connection();
        }

        public Venta(string met_pago, double importe, double subtotal, double total)
        {
            this.met_pago = met_pago;
            this.importe = importe;
            this.subtotal = subtotal;
            this.total = total;
            c = new Connection();
        }


        // metodo para guardar datos en las tablas ventas y detalles_venta
        public bool GuardarVentaConDetalles(DataGridView dtVenta, Venta venta, string id_cliente)
        {
            bool x = false;
            MySqlTransaction transaction = null;
            try
            {
                // estas son variables que se guardan en la aplicacion, usadas para no pasarlas como argumentos entre forms ni usar clases estáticas
                var xid = Application.UserAppDataRegistry.GetValue("ID");
                var xuser = Application.UserAppDataRegistry.GetValue("User");
                venta.id_empleado = Convert.ToInt32(xid);

                // abrimos la conexion y hacemos el begin
                c.OpenConnection();
                transaction = c.GetConnection().BeginTransaction();

                // esta consulta inserta los valores en la tabla ventas, preparamos la consulta, el cmd y ejecutamos la consulta
                string queryVenta = @"INSERT INTO ventas (id_empleado, id_cliente, importe, subtotal, total, metodo_pago, descripcion) 
                                  VALUES (@idEmpleado, @idCliente, @importe, @subtotal, @total, @metodoPago, '')";
                int idVenta;
                using (MySqlCommand cmdVenta = new MySqlCommand(queryVenta, c.GetConnection(), transaction))
                {
                    cmdVenta.Parameters.AddWithValue("@idEmpleado", venta.id_empleado);
                    cmdVenta.Parameters.AddWithValue("@idCliente", id_cliente);
                    cmdVenta.Parameters.AddWithValue("@importe", venta.importe);
                    cmdVenta.Parameters.AddWithValue("@subtotal", venta.subtotal);
                    cmdVenta.Parameters.AddWithValue("@total", venta.total);
                    cmdVenta.Parameters.AddWithValue("@metodoPago", venta.met_pago);

                    cmdVenta.ExecuteNonQuery();

                    // guardamos el valor insertado para la siguiente consulta
                    idVenta = (int)cmdVenta.LastInsertedId;
                }

                // de toda la datagreedview, vamos a seleccionar sus filas y las vamos a insertar una a una en un for each
                foreach (DataGridViewRow row in dtVenta.Rows)
                {
                    // mientras no lleguemos al final de la dgv, hacemos la consulta, preparando los valores a insertar y la consola, para 
                    // realizar la ejecucion de la consulta
                    if (row.Cells["ID"].Value != null)
                    {
                        int idProducto = Convert.ToInt32(row.Cells["ID"].Value);
                        int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                        double precio = Convert.ToDouble(row.Cells["PrecioU"].Value);

                        string queryDetalles = @"INSERT INTO detalles_venta 
                                              (id_venta, id_producto, cantidad_producto, precio_unitario) 
                                              VALUES (@idVenta, @idProducto, @cantidad, @precio)";

                        using (MySqlCommand cmdDetalles = new MySqlCommand(queryDetalles, c.GetConnection(), transaction))
                        {
                            cmdDetalles.Parameters.AddWithValue("@idVenta", idVenta);
                            cmdDetalles.Parameters.AddWithValue("@idProducto", idProducto);
                            cmdDetalles.Parameters.AddWithValue("@cantidad", cantidad);
                            cmdDetalles.Parameters.AddWithValue("@precio", precio);

                            cmdDetalles.ExecuteNonQuery();
                        }
                    }
                }

                // solo se hace commit si no han habido problemas con ninguna de las dos consultas anteriores
                transaction.Commit();

                // se da visto bueno y se ejecuta la funcion que genera los tickets
                x = true;
                GenTicket g = new GenTicket();
                g.GenerarRecibo(idVenta);
                Console.WriteLine("Venta y detalles registrados correctamente.");
            }
            catch (Exception ex)
            {
                // en caso de erroes, se hace rollback
                transaction?.Rollback();
                //Console.WriteLine("Error al registrar la venta y los detalles: " + ex.Message);
            }
            finally
            {
                // cerramos la conexion
                c.CloseConnection();
            }

            return x;
        }

        // funcion para seleccionar ventas por el mes
        public DataTable select_ventas_fecha(DateTime startDate, DateTime endDate)
        {
            // preparamos la consulta y la tabla donde se guardaran los datos
            string query = @"
                    SELECT * from ventas
                    WHERE fecha BETWEEN @startDate AND @endDate";

            DataTable tabla = new DataTable();
            try
            {
                // abrimos la conexion y le pasamos los parametros al cmd, luego ejecutamos y llenamos la tabla
                c.OpenConnection();
                using (var command = new MySqlCommand(query, c.GetConnection()))
                {
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);

                    using (var adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(tabla);
                    }
                }
            }
            catch(Exception ex)
            {
                //Console.WriteLine(ex);
            }
            finally
            {
                // cerramos la conexion
                c.CloseConnection();
            }

            return tabla;
        }

        // seleccionamos un producto por su id
        public int productos_por_venta(int folio)
        {
            try
            {
                // aabrimos la conexion, preparamos el cmd y ejecutamos, retornamos lo que se obtenga, o un 0 (no hay id 0, sirve para verificar si existe un producto)
                c.OpenConnection();

                string query = "select detalles_productos_dv(@id)";
                MySqlCommand cmd = new MySqlCommand(query, c.GetConnection());

                cmd.Parameters.AddWithValue("@id", folio);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                return 0; 
            }
            finally
            {
                // cerramos la conexion
                c.CloseConnection();
            }
        }

        // funcion para seleccionar todas las ventas
        public DataTable select_ventas()
        {
            // datatable para guardar los datos de la consulta
            DataTable dataTable = new DataTable();

            try
            {
                // abrimos la conexion, y llenamos la datatable
                c.OpenConnection();

                string query = "SELECT * FROM ventas";
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
                //MessageBox.Show("" + ex);
            }
            finally
            {
                // cerramos la conexion
                c.CloseConnection();
            }
            return dataTable;
        }
    }
}
