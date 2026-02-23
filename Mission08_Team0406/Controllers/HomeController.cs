using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0406.Models;

namespace Mission08_Team0406.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTask()
        {
            return View();
        }
    }
}
