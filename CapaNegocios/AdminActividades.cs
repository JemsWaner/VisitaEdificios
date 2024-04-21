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
        public static int idUsuarioAdmin;
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
        public List<String> ObtenerSolicitud()
        {
            List<string> solicitudes = new List<string>();

            using (MySqlCommand comando = new MySqlCommand("ObtenerSolicitud", connectionNow.conn))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        solicitudes.Add(reader.GetString(0));
                    }
                }
            }
            return solicitudes;
        }

        public List<String> ObtenerCampos(int id)
        {
            List<string> ListaCampos = new List<string>();
            String sql = "ObtenerCamposUsuario";

            using (MySqlCommand comando = new MySqlCommand(sql, connectionNow.conn))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_nuevo", id);
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListaCampos.Add(reader.GetString(0));
                        ListaCampos.Add(reader.GetString(1));
                        ListaCampos.Add(reader.GetString(2));
                        ListaCampos.Add(reader.GetString(3));
                        ListaCampos.Add(reader.GetString(4));
                    }
                }
            }
            return ListaCampos;
        }
    }
}
