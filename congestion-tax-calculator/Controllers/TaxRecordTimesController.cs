using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using congestion_tax_calculator.Data;
using congestion_tax_calculator.Models.TaxRecords;

namespace congestion_tax_calculator.Controllers
{
    public class TaxRecordTimesController : Controller
    {
        private readonly congestion_tax_calculatorContext _context;

        public TaxRecordTimesController(congestion_tax_calculatorContext context)
        {
            _context = context;
        }

        // GET: TaxRecordTimes
        public async Task<IActionResult> Index()
        {
            var congestion_tax_calculatorContext = _context.TaxRecordTimes.Include(t => t.TaxRecord);
            return View(await congestion_tax_calculatorContext.ToListAsync());
        }

        // GET: TaxRecordTimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxRecordTime = await _context.TaxRecordTimes
                .Include(t => t.TaxRecord)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxRecordTime == null)
            {
                return NotFound();
            }

            return View(taxRecordTime);
        }

        // GET: TaxRecordTimes/Create
        public IActionResult Create()
        {
            ViewData["TaxRecordId"] = new SelectList(_context.TaxRecord, "Id", "LicensePlateNumber");
            return View();
        }

        // POST: TaxRecordTimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,TaxRecordId")] TaxRecordTime taxRecordTime)
        {
           
                _context.Add(taxRecordTime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            //ViewData["TaxRecordId"] = new SelectList(_context.TaxRecord, "Id", "LicensePlateNumber", taxRecordTime.TaxRecordId);
            //return View(taxRecordTime);
        }

        // GET: TaxRecordTimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxRecordTime = await _context.TaxRecordTimes.FindAsync(id);
            if (taxRecordTime == null)
            {
                return NotFound();
            }
            ViewData["TaxRecordId"] = new SelectList(_context.TaxRecord, "Id", "Id", taxRecordTime.TaxRecordId);
            return View(taxRecordTime);
        }

        // POST: TaxRecordTimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,TaxRecordId")] TaxRecordTime taxRecordTime)
        {
            if (id != taxRecordTime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxRecordTime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxRecordTimeExists(taxRecordTime.Id))
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
            ViewData["TaxRecordId"] = new SelectList(_context.TaxRecord, "Id", "Id", taxRecordTime.TaxRecordId);
            return View(taxRecordTime);
        }

        // GET: TaxRecordTimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxRecordTime = await _context.TaxRecordTimes
                .Include(t => t.TaxRecord)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxRecordTime == null)
            {
                return NotFound();
            }

            return View(taxRecordTime);
        }

        // POST: TaxRecordTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxRecordTime = await _context.TaxRecordTimes.FindAsync(id);
            if (taxRecordTime != null)
            {
                _context.TaxRecordTimes.Remove(taxRecordTime);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxRecordTimeExists(int id)
        {
            return _context.TaxRecordTimes.Any(e => e.Id == id);
        }
    }
}
