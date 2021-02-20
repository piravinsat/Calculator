using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public interface ICalculatorService
    {
        int Add(string numbers);
        int GetAddCalledCount();
        int Subtract(string numbers);
        int GetSubtractCalledCount();
        int Multiply(string numbers);
        int GetMultiplyCalledCount();
        int Divide(string numbers);
        int GetDivideCalledCount();
    }
}
