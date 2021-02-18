using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Calculator.Data;
using Calculator.Models;

namespace Calculator.Controllers
{
    public class CalculatorsController : Controller
    {
        private readonly MvcMovieContext _context;

        public CalculatorsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Calculators
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }

        // GET: Calculators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculator = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calculator == null)
            {
                return NotFound();
            }

            return View(calculator);
        }

        // GET: Calculators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Calculators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Models.Calculator calculator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calculator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(calculator);
        }

        // GET: Calculators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculator = await _context.Movie.FindAsync(id);
            if (calculator == null)
            {
                return NotFound();
            }
            return View(calculator);
        }

        // POST: Calculators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Models.Calculator calculator)
        {
            if (id != calculator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calculator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalculatorExists(calculator.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(calculator);
        }

        // GET: Calculators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculator = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calculator == null)
            {
                return NotFound();
            }

            return View(calculator);
        }

        // POST: Calculators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calculator = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(calculator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalculatorExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
