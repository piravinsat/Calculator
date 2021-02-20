using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException() : base() {}

        public NegativeNumberException(string message) : base(message)
        {}

        public NegativeNumberException(string message, Exception inner) : base(message, inner) {}
    }
}
