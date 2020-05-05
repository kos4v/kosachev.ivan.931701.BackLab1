using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using kosachev.ivan._931701.backlab2.Models;
using System.Collections.Specialized;

namespace kosachev.ivan._931701.backlab2.Controllers
{
    public class CalcController : Controller
    {

        public IActionResult Manual()
        {
            if (Request.Method != "POST")
            {
                return View();
            }
            else
            {
                Calc calc = new Calc();
                calc.First = Request.Form["First"];
                calc.Second = Request.Form["Second"];
                calc.Operand = Request.Form["Operand"];
                double x;
                if (double.TryParse(calc.First,out x) & double.TryParse(calc.Second, out x))
                {
                    calc.Result = Calculate.Solution(calc.First, calc.Second, calc.Operand);
                    return View("~/Views/Calc/ResultManual.cshtml", calc);
                }
                else
                    return View(); 
            }

        }

        [HttpGet]
        public IActionResult ManualWithSeparateHandlers()
        {
                return View();
        }

        [HttpPost]
        public IActionResult ManualWithSeparateHandlers(string str  )
        {

            Calc calc = new Calc();
            calc.First = Request.Form["First"];
            calc.Second = Request.Form["Second"];
            calc.Operand = Request.Form["Operand"];
            double x;
            if (double.TryParse(calc.First, out x) & double.TryParse(calc.Second, out x))
            {
                calc.Result = Calculate.Solution(calc.First, calc.Second, calc.Operand);
                return View("~/Views/Calc/ResultManual.cshtml", calc);
            }
            else return View();

        }


        [HttpGet]
        public IActionResult ModelBindingsInParametrs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ModelBindingsInParametrs(string First, string Second, string Operand)
        {
            double x;
            if (double.TryParse(First, out x) & double.TryParse(Second, out x))
            {
                SetViewData(First, Second, Operand);
                return View("~/Views/Calc/Result.cshtml");
            }
            else
            return View();
        }
      
      
        [HttpGet]
        public IActionResult ModelBindingsInSeparateModel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ModelBindingsInSeparateModel(Calc calc)
        {
            double x;
            if (double.TryParse(calc.First,out x)  & double.TryParse(calc.Second,out x))
            {
                SetViewData(calc.First, calc.Second, calc.Operand);
                return View("~/Views/Calc/Result.cshtml");
            }
            return View();
        }

        public IActionResult ResultManual()
        {
            return View();
        }
        public IActionResult Result()
        {
            return View();
        }
        private void SetViewData(string First, string Second, string Operand)
        {
            ViewData["First"] = First;
            ViewData["Second"] = Second;
            ViewData["Operand"] = Operand;
            ViewData["Result"]  = Calculate.Solution(First, Second, Operand);
        }

    }
}