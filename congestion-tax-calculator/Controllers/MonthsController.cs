using congestion_tax_calculator.Data;
using congestion_tax_calculator.Models.Holidays;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace congestion_tax_calculator.Controllers
{
    public class MonthsController : Controller
    {
        private readonly congestion_tax_calculatorContext _context;

        public MonthsController(congestion_tax_calculatorContext context)
        {
            _context = context;
        }

        // GET: Months
        public async Task<IActionResult> Index()
        {
            return View(await _context.Month.OrderBy(s=>s.Number).ToListAsync());
        }

 

        // GET: Months/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Months/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number")] Month month)
        {
            if (_context.Month.Any(s => s.Number.Equals(month.Number)) || month.Number <1 || month.Number>12)
            {
                return RedirectToAction(nameof(Index));

            }
            _context.Add(month);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

 


        // GET: Months/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
      

            var month = await _context.Month
                .FirstOrDefaultAsync(m => m.Id == id);
            if (month == null)
            {
                return NotFound();
            }

            return View(month);
        }

        // POST: Months/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var month = await _context.Month.FindAsync(id);
            if (month != null)
            {
                _context.Month.Remove(month);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
