using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using congestion_tax_calculator.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<congestion_tax_calculatorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("congestion_tax_calculatorContext") ?? throw new InvalidOperationException("Connection string 'congestion_tax_calculatorContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    await app.InitialiseDatabaseAsync();

}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
