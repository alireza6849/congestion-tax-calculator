using Microsoft.AspNetCore.Mvc;

namespace congestion_tax_calculator.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
