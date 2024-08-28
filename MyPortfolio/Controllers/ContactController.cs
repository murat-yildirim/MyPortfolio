using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
	public class ContactController : Controller
	{
		MyPoftfolioContext context = new MyPoftfolioContext();
		public IActionResult ContactList()
		{
			var values = context.Contacts.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult ContactUpdate(int id)
		{
			var values = context.Contacts.Find(id);
			return View(values);
		}
		[HttpPost]
		public IActionResult ContactUpdate(Contact contact) 
		{
		
			context.Contacts.Update(contact);
			context.SaveChanges();
			return RedirectToAction("ContactList","Contact");
		}
	}
}
