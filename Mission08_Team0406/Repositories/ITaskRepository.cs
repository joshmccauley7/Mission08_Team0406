using Mission08_Team0406.Models;

namespace Mission08_Team0406.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<TaskItem> GetAllTasks();
        TaskItem GetTaskById(int id);
        void AddTask(TaskItem task);
        void UpdateTask(TaskItem task);
        void DeleteTask(int id);
        IEnumerable<Category> GetAllCategories();
    }
}
