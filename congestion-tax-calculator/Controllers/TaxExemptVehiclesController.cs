using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using congestion_tax_calculator.Data;
using congestion_tax_calculator.Models;

namespace congestion_tax_calculator.Controllers
{
    public class TaxExemptVehiclesController : Controller
    {
        private readonly congestion_tax_calculatorContext _context;

        public TaxExemptVehiclesController(congestion_tax_calculatorContext context)
        {
            _context = context;
        }

        // GET: TaxExemptVehicles
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaxExemptVehicles.ToListAsync());
        }

        // GET: TaxExemptVehicles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id==Guid.Empty)
            {
                return NotFound();
            }

            var taxExemptVehicles = await _context.TaxExemptVehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxExemptVehicles == null)
            {
                return NotFound();
            }

            return View(taxExemptVehicles);
        }

        // GET: TaxExemptVehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaxExemptVehicles/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsExemptVehicle")] TaxExemptVehicles taxExemptVehicles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taxExemptVehicles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taxExemptVehicles);
        }

        // GET: TaxExemptVehicles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var taxExemptVehicles = await _context.TaxExemptVehicles.FindAsync(id);
            if (taxExemptVehicles == null)
            {
                return NotFound();
            }
            return View(taxExemptVehicles);
        }

        // POST: TaxExemptVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,IsExemptVehicle")] TaxExemptVehicles taxExemptVehicles)
        {
            if (id != taxExemptVehicles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxExemptVehicles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxExemptVehiclesExists(taxExemptVehicles.Id))
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
            return View(taxExemptVehicles);
        }

        // GET: TaxExemptVehicles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var taxExemptVehicles = await _context.TaxExemptVehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxExemptVehicles == null)
            {
                return NotFound();
            }

            return View(taxExemptVehicles);
        }

        // POST: TaxExemptVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var taxExemptVehicles = await _context.TaxExemptVehicles.FindAsync(id);
            if (taxExemptVehicles != null)
            {
                _context.TaxExemptVehicles.Remove(taxExemptVehicles);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxExemptVehiclesExists(Guid id)
        {
            return _context.TaxExemptVehicles.Any(e => e.Id == id);
        }
    }
}
