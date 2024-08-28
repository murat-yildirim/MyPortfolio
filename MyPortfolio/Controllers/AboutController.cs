using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
    public class AboutController : Controller
    {
        MyPoftfolioContext context = new MyPoftfolioContext();
		
		[HttpGet]
		public IActionResult AboutUpdate()
        {
			var value = context.Abouts.Find(1);
			return View(value);
		}
		[HttpPost]
		public IActionResult AboutUpdate(About about)
		{

			context.Abouts.Update(about);
			context.SaveChanges();
			return RedirectToAction("AboutUpdate");

		}
	}
}
