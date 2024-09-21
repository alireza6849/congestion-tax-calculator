using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using congestion_tax_calculator.Data;
using congestion_tax_calculator.Models.Holidays;

namespace congestion_tax_calculator.Controllers
{
    public class DaysOfMonthsController : Controller
    {
        private readonly congestion_tax_calculatorContext _context;

        public DaysOfMonthsController(congestion_tax_calculatorContext context)
        {
            _context = context;
        }

        // GET: DaysOfMonths
        public async Task<IActionResult> Index()
        {
            var congestion_tax_calculatorContext = _context.DaysOfMonth.Include(d => d.Month);
            return View(await congestion_tax_calculatorContext.ToListAsync());
        }

        // GET: DaysOfMonths/Create
        public IActionResult Create()
        {
            ViewData["MonthId"] = new SelectList(_context.Month, "Id", "Number");
            return View();
        }

        // POST: DaysOfMonths/Create
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,MonthId")] DaysOfMonth daysOfMonth)
        {
            if (_context.DaysOfMonth.Any(s=>s.MonthId.Equals( daysOfMonth.MonthId) && s.Number.Equals(daysOfMonth.Number) ) || daysOfMonth.Number < 1) {
                return RedirectToAction(nameof(Index));


            }

            _context.Add(daysOfMonth);
                await _context.SaveChangesAsync();
            ViewData["MonthId"] = new SelectList(_context.Month, "Id", "Number", daysOfMonth.MonthId);
                return RedirectToAction(nameof(Index));

        }


        // GET: DaysOfMonths/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daysOfMonth = await _context.DaysOfMonth
                .Include(d => d.Month)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (daysOfMonth == null)
            {
                return NotFound();
            }

            return View(daysOfMonth);
        }

        // POST: DaysOfMonths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var daysOfMonth = await _context.DaysOfMonth.FindAsync(id);
            if (daysOfMonth != null)
            {
                _context.DaysOfMonth.Remove(daysOfMonth);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DaysOfMonthExists(int id)
        {
            return _context.DaysOfMonth.Any(e => e.Id == id);
        }
    }
}
