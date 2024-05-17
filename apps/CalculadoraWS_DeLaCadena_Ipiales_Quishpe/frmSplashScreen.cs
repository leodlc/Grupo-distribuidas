using System;
using System.Windows.Forms;

namespace CalculadoraWS_DeLaCadena_Ipiales_Quishpe
{
    public partial class frmSplashScreen : Form
    {
        private int moveStep = 5;

        public frmSplashScreen()
        {
            InitializeComponent();
        }

        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
            // Posicionar el PictureBox en la parte inferior del formulario al inicio
            pictureBox1.Top = this.Height;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Mover el PictureBox hacia arriba hasta que llegue al centro del formulario
            if (pictureBox1.Top > this.Height / 2 - pictureBox1.Height / 2)
            {
                pictureBox1.Top -= moveStep;
            }
            else
            {
                timer1.Stop();
                System.Threading.Thread.Sleep(2000); // Pausa por 2 segundos antes de cerrar
                this.Close(); // Cierra el formulario de inicio
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
