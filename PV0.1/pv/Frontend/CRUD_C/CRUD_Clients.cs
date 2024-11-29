using System;
using System.Windows.Forms;
using pv.Backend;

namespace pv.Frontend
{
    public partial class CRUD_Clients : Form
    {
        private Clients c;
        private int id;
        private string nombre;
        private string telefono;
        private int edad;
        private string sexo;

        public CRUD_Clients()
        {
            InitializeComponent();
            c = new Clients();
            LoadData(); 
        }

        private void CRUD_Clients_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // cargar datos
        private void LoadData()
        {
            try
            {
                var clientsList = c.SelectClients();
                dtclients.DataSource = clientsList; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // cambiar a crear cliente
        private void btnadd_Click(object sender, EventArgs e)
        {
            Create_Clients f = new Create_Clients();
            f.Show();
            this.Hide();
        }

        // cambiar a actualizar cliente
        private void btnupdate_Click(object sender, EventArgs e)
        {
            Update_Clients ue = new Update_Clients(id, nombre, telefono, edad, sexo);
            ue.Show();
            this.Hide();
        }

        // para borrar, primero salta un mensaje de confitmación, y en base a la decision, se borra o no, con el metodo deleteclient
        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool confirmed = Confirmar.Show("¿Estás seguro de que quieres eliminar el cliente?\nUna vez hecho, no podrás deshacer la acción.");
                if (confirmed)
                {
                    bool success = c.DeleteClient(id); 
                    if (success)
                    {
                        MessageBox.Show("Cliente eliminado correctamente.");
                        LoadData(); 
                    }
                    else
                    {
                        MessageBox.Show("Hubo un problema al eliminar el cliente.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // evento para habilitar el boton de borrar y eliminar al presionar una celda valida
        private void dtclients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dtclients.Rows.Count)
                {
                    DataGridViewRow selectedRow = dtclients.Rows[e.RowIndex];
                    id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                    nombre = selectedRow.Cells["Nombre"].Value.ToString();
                    telefono = selectedRow.Cells["Telefono"].Value.ToString();
                    edad = Convert.ToInt32(selectedRow.Cells["Edad"].Value);
                    sexo = selectedRow.Cells["Sexo"].Value.ToString();

                    btndelete.Enabled = true;
                    btnupdate.Enabled = true;
                }
                else
                {
                    btndelete.Enabled = false;
                    btnupdate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        // cambiar de vista a la principal
        private void btnback_Click(object sender, EventArgs e)
        {
            main m = new main();
            m.Show();
            this.Hide();
        }
    }
}
