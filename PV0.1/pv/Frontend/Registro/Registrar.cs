﻿using pv.Backend;
using System;
using System.Windows.Forms;

namespace pv.Frontend.Registro
{
    public partial class Registrar : Form
    {
        public Registrar()
        {
            // handlers para saltar de tbx en tbx
            InitializeComponent();
            tbname.KeyUp += new KeyEventHandler(tbname_KeyUp);
            tbuser.KeyUp += new KeyEventHandler(tbuser_KeyUp);
            tbpass.KeyUp += new KeyEventHandler(tbpass_KeyUp);
            tbpassc.KeyUp += new KeyEventHandler(tbpassc_KeyUp);
            tbmail.KeyUp += new KeyEventHandler(tbmail_KeyUp);
            tbphone.KeyUp += new KeyEventHandler(tbphone_KeyUp);
            tbname.Focus();
        }

        // regresar al logmain con mensaje de advertencia de por medio
        private void btnback_Click(object sender, EventArgs e)
        {
            bool confirmed = Confirmar.Show("¿Estás seguro de que quieres retroceder?\nNo se guardarán los cambios realizados.");
            if (confirmed)
            {
                this.Hide();
                logmain ce = new logmain();
                ce.Show();
            }
        }

        // se validan los datos y luego se insertan
        // finalmente se regresa al logmain automaticamente, en caso de errores, no se hace ni la insersion ni el regreso
        private void btnregistrar_Click(object sender, EventArgs e)
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
                        logmain ce = new logmain();
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

        // regresar, con mensaje de confimacion de por medio
        private void btnback_Click_1(object sender, EventArgs e)
        {
            try
            {
                bool confirmed = Confirmar.Show("¿Estás seguro de que quieres regresar a la página anterior?\nSe perderá la información no guardada.");
                if (confirmed)
                {
                    this.Hide();
                    logmain ce = new logmain();
                    ce.Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        // enter para avanzar enter tbx
        private void tbname_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbmail.Focus();
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
                btnregistrar.Focus();
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
                tbuser.Focus(); // Opcionalmente, enfocar el botón "Crear" al final
            }
        }

        private void Registrar_Load(object sender, EventArgs e)
        {
            tbname.Focus();
        }
    }
}
