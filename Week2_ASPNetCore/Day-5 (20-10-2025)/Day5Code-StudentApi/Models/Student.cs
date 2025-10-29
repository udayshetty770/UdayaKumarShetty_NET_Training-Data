using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCourseAPI.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(1, 100)]
        public int Age { get; set; }

        [StringLength(5)]
        public string? Grade { get; set; }

        // Foreign Key
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        // Navigation Property
        public Course? Course { get; set; }
    }
}
