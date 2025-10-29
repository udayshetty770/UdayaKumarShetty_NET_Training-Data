using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            try
            {
                var students = _context.Students
                    .FromSqlRaw("EXEC GetAllStudents")
                    .ToList();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var student = _context.Students
                    .FromSqlRaw("EXEC sp_GetStudentById @Id={0}", id)
                    .AsEnumerable()
                    .FirstOrDefault();

                if (student == null)
                    return NotFound($"Student with ID {id} not found.");

                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            try
            {
                _context.Database.ExecuteSqlRaw(
                    "EXEC sp_AddStudent @Name={0}, @Age={1}, @Grade={2}, @CourseId={3}",
                    student.Name, student.Age, student.Grade, student.CourseId);
                return Ok("Student added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            try
            {
                _context.Database.ExecuteSqlRaw(
                    "EXEC sp_UpdateStudent @Id={0}, @Name={1}, @Age={2}, @Grade={3}, @CourseId={4}",
                    id, student.Name, student.Age, student.Grade, student.CourseId);
                return Ok("Student updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                _context.Database.ExecuteSqlRaw("EXEC sp_DeleteStudent @Id={0}", id);
                return Ok("Student deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
