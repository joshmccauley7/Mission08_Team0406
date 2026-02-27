using Microsoft.AspNetCore.Mvc;
using Mission08_Team0406.Models;
using Mission08_Team0406.Repositories;
using System.Diagnostics;

namespace Mission08_Team0406.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo;
        public HomeController(ITaskRepository temp) //Constructor
        {
            _repo = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTask()
        {
            ViewBag.Categories = _repo.GetAllCategories()
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View(new TaskItem());
        }
    }
}
