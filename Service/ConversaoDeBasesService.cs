using Trabalho_Arquitetura.Model;

namespace Trabalho_Arquitetura.Service
{
    public class ConversaoDeBasesService
    {
        public OperadoresModel ConvertBase(OperadoresModel model)
        {
            if (model.BaseOrigem < 2 || model.BaseDestino < 2 || model.BaseOrigem > 16 || model.BaseDestino > 16)
            {
                throw new ArgumentException("As bases devem estar entre 2 e 16.");
            }

            // Converte o número da base de origem para a base 10
            int decimalNumber = ConvertToDecimal(model.Numero, model.BaseOrigem);

            // Converte o número da base 10 para a base de destino
            model.Resultado = ConvertFromDecimal(decimalNumber, model.BaseDestino);

            return model;
        }

        private int ConvertToDecimal(string number, int sourceBase)
        {
            int result = 0;
            int power = 1;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int digit = GetDecimalValue(number[i]);
                result += digit * power;
                power *= sourceBase;
            }

            return result;
        }

        private string ConvertFromDecimal(int decimalNumber, int targetBase)
        {
            if (decimalNumber == 0)
            {
                return "0";
            }

            string result = "";

            while (decimalNumber > 0)
            {
                int remainder = decimalNumber % targetBase;
                char digit = GetCharValue(remainder);
                result = digit + result;
                decimalNumber /= targetBase;
            }

            return result;
        }

        private int GetDecimalValue(char digit)
        {
            if (char.IsDigit(digit))
            {
                return digit - '0';
            }
            else
            {
                return char.ToUpper(digit) - 'A' + 10;
            }
        }

        private char GetCharValue(int value)
        {
            if (value >= 0 && value <= 9)
            {
                return (char)(value + '0');
            }
            else
            {
                return (char)(value - 10 + 'A');
            }
        }
    }
}
