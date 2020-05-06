using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebBackLab1.Models;
namespace kosachev.ivan._931701.backlab2.Controllers
{
    public class MockupsController : Controller
    {
        [HttpGet]
        public IActionResult Quiz()
        {
            OperAndNumb opernumb = new OperAndNumb();
            return View(opernumb);
        }

        [HttpPost]
        public IActionResult Quiz(OperAndNumb opernumb, string action)
        {
            double number;
            if (double.TryParse(opernumb.YourAnswer, out number) & ModelState.IsValid)
            {
                TotalAndCorrectAns tawa = TotalAndCorrectAns.Instance;
                tawa.Total+= 1;
                opernumb.Solution(); 
                ViewData["NotANumber"] = "" + opernumb.First + 
                    "  ||  " + opernumb.Second;
                if (opernumb.RightOrWrong())
                    tawa.Correct += 1;
                (tawa.Answers).Add(opernumb);

            }
            else
                ViewData["NotANumber"] = "Not a number!";
            if (action == "Next")
                return View(new OperAndNumb());
            return RedirectToAction("QuizResult");
        }

      

        public IActionResult QuizResult()
        {
            TotalAndCorrectAns tawa = TotalAndCorrectAns.Instance;
            ViewBag.Result = tawa.Answers;
            ViewData["Correct"] = "" +tawa.Correct;
            ViewData["Total"] = "" + tawa.Total;
            return View();
        }

        public IActionResult Reset()
        {
            TotalAndCorrectAns t = TotalAndCorrectAns.Instance;
            t.Reset();
            return Redirect("https://localhost:44332/");
        }
    }
}