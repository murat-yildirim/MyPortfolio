using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace MyPortfolio.Controllers
{
	public class RegisterController : Controller
	{
		MyPoftfolioContext context = new MyPoftfolioContext();

		private readonly MyPoftfolioContext _context;
		private readonly PasswordHasher<User> _passwordHasher;
		public RegisterController()
		{
			_context = new MyPoftfolioContext();
			_passwordHasher = new PasswordHasher<User>();
		}


		public IActionResult Index()
		{
			return View();
		}

		[AllowAnonymous]
		public IActionResult RegisterIndex()
		{
			return View();
		}


		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> RegisterIndex(User data)
		{
			if (!ModelState.IsValid)
			{
				bool userExists = await context.Users.AnyAsync(u => u.UserName == data.UserName);
				bool emailExists = await context.Users.AnyAsync(u => u.Mail == data.Mail);

				if (userExists)
				{
					TempData["Error"] = "Bu kullanıcı adı zaten alınmış.";
					return View(data);
				}

				if (emailExists)
				{
					TempData["Error"] = "Bu e-posta adresi zaten kullanılıyor.";
					return View(data);
				}

				if (userExists || emailExists)
				{
					// Hatalar varsa kullanıcıyı tekrar döndür
					return View(data);
				}

				data.Password = _passwordHasher.HashPassword(data, data.Password);
				data.PasswordAgain = _passwordHasher.HashPassword(data, data.PasswordAgain);

				// Kullanıcıyı veritabanına ekle
				data.Role = "U"; // Varsayılan rol olarak belirleyin
				context.Users.Add(data);

				// Veritabanı değişikliklerini asenkron olarak kaydedin
				await context.SaveChangesAsync();

				// Kayıttan sonra yönlendirme
				return RedirectToAction("Index", "Login");
			}
			return View(data);
		}
	}
}

