using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.ViewComponents
{
    public class _ContactComponentPartial : ViewComponent
    {
        MyPoftfolioContext context = new MyPoftfolioContext();  
        public IViewComponentResult Invoke()
        {
            ViewBag.contactTitle = context.Contacts.Select(x=>x.Title).FirstOrDefault();
            ViewBag.contactDescription = context.Contacts.Select(x=>x.Description).FirstOrDefault();
            var values = context.Contacts.ToList();
            return View(values); 
        }  
    }
}
