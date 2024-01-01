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
    public class PassengerDetailsController : ControllerBase
    {
        private readonly DBIndiaProjectContext _context;

        public PassengerDetailsController(DBIndiaProjectContext context)
        {
            _context = context;
        }

        // GET: api/PassengerDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PassengerDetail>>> GetPassengerDetails()
        {
          if (_context.PassengerDetails == null)
          {
              return NotFound();
          }
            return await _context.PassengerDetails.ToListAsync();
        }

        // GET: api/PassengerDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PassengerDetail>> GetPassengerDetail(string id)
        {
          if (_context.PassengerDetails == null)
          {
              return NotFound();
          }
            var passengerDetail = await _context.PassengerDetails.FindAsync(id);

            if (passengerDetail == null)
            {
                return NotFound();
            }

            return passengerDetail;
        }

        // PUT: api/PassengerDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassengerDetail(string id, PassengerDetail passengerDetail)
        {
            if (id != passengerDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(passengerDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerDetailExists(id))
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

        // POST: api/PassengerDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PassengerDetail>> PostPassengerDetail(PassengerDetail passengerDetail)
        {
          if (_context.PassengerDetails == null)
          {
              return Problem("Entity set 'DBIndiaProjectContext.PassengerDetails'  is null.");
          }
            _context.PassengerDetails.Add(passengerDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PassengerDetailExists(passengerDetail.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPassengerDetail", new { id = passengerDetail.Id }, passengerDetail);
        }

        // DELETE: api/PassengerDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassengerDetail(string id)
        {
            if (_context.PassengerDetails == null)
            {
                return NotFound();
            }
            var passengerDetail = await _context.PassengerDetails.FindAsync(id);
            if (passengerDetail == null)
            {
                return NotFound();
            }

            _context.PassengerDetails.Remove(passengerDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassengerDetailExists(string id)
        {
            return (_context.PassengerDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
