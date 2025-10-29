using System.ComponentModel.DataAnnotations;

namespace StudentApi.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100")]
        public int Age { get; set; }

        [StringLength(10, ErrorMessage = "Grade cannot exceed 10 characters")]
        public string? Grade { get; set; }
    }
}
