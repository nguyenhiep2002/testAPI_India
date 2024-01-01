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
    public class TrainSchedulesController : ControllerBase
    {
        private readonly DBIndiaProjectContext _context;

        public TrainSchedulesController(DBIndiaProjectContext context)
        {
            _context = context;
        }

        // GET: api/TrainSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainSchedule>>> GetTrainSchedules()
        {
          if (_context.TrainSchedules == null)
          {
              return NotFound();
          }
            return await _context.TrainSchedules.ToListAsync();
        }

        // GET: api/TrainSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrainSchedule>> GetTrainSchedule(string id)
        {
          if (_context.TrainSchedules == null)
          {
              return NotFound();
          }
            var trainSchedule = await _context.TrainSchedules.FindAsync(id);

            if (trainSchedule == null)
            {
                return NotFound();
            }

            return trainSchedule;
        }

        // PUT: api/TrainSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainSchedule(string id, TrainSchedule trainSchedule)
        {
            if (id != trainSchedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainScheduleExists(id))
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

        // POST: api/TrainSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrainSchedule>> PostTrainSchedule(TrainSchedule trainSchedule)
        {
          if (_context.TrainSchedules == null)
          {
              return Problem("Entity set 'DBIndiaProjectContext.TrainSchedules'  is null.");
          }
            _context.TrainSchedules.Add(trainSchedule);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)   
            {
                if (TrainScheduleExists(trainSchedule.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrainSchedule", new { id = trainSchedule.Id }, trainSchedule);
        }

        // DELETE: api/TrainSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainSchedule(string id)
        {
            if (_context.TrainSchedules == null)
            {
                return NotFound();
            }
            var trainSchedule = await _context.TrainSchedules.FindAsync(id);
            if (trainSchedule == null)
            {
                return NotFound();
            }

            _context.TrainSchedules.Remove(trainSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainScheduleExists(string id)
        {
            return (_context.TrainSchedules?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
