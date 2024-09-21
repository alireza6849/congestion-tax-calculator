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
    public class WeekendDaysController : Controller
    {
        private readonly congestion_tax_calculatorContext _context;

        public WeekendDaysController(congestion_tax_calculatorContext context)
        {
            _context = context;
        }

        // GET: WeekendDays
        public async Task<IActionResult> Index()
        {
            return View(await _context.WeekendDays.ToListAsync());
        }

        // GET: WeekendDays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weekendDays = await _context.WeekendDays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weekendDays == null)
            {
                return NotFound();
            }

            return View(weekendDays);
        }

        // GET: WeekendDays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeekendDays/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] WeekendDays weekendDays)
        {
            if (ModelState.IsValid)
            {
                if(await _context.WeekendDays.AnyAsync(s => s.Name.Equals(weekendDays.Name))){
                    return RedirectToAction(nameof(Index));


                }



                _context.Add(weekendDays);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weekendDays);
        }

        // GET: WeekendDays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weekendDays = await _context.WeekendDays.FindAsync(id);
            if (weekendDays == null)
            {
                return NotFound();
            }
            return View(weekendDays);
        }

        // POST: WeekendDays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] WeekendDays weekendDays)
        {
            if (id != weekendDays.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weekendDays);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeekendDaysExists(weekendDays.Id))
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
            return View(weekendDays);
        }

        // GET: WeekendDays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weekendDays = await _context.WeekendDays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weekendDays == null)
            {
                return NotFound();
            }

            return View(weekendDays);
        }

        // POST: WeekendDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weekendDays = await _context.WeekendDays.FindAsync(id);
            if (weekendDays != null)
            {
                _context.WeekendDays.Remove(weekendDays);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeekendDaysExists(int id)
        {
            return _context.WeekendDays.Any(e => e.Id == id);
        }
    }
}
