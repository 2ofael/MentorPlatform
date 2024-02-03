using HomeRent.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MentorsController(ApplicationDbContext applicationDbContext)
        {

            _context = applicationDbContext;
        }


        [HttpGet]
        public IActionResult GetMentors()
        {

            return Ok(_context.Mentors);
        }


        [HttpGet("{id}")]
        public IActionResult GetMentorById(int id)
        {

            return Ok(_context.Mentors.Where(m => m.Id == id));
        }

        [HttpPost]
        public IActionResult CreateMentor([FromBody] Mentor mentor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            _context.Mentors.Add(mentor);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetMentorById), new { id = mentor.Id }, mentor);






        }
        [HttpPut("{id}")]
        public IActionResult UpdateMentor(int id, [FromBody] Mentor mentor)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Mentors.Update(mentor);
            _context.SaveChanges();

            return Ok(mentor);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMentor(int id)
        {

            Mentor mentor = _context.Mentors.Find(id);
            if (mentor == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Mentors.Remove(mentor);
            _context.SaveChanges();

            return Ok(mentor);
        }

    }
}
