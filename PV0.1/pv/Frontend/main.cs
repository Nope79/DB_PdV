// libreria necesaria para usar formularios en windows
using System;
using System.Windows.Forms;

// se definen namespaces del proyecto y referencias a otras partes del frontend
using pv.Frontend.Vistas;
using pv.Frontend.Ventas;

namespace pv.Frontend
{
    // clase principal que extiende de form (ventana principal)
    public partial class main : Form
    {
        // constructor de la clase
        public main()
        {
            // obtiene valores del registro de la aplicacion
            var xid = Application.UserAppDataRegistry.GetValue("ID");
            var xuser = Application.UserAppDataRegistry.GetValue("User");

            // muestra los valores obtenidos en la consola
            Console.WriteLine($"{xid} {xuser}");

            // inicializa los componentes de la ventana
            InitializeComponent();

            // asigna un titulo personalizado a la ventana
            this.Text = $"Bienvenido {xuser} :D!";
        }

        // evento para el boton de crud de productos
        private void btnCRUDP_Click(object sender, EventArgs e)
        {
            // instancia y muestra la ventana de crud de productos, ocultando la actual
            CRUD_Productos ce = new CRUD_Productos();
            ce.Show();
            this.Hide();
        }

        // evento para el boton de crud de empleados
        private void btnCRUDE_Click(object sender, EventArgs e)
        {
            // instancia y muestra la ventana de crud de empleados, ocultando la actual
            CRUD_Employees ce = new CRUD_Employees();
            ce.Show();
            this.Hide();
        }

        // evento para el boton de ventas detalladas
        private void btnventasd_Click(object sender, EventArgs e)
        {
            // instancia y muestra la ventana de ventas detalladas, ocultando la actual
            Ventasx vd = new Ventasx();
            vd.Show();
            this.Hide();
        }

        // evento para el boton de vender
        private void btnvender_Click(object sender, EventArgs e)
        {
            // instancia y muestra la ventana de vender, ocultando la actual
            Vender v = new Vender();
            v.Show();
            this.Hide();
        }

        // evento que se ejecuta al cargar la ventana principal
        private void main_Load(object sender, EventArgs e)
        {
            // sin implementacion (vacio)
        }

        // evento para el boton de ticket
        private void btnticket_Click(object sender, EventArgs e)
        {
            // instancia y muestra la ventana de venta hecha, ocultando la actual
            VentaHecha v = new VentaHecha();
            v.Show();
            this.Hide();
        }

        // evento para el boton de regresar a la ventana principal
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // muestra un mensaje de confirmacion al usuario
                bool confirmed = Confirmar.Show("¿Estás seguro de que quieres regresar a la ventana principal?.");

                // si el usuario confirma, oculta la ventana actual y muestra la ventana principal
                if (confirmed)
                {
                    this.Hide();
                    logmain ce = new logmain();
                    ce.Show();
                }
            }
            catch (Exception ex)
            {
                // muestra cualquier error en la consola
                Console.WriteLine(ex);
            }
        }

        // evento al hacer clic en la picturebox7
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            // sin implementacion (vacio)
        }

        // evento para pintar el panel1
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // sin implementacion (vacio)
        }

        // evento para el boton de crud de clientes
        private void btnCRUD_Clients_Click(object sender, EventArgs e)
        {
            // instancia y muestra la ventana de crud de clientes, ocultando la actual
            CRUD_Clients crudClients = new CRUD_Clients();
            crudClients.Show();
            this.Hide();
        }

        // evento para el boton de ventas del mes
        private void button2_Click(object sender, EventArgs e)
        {
            // instancia y muestra la ventana de ventas del mes, ocultando la actual
            Ventas_Mes vm = new Ventas_Mes();
            vm.Show();
            this.Hide();
        }

        // evento para el boton de ventas por empleado
        private void button3_Click(object sender, EventArgs e)
        {
            // instancia y muestra la ventana de ventas por empleado, ocultando la actual
            Ventas_empleado ve = new Ventas_empleado();
            ve.Show();
            this.Hide();
        }

        // evento para el boton de ventas del trimestre
        private void btntrimestre_Click(object sender, EventArgs e)
        {
            // instancia y muestra la ventana de ventas del trimestre, ocultando la actual
            Ventas_trimestre vt = new Ventas_trimestre();
            this.Hide();
            vt.Show();
        }
    }
}
