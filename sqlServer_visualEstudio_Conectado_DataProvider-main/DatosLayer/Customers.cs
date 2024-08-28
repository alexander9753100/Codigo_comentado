using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    // Esta clase representa la entidad "Customers", la cual mapea los datos de la tabla "Customers" en la base de datos.
    public class Customers
    {
        // Propiedad que almacena el ID del cliente (CustomerID).
        public string CustomerID { get; set; }

        // Propiedad que almacena el nombre de la compañía del cliente (CompanyName).
        public string CompanyName { get; set; }

        // Propiedad que almacena el nombre del contacto principal en la compañía (ContactName).
        public string ContactName { get; set; }

        // Propiedad que almacena el título o cargo del contacto principal (ContactTitle).
        public string ContactTitle { get; set; }

        // Propiedad que almacena la dirección del cliente (Address).
        public string Address { get; set; }

        // Propiedad que almacena la ciudad donde se ubica el cliente (City).
        public string City { get; set; }

        // Propiedad que almacena la región o estado donde se encuentra el cliente (Region).
        public string Region { get; set; }

        // Propiedad que almacena el código postal del cliente (PostalCode).
        public string PostalCode { get; set; }

        // Propiedad que almacena el país donde se encuentra el cliente (Country).
        public string Country { get; set; }

        // Propiedad que almacena el número de teléfono del cliente (Phone).
        public string Phone { get; set; }

        // Propiedad que almacena el número de fax del cliente (Fax).
        public string Fax { get; set; }
    }
}
