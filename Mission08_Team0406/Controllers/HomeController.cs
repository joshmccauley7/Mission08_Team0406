using Microsoft.AspNetCore.Mvc;
using Mission08_Team0406.Models;
using Mission08_Team0406.Repositories;

namespace Mission08_Team0406.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskRepository _repo;

        public HomeController(ITaskRepository temp)
        {
            _repo = temp;
        }

        /// <summary>
        /// Quadrants view: show only tasks that are not completed.
        /// </summary>
        public IActionResult Index()
        {
            var tasks = _repo.GetAllTasks()
                .Where(t => !t.Completed)
                .ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _repo.GetAllCategories()
                .OrderBy(c => c.CategoryName)
                .ToList();
            return View(new TaskItem());
        }

        [HttpPost]
        public IActionResult AddTask(TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                taskItem.Completed = false;
                _repo.AddTask(taskItem);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _repo.GetAllCategories()
                .OrderBy(c => c.CategoryName)
                .ToList();
            return View(taskItem);
        }

        [HttpGet]
        public IActionResult EditTask(int id)
        {
            var task = _repo.GetTaskById(id);
            if (task == null)
                return NotFound();

            ViewBag.Categories = _repo.GetAllCategories()
                .OrderBy(c => c.CategoryName)
                .ToList();
            return View("AddTask", task);
        }

        [HttpPost]
        public IActionResult EditTask(TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateTask(taskItem);
                return RedirectToAction("Index");
            }

            ViewBag.Categories = _repo.GetAllCategories()
                .OrderBy(c => c.CategoryName)
                .ToList();
            return View("AddTask", taskItem);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _repo.DeleteTask(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult MarkCompleted(int id)
        {
            var task = _repo.GetTaskById(id);
            if (task == null)
                return NotFound();

            task.Completed = true;
            _repo.UpdateTask(task);
            return RedirectToAction("Index");
        }
    }
}
