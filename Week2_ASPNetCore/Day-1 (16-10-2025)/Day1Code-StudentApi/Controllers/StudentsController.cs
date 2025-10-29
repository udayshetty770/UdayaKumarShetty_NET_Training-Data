using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        // temporary in-memory list
        private static List<Student> students = new List<Student>
        {
            new Student(1, "Udaya Kumar", 22, "A"),
            new Student(2, "Prajwal S", 23, "B")
        };

        // GET api/students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            return Ok(students);
        }

        // GET api/students/{id}
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound(new { message = "Student not found" });
            return Ok(student);
        }

        // POST api/students
        [HttpPost]
        public ActionResult AddStudent([FromBody] Student s)
        {
            if (s == null || string.IsNullOrEmpty(s.Name))
                return BadRequest(new { message = "Invalid data" });

            students.Add(s);
            return Ok(new { message = "Student added successfully" });
        }

        // DELETE api/students/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            students.Remove(student);
            return Ok(new { message = "Deleted successfully" });
        }
    }
}
