using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace DataCustomers
{
    // Clase que gestiona la conexión a la base de datos.
    public class ConecionBD
    {
        // Propiedad estática que devuelve la cadena de conexión configurada con ajustes adicionales.
        public static string ConnectionString
        {
            get
            {
                // Obtiene la cadena de conexión de la configuración de la aplicación.
                string CadenaConexion = ConfigurationManager.ConnectionStrings["NWConnection"].ConnectionString;

                // Utiliza SqlConnectionStringBuilder para construir y manipular la cadena de conexión.
                SqlConnectionStringBuilder conexionBuilder = new SqlConnectionStringBuilder(CadenaConexion);

                // Asigna el nombre de la aplicación, si se ha configurado.
                conexionBuilder.ApplicationName = ApplicationName ?? conexionBuilder.ApplicationName;

                // Configura el tiempo de espera de la conexión si se ha especificado uno, de lo contrario, usa el valor predeterminado.
                conexionBuilder.ConnectTimeout = (ConnectionTimeout > 0) ? ConnectionTimeout : conexionBuilder.ConnectTimeout;

                // Devuelve la cadena de conexión final como un string.
                return conexionBuilder.ToString();
            }
        }

        // Propiedad para establecer el tiempo de espera de la conexión.
        public static int ConnectionTimeout { get; set; }

        // Propiedad para establecer el nombre de la aplicación que se incluirá en la cadena de conexión.
        public static string ApplicationName { get; set; }

        // Método estático para obtener una instancia de SqlConnection ya abierta.
        public static SqlConnection GetSqlConnection()
        {
            // Crea una nueva conexión SQL utilizando la cadena de conexión construida.
            SqlConnection conexion = new SqlConnection(ConnectionString);
            conexion.Open(); // Abre la conexión a la base de datos.
            return conexion; // Devuelve la conexión abierta.
        }
    }
}
