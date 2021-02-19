using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Services
{
    public interface IRequestService
    {
        void LogRequest(string ip);
    }
}
