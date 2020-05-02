using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using kosachev.ivan._931701.backlab2.Models;

namespace kosachev.ivan._931701.backlab2.Controllers
{
    public class CalcController : Controller
    {

        [HttpGet]
        public IActionResult Manual()
        {
            return View();
        }

       [HttpPost]
        public IActionResult Manual(string First, string Second, string Operand)
        {
            if (First != null & Second != null)
            {
                ViewData["First"] = First;
                ViewData["Second"] = Second;
                ViewData["Operand"] = Operand;
                ViewData["Result"] = Calculate.Solution(First, Second, Operand);
                return View("~/Views/Calc/Result.cshtml");
            }
            else return View();
        }
        public IActionResult ManualWithSeparateHandlers()
        {
            return View();
        }
        public IActionResult ModelBindingsInParametrs()
        {
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
            if (calc.First != null & calc.Second != null)
            {
                ViewData["First"] = calc.First;
                ViewData["Second"] = calc.Second;
                ViewData["Operand"] = calc.Operand;
                ViewData["Result"] = Calculate.Solution(calc.First, calc.Second, calc.Operand);
                return View("~/Views/Calc/Result.cshtml");
            }
            return View();
                
        }


    }
}