// librerias necesarias para formularios y conexion con el backend
using System;
using System.Windows.Forms;
using pv.Backend;

namespace pv.Frontend.Vistas
{
    // formulario para gestionar las ventas
    public partial class Ventasx : Form
    {
        // instancia para la conexion y operaciones de ventas
        private Connection c = new Connection();
        private Backend.Venta v;

        // constructor, inicializa el formulario y carga los datos de ventas
        public Ventasx()
        {
            InitializeComponent();
            v = new Backend.Venta();
            LoadData();
        }

        // carga inicial de datos en el formulario
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // metodo para cargar los datos de todas las ventas
        private void LoadData()
        {
            dtventas.DataSource = v.select_ventas();
        }

        // regresa al formulario principal
        private void btnback_Click(object sender, EventArgs e)
        {
            main m = new main();
            m.Show();
            this.Hide();
        }

        // carga ventas dentro de un rango de fechas
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpinicio.Value.Date;
            DateTime endDate = dtpfin.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.");
            }
            else
            {
                dtventas.DataSource = v.select_ventas_fecha(startDate, endDate);
            }
        }

        // recarga la vista completa de ventas
        private void btnnormal_Click(object sender, EventArgs e)
        {
            dtventas.DataSource = v.select_ventas();
        }

        // muestra la cantidad de productos en una venta segun el folio
        private void tbfolio_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tbfolio.Text, out int folio))
            {
                int cantidadProductos = v.productos_por_venta(folio);
                lblventas.Text = $"Productos en la venta {folio}: {cantidadProductos}";
            }
            else
            {
                lblventas.Text = "Folio inválido. Introduzca un número.";
            }
        }

        private void Ventasx_Load(object sender, EventArgs e)
        {

        }
    }
}
