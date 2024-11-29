// importacion de librerias necesarias para mysql y manejo de datos
using MySql.Data.MySqlClient;
using pv.Backend;
using System;
using System.Data;
using System.Windows.Forms;

namespace pv.Frontend.Vistas
{
    // formulario para visualizar las ventas por mes
    public partial class Ventas_Mes : Form
    {
        private Connection c; // objeto de conexion a la base de datos

        public Ventas_Mes()
        {
            InitializeComponent();
            c = new Connection(); // inicializacion de la conexion
        }

        // evento asociado al boton para regresar al formulario principal
        private void button1_Click(object sender, EventArgs e)
        {
            main m = new main(); // instancia del formulario principal
            this.Hide(); // oculta el formulario actual
            m.Show(); // muestra el formulario principal
        }

        // evento de carga del formulario
        private void Ventas_Mes_Load(object sender, EventArgs e)
        {
        }

        // metodo para cargar el reporte de ventas por mes y anio
        private void CargarReporteVentas(int mesSeleccionado, string year)
        {
            try
            {
                c.OpenConnection(); // abre la conexion a la base de datos

                // consulta sql para obtener las ventas del mes y anio seleccionados
                string query = "SELECT * FROM reporte_ventas_mes_anio WHERE MONTH(fecha) = @mes and year(fecha) = @year";

                MySqlCommand cmd = new MySqlCommand(query, c.GetConnection()); // crea el comando con la consulta
                cmd.Parameters.AddWithValue("@mes", mesSeleccionado); // agrega parametro para el mes
                cmd.Parameters.AddWithValue("@year", year); // agrega parametro para el anio
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd); // adaptador para llenar el DataTable

                DataTable dt = new DataTable(); // tabla para almacenar los datos
                adapter.Fill(dt); // llena el DataTable con los datos de la consulta
                dtmes.DataSource = dt; // asigna el DataTable al DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar las ventas por mes."); // muestra mensaje de error si ocurre una excepcion
            }
            finally
            {
                c.CloseConnection(); // cierra la conexion a la base de datos
            }
        }

        // evento cuando se selecciona un mes en el comboBox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // si los dos valores (anio y mes) estan seleccionados
            if (cbanio.SelectedIndex != -1 && cbmes.SelectedIndex != -1)
            {
                int mesSeleccionado = ObtenerNumeroMes(cbmes.Text); // obtiene el numero del mes seleccionado
                string anio = cbanio.SelectedItem.ToString(); // obtiene el anio seleccionado
                CargarReporteVentas(mesSeleccionado, anio); // carga el reporte con los parametros seleccionados
            }
        }

        // metodo para obtener el numero de mes a partir de su nombre
        private int ObtenerNumeroMes(string nombreMes)
        {
            // convierte el nombre del mes a su respectivo numero
            switch (nombreMes.ToLower())
            {
                case "enero": return 1;
                case "febrero": return 2;
                case "marzo": return 3;
                case "abril": return 4;
                case "mayo": return 5;
                case "junio": return 6;
                case "julio": return 7;
                case "agosto": return 8;
                case "septiembre": return 9;
                case "octubre": return 10;
                case "noviembre": return 11;
                case "diciembre": return 12;
                default: throw new Exception("Mes invalido"); // lanza excepcion si el mes no es valido
            }
        }

        // evento asociado al DataGridView de ventas por mes
        private void dtmes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // evento asociado al label (sin uso en este caso)
        private void label1_Click(object sender, EventArgs e)
        {

        }

        // evento cuando se selecciona un anio en el comboBox
        private void cbanio_SelectedIndexChanged(object sender, EventArgs e)
        {
            // si los dos valores (anio y mes) estan seleccionados
            if (cbanio.SelectedIndex != -1 && cbmes.SelectedIndex != -1)
            {
                int mesSeleccionado = ObtenerNumeroMes(cbmes.Text); // obtiene el numero del mes seleccionado
                string anio = cbanio.SelectedItem.ToString(); // obtiene el anio seleccionado
                CargarReporteVentas(mesSeleccionado, anio); // carga el reporte con los parametros seleccionados
            }
        }
    }
}
