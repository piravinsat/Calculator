using System.Threading;
using static System.String;

namespace Calculator.Services
{
    public class CalculatorService : ICalculatorService
    {
        public int AddInvoked;

        public int Add(string numbers)
        {
            Interlocked.Increment(ref AddInvoked);
            var count = 0;
            var result = 0;

            if (IsNullOrEmpty(numbers))
            {
                return result;
            }

            //Allow different delimiters
            var listOfNumbers = numbers.Split(new char[] { ',', '\\', '\n' , ';'}, System.StringSplitOptions.None);

            while (count < listOfNumbers.Length)
            {
                int.TryParse(listOfNumbers[count], out int num);

                HandleNegativeNumbers(num);

                //Ignore numbers bigger than 1000.
                if (num <= 1000)
                {
                    result += num;
                }

                count++;
            }

            return result;
        }

        private static void HandleNegativeNumbers(int num)
        {
            if (num < 0)
            {
                throw new NegativeNumberException("negatives not allowed");
            }
        }

        public int GetCalledCount()
        {
            return AddInvoked;
        }
    }
}
