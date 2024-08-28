using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace DatosLayer
{
    public class DataBase
    {
        // Propiedad estática que obtiene la cadena de conexión.
        // La cadena se obtiene de la configuración y se puede modificar 
        // con el nombre de la aplicación y el tiempo de espera para la conexión.
        public static string ConnectionString {
            get
            {
                // Obtener la cadena de conexión desde el archivo de configuración.
                string CadenaConexion = ConfigurationManager
                    .ConnectionStrings["NWConnection"]
                    .ConnectionString;

                // Construir el objeto SqlConnectionStringBuilder con la cadena obtenida.
                SqlConnectionStringBuilder conexionBuilder = 
                    new SqlConnectionStringBuilder(CadenaConexion);

                // Si se proporciona un ApplicationName, se utiliza; 
                // de lo contrario, se deja el valor por defecto.
                conexionBuilder.ApplicationName = 
                    ApplicationName ?? conexionBuilder.ApplicationName;
         
                // Si se establece un ConnectionTimeout mayor a 0, se utiliza; 
                // de lo contrario, se deja el valor por defecto.
                conexionBuilder.ConnectTimeout = ( ConnectionTimeout > 0 ) 
                    ? ConnectionTimeout : conexionBuilder.ConnectTimeout;
                
                // Devolver la cadena de conexión final como una cadena de texto.
                return conexionBuilder.ToString();
            }
        }

        // Propiedad estática para establecer o obtener el tiempo de espera de la conexión.
        public static int ConnectionTimeout { get; set; }

        // Propiedad estática para establecer o obtener el nombre de la aplicación.
        public static string ApplicationName { get; set; }

        // Método estático para obtener una conexión SQL abierta.
        public static SqlConnection GetSqlConnection()
        {
            // Crear una nueva conexión SQL con la cadena de conexión generada.
            SqlConnection conexion = new SqlConnection(ConnectionString);
            
            // Abrir la conexión antes de devolverla.
            conexion.Open();
            return conexion;
        } 
    }
}

