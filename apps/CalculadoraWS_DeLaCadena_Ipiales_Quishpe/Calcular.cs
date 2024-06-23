using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraWS_DeLaCadena_Ipiales_Quishpe
{
    public class Calcular
    {
        public int Suma(int Numero, int Numero2)
        {
            int Respuesta;
            Calculadora.CalculatorSoapClient objSumar = new Calculadora.CalculatorSoapClient("CalculatorSoap");

            Respuesta = objSumar.Add(Numero, Numero2);

            return Respuesta;
        }

        public int Resta(int Numero, int Numero2)
        {
            int Respuesta;
            Calculadora.CalculatorSoapClient objRestar = new Calculadora.CalculatorSoapClient("CalculatorSoap");

            Respuesta = objRestar.Subtract(Numero, Numero2);
            return Respuesta;
        }

        public int Multiplicar(int Numero, int Numero2)
        {
            int Respuesta;
            Calculadora.CalculatorSoapClient objMultiplicar = new Calculadora.CalculatorSoapClient("CalculatorSoap");

            Respuesta = objMultiplicar.Multiply(Numero, Numero2);
            return Respuesta;
        }

        public int Dividir(int Numero, int Numero2)
        {
            int Respuesta;
            Calculadora.CalculatorSoapClient objDividir = new Calculadora.CalculatorSoapClient("CalculatorSoap");

            Respuesta = objDividir.Divide(Numero, Numero2);
            return Respuesta;
        }
    }
}
