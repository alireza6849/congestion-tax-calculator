using congestion_tax_calculator.Data;
using congestion_tax_calculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace congestion_tax_calculator.Controllers
{
    public class TaxRulesController : Controller
    {
        private readonly congestion_tax_calculatorContext _context;

        public TaxRulesController(congestion_tax_calculatorContext context)
        {
            _context = context;
        }

        // GET: TaxRules
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaxRule.ToListAsync());
        }

        // GET: TaxRules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxRule = await _context.TaxRule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxRule == null)
            {
                return NotFound();
            }

            return View(taxRule);
        }

        // GET: TaxRules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaxRules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FromTime,ToTime,Amount")] TaxRule taxRule)
        {
            if (ModelState.IsValid)
            {
                //if (taxRule.FromTime >= taxRule.ToTime)
                //{
                  
                //    TempData["error"] = "FromTime is Bigger Than ToTime";
                //    return View(taxRule);

                //}
                _context.Add(taxRule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taxRule);
        }

        // GET: TaxRules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxRule = await _context.TaxRule.FindAsync(id);
            if (taxRule == null)
            {
                return NotFound();
            }
            return View(taxRule);
        }

        // POST: TaxRules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FromTime,ToTime,Amount")] TaxRule taxRule)
        {
            if (id != taxRule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (taxRule.FromTime >= taxRule.ToTime)
                    {

                        TempData["error"] = "FromTime is Bigger Than ToTime";
                        return View(taxRule);

                    }
                    _context.Update(taxRule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxRuleExists(taxRule.Id))
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
            return View(taxRule);
        }

        // GET: TaxRules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxRule = await _context.TaxRule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxRule == null)
            {
                return NotFound();
            }

            return View(taxRule);
        }

        // POST: TaxRules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxRule = await _context.TaxRule.FindAsync(id);
            if (taxRule != null)
            {
                _context.TaxRule.Remove(taxRule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxRuleExists(int id)
        {
            return _context.TaxRule.Any(e => e.Id == id);
        }
    }
}
