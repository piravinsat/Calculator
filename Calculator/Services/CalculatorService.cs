using System.Threading;
using static System.String;

namespace Calculator.Services
{
    public class CalculatorService : ICalculatorService
    {
        public int AddInvoked;
        public int SubtractInvoked;
        public int MultiplyInvoked;
        public int DivideInvoked;

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
            var listOfNumbers = SplitNumbers(numbers);

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

        public int Subtract(string numbers)
        {
            Interlocked.Increment(ref SubtractInvoked);
            var result = 0;
            var count = 0;

            if (IsNullOrEmpty(numbers))
            {
                return result;
            }

            var listOfNumbers = SplitNumbers(numbers);

            while (count < listOfNumbers.Length)
            {
                int.TryParse(listOfNumbers[count], out int num);

                HandleNegativeNumbers(num);

                //Ignore numbers bigger than 1000.
                if (num <= 1000)
                {
                    if (count == 0)
                    {
                        result = num;
                    }
                    else
                    {
                        result -= num;
                    }
                }

                count++;
            }
            return result;
        }

        public int GetSubtractCalledCount()
        {
            return SubtractInvoked;
        }

        public int Multiply(string numbers)
        {
            Interlocked.Increment(ref MultiplyInvoked);
            var result = 0;
            var count = 0;

            if (IsNullOrEmpty(numbers))
            {
                return result;
            }

            var listOfNumbers = SplitNumbers(numbers);

            while (count < listOfNumbers.Length)
            {
                int.TryParse(listOfNumbers[count], out int num);

                HandleNegativeNumbers(num);

                //Ignore numbers bigger than 1000.
                if (num <= 1000)
                {
                    if (count == 0)
                    {
                        result = num;
                    }
                    else
                    {
                        result *= num;
                    }
                }

                count++;
            }
            return result;
        }

        public int GetMultiplyCalledCount()
        {
            return MultiplyInvoked;
        }

        public int Divide(string numbers)
        {
            Interlocked.Increment(ref DivideInvoked);
            var result = 0;
            var count = 0;

            if (IsNullOrEmpty(numbers))
            {
                return result;
            }

            var listOfNumbers = SplitNumbers(numbers);

            while (count < listOfNumbers.Length)
            {
                int.TryParse(listOfNumbers[count], out int num);

                HandleNegativeNumbers(num);

                //Ignore numbers bigger than 1000.
                if (num <= 1000)
                {
                    if (count == 0)
                    {
                        result = num;
                    }
                    else
                    {
                        result /= num;
                    }
                }

                count++;
            }
            return result;
        }

        public int GetDivideCalledCount()
        {
            return DivideInvoked;
        }

        private static string[] SplitNumbers(string numbers)
        {
            //Allow different delimiters
            var listOfNumbers = numbers.Split(new char[] {',','\\', '\n', ';', '/' }, System.StringSplitOptions.RemoveEmptyEntries);
            return listOfNumbers;
        }

        public int GetAddCalledCount()
        {
            return AddInvoked;
        }

        private static void HandleNegativeNumbers(int num)
        {
            if (num < 0)
            {
                throw new NegativeNumberException("negatives not allowed");
            }
        }
    }
}
