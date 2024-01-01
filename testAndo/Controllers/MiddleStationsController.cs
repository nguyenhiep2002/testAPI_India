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
    public class MiddleStationsController : ControllerBase
    {
        private readonly DBIndiaProjectContext _context;

        public MiddleStationsController(DBIndiaProjectContext context)
        {
            _context = context;
        }

        // GET: api/MiddleStations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MiddleStation>>> GetMiddleStations()
        {
          if (_context.MiddleStations == null)
          {
              return NotFound();
          }
            return await _context.MiddleStations.ToListAsync();
        }

        // GET: api/MiddleStations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MiddleStation>> GetMiddleStation(string id)
        {
          if (_context.MiddleStations == null)
          {
              return NotFound();
          }
            var middleStation = await _context.MiddleStations.FindAsync(id);

            if (middleStation == null)
            {
                return NotFound();
            }

            return middleStation;
        }

        // PUT: api/MiddleStations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiddleStation(string id, MiddleStation middleStation)
        {
            if (id != middleStation.Id)
            {
                return BadRequest();
            }

            _context.Entry(middleStation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiddleStationExists(id))
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

        // POST: api/MiddleStations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MiddleStation>> PostMiddleStation(MiddleStation middleStation)
        {
          if (_context.MiddleStations == null)
          {
              return Problem("Entity set 'DBIndiaProjectContext.MiddleStations'  is null.");
          }
            _context.MiddleStations.Add(middleStation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MiddleStationExists(middleStation.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMiddleStation", new { id = middleStation.Id }, middleStation);
        }

        // DELETE: api/MiddleStations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiddleStation(string id)
        {
            if (_context.MiddleStations == null)
            {
                return NotFound();
            }
            var middleStation = await _context.MiddleStations.FindAsync(id);
            if (middleStation == null)
            {
                return NotFound();
            }

            _context.MiddleStations.Remove(middleStation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MiddleStationExists(string id)
        {
            return (_context.MiddleStations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
