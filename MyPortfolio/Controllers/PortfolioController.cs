using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
	public class PortfolioController : Controller
	{
		MyPoftfolioContext context = new MyPoftfolioContext();

		public IActionResult PortfolioList()
		{
			var values = context.Portfolios.ToList();
			return View(values);
		}




		[HttpGet]
		public IActionResult PortfolioAdd()
		{
			
			return View();
		}
		[HttpPost]
		public IActionResult PortfolioAdd(Portfolio portfolio)
		{
			context.Portfolios.Add(portfolio);
			context.SaveChanges();
			return RedirectToAction("PortfolioList");
		}

		public IActionResult PortfolioDelete(int id)
		{
			var values = context.Portfolios.Find(id);
			context.Portfolios.Remove(values);
			context.SaveChanges();
			return RedirectToAction("PortfolioList");
		}

		[HttpGet]
		public IActionResult PortfolioUpdate(int id)
		{
			var values = context.Portfolios.Find(id);
			return View(values); 
		}
		[HttpPost]
		public IActionResult PortfolioUpdate(Portfolio portfolio)
		{
			context.Update(portfolio);
			context.SaveChanges();
			return RedirectToAction("PortfolioList");
		}
	}
}
