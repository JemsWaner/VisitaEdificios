using CapaDatos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class AdminActividades
    {
        public Connection connectionNow;
        public MySqlCommand comando;
        MySqlDataReader reader;
        public static int idUsuario;
        public AdminActividades()
        {
            connectionNow = new Connection();
        }

        public void InsertarNuevoUsuario(string nombreUsuario, string apellidoUsuario, string contrasenaUsuario,string fechaNacimiento,string tipoUsuario)
        {
            using (MySqlCommand comando = new MySqlCommand("InsertarNuevoUsuario", connectionNow.conn))
            {
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@nombre", nombreUsuario);
                comando.Parameters.AddWithValue("@apellido", apellidoUsuario);
                comando.Parameters.AddWithValue("@contrasenaUsuario", contrasenaUsuario);
                comando.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                comando.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);

                comando.ExecuteNonQuery();
            }
        }
        public List<String> ObtenerTipo()
        {
            List<string> tipos = new List<string>();
            using (MySqlCommand comando = new MySqlCommand("SELECT tipo_usuario FROM tipo_usuario", connectionNow.conn))
            {
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tipos.Add(reader.GetString(0));
                    }
                }
            }
            return tipos;
        }

        public List<String> ObtenerListaUsuarios()
        {
            List<string> ListaUsuarios = new List<string>();
            String sql = "ObtenerListaUsuarios";

            using (MySqlCommand comando = new MySqlCommand(sql, connectionNow.conn))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        String idNombreApellido = reader.GetInt32(0).ToString() + "- " + reader.GetString(1) + " " + reader.GetString(2);
                        ListaUsuarios.Add(idNombreApellido);
                    }
                }
            }
            return ListaUsuarios;
        }
    }
}
