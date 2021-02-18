using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: /Calculator/
        //public string Index()
        //{
        //    return "This is my default action...";
        //}
        public IActionResult Index()
        {
            return View();
        }

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
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
