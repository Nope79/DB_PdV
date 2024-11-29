using System;
using MySql.Data.MySqlClient;

namespace pv.Backend
{
    public class Connection
    {
        private MySqlConnection connection;
        private readonly string connectionString;
        public Connection()
        {
            connectionString = "server=localhost; User ID=root; password=insertecontraseña; Database=puntodeventa; port=3306;";
            connection = new MySqlConnection(connectionString);
        }

        // funcion para abrir una conexion cuando esta cerrada
        public void OpenConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                    //Console.WriteLine("Conexión exitosa.");
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
            }
        }

        // funcion para cerrar una conexion que esta abierta
        public void CloseConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    //Console.WriteLine("Conexión cerrada exitosamente.");
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
            }
        }

        // servira para conseguir la conexion 
        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
