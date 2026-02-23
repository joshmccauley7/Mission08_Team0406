using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0406.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Task is required")]
        public string Task { get; set; }

        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Quadrant is required")]
        [Range(1, 4, ErrorMessage = "Quadrant must be between 1 and 4")]
        public int Quadrant { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public bool Completed { get; set; }
    }
}
