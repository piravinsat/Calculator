using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Services
{
    public interface ICalculatorService
    {
        int Add(string numbers);
        Task<CalculatorResponseModel> AddAsync(string numbers);
        int GetAddCalledCount();
        int Subtract(string numbers);
        int GetSubtractCalledCount();
        int Multiply(string numbers);
        int GetMultiplyCalledCount();
        int Divide(string numbers);
        int GetDivideCalledCount();
        Task<CalculatorResponseModel> SubtractAsync(string numbers);
        Task<CalculatorResponseModel> MultiplyAsync(string numbers);
        Task<CalculatorResponseModel> DivideAsync(string numbers);
    }
}
