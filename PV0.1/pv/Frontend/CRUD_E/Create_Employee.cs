using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using pv.Backend;

namespace pv.Frontend
{
    public partial class Create_Employee : Form
    {
        public Create_Employee()
        {
            InitializeComponent();
            this.Load += new EventHandler(Create_Employee_Load);
        }

        // regresar al crud, con un mensaje de aviso de por medio
        private void btnback_Click(object sender, EventArgs e)
        {
            try
            {
                bool confirmed = Confirmar.Show("¿Estás seguro de que quieres regresar a la página anterior?\nSe perderá la información no guardada.");
                if (confirmed)
                {
                    this.Hide();
                    CRUD_Employees ce = new CRUD_Employees();
                    ce.Show();
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
            }
        }

        private void Update_Employee_Load(object sender, EventArgs e)
        {

        }

        // opciones para enfocar los tbx con tecla enter
        private void tbname_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbuser.Focus();
            }
        }

        private void tbuser_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbpass.Focus();
            }
        }

        private void tbpass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbpassc.Focus();
            }
        }

        private void tbpassc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbmail.Focus();
            }
        }

        private void tbmail_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbphone.Focus();
            }
        }

        private void tbphone_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnadd.Focus(); // Opcionalmente, enfocar el botón "Crear" al final
            }
        }

        // al iniciar el form, se enfoca el primer tbx, nombre
        private void Create_Employee_Load(object sender, EventArgs e)
        {
            tbname.Focus();
        }

        // al añadir el cliente, se validan los datos con validar_insersion, luego se insertan en caso de ser validos con insert_employees
        // al realizarlo exitosamente, se regresa al crud automaticamente
        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                Employees ee = new Employees();

                string nombre = tbname.Text.Trim();
                string user = tbuser.Text.Trim();
                string pass = tbpass.Text.Trim();
                string passc = tbpassc.Text.Trim();
                string correo = tbmail.Text.Trim();
                string tel = tbphone.Text.Trim();

                string res = ee.validar_insersion(0, nombre, user, pass, passc, correo, tel);
                if (res == "OK")
                {
                    bool x = ee.insert_employees(nombre, user, pass, correo, tel);

                    if (x)
                    {
                        CRUD_Employees ce = new CRUD_Employees();
                        ce.Show();
                        this.Hide();
                        res = "Usuario creado correctamente.";
                    }
                    else
                    {
                        res = "Hubo un problema en la base de datos. Inténtelo más tarde.";
                    }
                    
                }

                MessageBox.Show(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
