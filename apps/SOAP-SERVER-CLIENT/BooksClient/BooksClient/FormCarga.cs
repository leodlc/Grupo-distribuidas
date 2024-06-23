using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksClient
{
    public partial class FormCarga : Form
    {
        public FormCarga()
        {
            InitializeComponent();
        }

        private void FormCarga_Load(object sender, EventArgs e)
        {
            // Iniciar el temporizador cuando se carga el formulario
            timerCerrar.Start();
        }

        // Método para manejar el evento Tick del temporizador
        private void timerCerrar_Tick(object sender, EventArgs e)
        {
            // Cerrar el formulario después de dos segundos
            this.Close();
        }

        private void timerCerrar_Tick_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
