using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Server.Data;
using Project.Server.IRepository;
using Project.Shared.Domain;

namespace Project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;


        public AttendeesController(IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;
        }

        // GET: api/Categories
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Attendee>>> GetAttendee()
        //{
        //    return await _context.Attendee.ToListAsync();
        //}
        public async Task<IActionResult> GetAttendees()
        {
            var Attendee = await _unitofwork.Attendees.GetAll(includes: q => q.Include(x => x.Event).Include(x => x.Student));
            return Ok(Attendee);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Attendee>> GetAttendee(int id)
        //{
        //    var Attendee = await _context.Attendee.FindAsync(id);

        //    if (Attendee == null)
        //    {
        //        return NotFound();
        //    }

        //    return Attendee;
        //}
        public async Task<IActionResult> GetAttendee(int id)
        {
            var Attendee = await _unitofwork.Attendees.Get(q => q.Id == id);
            if (Attendee == null)
            {
                return NotFound();
            }
            return Ok(Attendee);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendee(int id, Attendees Attendee)
        {
            if (id != Attendee.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Attendee).State = EntityState.Modified;
            _unitofwork.Attendees.Update(Attendee);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitofwork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!AttendeeExists(id))
                if (!await AttendeeExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Attendees>> PostAttendee(Attendees Attendee)
        {
            //_context.Attendee.Add(Attendee);
            //await _context.SaveChangesAsync();
            await _unitofwork.Attendees.Insert(Attendee);
            await _unitofwork.Save(HttpContext);

            return CreatedAtAction("GetAttendee", new { id = Attendee.Id }, Attendee);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendee(int id)
        {
            //var Attendee = await _context.Attendee.FindAsync(id);
            var Attendee = await _unitofwork.Attendees.Get(q => q.Id == id);
            if (Attendee == null)
            {
                return NotFound();
            }

            //_context.Attendee.Remove(Attendee);
            //await _context.SaveChangesAsync();
            await _unitofwork.Attendees.Delete(id);
            await _unitofwork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> AttendeeExists(int id)
        {
            //return _context.Attendee.Any(e => e.Id == id);
            var Attendee = await _unitofwork.Attendees.Get(q => q.Id == id);
            return Attendee != null;
        }
    }
}

