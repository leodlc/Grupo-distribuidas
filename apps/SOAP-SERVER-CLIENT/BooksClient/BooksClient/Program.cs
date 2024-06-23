using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksClient
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Mostrar el formulario de carga
            using (var formCarga = new FormCarga())
            {
                formCarga.ShowDialog();
            }

            // Una vez que el formulario de carga se cierra, iniciar el formulario principal
            Application.Run(new Form1());
        }
    }
    }

