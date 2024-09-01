using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.ViewComponents.LayoutViewComponents
{
	public class _LayoutNavbarComponentPartial : ViewComponent
	{
		MyPoftfolioContext context = new MyPoftfolioContext();
		public IViewComponentResult Invoke()
		{
			ViewBag.announcementCount = context.Announcements.Where(x=>x.Status == false).Count();
			var values = context.Announcements.Where(x => x.Status == false).ToList();

			// Oturum açmış kullanıcının kullanıcı adını al
			string username = User.Identity.Name;

			// Kullanıcının bilgilerini Users tablosundan al
			var user = context.Users.FirstOrDefault(u => u.UserName == username);

			if (user != null)
			{
				// Kullanıcının mail adresi, adı ve soyadını Message nesnesine ekle
				ViewBag.name = user.Name;
				ViewBag.surname = user.Surname;
				ViewBag.mail=user.Mail;
				
			}
			return View(values);
		}
	}
}
