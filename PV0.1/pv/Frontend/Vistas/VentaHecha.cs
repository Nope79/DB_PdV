// importacion de librerias necesarias para mysql y manejo de datos
using MySql.Data.MySqlClient;
using pv.Backend;
using System;
using System.Data;
using System.Windows.Forms;

namespace pv.Frontend.Vistas
{
    // formulario para mostrar los detalles de una venta hecha
    public partial class VentaHecha : Form
    {
        private Connection c = new Connection(); // conexion a la base de datos
        private string idVenta; // variable para almacenar el id de la venta

        public VentaHecha()
        {
            InitializeComponent(); // inicializacion del formulario
        }

        // evento del boton de retroceso, regresa al formulario principal
        private void btnback_Click(object sender, EventArgs e)
        {
            main m = new main(); // instancia del formulario principal
            m.Show(); // muestra el formulario principal
            this.Hide(); // oculta el formulario actual
        }

        // evento de carga del formulario, no se usa pero esta preparado para futuras modificaciones
        private void VentaHecha_Load(object sender, EventArgs e)
        {
        }

        // metodo para cargar los datos de la venta según el idVenta
        private void CargarDatos()
        {
            try
            {
                // validación de que el id de venta no esté vacío
                if (string.IsNullOrEmpty(idVenta))
                {
                    MessageBox.Show("Por favor, ingresa un ID de venta.");
                    return;
                }

                // consulta sql para obtener los detalles de la venta
                string query = @"
                            SELECT 
                            v.id AS id_venta,
                            e.id AS id_empleado,
                            p.id AS id_producto,
                            p.nombre AS producto,
                            p.marca AS marca,
                            dv.precio_unitario,
                            dv.cantidad_producto
                            FROM ventas v
                            JOIN detalles_venta dv ON v.id = dv.id_venta
                            JOIN empleados e ON v.id_empleado = e.id
                            JOIN productos p ON dv.id_producto = p.id
                            WHERE v.id = @idVenta";

                c.OpenConnection(); // abre la conexion a la base de datos

                // ejecuta la consulta y obtiene los resultados
                using (MySqlCommand command = new MySqlCommand(query, c.GetConnection()))
                {
                    command.Parameters.AddWithValue("@idVenta", int.Parse(idVenta)); // pasa el idVenta como parametro

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable table = new DataTable(); // crea un DataTable para almacenar los resultados
                        adapter.Fill(table); // llena el DataTable con los datos obtenidos
                        dtticket.DataSource = table; // asigna el DataTable al DataGridView
                    }
                }

                dtticket.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // ajusta el tamaño de las columnas

                // muestra un mensaje si no se encuentran resultados para el ID de venta ingresado
                if (dtticket.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron datos para este ID de venta.");
                }
            }
            catch (FormatException ex)
            {
                // maneja excepciones si el formato del idVenta no es válido
                MessageBox.Show("El ID de la venta debe ser un número válido.");
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                // maneja cualquier otra excepción
                Console.WriteLine(ex);
                MessageBox.Show($"Ocurrió un error al cargar los datos: {ex.Message}");
            }
        }

        // evento al seleccionar una opción del ComboBox
        private void cbopcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            // muestra o oculta el campo para ingresar el ID según la opción seleccionada
            if (cbopcion.SelectedItem == "Fecha")
            {
                tbid.Visible = false; // oculta el campo ID
            }
            else if (cbopcion.SelectedItem == "ID")
            {
                tbid.Visible = true; // muestra el campo ID
            }
            else
            {
                tbid.Visible = false; // oculta el campo ID para otras opciones
            }
        }

        // evento cuando el texto del TextBox del ID cambia
        private void tbid_TextChanged(object sender, EventArgs e)
        {
            idVenta = tbid.Text; // guarda el valor del ID de venta
            CargarDatos(); // carga los datos correspondientes al ID de venta
        }
    }
}
