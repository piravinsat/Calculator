using System;
using Calculator.Data;
using Calculator.Models;

namespace Calculator.Services
{
    public class RequestService : IRequestService
    {
        private readonly RequestContext _context;

        public RequestService(RequestContext context)
        {
            _context = context;
        }

        /*
         * IP Address of client should be logged into the database
         * with date/time of the request
         */
        public void LogRequest(string ip)
        {
            var request = new Request {IpAddress = ip, RequestDateTime = DateTime.Now};

            _context.Request.Add(request);
            _context.SaveChanges();
        }
    }
}
