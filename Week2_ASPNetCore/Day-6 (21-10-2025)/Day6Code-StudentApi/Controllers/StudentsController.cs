using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentCourseContext _context;

        public StudentsController(StudentCourseContext context)
        {
            _context = context;
        }

        // GET all students
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _context.Students.FromSqlRaw("EXEC GetAllStudents").ToList();

            return Ok(students);
        }

        // GET by ID
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var idParam = new SqlParameter("@Id", id);
            var student = _context.Students.FromSqlRaw("EXEC sp_GetStudentById @Id", idParam).ToList();
            return Ok(student);
        }

        // POST Add new student
        [HttpPost]
        public IActionResult AddStudent(Student s)
        {
            _context.Database.ExecuteSqlRaw(
                "EXEC sp_AddStudent @p0, @p1, @p2, @p3",
                s.Name, s.Age, s.Grade, s.CourseId);
            return Ok("Student added successfully");
        }

        // PUT Update student
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student s)
        {
            _context.Database.ExecuteSqlRaw(
                "EXEC sp_UpdateStudent @p0, @p1, @p2, @p3, @p4",
                id, s.Name, s.Age, s.Grade, s.CourseId);
            return Ok("Student updated successfully");
        }

        // DELETE student
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            _context.Database.ExecuteSqlRaw("EXEC sp_DeleteStudent @p0", id);
            return Ok("Student deleted successfully");
        }
    }

   
}
