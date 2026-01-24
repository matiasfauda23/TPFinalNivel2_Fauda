using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ESTA ES LA LÍNEA CLAVE:
            // Le decimos que arranque abriendo tu formulario nuevo "FrmCatalogo"
            Application.Run(new FrmCatalogo());
        }
    }
}