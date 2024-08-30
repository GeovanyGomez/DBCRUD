using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataCustomers; // Importa el namespace donde se encuentra la clase CustomerRepositorys.
using System.Reflection;

namespace BDcrud
{
    // Formulario principal que permite realizar operaciones CRUD sobre los clientes.
    public partial class Form1 : Form
    {
        // Instancia del repositorio de clientes para acceder a las operaciones CRUD.
        CustomerRepositorys customerRepository = new CustomerRepositorys();

        // Constructor del formulario.
        public Form1()
        {
            InitializeComponent(); // Inicializa los componentes del formulario.
        }

        // Evento click del botón 'Cargar' para cargar todos los clientes en el DataGridView.
        private void btnCargar_Click(object sender, EventArgs e)
        {
            var Customers = customerRepository.ObtenerTodos(); // Obtiene todos los clientes.
            datagrid.DataSource = Customers; // Asigna la lista de clientes como fuente de datos para el DataGridView.
        }

        // Evento click del botón 'Buscar' para buscar un cliente por su ID y mostrar sus datos en los TextBoxes.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var cliente = customerRepository.ObtenerPorID(txtBuscar.Text); // Busca un cliente por su ID.
            // Asigna los valores del cliente encontrado a los TextBoxes correspondientes.
            txtCustomerID.Text = cliente.CustomerID;
            txtCompanyName.Text = cliente.CompanyName;
            txtContactName.Text = cliente.ContactName;
            txtContactTitle.Text = cliente.ContactTitle;
            txtAddress.Text = cliente.Address;
            txtCity.Text = cliente.City;
            txtRegion.Text = cliente.Region;
            txtPostalCode.Text = cliente.PostalCode;
            txtCountry.Text = cliente.Country;
            txtPhone.Text = cliente.Phone;
            txtFax.Text = cliente.Fax;
        }

        // Evento click del botón 'Insertar' para agregar un nuevo cliente a la base de datos.
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var resultado = 0; // Inicializa la variable para almacenar el resultado de la operación.

            var nuevoCliente = ObtenerNuevoCliente(); // Obtiene un objeto con los datos del nuevo cliente.

            // Verifica si hay campos vacíos en el nuevo cliente.
            if (validarCampoNull(nuevoCliente) == false)
            {
                // Si no hay campos vacíos, agrega el cliente a la base de datos.
                resultado = customerRepository.AgregarCliente(nuevoCliente);
                // Muestra un mensaje de éxito con el número de filas afectadas.
                MessageBox.Show("Guardado." + " Datos modificados correctamente, filas afectadas = " + resultado);
            }
            else
            {
                // Si hay campos vacíos, muestra un mensaje indicando que deben completarse.
                MessageBox.Show("Debe completar los campos, por favor");
            }
        }

        // Método para validar si alguno de los campos del cliente es nulo o está vacío.
        // Devuelve true si encuentra un campo vacío, de lo contrario, devuelve false.
        public Boolean validarCampoNull(Object objeto)
        {
            // Recorre todas las propiedades del objeto cliente.
            foreach (PropertyInfo property in objeto.GetType().GetProperties())
            {
                object value = property.GetValue(objeto, null); // Obtiene el valor de la propiedad.
                if ((string)value == "") // Verifica si el valor es una cadena vacía.
                {
                    return true; // Devuelve true si encuentra una cadena vacía.
                }
            }
            return false; // Devuelve false si no encuentra ninguna cadena vacía.
        }

        // Evento click del botón 'Modificar' para actualizar los datos de un cliente existente.
        private void btModificar_Click(object sender, EventArgs e)
        {
            var actualizarCliente = ObtenerNuevoCliente(); // Obtiene un objeto con los datos actualizados del cliente.
            int actualizadas = customerRepository.ActualizarCliente(actualizarCliente); // Actualiza el cliente en la base de datos.
            // Muestra un mensaje de éxito con el número de filas actualizadas.
            MessageBox.Show($"Los datos han sido actualizados, filas actualizadas = {actualizadas}");
        }

        // Método para obtener un nuevo cliente a partir de los datos ingresados en los TextBoxes.
        private CustomersGet ObtenerNuevoCliente()
        {
            // Crea una nueva instancia de CustomersGet y asigna los valores de los TextBoxes.
            var nuevoCliente = new CustomersGet
            {
                CustomerID = txtCustomerID.Text,
                CompanyName = txtCompanyName.Text,
                ContactName = txtContactName.Text,
                ContactTitle = txtContactTitle.Text,
                Address = txtAddress.Text,
                City = txtCity.Text,
                Region = txtRegion.Text,
                PostalCode = txtPostalCode.Text,
                Country = txtCountry.Text,
                Phone = txtPhone.Text,
                Fax = txtFax.Text
            };

            return nuevoCliente; // Devuelve el nuevo cliente.
        }

        // Evento click del botón 'Eliminar' para eliminar un cliente de la base de datos.
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int eliminadas = customerRepository.EliminarCliente(txtCustomerID.Text); // Elimina el cliente por su ID.
            // Muestra un mensaje de éxito con el número de filas eliminadas.
            MessageBox.Show("Se ha eliminado = " + eliminadas + " Customers");
        }
    }
}
