using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0406.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission08_Team0406.Controllers
{
    public class HomeController : Controller
    {
        private DbContext _context;
        public HomeController(DbContext temp) //Constructor
        {
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTask()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View(new TaskItem());
        }
    }
}
