using Microsoft.AspNetCore.Mvc;

namespace FoodLoverGuide.Controllers
{
    public class FeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
