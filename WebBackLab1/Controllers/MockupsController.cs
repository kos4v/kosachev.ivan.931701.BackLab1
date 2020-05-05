using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebBackLab1.Controllers
{
    public class MockupsController : Controller
    {
        public IActionResult Mockups()
        {
            return View();
        }
    }
}