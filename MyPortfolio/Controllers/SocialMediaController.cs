using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
	public class SocialMediaController : Controller
	{
		MyPoftfolioContext context = new MyPoftfolioContext();
		public IActionResult SocialMediaList()
		{
			var values = context.SocialMedias.ToList();
			return View(values);
		}

		[HttpGet]
		public IActionResult SocialMediaAdd()
		{
			return View();
		}
		[HttpPost]
		public IActionResult SocialMediaAdd(SocialMedia social)
		{
			context.SocialMedias.Add(social);
			context.SaveChanges();
			return RedirectToAction("SocialMediaList");
		}

		public IActionResult SocialMediaDelete(int id)
		{
			var values = context.SocialMedias.Find(id);
			context.SocialMedias.Remove(values);
			context.SaveChanges();
			return RedirectToAction("SocialMediaList");
		}

		[HttpGet]
		public IActionResult SocialMediaUpdate(int id)
		{
			var values = context.SocialMedias.Find(id);
			return View(values);
		}
		[HttpPost]
		public IActionResult SocialMediaUpdate(SocialMedia social)
		{
			context.SocialMedias.Update(social);
			context.SaveChanges();
			return RedirectToAction("SocialMediaList");
		}

		
	}
}
