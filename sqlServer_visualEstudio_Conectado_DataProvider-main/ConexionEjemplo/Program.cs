using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionEjemplo
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread] // Indica que el subproceso principal de la aplicación utiliza el modelo de subprocesamiento STA (Single Thread Apartment).
        static void Main() // Este es el punto de entrada principal de la aplicación.
        {
            // Habilita los estilos visuales modernos para la aplicación, asegurando que los controles usen el estilo visual del sistema operativo.
            Application.EnableVisualStyles();

            // Establece el renderizado de texto predeterminado. Si se establece en false, usará el renderizado de texto GDI+ en lugar de GDI.
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia la aplicación de Windows Forms y muestra el formulario principal (Form1).
            Application.Run(new Form1());
        }
    }
}

