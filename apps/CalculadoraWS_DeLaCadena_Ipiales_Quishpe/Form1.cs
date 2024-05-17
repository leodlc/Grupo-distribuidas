using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraWS_DeLaCadena_Ipiales_Quishpe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            RealizarOperacion("suma");
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            RealizarOperacion("resta");
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            RealizarOperacion("multiplicar");
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            RealizarOperacion("dividir");
        }

        private void RealizarOperacion(string operacion)
        {
            
            txtBoxResp.Text = string.Empty;

            
            int numero1 = int.Parse(txtBoxNum1.Text);
            int numero2 = int.Parse(txtBoxNum2.Text);

            
            Calcular calcular = new Calcular();

            
            int resultado = 0;

            
            switch (operacion)
            {
                case "suma":
                    resultado = calcular.Suma(numero1, numero2);
                    break;
                case "resta":
                    resultado = calcular.Resta(numero1, numero2);
                    break;
                case "multiplicar":
                    resultado = calcular.Multiplicar(numero1, numero2);
                    break;
                case "dividir":
                    resultado = calcular.Dividir(numero1, numero2);
                    break;
            }

            // Mostrar el resultado en el TextBox de respuesta
            txtBoxResp.Text = resultado.ToString();
        }

        
    }
}
