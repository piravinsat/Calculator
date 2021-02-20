using static System.String;

namespace Calculator.Services
{
    public class CalculatorService : ICalculatorService
    {
        public int Add(string numbers)
        {
            var count = 0;
            var result = 0;

            if (IsNullOrEmpty(numbers))
            {
                return result;
            }

            var listOfNumbers = numbers.Split(',');

            while (count < listOfNumbers.Length)
            {
                int.TryParse(listOfNumbers[count], out int num);
                result += num;
                count++;
            }

            return result;
        }
    }
}
