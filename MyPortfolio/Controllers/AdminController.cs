using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
	public class AdminController : Controller
	{
		MyPoftfolioContext context = new MyPoftfolioContext();
		public IActionResult Login()
		{
			return View();
		}

		public IActionResult Login(string username, string password)
		{
			var admin = context.Users.FirstOrDefault(x => x.UserName == username && x.Password == password);
			if (admin == null)
			{
				HttpContext.Session.SetString("AdminUsername", admin.UserName);
				return RedirectToAction("Index", "Default");
			}
			ViewBag.Message = "Geçersiz Kullanıcı Adı Veya Şifre.";
			return View();
		}



       
	}
}
