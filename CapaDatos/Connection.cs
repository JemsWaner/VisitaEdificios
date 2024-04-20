using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class Connection
    {
        String server = "localhost";
        String user = "root";
        String database = "VisitasSistema";
        String port = "3306";
        String password = "12345678";
        public MySqlConnection conn;

        public Connection()
        {

            String connectionString = $"server={server}; " +
                $"user={user}; " +
                $"database={database}; " +
                $"port={port}; " +
                $"password={password}; ";

            conn = new MySqlConnection();
            conn.ConnectionString = connectionString;

            try
            {
                conn.Open();
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
