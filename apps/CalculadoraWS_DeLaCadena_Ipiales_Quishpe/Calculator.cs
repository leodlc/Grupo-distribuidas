using System;
using System.Windows.Forms;

namespace CalculadoraWS_DeLaCadena_Ipiales_Quishpe
{
    public partial class Calculator : Form
    {
        private string input = string.Empty; // Almacena la entrada del usuario
        private string operador1 = string.Empty; // Almacena el primer operando
        private string operand2 = string.Empty; // Almacena el segundo operando
        private char operation; // Almacena el operador
        private int result = 0; // Almacena el resultado

        public Calculator()
        {
            InitializeComponent();
            AssignButtonEvents();
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Calculator_KeyPress);
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            // Configuración inicial si es necesario
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.txtIngresoSalida.Text += button.Text;
            input += button.Text;
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operador1 = input;
            operation = button.Text[0];
            input = string.Empty;
            this.txtIngresoSalida.Text += button.Text;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            operand2 = input;
            int num1, num2;
            int.TryParse(operador1, out num1);
            int.TryParse(operand2, out num2);

            Calcular calcular = new Calcular();

            try
            {
                switch (operation)
                {
                    case '+':
                        result = calcular.Suma(num1, num2);
                        break;
                    case '-':
                        result = calcular.Resta(num1, num2);
                        break;
                    case 'X':
                        result = calcular.Multiplicar(num1, num2);
                        break;
                    case '/':
                        result = calcular.Dividir(num1, num2);
                        break;
                }
                this.txtIngresoSalida.Text = result.ToString();
                input = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.txtIngresoSalida.Clear();
                input = string.Empty;
                operador1 = string.Empty;
                operand2 = string.Empty;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtIngresoSalida.Clear();
            this.input = string.Empty;
            this.operador1 = string.Empty;
            this.operand2 = string.Empty;
        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                this.txtIngresoSalida.Text += e.KeyChar;
                input += e.KeyChar;
            }
            else if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == 'X' || e.KeyChar == '/')
            {
                if (!string.IsNullOrEmpty(input))
                {
                    operador1 = input;
                    operation = e.KeyChar;
                    input = string.Empty;
                    this.txtIngresoSalida.Text += e.KeyChar;
                }
            }
            else if (e.KeyChar == '=' || e.KeyChar == '\r')
            {
                btnCalcular.PerformClick();
            }
            else if (e.KeyChar == '\b')
            {
                if (txtIngresoSalida.Text.Length > 0)
                {
                    txtIngresoSalida.Text = txtIngresoSalida.Text.Substring(0, txtIngresoSalida.Text.Length - 1);
                    if (input.Length > 0)
                        input = input.Substring(0, input.Length - 1);
                }
            }
        }

        private void AssignButtonEvents()
        {
            this.btn0.Click += new EventHandler(btnNumber_Click);
            this.btn1.Click += new EventHandler(btnNumber_Click);
            this.btn2.Click += new EventHandler(btnNumber_Click);
            this.btn3.Click += new EventHandler(btnNumber_Click);
            this.btn4.Click += new EventHandler(btnNumber_Click);
            this.btn5.Click += new EventHandler(btnNumber_Click);
            this.btn6.Click += new EventHandler(btnNumber_Click);
            this.btn7.Click += new EventHandler(btnNumber_Click);
            this.btn8.Click += new EventHandler(btnNumber_Click);
            this.btn9.Click += new EventHandler(btnNumber_Click);

            this.btnSuma.Click += new EventHandler(btnOperator_Click);
            this.btnResta.Click += new EventHandler(btnOperator_Click);
            this.btnMultiplicacion.Click += new EventHandler(btnOperator_Click);
            this.btnDivision.Click += new EventHandler(btnOperator_Click);

            this.btnCalcular.Click += new EventHandler(btnCalcular_Click);
            this.btnLimpiar.Click += new EventHandler(btnLimpiar_Click);
        }
    }
}
