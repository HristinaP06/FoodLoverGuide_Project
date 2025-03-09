using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodLoverGuide.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
