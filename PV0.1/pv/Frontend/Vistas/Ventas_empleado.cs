// importacion de librerias necesarias para mysql y manejo de datos
using MySql.Data.MySqlClient;
using pv.Backend;
using System;
using System.Data;
using System.Windows.Forms;

namespace pv.Frontend.Vistas
{
    // formulario para visualizar las ventas por empleado
    public partial class Ventas_empleado : Form
    {
        private Connection c; // objeto de conexion a la base de datos

        public Ventas_empleado()
        {
            InitializeComponent(); // inicializacion del formulario
            c = new Connection(); // inicializacion de la conexion
        }

        // evento de carga del formulario
        private void Ventas_empleado_Load(object sender, EventArgs e)
        {
            CargarReporteVentasEmpleado(); // carga el reporte de ventas por empleado
        }

        // metodo para cargar el reporte de ventas por empleado
        private void CargarReporteVentasEmpleado()
        {
            try
            {
                c.OpenConnection(); // abre la conexion a la base de datos

                // consulta sql para obtener las ventas por empleado
                string query = "SELECT * FROM ventas_por_empleado";
                MySqlCommand cmd = new MySqlCommand(query, c.GetConnection()); // crea el comando con la consulta
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd); // adaptador para llenar el DataTable

                DataTable dt = new DataTable(); // tabla para almacenar los datos
                adapter.Fill(dt); // llena el DataTable con los datos de la consulta
                dgvVentasEmpleado.DataSource = dt; // asigna el DataTable al DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las ventas por empleado."); // muestra mensaje de error si ocurre una excepcion
            }
            finally
            {
                c.CloseConnection(); // cierra la conexion a la base de datos
            }
        }

        // evento asociado al boton de retroceso, regresa al formulario principal
        private void btnback_Click(object sender, EventArgs e)
        {
            main m = new main(); // instancia del formulario principal
            this.Hide(); // oculta el formulario actual
            m.Show(); // muestra el formulario principal
        }
    }
}
