using Microsoft.AspNetCore.Mvc;

namespace ProductApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
