using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using MySql.Data.MySqlClient;

namespace CapaNegocios
{
    public class AgregarDatos
    {
        public Connection connectionNow;
        public MySqlCommand comando;
        MySqlDataReader reader;
        public static int idUsuario;
        public AgregarDatos()
        {
            connectionNow = new Connection();
        }

        public void InsertarUsuario(string nombreUsuario, string apellidoUsuario, string correoUsuario, string contrasenaUsuario, string motivoVisita, string idCarrera, string idEdificio, string idAula,string horaEntrada,string horaSalida)
        {

            using (MySqlCommand comando = new MySqlCommand("InsertarUsuario", connectionNow.conn))
            {
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                comando.Parameters.AddWithValue("@apellidoUsuario", apellidoUsuario);
                comando.Parameters.AddWithValue("@correoUsuario", correoUsuario);
                comando.Parameters.AddWithValue("@contrasenaUsuario", contrasenaUsuario);
                comando.Parameters.AddWithValue("@motivoVisita", motivoVisita);
                comando.Parameters.AddWithValue("@idCarrera", idCarrera);
                comando.Parameters.AddWithValue("@idEdificio", idEdificio);
                comando.Parameters.AddWithValue("@idAula", idAula);
                comando.Parameters.AddWithValue("@horaentrada", horaEntrada);
                comando.Parameters.AddWithValue("@horasalida", horaSalida);

                comando.ExecuteNonQuery();
                ObtenerID(nombreUsuario,contrasenaUsuario);
            }
        }
        public void ActualizarUsuario(int idUsuario, string nombreUsuario, string apellidoUsuario, string correoUsuario, string contrasenaUsuario, string motivoVisita, string idCarrera, string idEdificio, string idAula, string horaEntrada, string horaSalida)
        {   
            using (MySqlCommand comando = new MySqlCommand("ActualizarUsuario", connectionNow.conn))
            {
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                comando.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                comando.Parameters.AddWithValue("@apellidoUsuario", apellidoUsuario);
                comando.Parameters.AddWithValue("@correoUsuario", correoUsuario);
                comando.Parameters.AddWithValue("@contrasenaUsuario", contrasenaUsuario);
                comando.Parameters.AddWithValue("@motivoVisita", motivoVisita);
                comando.Parameters.AddWithValue("@idCarrera", idCarrera);
                comando.Parameters.AddWithValue("@idEdificio", idEdificio);
                comando.Parameters.AddWithValue("@idAula", idAula);
                comando.Parameters.AddWithValue("@horaentrada", horaEntrada);
                comando.Parameters.AddWithValue("@horasalida", horaSalida);

                comando.ExecuteNonQuery();
            }
        }

        public void ObtenerID(string nombreUsuario,string contrasenaUsuario) {
            String sql ="select id_usuario from usuario where nombre=@nombreUsuario and contrasena=@contrasenaUsuario";
           
            using (MySqlCommand comando = new MySqlCommand(sql, connectionNow.conn))
            {
                comando.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                comando.Parameters.AddWithValue("@contrasenaUsuario", contrasenaUsuario);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idUsuario = reader.GetInt32(0);
                    }
                }
            }
        }

        public String UsuarioOAdmin(int id)
        {
            string tipoUsuario="";
            String sql ="ObtenerEstado";

            using (MySqlCommand comando = new MySqlCommand(sql, connectionNow.conn))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id_nuevo", id);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tipoUsuario = reader.GetString(0);
                        Console.WriteLine("Tipo de usuario: " + tipoUsuario);
                    }
                }
            }
            return tipoUsuario;
        }

        public List<String> ObtenerCarrera()
        {
            List<string> carreras = new List<string>();
            using (MySqlCommand comando = new MySqlCommand("SELECT carrera_nombre FROM carrera", connectionNow.conn))
            {
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        carreras.Add(reader.GetString(0));
                    }
                }
            }
            return carreras;
        }

        public List<String> ObtenerEdificio()
        {
            List<string> edificios = new List<string>();
            using (MySqlCommand comando = new MySqlCommand("SELECT edificio_nombre FROM edificio", connectionNow.conn))
            {
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        edificios.Add(reader.GetString(0));
                    }
                }
            }
            return edificios;
        }

        public List<String> ObtenerAula()
        {
            List<string> aulas = new List<string>();
            using (MySqlCommand comando = new MySqlCommand("SELECT aula_nombre FROM aula", connectionNow.conn))
            {
                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        aulas.Add(reader.GetString(0));
                    }
                }
            }
            return aulas;
        }

    }
}
