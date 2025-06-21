using LAB12_ALDANA_API.Context;
using LAB12_ALDANA_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB12_ALDANA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly MiDBContext _context;

        public GradeController(MiDBContext context)
        {
            _context = context;
        }

        // GET: api/Grade
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGrades()
        {
            return await _context.Grades
                .Where(g => !g.IsDeleted)
                .ToListAsync();
        }

        // GET: api/Grade/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> GetGrade(int id)
        {
            var grade = await _context.Grades.FindAsync(id);

            if (grade == null || grade.IsDeleted)
            {
                return NotFound();
            }

            return grade;
        }

        // POST: api/Grade
        [HttpPost]
        public async Task<ActionResult<Grade>> PostGrade(Grade grade)
        {
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGrade), new { id = grade.IdGrade }, grade);
        }

        // PUT: api/Grade/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrade(int id, Grade grade)
        {
            if (id != grade.IdGrade)
            {
                return BadRequest();
            }

            var existingGrade = await _context.Grades.FindAsync(id);

            if (existingGrade == null || existingGrade.IsDeleted)
            {
                return NotFound();
            }

            existingGrade.Name = grade.Name;
            existingGrade.Description = grade.Description;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Grade/5 (eliminación lógica)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var grade = await _context.Grades.FindAsync(id);

            if (grade == null || grade.IsDeleted)
            {
                return NotFound();
            }

            grade.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
