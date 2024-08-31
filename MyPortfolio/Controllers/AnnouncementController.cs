using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.Controllers
{
	public class AnnouncementController : Controller
	{
		MyPoftfolioContext context = new MyPoftfolioContext();
		public IActionResult AnnouncementList()
		{
			var values = context.Announcements.ToList();
			return View(values);
		}
	}
}
