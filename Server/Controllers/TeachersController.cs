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
    public class TeachersController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
       

        public TeachersController(IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;
        }

        // GET: api/Categories
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        //{
        //    return await _context.Category.ToListAsync();
        //}
        public async Task<IActionResult> GetTeachers()
        {
            var category = await _unitofwork.Teachers.GetAll();
            return Ok(category);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Category>> GetCategory(int id)
        //{
        //    var category = await _context.Category.FindAsync(id);

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return category;
        //}
        public async Task<IActionResult> GetTeachers(int id)
        {
            var category = await _unitofwork.Teachers.Get(q => q.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeachers(int id, Category Teachers)
        {
            if (id != Teachers.Id)
            {
                return BadRequest();
            }

            //_context.Entry(category).State = EntityState.Modified;
            _unitofwork.Category.Update(Teachers);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitofwork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!CategoryExists(id))
                if (!await TeachersExists(id))
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
        public async Task<ActionResult<Category>> PostTeachers(Teachers category)
        {
            //_context.Category.Add(category);
            //await _context.SaveChangesAsync();
            await _unitofwork.Teachers.Insert(category);
            await _unitofwork.Save(HttpContext);

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeachers(int id)
        {
            //var category = await _context.Category.FindAsync(id);
            var category = await _unitofwork.Teachers.Get(q => q.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            //_context.Category.Remove(category);
            //await _context.SaveChangesAsync();
            await _unitofwork.Teachers.Delete(id);
            await _unitofwork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> TeachersExists(int id)
        {
            //return _context.Category.Any(e => e.Id == id);
            var category = await _unitofwork.Category.Get(q => q.Id == id);
            return category != null;
        }
    }
}
