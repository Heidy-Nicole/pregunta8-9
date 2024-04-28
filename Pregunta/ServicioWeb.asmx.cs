using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Pregunta
{
    /// <summary>
    /// Descripción breve de ServicioWeb
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioWeb : System.Web.Services.WebService
    {

        [WebMethod]
        public int ModificarPersona(int persona_id, string nombre, string ap_paterno, string ap_materno, string correo, string rol, string departamento)
        {
            try
            {
                MySqlConnection con = new MySqlConnection();
                string servidor = "localhost";
                string bd = "bdheidy2";
                string usuario = "root";
                string password = "";
                string cadenaConexion = "server=" + servidor + ";" + "user=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
                string query = "UPDATE personas SET nombre = '" + nombre + "', ap_paterno = '" + ap_paterno + "', ap_materno = '" + ap_materno + "', correo = '" + correo + "', rol = '" + rol + "', departamento = '" + departamento + "' WHERE persona_id = '" + persona_id+"';";
                con.ConnectionString = cadenaConexion;
                con.Open();
                MySqlCommand comando = new MySqlCommand(query, con);
                comando.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Se ha modificado la persona con id: " + persona_id);
                return 2;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        [WebMethod]
        public int AgregarPersona(string nombre, string ap_paterno, string ap_materno, string correo, string rol, string departamento)
        {
            try
            {
                MySqlConnection con = new MySqlConnection();
                string servidor = "localhost";
                string bd = "bdheidy2";
                string usuario = "root";
                string password = "";
                string cadenaConexion = "server=" + servidor + ";" + "user=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
                string query = "INSERT INTO personas (nombre, ap_paterno, ap_materno, correo, rol, departamento) VALUES (@nombre, @ap_paterno, @ap_materno, @correo, @rol, @departamento)";

                con.ConnectionString = cadenaConexion;
                con.Open();
                MySqlCommand comando = new MySqlCommand(query, con);
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@ap_paterno", ap_paterno);
                comando.Parameters.AddWithValue("@ap_materno", ap_materno);
                comando.Parameters.AddWithValue("@correo", correo);
                comando.Parameters.AddWithValue("@rol", rol);
                comando.Parameters.AddWithValue("@departamento", departamento);

                comando.ExecuteNonQuery();

                con.Close();
                return 1; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0; 
            }
        }

        [WebMethod]
        public int EliminarPersona(int persona_id)
        {
            try
            {
                MySqlConnection con = new MySqlConnection();
                string servidor = "localhost";
                string bd = "bdheidy2";
                string usuario = "root";
                string password = "";
                string cadenaConexion = "server=" + servidor + ";" + "user=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
                string query = "DELETE FROM personas WHERE persona_id = '" + persona_id + "'";
                con.ConnectionString = cadenaConexion;
                con.Open();
                MySqlCommand comando = new MySqlCommand(query, con);
                comando.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Se ha eliminado la persona con id: " + persona_id);
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }


    }
}
