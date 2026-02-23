using Microsoft.EntityFrameworkCore;
using Mission08_Team0406.Models;

namespace Mission08_Team0406.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskItem> GetAllTasks()
        {
            return _context.Tasks.Include(t => t.Category).ToList();
        }

        public TaskItem GetTaskById(int id)
        {
            return _context.Tasks.Include(t => t.Category).FirstOrDefault(t => t.TaskId == id);
        }

        public void AddTask(TaskItem task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(TaskItem task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
