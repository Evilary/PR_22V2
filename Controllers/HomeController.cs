using Microsoft.AspNetCore.Mvc;
namespace Shop_Chernyshkov_Final.Controllers

{
    public class HomeController : Controller
    {
        
        public RedirectResult Index()
        {
            return Redirect("/Items/List");
        }
    }
}
