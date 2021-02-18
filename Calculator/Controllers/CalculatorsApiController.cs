using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Calculator.Data;
using Calculator.Models;

namespace Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorsApiController : ControllerBase
    {
        private readonly MvcMovieContext _context;

        public CalculatorsApiController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: api/CalculatorsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Calculator>>> GetMovie()
        {
            return await _context.Movie.ToListAsync();
        }

        // GET: api/CalculatorsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Calculator>> GetCalculator(int id)
        {
            var calculator = await _context.Movie.FindAsync(id);

            if (calculator == null)
            {
                return NotFound();
            }

            return calculator;
        }

        // PUT: api/CalculatorsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalculator(int id, Models.Calculator calculator)
        {
            if (id != calculator.Id)
            {
                return BadRequest();
            }

            _context.Entry(calculator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalculatorExists(id))
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

        // POST: api/CalculatorsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.Calculator>> PostCalculator(Models.Calculator calculator)
        {
            _context.Movie.Add(calculator);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetCalculator", new { id = calculator.Id }, calculator);
            return CreatedAtAction(nameof(GetCalculator), new { id = calculator.Id }, calculator);
        }

        // DELETE: api/CalculatorsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalculator(int id)
        {
            var calculator = await _context.Movie.FindAsync(id);
            if (calculator == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(calculator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalculatorExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
