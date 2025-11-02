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
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ApplicationDbContext context, ILogger<StudentsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/students
        [HttpGet]
        public IActionResult GetStudents()
        {
            try
            {
                var students = _context.Students.FromSqlRaw("EXEC sp_GetStudents").ToList();
                return Ok(students);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetStudents");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/students/{id}
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            try
            {
                var student = _context.Students
                    .FromSqlRaw("EXEC sp_GetStudentById @Id={0}", id)
                    .AsEnumerable()
                    .FirstOrDefault();

                if (student == null) return NotFound();
                return Ok(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetStudentById");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/students
        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            if (student == null) return BadRequest("Student is null");
            if (string.IsNullOrWhiteSpace(student.Name)) return BadRequest("Name required");
            if (student.Age < 1 || student.Age > 100) return BadRequest("Age must be 1..100");

            try
            {
                _context.Database.ExecuteSqlRaw(
                    "EXEC sp_AddStudent @Name={0}, @Age={1}, @Grade={2}, @CourseId={3}",
                    student.Name, student.Age, student.Grade, student.CourseId);

                return Ok(new { message = "Student added successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in AddStudent");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/students/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            if (student == null) return BadRequest("Student is null");
            try
            {
                _context.Database.ExecuteSqlRaw(
                    "EXEC sp_UpdateStudent @Id={0}, @Name={1}, @Age={2}, @Grade={3}, @CourseId={4}",
                    id, student.Name, student.Age, student.Grade, student.CourseId);

                return Ok(new { message = "Student updated successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateStudent");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/students/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                _context.Database.ExecuteSqlRaw("EXEC sp_DeleteStudent @Id={0}", id);
                return Ok(new { message = "Student deleted successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeleteStudent");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
