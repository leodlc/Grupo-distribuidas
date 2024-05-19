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
            AplicarEstilos();
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
        private void AplicarEstilos()
        {
            // Fondo principal
            this.BackColor = ColorTranslator.FromHtml("#E0F7FA");

            // Colores de texto de etiquetas
            lblNum1.ForeColor = ColorTranslator.FromHtml("#333333");
            lblNum2.ForeColor = ColorTranslator.FromHtml("#333333");
            lvlResp.ForeColor = ColorTranslator.FromHtml("#333333");
            lblBy.ForeColor = ColorTranslator.FromHtml("#333333");
            lblLeo.ForeColor = ColorTranslator.FromHtml("#333333");
            lblCarlos.ForeColor = ColorTranslator.FromHtml("#333333");
            lblSanti.ForeColor = ColorTranslator.FromHtml("#333333");
            lblTitle.ForeColor = ColorTranslator.FromHtml("#00BFFF");

            // Estilo de botones
            btnSumar.BackColor = ColorTranslator.FromHtml("#80CBC4");
            btnSumar.ForeColor = Color.White;
            btnRestar.BackColor = ColorTranslator.FromHtml("#80CBC4");
            btnRestar.ForeColor = Color.White;
            btnMultiplicar.BackColor = ColorTranslator.FromHtml("#80CBC4");
            btnMultiplicar.ForeColor = Color.White;
            btnDividir.BackColor = ColorTranslator.FromHtml("#80CBC4");
            btnDividir.ForeColor = Color.White;
            button1.BackColor = ColorTranslator.FromHtml("#03AED2");
            button1.ForeColor = Color.White;

            // Estilo del cuadro de respuesta
            txtBoxResp.BackColor = Color.White;
            txtBoxResp.BorderStyle = BorderStyle.FixedSingle;
            txtBoxResp.ForeColor = ColorTranslator.FromHtml("#333333");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calculator nuevoFormulario = new Calculator();

            // Cierra el formulario actual

            // Abre el nuevo formulario
            nuevoFormulario.Show();
            this.Hide();

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
