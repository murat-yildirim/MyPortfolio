using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
