// librerias necesarias para login y registro, ademas de funcionalidad general de formularios
using pv.Frontend.Login;
using pv.Frontend.Registro;
using System;
using System.Windows.Forms;

namespace pv.Frontend
{
    // clase principal para la ventana de inicio de sesion
    public partial class logmain : Form
    {
        // constructor de la clase
        public logmain()
        {
            // inicializa los componentes de la ventana
            InitializeComponent();
        }

        // evento que se ejecuta al cargar la ventana de logmain
        private void logmain_Load(object sender, EventArgs e)
        {
            // sin implementacion (vacio)
        }

        // evento para el boton de iniciar sesion
        private void btnlogin_Click(object sender, EventArgs e)
        {
            // instancia y muestra la ventana de ingreso, ocultando la actual
            Ingreso i = new Ingreso();
            i.Show();
            this.Hide();
        }

        // evento para el boton de registro
        private void btnregistro_Click(object sender, EventArgs e)
        {
            // instancia y muestra la ventana de registro, ocultando la actual
            Registrar r = new Registrar();
            r.Show();
            this.Hide();
        }

        // evento al hacer clic en picturebox1
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // sin implementacion (vacio)
        }
    }
}
