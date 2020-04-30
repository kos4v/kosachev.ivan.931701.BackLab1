using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebBackLab1.Models;

namespace WebBackLab1.Controllers
{
    public class Oper
    {
        public String First { get; set; }
        public String Second { get; set; }
        public String Add { get; set; }
        public String Sub { get; set; }
        public String Mult { get; set; }
        public String Div { get; set; }
    }
    public class CalcServiceController : Controller
    {
        private readonly ILogger<HomeController> _logger;
      
        public CalcServiceController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult PassUsingModel()
        {
            Oper oper = new Oper();
            double First, Second;
            var random = new Random();
            First = random.Next() % 11;
            Second = random.Next() % 11;
            oper.First = "" + First;
            oper.Second = "" + Second;
            oper.Add = "" + (First + Second);
            oper.Sub = "" + (First - Second);
            oper.Mult = "" + (First * Second);
            oper.Div = "" + (First / Second);
            return View(oper);
        }

        public IActionResult PassUsingViewData()
        {
            double First, Second;
            var random = new Random();
            First = random.Next() % 11;
            Second =  random.Next() % 11;
            ViewData["First"] = "" + First;
            ViewData["Second"] = "" + Second;
            ViewData["Add"] = "" + (First + Second);
            ViewData["Sub"] = "" + (First - Second);
            ViewData["Mult"]= "" + (First * Second);
            ViewData["Div"] = "" + (First / Second);
            return View();
        }

        public IActionResult PassUsingBag()
        {

            double First, Second;
            var random = new Random();
            First = random.Next() % 11;
            Second = random.Next() % 11;
            ViewBag.Numbers = new List<string> { "Rand Value First : " + First, "Rand Value Second : " + Second };
            ViewBag.Operations = new List<string>
            {  "Add : ", "" + First + " + " + Second + " = " + (First + Second),
               "Sub : ", "" + First + " - " + Second + " = " + (First - Second),
               "Mult : ","" + First + " * " + Second + " = " + (First * Second),
               "Div : ", "" + First + " / " + Second + " = " + (First / Second)};
            return View();
        }

        public IActionResult AcessServiceDirectly()
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
