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
    public class StationMastersController : ControllerBase
    {
        private readonly DBIndiaProjectContext _context;

        public StationMastersController(DBIndiaProjectContext context)
        {
            _context = context;
        }

        // GET: api/StationMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationMaster>>> GetStationMasters()
        {
          if (_context.StationMasters == null)
          {
              return NotFound();
          }
            return await _context.StationMasters.ToListAsync();
        }

        // GET: api/StationMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StationMaster>> GetStationMaster(string id)
        {
          if (_context.StationMasters == null)
          {
              return NotFound();
          }
            var stationMaster = await _context.StationMasters.FindAsync(id);

            if (stationMaster == null)
            {
                return NotFound();
            }

            return stationMaster;
        }

        // PUT: api/StationMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStationMaster(string id, StationMaster stationMaster)
        {
            if (id != stationMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(stationMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationMasterExists(id))
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

        // POST: api/StationMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StationMaster>> PostStationMaster(StationMaster stationMaster)
        {
          if (_context.StationMasters == null)
          {
              return Problem("Entity set 'DBIndiaProjectContext.StationMasters'  is null.");
          }
            _context.StationMasters.Add(stationMaster);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StationMasterExists(stationMaster.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStationMaster", new { id = stationMaster.Id }, stationMaster);
        }

        // DELETE: api/StationMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStationMaster(string id)
        {
            if (_context.StationMasters == null)
            {
                return NotFound();
            }
            var stationMaster = await _context.StationMasters.FindAsync(id);
            if (stationMaster == null)
            {
                return NotFound();
            }

            _context.StationMasters.Remove(stationMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StationMasterExists(string id)
        {
            return (_context.StationMasters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
