using System;
using System.Windows.Forms;

namespace CalculadoraWS_DeLaCadena_Ipiales_Quishpe
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

            // Mostrar el formulario de splash
            using (var splashForm = new frmSplashScreen())
            {
                splashForm.ShowDialog();
            }

            // Mostrar el formulario principal
            Application.Run(new Form1());

        }
    }
}
