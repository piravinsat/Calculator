using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Calculator.Models
{
    public class CalculatorResponseModel
    {
        public int Id { get; set; }
        public string Numbers { get; set; }
        public int Result { get; set; }
    }
}
