using System.ComponentModel.DataAnnotations;

namespace StudentCourseAPI.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required, StringLength(100)]
        public string CourseName { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
