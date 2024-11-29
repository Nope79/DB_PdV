// librerias para la conexion a MySQL y manejo de datos
using MySql.Data.MySqlClient;
using pv.Backend;
using System;
using System.Data;
using System.Windows.Forms;

namespace pv.Frontend.Vistas
{
    // formulario para visualizar las ventas por trimestre
    public partial class Ventas_trimestre : Form
    {
        private Connection c; // objeto para manejar la conexion

        // constructor que inicializa la conexion
        public Ventas_trimestre()
        {
            InitializeComponent();
            c = new Connection();
        }

        // evento que carga el reporte de ventas al abrir el formulario
        private void Ventas_trimestre_Load(object sender, EventArgs e)
        {
            CargarReporteVentasTrimestre();
        }

        // metodo que genera el reporte de ventas trimestrales
        private void CargarReporteVentasTrimestre()
        {
            try
            {
                c.OpenConnection(); // abre la conexion
                string query = "select * from ventas_por_trimestre";

                MySqlCommand cmd = new MySqlCommand(query, c.GetConnection());
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable(); // llena los datos en la tabla
                adapter.Fill(dt);
                dttrimestre.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al intentar generar las ventas."); // mensaje en caso de error
            }
            finally
            {
                c.CloseConnection(); // cierra la conexion
            }
        }

        // regresa al formulario principal
        private void btnback_Click(object sender, EventArgs e)
        {
            main m = new main();
            m.Show();
            this.Hide();
        }

        // evento asociado a la tabla (sin implementar)
        private void dttrimestre_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
