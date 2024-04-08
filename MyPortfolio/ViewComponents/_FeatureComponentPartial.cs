using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.ViewComponents
{
    public class _FeatureComponentPartial : ViewComponent
    {
        MyPoftfolioContext portfolioContext = new MyPoftfolioContext(); 

        public IViewComponentResult Invoke() 
        {
            var values = portfolioContext.Features.ToList();    

            return View(values); 
        }  
    }
}
