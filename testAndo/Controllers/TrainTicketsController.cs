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
    public class TrainTicketsController : ControllerBase
    {
        private readonly DBIndiaProjectContext _context;

        public TrainTicketsController(DBIndiaProjectContext context)
        {
            _context = context;
        }

        // GET: api/TrainTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainTickets>>> GetTrainTickets()
        {
          if (_context.TrainTickets == null)
          {
              return NotFound();
          }
            return await _context.TrainTickets.ToListAsync();
        }

        // GET: api/TrainTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainTickets>> GetTrainTickets(string id)
        {
          if (_context.TrainTickets == null)
          {
              return NotFound();
          }
            var trainTickets = await _context.TrainTickets.FindAsync(id);

            if (trainTickets == null)
            {
                return NotFound();
            }

            return trainTickets;
        }

        // PUT: api/TrainTickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainTickets(string id, TrainTickets trainTickets)
        {
            if (id != trainTickets.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainTickets).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainTicketsExists(id))
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

        // POST: api/TrainTickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrainTickets>> PostTrainTickets(TrainTickets trainTickets)
        {
          if (_context.TrainTickets == null)
          {
              return Problem("Entity set 'DBIndiaProjectContext.TrainTickets'  is null.");
          }
            _context.TrainTickets.Add(trainTickets);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrainTicketsExists(trainTickets.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrainTickets", new { id = trainTickets.Id }, trainTickets);
        }

        // DELETE: api/TrainTickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainTickets(string id)
        {
            if (_context.TrainTickets == null)
            {
                return NotFound();
            }
            var trainTickets = await _context.TrainTickets.FindAsync(id);
            if (trainTickets == null)
            {
                return NotFound();
            }

            _context.TrainTickets.Remove(trainTickets);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainTicketsExists(string id)
        {
            return (_context.TrainTickets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
