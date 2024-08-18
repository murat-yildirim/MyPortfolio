using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.Controllers
{
	public class SkillController : Controller
	{
		MyPoftfolioContext context = new MyPoftfolioContext();
		public IActionResult SkillList()
		{
			var values = context.Skills.ToList();
			return View(values);
		}
	}
}
