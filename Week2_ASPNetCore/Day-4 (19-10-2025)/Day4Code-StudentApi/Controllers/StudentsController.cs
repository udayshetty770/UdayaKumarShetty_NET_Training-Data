using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Models;
using StudentApi.Models.DTOs;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDBContext _context;

        public StudentsController(StudentDBContext context)
        {
            _context = context;
        }

        // GET: api/students
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var students = await _context.Students.ToListAsync();
                return Ok(new { Success = true, Data = students });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = ex.Message });
            }
        }

        // GET: api/students/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                    return NotFound(new { Success = false, Message = "Student not found" });

                return Ok(new { Success = true, Data = student });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = ex.Message });
            }
        }

        // POST: api/students
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Success = false, Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });

            try
            {
                var student = new Student
                {
                    Name = studentDto.Name,
                    Age = studentDto.Age,
                    Grade = studentDto.Grade
                };

                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetStudentById), new { id = student.Id },
                    new { Success = true, Message = "Student added successfully", Data = student });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = ex.Message });
            }
        }

        // PUT: api/students/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Success = false, Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });

            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                    return NotFound(new { Success = false, Message = "Student not found" });

                student.Name = studentDto.Name;
                student.Age = studentDto.Age;
                student.Grade = studentDto.Grade;

                _context.Entry(student).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(new { Success = true, Message = "Student updated successfully", Data = student });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = ex.Message });
            }
        }

        // DELETE: api/students/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                    return NotFound(new { Success = false, Message = "Student not found" });

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                return Ok(new { Success = true, Message = "Student deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = ex.Message });
            }
        }
    }
}
