using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;
using System.Security.Claims;

namespace MyPortfolio.Controllers
{

	public class LoginController : Controller
	{
		MyPoftfolioContext c = new MyPoftfolioContext();

		[AllowAnonymous]
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}


		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Index(User p)
		{
			var datavalue = c.Users.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
			if (datavalue != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name,p.UserName),
					new Claim(ClaimTypes.Role, datavalue.Role) // Veritabanından rolü alıyoruz
				};
				var useridentity = new ClaimsIdentity(claims, "Login");
				ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(principal);

				return RedirectToAction("Index", "Dashboard");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> LogOut()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Login");
		}
	}
}
