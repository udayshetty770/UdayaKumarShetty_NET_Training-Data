using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCourseAPI.Data;
using StudentCourseAPI.Models;

namespace StudentCourseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public StudentsController(StudentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetStudents()
        {
            // LINQ with Include and Projection
            var result = await _context.Students
                .Include(s => s.Course)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.Age,
                    s.Grade,
                    Course = s.Course!.CourseName
                })
                .ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudents), new { id = student.Id }, student);
        }

        [HttpGet("by-course/{courseId}")]
        public async Task<ActionResult<IEnumerable<object>>> GetStudentsByCourse(int courseId)
        {
            var students = await _context.Students
                .Where(s => s.CourseId == courseId)
                .Select(s => new { s.Name, s.Grade })
                .ToListAsync();

            return Ok(students);
        }

        [HttpGet("group-by-course")]
        public async Task<ActionResult<IEnumerable<object>>> GetStudentCountByCourse()
        {
            var groupResult = await _context.Students
                .Include(s => s.Course)
                .GroupBy(s => s.Course!.CourseName)
                .Select(g => new
                {
                    Course = g.Key,
                    StudentCount = g.Count()
                })
                .ToListAsync();

            return Ok(groupResult);
        }
    }
}
