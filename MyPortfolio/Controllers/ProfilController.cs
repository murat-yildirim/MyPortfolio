using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
	public class ProfilController : Controller
	{
		MyPoftfolioContext context = new MyPoftfolioContext();
		[HttpGet]
		public IActionResult ProfilView()
		{
			// Oturum açmış kullanıcının kullanıcı adını al
			string username = User.Identity.Name;

			// Kullanıcının bilgilerini Users tablosundan al
			var user = context.Users.FirstOrDefault(u => u.UserName == username);

			return View(user);
		}
		[HttpPost]
		public IActionResult ProfilView(User users)
		{
			// Oturum açmış kullanıcının kullanıcı adını al
			string username = User.Identity.Name;

			// Kullanıcının bilgilerini Users tablosundan al
			var user = context.Users.FirstOrDefault(u => u.UserName == username);

			user.Name = users.Name;
			user.Surname = users.Surname;
			user.Password = users.Password;
			user.PasswordAgain = users.PasswordAgain;
			var values = context.Users.Update(user);
			context.SaveChanges();
			return View();
		}
	}
}
