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
    public partial class Form1 : Form
    {
        // Constructor del formulario. Se llama cuando se instancia el formulario.
        public Form1()
        {
            // Inicializa los componentes del formulario. Este método es generado automáticamente
            // por el diseñador de Visual Studio y configura todos los controles en el formulario.
            InitializeComponent();
        }

        // Este método se ejecuta cuando se hace clic en el botón "Guardar" del BindingNavigator.
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            // Valida los controles en el formulario para asegurarse de que no hay errores de entrada.
            this.Validate();

            // Finaliza cualquier edición en curso en el BindingSource, lo que asegura que los datos
            // editados en el formulario se reflejen en el origen de datos subyacente.
            this.customersBindingSource.EndEdit();

            // Aplica todos los cambios pendientes en el DataSet a la base de datos.
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);
        }

        // Otro método de manejo de eventos para el botón "Guardar" del BindingNavigator.
        // Parece que se añadieron varios métodos similares, lo que puede ser un error o
        // sobras de código generado automáticamente.
        private void customersBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);
        }

        // Un tercer método similar, probablemente también agregado por error.
        private void customersBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);
        }

        // Este método se ejecuta cuando el formulario se carga por primera vez.
        private void Form1_Load(object sender, EventArgs e)
        {
            // Esta línea de código carga datos en la tabla 'Customers' del 'northwindDataSet'.
            // El método 'Fill' del TableAdapter obtiene los datos de la base de datos y los
            // carga en el DataSet, lo que permite que los datos se muestren en el formulario.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }

        // Este método maneja el evento cuando se hace clic en una celda del DataGridView.
        // Actualmente, no hace nada y está vacío. Puedes agregar código aquí si quieres
        // realizar alguna acción específica cuando el usuario haga clic en una celda.
        private void customersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Código para manejar el evento de clic en una celda del DataGridView.
        }
    }
}

