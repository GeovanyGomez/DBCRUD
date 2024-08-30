using DataCustomers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCustomers
{
    // Clase principal que maneja las operaciones CRUD para los clientes.
    public class CustomerRepositorys
    {
        // Método para obtener todos los registros de la tabla Customers.
        public List<CustomersGet> ObtenerTodos()
        {
            using (var conexion = ConecionBD.GetSqlConnection()) // Abre una conexión a la base de datos.
            {
                // Construcción de la consulta SQL para obtener todos los clientes.
                String Cargar = "";
                Cargar = Cargar + "SELECT [CustomerID] " + "\n";
                Cargar = Cargar + "      ,[CompanyName] " + "\n";
                Cargar = Cargar + "      ,[ContactName] " + "\n";
                Cargar = Cargar + "      ,[ContactTitle] " + "\n";
                Cargar = Cargar + "      ,[Address] " + "\n";
                Cargar = Cargar + "      ,[City] " + "\n";
                Cargar = Cargar + "      ,[Region] " + "\n";
                Cargar = Cargar + "      ,[PostalCode] " + "\n";
                Cargar = Cargar + "      ,[Country] " + "\n";
                Cargar = Cargar + "      ,[Phone] " + "\n";
                Cargar = Cargar + "      ,[Fax] " + "\n";
                Cargar = Cargar + "  FROM [dbo].[Customers]"; // Finaliza la consulta SQL.

                using (SqlCommand comando = new SqlCommand(Cargar, conexion)) // Prepara la consulta SQL para ejecutarla.
                {
                    SqlDataReader reader = comando.ExecuteReader(); // Ejecuta la consulta y obtiene los resultados.
                    List<CustomersGet> Customers = new List<CustomersGet>();// Crea una lista para almacenar los resultados.

                    while (reader.Read())// Itera a través de los registros obtenidos.
                    {
                        var customers = LeerDatos(reader); // Extrae los datos de cada registro.

                        Customers.Add(customers); // Agrega el cliente a la lista.
                    }
                    return Customers; // Devuelve la lista completa de clientes.
                }
            }
        }
        // Método para obtener un cliente específico por su ID.
        public CustomersGet ObtenerPorID(string id)
        {
            using (var conexion = ConecionBD.GetSqlConnection()) // Abre una conexión a la base de datos.
            {
                // Construcción de la consulta SQL para obtener un cliente por su ID.
                String Buscar = "";
                Buscar = Buscar + "SELECT [CustomerID] " + "\n";
                Buscar = Buscar + "      ,[CompanyName] " + "\n";
                Buscar = Buscar + "      ,[ContactName] " + "\n";
                Buscar = Buscar + "      ,[ContactTitle] " + "\n";
                Buscar = Buscar + "      ,[Address] " + "\n";
                Buscar = Buscar + "      ,[City] " + "\n";
                Buscar = Buscar + "      ,[Region] " + "\n";
                Buscar = Buscar + "      ,[PostalCode] " + "\n";
                Buscar = Buscar + "      ,[Country] " + "\n";
                Buscar = Buscar + "      ,[Phone] " + "\n";
                Buscar = Buscar + "      ,[Fax] " + "\n";
                Buscar = Buscar + "  FROM [dbo].[Customers] " + "\n";
                Buscar = Buscar + $"  Where CustomerID = @customerId"; // Añade el filtro por ID.

                using (SqlCommand comando = new SqlCommand(Buscar, conexion)) // Prepara la consulta SQL para ejecutarla.
                {
                    comando.Parameters.AddWithValue("customerId", id);  // Añade el parámetro del ID.


                    var reader = comando.ExecuteReader();// Ejecuta la consulta y obtiene los resultados.
                    CustomersGet customers = null; // Inicializa la variable para almacenar el resultado.
                    if (reader.Read()) // Verifica si hay un resultado.
                    {
                        customers = LeerDatos(reader); // Extrae los datos del cliente.
                    }
                    return customers; // Devuelve el cliente encontrado, o null si no existe.
                }

            }
        }
        // Método para leer los datos de un cliente desde un SqlDataReader.
        public CustomersGet LeerDatos(SqlDataReader reader)
        {
            CustomersGet customers = new CustomersGet(); // Crea una nueva instancia del cliente.
            //Asigna  los parametros necesarios
            customers.CustomerID = reader["CustomerID"] == DBNull.Value ? " " : (String)reader["CustomerID"];
            customers.CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (String)reader["CompanyName"];
            customers.ContactName = reader["ContactName"] == DBNull.Value ? "" : (String)reader["ContactName"];
            customers.ContactTitle = reader["ContactTitle"] == DBNull.Value ? "" : (String)reader["ContactTitle"];
            customers.Address = reader["Address"] == DBNull.Value ? "" : (String)reader["Address"];
            customers.City = reader["City"] == DBNull.Value ? "" : (String)reader["City"];
            customers.Region = reader["Region"] == DBNull.Value ? "" : (String)reader["Region"];
            customers.PostalCode = reader["PostalCode"] == DBNull.Value ? "" : (String)reader["PostalCode"];
            customers.Country = reader["Country"] == DBNull.Value ? "" : (String)reader["Country"];
            customers.Phone = reader["Phone"] == DBNull.Value ? "" : (String)reader["Phone"];
            customers.Fax = reader["Fax"] == DBNull.Value ? "" : (String)reader["Fax"];

            return customers; // Devuelve la instancia del cliente con todos sus datos.
        }


        // Método para agregar un nuevo cliente a la base de datos.
        public int AgregarCliente(CustomersGet customer)
        {
            using (var conexion = ConecionBD.GetSqlConnection()) // Abre una conexión a la base de datos.
            {
                // Construcción de la consulta SQL para insertar un nuevo cliente.
                String Agregar = "";
                Agregar = Agregar + "INSERT INTO [dbo].[Customers] " + "\n";
                Agregar = Agregar + "           ([CustomerID] " + "\n";
                Agregar = Agregar + "           ,[CompanyName] " + "\n";
                Agregar = Agregar + "           ,[ContactName] " + "\n";
                Agregar = Agregar + "           ,[ContactTitle] " + "\n";
                Agregar = Agregar + "           ,[Address] " + "\n";
                Agregar = Agregar + "           ,[City] " + "\n";
                Agregar = Agregar + "           ,[Region] " + "\n";
                Agregar = Agregar + "           ,[PostalCode] " + "\n";
                Agregar = Agregar + "           ,[Country] " + "\n";
                Agregar = Agregar + "           ,[Phone] " + "\n";
                Agregar = Agregar + "           ,[Fax]) " + "\n";
                Agregar = Agregar + "     VALUES " + "\n";
                Agregar = Agregar + "           (@CustomerID " + "\n";
                Agregar = Agregar + "           ,@CompanyName " + "\n";
                Agregar = Agregar + "           ,@ContactName " + "\n";
                Agregar = Agregar + "           ,@ContactTitle " + "\n";
                Agregar = Agregar + "           ,@Address " + "\n";
                Agregar = Agregar + "           ,@City" + "\n";
                Agregar = Agregar + "           ,@Region" + "\n";
                Agregar = Agregar + "           ,@PostalCode" + "\n";
                Agregar = Agregar + "           ,@Country" + "\n";
                Agregar = Agregar + "           ,@Phone" + "\n";
                Agregar = Agregar + "           ,@Fax)"; // Finaliza la consulta SQL de inserción.

                using (var comando = new SqlCommand(Agregar, conexion)) // Prepara la consulta SQL para ejecutarla.
                {
                    int agregado = Parametros(customer, comando);// Llama al método para agregar los parámetros y ejecutar la consulta.
                    return agregado; // Devuelve el número de filas afectadas.
                }

            }
        }
        // Método para actualizar un cliente existente en la base de datos.
        public int ActualizarCliente(CustomersGet customer)
        {
            using (var conexion = ConecionBD.GetSqlConnection())// Abre una conexión a la base de datos.


            {
                // Construcción de la consulta SQL para actualizar un cliente por su ID.
                String ActualizarPorID = "";
                ActualizarPorID = ActualizarPorID + "UPDATE [dbo].[Customers] " + "\n";
                ActualizarPorID = ActualizarPorID + "   SET [CustomerID] = @CustomerID " + "\n";
                ActualizarPorID = ActualizarPorID + "      ,[CompanyName] = @CompanyName " + "\n";
                ActualizarPorID = ActualizarPorID + "      ,[ContactName] = @ContactName " + "\n";
                ActualizarPorID = ActualizarPorID + "      ,[ContactTitle] = @ContactTitle " + "\n";
                ActualizarPorID = ActualizarPorID + "      ,[Address] = @Address " + "\n";
                ActualizarPorID = ActualizarPorID + "      ,[City] = @City " + "\n";
                ActualizarPorID = ActualizarPorID + "      ,[Region] = @Region " + "\n";
                ActualizarPorID = ActualizarPorID + "      ,[PostalCode] = @PostalCode " + "\n";
                ActualizarPorID = ActualizarPorID + "      ,[Country] = @Country " + "\n";
                ActualizarPorID = ActualizarPorID + "      ,[Phone] = @Phone " + "\n";
                ActualizarPorID = ActualizarPorID + "      ,[Fax] = @Fax " + "\n";
                ActualizarPorID = ActualizarPorID + " WHERE CustomerID= @CustomerID"; // Añade la condición para actualizar solo el cliente con el ID especificado.
                using (var comando = new SqlCommand(ActualizarPorID, conexion)) // Prepara la consulta SQL para ejecutarla.
                {

                    int actualizado = Parametros(customer, comando);// Llama al método para agregar los parámetros y ejecutar la consulta.

                    return actualizado; // Devuelve el número de filas afectadas.
                }
            }
        }
        // Método para agregar los parámetros comunes en las consultas de agregar y actualizar.
        public int Parametros(CustomersGet customer, SqlCommand comando)
        {

            //Agrega los parametros necesarios  
            comando.Parameters.AddWithValue("CustomerID", customer.CustomerID);
            comando.Parameters.AddWithValue("CompanyName", customer.CompanyName);
            comando.Parameters.AddWithValue("ContactName", customer.ContactName);
            comando.Parameters.AddWithValue("ContactTitle", customer.ContactTitle);
            comando.Parameters.AddWithValue("Address", customer.Address);
            comando.Parameters.AddWithValue("City", customer.City);
            comando.Parameters.AddWithValue("Region", customer.Region);
            comando.Parameters.AddWithValue("PostalCode", customer.PostalCode);
            comando.Parameters.AddWithValue("Country", customer.Country);
            comando.Parameters.AddWithValue("Phone", customer.Phone);
            comando.Parameters.AddWithValue("Fax", customer.Fax);
            var agregado = comando.ExecuteNonQuery();
            return agregado; // Devuelve el número de filas afectadas.
        }
        // Método para eliminar un cliente de la base de datos por su ID.
        public int EliminarCliente(string id)
        {
            using (var conexion = ConecionBD.GetSqlConnection())  // Abre una conexión a la base de datos.
            {
                // Construcción de la consulta SQL para eliminar un cliente por su ID.
                String Eliminar = "";
                Eliminar = Eliminar + "DELETE FROM [dbo].[Customers] " + "\n";
                Eliminar = Eliminar + "      WHERE CustomerID = @CustomerID";// Añade la condición para eliminar solo el cliente con el ID especificado.
                using (SqlCommand comando = new SqlCommand(Eliminar, conexion))// Prepara la consulta SQL para ejecutarla.
                {
                    comando.Parameters.AddWithValue("@CustomerID", id); // Añade el parámetro CustomerID.
                    int elimindo = comando.ExecuteNonQuery(); // Ejecuta la consulta SQL.
                    return elimindo; // Devuelve el número de filas afectadas.
                }
            }
        }
    }
}
