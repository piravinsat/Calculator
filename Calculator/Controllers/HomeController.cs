using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Calculator.Data;
using Calculator.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IActionContextAccessor _accessor;
        private readonly IRequestService _requestService;
        private readonly RequestContext _context;

        public HomeController(ILogger<HomeController> logger, IActionContextAccessor accessor, RequestContext context)
        {
            _logger = logger;
            _accessor = accessor;
            _context = context;
            _requestService = new RequestService(_context);
        }

        public IActionResult Index()
        {
            var ip = _accessor.ActionContext.HttpContext.Connection.RemoteIpAddress.ToString();
            _requestService.LogRequest(ip);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
