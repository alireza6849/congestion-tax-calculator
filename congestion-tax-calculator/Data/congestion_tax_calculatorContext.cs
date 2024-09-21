using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using congestion_tax_calculator.Models.Holidays;
using congestion_tax_calculator.Models.TaxRecords;

namespace congestion_tax_calculator.Data
{
    public class congestion_tax_calculatorContext : DbContext
    {
        public congestion_tax_calculatorContext (DbContextOptions<congestion_tax_calculatorContext> options)
            : base(options)
        {
        }

        public DbSet<congestion_tax_calculator.Models.TaxExemptVehicles> TaxExemptVehicles { get; set; } = default!;
        public DbSet<congestion_tax_calculator.Models.WeekendDays> WeekendDays { get; set; } = default!;
        public DbSet<congestion_tax_calculator.Models.Holidays.Month> Month { get; set; } = default!;
        public DbSet<congestion_tax_calculator.Models.Holidays.DaysOfMonth> DaysOfMonth { get; set; } = default!;
        public DbSet<congestion_tax_calculator.Models.TaxRule> TaxRule { get; set; } = default!;
        public DbSet<TaxRecord> TaxRecord { get; set; } = default!;
        public DbSet<TaxRecordTime> TaxRecordTimes { get; set; } = default!;

    }
}
