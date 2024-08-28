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
using DatosLayer;
using System.Net;
using System.Reflection;


namespace ConexionEjemplo
{
    public partial class Form1 : Form
    {
        // Se crea una instancia de la clase CustomerRepository que contiene los métodos para interactuar con la base de datos.
        CustomerRepository customerRepository = new CustomerRepository();

        public Form1()
        {
            InitializeComponent(); // Inicializa los componentes del formulario, como botones, cuadros de texto, etc.
        }

        // Evento que se ejecuta al hacer clic en el botón Cargar
        private void btnCargar_Click(object sender, EventArgs e)
        {
            // Obtiene todos los clientes de la base de datos y los muestra en un DataGridView.
            var Customers = customerRepository.ObtenerTodos();
            dataGrid.DataSource = Customers; // Asigna la lista de clientes como fuente de datos para el DataGridView.
        }

        // Evento que se ejecuta cuando el texto en el TextBox cambia
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           // Se podría usar este evento para filtrar los resultados en el DataGridView en función del texto ingresado.
           // var filtro = Customers.FindAll( X => X.CompanyName.StartsWith(tbFiltro.Text));
           // dataGrid.DataSource = filtro;
        }

        // Evento que se ejecuta al cargar el formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            // Este código se usa para configurar la conexión a la base de datos, pero está comentado.
            /*  DatosLayer.DataBase.ApplicationName = "Programacion 2 ejemplo";
                DatosLayer.DataBase.ConnectionTimeout = 30;
                string cadenaConexion = DatosLayer.DataBase.ConnectionString;
                var conexion = DatosLayer.DataBase.GetSqlConnection();
            */
        }

        // Evento que se ejecuta al hacer clic en el botón Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Busca un cliente en la base de datos usando el ID ingresado y muestra sus detalles en los TextBoxes correspondientes.
            var cliente = customerRepository.ObtenerPorID(txtBuscar.Text);
            tboxCustomerID.Text = cliente.CustomerID;
            tboxCompanyName.Text = cliente.CompanyName;
            tboxContacName.Text = cliente.ContactName;
            tboxContactTitle.Text = cliente.ContactTitle;
            tboxAddress.Text = cliente.Address;
            tboxCity.Text = cliente.City;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Este evento está vacío, no hace nada actualmente.
        }

        // Evento que se ejecuta al hacer clic en el botón Insertar
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var resultado = 0; // Variable para almacenar el número de filas modificadas.

            // Obtiene los valores de los TextBoxes y crea un nuevo objeto cliente.
            var nuevoCliente = ObtenerNuevoCliente();

            // Verifica si hay campos nulos en el nuevo cliente antes de intentar insertarlo.
            if (validarCampoNull(nuevoCliente) == false)
            {
                // Si no hay campos nulos, inserta el cliente en la base de datos y muestra un mensaje con el número de filas afectadas.
                resultado = customerRepository.InsertarCliente(nuevoCliente);
                MessageBox.Show("Guardado" + "Filas modificadas = " + resultado);
            }
            else {
                // Si hay campos nulos, muestra un mensaje de advertencia.
                MessageBox.Show("Debe completar los campos por favor");
            }
        }

        // Método para validar si algún campo del objeto está nulo o vacío
        public Boolean validarCampoNull(Object objeto)
        {
            // Recorre todas las propiedades del objeto y verifica si alguna está vacía.
            foreach (PropertyInfo property in objeto.GetType().GetProperties()) {
                object value = property.GetValue(objeto, null);
                if ((string)value == "") {
                    return true; // Si encuentra un campo vacío, retorna true.
                }
            }
            return false; // Si todos los campos están completos, retorna false.
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Este evento está vacío, no hace nada actualmente.
        }

        // Evento que se ejecuta al hacer clic en el botón Modificar
        private void btModificar_Click(object sender, EventArgs e)
        {
            // Obtiene los datos del cliente que se desean actualizar.
            var actualizarCliente = ObtenerNuevoCliente();
            // Actualiza el cliente en la base de datos y muestra un mensaje con el número de filas afectadas.
            int actualizadas = customerRepository.ActualizarCliente(actualizarCliente);
            MessageBox.Show($"Filas actualizadas = {actualizadas}");
        }

        // Método para obtener los datos del nuevo cliente desde los TextBoxes
        private Customers ObtenerNuevoCliente()
        {
            var nuevoCliente = new Customers
            {
                CustomerID = tboxCustomerID.Text, // Asigna el ID del cliente
                CompanyName = tboxCompanyName.Text, // Asigna el nombre de la compañía
                ContactName = tboxContacName.Text, // Asigna el nombre del contacto
                ContactTitle = tboxContactTitle.Text, // Asigna el título del contacto
                Address = tboxAddress.Text, // Asigna la dirección
                City = tboxCity.Text // Asigna la ciudad
            };
            return nuevoCliente; // Retorna el objeto cliente con los valores asignados.
        }

        // Evento que se ejecuta al hacer clic en el botón Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Elimina el cliente de la base de datos usando el ID ingresado y muestra un mensaje con el número de filas eliminadas.
            int eliminadas = customerRepository.EliminarCliente(tboxCustomerID.Text);
            MessageBox.Show("Filas eliminadas = " + eliminadas);
        }
    }
}
