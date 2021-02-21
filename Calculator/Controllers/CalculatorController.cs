using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Calculator.Models;
using Calculator.Services;

namespace Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _service;

        public CalculatorController(CalculatorService service)
        {
            _service = service;
        }

        //GET: api/Calculator/add/2,1
        [HttpGet("add/{numbers}")]
        public async Task<ActionResult<CalculatorResponseModel>> Add(string numbers)
        {
            var result = await _service.AddAsync(numbers);

            return result;
        }

        //GET: api/Calculator/subtract/5,3
        [HttpGet("subtract/{numbers}")]
        public async Task<ActionResult<CalculatorResponseModel>> Subtract(string numbers)
        {
            var result = await _service.SubtractAsync(numbers);

            return result;
        }

        //GET: api/Calculator/multiply/5,3
        [HttpGet("multiply/{numbers}")]
        public async Task<ActionResult<CalculatorResponseModel>> Multiply(string numbers)
        {
            var result = await _service.MultiplyAsync(numbers);

            return result;
        }

        //GET: api/Calculator/divide/10,2
        [HttpGet("divide/{numbers}")]
        public async Task<ActionResult<CalculatorResponseModel>> Divide(string numbers)
        {
            var result = await _service.DivideAsync(numbers);

            return result;
        }


        // GET: /Calculator/
        //public string Index()
        //{
        //    return "This is my default action...";
        //}
        //public IActionResult Index()
        //{
        //    return View();
        //}

        // GET: /Calculator/Welcome/
        //public string Welcome()
        //{
        //    return "This is the Welcome action method...";
        //}
        //public string Welcome(string name, int numTimes = 1)
        //{
        //    return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        //}

        //public string Welcome(string name, int ID = 1)
        //{
        //    return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        //}
        //public IActionResult Welcome(string name, int numTimes = 1)
        //{
        //    ViewData["Message"] = "Hello " + name;
        //    ViewData["NumTimes"] = numTimes;

        //    return View();
        //}
    }
}
