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
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;
        }

        // GET: api/Categories
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        //{
        //    return await _context.Category.ToListAsync();
        //}
        public async Task<IActionResult> GetCategories()
        {
            var category = await _unitofwork.Category.GetAll();
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
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _unitofwork.Category.Get(q => q.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            //_context.Entry(category).State = EntityState.Modified;
            _unitofwork.Category.Update(category);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitofwork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!CategoryExists(id))
                if (!await CategoryExists(id))
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
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            //_context.Category.Add(category);
            //await _context.SaveChangesAsync();
            await _unitofwork.Category.Insert(category);
            await _unitofwork.Save(HttpContext);

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            //var category = await _context.Category.FindAsync(id);
            var category = await _unitofwork.Category.Get(q => q.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            //_context.Category.Remove(category);
            //await _context.SaveChangesAsync();
            await _unitofwork.Category.Delete(id);
            await _unitofwork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> CategoryExists(int id)
        {
            //return _context.Category.Any(e => e.Id == id);
            var category = await _unitofwork.Category.Get(q => q.Id == id);
            return category != null;
        }
    }
}
