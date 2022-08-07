using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoomAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassAPIController : ControllerBase
    {
        private readonly DataContext _context;

        public ClassAPIController(DataContext context)
        {
            _context = context;
        }
        // GET: All Student in Classes
        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            
            return Ok(await _context.Classes.ToListAsync());
        }

        // GET: 1 Student in Classes
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Student>>> Get(int id)
        {
            var singleStudent = await _context.Classes.FindAsync(id);
            if(singleStudent == null)
            {
                return BadRequest("Student not found!");
            }
            return Ok(singleStudent);
        }

        // POST: Add Student to Classes
        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddStudent(Student student)
        {
            _context.Classes.Add(student);

            await _context.SaveChangesAsync();
            return Ok(await _context.Classes.ToListAsync());
        }

        // PUT: Modify Student in Classes
        [HttpPut]
        public async Task<ActionResult<List<Student>>> ModifyStudent(Student reqStudent)
        {
            var singleStudent = await _context.Classes.FindAsync(reqStudent.Id);
            if (singleStudent == null)
            {
                return BadRequest("Student not found!");
            }

            singleStudent.FirstName = reqStudent.FirstName;
            singleStudent.LastName = reqStudent.LastName;
            singleStudent.Place = reqStudent.Place;

            await _context.SaveChangesAsync();
            return Ok(await _context.Classes.ToListAsync());
        }

        //DELETE: Delete Student in Classes
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int id)
        {
            var singleStudent = await _context.Classes.FindAsync(id);
            if (singleStudent == null)
            {
                return BadRequest("Student not found!");
            }

            _context.Classes.Remove(singleStudent);

            await _context.SaveChangesAsync();

            return Ok(await _context.Classes.ToListAsync());
        }
    }
}
