using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebBackLab1.Models;

namespace WebBackLab1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
           
        }

        public IActionResult Index()
        {
            AppdbContext _context = new AppdbContext();
            if (_context.Folders.FirstOrDefault(m => m.Id > 0) == null)
            {
                _context.Folders.Add(new Folder() { Id = 0, Name = "root", });
            }
            _context.SaveChanges();
            if (User.Identity.Name == null)
            {
                @ViewData["LogIn"] = "Log in";
                @ViewData["Register"] = "Register";
            }
            else
            {
                @ViewData["LogIn"] = "Log out";
                @ViewData["Register"] = "!" + ("Hello, " + User.Identity.Name) ;
            }
            return View();
        }

    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}