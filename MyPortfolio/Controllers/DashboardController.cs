using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.DAL.Context;
using System.Xml.Linq;

namespace MyPortfolio.Controllers
{
	public class DashboardController : Controller
	{
		MyPoftfolioContext context = new MyPoftfolioContext();
		[Authorize(Roles = "A")]
		public IActionResult Index()
		{

			// Statistik verileri ViewBag'e ekleyin
			ViewBag.v1 = context.Skills.Count();
			ViewBag.v2 = context.Messages.Count();
			ViewBag.v3 = context.Messages.Where(x => x.IsRead == false).Count();
			ViewBag.v4 = context.Messages.Where(x => x.IsRead == true).Count();

			////Weather APİ
			//string api = "5f6f59be2beceaaba4c683f616c33f98";
			//string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
			//XDocument document = XDocument.Load(connection);
			//ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

			// ToDoList verilerini model olarak gönderin
			var toDoLists = context.ToDoLists
	.OrderByDescending(x => x.Date) // yeniden eskiye Tarihe göre sıralama
	.Take(3) // İlk 3 kaydı al
	.ToList();
			return View(toDoLists); // List<ToDoList> modeli


		}
		[Authorize(Roles = "A")]
		public IActionResult StatisticList()
		{
			ViewBag.v1 = context.Skills.Count();
			ViewBag.v2 = context.Messages.Count();
			ViewBag.v3 = context.Messages.Where(x => x.IsRead == false).Count();
			ViewBag.v4 = context.Messages.Where(x => x.IsRead == true).Count();
			return PartialView("StatisticList"); // PartialView döndürür
		}

		[Authorize(Roles = "A")]
		public IActionResult DashboardToDoList()
		{
			var values = context.ToDoLists
	.OrderByDescending(x => x.Date) // yeniden eskiye Tarihe göre sıralama
	.Take(3) // İlk 3 kaydı al
	.ToList();
			return PartialView("DashboardToDoList", values); // PartialView ve model gönderir	
		}

		public IActionResult UserDashboard()
		{

			////Weather APİ
			//string api = "5f6f59be2beceaaba4c683f616c33f98";
			//string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
			//XDocument document = XDocument.Load(connection);
			//ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

			
			return View();


		}
	}
}
