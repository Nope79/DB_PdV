// librerias necesarias para funcionalidad general de formularios y graficos
using System;
using System.Drawing;
using System.Windows.Forms;

namespace pv.Frontend
{
    // clase para el formulario de confirmacion
    public partial class Confirmar : Form
    {
        // constructor que recibe un mensaje como parametro
        public Confirmar(string message)
        {
            // inicializa los componentes del formulario
            InitializeComponent();

            // asigna el mensaje recibido al label y lo centra
            lbmessage.Text = message;
            CenterLabel();
        }

        // evento al hacer clic en el label1
        private void label1_Click(object sender, EventArgs e)
        {
            // sin implementacion (vacio)
        }

        // evento que se ejecuta al cargar el formulario
        private void Confirmar_Load(object sender, EventArgs e)
        {
            // sin implementacion (vacio)
        }

        // metodo estatico para mostrar el dialogo de confirmacion
        public static bool Show(string message)
        {
            // crea una instancia del formulario con el mensaje recibido
            using (var confirmDialog = new Confirmar(message))
            {
                // muestra el formulario como dialogo modal y devuelve true si el usuario selecciona "Yes"
                var result = confirmDialog.ShowDialog();
                return result == DialogResult.Yes;
            }
        }

        // evento para el boton "Yes"
        private void btnYes_Click(object sender, EventArgs e)
        {
            // establece el resultado del dialogo como "Yes" y cierra el formulario
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        // evento para el boton "No"
        private void btnNo_Click(object sender, EventArgs e)
        {
            // establece el resultado del dialogo como "No" y cierra el formulario
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        // metodo para centrar el label del mensaje
        private void CenterLabel()
        {
            // calcula la posicion x e y para centrar el label en el formulario
            int xPos = (this.ClientSize.Width - lbmessage.Width) / 2;
            int yPos = (this.ClientSize.Height - lbmessage.Height) / 3;

            // actualiza la ubicacion del label
            lbmessage.Location = new Point(xPos, yPos);
        }
    }
}
