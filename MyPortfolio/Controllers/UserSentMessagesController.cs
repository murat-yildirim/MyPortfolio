using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
	public class UserSentMessagesController : Controller
	{
		MyPoftfolioContext context = new MyPoftfolioContext();
		public IActionResult UserSendMessageList()
		{

			// Kullanıcının adını al
			string username = User.Identity.Name;

			// Kullanıcının e-posta adresini veritabanından al
			var userEmail = context.Users
								   .Where(u => u.UserName == username)
								   .Select(u => u.Mail)
								   .FirstOrDefault();

			if (userEmail == null)
			{
				// Eğer e-posta adresi bulunamazsa uygun bir hata döndürün
				return Unauthorized(); // veya uygun bir hata sayfasına yönlendirin
			}

			// E-posta adresine göre mesajları filtrele
			var values = context.Messages
								.Where(m => m.Email == userEmail)
								.ToList();

			return View(values);
		}
		[HttpGet]
		public IActionResult NewSendMessage()
		{
			return View();
		}
		[HttpPost]
		public IActionResult NewSendMessage(Message messagesend)
		{

			// Oturum açmış kullanıcının kullanıcı adını al
			string username = User.Identity.Name;

			// Kullanıcının bilgilerini Users tablosundan al
			var user = context.Users.FirstOrDefault(u => u.UserName == username);

			if (user != null)
			{
				// Kullanıcının mail adresi, adı ve soyadını Message nesnesine ekle
				messagesend.Email = user.Mail;
				messagesend.Surname = user.Surname;
				messagesend.Name = user.Name;
				messagesend.SendDate = DateTime.Now;

				// Mesajı veritabanına kaydet
				context.Messages.Add(messagesend);
				context.SaveChanges();
			}
			else
			{
				// Kullanıcı bulunamazsa uygun bir hata döndür
				return NotFound("Kullanıcı bulunamadı.");
			}

			// Mesaj gönderiminden sonra bir sayfaya yönlendir (örneğin, mesaj listesi)
			return RedirectToAction("UserSendMessageList");
		}
	}
}
