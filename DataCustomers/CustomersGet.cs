using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCustomers
{
    // Clase que representa un cliente con sus respectivas propiedades.
    public class CustomersGet
    {
        // Propiedad que almacena el ID del cliente.
        public string CustomerID { get; set; }

        // Propiedad que almacena el nombre de la compañía del cliente.
        public string CompanyName { get; set; }

        // Propiedad que almacena el nombre del contacto en la compañía.
        public string ContactName { get; set; }

        // Propiedad que almacena el título del contacto.
        public string ContactTitle { get; set; }

        // Propiedad que almacena la dirección del cliente.
        public string Address { get; set; }

        // Propiedad que almacena la ciudad donde se encuentra el cliente.
        public string City { get; set; }

        // Propiedad que almacena la región donde se encuentra el cliente.
        public string Region { get; set; }

        // Propiedad que almacena el código postal del cliente.
        public string PostalCode { get; set; }

        // Propiedad que almacena el país del cliente.
        public string Country { get; set; }

        // Propiedad que almacena el número de teléfono del cliente.
        public string Phone { get; set; }

        // Propiedad que almacena el número de fax del cliente.
        public string Fax { get; set; }
    }
}
