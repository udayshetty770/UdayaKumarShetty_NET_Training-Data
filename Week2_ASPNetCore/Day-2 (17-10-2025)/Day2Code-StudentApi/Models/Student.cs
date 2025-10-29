using System.ComponentModel.DataAnnotations;

namespace StudentApi.Models
{
    public partial class Student
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; } = null!;

        [Range(1, 100)]
        public int Age { get; set; }

        [StringLength(10)]
        public string? Grade { get; set; }
    }
}
