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

			context.Users.Update(user);
			context.SaveChanges();
			return View();
		}
		[HttpGet]
		public IActionResult ProfilNewPassword()
		{
			// Oturum açmış kullanıcının kullanıcı adını al
			string username = User.Identity.Name;

			// Kullanıcının bilgilerini Users tablosundan al
			var user = context.Users.FirstOrDefault(u => u.UserName == username);

			return View(user);
		}


		[HttpPost]
		public IActionResult ProfilNewPassword(User userModel)
		{
			// Oturum açmış kullanıcının kullanıcı adını al
			string username = User.Identity.Name;

			// Kullanıcının bilgilerini Users tablosundan al
			var user = context.Users.FirstOrDefault(u => u.UserName == username);

			
				if (userModel.Password == userModel.PasswordAgain)
				{
					// Yeni şifreyi kaydet
					user.Password = userModel.Password;
					user.PasswordAgain = userModel.PasswordAgain;
					context.Users.Update(user);
					context.SaveChanges();

				// Başarı mesajını ayarla
				TempData["SuccessMessage"] = "Şifreniz başarıyla güncellendi.";
			}
			else
				{
					// Şifreler eşleşmiyorsa hata mesajını ekle
					ModelState.AddModelError("", "Yeni şifreler eşleşmiyor.");
				}
			
			return View(userModel);
		}
	}
}
