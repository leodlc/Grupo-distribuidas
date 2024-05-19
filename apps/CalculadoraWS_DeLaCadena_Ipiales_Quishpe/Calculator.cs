using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CalculadoraWS_DeLaCadena_Ipiales_Quishpe
{
    public partial class Calculator : Form
    {
        private string input = string.Empty; // Almacena la entrada del usuario

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
            this.txtIngresoSalida.Text += button.Text;
            input += button.Text;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                var result = EvaluateExpression(input);
                this.txtIngresoSalida.Text = result.ToString();
                input = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.txtIngresoSalida.Clear();
                input = string.Empty;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtIngresoSalida.Clear();
            this.input = string.Empty;
        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == 'X' || e.KeyChar == '/' || e.KeyChar == '.')
            {
                this.txtIngresoSalida.Text += e.KeyChar;
                input += e.KeyChar;
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

        private int EvaluateExpression(string expression)
        {
            expression = expression.Replace("X", "*");

            var tokens = ParseExpression(expression);
            return CalculateResult(tokens);
        }

        private List<string> ParseExpression(string expression)
        {
            var tokens = new List<string>();
            string number = string.Empty;

            foreach (char c in expression)
            {
                if (char.IsDigit(c))
                {
                    number += c;
                }
                else
                {
                    if (!string.IsNullOrEmpty(number))
                    {
                        tokens.Add(number);
                        number = string.Empty;
                    }
                    tokens.Add(c.ToString());
                }
            }

            if (!string.IsNullOrEmpty(number))
            {
                tokens.Add(number);
            }

            return tokens;
        }

        private int CalculateResult(List<string> tokens)
        {
            Calcular calcular = new Calcular();

            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i] == "*" || tokens[i] == "/")
                {
                    int num1 = int.Parse(tokens[i - 1]);
                    int num2 = int.Parse(tokens[i + 1]);
                    int result = 0;

                    if (tokens[i] == "*")
                    {
                        result = calcular.Multiplicar(num1, num2);
                    }
                    else if (tokens[i] == "/")
                    {
                        result = calcular.Dividir(num1, num2);
                    }

                    tokens[i - 1] = result.ToString();
                    tokens.RemoveAt(i);
                    tokens.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i] == "+" || tokens[i] == "-")
                {
                    int num1 = int.Parse(tokens[i - 1]);
                    int num2 = int.Parse(tokens[i + 1]);
                    int result = 0;

                    if (tokens[i] == "+")
                    {
                        result = calcular.Suma(num1, num2);
                    }
                    else if (tokens[i] == "-")
                    {
                        result = calcular.Resta(num1, num2);
                    }

                    tokens[i - 1] = result.ToString();
                    tokens.RemoveAt(i);
                    tokens.RemoveAt(i);
                    i--;
                }
            }

            return int.Parse(tokens[0]);
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

        private void txtIngresoSalida_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
