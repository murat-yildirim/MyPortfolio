using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
	public class ContactMessageController : Controller
	{
		MyPoftfolioContext context = new MyPoftfolioContext();
	
		public IActionResult Index()
		{
		
			return View();
		}

		[HttpGet]
		public PartialViewResult ContactMessageSend()
		{
			return PartialView();
		}
		[HttpPost]
        public async Task<IActionResult> ContactMessageSend(ContactMessage contactMessage)
        {
            if (ModelState.IsValid)
            {
                try
                {
					contactMessage.SendDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
					contactMessage.IsRead = false;
					context.ContactMessages.Add(contactMessage);

                    await context.SaveChangesAsync();
                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Bir hata oluştu: " + ex.Message });
                }
            }
            return Json(new { success = false, message = "Model geçersiz" });
        }

        public IActionResult ContactMessageList()
        {
            var values = context.ContactMessages.ToList();
            return View(values);
        }
		public IActionResult ChangeIsReadToTrue(int id)
		{
			var value = context.ContactMessages.Find(id);
			value.IsRead = true;
			context.SaveChanges();
			return RedirectToAction("ContactMessageList");
		}
		public IActionResult ChangeIsReadToFalse(int id)
		{
			var value = context.ContactMessages.Find(id);
			value.IsRead = false;
			context.SaveChanges();
			return RedirectToAction("ContactMessageList");
		}

		public IActionResult ContactMessageDetail(int id)
		{
			var values = context.ContactMessages.Find(id);

			return View(values);
		}
	}
}
