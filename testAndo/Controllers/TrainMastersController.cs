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
    public class TrainMastersController : ControllerBase
    {
        private readonly DBIndiaProjectContext _context;

        public TrainMastersController(DBIndiaProjectContext context)
        {
            _context = context;
        }

        // GET: api/TrainMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainMaster>>> GetTrainMasters()
        {
          if (_context.TrainMasters == null)
          {
              return NotFound();
          }
            return await _context.TrainMasters.ToListAsync();
        }

        // GET: api/TrainMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainMaster>> GetTrainMaster(string id)
        {
          if (_context.TrainMasters == null)
          {
              return NotFound();
          }
            var trainMaster = await _context.TrainMasters.FindAsync(id);

            if (trainMaster == null)
            {
                return NotFound();
            }

            return trainMaster;
        }

        // PUT: api/TrainMasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainMaster(string id, TrainMaster trainMaster)
        {
            if (id != trainMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainMasterExists(id))
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

        // POST: api/TrainMasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrainMaster>> PostTrainMaster(TrainMaster trainMaster)
        {
          if (_context.TrainMasters == null)
          {
              return Problem("Entity set 'DBIndiaProjectContext.TrainMasters'  is null.");
          }
            _context.TrainMasters.Add(trainMaster);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrainMasterExists(trainMaster.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrainMaster", new { id = trainMaster.Id }, trainMaster);
        }

        // DELETE: api/TrainMasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainMaster(string id)
        {
            if (_context.TrainMasters == null)
            {
                return NotFound();
            }
            var trainMaster = await _context.TrainMasters.FindAsync(id);
            if (trainMaster == null)
            {
                return NotFound();
            }

            _context.TrainMasters.Remove(trainMaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainMasterExists(string id)
        {
            return (_context.TrainMasters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
