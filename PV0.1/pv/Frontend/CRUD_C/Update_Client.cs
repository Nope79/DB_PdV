using System;
using System.Windows.Forms;
using pv.Backend;

namespace pv.Frontend
{
    public partial class Update_Clients : Form
    {
        private int id;
        private string nombre;
        private string telefono;
        private int edad;
        private string sexo;

        // cargamos los tbx con los argumentos enviados al cargar este form
        public Update_Clients(int id, string nombre, string telefono, int edad, string sexo)
        {
            InitializeComponent();

            this.id = id;
            this.nombre = nombre;
            this.telefono = telefono;
            this.edad = edad;
            this.sexo = sexo;

            tbname.Text = nombre;
            tbphone.Text = telefono;
            tbage.Text = edad.ToString();
            if (sexo == "M") rbmale.Checked = true;
            else rbfemale.Checked = true;
        }

        // se validan los datos antes de actualizarlos, para evitar incongruencias
        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                Clients clientHandler = new Clients();
                string nombre = tbname.Text.Trim();
                string telefono = tbphone.Text.Trim();
                int edad = Convert.ToInt32(tbage.Text.Trim());
                string sexo = rbmale.Checked ? "M" : "F";

                string val = clientHandler.validar_cliente(nombre, telefono, edad.ToString(), sexo);
                if (val == "OK")
                {
                    bool result = clientHandler.UpdateClient(id, nombre, telefono, edad, sexo);

                    if (result)
                    {
                        MessageBox.Show("Cliente actualizado correctamente.");
                        CRUD_Clients ce = new CRUD_Clients();
                        ce.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un problema al actualizar el cliente.");
                    }
                }
                else
                {
                    MessageBox.Show(val);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al actualizar el cliente.");
            }
        }

        // regresar al crud
        private void btnback_Click(object sender, EventArgs e)
        {
            CRUD_Clients ce = new CRUD_Clients();
            ce.Show();
            this.Hide();
        }

        private void Update_Clients_Load(object sender, EventArgs e)
        {

        }
    }
}
