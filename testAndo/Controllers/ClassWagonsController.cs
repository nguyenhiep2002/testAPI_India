using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_INDIA.Models;

namespace testAndo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassWagonsController : ControllerBase
    {
        private readonly DBIndiaProjectContext _context;

        public ClassWagonsController(DBIndiaProjectContext context)
        {
            _context = context;
        }

        // GET: api/ClassWagons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassWagon>>> GetClassWagons()
        {
          if (_context.ClassWagons == null)
          {
              return NotFound();
          }
            return await _context.ClassWagons.ToListAsync();
        }

        // GET: api/ClassWagons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassWagon>> GetClassWagon(string id)
        {
          if (_context.ClassWagons == null)
          {
              return NotFound();
          }
            var classWagon = await _context.ClassWagons.FindAsync(id);

            if (classWagon == null)
            {
                return NotFound();
            }

            return classWagon;
        }

        // PUT: api/ClassWagons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassWagon(string id, ClassWagon classWagon)
        {
            if (id != classWagon.Id)
            {
                return BadRequest();
            }

            _context.Entry(classWagon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassWagonExists(id))
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

        // POST: api/ClassWagons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClassWagon>> PostClassWagon(ClassWagon classWagon)
        {
          if (_context.ClassWagons == null)
          {
              return Problem("Entity set 'DBIndiaProjectContext.ClassWagons'  is null.");
          }
            _context.ClassWagons.Add(classWagon);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClassWagonExists(classWagon.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClassWagon", new { id = classWagon.Id }, classWagon);
        }

        // DELETE: api/ClassWagons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassWagon(string id)
        {
            if (_context.ClassWagons == null)
            {
                return NotFound();
            }
            var classWagon = await _context.ClassWagons.FindAsync(id);
            if (classWagon == null)
            {
                return NotFound();
            }

            _context.ClassWagons.Remove(classWagon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassWagonExists(string id)
        {
            return (_context.ClassWagons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
