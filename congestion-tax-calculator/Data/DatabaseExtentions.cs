using Microsoft.EntityFrameworkCore;

namespace congestion_tax_calculator.Data
{
    public static class DatabaseExtentions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<congestion_tax_calculatorContext>();

            context.Database.MigrateAsync().GetAwaiter().GetResult();

            await SeedAsync(context);
        }
        private static async Task SeedAsync(congestion_tax_calculatorContext context)
        {
            await SeedWeekendDaysAsync(context);
            await TaxExemptVehicles(context);
            await TaxRule(context);
            await Month(context);
            await DaysOfMonth(context);
            await TaxRecords(context);
            await TaxRecordsTimes(context);
        }
        private static async Task SeedWeekendDaysAsync(congestion_tax_calculatorContext context)
        {
            if (!await context.WeekendDays.AnyAsync())
            {
                await context.WeekendDays.AddRangeAsync(InitialData.w);
                await context.SaveChangesAsync();
            }
        }
        private static async Task TaxExemptVehicles(congestion_tax_calculatorContext context)
        {
            if (!await context.TaxExemptVehicles.AnyAsync())
            {
                await context.TaxExemptVehicles.AddRangeAsync(InitialData.t);
                await context.SaveChangesAsync();
            }
        }
        private static async Task TaxRule(congestion_tax_calculatorContext context)
        {
            if (!await context.TaxRule.AnyAsync())
            {
                await context.TaxRule.AddRangeAsync(InitialData._taxrule);
                await context.SaveChangesAsync();
            }
        }
        private static async Task Month(congestion_tax_calculatorContext context)
        {
            if (!await context.Month.AnyAsync())
            {
                await context.Month.AddRangeAsync(InitialData._month);
                await context.SaveChangesAsync();
            }
        }
        private static async Task DaysOfMonth(congestion_tax_calculatorContext context)
        {
            if (!await context.DaysOfMonth.AnyAsync())
            {
                await context.DaysOfMonth.AddRangeAsync(InitialData._daysofmonth);
                await context.SaveChangesAsync();
            }
        }
        private static async Task TaxRecords(congestion_tax_calculatorContext context)
        {
            if (!await context.TaxRecord.AnyAsync())
            {
                await context.TaxRecord.AddRangeAsync(InitialData._taxRecord);
                await context.SaveChangesAsync();
            }
        }
        private static async Task TaxRecordsTimes(congestion_tax_calculatorContext context)
        {
            if (!await context.TaxRecordTimes.AnyAsync())
            {
                await context.TaxRecordTimes.AddRangeAsync(InitialData._taxRecordTime);
                await context.SaveChangesAsync();
            }
        }
    }
}
