using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebBackLab1.Models;

namespace WebBackLab1.Controllers
{
    public class ControlsController : Controller
    {
        public IActionResult Controls()
        {
            return View();
        }
        public IActionResult TextBox()
        {
            return View();
        }
        public IActionResult TextArea()
        {
            return View();
        }
        public IActionResult CheckBox()
        {
            return View();
        }
        public IActionResult Radio()
        {
            return View();
        }
        public IActionResult DropDownList()
        {
            SetViewBag();
            return View();
        }
        public IActionResult ListBox()
        {
            SetViewBag();
            return View();
        }
        private void SetViewBag()
        {
            string[] months_str_mass = { "January", "February", "March", "April",
                "May", "June", "July", "August", "September", "October", "November", "December" };
            SelectList months_SList = new SelectList(months_str_mass, "month");
            ViewBag.Months = months_SList;
        }
    }
}