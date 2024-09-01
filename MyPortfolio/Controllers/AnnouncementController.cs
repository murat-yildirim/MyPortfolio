using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;
using MyPortfolio.DAL.Entities;

namespace MyPortfolio.Controllers
{
	public class AnnouncementController : Controller
	{
		MyPoftfolioContext context = new MyPoftfolioContext();
		public IActionResult AnnouncementList()
		{

			var values = context.Announcements.OrderByDescending(x=>x.Date).ToList();
			return View(values);
		}
        [Authorize(Roles = "A")]
        [HttpGet]
		public IActionResult AnnouncementAdd()
		{

			return View();
		}
        [Authorize(Roles = "A")]
        [HttpPost]
		public IActionResult AnnouncementAdd(Announcement announcement)
		{
			context.Announcements.Add(announcement);
			context.SaveChanges();
			return RedirectToAction("AnnouncementList");
		}
		public IActionResult AnnouncementDetail(int id)
		{
			var values = context.Announcements.Find(id);
			return View(values);
		}
        [Authorize(Roles = "A")]
        public IActionResult AnnouncementDelete(int id)
		{
			var values = context.Announcements.Find(id);
			context.Announcements.Remove(values);
			context.SaveChanges();
			return RedirectToAction("AnnouncementList");
		}
        [Authorize(Roles = "A")]
        [HttpGet]
		public IActionResult AnnouncementUpdate(int id)
		{
			var values = context.Announcements.Find(id);
			return View(values);
		}
        [Authorize(Roles = "A")]
        [HttpPost]
		public IActionResult AnnouncementUpdate(Announcement announcement)
		{
			
			context.Announcements.Update(announcement);
			context.SaveChanges();
			return RedirectToAction("AnnouncementList");
		}
       
	}
}
