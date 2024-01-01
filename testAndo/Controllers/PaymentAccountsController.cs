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
    public class PaymentAccountsController : ControllerBase
    {
        private readonly DBIndiaProjectContext _context;

        public PaymentAccountsController(DBIndiaProjectContext context)
        {
            _context = context;
        }

        // GET: api/PaymentAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentAccount>>> GetPaymentAccounts()
        {
          if (_context.PaymentAccounts == null)
          {
              return NotFound();
          }
            return await _context.PaymentAccounts.ToListAsync();
        }

        // GET: api/PaymentAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentAccount>> GetPaymentAccount(string id)
        {
          if (_context.PaymentAccounts == null)
          {
              return NotFound();
          }
            var paymentAccount = await _context.PaymentAccounts.FindAsync(id);

            if (paymentAccount == null)
            {
                return NotFound();
            }

            return paymentAccount;
        }

        // PUT: api/PaymentAccounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentAccount(string id, PaymentAccount paymentAccount)
        {
            if (id != paymentAccount.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentAccountExists(id))
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

        // POST: api/PaymentAccounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentAccount>> PostPaymentAccount(PaymentAccount paymentAccount)
        {
          if (_context.PaymentAccounts == null)
          {
              return Problem("Entity set 'DBIndiaProjectContext.PaymentAccounts'  is null.");
          }
            _context.PaymentAccounts.Add(paymentAccount);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PaymentAccountExists(paymentAccount.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPaymentAccount", new { id = paymentAccount.Id }, paymentAccount);
        }

        // DELETE: api/PaymentAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentAccount(string id)
        {
            if (_context.PaymentAccounts == null)
            {
                return NotFound();
            }
            var paymentAccount = await _context.PaymentAccounts.FindAsync(id);
            if (paymentAccount == null)
            {
                return NotFound();
            }

            _context.PaymentAccounts.Remove(paymentAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentAccountExists(string id)
        {
            return (_context.PaymentAccounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
