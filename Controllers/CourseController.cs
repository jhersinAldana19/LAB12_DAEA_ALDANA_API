using LAB12_ALDANA_API.Context;
using LAB12_ALDANA_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB12_ALDANA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly MiDBContext _context;

        public CourseController(MiDBContext context)
        {
            _context = context;
        }

        // GET: api/Course
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null || course.IsDeleted)
            {
                return NotFound();
            }

            return course;
        }

        // POST: api/Course
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCourse), new { id = course.IdCourse }, course);
        }

        // PUT: api/Course/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.IdCourse)
            {
                return BadRequest();
            }

            var existingCourse = await _context.Courses.FindAsync(id);

            if (existingCourse == null || existingCourse.IsDeleted)
            {
                return NotFound();
            }

            existingCourse.Name = course.Name;
            existingCourse.Credit = course.Credit;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Course/5 (eliminación lógica)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null || course.IsDeleted)
            {
                return NotFound();
            }

            course.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
