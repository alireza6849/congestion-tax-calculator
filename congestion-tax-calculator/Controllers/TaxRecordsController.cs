using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using congestion_tax_calculator.Data;
using congestion_tax_calculator.Models.TaxRecords;
using congestion_tax_calculator.Models;

namespace congestion_tax_calculator.Controllers
{
    public class TaxRecordsController : Controller
    {
        private readonly congestion_tax_calculatorContext _context;

        public TaxRecordsController(congestion_tax_calculatorContext context)
        {
            _context = context;
        }

        // GET: TaxRecords
        public async Task<IActionResult> Index()
        {
            var congestion_tax_calculatorContext = _context.TaxRecord.Include(t => t.CarType);
            return View(await congestion_tax_calculatorContext.ToListAsync());
        }

        // GET: TaxRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxRecord = await _context.TaxRecord
                .Include(t => t.CarType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxRecord == null)
            {
                return NotFound();
            }
            var history = await _context.TaxRecordTimes.Where(s => s.TaxRecordId.Equals(id)).Select(s=>s.Date).ToListAsync();
            TempData["tax"]  = GetTax(taxRecord, history);
            return View(taxRecord);
        }

        // GET: TaxRecords/Create
        public IActionResult Create()
        {
            ViewData["CarTypeId"] = new SelectList(_context.TaxExemptVehicles, "Id", "Name");
            return View();
        }

        // POST: TaxRecords/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarName,LicensePlateNumber,CarTypeId")] TaxRecord taxRecord)
        {

            if (ModelState.IsValid)
            {
                if(await _context.TaxRecord.AnyAsync(s => s.LicensePlateNumber.Equals(taxRecord.LicensePlateNumber))){
                    return RedirectToAction(nameof(Index));

                }
                _context.Add(taxRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CarTypeId"] = new SelectList(_context.TaxExemptVehicles, "Id", "Name", taxRecord.CarTypeId);
            return View(taxRecord);
        }

        // GET: TaxRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxRecord = await _context.TaxRecord.FindAsync(id);
            if (taxRecord == null)
            {
                return NotFound();
            }
            ViewData["CarTypeId"] = new SelectList(_context.TaxExemptVehicles, "Id", "Name", taxRecord.CarTypeId);
            return View(taxRecord);
        }

        // POST: TaxRecords/Edit/5
  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarName,LicensePlateNumber,CarTypeId")] TaxRecord taxRecord)
        {
            if (id != taxRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxRecordExists(taxRecord.Id))
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
            ViewData["CarTypeId"] = new SelectList(_context.TaxExemptVehicles, "Id", "Name", taxRecord.CarTypeId);
            return View(taxRecord);
        }

        // GET: TaxRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxRecord = await _context.TaxRecord
                .Include(t => t.CarType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxRecord == null)
            {
                return NotFound();
            }

            return View(taxRecord);
        }

        // POST: TaxRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxRecord = await _context.TaxRecord.FindAsync(id);
            if (taxRecord != null)
            {
                _context.TaxRecord.Remove(taxRecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult InsertTainsertTravelTime(int id)
        {
         
            return View(id);
        }
  

        private bool TaxRecordExists(int id)
        {
            return _context.TaxRecord.Any(e => e.Id == id);
        }

        public int GetTax(TaxRecord  taxRecord,List< DateTime> dates)
        {
            DateTime intervalStart = dates[0];
            int totalFee = 0;
            foreach (DateTime date in dates)
            {
                int nextFee = GetTollFee(date, taxRecord);
                int tempFee = GetTollFee(intervalStart, taxRecord);

                long diffInMillies = date.Millisecond - intervalStart.Millisecond;
                long minutes = diffInMillies / 1000 / 60;

                if (minutes <= 60)
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                {
                    totalFee += nextFee;
                }
            }
            if (totalFee > 60) totalFee = 60;
            return totalFee;
        }
        private bool IsTollFreeVehicle(TaxRecord vehicle)
        {
            if (vehicle == null) return false;
            var  vehicleType = vehicle.CarType;
            if (vehicleType.IsExemptVehicle)
            {
                return true;
            }
            else
                return false; 
        }
        public  int GetTollFee(DateTime date, TaxRecord vehicle)
        {
            if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicle)) return 0;

            int hour = date.Hour;
            int minute = date.Minute;


            var taxtimes =  _context.TaxRule.ToList();

            foreach (var item in taxtimes)
            {
                if(hour==item.FromTime.Hour && minute >=item.FromTime.Minute && minute <= item.ToTime.Minute)
                {
                    return item.Amount;
                }
            }
            return 0; 
        }

        private Boolean IsTollFreeDate(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            var weekends = _context.WeekendDays.ToList();
            var holidays =  _context.DaysOfMonth.Include(t=>t.Month).ToList();
            foreach (var item in weekends)
            {
                if(WeekendDaysMap(date.DayOfWeek) == item.Name)
                {
                    return true;
                }
            }
            foreach (var item in holidays)
            {
                if(month == item.Month.Number && day == item.Number)
                {
                    return true;
                }
            }
            return false; 
        }

        public WeekendDaysName WeekendDaysMap(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek) {
                case DayOfWeek.Monday:
                    return WeekendDaysName.Monday;
                    case DayOfWeek.Tuesday:
                    return WeekendDaysName.Tuesday;
                    case DayOfWeek.Wednesday:
                    return WeekendDaysName.Wednesday;
                    case DayOfWeek.Thursday:
                    return WeekendDaysName.Thursday;
                    case DayOfWeek.Friday:
                    return WeekendDaysName.Friday;
                    case DayOfWeek.Saturday:
                    return WeekendDaysName.Saturday;
                case DayOfWeek.Sunday:
                    return WeekendDaysName.sunday;
                    default:
                    return WeekendDaysName.sunday;

            }

        } 

    }
}
