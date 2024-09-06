using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;
using System.Security.Claims;

namespace MyPortfolio.Controllers
{

	public class LoginController : Controller
	{
		MyPoftfolioContext c = new MyPoftfolioContext();


		private readonly MyPoftfolioContext _context;
		private readonly PasswordHasher<User> _passwordHasher;
		public LoginController()
		{
			_context = new MyPoftfolioContext();
			_passwordHasher = new PasswordHasher<User>();
		}

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
			// Kullanıcıyı kullanıcı adına göre veritabanında bul
			var datavalue = c.Users.FirstOrDefault(x => x.UserName == p.UserName);

			if (datavalue != null)
			{
				// Kullanıcıdan alınan şifreyi hashleyip, veritabanındaki hashlenmiş şifre ile karşılaştırın
				var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(datavalue, datavalue.Password, p.Password);

				if (passwordVerificationResult == PasswordVerificationResult.Success)
				{
					// Şifre doğrulama başarılıysa, kullanıcının claim'lerini oluşturun
					var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, p.UserName),
				new Claim(ClaimTypes.Role, datavalue.Role) // Veritabanından rolü alıyoruz
			};

					var userIdentity = new ClaimsIdentity(claims, "Login");
					ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

					// Kullanıcıyı oturum açtır
					await HttpContext.SignInAsync(principal);

					// Kullanıcının rolüne göre yönlendirme yapın
					if (datavalue.Role == "A")
					{
						return RedirectToAction("Index", "Dashboard");
					}
					else
					{
						return RedirectToAction("UserDashboard", "Dashboard");
					}
				}
			}

			// Kullanıcı adı veya şifre yanlışsa, hata mesajı ile tekrar giriş sayfasına yönlendirin
			ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre.");
			return View(p);
		}

		[HttpGet]
		public async Task<IActionResult> LogOut()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Login");
		}
	}
}
