using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSourceDemo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // Maneja el evento de clic en el botón de guardar del BindingNavigator.
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            // Valida los datos en los controles de entrada.
            this.Validate();
            // Finaliza la edición de los datos en el BindingSource.
            this.customersBindingSource.EndEdit();
            // Actualiza todos los cambios en la base de datos a través del TableAdapterManager.
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);
        }

        // Maneja el evento de carga del formulario.
        private void Form2_Load(object sender, EventArgs e)
        {
            // Carga los datos en la tabla 'Customers' del DataSet 'northwindDataSet'.
            // Esta línea de código se ejecuta cuando el formulario se carga.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }

        // Maneja el evento de clic en el TextBox (cajaTextoID). Actualmente no tiene implementación.
        private void cajaTextoID_Click(object sender, EventArgs e)
        {
            // No hay código aquí. Puedes implementar la lógica si es necesario.
        }

        // Maneja el evento de presionar una tecla en el TextBox (cajaTextoID).
        private void cajaTextoID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es Enter (código ASCII 13).
            if (e.KeyChar == (char)13)
            {
                // Busca el índice del elemento en el BindingSource que coincide con el valor en cajaTextoID.
                var index = customersBindingSource.Find("customerID", cajaTextoID.Text);

                // Si el índice es válido, establece la posición del BindingSource en ese índice.
                if (index > -1)
                {
                    customersBindingSource.Position = index;
                    return;
                }
                else
                {
                    // Muestra un mensaje si el elemento no se encuentra.
                    MessageBox.Show("Elemento no encontrado");
                }
            }
        }
    }
}

