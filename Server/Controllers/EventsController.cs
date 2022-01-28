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
    public class EventsController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;


        public EventsController(IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;
        }

        // GET: api/Categories
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Events>>> GetEvents()
        //{
        //    return await _context.Events.ToListAsync();
        //}
        public async Task<IActionResult> GetEvents()
        {
            var events = await _unitofwork.Events.GetAll(includes: q => q.Include(x => x.Category));
            return Ok(events);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Events>> GetEvents(int id)
        //{
        //    var Events = await _context.Events.FindAsync(id);

        //    if (Events == null)
        //    {
        //        return NotFound();
        //    }

        //    return Events;
        //}
        public async Task<IActionResult> GetEvents(int id)
        {
            var events = await _unitofwork.Events.Get(q => q.Id == id);
            if (events == null)
            {
                return NotFound();
            }
            return Ok(events);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvents(int id, Events Events)
        {
            if (id != Events.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Events).State = EntityState.Modified;
            _unitofwork.Events.Update(Events);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitofwork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!EventsExists(id))
                if (!await EventsExists(id))
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
        public async Task<ActionResult<Events>> PostEvents(Events Events)
        {
            //_context.Events.Add(Events);
            //await _context.SaveChangesAsync();
            await _unitofwork.Events.Insert(Events);
            await _unitofwork.Save(HttpContext);

            return CreatedAtAction("GetEvents", new { id = Events.Id }, Events);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvents(int id)
        {
            //var Events = await _context.Events.FindAsync(id);
            var Events = await _unitofwork.Events.Get(q => q.Id == id);
            if (Events == null)
            {
                return NotFound();
            }

            //_context.Events.Remove(Events);
            //await _context.SaveChangesAsync();
            await _unitofwork.Events.Delete(id);
            await _unitofwork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> EventsExists(int id)
        {
            //return _context.Events.Any(e => e.Id == id);
            var Events = await _unitofwork.Events.Get(q => q.Id == id);
            return Events != null;
        }
    }
}
