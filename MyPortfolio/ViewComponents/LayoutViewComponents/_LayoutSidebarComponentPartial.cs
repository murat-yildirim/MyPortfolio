using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.ViewComponents.LayoutViewComponents
{
	public class _LayoutSidebarComponentPartial: ViewComponent
	{
		MyPoftfolioContext context = new MyPoftfolioContext();
		public IViewComponentResult Invoke()
		{
			

			// Oturum açmış kullanıcının kullanıcı adını al
			string username = User.Identity.Name;

			// Kullanıcının bilgilerini Users tablosundan al
			var user = context.Users.FirstOrDefault(u => u.UserName == username);

			if (user != null)
			{
				// Kullanıcının mail adresi, adı ve soyadını Message nesnesine ekle
				ViewBag.name = user.Name;
				ViewBag.surname = user.Surname;	
				if(user.Role == "A")
				{
					ViewBag.role = "Admin";
				}
                else
                {
					ViewBag.role = "Üye";
				}
            }
			return View();
		}
	}
}
