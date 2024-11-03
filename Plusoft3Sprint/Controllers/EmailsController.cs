using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plusoft3Sprint.Data;
using Plusoft3Sprint.Models;

namespace Plusoft3Sprint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : Controller
    {
        private readonly AppDbContext _context;

        public EmailsController(AppDbContext context)
        {
            _context = context;
        }

        //Get: api/Emails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Email>>> GetEmails()

        {
            return await _context.Emails.ToListAsync();
        }

        // GET: api/Emails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Email>> GetEmail(int id)
        {
            var email = await _context.Emails.FindAsync(id);

            if (email == null)
            {
                return NotFound();
            }

            return email;
        }



        //PUT: api/Emails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmail(int id, Email email)
        {
            if (id != email.Id)
            {
                return BadRequest();
            }

            _context.Entry(email).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Emails
        [HttpPost]
        public async Task<ActionResult<Email>> PostEmail(Email email)
        {

            _context.Emails.Add(email);


            await _context.SaveChangesAsync();


            return CreatedAtAction("GetEmail", new { id = email.Id }, email);
        }


        // DELETE: api/Emails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmail(int id)
        {
            var email = await _context.Emails.FindAsync(id);
            if (email == null)
            {
                return NotFound();
            }


            _context.Emails.Remove(email);
            await _context.SaveChangesAsync();
            return NoContent();

        }

        private bool EmailExists(int id)
        {
            return _context.Emails.Any(e => e.Id == id);
        }

    }
}
