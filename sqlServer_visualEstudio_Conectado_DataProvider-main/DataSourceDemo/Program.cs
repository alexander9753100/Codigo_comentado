using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSourceDemo
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// Este comentario describe el propósito del método Main, que es iniciar la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Este método habilita los estilos visuales para la aplicación. Específicamente,
            // se asegura de que los controles usen los estilos visuales del sistema operativo
            // en lugar de los estilos predeterminados de Windows.
            Application.EnableVisualStyles();

            // Establece la propiedad "UseCompatibleTextRendering" en false, lo que significa que
            // los controles usarán el motor de renderizado de texto GDI+ en lugar del más antiguo GDI.
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia la aplicación y abre el formulario principal, que en este caso es "Form2".
            // Este formulario se muestra cuando la aplicación se inicia y permanece abierto
            // hasta que el usuario lo cierre.
            Application.Run(new Form2());
        }
    }
}

