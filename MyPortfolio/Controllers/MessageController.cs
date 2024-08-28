using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.Controllers
{
	public class MessageController : Controller
	{
		MyPoftfolioContext context = new MyPoftfolioContext();
		public IActionResult Inbox()
		{
			var values = context.Messages.ToList();
			return View(values);
		}
		public IActionResult ChangeIsReadToTrue(int id)
		{
			var value = context.Messages.Find(id);
			value.IsRead = true;
			context.SaveChanges();
			return RedirectToAction("Inbox");
		}
		public IActionResult ChangeIsReadToFalse(int id)
		{
			var value = context.Messages.Find(id);
			value.IsRead = false;
			context.SaveChanges();
			return RedirectToAction("Inbox");
		}
		public IActionResult DeleteMessage(int id)
		{
			var value = context.Messages.Find(id);
			context.Messages.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Inbox");

		}
		[Authorize(Roles = "A")]
		public IActionResult MessageDetail(int id)
		{
			var value = context.Messages.Find(id);
			return View(value);
		}
		public IActionResult UserMessageDetail(int id)
		{
			// Kullanıcının kullanıcı adını al
			string username = User.Identity.Name;

			// Kullanıcının e-posta adresini veritabanından al
			var userEmail = context.Users
								   .Where(u => u.UserName == username)
								   .Select(u => u.Mail)
								   .FirstOrDefault();

			if (userEmail == null)
			{
				// Eğer e-posta adresi bulunamazsa uygun bir hata döndürün
				return Unauthorized();
			}

			// İlgili mesajı veritabanından al
			var message = context.Messages.FirstOrDefault(m => m.MessageId == id);

			if (message == null)
			{
				// Eğer mesaj bulunamazsa 404 sayfasına yönlendir
				return NotFound();
			}

			// Eğer mesajın sahibi giriş yapan kullanıcı değilse
			if (message.Email != userEmail)
			{
				// Erişim yetkisi olmadığını belirten bir sayfaya yönlendir
				return Forbid(); // veya Unauthorized() ya da özel bir hata sayfası
			}

			// Mesajın detaylarını görüntüle
			return View(message);
		}
	}
}
