using Microsoft.AspNetCore.Mvc;

namespace FoodLoverGuide.Controllers
{
    public class SocialMediaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
