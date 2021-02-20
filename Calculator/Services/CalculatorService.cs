using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.String;

namespace Calculator.Services
{
    public class CalculatorService : ICalculatorService
    {
        public int Add(string numbers)
        {
            var result = 0;

            if (IsNullOrEmpty(numbers))
            {
                return 0;
            }

            return result;
        }
    }
}
